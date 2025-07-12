using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using clsLibrary;



namespace Inventory
{
    public partial class frmCustDetails : Form
    {
        public frmCustDetails(string Code, string Descrip)
        {
            InitializeComponent();
            txtCustCode.Text = Code;
            this.Text = Descrip;
            this.Load+=new EventHandler(this.btnOk_Click);
        }
        clsSupplier objcustdetail = new clsSupplier();

        private static frmCustDetails frmCustDetail;
        public static frmCustDetails GetfrmCustDetail
        {
            get { return frmCustDetail; }
            set { frmCustDetail = value; }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            newModule.ClearForm(this);
            txtCusCode.Focus();

        }

        public void savemeth()
        {
            

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                frmCustDetail = null;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    //m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmSalesman 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip3_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmCustDetails_KeyDown(object sender, KeyEventArgs e)
       {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtRefClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    objcustdetail.SqlStatement = "SELECT tb_CustReferees.RefNIC, tb_CustReferees.CustomerCode, Customer.Cust_Name FROM tb_CustReferees INNER JOIN Customer ON tb_CustReferees.CustomerCode = Customer.Cust_Code WHERE (tb_CustReferees.RefNIC = '" + txtRefNIC.Text.Trim() + "')AND CustomerCode <> '" + txtCustCode.Text.Trim() + "'";
                    objcustdetail.ReadDuplicateNIC();
                    if (objcustdetail.RecordFound == true)
                    {
                        MessageBox.Show("You have already insert NIC (" + txtRefNIC.Text.Trim() + ") under the " + objcustdetail.Cust_Name.ToUpper() + "", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtRefNIC.SelectAll();
                        txtRefNIC.Focus();
                    }
                    else
                    {
                        if (txtRefName.Text==string.Empty)
                        {
                            MessageBox.Show("Can't save Details without Referees Name",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
                            txtRefName.Focus();
                            return;
                        }
                        if (txtRefBirthday.Text.Length != 10)
                        {
                            MessageBox.Show("Birthday was not compeate",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
                            txtRefBirthday.Focus();
                            return;
                        }
                        objcustdetail.GetCustCode = txtCustCode.Text.Trim();
                        objcustdetail.GetRefName = txtRefName.Text.Trim();
                        objcustdetail.GetRefBirthday = Convert.ToDateTime(string.Format("{0:dd/MM/yyyy}", txtRefBirthday.Text.Trim()));
                        objcustdetail.GetRefNIC = txtRefNIC.Text.Trim();
                        objcustdetail.GetRefOccupation = txtRefOcupatn.Text.Trim();
                        objcustdetail.GetClass = txtRefClass.Text.Trim();
                        objcustdetail.tempInsertCutDetail();

                        objcustdetail.SqlStatement = "SELECT RefName, RefBirthday, RefNIC, RefOccupation, Class FROM tb_CustReferees WHERE CustomerCode='" + txtCustCode.Text.Trim() + "'";
                        objcustdetail.DataSetName = "tb_CustReferees";
                        objcustdetail.GetCustomerDetails();
                        dgRefreesDetails.DataSource = objcustdetail.GetCustomerDataset.Tables["tb_CustReferees"];
                        dgRefreesDetails.Refresh();
                        txtRefName.Text = string.Empty;
                        txtRefBirthday.Text = string.Empty;
                        txtRefNIC.Text = string.Empty;
                        txtRefOcupatn.Text = string.Empty;
                        txtRefClass.Text = string.Empty;
                        txtRefName.Focus();
                    }
                }
                catch (Exception ex)
                {

                   // throw ex;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //objcustdetail.SqlStatement = "SELECT  tb_Customer_Detail.CustomerCode, tb_Customer_Detail.Occupation, tb_Customer_Detail.Address1, tb_Customer_Detail.Address2, tb_Customer_Detail.Address3, tb_Customer_Detail.Phone, tb_Customer_Detail.MonIncome, tb_Customer_Detail.SpouseName, tb_Customer_Detail.SpOccupation, tb_Customer_Detail.SpAddress, tb_Customer_Detail.SpAddress2, tb_Customer_Detail.SpAddress3, tb_Customer_Detail.SpPhone, tb_Customer_Detail.SpMonIncome, tb_Customer_Detail.ComName, tb_Customer_Detail.ComAddress1, tb_Customer_Detail.ComAddress2, tb_Customer_Detail.ComAddress3, tb_Customer_Detail.ComPhone, tb_CustReferees.RefName, tb_CustReferees.RefBirthday, tb_CustReferees.RefNIC, tb_CustReferees.RefOccupation, tb_CustReferees.Class FROM tb_Customer_Detail INNER JOIN tb_CustReferees ON tb_CustReferees.CustomerCode = tb_Customer_Detail.CustomerCode WHERE tb_Customer_Detail.CustomerCode='" + txtCustCode.Text.Trim() + "'";
                objcustdetail.SqlStatement = "SELECT  tb_Customer_Detail.CustomerCode, tb_Customer_Detail.Occupation, tb_Customer_Detail.Address1, tb_Customer_Detail.Address2, tb_Customer_Detail.Address3, tb_Customer_Detail.Phone, tb_Customer_Detail.MonIncome, tb_Customer_Detail.SpouseName, tb_Customer_Detail.SpOccupation, tb_Customer_Detail.SpAddress, tb_Customer_Detail.SpAddress2, tb_Customer_Detail.SpAddress3, tb_Customer_Detail.SpPhone, tb_Customer_Detail.SpMonIncome,tb_Customer_Detail.ComName, tb_Customer_Detail.ComAddress1, tb_Customer_Detail.ComAddress2, tb_Customer_Detail.ComAddress3, tb_Customer_Detail.ComPhone FROM tb_Customer_Detail INNER JOIN Customer ON tb_Customer_Detail.CustomerCode = Customer.Cust_Code WHERE Customer.Cust_Code='" + txtCustCode.Text.Trim() + "'";
                objcustdetail.DataSetName = "CustDetails";
                objcustdetail.GetCustomerDetails();
                foreach (DataRow row in objcustdetail.GetCustomerDataset.Tables["CustDetails"].Rows)
                {
                    txtCustCode.Text = row["CustomerCode"].ToString();
                    txtOccupation.Text = row["Occupation"].ToString();
                    txtAddress1.Text = row["Address1"].ToString();
                    txtAddress2.Text = row["Address2"].ToString();
                    txtAddress3.Text = row["Address3"].ToString();
                    txtPhone.Text = row["Phone"].ToString();
                    txtMIncom.Text = row["MonIncome"].ToString();
                    txtSpouseNa.Text = row["SpouseName"].ToString();
                    txtSpouseOcc.Text = row["SpOccupation"].ToString();
                    txtSPAddress.Text = row["SpAddress"].ToString();
                    txtSPAddress2.Text = row["SpAddress2"].ToString();
                    txtSPAddress3.Text = row["SpAddress3"].ToString();
                    txtSPPhone.Text = row["SpPhone"].ToString();
                    txtSpMIncom.Text = row["SpMonIncome"].ToString();
                    txtComName.Text = row["ComName"].ToString();
                    txtComAdd1.Text = row["ComAddress1"].ToString();
                    txtComAdd2.Text = row["ComAddress2"].ToString();
                    txtComAdd3.Text = row["ComAddress3"].ToString();
                    txtComPhone.Text = row["ComPhone"].ToString();
                }
                objcustdetail.SqlStatement = "SELECT * FROM tb_CustReferees WHERE CustomerCode = '" + txtCustCode.Text.Trim() + "'";
                objcustdetail.DataSetName = "CustReferees";
                objcustdetail.GetCustomerDetails();
                dgRefreesDetails.DataSource = objcustdetail.GetCustomerDataset.Tables["CustReferees"];
                dgRefreesDetails.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustCode.Text != string.Empty)
                {


                    objcustdetail.GetCustCode = txtCustCode.Text.Trim();
                    objcustdetail.GetOccupation = txtOccupation.Text.Trim();
                    objcustdetail.GetAddress1 = txtAddress1.Text.Trim();
                    objcustdetail.GetAddress2 = txtAddress2.Text.Trim();
                    objcustdetail.GetAddress3 = txtAddress3.Text.Trim();
                    objcustdetail.GetPhone = txtPhone.Text.Trim();
                    objcustdetail.GetMonIncome = decimal.Parse(txtMIncom.Text.Trim());
                    objcustdetail.GetSpouseName = txtSpouseNa.Text.Trim();
                    objcustdetail.GetSpOccupation = txtSpouseOcc.Text.Trim();
                    objcustdetail.GetSpAddress = txtSPAddress.Text.Trim();
                    objcustdetail.GetSpAddress2 = txtSPAddress2.Text.Trim();
                    objcustdetail.GetSpAddress3 = txtSPAddress3.Text.Trim();
                    objcustdetail.GetSpPhone = txtSPPhone.Text.Trim();
                    objcustdetail.GetSpMonIncome = decimal.Parse(txtSpMIncom.Text.Trim());
                    objcustdetail.GetComName = txtComName.Text.Trim();
                    objcustdetail.GetComAddress1 = txtComAdd2.Text.Trim();
                    objcustdetail.GetComAddress2 = txtComAdd3.Text.Trim();
                    objcustdetail.GetComAddress3 = txtComAdd3.Text.Trim();
                    objcustdetail.GetComPhone = txtComPhone.Text.Trim();
                    objcustdetail.InsertCutDetail();
                }
                else
                {
                    MessageBox.Show("Test");
                }
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void frmCustDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCustDetails.GetfrmCustDetail = null;
        }

        private void txtMIncom_Leave(object sender, EventArgs e)
        {
            if (txtMIncom.Text==string.Empty)
            {
                txtMIncom.Text = "0.00";
            }
        }

        private void txtSpMIncom_Leave(object sender, EventArgs e)
        {
            if (txtSpMIncom.Text == string.Empty)
            {
                txtSpMIncom.Text = "0.00";
            }
        }

        private void txtRefName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                txtRefBirthday.Focus();
            }
        }

        private void txtRefBirthday_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRefNIC.Focus();
            }
        }

        private void txtRefNIC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRefOcupatn.Focus();
            }
        }

        private void txtRefOcupatn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRefClass.Focus();
            }
        }

        private void dgRefreesDetails_DoubleClick(object sender, EventArgs e)
        {
            if (dgRefreesDetails.SelectedRows.Count <= 0 || dgRefreesDetails.SelectedRows[0].Cells[0].ToString() == "")
            {
                MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtRefName.Text = dgRefreesDetails.SelectedRows[0].Cells[0].Value.ToString();
                txtRefBirthday.Text = dgRefreesDetails.SelectedRows[0].Cells[1].Value.ToString();
                txtRefNIC.Text = dgRefreesDetails.SelectedRows[0].Cells[2].Value.ToString();
                txtRefOcupatn.Text = dgRefreesDetails.SelectedRows[0].Cells[3].Value.ToString();
                txtRefClass.Text = dgRefreesDetails.SelectedRows[0].Cells[4].Value.ToString();
                txtRefName.SelectAll();
                txtRefName.Focus();
            }
        }
      
    }
}