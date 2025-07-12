using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using clsLibrary;

namespace Inventory
{
    public partial class frmAdditionalInfomation : Form
    {
        public frmAdditionalInfomation()
        {
            InitializeComponent();
        }

        private static frmAdditionalInfomation AdditionalInfo;
        public static frmAdditionalInfomation GetAdditionalInfo
        {
            get { return AdditionalInfo; }
            set { AdditionalInfo = value; }
        }

        clsCRMCustomer objAddInfo = new clsCRMCustomer();

        private void frmAdditionalInfomation_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdditionalInfo = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                objAddInfo.CusCode = txtAddCustCode.Text.Trim();
                objAddInfo.CusName = txtAddCustName.Text.Trim();
                objAddInfo.OncePerWeek = Convert.ToBoolean(rbA01.Checked);
                objAddInfo.TwicePerWeek = Convert.ToBoolean(rbA02.Checked);
                objAddInfo.OncePerMonth = Convert.ToBoolean(rbA04.Checked);
                objAddInfo.CoupleOfWeek = Convert.ToBoolean(rbA03.Checked);
                objAddInfo.PrivateVehicle = Convert.ToBoolean(chkA05.Checked);
                objAddInfo.RentVehicle = Convert.ToBoolean(chkA06.Checked);
                objAddInfo.Walking = Convert.ToBoolean(chkA07.Checked);
                objAddInfo.RSRentVehicle = Convert.ToBoolean(chkA08.Checked);
                objAddInfo.InsertUser = LoginManager.UserName;
                objAddInfo.SaveAdditionalInfo();
                this.Close(); 

            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                
            }
        }

        private void frmAdditionalInfomation_Load(object sender, EventArgs e)
        {
            try
            {
                string SqlStatement = "SELECT Company_Name FROM CRM_CardInfo";
                objAddInfo.getDataReader(SqlStatement);
                if (objAddInfo.Reader.Read())
                {
                    label4.Text = objAddInfo.Reader["Company_Name"].ToString();
                    label5.Text = objAddInfo.Reader["Company_Name"].ToString();
                    label6.Text = objAddInfo.Reader["Company_Name"].ToString();                   
                }               
                //Question Number One with Answers
                SqlStatement = "SELECT AQ.Question_No, Question, Answer_No, Answer FROM CRM_AdditionalQuestions AQ INNER JOIN CRM_AdditionalAnswers AA ON AQ.Question_No=AA.Question_No WHERE AQ.Question_No='Q01' AND AA.Answer_No IN ('A01','A02','A03','A04')";
                objAddInfo.getDataReader(SqlStatement);
                while (objAddInfo.Reader.Read())
                {
                    //Question
                    string Q_No = objAddInfo.Reader["Question_No"].ToString();
                    if (Q_No == "Q01")
                    {
                        lblQ01.Text = objAddInfo.Reader["Question"].ToString();
                    }
                    //Answers
                    string A_No = objAddInfo.Reader["Answer_No"].ToString();
                    if (A_No == "A01")
                    {
                        rbA01.Text = objAddInfo.Reader["Answer"].ToString(); 
                    }
                    if (A_No == "A02")
                    {
                        rbA02.Text = objAddInfo.Reader["Answer"].ToString();
                    }
                    if (A_No == "A03")
                    {
                        rbA03.Text = objAddInfo.Reader["Answer"].ToString();
                    }
                    if (A_No == "A04")
                    {
                        rbA04.Text = objAddInfo.Reader["Answer"].ToString();
                    }                                                                    
                }
                //Question Number Two with Answers
                SqlStatement = "SELECT AQ.Question_No, Question, Answer_No, Answer FROM CRM_AdditionalQuestions AQ INNER JOIN CRM_AdditionalAnswers AA ON AQ.Question_No=AA.Question_No WHERE AQ.Question_No='Q02' AND AA.Answer_No IN ('A05','A06','A07','A08')";
                objAddInfo.getDataReader(SqlStatement);
                while (objAddInfo.Reader.Read())
                {
                    //Question
                    string Q_No = objAddInfo.Reader["Question_No"].ToString();
                    if (Q_No == "Q02")
                    {
                        lblQ02.Text = objAddInfo.Reader["Question"].ToString();
                    }
                    //Answers
                    string A_No = objAddInfo.Reader["Answer_No"].ToString();
                    if (A_No == "A05")
                    {
                        chkA05.Text = objAddInfo.Reader["Answer"].ToString();
                    }
                    if (A_No == "A06")
                    {
                        chkA06.Text = objAddInfo.Reader["Answer"].ToString();
                    }
                    if (A_No == "A07")
                    {
                        chkA07.Text = objAddInfo.Reader["Answer"].ToString();
                    }
                    if (A_No == "A08")
                    {
                        chkA08.Text = objAddInfo.Reader["Answer"].ToString();
                    }                    
                }
              
                SqlStatement = "SELECT Once_PerWeek, Twice_PerWeek, Once_PerCoupleofWeek, Once_PerMonth, By_PrivateVehicle, By_RentVehicle, By_RS_RentVehicle, By_Walking  FROM CRM_AdditionalInformation  WHERE Cust_Code='" + txtAddCustCode.Text.Trim() + "'";
                objAddInfo.getDataReader(SqlStatement);
                if (objAddInfo.Reader.Read())
                {                    
                    rbA01.Checked = Convert.ToBoolean(objAddInfo.Reader["Once_PerWeek"]);
                    rbA02.Checked = Convert.ToBoolean(objAddInfo.Reader["Twice_PerWeek"]);
                    rbA03.Checked = Convert.ToBoolean(objAddInfo.Reader["Once_PerCoupleofWeek"]);
                    rbA04.Checked = Convert.ToBoolean(objAddInfo.Reader["Once_PerMonth"]);

                    chkA05.Checked = Convert.ToBoolean(objAddInfo.Reader["By_PrivateVehicle"]);
                    chkA06.Checked = Convert.ToBoolean(objAddInfo.Reader["By_RentVehicle"]);
                    chkA08.Checked = Convert.ToBoolean(objAddInfo.Reader["By_RS_RentVehicle"]);
                    chkA07.Checked = Convert.ToBoolean(objAddInfo.Reader["By_Walking"]);                  
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());                                
            }

        }

    }
   
	

    
	
}