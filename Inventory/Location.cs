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
    public partial class frmLocation : Form
    {
        private int Err = 0;
        private string query;
        frmSearch search = new frmSearch();

        public frmLocation()
        {
            InitializeComponent();
        }

        private static frmLocation location;
        //property for location
        public static frmLocation GetLocation {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        
        }

        private void CmdHlpDesc_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                //new clsMenuControler().Location.Close();
                this.Close();
                this.Dispose();
                location = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Err = 0;
                errLocaName.Clear();
                errLocaCode.Clear();

                if (TxtLocaCode.Text == string.Empty)
                {
                    errLocaCode.SetError(TxtLocaCode, "Location Code is mandatory feild");
                    Err++;

                }

                if (TxtLocaName.Text == string.Empty)
                {
                    errLocaName.SetError(TxtLocaName, "Location Name is mandatory feild");
                    Err++;
                }
                if (numvalidate(TxtLocaCode.Text) == 1)
                {
                    MessageBox.Show("A numeric field, Location Code contains alpha characters. Please check the data entered. ", "Non numeric character found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Err++;
                }

                this.validator(GrbHeader);
                if (Err == 0)
                {
                    clsLocation.getlocation().ErrorCode = 0;
                    clsLocation.getlocation().LocationCode = TxtLocaCode.Text.Trim().ToUpper();
                    clsLocation.getlocation().LocationName = TxtLocaName.Text.Trim().ToUpper();
                    clsLocation.getlocation().Address1 = TxtAddress1.Text.Trim().ToUpper();
                    clsLocation.getlocation().Address2 = TxtAddress2.Text.Trim().ToUpper();
                    clsLocation.getlocation().Address3 = TxtAddress3.Text.Trim().ToUpper();
                    clsLocation.getlocation().Telephone = TxtTelephone.Text.Trim().ToUpper();
                    clsLocation.getlocation().Fax = TxtFax.Text.Trim().ToUpper();
                    clsLocation.getlocation().WebAddress = txtWebsite.Text.Trim();
                    clsLocation.getlocation().Email = TxtEmail.Text.Trim();
                    clsLocation.getlocation().Tax = TxtTaxReg.Text.Trim().ToUpper().ToUpper();
                    clsLocation.getlocation().OGF = chkOgf.Checked;
                   


                    //clear all the properties used in search form
                    search.Code = string.Empty;
                    search.Descript = string.Empty;
                    search.prop_Focus = null;
                    search.prop_Name = string.Empty;

                    clsLocation.getlocation().UpdateData(GrbHeader, TxtLocaCode);

                    btnClear.PerformClick();
                   


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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clsClear.getclear().clearfeilds(GrbHeader, TxtLocaCode);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

 #region Delete command button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Display a message box asking users if they
                // want to delete the record
                if (TxtLocaCode.Text != string.Empty)
                {
                    if (MessageBox.Show("Do you really want to delete the record ?  " + TxtLocaCode.Text + "", "Location Details",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                          == DialogResult.Yes)
                    {
                        clsLocation.getlocation().DeleteData(TxtLocaCode.Text, GrbHeader, TxtLocaCode);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

 #region Validate whether textfeilds contains ' character
        public void validator(Control text)
        {
            try
            {
                for (int i = 0; i < text.Controls.Count; i++)
                {
                    if ((text.Controls[i].GetType() == typeof(TextBox)) && (text.Controls[i].Text.Contains("'")))
                    {
                        MessageBox.Show("Invalid characters in Textfeilds Please check the characters entered.", "Invalid character (') found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        text.Controls[i].Text = string.Empty;
                        text.Controls[i].Focus();

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
        public int numvalidate(string str)
        {
            try
            {
                if (str == string.Empty)
                {
                    return 0;
                }
                else { 
                int result = int.Parse(str);
                return 0;
                }
            }
            catch
            {
                return 1;
            }
        }

        private void CmdHlpLocation_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

               

                query = "SELECT  Loca As Code ,Loca_Descrip AS Description FROM [dbo].[Location]   ORDER BY Loca";
                search.dgSearch.DataSource = clsRetriveGenaral.combofill1(query).Tables["Table"];
                search.prop_Focus = TxtLocaCode;
                search.Cont_Descript = TxtLocaName;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmLocation_Leave(object sender, EventArgs e)
        {
            try
            {
                clsLocation.getlocation().LocationCode = string.Empty;
                clsLocation.getlocation().LocationName = string.Empty;
                clsLocation.getlocation().Address1 = string.Empty;
                clsLocation.getlocation().Address2 = string.Empty;
                clsLocation.getlocation().Address3 = string.Empty;
                clsLocation.getlocation().Telephone = string.Empty;
                clsLocation.getlocation().Fax = string.Empty;
                clsLocation.getlocation().Email = string.Empty;
                clsLocation.getlocation().Tax = string.Empty;
                clsClear.getclear().clearfeilds(GrbHeader, TxtLocaCode);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void TxtLocaCode_Enter(object sender, EventArgs e)
        {
            try
            {
                if (search.Code != null && search.Code != "")
                {
                    TxtLocaCode.Text = search.Code;
                    TxtLocaName.Text = search.Descript;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        public void settext()
        {
            try
            {
                query = "SELECT  Address1, Address2, Address3, Tel, Fax, Email, TaxReg FROM Location WHERE Loca = '" + TxtLocaCode.Text + "' and TaxLoca='" + LoginManager.TaxLocaLogin + "'";
                clsLocation.getlocation().GetDataset1 = clsLocation.getlocation().RetriveData(query);
                if (clsLocation.getlocation().GetDataset1.Tables["Table"].Rows.Count > 0)
                {

                    TxtAddress1.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][0].ToString();
                    TxtAddress2.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][1].ToString();
                    TxtAddress3.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][2].ToString();
                    TxtTelephone.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][3].ToString();
                    TxtFax.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][4].ToString();
                    TxtEmail.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][5].ToString();
                    TxtTaxReg.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][6].ToString();

                    for (int i = 0; i < clsLocation.getlocation().GetDataset1.Tables.Count; i++)
                    {
                        clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][i] = "";
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void TxtLocaCode_TextChanged(object sender, EventArgs e)
        {
            //if (TxtLocaCode.Text != string.Empty ){
            //    this.settext();
            //}
        }

        private void frmLocation_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                location = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void TxtLocaCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    query = "SELECT  Address1, Address2, Address3, Tel, Fax, Email, TaxReg, Loca_Descrip,OGF FROM Location WHERE Loca = '" + TxtLocaCode.Text + "' and TaxLoca='" + LoginManager.TaxLocaLogin + "' ";
                    clsLocation.getlocation().GetDataset1 = clsLocation.getlocation().RetriveData(query);
                    if (clsLocation.getlocation().GetDataset1.Tables["Table"].Rows.Count > 0)
                    {
                        TxtAddress1.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][0].ToString();
                        TxtAddress2.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][1].ToString();
                        TxtAddress3.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][2].ToString();
                        TxtTelephone.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][3].ToString();
                        TxtFax.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][4].ToString();
                        TxtEmail.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][5].ToString();
                        TxtTaxReg.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][6].ToString();
                        TxtLocaName.Text = clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][7].ToString();
                        chkOgf.Checked = bool.Parse(clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][8].ToString());

                        for (int i = 0; i < clsLocation.getlocation().GetDataset1.Tables.Count; i++)                          
                        {
                            clsLocation.getlocation().GetDataset1.Tables["Table"].Rows[0][i] = "";
                        }
                        TxtAddress1.Focus();
                    }
                    else
                    {
                        TxtAddress1.Text = string.Empty;
                        TxtAddress2.Text = string.Empty;
                        TxtAddress3.Text = string.Empty;
                        TxtTelephone.Text = string.Empty;
                        TxtFax.Text = string.Empty;
                        TxtEmail.Text = string.Empty;
                        TxtTaxReg.Text = string.Empty;
                        TxtLocaName.Text = string.Empty;
                        chkOgf.Checked = false;
                        TxtLocaName.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void TxtAddress2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TxtAddress3.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void TxtAddress3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TxtTelephone.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void TxtAddress1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TxtAddress2.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void TxtTelephone_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TxtFax.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void TxtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtWebsite.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 016. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void TxtFax_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TxtEmail.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 017. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void TxtTaxReg_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Select();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 018. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtWebsite_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TxtTaxReg.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmLocation 016. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void TxtLocaName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                TxtAddress1.Focus();
            }
        }

        private void frmLocation_Load(object sender, EventArgs e)
        {

        }

        private void chkOgf_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TxtLocaName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}