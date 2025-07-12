using clsLibrary;
using Inventory.Properties;
using Microsoft.Office.Interop.Excel;
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
using Point = System.Drawing.Point;

namespace Inventory
{
    public partial class frmCustomerAppointment : Form
    {
        public frmCustomerAppointment()
        {
            InitializeComponent();
        }
        private frmSearch search = new frmSearch();
        clsWholeSaleInvoice objWholeInvoice = new clsWholeSaleInvoice();
        bool CusSearching = false;
        public static frmCustomerAppointment GetForm { get; set; }
        private void btnNewCust_Click(object sender, EventArgs e)
        {
            try
            {
                if (frmAccounts.GetAccount != null)
                {
                    frmAccounts.GetAccount.Close();
                }

                frmAccounts.GetAccount = new frmAccounts();
                frmAccounts.GetAccount.CustCode = txtCustCode.Text;
                frmAccounts.GetAccount.frmOpenFrom = "Appoinment";
                frmAccounts.GetAccount.ShowDialog();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void btnCustomerSearch_Click(object sender, EventArgs e)
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

                if (txtCustCode.Text.Trim() != string.Empty && txtCustName.Text.Trim() == string.Empty)
                {
                    objWholeInvoice.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name],Mobile " +
                        "FROM Customer JOIN dbo.CRM_Customer ON Cus_Code=Cust_Code WHERE (Cust_Code LIKE '%" + txtCustCode.Text.Trim() + "%' OR Mobile LIKE '%" + txtCustCode.Text.Trim() + "%'  ) " +
                        "AND dbo.CRM_Customer.Inactive=0  " + Loca + "    ORDER BY Cust_Code";
                }
                else
                {
                    if (txtCustCode.Text.Trim() == string.Empty && txtCustName.Text.Trim() != string.Empty)
                    {
                        objWholeInvoice.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name],Mobile FROM Customer JOIN dbo.CRM_Customer ON Cus_Code=Cust_Code " +
                            "WHERE  (Cust_Name LIKE '%" + txtCustName.Text.Trim() + "%'  Or Mobile LIKE '%" + txtCustName.Text.Trim() + "%' ) " +
                            "AND dbo.CRM_Customer.Inactive=0 " + Loca + "    ORDER BY Cust_Name";

                    }
                    else
                    {
                        objWholeInvoice.SqlStatement = "SELECT Cust_Code AS [Customer Code],Cust_Name AS [Customer Name],Mobile FROM Customer  JOIN dbo.CRM_Customer ON Cus_Code=Cust_Code " +
                            "WHERE  dbo.CRM_Customer.Inactive=0 " + Loca + "   ORDER BY Cust_Code";
                    }
                }

                objWholeInvoice.DataetName = "dsCustomer";
                objWholeInvoice.GetCustomerDetails();
                search.dgSearch.DataSource = objWholeInvoice.GetCustomerDataSet.Tables["dsCustomer"];
                search.prop_Focus = txtCustCode;
                search.Cont_Descript = txtCustName;

