using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Data.SqlClient;
using clsLibrary;
using GsmComm.GsmCommunication;
using GsmComm.Interfaces;
using GsmComm.PduConverter;
using GsmComm.Server;
using Inventory.Properties;
using System.Management;
using System.Threading;

namespace Inventory
{
    public partial class frmDayEndProcessNew : Form
    {
        public frmDayEndProcessNew()
        {
            InitializeComponent();
        }

        SerialPort port;
        clsDayEndProcessNew objDayEndProcess = new clsDayEndProcessNew();
        clsCommon clsTemp = new clsCommon();
        private static frmDayEndProcessNew DayEndProcess;

        public static frmDayEndProcessNew GetDayEndProcess
        {
            get
            {
                return DayEndProcess;
            }
            set
            {
                DayEndProcess = value;
            }
        }

        private void frmDayEndProcess_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                DayEndProcess = null;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void frmDayEndProcess_FormClosing(object sender, FormClosingEventArgs e)
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
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                DayEndProcess = null;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnDayEnd_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkDuplicated.Checked==false)
                {
                    MessageBox.Show("Duplicates Found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                objDayEndProcess.DayEndProcess();
                
                if (objDayEndProcess.ErrorCode == 0)
                {
                    //btnSMS_Click(sender, e);
                    MessageBox.Show("DayEnd Process Completed Successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (objDayEndProcess.ErrorCode == -10)
                    {
                        MessageBox.Show("Duplicates Data Found. Please contact Onimta information technology", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error Found On DayEnd Process.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }

                lvUnitSales.Items.Clear();
                chkDuplicated.Checked = false;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnSMS_Click(object sender, EventArgs e)
        {
            // sms quary
            
            GsmCommMain comm = new GsmCommMain();
            StreamReader m_streamReader = null;
            StreamReader sr = null;
            try
            {
//--------------------------------------------------------------------------------------------
                //checking  ports
                string[] comports = SerialPort.GetPortNames();
             /*   if (comports.Length <= 1)
                {
                    MessageBox.Show("Please Connect the Doungle", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
*/

                string port = cmbComPrts.Text.Trim();
                

                 
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
                if (ex.Message.Length > 15)
                {
                    string s = ex.Message.Substring(0, 15);
                    if (ex.Message.Substring(0, 15) == "Timeout expired")
                    {
                        clsCommon tempcls = new clsCommon();
                        string sqlStatement = "INSERT INTO tb_DayEndError (PostDate,ErrorDesc) VALUES ('" + DateTime.Now.ToString("dd/MM/yyyy") + "','" + ex.Message + "')";
                        tempcls.getDataReader(sqlStatement);
                        tempcls.closeConnection();
                    }
                }
            }
            finally
            {
                if (comm != null)
                {
                    if (comm.IsOpen())
                    {
                        comm.Close();
                    }
                }
                if (m_streamReader != null)
                {
                    m_streamReader.Close();
                }
                if (sr != null)
                {
                    sr.Close();
                }
                clsTemp.closeConnection();
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
            //check quary
            lblPAwait.Visible = true;
            string netAmount = "";
            Application.DoEvents();
            
            objDayEndProcess.PosSalesSummary(LoginManager.LocaCode, dtpDate.Text.Trim(), dtpDate.Text.Trim());
            string sqlStatement = "select ISNULL(SUM(PosNet_Amt),0) from tbPosSalesSummary inner join Location on tbPosSalesSummary.loca = Location.loca WHERE Location.Loca='" + LoginManager.LocaCode + "' ";
            clsTemp.getDataReader(sqlStatement);
            if (clsTemp.Adr.Read())
            {
                 netAmount = Convert.ToDecimal(clsTemp.Adr[0].ToString()).ToString();
            }
            clsTemp.closeConnection();


            lblNetSales.Text = "Rs." + netAmount;
            lblPAwait.Visible = false;

        }
        catch (Exception ex)
        {

            clsClear.ErrMessage(ex.Message, ex.StackTrace);
        }

        }

        private void txtSmsNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                
               clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
           
        }

        private void frmDayEndProcess_Load(object sender, EventArgs e)
        {
            try
            {

               
                lblPAwait.Visible = false;
                string stCOMPort = "";
                string userRole = "";
                //--------------------------------------------------------------------------------------------
                //
                string query = "SELECT UserRole_Id FROM Employee WHERE(Emp_Name = '" + LoginManager.UserName + "') AND (Loca = '" + LoginManager.LocaCode + "') AND Acc_Desable = 'F'";
                clsTemp.getDataReader(query);
                if (clsTemp.Adr.Read())
                {
                    userRole = Convert.ToDecimal(clsTemp.Adr[0].ToString()).ToString();
                }

                clsTemp.closeConnection();
               
               // ---------------------------------------------------------------------------------------------
                
              

                
                  
             
                //-----------------------------------------------------------------------------------------------
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

       

      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Items.Count>0 && comboBox1.Text.Trim()!="")
                {
                    
                    txtCOMPort.Text = comboBox1.Text.Substring(comboBox1.Text.LastIndexOf("(") + 4, comboBox1.Text.LastIndexOf(")") - (comboBox1.Text.LastIndexOf("(") + 4));
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            
            }
        }

        private bool CheckExistingModemOnComPort(SerialPort serialPort)
        {
           

            if ((serialPort == null) || !serialPort.IsOpen)
                return false;

            // Commands for modem checking
            string[] modemCommands = new string[] { "AT",       // Check connected modem. After 'AT' command some modems autobaud their speed.
                                            "ATQ0" };   // Switch on confirmations
            serialPort.DtrEnable = true;    // Set Data Terminal Ready (DTR) signal 
            serialPort.RtsEnable = true;    // Set Request to Send (RTS) signal

            string answer = "";
            bool retOk = false;
            for (int rtsInd = 0; rtsInd < 2; rtsInd++)
            {
                foreach (string command in modemCommands)
                {
                    serialPort.Write(command + serialPort.NewLine);
                    retOk = false;
                    answer = "";
                    int timeout = (command == "AT") ? 10 : 20;

                    // Waiting for response 1-2 sec
                    for (int i = 0; i < timeout; i++)
                    {
                        Thread.Sleep(100);
                        answer += serialPort.ReadExisting();
                        if (answer.IndexOf("OK") >= 0)
                        {
                            retOk = true;
                            break;
                        }
                    }
                }
                // If got responses, we found a modem
                if (retOk)
                    return true;

                // Trying to execute the commands without RTS
                serialPort.RtsEnable = false;
            }
            return false;
        
       
        }

        private void btn_Click(object sender, EventArgs e)
        {
            
                //1
            //string[] comports = SerialPort.GetPortNames();
            //for (int i = 0; i < comports.Length; i++)
            //{
            //    SerialPort port = new SerialPort(comports[i], 9600, Parity.None, 8, StopBits.One);
            //    if (port.IsOpen)
            //    {
            //        port.Close();
            //    }
            //    port.Open();
            //    if (CheckExistingModemOnComPort(port))
            //    {
            //        MessageBox.Show(comports[i]);
            //    }
            //    else
            //    {
            //        port.Close();
            //    }
                
            //}

                //2
            lblPAwait.Visible = true;
            this.Refresh();
            cmbComPrts.Items.Clear();
            cmbComPrts.Text = "";
            foreach (string portname in SerialPort.GetPortNames())
            {
                // Use your connection settings - own baud rate etc
                
                SerialPort sp = new SerialPort(portname, 4800, Parity.Odd, 8, StopBits.One);
                try
                {
                    if (sp.IsOpen)
                    {
                        sp.Close();
                    }
                    sp.Open();
                    sp.Write("AT\r");
                    Thread.Sleep(500);
                    string received = sp.ReadExisting();

                    if (received.IndexOf("OK")>=0)
                    {
                        cmbComPrts.Items.Add(portname.Replace("COM", ""));
                        cmbComPrts.Text = portname.Replace("COM", "");
                    }
                }
                catch (Exception ex)
                {
                    clsClear.ErrMessage(ex.Message, ex.StackTrace);
                }
                finally
                {
                    sp.Close();
                }
            }
            lblPAwait.Visible = false;
            this.Refresh();
            
        }

        private void btnCheckDuplicate_Click(object sender, EventArgs e)
        {
            try
            {
                btnRemoveDup.Enabled = false;
                objDayEndProcess.DuplicateCheck();
                if (objDayEndProcess.ErrorCode == 0)
                {
                    chkDuplicated.Checked = true;
                }
                else
                {
                    if (objDayEndProcess.ErrorCode == -10)
                    {
                        MessageBox.Show("Duplicates Data Found. Please contact Onimta information technology", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRemoveDup.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Error Found On DayEnd Process.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    chkDuplicated.Checked = false;
                }
                DataTable dt = new DataTable();
                dt=objDayEndProcess.dsResultSet.Tables["dsDuplicateCheck"];

                lvUnitSales.Items.Clear();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        ListViewItem list = new ListViewItem(dtRow[0].ToString());
                        for (int i = 1; i < dt.Columns.Count; i++)
                        {
                            list.SubItems.Add(dtRow[i].ToString());
                        }
                        lvUnitSales.Items.Add(list);
                        int count = lvUnitSales.Items.Count;
                        if (count % 2 == 1)
                        {
                            list.BackColor = System.Drawing.Color.PowderBlue;
                        }
                        else
                        {
                            list.BackColor = Color.White;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnRemoveDup_Click(object sender, EventArgs e)
        {
            try
            {
                objDayEndProcess.DuplicateRemove();
                if (objDayEndProcess.ErrorCode == 0)
                {
                    
                }
                else
                {
                    if (objDayEndProcess.ErrorCode == -10)
                    {
                        MessageBox.Show("Duplicates Data Found. Please contact Onimta information technology", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Error Found On DayEnd Process.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    chkDuplicated.Checked = false;
                }
                DataTable dt = new DataTable();
                dt = objDayEndProcess.dsResultSet.Tables["dsDuplicateCheck"];

                lvUnitSales.Items.Clear();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dtRow in dt.Rows)
                    {
                        ListViewItem list = new ListViewItem(dtRow[0].ToString());
                        for (int i = 1; i < dt.Columns.Count; i++)
                        {
                            list.SubItems.Add(dtRow[i].ToString());
                        }
                        lvUnitSales.Items.Add(list);
                        int count = lvUnitSales.Items.Count;
                        if (count % 2 == 1)
                        {
                            list.BackColor = System.Drawing.Color.PowderBlue;
                        }
                        else
                        {
                            list.BackColor = Color.White;
                        }
                    }
                }
                MessageBox.Show("Duplicates Removed.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRemoveDup.Enabled = false;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

    }
}