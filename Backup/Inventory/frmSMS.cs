using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GsmComm.GsmCommunication;
using GsmComm.Interfaces;
using GsmComm.PduConverter;
using GsmComm.Server;
using clsLibrary;
using System.IO.Ports;
using System.IO; 
using System.Web;
using System.Net;
using Inventory.Properties;

namespace Inventory
{
    public partial class frmSMS : Form
    {
        GsmCommMain comm;

        public frmSMS()
        {
            InitializeComponent();
            
        }

        clsSMS2 main = new clsSMS2();
        clsSMS objChildBDay = new clsSMS();

        private static frmSMS SMS;
        public static frmSMS GetSMS
        {
            get { return SMS; }
            set { SMS = value; }
        }

        Control[] control = new Control[] { };

        void visibleTF(Control[] contsTrue, Control[] contsFalse)
        {
            for (int i = 0; i < contsTrue.Length; i++)
            {
                contsTrue[i].Visible = true;
            }
            for (int i = 0; i < contsFalse.Length; i++)
            {
                contsFalse[i].Visible = false;
            }
        }
        clsCommon ObjComm = new clsCommon();
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                comm = new GsmCommMain(Convert.ToInt32(txtCOMPort.Text.Trim()), 15200, 10000);
                Settings.Default.ComNo = int.Parse(txtCOMPort.Text.ToString());
                Settings.Default.Save();

                if (rdbDongel.Checked == true)
                {
                    if (comm.IsOpen())
                    {
                        comm.Close();
                    }
                    //comm = new GsmCommMain(OnimtaOpticalSystem.Properties.Settings.Default.ComNo, 15200, 100);

                    comm.Open();

                }

                SmsSubmitPdu pdu;

