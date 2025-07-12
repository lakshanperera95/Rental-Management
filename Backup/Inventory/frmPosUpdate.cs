using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Inventory.Properties;
using clsLibrary;

namespace Inventory
{
    public partial class frmPosUpdate : Form
    {
        public frmPosUpdate()
        {
            InitializeComponent();
        }

        private static frmPosUpdate PosUpdate;
        clsPosUpdate objPosUpdate = new clsPosUpdate();

        public static frmPosUpdate GetPosUpdate
        {
            get { return PosUpdate; }
            set { PosUpdate = value; }
        }

        private void frmPosUpdate_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPosUpdate 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPosUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                PosUpdate = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPosUpdate 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmBarcode_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPosUpdate 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnCusExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                PosUpdate = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPosUpdate 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {

                int c = 0, x = 1, y = 1;
                objPosUpdate.GetPosTerminal();
                lblTerminal.Text = objPosUpdate.PosTerminal.Tables["dsTerminalDetails"].Rows.Count.ToString() + " Terminal Found";
                lblTerminal.Refresh();

                lisChkListBox.Items.Clear();
                foreach (DataRow row in objPosUpdate.PosTerminal.Tables["dsTerminalDetails"].Rows)
                {
                    //Pos 1
                    objPosUpdate.Terminal = row["Terminal_Name"].ToString();
                    objPosUpdate.TerminalPwd = row["Terminal_Password"].ToString();
                    objPosUpdate.DatabaseName = row["DatabaseName"].ToString();

                    objPosUpdate.TerminalReload();
                    int b = 103 / objPosUpdate.PosTerminal.Tables["dsTerminalDetails"].Rows.Count;
                 

                    for (int i = 1; i < Settings.Default.NoOfTerminal + 1; i++)
                    {
                        if (row["Terminal_No"].ToString() == "0" + i)
                        {
                            if (objPosUpdate.TerminalUpdate == true)
                            {
                                lisChkListBox.Items.Add("(" + objPosUpdate.Terminal + ")  Upload Complete", true);
                                lisChkListBox.Refresh();
                                lblProcess.Size = new System.Drawing.Size(c + b, 13);
                                lblProcess.Refresh();
                                lblSucsess.Text = x.ToString() + " Success";
                                lblSucsess.Refresh();
                                x = x + 1;
                                c = c + b;

                            }
                            else
                            {
                                lisChkListBox.Items.Add("(" + objPosUpdate.Terminal + ")  Reload Failed", false);
                                lisChkListBox.Refresh();
                                lblProcess.Size = new System.Drawing.Size(c + b, 13);
                                lblProcess.Refresh();
                                lblFaild.Text = y.ToString() + " Faild";
                                lblFaild.Refresh();
                                y = y + 1;
                                c = c + b;
                            }
                        }
                    }
                    #region jhdjg

                    
                    //if (row["Terminal_No"].ToString() == "01")
                    //{
                    //    if (objPosUpdate.TerminalUpdate == true)
                    //    {
                    //        chkTerminal1.Checked = true;
                    //        chkTerminal1.Text = "'" + objPosUpdate.Terminal + "' Completed Successfully";
                    //        chkTerminal1.Refresh();
                    //    }
                    //    else
                    //    {
                    //        chkTerminal1.Checked = false;
                    //        chkTerminal1.Text = "'" + objPosUpdate.Terminal + "' Reload Failed";
                    //        chkTerminal1.Refresh();
                    //    }
                    //}
                    //if (row["Terminal_No"].ToString() == "02")
                    //{
                    //    if (objPosUpdate.TerminalUpdate == true)
                    //    {
                    //        chkTerminal2.Checked = true;
                    //        chkTerminal2.Text = "'" + objPosUpdate.Terminal + "' Completed Successfully";
                    //        chkTerminal2.Refresh();
                    //    }
                    //    else
                    //    {
                    //        chkTerminal2.Checked = false;
                    //        chkTerminal2.Text = "'" + objPosUpdate.Terminal + "' Reload Failed";
                    //        chkTerminal2.Refresh();
                    //    }
                    //}

                    //if (row["Terminal_No"].ToString() == "03")
                    //{
                    //    if (objPosUpdate.TerminalUpdate == true)
                    //    {
                    //        chkTerminal3.Checked = true;
                    //        chkTerminal3.Text = "'" + objPosUpdate.Terminal + "' Completed Successfully";
                    //        chkTerminal3.Refresh();
                    //    }
                    //    else
                    //    {
                    //        chkTerminal3.Checked = false;
                    //        chkTerminal3.Text = "'" + objPosUpdate.Terminal + "' Reload Failed";
                    //        chkTerminal3.Refresh();
                    //    }
                    //}

                    //if (row["Terminal_No"].ToString() == "04")
                    //{
                    //    if (objPosUpdate.TerminalUpdate == true)
                    //    {
                    //        chkTerminal4.Checked = true;
                    //        chkTerminal4.Text = "'" + objPosUpdate.Terminal + "' Completed Successfully";
                    //        chkTerminal4.Refresh();
                    //    }
                    //    else
                    //    {
                    //        chkTerminal4.Checked = false;
                    //        chkTerminal4.Text = "'" + objPosUpdate.Terminal + "' Reload Failed";
                    //        chkTerminal4.Refresh();
                    //    }
                    //}

                    //if (row["Terminal_No"].ToString() == "05")
                    //{
                    //    if (objPosUpdate.TerminalUpdate == true)
                    //    {
                    //        chkTerminal5.Checked = true;
                    //        chkTerminal5.Text = "'" + objPosUpdate.Terminal + "' Completed Successfully";
                    //        chkTerminal5.Refresh();
                    //    }
                    //    else
                    //    {
                    //        chkTerminal5.Checked = false;
                    //        chkTerminal5.Text = "'" + objPosUpdate.Terminal + "' Reload Failed";
                    //        chkTerminal5.Refresh();
                    //    }
                    //}

                    //if (row["Terminal_No"].ToString() == "06")
                    //{
                    //    if (objPosUpdate.TerminalUpdate == true)
                    //    {
                    //        chkTerminal6.Checked = true;
                    //        chkTerminal6.Text = "'" + objPosUpdate.Terminal + "' Completed Successfully";
                    //        chkTerminal6.Refresh();
                    //    }
                    //    else
                    //    {
                    //        chkTerminal6.Checked = false;
                    //        chkTerminal6.Text = "'" + objPosUpdate.Terminal + "' Reload Failed";
                    //        chkTerminal6.Refresh();
                    //    }
                    //}

                    //if (row["Terminal_No"].ToString() == "07")
                    //{
                    //    if (objPosUpdate.TerminalUpdate == true)
                    //    {
                    //        chkTerminal7.Checked = true;
                    //        chkTerminal7.Text = "'" + objPosUpdate.Terminal + "' Completed Successfully";
                    //        chkTerminal7.Refresh();
                    //    }
                    //    else
                    //    {
                    //        chkTerminal7.Checked = false;
                    //        chkTerminal7.Text = "'" + objPosUpdate.Terminal + "' Reload Failed";
                    //        chkTerminal7.Refresh();
                    //    }
                    //}

                    //if (row["Terminal_No"].ToString() == "08")
                    //{
                    //    if (objPosUpdate.TerminalUpdate == true)
                    //    {
                    //        chkTerminal8.Checked = true;
                    //        chkTerminal8.Text = "'" + objPosUpdate.Terminal + "' Completed Successfully";
                    //        chkTerminal8.Refresh();
                    //    }
                    //    else
                    //    {
                    //        chkTerminal8.Checked = false;
                    //        chkTerminal8.Text = "'" + objPosUpdate.Terminal + "' Reload Failed";
                    //        chkTerminal8.Refresh();
                    //    }
                    //}
                    //if (row["Terminal_No"].ToString() == "09")
                    //{
                    //    if (objPosUpdate.TerminalUpdate == true)
                    //    {
                    //        chkTerminal9.Checked = true;
                    //        chkTerminal9.Text = "'" + objPosUpdate.Terminal + "' Completed Successfully";
                    //        chkTerminal9.Refresh();
                    //    }
                    //    else
                    //    {
                    //        chkTerminal9.Checked = false;
                    //        chkTerminal9.Text = "'" + objPosUpdate.Terminal + "' Reload Failed";
                    //        chkTerminal9.Refresh();
                    //    }
                    //}
                    //if (row["Terminal_No"].ToString() == "10")
                    //{
                    //    if (objPosUpdate.TerminalUpdate == true)
                    //    {
                    //        chkTerminal10.Checked = true;
                    //        chkTerminal10.Text = "'" + objPosUpdate.Terminal + "' Completed Successfully";
                    //        chkTerminal10.Refresh();
                    //    }
                    //    else
                    //    {
                    //        chkTerminal10.Checked = false;
                    //        chkTerminal10.Text = "'" + objPosUpdate.Terminal + "' Reload Failed";
                    //        chkTerminal10.Refresh();
                    //    }
                    //}
                    #endregion

                }

                ////Pos 1
                //objPosUpdate.Terminal = "oitpos01";
                //objPosUpdate.TerminalReload();
                //if (objPosUpdate.TerminalUpdate == true)
                //{
                //    chkTerminal1.Checked = true;
                //    chkTerminal1.Text = "Terminal 1 Completed Successfully";
                //}
                //else
                //{
                //    chkTerminal1.Checked = false;
                //    chkTerminal1.Text = "Terminal 1 Update Failed";
                //}
                ////End pos1

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPosUpdate 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
    }
}