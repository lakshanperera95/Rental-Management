using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using clsLibrary;

namespace Inventory
{
    public partial class frmLocationROL : Form
    {
        public frmLocationROL(string strProdCode, string strProdName)
        {
            InitializeComponent();
            this.lblProdCode.Text = strProdCode;
            this.lblProdName.Text = strProdName;
        }

        clsProduct ObjProduct = new clsProduct();

        frmSearch search = new frmSearch();

        private static frmLocationROL LocationROL;

        private string strSqlString;

        public static frmLocationROL GetLocationROL
        {
            get { return LocationROL; }
            set { LocationROL = value; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                LocationROL = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmLocationROL 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmLocationROL_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                LocationROL = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmLocationROL 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmLocationROL_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmLocationROL 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmLocationROL_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control == true)
                {

                    if (e.KeyCode == Keys.A)
                    {
                        this.btnAdd.PerformClick();
                    }
                    else
                    {
                        if (e.KeyCode == Keys.E)
                        {
                            this.btnExit.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmLocationROL 004.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmLocationROL_Load( object sender, EventArgs e)
        {
            try
            {
                ObjProduct.Code = lblProdCode.Text.Trim();
                //ObjProduct.DeleteLocationROL();
                ObjProduct.GetTempDataset();
                dataGridViewLocationROL.DataSource = ObjProduct.TempLocationROL.Tables["dsProdROL"];
                dataGridViewLocationROL.Refresh();
                //Set Grid Last Record
                if (dataGridViewLocationROL.RowCount > 10)
                {
                    dataGridViewLocationROL.FirstDisplayedCell = dataGridViewLocationROL[0, dataGridViewLocationROL.RowCount - 6];
                }
                //******************

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmLocationROL 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                strSqlString = "SELECT Loca AS Code, Loca_Descrip AS Description FROM Location WHERE Loca <> '" + LoginManager.LocaCode + "' ORDER BY Loca";

                search.dgSearch.DataSource = clsRetriveGenaral.combofill1(strSqlString).Tables["Table"];
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmLocationROL 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmLocationROL 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                    if (txtLocaCode.Text.Trim() != "" && txtLocaCode.Text.Trim() !=  LoginManager.LocaCode)
                    {
                        ObjProduct.SqlString = "SELECT Loca, Loca_Descrip FROM location WHERE Loca = " + txtLocaCode.Text.Trim() ;
                        ObjProduct.ReadLocationCode();
                        if (ObjProduct.LocaName != string.Empty)
                        {
                            txtLocaName.Text = ObjProduct.LocaName;
                            txtROL.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmLocationROL 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                //ObjProduct.Code = lblProdCode.Text.Trim();
                //ObjProduct.DeleteLocationROLAll();

                this.Close();
                this.Dispose();
                LocationROL = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmLocationROL 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtROL_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtROL.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtROL.Text) > 0)
                {
                    txtReOrderQty.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmLocationROL 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtReOrderQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && clsValidation.isNumeric(txtROL.Text, System.Globalization.NumberStyles.Number) == true && decimal.Parse(txtROL.Text) > 0)
                {
                    ObjProduct.Code = lblProdCode.Text.Trim();
                    ObjProduct.LocaCode = txtLocaCode.Text.Trim();
                    ObjProduct.LocaROL = decimal.Parse(txtROL.Text.ToString());
                    ObjProduct.LocaReQty = decimal.Parse(txtReOrderQty.Text.ToString()); 
                    ObjProduct.UpdateLocationROL();

                    //ObjProduct.GetTempDataset();
                    dataGridViewLocationROL.DataSource = ObjProduct.TempLocationROL.Tables["dsProdROL"];
                    dataGridViewLocationROL.Refresh();
                    //Set Grid Last Record
                    if (dataGridViewLocationROL.RowCount > 10)
                    {
                        dataGridViewLocationROL.FirstDisplayedCell = dataGridViewLocationROL[0, dataGridViewLocationROL.RowCount - 6];
                    }
                    //******************

                    txtLocaCode.Text = string.Empty;
                    txtLocaName.Text = string.Empty;
                    txtROL.Text = string.Empty;
                    txtReOrderQty.Text = string.Empty;
                    txtLocaCode.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmLocationROL 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewLocationROL_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewLocationROL.SelectedRows.Count <= 0 || dataGridViewLocationROL.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtLocaCode.Text = dataGridViewLocationROL.SelectedRows[0].Cells[0].Value.ToString();
                    txtLocaName.Text = dataGridViewLocationROL.SelectedRows[0].Cells[1].Value.ToString();
                    txtROL.Text = dataGridViewLocationROL.SelectedRows[0].Cells[2].Value.ToString();
                    txtReOrderQty.Text = dataGridViewLocationROL.SelectedRows[0].Cells[3].Value.ToString();
                    txtROL.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "' frmLocationROL 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewLocationROL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        ObjProduct.Code = lblProdCode.Text;
                        ObjProduct.LocaCode = dataGridViewLocationROL.SelectedRows[0].Cells[0].Value.ToString();
                        ObjProduct.DeleteLocationROL();
                        //ObjProduct.GetTempDataset();
                        dataGridViewLocationROL.DataSource = ObjProduct.TempLocationROL.Tables["dsProdROL"];
                        dataGridViewLocationROL.Refresh();
                    }
                    catch (Exception ex)
                    {

                        ObjProduct.Errormsg(ex, "dataGridViewLocationROL_KeyDown-frmLocationROL");
                    }
                }
            }
        }
    }
}