                for (int i = 0; i < dgCustomer.RowCount; i++)
                {
                    lblCust.Text = dgCustomer.Rows[i].Cells[1].Value.ToString() + " - " + dgCustomer.Rows[i].Cells[2].Value.ToString() + " Sending... ";

                    if (Convert.ToBoolean(dgCustomer.Rows[i].Cells[0].FormattedValue) == true)
                    {
                        try
                        {
                            if (dgCustomer.Rows[i].Cells[4].Value.ToString().Replace("'", "").Length == 10)
                            {
                                try
                                {
                                    switch (dgCustomer.Rows[i].Cells[4].Value.ToString().Substring(0, 3))
                                    {
                                        case "070":
                                        case "071":
                                        case "072":
                                        case "075":
                                        case "076":
                                        case "077":
                                        case "078":
                                        case "011":
                                            pdu = new SmsSubmitPdu(richMessage.Text.Replace("<<<Name>>>", dgCustomer.Rows[i].Cells[2].Value.ToString()), dgCustomer.Rows[i].Cells[4].Value.ToString(), "");
                                            pdu.RequestStatusReport = true;
                                            //comm.SendMessage(pdu);

                                            if (rdbDongel.Checked == true)
                                            {
                                                comm.SendMessage(pdu);
                                            }
                                            else
                                            {

                                                string baseURL = "SELECT API FROM tb_Url ";
                                                objChildBDay.getDataReaderbaseURL(baseURL);
                                                if (objChildBDay.Reader.Read())
                                                {
                                                    baseURL = objChildBDay.Reader["API"].ToString();
                                                    baseURL = baseURL.Replace("PhoneNo", dgCustomer.Rows[i].Cells[4].Value.ToString()).Replace("Message", richMessage.Text.Replace("<<<Name>>>", dgCustomer.Rows[i].Cells[2].Value.ToString()));
                                                    
                                                    HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(baseURL);
                                                    HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
                                                    System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());

                                                    string responseString = respStreamReader.ReadToEnd();

                                                    if (responseString.Contains("Operation success"))
                                                    {
                                                        lblCust.Text = dgCustomer.Rows[i].Cells[1].Value.ToString() + " - " + dgCustomer.Rows[i].Cells[2].Value.ToString() + " Sent Success. ";

                                                    }
                                                    else
                                                    {
                                                        lblCust.Text = dgCustomer.Rows[i].Cells[1].Value.ToString() + " - " + dgCustomer.Rows[i].Cells[2].Value.ToString() + " Sent Error. ";
                                                    }

                                                    respStreamReader.Close();
                                                    myResp.Close();

                                                }
                                            }

                                            dgCustomer.Rows[i].Cells[6].Value = true;
                                            dgCustomer.Refresh();

                                         /*   try
                                            {
                                                main.getReader(@"INSERT INTO CRM_SentSMS (Cus_Code, Cus_Name, SMS, InsertUser)
                                                VALUES ('" + dgCustomer.Rows[i].Cells[1].Value.ToString() + "', '" + dgCustomer.Rows[i].Cells[2].Value.ToString() + "', 'BIR', '" + clsSMS2.LoginUser.Trim() + "')");
                                            }
                                            finally
                                            {
                                                main.CloseReaderAndConnection();
                                            }*/
                                            break;

                                        default:
                                            MessageBox.Show("Mobile number is incorrect!\r\nPlease check the number before sending SMS again.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.ToString(), "SMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                notifyIcon1.ShowBalloonTip(2, "All Messages Sent Successfully.", " ", System.Windows.Forms.ToolTipIcon.Info);
                if (comm.IsOpen())
                {
                    comm.Close();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void frmSMS_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //main.getDataSet("DELETE FROM CRM_TempIndividualSMS");
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            SMS = null;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "";
                if (!raiBirthDay.Checked)
                {
                    Query = "SELECT Cus_Code, Cus_Name, REPLACE(Address1 + Address2 + Address3 + Address5,',',',') AS [Address], CONVERT(NVARCHAR(10),Birthday,103) [Birthday], REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(Mobile,'-',''),' ',''),'A',''),'B',''),'C',''),'D',''),'E',''),'F',''),'G',''),'H',''),'I',''),'J',''),'K',''),'L',''),'M',''),'N',''),'O',''),'P',''),'Q',''),'R',''),'S',''),'T',''),'U',''),'V',''),'W',''),'Z',''),'Y',''),'Z',''),',',''),'(',''),')',''),'''','') AS [Mobile], '" + dtBirthDate.Text.Trim() + "' AS [DateFrom], CASE LEN(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(Mobile,'-',''),' ',''),'A',''),'B',''),'C',''),'D',''),'E',''),'F',''),'G',''),'H',''),'I',''),'J',''),'K',''),'L',''),'M',''),'N',''),'O',''),'P',''),'Q',''),'R',''),'S',''),'T',''),'U',''),'V',''),'W',''),'Z',''),'Y',''),'Z',''),',',''),'(',''),')',''),'''','')) WHEN 10 THEN 1 ELSE 0 END [SELECT] FROM CRM_Customer ";
                }
                else
                {
                    Query = "SELECT Cus_Code, Cus_Name, REPLACE(Address1 + Address2 + Address3 + Address5,',',',') AS [Address], CONVERT(NVARCHAR(10),Birthday,103) [Birthday], REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(Mobile,'-',''),' ',''),'A',''),'B',''),'C',''),'D',''),'E',''),'F',''),'G',''),'H',''),'I',''),'J',''),'K',''),'L',''),'M',''),'N',''),'O',''),'P',''),'Q',''),'R',''),'S',''),'T',''),'U',''),'V',''),'W',''),'Z',''),'Y',''),'Z',''),',',''),'(',''),')',''),'''','') AS [Mobile], '" + dtBirthDate.Text.Trim() + "' AS [DateFrom], CASE LEN(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(Mobile,'-',''),' ',''),'A',''),'B',''),'C',''),'D',''),'E',''),'F',''),'G',''),'H',''),'I',''),'J',''),'K',''),'L',''),'M',''),'N',''),'O',''),'P',''),'Q',''),'R',''),'S',''),'T',''),'U',''),'V',''),'W',''),'Z',''),'Y',''),'Z',''),',',''),'(',''),')',''),'''','')) WHEN 10 THEN 1 ELSE 0 END [SELECT] FROM CRM_Customer ";
                }
                if (raiAll.Checked)
                {
                    Query = Query + " WHERE LEN(REPLACE(Mobile,' ','')) <> 0 AND Inactive = " + Convert.ToByte(chkInactive.Checked) + " ORDER BY CONVERT(DATETIME,InsertDate,103)";
                    cmbCustType.Text = string.Empty;
                    cmbCustGroup.Text = string.Empty;
                }
                else if (raiBirthDay.Checked)
                {
                    Query = Query + " WHERE SUBSTRING(Birthday, 1, 5) = '" + dtBirthDate.Text.Substring(0, 5) + "' AND LEN(REPLACE(Mobile,' ','')) <> 0 AND Inactive = " + Convert.ToByte(chkInactive.Checked) + " ORDER BY CONVERT(DATETIME,Birthday,103)";
                    chkChildBDays.Checked = false;
                    chkSpouseBDay.Checked = false;
                }
                else if (raiFestival.Checked)
                {
                    Query = Query + " WHERE Festival LIKE '%" + cmbFestival.SelectedIndex.ToString() + "%' AND LEN(REPLACE(Mobile,' ','')) <> 0 AND Inactive = " + Convert.ToByte(chkInactive.Checked) + " ORDER BY CONVERT(DATETIME,InsertDate,103)";
                }
                else if (rbPoints.Checked)
                {
                    Query = "SELECT Cus_Code, Cus_Name, PhoneNo [Address], Mobile, SUM(Points) Birthday FROM Pos_CustomerPoints PCP INNER JOIN CRM_Customer CC ON PCP.Cust_Code=CC.Cus_Code WHERE CONVERT(DATETIME,ReportDate,103) BETWEEN '01'+ SUBSTRING(CONVERT(NVARCHAR(10),GETDATE(),103),3,8) AND GETDATE() GROUP BY  Cus_Code, Cus_Name, Mobile, PhoneNo HAVING SUM(Points) BETWEEN " + txtPointsFrom.Text.Trim() + " AND " + txtPointsTo.Text.Trim() + "  ORDER BY Birthday DESC ";
                }
                else if (rbPurchValue.Checked)
                {
                    Query = "SELECT Cus_Code, Cus_Name,  Mobile [Address], ReportDate [Mobile], SUM(ActualBillAmt) [BirthDay]  FROM Pos_CustomerPoints PCP INNER JOIN CRM_Customer CC ON PCP.Cust_Code=CC.Cus_Code WHERE ActualBillAmt BETWEEN " + txtPointsFrom.Text.Trim() + "  AND " + txtPointsTo.Text.Trim() + "  GROUP BY Cus_Code, Cus_Name, ReportDate, Mobile ORDER BY BirthDay DESC";
                }
                else if (rbAnniversary.Checked)
                {
                    Query = "SELECT Cus_Code, Cus_Name, REPLACE(Address1 + Address2 + Address3 + Address5,',',',') AS [Address], CONVERT(NVARCHAR(10),Birthday,103) [Birthday], Birthday, REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(Mobile,'-',''),' ',''),'A',''),'B',''),'C',''),'D',''),'E',''),'F',''),'G',''),'H',''),'I',''),'J',''),'K',''),'L',''),'M',''),'N',''),'O',''),'P',''),'Q',''),'R',''),'S',''),'T',''),'U',''),'V',''),'W',''),'Z',''),'Y',''),'Z',''),',',''),'(',''),')',''),'''','') AS [Mobile], '" + dtBirthDate.Text.Trim() + "' AS [DateFrom], CASE LEN(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(Mobile,'-',''),' ',''),'A',''),'B',''),'C',''),'D',''),'E',''),'F',''),'G',''),'H',''),'I',''),'J',''),'K',''),'L',''),'M',''),'N',''),'O',''),'P',''),'Q',''),'R',''),'S',''),'T',''),'U',''),'V',''),'W',''),'Z',''),'Y',''),'Z',''),',',''),'(',''),')',''),'''','')) WHEN 10 THEN 1 ELSE 0 END [SELECT] FROM CRM_Customer WHERE SUBSTRING(Anniversary, 1, 5) = '" + dtAnniversary.Text.Substring(0, 5) + "' AND LEN(REPLACE(Mobile,' ','')) <> 0 AND Inactive = " + Convert.ToByte(chkInactive.Checked) + " ORDER BY Cus_Code";
                }

                main.dataset = main.getDataSet(Query, "Customer");
                dgCustomer.DataSource = main.dataset.Tables[0];
                dgCustomer.Refresh();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnWithName_Click(object sender, EventArgs e)
        {
            try
            {
                richMessage.Text = richMessage.Text.Insert(richMessage.SelectionStart, "<<<Name>>>");
                richMessage.Refresh();
                richMessage.Focus();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void richMessage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblMSGLength.Text = string.Format("{0:0}", (160 - richMessage.Text.Length));
                btnSend.Enabled = (lblMSGLength.Text == "160") ? false : true;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void raiAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (raiAll.Checked)
                {
                    dgCustomer.DataSource = null;
                    visibleTF(new Control[] {btnDisplay}, new Control[] {lblBirthday, dtBirthDate, lblFestival, cmbFestival, txtCus_Code, txtCus_Name, btnCusSearch});
                    chkChildBDays.Visible = false;
                    chkSpouseBDay.Visible = false;

                    txtPointsFrom.Visible = false;
                    txtPointsTo.Visible = false;
                    lblPointsFrom.Visible = false;
                    lblPointsTo.Visible = false;
                    lblFrom.Visible = false;
                    lblPurchValue.Visible = false;
                    dtAnniversary.Visible = false;                 

                    chkCustRegDate.Visible = true;
                    dtpCustRegDate.Visible = true;
                    lblCustGroup.Visible = true;
                    cmbCustGroup.Visible = true;
                    lblCustType.Visible = true;
                    cmbCustType.Visible = true;

                    txtCus_Code.Text = string.Empty;
                    txtCus_Name.Text = string.Empty;

                    cusNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
                    birthdayDataGridViewTextBoxColumn.HeaderText = "BirthDay";
                    addressDataGridViewTextBoxColumn.HeaderText = "Address";
                    mobileDataGridViewTextBoxColumn.HeaderText = "Mobile";

                    lblReligion.Visible = false;
                    cmbReligion.Visible = false;
                }
                else
                {
                    dgCustomer.DataSource = null;
                    chkCustRegDate.Checked = false;
                    dtpCustRegDate.Value = System.DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void raiIndividual_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (raiIndividual.Checked)
                {
                    dgCustomer.DataSource = null;
                    visibleTF(new Control[] { txtCus_Code, txtCus_Name, btnCusSearch }, new Control[] { lblBirthday, dtBirthDate, lblFestival, cmbFestival, btnDisplay });
                    chkChildBDays.Visible = false;
                    chkSpouseBDay.Visible = false;

                    txtPointsFrom.Visible = false;
                    txtPointsTo.Visible = false;
                    lblPointsFrom.Visible = false;
                    lblPointsTo.Visible = false;
                    lblFrom.Visible = false;
                    lblPurchValue.Visible = false;
                    lblCustGroup.Visible = false;
                    cmbCustGroup.Visible = false;
                    lblCustType.Visible = false;
                    cmbCustType.Visible = false;
                    dtAnniversary.Visible = false;
                  
                    chkCustRegDate.Visible = false;
                    dtpCustRegDate.Visible = false;

                    txtCus_Code.Focus();

                    cusNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
                    addressDataGridViewTextBoxColumn.HeaderText = "Address";
                    mobileDataGridViewTextBoxColumn.HeaderText = "Mobile";
                    birthdayDataGridViewTextBoxColumn.HeaderText = "Reg:Date";


                    lblReligion.Visible = false;
                    cmbReligion.Visible = false;
                }
                else
                {
                    dgCustomer.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void raiBirthDay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (raiBirthDay.Checked)
                {
                    dgCustomer.DataSource = null;
                    visibleTF(new Control[] { btnDisplay, lblBirthday, dtBirthDate }, new Control[] { lblFestival, cmbFestival, txtCus_Code, txtCus_Name, btnCusSearch });
                    birthdayDataGridViewTextBoxColumn.HeaderText = "Birthday";
                    chkChildBDays.Visible = true;
                    chkSpouseBDay.Visible = true;

                    txtPointsFrom.Visible = false;
                    txtPointsTo.Visible = false;
                    lblPointsFrom.Visible = false;
                    lblPointsTo.Visible = false;
                    lblFrom.Visible = false;
                    lblPurchValue.Visible = false;
                    lblCustGroup.Visible = false;
                    cmbCustGroup.Visible = false;
                    lblCustType.Visible = false;
                    cmbCustType.Visible = false;
                    dtAnniversary.Visible = false;

                    txtCus_Code.Text = string.Empty;
                    txtCus_Name.Text = string.Empty;

                    chkCustRegDate.Visible = false;
                    dtpCustRegDate.Visible = false;

                    dtBirthDate.Focus();
                    dtBirthDate.Select();

                    lblBirthday.Text = "Birthday";

                    cusNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
                    birthdayDataGridViewTextBoxColumn.HeaderText = "BirthDay";
                    addressDataGridViewTextBoxColumn.HeaderText = "Address";
                    mobileDataGridViewTextBoxColumn.HeaderText = "Mobile";


                    lblReligion.Visible = false;
                    cmbReligion.Visible = false;
                }
                else
                {
                    dgCustomer.DataSource = null;
                   /// birthdayDataGridViewTextBoxColumn.HeaderText = "Reg: Date";
                    //mobileDataGridViewTextBoxColumn.HeaderText = "Mobile";
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void raiFestival_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (raiFestival.Checked)
                {
                    dgCustomer.DataSource = null;
                    visibleTF(new Control[] { btnDisplay, lblFestival, cmbFestival }, new Control[] { lblBirthday, dtBirthDate, txtCus_Code, txtCus_Name, btnCusSearch });
                    chkChildBDays.Visible = false;
                    chkSpouseBDay.Visible = false;

                    txtPointsFrom.Visible = false;
                    txtPointsTo.Visible = false;
                    lblPointsFrom.Visible = false;
                    lblPointsTo.Visible = false;
                    lblFrom.Visible = false;
                    lblCustGroup.Visible = false;
                    cmbCustGroup.Visible = false;
                    lblCustType.Visible = false;
                    cmbCustType.Visible = false;
                    dtAnniversary.Visible = false;
                  
                    lblPurchValue.Visible = false;

                    chkCustRegDate.Visible = false;
                    dtpCustRegDate.Visible = false;

                    txtCus_Code.Text = string.Empty;
                    txtCus_Name.Text = string.Empty;

                    cusNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
                    birthdayDataGridViewTextBoxColumn.HeaderText = "BirthDay";
                    addressDataGridViewTextBoxColumn.HeaderText = "Address";
                    mobileDataGridViewTextBoxColumn.HeaderText = "Mobile";


                    lblReligion.Visible = false;
                    cmbReligion.Visible = false;
                }
                else
                {
                    dgCustomer.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void frmSMS_Load(object sender, EventArgs e)
        {
            try
            {
                //comm = new GsmCommMain(Convert.ToInt32(txtCOMPort.Text.Trim()), 15200, 100);
                txtCOMPort.Text = Settings.Default.ComNo.ToString();
                //Settings.Default.Save();

                main.dataset = main.getDataSet("SELECT FastName FROM CRM_Fastival ORDER BY Numbers ASC");
                cmbFestival.DataSource = main.dataset.Tables[0];
                cmbFestival.DisplayMember = "FastName";

                string SqlStatement = "SELECT Type FROM CRM_CustomerType";
                main.getDataReader(SqlStatement);
                while (main.Reader.Read())
                {
                    cmbCustType.Items.Add(main.Reader["Type"].ToString());
                }

                SqlStatement = "SELECT Group_Name FROM CRM_CustomerGroup ";
                main.getDataReader(SqlStatement);
                while (main.Reader.Read())
                {
                    cmbCustGroup.Items.Add(main.Reader["Group_Name"].ToString());
                }

                lblCust.Text = "";

                SqlStatement = "SELECT Religion FROM CRM_Religion ORDER BY Religion";
                main.getDataset(SqlStatement, "dsReligion");
                cmbReligion.DataSource = main.dataset.Tables["dsReligion"];
                cmbReligion.DisplayMember = "Religion";
                cmbReligion.Refresh();

                cmbReligion.SelectedIndex = -1;
                cmbReligion.Text = "";
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnTextSave_Click(object sender, EventArgs e)
        {
            try
            {
                //-----Save Message--------
                richMessage.Text = "";

                FileStream fileStream;
                string SqlStatement = "SELECT Company_Name FROM CRM_CardInfo";
                objChildBDay.getDataReader(SqlStatement);
                if (objChildBDay.Reader.Read())
                {
                    string Msg_From = objChildBDay.Reader["Company_Name"].ToString();
                    richMessage.Text = richMessage.Text + "\nFrom : " + Msg_From.ToString();
                }

                SqlStatement = "SELECT Cus_Name FROM CRM_Customer";
                objChildBDay.getDataReader(SqlStatement);
                if (objChildBDay.Reader.Read())
                {
                    string Msg_Start = objChildBDay.Reader["Cus_Name"].ToString();
                    richMessage.Text = "Dear  " + Msg_Start.ToString() + "\n" + richMessage.Text;
                }
                
                if (richMessage.Text.Replace("\n", " ").Replace("@", "").Replace(":", "").Length >= 20)
                {
                    fileStream = new FileStream(@"..\Templete\" + richMessage.Text.Replace("\n", " ").Replace("@", "").Replace(":", "").Substring(0, 20) + ".txt", FileMode.Create);
                }
                else
                {
                    fileStream = new FileStream(@"..\Templete\" + richMessage.Text.Replace("\n", " ").Replace("@", "").Replace(":", "").ToString().Trim() + ".txt", FileMode.Create);
                }

                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                //string g = @".\Templete\" + Path.GetRandomFileName();

                try
                {
                    m_streamWriter.WriteLine(richMessage.Text.ToString());
                    btnTemplate.PerformClick();
                }
                finally
                {
                    m_streamWriter.Close();
                    fileStream.Close();                    
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnCusSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerSearch search = new frmCustomerSearch();
                if (txtCus_Code.Text != string.Empty && txtCus_Name.Text == string.Empty)
                {
                    clsSMS2.SearchDataset = main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE Cus_Code LIKE '%" + txtCus_Code.Text.Trim() + "%' ORDER BY Cus_Code", "T");
                }
                if (txtCus_Code.Text == string.Empty && txtCus_Name.Text != string.Empty)
                {
                    clsSMS2.SearchDataset = main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer WHERE Cus_Name LIKE '%" + txtCus_Name.Text.Trim() + "%' ORDER BY Cus_Name", "T");
                }
                else
                {
                   clsSMS2.SearchDataset = main.getDataSet("SELECT Cus_Code AS [Customer], Cus_Name AS [Name], Address5 AS [Town], Birthday AS [BirthDay], PhoneNo AS [Phone], Mobile FROM CRM_Customer ORDER BY Cus_Code", "T");
                }

                search.ShowDialog();

                if (clsSMS2.Cnt_Focus != null)
                {
                    txtCus_Code.Text = clsSMS2.Cnt_Focus.ToString();
                    txtCus_Name.Text = clsSMS2.Cnt_Descrip.ToString();
                    clsSMS2.Cnt_Focus = null;
                    clsSMS2.Cnt_Descrip = null;
                }
                txtCus_Code.Focus();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void txtCus_Code_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCus_Code.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Please enter a Customer Code.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCus_Code.Focus();
                        txtCus_Code.SelectAll();
                        return;
                    }

                    string SqlStatement = "SELECT Cus_Code, Card_No FROM CRM_Customer WHERE (Cus_Code='" + txtCus_Code.Text.Trim() + "' OR Card_No='" + txtCus_Code.Text.Trim() + "')";
                    objChildBDay.getDataReader(SqlStatement);
                    if (!objChildBDay.Reader.Read())
                    {
                        MessageBox.Show("Customer not found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCus_Code.Focus();    
                        txtCus_Code.SelectAll();   
                        return;
                    }

                    SqlStatement = "SELECT C.Cus_Code, C.Cus_Name, REPLACE(C.Address1 + C.Address2 + C.Address3 +  C.Address5,',',',') AS [Address],CASE C.BirthDay WHEN '/  /' THEN CONVERT(DATETIME,'01/01/1990',103) ELSE CONVERT(DATETIME,C.Birthday,103) END [Birthday], REPLACE(C.Address1 + C.Address2 + C.Address3 +  C.Address5,',',',') AS [Address], CASE C.BirthDay WHEN '/  /' THEN CONVERT(DATETIME,'01/01/1990',103) ELSE CONVERT(DATETIME,C.Birthday,103) END [Birthday] /*C.Birthday*/, REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(C.Mobile,'-',''),' ',''),'A',''),'B',''),'C',''),'D',''),'E',''),'F',''),'G',''),'H',''),'I',''),'J',''),'K',''),'L',''),'M',''),'N',''),'O',''),'P',''),'Q',''),'R',''),'S',''),'T',''),'U',''),'V',''),'W',''),'Z',''),'Y',''),'Z',''),',',''),'(',''),')',''),'''','') AS [Mobile], CASE LEN(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(C.Mobile,'-',''),' ',''),'A',''),'B',''),'C',''),'D',''),'E',''),'F',''),'G',''),'H',''),'I',''),'J',''),'K',''),'L',''),'M',''),'N',''),'O',''),'P',''),'Q',''),'R',''),'S',''),'T',''),'U',''),'V',''),'W',''),'Z',''),'Y',''),'Z',''),',',''),'(',''),')',''),'''','')) WHEN 10 THEN 1 ELSE 0 END [SELECT] FROM CRM_Customer C  WHERE (Cus_Code='" + txtCus_Code.Text.Trim() + "' OR Card_No='" + txtCus_Code.Text.Trim() + "')";
                    main.dataset = main.getDataSet(SqlStatement, "Customer");
                    dgCustomer.DataSource = main.dataset.Tables[0];
                    dgCustomer.Refresh();

                    main.getDataReader(SqlStatement);
                    if (main.Reader.Read())
                    {
                        txtCus_Name.Text = main.Reader["Cus_Name"].ToString();
                    }



                    //main.CusCode = txtCus_Code.Text.Trim().ToString();
                    //main.IndividualCusSMS();
                    //if (!string.IsNullOrEmpty(main.Remark1.Trim().ToString()))
                    //{
                    //    this.Controls.Find(main.Remark1, true)[0].Focus();
                    //}
                    //dgCustomer.DataSource = main.dataset.Tables[0];
                    //dgCustomer.Refresh();                    
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                lisTemplate.Items.Clear();
                DirectoryInfo di = new DirectoryInfo(@"..\Templete\");
                FileInfo[] rgFiles = di.GetFiles("*.txt");
                foreach (FileInfo fi in rgFiles)
                {
                    lisTemplate.Items.Add(Path.GetFileNameWithoutExtension(fi.Name));
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void lisTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FileInfo files = new FileInfo(@"..\Templete\" + lisTemplate.Text + ".txt");
                richMessage.Text = files.OpenText().ReadToEnd();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void dgCustomer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           /* if (frmCustomer.GetCustomer == null)
            {
                frmCustomer.GetCustomer = new frmCustomer();
                frmCustomer.GetCustomer.MdiParent = MdiParent;
                frmCustomer.GetCustomer.Show();
                frmCustomer.GetCustomer.CustomerRetrieve("Cus_Code = '" + dgCustomer.SelectedRows[0].Cells[1].Value.ToString() + "'");
            }
            else
            {
                frmCustomer.GetCustomer.CustomerRetrieve("Cus_Code = '" + dgCustomer.SelectedRows[0].Cells[1].Value.ToString() + "'");
                frmCustomer.GetCustomer.Focus();
            }*/
           
        }

        private void chkChildBDays_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkChildBDays.Checked == true)
                {
                    chkSpouseBDay.Checked = false;
                    birthdayDataGridViewTextBoxColumn.HeaderText = "Child Birthday";
                    cusNameDataGridViewTextBoxColumn.HeaderText = "Child Name";
                    addressDataGridViewTextBoxColumn.HeaderText = "Gender";
                    mobileDataGridViewTextBoxColumn.HeaderText = "Parent Mobile";

                    if (MessageBox.Show("Do you want to load Children Birth Days ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string SqlStatement = "SELECT EmpCode [Cus_Code], Name [Cus_Name], Sex [Address], Mobile, CONVERT(NVARCHAR(10),CD.Birthday,103) Birthday  FROM  CRM_ChildrenDetails CD INNER JOIN CRM_Customer CC ON CD.EmpCode=CC.Cus_Code WHERE SUBSTRING(CONVERT(NVARCHAR,CD.Birthday,103), 1, 5) = '" + dtBirthDate.Text.Substring(0, 5) + "'";
                        main.dataset = main.getDataSet(SqlStatement, "Customer");
                        dgCustomer.DataSource = main.dataset.Tables[0];
                        dgCustomer.Refresh();                                              
                    }
                    else
                    {
                        chkChildBDays.Checked = false;
                    }
                    
                }
                else
                {
                    birthdayDataGridViewTextBoxColumn.HeaderText = "Birthday";
                    cusNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
                    addressDataGridViewTextBoxColumn.HeaderText = "Address";
                    mobileDataGridViewTextBoxColumn.HeaderText = "Mobile";

                    string SqlStatement = "SELECT Cus_Code, Cus_Name, REPLACE(Address1 + Address2 + Address3 + Address5,',',',') AS [Address], Mobile, CONVERT(NVARCHAR(10),Birthday,103) Birthday  FROM  CRM_Customer WHERE SUBSTRING(CONVERT(NVARCHAR,Birthday,103), 1, 5) = '" + dtBirthDate.Text.Substring(0, 5) + "'";
                    main.dataset = main.getDataSet(SqlStatement, "Customer");
                    dgCustomer.DataSource = main.dataset.Tables[0];
                    dgCustomer.Refresh();

                    //chkSpouseBDay.Checked = true;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void rbPoints_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbPoints.Checked == true)
                {
                    dgCustomer.DataSource = null;
                    txtPointsFrom.Visible = true;
                    txtPointsTo.Visible = true;
                    lblPointsFrom.Visible = true;
                    lblPointsTo.Visible = true;
                    lblFrom.Visible = true;
                    btnDisplay.Visible = true;

                    txtPointsFrom.Focus();
                   
                    lblFestival.Visible = false;
                    cmbFestival.Visible = false;
                    lblBirthday.Visible = false;
                    dtBirthDate.Visible = false;
                    txtCus_Code.Visible = false;
                    txtCus_Name.Visible = false;
                    btnCusSearch.Visible = false;
                    chkChildBDays.Visible = false;
                    chkSpouseBDay.Visible = false;
                    lblCustGroup.Visible = false;
                    cmbCustGroup.Visible = false;
                    lblCustType.Visible = false;
                    cmbCustType.Visible = false;
                    dtAnniversary.Visible = false;

                    chkCustRegDate.Visible = false;
                    dtpCustRegDate.Visible = false;

                    lblPurchValue.Visible = false;

                    txtCus_Code.Text = string.Empty;
                    txtCus_Name.Text = string.Empty;
                   

                    txtPointsFrom.Text = "";
                    txtPointsTo.Text = "";

                    addressDataGridViewTextBoxColumn.HeaderText = "Address";
                    birthdayDataGridViewTextBoxColumn.HeaderText = "Points";
                    cusNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
                    mobileDataGridViewTextBoxColumn.HeaderText = "Mobile";


                    lblReligion.Visible = false;
                    cmbReligion.Visible = false;
                }
                else
                {
                    dgCustomer.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void txtPointsTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnDisplay.Focus();
                    btnDisplay.PerformClick();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }

        }

        private void txtPointsFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPointsTo.Focus();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void chkCustRegDate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCustRegDate.Checked == true)
                {
                    dtpCustRegDate.Enabled = true;
                    dtpCustRegDate.Focus();
                    dtpCustRegDate.Select();
                   
                }
                else
                {
                   /* string SqlStatement = "SELECT Cus_Code, Cus_Name, REPLACE(Address1 + Address2 + Address3 + Address5,',',',') AS [Address], Mobile, CONVERT(NVARCHAR(10),Birthday,103) Birthday  FROM  CRM_Customer WHERE LEN(REPLACE(Mobile,' ','')) <> 0 AND Inactive = " + Convert.ToByte(chkInactive.Checked) + " ORDER BY CONVERT(DATETIME,InsertDate,103)";
                    main.dataset = main.getDataSet(SqlStatement, "Customer");
                    dgCustomer.DataSource = main.dataset.Tables[0];
                    dgCustomer.Refresh();
                    
                    dtpCustRegDate.Enabled = false;*/
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                 
            }
        }

        private void dtpCustRegDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string SqlStatement = "SELECT Cus_Code, Cus_Name, REPLACE(Address1 + Address2 + Address3 + Address5,',',',') AS [Address], Mobile, CONVERT(NVARCHAR(10),Birthday,103) Birthday  FROM  CRM_Customer WHERE CONVERT(NVARCHAR,InsertDate,103) = '" + dtpCustRegDate.Text.ToString() + "'";
                    main.dataset = main.getDataSet(SqlStatement, "Customer");
                    dgCustomer.DataSource = main.dataset.Tables[0];
                    dgCustomer.Refresh();
                }               
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void chkSpouseBDay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSpouseBDay.Checked == true)
                {
                    chkChildBDays.Checked = false;
                    birthdayDataGridViewTextBoxColumn.HeaderText = "Spouse Birthday";
                    cusNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
                    addressDataGridViewTextBoxColumn.HeaderText = "Spouse Name";
                    mobileDataGridViewTextBoxColumn.HeaderText = "Customer Mobile";

                    if (MessageBox.Show("Do you want to load Spouse Birth Days?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string SqlStatement = "SELECT Cus_Code, Cus_Name, NameofSpouse [Address], Mobile, CONVERT(NVARCHAR(10),SpouseBirthDay,103) Birthday  FROM  CRM_Customer WHERE SUBSTRING(CONVERT(NVARCHAR,SpouseBirthDay,103), 1, 5) = '" + dtBirthDate.Text.Substring(0, 5) + "'";
                        main.dataset = main.getDataSet(SqlStatement, "Customer");
                        dgCustomer.DataSource = main.dataset.Tables[0];
                        dgCustomer.Refresh();
                    }
                    else 
                    {
                        chkSpouseBDay.Checked = false;
                    }
                }
                else      
                {
                    birthdayDataGridViewTextBoxColumn.HeaderText = "Birthday";
                    cusNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
                    addressDataGridViewTextBoxColumn.HeaderText = "Address";
                    mobileDataGridViewTextBoxColumn.HeaderText = "Mobile";

                    string SqlStatement = "SELECT Cus_Code, Cus_Name, REPLACE(Address1 + Address2 + Address3 + Address5,',',',') AS [Address], Mobile, CONVERT(NVARCHAR(10),Birthday,103) Birthday  FROM  CRM_Customer WHERE SUBSTRING(CONVERT(NVARCHAR,Birthday,103), 1, 5) = '" + dtBirthDate.Text.Substring(0, 5) + "'";
                    main.dataset = main.getDataSet(SqlStatement, "Customer");
                    dgCustomer.DataSource = main.dataset.Tables[0];
                    dgCustomer.Refresh();

                    //chkSpouseBDay.Checked = true;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void dtBirthDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string Query = "";
                    Query = "SELECT Cus_Code, Cus_Name, REPLACE(Address1 + Address2 + Address3 + Address5,',',',') AS [Address], CONVERT(NVARCHAR(10),Birthday,103) [Birthday], Birthday, REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(Mobile,'-',''),' ',''),'A',''),'B',''),'C',''),'D',''),'E',''),'F',''),'G',''),'H',''),'I',''),'J',''),'K',''),'L',''),'M',''),'N',''),'O',''),'P',''),'Q',''),'R',''),'S',''),'T',''),'U',''),'V',''),'W',''),'Z',''),'Y',''),'Z',''),',',''),'(',''),')',''),'''','') AS [Mobile], '" + dtBirthDate.Text.Trim() + "' AS [DateFrom], CASE LEN(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(Mobile,'-',''),' ',''),'A',''),'B',''),'C',''),'D',''),'E',''),'F',''),'G',''),'H',''),'I',''),'J',''),'K',''),'L',''),'M',''),'N',''),'O',''),'P',''),'Q',''),'R',''),'S',''),'T',''),'U',''),'V',''),'W',''),'Z',''),'Y',''),'Z',''),',',''),'(',''),')',''),'''','')) WHEN 10 THEN 1 ELSE 0 END [SELECT] FROM CRM_Customer WHERE SUBSTRING(Birthday, 1, 5) = '" + dtBirthDate.Text.Substring(0, 5) + "' AND LEN(REPLACE(Mobile,' ','')) <> 0 AND Inactive = " + Convert.ToByte(chkInactive.Checked) + " ORDER BY CONVERT(DATETIME,Birthday,103)";
                    main.dataset = main.getDataSet(Query, "Customer");
                    dgCustomer.DataSource = main.dataset.Tables[0];
                    dgCustomer.Refresh();
                }             
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void rbPurchValue_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbPurchValue.Checked == true)
                {
                    dgCustomer.DataSource = null;
                    txtPointsFrom.Visible = true;
                    txtPointsTo.Visible = true;                   
                    lblPointsTo.Visible = true;
                    lblFrom.Visible = true;
                    btnDisplay.Visible = true;

                    txtPointsFrom.Focus();

                    lblPointsFrom.Visible = false;
                    lblFestival.Visible = false;
                    cmbFestival.Visible = false;
                    lblBirthday.Visible = false;
                    dtBirthDate.Visible = false;
                    txtCus_Code.Visible = false;
                    txtCus_Name.Visible = false;
                    btnCusSearch.Visible = false;
                    chkChildBDays.Visible = false;
                    chkSpouseBDay.Visible = false;
                    lblCustGroup.Visible = false;
                    cmbCustGroup.Visible = false;
                    lblCustType.Visible = false;
                    cmbCustType.Visible = false;
                    dtAnniversary.Visible = false;

                    chkCustRegDate.Visible = false;
                    dtpCustRegDate.Visible = false;

                    lblPurchValue.Visible = true;
                 
                    lblPointsTo.Visible = true;
                    lblFrom.Visible = true;
                    btnDisplay.Visible = true;

                    txtCus_Code.Text = string.Empty;
                    txtCus_Name.Text = string.Empty;

                    cusNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
                    birthdayDataGridViewTextBoxColumn.HeaderText = "Purchase Value";
                    addressDataGridViewTextBoxColumn.HeaderText = "Mobile";
                    mobileDataGridViewTextBoxColumn.HeaderText = "Bill Date";


                    lblReligion.Visible = false;
                    cmbReligion.Visible = false;
                }
                else
                {
                    dgCustomer.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                                
            }
        }

        private void dtPurchValueTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnDisplay.Focus();
                    btnDisplay.PerformClick();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
                
            }
        }

        private void dtPurchValueFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPointsTo.Focus();
                    txtPointsTo.SelectAll();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lisTemplate.Items.Clear();
        }

      
        private void cmbCustType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string SqlStatement = "SELECT Cus_Code, Cus_Name, REPLACE(Address1 + Address2 + Address3 + Address5,',',',') AS [Address], Mobile, CONVERT(NVARCHAR(10),Birthday,103) Birthday  FROM  CRM_Customer WHERE Cus_Type='" + cmbCustType.Text.Trim() + "'";
                main.dataset = main.getDataSet(SqlStatement, "Customer");
                dgCustomer.DataSource = main.dataset.Tables[0];
                dgCustomer.Refresh();

                cmbCustGroup.Text = string.Empty;
                chkCustRegDate.Checked = false;
                dtpCustRegDate.Enabled = false;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                 
            }
        }

        private void cmbCustGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string SqlStatement = "SELECT Cus_Code, Cus_Name, REPLACE(Address1 + Address2 + Address3 + Address5,',',',') AS [Address], Mobile, CONVERT(NVARCHAR(10),Birthday,103) Birthday  FROM  CRM_Customer WHERE Group_Name='" + cmbCustGroup.Text.Trim() + "'";
                main.dataset = main.getDataSet(SqlStatement, "Customer");
                dgCustomer.DataSource = main.dataset.Tables[0];
                dgCustomer.Refresh();

                cmbCustType.Text = string.Empty;
                chkCustRegDate.Checked = false;
                dtpCustRegDate.Enabled = false;
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                 
            }

        }

        private void rbAnniversary_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbAnniversary.Checked == true)
                {
                    dgCustomer.DataSource = null;
                    txtPointsFrom.Visible = false;
                    txtPointsTo.Visible = false;
                    lblPointsTo.Visible = false;
                    lblFrom.Visible = false;
                    btnDisplay.Visible = true;
                    dtAnniversary.Visible = true;

                    txtPointsFrom.Focus();

                    lblPointsFrom.Visible = false;
                    lblFestival.Visible = false;
                    cmbFestival.Visible = false;
                    lblBirthday.Visible = true;
                    dtBirthDate.Visible = false;
                    txtCus_Code.Visible = false;
                    txtCus_Name.Visible = false;
                    btnCusSearch.Visible = false;
                    chkChildBDays.Visible = false;
                    chkSpouseBDay.Visible = false;
                    lblCustGroup.Visible = false;
                    cmbCustGroup.Visible = false;
                    lblCustType.Visible = false;
                    cmbCustType.Visible = false;

                    chkCustRegDate.Visible = false;
                    dtpCustRegDate.Visible = false;

                    lblPurchValue.Visible = false;

                    lblPointsTo.Visible = false;
                    lblFrom.Visible = false;
                   

                    txtCus_Code.Text = string.Empty;
                    txtCus_Name.Text = string.Empty;

                    lblBirthday.Text = "Anniversary";

                    cusNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
                    birthdayDataGridViewTextBoxColumn.HeaderText = "BirthDay";
                    addressDataGridViewTextBoxColumn.HeaderText = "Address";
                    mobileDataGridViewTextBoxColumn.HeaderText = "Mobile";

                    lblReligion.Visible = false;
                    cmbReligion.Visible = false;

                }
                else
                {
                    dgCustomer.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void dtAnniversary_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string Query = "";
                    Query = "SELECT Cus_Code, Cus_Name, REPLACE(Address1 + Address2 + Address3 + Address5,',',',') AS [Address], CONVERT(NVARCHAR(10),Birthday,103) [Birthday], Birthday, REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(Mobile,'-',''),' ',''),'A',''),'B',''),'C',''),'D',''),'E',''),'F',''),'G',''),'H',''),'I',''),'J',''),'K',''),'L',''),'M',''),'N',''),'O',''),'P',''),'Q',''),'R',''),'S',''),'T',''),'U',''),'V',''),'W',''),'Z',''),'Y',''),'Z',''),',',''),'(',''),')',''),'''','') AS [Mobile], '" + dtBirthDate.Text.Trim() + "' AS [DateFrom], CASE LEN(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(Mobile,'-',''),' ',''),'A',''),'B',''),'C',''),'D',''),'E',''),'F',''),'G',''),'H',''),'I',''),'J',''),'K',''),'L',''),'M',''),'N',''),'O',''),'P',''),'Q',''),'R',''),'S',''),'T',''),'U',''),'V',''),'W',''),'Z',''),'Y',''),'Z',''),',',''),'(',''),')',''),'''','')) WHEN 10 THEN 1 ELSE 0 END [SELECT] FROM CRM_Customer WHERE SUBSTRING(Anniversary, 1, 5) = '" + dtAnniversary.Text.Substring(0, 5) + "' AND LEN(REPLACE(Mobile,' ','')) <> 0 AND Inactive = " + Convert.ToByte(chkInactive.Checked) + " ORDER BY Cus_Code";
                    main.dataset = main.getDataSet(Query, "Customer");
                    dgCustomer.DataSource = main.dataset.Tables[0];
                    dgCustomer.Refresh();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void rdbVPN_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbVPN.Checked == true)
            {
                txtCOMPort.Enabled = false;
            }
            else
            {
                txtCOMPort.Enabled = true;
            }
        }

        private void rdbDongel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbReligion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbReligion.Checked == true)
                {
                    dgCustomer.DataSource = null;
                    txtPointsFrom.Visible = false;
                    txtPointsTo.Visible = false;
                    lblPointsTo.Visible = false;
                    lblFrom.Visible = false;
                    btnDisplay.Visible = true;
                    dtAnniversary.Visible = false;

                    txtPointsFrom.Focus();

                    lblPointsFrom.Visible = false;
                    lblFestival.Visible = false;
                    cmbFestival.Visible = false;
                    lblBirthday.Visible = false;
                    dtBirthDate.Visible = false;
                    txtCus_Code.Visible = false;
                    txtCus_Name.Visible = false;
                    btnCusSearch.Visible = false;
                    chkChildBDays.Visible = false;
                    chkSpouseBDay.Visible = false;
                    lblCustGroup.Visible = false;
                    cmbCustGroup.Visible = false;
                    lblCustType.Visible = false;
                    cmbCustType.Visible = false;

                    chkCustRegDate.Visible = false;
                    dtpCustRegDate.Visible = false;

                    lblPurchValue.Visible = false;

                    lblPointsTo.Visible = false;
                    lblFrom.Visible = false;


                    txtCus_Code.Text = string.Empty;
                    txtCus_Name.Text = string.Empty;

                    lblBirthday.Text = "Anniversary";

                    cusNameDataGridViewTextBoxColumn.HeaderText = "Customer Name";
                    birthdayDataGridViewTextBoxColumn.HeaderText = "BirthDay";
                    addressDataGridViewTextBoxColumn.HeaderText = "Address";
                    mobileDataGridViewTextBoxColumn.HeaderText = "Mobile";

                    lblReligion.Visible = true;
                    cmbReligion.Visible = true;

                }
                else
                {
                    dgCustomer.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }

        private void cmbReligion_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string SqlStatement = "SELECT Cus_Code, Cus_Name, REPLACE(Address1 + Address2 + Address3 + Address5,',',',') AS [Address], Mobile, CONVERT(NVARCHAR(10),Birthday,103) Birthday  FROM  CRM_Customer WHERE Religion='" + cmbReligion.Text.Trim() + "'";
                main.dataset = main.getDataSet(SqlStatement, "Customer");
                dgCustomer.DataSource = main.dataset.Tables[0];
                dgCustomer.Refresh();
                
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
        }
    }
}