                search.Show();
                search.Location = new Point(this.Location.X, this.Location.Y + 100);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtCustName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtCustCode.Text.Trim() != "" && txtCustName.Text.Trim() != "")
                {
                    txtConNo.Focus();
                }
                if (e.KeyCode == Keys.Enter && txtCustName.Text.Trim() == "")
                {
                    txtCustCode.Focus();
                }
                if (e.KeyCode == Keys.F5)
                {
                    if (CusSearching == true)
                    {
                        CusSearching = false;
                        txtCustName.BackColor = Color.Empty;
                        txtCustCode.BackColor = Color.Empty;
                        search.Hide();

                    }
                    else
                    {
                        CusSearching = true;
                        txtCustCode.BackColor = Color.MediumAquamarine;
                        txtCustName.BackColor = Color.MediumAquamarine;
                    }
                }
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    e.Handled = true;
                    search.Focus();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    txtCustName.Text = txtCustCode.Text = string.Empty;
                }
                if (search.dgSearch.Rows.Count > 0 && search.Visible)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        search.selectRow();
                        return;
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
                if (e.KeyCode == Keys.Enter && txtCustName.Text.Trim() != "")
                {
                    objWholeInvoice.CustName = txtCustName.Text.ToString().Trim();
                    objWholeInvoice.SqlStatement = "SELECT Cust_Code, Cust_Name, C.Address1, Contact_Prsn Address2, C.Address3,VAT,VatNo,PaymentType,Tel,C.Age FROM dbo.CRM_Customer CRM JOIN dbo.Customer C ON Cust_Name=Cus_Name WHERE (Mobile LIKE '%" + txtCustName.Text.Trim() + "%' OR Cus_Name LIKE '%" + txtCustName.Text.Trim() + "%')  AND C.Inactive=0 ";
                    objWholeInvoice.ReadCustomerDetails();
                    if (objWholeInvoice.RecordFound == true)
                    {
                        txtCustCode.Text = objWholeInvoice.CustCode;
                        txtCustName.Text = objWholeInvoice.CustName;
                        txtConNo.Text = objWholeInvoice.Mobile;
                        //txtConper.Text = objWholeInvoice.Address1;
                        txtAge.Text = objWholeInvoice.Age;
                    }
                    else
                    {
                        MessageBox.Show("Customer Code Not Found OR Invalid Payment Type OR Invalid Customer Type.", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCustName.Focus();
                        txtCustName.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtCustName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCustName.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && CusSearching == true)
            {
                btnCustomerSearch.PerformClick();
            }
            if (txtCustName.Text.Trim() == string.Empty && search.Visible == true)
            {
                search.Hide();
            }
        }

        private void txtCustCode_Enter(object sender, EventArgs e)
        {
            if (search.Code != null && search.Code != "")
            {
                txtCustCode.Text = search.Code.Trim();
                txtCustName.Text = search.Descript.Trim();
                txtCustName.Focus();
            }
            search.Code = string.Empty;
            search.Descript = string.Empty;
        }

        public void txtCustCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtCustCode.Text.Trim() != "" && txtCustName.Text.Trim() != "")
                {
                    txtCustName.Focus();
                }
                if (e.KeyCode == Keys.Enter && txtCustCode.Text.Trim() == "")
                {
                    txtCustName.Focus();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    txtCustName.Text = txtCustCode.Text = string.Empty;
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
                if (e.KeyCode == Keys.Enter && txtCustCode.Text.Trim() != "")
                {
                    objWholeInvoice.CustCode = txtCustCode.Text.ToString().Trim();
                    objWholeInvoice.SqlStatement = "SELECT Cust_Code, Cust_Name, C.Address1, Contact_Prsn Address2, C.Address3,VAT,VatNo,PaymentType,Tel,C.Age FROM dbo.CRM_Customer CRM JOIN dbo.Customer C ON Cust_Code=Cus_Code WHERE (Mobile LIKE '%" + txtCustCode.Text.Trim() + "%' OR Cus_Code LIKE '%" + txtCustCode.Text.Trim() + "%')  AND C.Inactive=0 ";
                    objWholeInvoice.ReadCustomerDetails();
                    if (objWholeInvoice.RecordFound == true)
                    {
                        txtCustCode.Text = objWholeInvoice.CustCode;
                        txtCustName.Text = objWholeInvoice.CustName;
                        txtConNo.Text = objWholeInvoice.Mobile;
                        //txtConper.Text = objWholeInvoice.Address1;
                        txtAge.Text = objWholeInvoice.Age;
                    }
                    else
                    {
                        MessageBox.Show("Customer Code Not Found OR Invalid Payment Type OR Invalid Customer Type.", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCustCode.Focus();
                        txtCustCode.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtCustCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCustCode.Text != "" && e.KeyCode != Keys.F3 && e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down && e.KeyCode != Keys.F1 && e.KeyCode != Keys.Escape && e.KeyCode != Keys.F5 && CusSearching == true)
            {
                btnCustomerSearch.PerformClick();
            }
        }

        private void frmCustomerAppointment_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                objWholeInvoice.SqlStatement = "SELECT AppType FROM dbo.TbAppointmentDetails GROUP BY AppType; ";
                cmbType.DataSource = objWholeInvoice.getds().Tables[0];
                cmbType.DisplayMember = "AppType";

                objWholeInvoice.SqlStatement = "SELECT DocNo,C.Cust_Code,C.Cust_Name,T.TimeFrom,T.TimeTo,T.Memo,T.AppType[Type],AppDoc,Recalled,DocCode,DocName,NurseCode,NurseName,HelperCode,HelperName,BeuticianCode,BeuticianName,ServiceCode,ServiceItem FROM dbo.TbAppointmentDetails T JOIN dbo.Customer C ON C.Cust_Code=T.CustCode WHERE T.Post_Date='" + dpDate.Text+"' and Loca='"+LoginManager.LocaCode+"'; ";
                dgAppointments.DataSource = objWholeInvoice.getds().Tables[0];

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtCustName_Enter(object sender, EventArgs e)
        {
            if (search.Code != null && search.Code != "")
            {
                txtCustCode.Text = search.Code.Trim();
                txtCustName.Text = search.Descript.Trim();
            }
            search.Code = string.Empty;
            search.Descript = string.Empty;
        }
        private void dpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                objWholeInvoice.SqlStatement = "SELECT DocNo,C.Cust_Code,C.Cust_Name,T.TimeFrom,T.TimeTo,T.Memo,T.AppType[Type],AppDoc,Recalled,DocCode,DocName,NurseCode,NurseName,HelperCode,HelperName,BeuticianCode,BeuticianName,ServiceCode,ServiceItem FROM dbo.TbAppointmentDetails T JOIN dbo.Customer C ON C.Cust_Code=T.CustCode WHERE T.Post_Date='" + dpDate.Text + "' and Loca='"+LoginManager.LocaCode+"'; ";
                dgAppointments.DataSource = objWholeInvoice.getds().Tables[0];
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                objWholeInvoice.SqlStatement = "SELECT *  from Customer  where cust_code = '" + txtCustCode.Text.ToString() + "'   ";
                objWholeInvoice.ReadTempTransDetails();
                if (objWholeInvoice.RecordFound != true)
                {
                    MessageBox.Show("Customer Not Found.Or Invalid Customer Type", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (cmbType.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Invalid Appointment Type", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbType.Focus();
                    return;
                }

                if (txtDocCode.Text.Trim() != string.Empty)
                {
                    objWholeInvoice.SqlStatement = "SELECT *  from TB_Staff  where Staff_Code = '" + txtDocCode.Text.ToString() + "'   ";
                    objWholeInvoice.ReadTempTransDetails();
                    if (objWholeInvoice.RecordFound != true)
                    {
                        MessageBox.Show("Doctor Not Found.Or Invalid Doctor Code", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                txtDocCode_KeyDown(sender, new KeyEventArgs(Keys.Enter));

                if (txtNurseCode.Text.Trim() != string.Empty)
                {
                    objWholeInvoice.SqlStatement = "SELECT *  from TB_Staff  where Staff_Code = '" + txtNurseCode.Text.ToString() + "'   ";
                    objWholeInvoice.ReadTempTransDetails();
                    if (objWholeInvoice.RecordFound != true)
                    {
                        MessageBox.Show("Nurse Not Found.Or Invalid Nurse Code", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                txtNurseCode_KeyDown(sender, new KeyEventArgs(Keys.Enter));

                if (txtHelperCode.Text.Trim() != string.Empty)
                {
                    objWholeInvoice.SqlStatement = "SELECT *  from TB_Staff  where Staff_Code = '" + txtHelperCode.Text.ToString() + "'   ";
                    objWholeInvoice.ReadTempTransDetails();
                    if (objWholeInvoice.RecordFound != true)
                    {
                        MessageBox.Show("Helper Not Found.Or Invalid Helper Code", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                txtHelperCode_KeyDown(sender, new KeyEventArgs(Keys.Enter));

                if (txtBeutCode.Text.Trim() != string.Empty)
                {
                    objWholeInvoice.SqlStatement = "SELECT *  from TB_Staff  where Staff_Code = '" + txtBeutCode.Text.ToString() + "'   ";
                    objWholeInvoice.ReadTempTransDetails();
                    if (objWholeInvoice.RecordFound != true)
                    {
                        MessageBox.Show("Beutician Not Found.Or Invalid Beutician Code", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                txtBeutCode_KeyDown(sender, new KeyEventArgs(Keys.Enter));


                if (dpDate.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("Invalid Date", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dpDate.Focus();
                    return;
                }

                objWholeInvoice.CheckTimePeriod(dpDate.Text, Convert.ToDateTime(dpTimeFrom.Text), Convert.ToDateTime(dpTimeTo.Text), txtDocCode.Text, txtNurseCode.Text, txtHelperCode.Text, txtBeutCode.Text, "TimeIn");
                //objWholeInvoice.ReadDetails();
                if (objWholeInvoice.RecordFound == true)
                {
                    try
                    {
                        MessageBox.Show("In this time has an Appoinment, Then You cannot add another Appointment.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dpTimeFrom.Focus();
                        return;
                    }
                    catch (Exception ex)
                    {
                        clsClear.ErrMessage(ex);
                    }
                }


                objWholeInvoice.CheckTimePeriod(dpDate.Text, Convert.ToDateTime(dpTimeFrom.Text), Convert.ToDateTime(dpTimeTo.Text), txtDocCode.Text, txtNurseCode.Text, txtHelperCode.Text, txtBeutCode.Text, "TimeOut");
                //objWholeInvoice.ReadDetails();
                if (objWholeInvoice.RecordFound == true)
                {
                    try
                    {
                        MessageBox.Show("In this time has an Appoinment, Then You cannot add another Appointment.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dpTimeFrom.Focus();
                        return;
                    }
                    catch (Exception ex)
                    {
                        clsClear.ErrMessage(ex);
                    }
                }

                if (MessageBox.Show("Sure to add Appointment?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objWholeInvoice.AppointmentBooking(dpDate.Text, dpTimeFrom.Text, dpTimeTo.Text, txtCustCode.Text, cmbType.Text, txtRemarks.Text, txtDocCode.Text, txtNurseCode.Text, txtHelperCode.Text, txtBeutCode.Text, txtServiceCode.Text, txtDocName.Text, txtNurseName.Text, txtHelperName.Text, txtBeutName.Text, txtServiceItem.Text);
                    MessageBox.Show("Appointment Booking Success", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cmbType.Text = txtRemarks.Text = txtCustCode.Text = txtAge.Text = txtConNo.Text = txtConper.Text = txtCustName.Text = txtDocCode.Text = txtNurseCode.Text = txtHelperCode.Text = txtBeutCode.Text = txtServiceCode.Text = txtDocName.Text = txtNurseName.Text = txtHelperName.Text = txtBeutName.Text = txtServiceItem.Text = string.Empty;
                    LoadData();
                    cmbType.Focus();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

       
        private void frmCustomerAppointment_FormClosed(object sender, FormClosedEventArgs e)
        {
            GetForm = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgAppointments_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgAppointments.SelectedRows.Count <= 0 || dgAppointments.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    dpTimeFrom.Text = dgAppointments.SelectedRows[0].Cells[1].Value.ToString();
                    dpTimeTo.Text = dgAppointments.SelectedRows[0].Cells[2].Value.ToString();
                    cmbType.Text = dgAppointments.SelectedRows[0].Cells[3].Value.ToString();
                    txtCustCode.Text = dgAppointments.SelectedRows[0].Cells[4].Value.ToString();
                    txtCustCode_KeyDown(sender, new KeyEventArgs(Keys.Enter));
                    txtRemarks.Text = dgAppointments.SelectedRows[0].Cells[6].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void dgAppointments_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F2)
                {
                    if (dgAppointments.SelectedRows.Count <= 0 || dgAppointments.SelectedRows[0].Cells[0].ToString() == "")
                    {
                        MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (MessageBox.Show("Sure to Delete Appointment?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string TimeFrom = dgAppointments.SelectedRows[0].Cells[1].Value.ToString();
                            string Type = dgAppointments.SelectedRows[0].Cells[3].Value.ToString();
                            string CustCode = dgAppointments.SelectedRows[0].Cells[4].Value.ToString();

                            objWholeInvoice.AppointmentDelete(dpDate.Text, TimeFrom, CustCode, Type, txtDocCode.Text, txtNurseCode.Text, txtHelperCode.Text, txtBeutCode.Text, txtServiceCode.Text, txtDocName.Text, txtNurseName.Text, txtHelperName.Text, txtBeutName.Text, txtServiceItem.Text);
                            MessageBox.Show("Appointment Delete Success", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cmbType.Text = txtRemarks.Text = txtCustCode.Text = txtAge.Text = txtConNo.Text = txtConper.Text = txtCustName.Text = txtDocCode.Text = txtNurseCode.Text = txtHelperCode.Text = txtBeutCode.Text = txtServiceCode.Text = txtDocName.Text = txtNurseName.Text = txtHelperName.Text = txtBeutName.Text = txtServiceItem.Text = string.Empty;
                            LoadData();
                            cmbType.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void dpTimeFrom_ValueChanged(object sender, EventArgs e)
        {
            dpTimeTo.Value = dpTimeFrom.Value;
            dpTimeTo.Value = dpTimeTo.Value.AddMinutes(Convert.ToDouble(objWholeInvoice.ServiceTime));
        }

        private void btnDocSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                             

                if (txtDocCode.Text.Trim() != string.Empty && txtDocName.Text.Trim() == string.Empty)
                {
                    objWholeInvoice.SqlStatement = " SELECT Staff_Code DocCode, Staff_Name DocName " +
                                                   " FROM tb_Staff WHERE (Staff_Code LIKE '%" + txtDocCode.Text.Trim() + "%') AND Department = 'Doctor'";
                }
                else
                {
                    if (txtDocCode.Text.Trim() == string.Empty && txtDocName.Text.Trim() != string.Empty)
                    {
                        objWholeInvoice.SqlStatement = " SELECT Staff_Code DocCode, Staff_Name DocName " +
                                                       " FROM tb_Staff WHERE (Staff_Name LIKE '%" + txtDocName.Text.Trim() + "%') AND Department = 'Doctor'";
                    }
                    else
                    {
                        objWholeInvoice.SqlStatement = " SELECT Staff_Code DocCode, Staff_Name DocName " +
                                                       " FROM tb_Staff WHERE Department = 'Doctor'";
                    }
                }

                objWholeInvoice.DataetName = "dsStaff";
                objWholeInvoice.GetStaffDetails();
                search.dgSearch.DataSource = objWholeInvoice.GetStaffDataSet.Tables["dsStaff"];
                search.prop_Focus = txtDocCode;
                search.Cont_Descript = txtDocName;

                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void btnNurseSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                
                if (txtNurseCode.Text.Trim() != string.Empty && txtNurseName.Text.Trim() == string.Empty)
                {
                    objWholeInvoice.SqlStatement = " SELECT Staff_Code NurseCode, Staff_Name NurseName " +
                                                   " FROM tb_Staff WHERE (Staff_Code LIKE '%" + txtNurseCode.Text.Trim() + "%') AND Department = 'Nurse'";
                }
                else
                {
                    if (txtNurseCode.Text.Trim() == string.Empty && txtNurseName.Text.Trim() != string.Empty)
                    {
                        objWholeInvoice.SqlStatement = " SELECT Staff_Code NurseCode, Staff_Name NurseName " +
                                                       " FROM tb_Staff WHERE (Staff_Name LIKE '%" + txtNurseName.Text.Trim() + "%') AND Department = 'Nurse'";
                    }
                    else
                    {
                        objWholeInvoice.SqlStatement = " SELECT Staff_Code NurseCode, Staff_Name NurseName " +
                                                       " FROM tb_Staff WHERE Department = 'Nurse'";
                    }
                }

                objWholeInvoice.DataetName = "dsStaff";
                objWholeInvoice.GetStaffDetails();
                search.dgSearch.DataSource = objWholeInvoice.GetStaffDataSet.Tables["dsStaff"];
                search.prop_Focus = txtNurseCode;
                search.Cont_Descript = txtNurseName;

                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void btnHelperSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

         
                if (txtHelperCode.Text.Trim() != string.Empty && txtHelperName.Text.Trim() == string.Empty)
                {
                    objWholeInvoice.SqlStatement = " SELECT Staff_Code HelperCode, Staff_Name HelperName " +
                                                   " FROM tb_Staff WHERE (Staff_Code LIKE '%" + txtHelperCode.Text.Trim() + "%') AND Department = 'Helper'";
                }
                else
                {
                    if (txtHelperCode.Text.Trim() == string.Empty && txtHelperName.Text.Trim() != string.Empty)
                    {
                        objWholeInvoice.SqlStatement = " SELECT Staff_Code HelperCode, Staff_Name HelperName " +
                                                       " FROM tb_Staff WHERE (Staff_Name LIKE '%" + txtHelperName.Text.Trim() + "%') AND Department = 'Helper'";
                    }
                    else
                    {
                        objWholeInvoice.SqlStatement = " SELECT Staff_Code HelperCode, Staff_Name HelperName " +
                                                       " FROM tb_Staff WHERE Department = 'Helper'";
                    }
                }

                objWholeInvoice.DataetName = "dsStaff";
                objWholeInvoice.GetStaffDetails();
                search.dgSearch.DataSource = objWholeInvoice.GetStaffDataSet.Tables["dsStaff"];
                search.prop_Focus = txtHelperCode;
                search.Cont_Descript = txtHelperName;

                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void btnBeutSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

             
                if (txtBeutCode.Text.Trim() != string.Empty && txtBeutName.Text.Trim() == string.Empty)
                {
                    objWholeInvoice.SqlStatement = " SELECT Staff_Code BeuticianCode, Staff_Name BeuticianName " +
                                                   " FROM tb_Staff WHERE (Staff_Code LIKE '%" + txtBeutCode.Text.Trim() + "%') AND Department = 'Beutician'";
                }
                else
                {
                    if (txtBeutCode.Text.Trim() == string.Empty && txtBeutName.Text.Trim() != string.Empty)
                    {
                        objWholeInvoice.SqlStatement = " SELECT Staff_Code BeuticianCode, Staff_Name BeuticianName " +
                                                       " FROM tb_Staff WHERE (Staff_Name LIKE '%" + txtBeutName.Text.Trim() + "%') AND Department = 'Beutician'";
                    }
                    else
                    {
                        objWholeInvoice.SqlStatement = " SELECT Staff_Code BeuticianCode, Staff_Name BeuticianName " +
                                                       " FROM tb_Staff WHERE Department = 'Beutician'";
                    }
                }

                objWholeInvoice.DataetName = "dsStaff";
                objWholeInvoice.GetStaffDetails();
                search.dgSearch.DataSource = objWholeInvoice.GetStaffDataSet.Tables["dsStaff"];
                search.prop_Focus = txtBeutCode;
                search.Cont_Descript = txtBeutName;

                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

              

                if (txtServiceCode.Text.Trim() != string.Empty && txtServiceItem.Text.Trim() == string.Empty)
                {
                    objWholeInvoice.SqlStatement = " SELECT Prod_Code ServiceCode, Prod_name ServiceItem " +
                                                   " FROM Product WHERE (Prod_Code LIKE '%" + txtServiceCode.Text.Trim() + "%') AND ServiceItem = 1";
                }
                else
                {
                    if (txtServiceCode.Text.Trim() == string.Empty && txtServiceItem.Text.Trim() != string.Empty)
                    {
                        objWholeInvoice.SqlStatement = " SELECT Prod_Code ServiceCode, Prod_name ServiceItem " +
                                                       " FROM Product WHERE (Prod_name LIKE '%" + txtServiceItem.Text.Trim() + "%') AND ServiceItem = 1";
                    }
                    else
                    {
                        objWholeInvoice.SqlStatement = " SELECT Prod_Code ServiceCode, Prod_name ServiceItem " +
                                                       " FROM Product WHERE ServiceItem = 1";
                    }
                }

                objWholeInvoice.DataetName = "Product";
                objWholeInvoice.GetProductDetails();
                search.dgSearch.DataSource = objWholeInvoice.GetProductDataSet.Tables["Product"];
                search.prop_Focus = txtServiceCode;
                search.Cont_Descript = txtServiceItem;
                search.Show(); 
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtDocCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDocName.Focus();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    txtDocName.Text = txtDocCode.Text = string.Empty;
                }                
         
                if (e.KeyCode == Keys.Enter && txtDocCode.Text.Trim() != "")
                {
                    objWholeInvoice.StaffCode = txtDocCode.Text.ToString().Trim();
                    objWholeInvoice.SqlStatement = "SELECT Staff_Code, Staff_Name FROM dbo.tb_Staff WHERE Staff_Code LIKE '%"+ txtDocCode.Text+"%' AND Department = 'Doctor'";
                    objWholeInvoice.ReadStaffDetails();
                    if (objWholeInvoice.RecordFound == true)
                    {
                        txtDocCode.Text = objWholeInvoice.StaffCode;
                        txtDocName.Text = objWholeInvoice.StaffName;
                    }
                    else
                    {
                        MessageBox.Show("Doctor Code Not Found OR Invalid.", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDocCode.Focus();
                        txtDocCode.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtNurseCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtNurseName.Focus();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    txtNurseName.Text = txtNurseCode.Text = string.Empty;
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
                if (e.KeyCode == Keys.Enter && txtNurseCode.Text.Trim() != "")
                {
                    objWholeInvoice.StaffCode = txtNurseCode.Text.ToString().Trim();
                    objWholeInvoice.SqlStatement = "SELECT Staff_Code, Staff_Name FROM dbo.tb_Staff WHERE Staff_Code LIKE '%" + txtNurseCode.Text + "%' AND Department = 'Nurse'";
                    objWholeInvoice.ReadStaffDetails();
                    if (objWholeInvoice.RecordFound == true)
                    {
                        txtNurseCode.Text = objWholeInvoice.StaffCode;
                        txtNurseName.Text = objWholeInvoice.StaffName;
                    }
                    else
                    {
                        MessageBox.Show("Nurse Code Not Found OR Invalid.", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNurseCode.Focus();
                        txtNurseCode.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtHelperCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtHelperName.Focus();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    txtHelperName.Text = txtHelperCode.Text = string.Empty;
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
                if (e.KeyCode == Keys.Enter && txtHelperCode.Text.Trim() != "")
                {
                    objWholeInvoice.StaffCode = txtHelperCode.Text.ToString().Trim();
                    objWholeInvoice.SqlStatement = "SELECT Staff_Code, Staff_Name FROM dbo.tb_Staff WHERE Staff_Code LIKE '%" + txtHelperCode.Text + "%' AND Department = 'Helper'";
                    objWholeInvoice.ReadStaffDetails();
                    if (objWholeInvoice.RecordFound == true)
                    {
                        txtHelperCode.Text = objWholeInvoice.StaffCode;
                        txtHelperName.Text = objWholeInvoice.StaffName;
                    }
                    else
                    {
                        MessageBox.Show("Helper Code Not Found OR Invalid.", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtHelperCode.Focus();
                        txtHelperCode.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtBeutCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBeutName.Focus();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    txtBeutName.Text = txtBeutCode.Text = string.Empty;
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
                if (e.KeyCode == Keys.Enter && txtBeutCode.Text.Trim() != "")
                {
                    objWholeInvoice.StaffCode = txtBeutCode.Text.ToString().Trim();
                    objWholeInvoice.SqlStatement = "SELECT Staff_Code, Staff_Name FROM dbo.tb_Staff WHERE Staff_Code LIKE '%" + txtBeutCode.Text + "%' AND Department = 'Beutician'";
                    objWholeInvoice.ReadStaffDetails();
                    if (objWholeInvoice.RecordFound == true)
                    {
                        txtBeutCode.Text = objWholeInvoice.StaffCode;
                        txtBeutName.Text = objWholeInvoice.StaffName;
                        dpDate.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Beutician Code Not Found OR Invalid.", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtBeutCode.Focus();
                        txtBeutCode.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtServiceCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtServiceItem.Focus();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    txtServiceItem.Text = txtServiceCode.Text = string.Empty;
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
                if (e.KeyCode == Keys.Enter && txtServiceCode.Text.Trim() != "")
                {
                    objWholeInvoice.ProductCode = txtServiceCode.Text.ToString().Trim();
                    objWholeInvoice.SqlStatement = "SELECT Prod_Code, Prod_Name, ServiceTime FROM dbo.Product WHERE Prod_Code LIKE '%" + txtServiceCode.Text + "%' AND ServiceItem = 1";
                    objWholeInvoice.ReadServiceDetails();
                    if (objWholeInvoice.RecordFound == true)
                    {
                        txtServiceCode.Text = objWholeInvoice.ServiceCode;
                        txtServiceItem.Text = objWholeInvoice.ServiceItem;
                        dpTimeFrom_ValueChanged(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Service Code Not Found OR Invalid.", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtServiceCode.Focus();
                        txtServiceCode.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtServiceCode.Focus();
            }            
        }

        private void txtServiceCode_TextChanged(object sender, EventArgs e)
        {
            //if(txtServiceCode.Text != string.Empty)
            //{
            //    dpTimeTo.Enabled = false;
            //}
            //else
            //{
            //    dpTimeTo.Enabled = true;
            //}
        }

        private void txtServiceItem_TextChanged(object sender, EventArgs e)
        {
            //if (txtServiceItem.Text != string.Empty)
            //{
            //    dpTimeTo.Enabled = false;
            //}
        }

        private void dpTimeTo_ValueChanged(object sender, EventArgs e)
        {
            //if (txtServiceCode.Text != string.Empty || txtServiceItem.Text != string.Empty)
            //{
            //    dpTimeTo.Enabled = false;
            //}
            //else
            //{
            //    dpTimeTo.Enabled = true;
            //}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                dpDate.Value = DateTime.Now;
                dpTimeFrom.Value = DateTime.Now;
                dpTimeTo.Value = DateTime.Now;
                cmbType.Text = txtRemarks.Text = txtCustCode.Text = txtAge.Text = txtConNo.Text = txtConper.Text = txtCustName.Text = txtDocCode.Text = txtNurseCode.Text = txtHelperCode.Text = txtBeutCode.Text = txtServiceCode.Text = txtDocName.Text = txtNurseName.Text = txtHelperName.Text = txtBeutName.Text = txtServiceItem.Text = string.Empty;
                
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtRemarks_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtServiceCode_Enter(object sender, EventArgs e)
        {
            if (search.Code != null && search.Code != "")
            {
                txtServiceCode.Text = search.Code.Trim();
                txtServiceItem.Text = search.Descript.Trim();
            }
            search.Code = string.Empty;
            search.Descript = string.Empty;
        }

        private void txtDocCode_Enter(object sender, EventArgs e)
        {
            if (search.Code != null && search.Code != "")
            {
                txtDocCode.Text = search.Code.Trim();
                txtDocName.Text = search.Descript.Trim();
            }
            search.Code = string.Empty;
            search.Descript = string.Empty;
        }

        private void txtNurseCode_Enter(object sender, EventArgs e)
        {
            if (search.Code != null && search.Code != "")
            {
                txtNurseCode.Text = search.Code.Trim();
                txtNurseName.Text = search.Descript.Trim();
            }
            search.Code = string.Empty;
            search.Descript = string.Empty;
        }

        private void txtHelperCode_Enter(object sender, EventArgs e)
        {
            if (search.Code != null && search.Code != "")
            {
                txtHelperCode.Text = search.Code.Trim();
                txtHelperName.Text = search.Descript.Trim();
            }
            search.Code = string.Empty;
            search.Descript = string.Empty;
        }

        private void txtBeutCode_Enter(object sender, EventArgs e)
        {
            if (search.Code != null && search.Code != "")
            {
                txtBeutCode.Text = search.Code.Trim();
                txtBeutName.Text = search.Descript.Trim();
            }
            search.Code = string.Empty;
            search.Descript = string.Empty;
        }

        private void txtConNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCustCode.Text.Trim() != "" && txtCustName.Text.Trim() != "")
            {
                txtConper.Focus();
            }
        }

        private void txtConper_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCustCode.Text.Trim() != "" && txtCustName.Text.Trim() != "")
            {
                txtAge.Focus();
            }
        }

        private void txtAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtCustCode.Text.Trim() != "" && txtCustName.Text.Trim() != "")
            {
                txtRemarks.Focus();
            }
        }

        private void txtServiceItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDocCode.Focus();
            }
            if (e.KeyCode == Keys.Enter && txtServiceItem.Text.Trim() != "")
            {
                objWholeInvoice.ProductName = txtServiceItem.Text.ToString().Trim();
                objWholeInvoice.SqlStatement = "SELECT Prod_Code, Prod_Name, ServiceTime FROM dbo.Product WHERE Prod_Name LIKE '%" + txtServiceItem.Text + "%' AND ServiceItem = 1";
                objWholeInvoice.ReadServiceDetails();
                if (objWholeInvoice.RecordFound == true)
                {
                    txtServiceCode.Text = objWholeInvoice.ServiceCode;
                    txtServiceItem.Text = objWholeInvoice.ServiceItem;
                }
                else
                {
                    MessageBox.Show("Service Code Not Found OR Invalid.", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtServiceItem.Focus();
                    txtServiceItem.SelectAll();
                }
            }
        }

        private void txtDocName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNurseCode.Focus();
            }
            if (e.KeyCode == Keys.Enter && txtDocName.Text.Trim() != "")
            {
                objWholeInvoice.StaffName = txtDocName.Text.ToString().Trim();
                objWholeInvoice.SqlStatement = "SELECT Staff_Code, Staff_Name FROM dbo.tb_Staff WHERE Staff_Name LIKE '%" + txtDocName.Text + "%' AND Department = 'Doctor'";
                objWholeInvoice.ReadStaffDetails();
                if (objWholeInvoice.RecordFound == true)
                {
                    txtDocCode.Text = objWholeInvoice.StaffCode;
                    txtDocName.Text = objWholeInvoice.StaffName;
                }
                else
                {
                    MessageBox.Show("Doctor Code Not Found OR Invalid.", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDocName.Focus();
                    txtDocName.SelectAll();
                }
            }
        }

        private void txtNurseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHelperCode.Focus();
            }
            if (e.KeyCode == Keys.Enter && txtNurseName.Text.Trim() != "")
            {
                objWholeInvoice.StaffName = txtNurseName.Text.ToString().Trim();
                objWholeInvoice.SqlStatement = "SELECT Staff_Code, Staff_Name FROM dbo.tb_Staff WHERE Staff_Name LIKE '%" + txtNurseName.Text + "%' AND Department = 'Nurse'";
                objWholeInvoice.ReadStaffDetails();
                if (objWholeInvoice.RecordFound == true)
                {
                    txtNurseCode.Text = objWholeInvoice.StaffCode;
                    txtNurseName.Text = objWholeInvoice.StaffName;
                }
                else
                {
                    MessageBox.Show("Doctor Code Not Found OR Invalid.", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNurseName.Focus();
                    txtNurseName.SelectAll();
                }
            }
        }

        private void txtHelperName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBeutCode.Focus();
            }
            if (e.KeyCode == Keys.Enter && txtHelperName.Text.Trim() != "")
            {
                objWholeInvoice.StaffName = txtHelperName.Text.ToString().Trim();
                objWholeInvoice.SqlStatement = "SELECT Staff_Code, Staff_Name FROM dbo.tb_Staff WHERE Staff_Name LIKE '%" + txtHelperName.Text + "%' AND Department = 'Helper'";
                objWholeInvoice.ReadStaffDetails();
                if (objWholeInvoice.RecordFound == true)
                {
                    txtHelperCode.Text = objWholeInvoice.StaffCode;
                    txtHelperName.Text = objWholeInvoice.StaffName;
                }
                else
                {
                    MessageBox.Show("Helper Code Not Found OR Invalid.", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHelperName.Focus();
                    txtHelperName.SelectAll();
                }
            }
        }

        private void txtBeutName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dpDate.Focus();
            }
            if (e.KeyCode == Keys.Enter && txtBeutName.Text.Trim() != "")
            {
                objWholeInvoice.StaffName = txtBeutName.Text.ToString().Trim();
                objWholeInvoice.SqlStatement = "SELECT Staff_Code, Staff_Name FROM dbo.tb_Staff WHERE Staff_Name LIKE '%" + txtBeutName.Text + "%' AND Department = 'Beutician'";
                objWholeInvoice.ReadStaffDetails();
                if (objWholeInvoice.RecordFound == true)
                {
                    txtBeutCode.Text = objWholeInvoice.StaffCode;
                    txtBeutName.Text = objWholeInvoice.StaffName;
                }
                else
                {
                    MessageBox.Show("Beutician Code Not Found OR Invalid.", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBeutName.Focus();
                    txtBeutName.SelectAll();
                }
            }
        }

        private void dpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dpTimeFrom.Focus();
            }
        }

        private void dpTimeFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dpTimeTo.Focus();
            }
        }
    }
}
