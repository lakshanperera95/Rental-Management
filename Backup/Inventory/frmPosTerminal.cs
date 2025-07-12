using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using clsLibrary;
using Inventory.Properties;

namespace Inventory
{
    public partial class frmPosTerminal : Form
    {
        public frmPosTerminal()
        {
            InitializeComponent();
        }

        private static frmPosTerminal PosTerminal;
        clsPosTerminal objPosTerminal = new clsPosTerminal();

        public static frmPosTerminal GetPosTerminal
        {
            get { return PosTerminal; }
            set { PosTerminal = value; }
        }

        private void frmPosTerminal_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                PosTerminal = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPosTerminal 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPosTerminal_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPosTerminal 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnCusExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                PosTerminal = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPosTerminal 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
            try
            {
                //Update Locally
                objPosTerminal.Tail1 = txtTrailerMessage1.Text.Trim();
                objPosTerminal.Tail2 = txtTrailerMessage2.Text.Trim();
                objPosTerminal.Tail3 = txtTrailerMessage3.Text.Trim();
                objPosTerminal.Tail4 = txtTrailerMessage4.Text.Trim();
                objPosTerminal.Tail5 = txtTrailerMessage5.Text.Trim();
                objPosTerminal.Tail6 = txtTrailerMessage6.Text.Trim();
                objPosTerminal.Tail7 = txtTrailerMessage7.Text.Trim();
                objPosTerminal.Tail8 = txtTrailerMessage8.Text.Trim();
                objPosTerminal.Tail9 = txtTrailerMessage9.Text.Trim();
                objPosTerminal.Tail10 = txtTrailerMessage10.Text.Trim();
                objPosTerminal.Message = txtDisplayMessage.Text.Trim();
                objPosTerminal.UpdatePosSettingsLocal();


                objPosTerminal.GetPosTerminal();
                lisChkListBox.Items.Clear();
                foreach (DataRow row in objPosTerminal.PosTerminal.Tables["dsTerminalDetails"].Rows)
                {
                    //Pos 1
                    objPosTerminal.Terminal = row["Terminal_Name"].ToString();
                    objPosTerminal.TerminalPwd = row["Terminal_Password"].ToString();
                    objPosTerminal.DatabaseName = row["DatabaseName"].ToString();

                    objPosTerminal.TerminalReload();

                    for (int i = 1; i < Settings.Default.NoOfTerminal + 1; i++)
                    {
                        if (row["Terminal_No"].ToString() == "0" + i)
                        {
                            if (objPosTerminal.TerminalUpdate == true)
                            {
                                lisChkListBox.Items.Add("(" + objPosTerminal.Terminal + ")  Completed Successfully", true);
                                lisChkListBox.Refresh();
                            }
                            else
                            {
                                lisChkListBox.Items.Add("(" + objPosTerminal.Terminal + ")  Update Failed", false);
                                lisChkListBox.Refresh();
                            }
                        }
                    }
                }
                MessageBox.Show("Pos Terminal Settings Update Completed Successfully.", "Pos Terminal Settings Update", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPosTerminal 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmPosTerminal_Load(object sender, EventArgs e)
        {
            try
            {
                objPosTerminal.ReadDefaultPosSettings();
                if (objPosTerminal.RecordFound == true)
                {
                    txtDisplayMessage.Text = objPosTerminal.Message;
                    txtTrailerMessage1.Text = objPosTerminal.Tail1;
                    txtTrailerMessage2.Text = objPosTerminal.Tail2;
                    txtTrailerMessage3.Text = objPosTerminal.Tail3;
                    txtTrailerMessage4.Text = objPosTerminal.Tail4;
                    txtTrailerMessage5.Text = objPosTerminal.Tail5;
                    txtTrailerMessage6.Text = objPosTerminal.Tail6;
                    txtTrailerMessage7.Text = objPosTerminal.Tail7;
                    txtTrailerMessage8.Text = objPosTerminal.Tail8;
                    txtTrailerMessage9.Text = objPosTerminal.Tail9;
                    txtTrailerMessage10.Text = objPosTerminal.Tail10;

                }
                else
                {
                    txtDisplayMessage.Text = "<<<<   WELCOME ONIMTA IT";
                    txtTrailerMessage1.Text = "---------------------------------";
                    txtTrailerMessage2.Text = "THANK YOU FOR SHOPING";
                    txtTrailerMessage3.Text = "---------------------------------";
                    txtTrailerMessage4.Text = string.Empty ;
                    txtTrailerMessage5.Text = string.Empty;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmPosTerminal 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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