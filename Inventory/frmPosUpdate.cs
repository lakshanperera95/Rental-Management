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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Threading;

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
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
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
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
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
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
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
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }
        /*
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
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }
        */
        private void frmPosUpdate_Load(object sender, EventArgs e)
        {
        
            try
            {
                objPosUpdate.ReturnConn();

                DataTable Dt = objPosUpdate.GetTerminals();
                
                foreach (DataRow dr in Dt.Rows)
                {
                    listBoxMsgs.Items.Add(dr[0].ToString() + " : " + dr[1].ToString());
                }
                //txtQuery.Text = " DECLARE @ReloadMsg NVARCHAR(50)" +
                //     " EXEC dbo.sp_PosReloadUpdate @ReloadMsg = @ReloadMsg OUTPUT," +
                //     "  @AllProductDownload = N'T', " +
                //     "  @CustomerDoenload = 'F'";

                txtQuery.Text = Settings.Default.PosReload;

                if (Settings.Default.SelModeMain == true)
                {
                    rbMain.Checked = true;
                }
                else
                {
                    rbOutlet.Checked = true;
                }

                btnAddLinkServers.Visible = btnRunScript.Visible = false;
                if (LoginManager.UserName.ToUpper()=="ONIMTA")
                {
                    this.Width = 707;
                    btnAddLinkServers.Visible = btnRunScript.Visible = true;

                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void btnRunScript_Click(object sender, EventArgs e)
        {
            try
            {
                string SQLCommand1 = Resources.IniScript.ToString();

                // Remove multi-line comments properly
                SQLCommand1 = Regex.Replace(SQLCommand1, @"/\*.*?\*/", "", RegexOptions.Singleline);

                // Split script on "GO" (case-insensitive, ensures proper execution)
                string[] batches = Regex.Split(SQLCommand1, @"\bGO\b", RegexOptions.IgnoreCase);

                foreach (string batch in batches)
                {
                    string trimmedBatch = batch.Trim();
                    if (!string.IsNullOrEmpty(trimmedBatch))
                    {
                        objPosUpdate.Execute_Query(trimmedBatch);
                    }
                }

                MessageBox.Show("Success!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.ToString(),ex.StackTrace);
            }
            finally
            {
                objPosUpdate.connection.InfoMessage -= OnInfoMessage;     
            }

        }

        private void OnInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            if (listBoxMsgs.InvokeRequired)
            {
                listBoxMsgs.BeginInvoke(new Action(() =>
                {
                    string timeStamp = DateTime.Now.ToString("HH:mm:ss");
                    foreach (SqlError error in e.Errors)
                    {
                        listBoxMsgs.Items.Add($"{timeStamp} : {error.Message}");
                    }
                }));
            }
            else
            {
                string timeStamp = DateTime.Now.ToString("HH:mm:ss");

                foreach (SqlError error in e.Errors)
                {
                    listBoxMsgs.Items.Add($"{timeStamp} : {error.Message}");
                }
            }

        }

        private void btnAddLinkServers_Click(object sender, EventArgs e)
        {
            try
            {

                objPosUpdate.OpenConnection();
                listBoxMsgs.Items.Clear();
                objPosUpdate.connection.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);

                SqlCommand command = new SqlCommand
                {
                    Connection = objPosUpdate.connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "[Pos_DbUpdateLinkDataBase]",
                    CommandTimeout = 10000
                };

                // Clear parameters
                command.Parameters.Clear();

                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "ds");

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.ToString(), ex.StackTrace);
            }
            finally
            {
                objPosUpdate.connection.InfoMessage -= OnInfoMessage;
                objPosUpdate.CloseConnection();
            }
        }

        private CancellationTokenSource _cancellationTokenSource;
        private bool _isTaskRunning = false;
        private async void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _isTaskRunning = true;
                btnCusExit.Enabled = false;
                await Task.Run(() => UpdateDb(_cancellationTokenSource.Token), _cancellationTokenSource.Token);
                MessageBox.Show("Database update completed.","Updated",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Operation canceled.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                _isTaskRunning = false;
            }
            finally
            {
                _isTaskRunning = false;
                btnCusExit.Enabled = true;
            }
        }
        /*
        private void UpdateDb(CancellationToken cancellationToken)
        {
            try
            {

                cancellationToken.ThrowIfCancellationRequested();

                objPosUpdate.OpenConnection();

                // UI updates must be on the main thread
                if (listBoxMsgs.InvokeRequired)
                {
                    listBoxMsgs.BeginInvoke(new Action(() => listBoxMsgs.Items.Clear()));
                }
                else
                {
                    listBoxMsgs.Items.Clear();
                }

                if (btnUpdate.InvokeRequired)
                {
                    btnUpdate.BeginInvoke(new Action(() => btnUpdate.Enabled = false));
                }
                else
                {
                    btnUpdate.Enabled = false;
                }


                objPosUpdate.connection.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);

                SqlCommand command = new SqlCommand
                {
                    Connection = objPosUpdate.connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "[Pos_DbUpdateFromText]",
                    CommandTimeout = 1000
                };

                // Clear parameters
                command.Parameters.Clear();
              
                // Use Invoke to get the value of txtQuery on the UI thread synchronously
                string queryText = string.Empty;
                if (txtQuery.InvokeRequired)
                {
                    txtQuery.Invoke(new Action(() =>
                    {
                        if (rbMain.Checked == true)
                        {
                            queryText = " EXEC [Pos_DbUpdateFromText] '" + txtQuery.Text + "' ";
                        }
                        else
                        {
                            queryText = txtQuery.Text;  
                        }
                    }));
                }
                else
                {
                    if (rbMain.Checked == true)
                    {
                        queryText = " EXEC [Pos_DbUpdateFromText] '" + txtQuery.Text + "' ";
                    }
                    else
                    {
                        queryText = txtQuery.Text;
                    }
                }

                // Check if query is empty
                if (string.IsNullOrWhiteSpace(queryText))
                {
                    // Log or handle the case where the SQL query is empty or invalid
                    if (listBoxMsgs.InvokeRequired)
                    {
                        listBoxMsgs.BeginInvoke(new Action(() =>
                        {
                            listBoxMsgs.Items.Add("Error: SQL query is empty.");
                        }));
                    }
                    else
                    {
                        listBoxMsgs.Items.Add("Error: SQL query is empty.");
                    }
                    return; // Exit early to prevent the command from running with an empty query.
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@SQLQuery", queryText));
                }

                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds, "ds");             

                 
                if (btnUpdate.InvokeRequired)
                {
                    btnUpdate.BeginInvoke(new Action(() => btnUpdate.Enabled = true));
                }
                else
                {
                    btnUpdate.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                if (listBoxMsgs.InvokeRequired)
                {
                    listBoxMsgs.BeginInvoke(new Action(() =>
                    {
                        listBoxMsgs.Items.Add("Error: " + ex.Message);
                    }));

                }
                else
                {
                    listBoxMsgs.Items.Add("Error: " + ex.Message);
                }
                BeginInvoke(new Action(() =>
                {
                    clsClear.ErrMessage(ex.ToString(), ex.StackTrace);
                }));
            }
            finally
            {
                objPosUpdate.connection.InfoMessage -= OnInfoMessage;
                objPosUpdate.CloseConnection();
            }
        }
        */
        private void UpdateDb(CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                objPosUpdate.OpenConnection();

                UpdateUI(() => listBoxMsgs.Items.Clear());
                UpdateUI(() => btnUpdate.Enabled = false);

                objPosUpdate.connection.InfoMessage += new SqlInfoMessageEventHandler(OnInfoMessage);

                SqlCommand command = new SqlCommand
                {
                    Connection = objPosUpdate.connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "[Pos_DbUpdateFromText]",
                    CommandTimeout = 1000
                };

                // Get the query text safely from the UI thread
                string queryText = GetQueryText();
                if (string.IsNullOrWhiteSpace(queryText))
                {
                    UpdateUI(() => listBoxMsgs.Items.Add("Error: SQL query is empty."));
                    return;
                }

                command.Parameters.Add(new SqlParameter("@SQLQuery", queryText));

                using (SqlDataAdapter da = new SqlDataAdapter(command))
                using (DataSet ds = new DataSet())
                {
                    da.Fill(ds, "ds");
                }

                UpdateUI(() => btnUpdate.Enabled = true);
            }
            catch (OperationCanceledException)
            {
                UpdateUI(() => listBoxMsgs.Items.Add("Operation canceled."));
                _isTaskRunning = false;
            }
            catch (Exception ex)
            {
                UpdateUI(() =>
                {
                    listBoxMsgs.Items.Add("Error: " + ex.Message);
                    clsClear.ErrMessage(ex.ToString(), ex.StackTrace);
                });
            }
            finally
            {
                objPosUpdate.connection.InfoMessage -= OnInfoMessage;
                objPosUpdate.CloseConnection();
            }
        }
        private string GetQueryText()
        {
            if (txtQuery.InvokeRequired)
            {
                return (string)txtQuery.Invoke(new Func<string>(() =>
                {
                    return rbMain.Checked
                        ? $"EXEC [Pos_DbUpdateFromText] '{txtQuery.Text}'"
                        : txtQuery.Text;
                }));
            }
            else
            {
                return rbMain.Checked
                    ? $"EXEC [Pos_DbUpdateFromText] '{txtQuery.Text}'"
                    : txtQuery.Text;
            }
        }

        private void UpdateUI(Action action)
        {
            if (InvokeRequired)
            {
                BeginInvoke(action);
            }
            else
            {
                action();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cancellationTokenSource?.Cancel();
        }

        private void listBoxMsgs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(listBoxMsgs.SelectedItem.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rbMain_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.SelModeMain = true;
            Settings.Default.Save();
        }

        private void rbOutlet_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.SelModeMain = false;
            Settings.Default.Save();
        }

        private void frmPosUpdate_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (_isTaskRunning)
            {
                MessageBox.Show("Wait for Update to Be Finished","Wait",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
                //DialogResult result = MessageBox.Show(
                //    "A task is still running. Do you want to wait for it to finish?",
                //    "Task Running",
                //    MessageBoxButtons.YesNo,
                //    MessageBoxIcon.Warning);

                //if (result == DialogResult.Yes)
                //{
                //    e.Cancel = true; // Prevent form from closing
                //    return;
                //}

                //// Cancel the running task if the user wants to close
                //_cancellationTokenSource?.Cancel();
            }
        }
    }
}