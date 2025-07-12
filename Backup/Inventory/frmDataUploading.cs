using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using clsLibrary;
namespace Inventory
{
    public partial class frmDataUploading : Form
    {
        public frmDataUploading()
        {
            InitializeComponent();
        }
        private string selectquery;
        private frmSearch search = new frmSearch();
        clsDataUploading objDataUploading = new clsDataUploading();
        private static frmDataUploading DataUpload;

        public static frmDataUploading GetDataUpload
        {
            get { return DataUpload; }
            set { DataUpload = value; }
        }

        private void frmDataUploading_Load(object sender, EventArgs e)
        {

        }

        private void frmDataUploading_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                DataUpload = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmDataUpload 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmDataUploading_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Hide the form...
                this.Hide();

                // Cancel the close...
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmDataUpload 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                DataUpload = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmDataUpload 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLocaCode.Text == string.Empty)
                {
                    MessageBox.Show("Select the location first", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (File.Exists(@"D:\SQL Databases\DataTransfer.mdb"))
                {
                    File.Delete(@"D:\SQL Databases\DataTransfer.mdb");
                    File.Copy(@"D:\SQL Databases\DataTransferEmpty.mdb", @"D:\SQL Databases\DataTransfer.mdb");
                }
                objDataUploading.ToLocaCode = txtLocaCode.Text.ToString().Trim();
                objDataUploading.Product = chkProducts.Checked;
                objDataUploading.Department = chkDepartment.Checked;
                objDataUploading.Category = chkCategorys.Checked;
                objDataUploading.Supplier = chkSuppliers.Checked;
                objDataUploading.Customer = chkCustomers.Checked;
                objDataUploading.Brand = chkBrands.Checked;
                objDataUploading.AllProduct = opProductAll.Checked;
                objDataUploading.Dates = dtDates.Text.Trim();
                objDataUploading.DataUploading();
                if (objDataUploading.ErrorCode == 0)
                {
                    MessageBox.Show("Data Uploading Process Completed Successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Found On Data Uploading Process.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmDataUpload 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnLocaSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }
                selectquery = "SELECT Loca AS Code, Loca_Descrip AS Description FROM Location ORDER BY Loca";

                search.dgSearch.DataSource = clsRetriveGenaral.combofill1(selectquery).Tables["Table"];
                search.Show();
                search.prop_Focus = txtLocaCode;
                txtLocaName.Text = search.Descript;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmDataUpload 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtLocaCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Display Departemnt
                    if (txtLocaCode.Text.Trim() != "")
                    {
                        objDataUploading.ToLocaCode = txtLocaCode.Text.ToString().Trim();
                        objDataUploading.SqlStatement = "SELECT Loca, Loca_Descrip FROM location WHERE Loca = '";
                        objDataUploading.ReadToLocationCode();
                        if (objDataUploading.ToLocaName != string.Empty)
                        {
                            txtLocaName.Text = objDataUploading.ToLocaName;
                            button1.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Locaion Code Not Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtLocaCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmDataUpload 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtLocaCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    txtLocaCode.Text = search.Code.Trim();
                    txtLocaName.Text = search.Descript.Trim();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmDataUpload 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                chkDepartment.Enabled = chkCategorys.Enabled = chkSuppliers.Enabled = chkCustomers.Enabled = chkBrands.Enabled = !chkAll.Checked;
                chkDepartment.Checked = chkCategorys.Checked = chkSuppliers.Checked = chkCustomers.Checked = chkBrands.Checked = chkProducts.Checked = chkAll.Checked;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void chkProducts_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                opProductAll.Enabled = opProductDate.Enabled = chkProducts.Checked;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void opProductDate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtDates.Enabled = opProductDate.Checked;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

    }
}