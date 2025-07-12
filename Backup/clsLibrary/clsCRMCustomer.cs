using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DbConnection;
using System.Windows.Forms;
using System.IO;

namespace clsLibrary
{
    public class clsCRMCustomer : clsSMS2
    {
        private string strFestival;
        public string Festival
        {
            get { return strFestival; }
            set { strFestival = value; }
        }

        private string strRemark1;
        public string Remark1
        {
            get { return strRemark1; }
            set { strRemark1 = value; }
        }

        private string strRemark2;
        public string Remark2
        {
            get { return strRemark2; }
            set { strRemark2 = value; }
        }

        private string strRemark3;
        public string Remark3
        {
            get { return strRemark3; }
            set { strRemark3 = value; }
        }

        private string strRemark4;
        public string Remark4
        {
            get { return strRemark4; }
            set { strRemark4 = value; }
        }

        private string strRemark5;
        public string Remark5
        {
            get { return strRemark5; }
            set { strRemark5 = value; }
        }

        private string strRemark6;
        public string Remark6
        {
            get { return strRemark6; }
            set { strRemark6 = value; }
        }

        private bool blWorkshop;
        public bool Workshop
        {
            get { return blWorkshop; }
            set { blWorkshop = value; }
        }

        private bool blTransfer;
        public bool Transfer
        {
            get { return blTransfer; }
            set { blTransfer = value; }
        }

        private bool blLensRedy;
        public bool LensRedy
        {
            get { return blLensRedy; }
            set { blLensRedy = value; }
        }

        private bool blFitting;
        public bool Fitting
        {
            get { return blFitting; }
            set { blFitting = value; }
        }

        private bool blComplete;
        public bool Complete
        {
            get { return blComplete; }
            set { blComplete = value; }
        }

        private bool blReminder;
        public bool Reminder
        {
            get { return blReminder; }
            set { blReminder = value; }
        }

        private string strWorkshopName;
        public string WorkshopName
        {
            get { return strWorkshopName; }
            set { strWorkshopName = value; }
        }

        private string strTransferDate;
        public string TransferDate
        {
            get { return strTransferDate; }
            set { strTransferDate = value; }
        }

        private string strLensRedyDate;
        public string LensRedyDate
        {
            get { return strLensRedyDate; }
            set { strLensRedyDate = value; }
        }

        private string strFittingDate;
        public string FittingDate
        {
            get { return strFittingDate; }
            set { strFittingDate = value; }
        }

        private string strCompleteDate;
        public string CompleteDate
        {
            get { return strCompleteDate; }
            set { strCompleteDate = value; }
        }

        private string strReminderDate;
        public string ReminderDate
        {
            get { return strReminderDate; }
            set { strReminderDate = value; }
        }

        private decimal decNetAmount;
        public decimal NetAmount
        {
            get { return decNetAmount; }
            set { decNetAmount = value; }
        }

        private string _ChildName;
        public string ChildName
        {
            get { return _ChildName; }
            set { _ChildName = value; }
        }

        private string _ChildSex;
        public string ChildSex
        {
            get { return _ChildSex; }
            set { _ChildSex = value; }
        }

        private string _ChildBirthday;
        public string ChildBirthday
        {
            get { return _ChildBirthday; }
            set { _ChildBirthday = value; }
        }

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _SpouseName;
        public string SpouseName
        {
            get { return _SpouseName; }
            set { _SpouseName = value; }
        }

        private bool blOncePerWeek;
        public bool OncePerWeek
        {
            get { return blOncePerWeek; }
            set { blOncePerWeek = value; }
        }

        private bool blTwicePerWeek;
        public bool TwicePerWeek
        {
            get { return blTwicePerWeek; }
            set { blTwicePerWeek = value; }
        }

        private bool blCoupleofWeek;
        public bool CoupleOfWeek
        {
            get { return blCoupleofWeek; }
            set { blCoupleofWeek = value; }
        }

        private bool blOncePerMonth;
        public bool OncePerMonth
        {
            get { return blOncePerMonth; }
            set { blOncePerMonth = value; }
        }

        private bool blPrivateVehicle;
        public bool PrivateVehicle
        {
            get { return blPrivateVehicle; }
            set { blPrivateVehicle = value; }
        }

        private bool blRentVehicle;
        public bool RentVehicle
        {
            get { return blRentVehicle; }
            set { blRentVehicle = value; }
        }

        private bool blWalking;
        public bool Walking
        {
            get { return blWalking; }
            set { blWalking = value; }
        }

        private bool blRSRentVehicle;
        public bool RSRentVehicle
        {
            get { return blRSRentVehicle; }
            set { blRSRentVehicle = value; }
        }

        private string strCustCategory;

        public string CustCategory
        {
            get { return strCustCategory; }
            set { strCustCategory = value; }
        }

            private string strPoint_Rate_Gui;

        public string Point_Rate_Gui
        {
            get { return strPoint_Rate_Gui; }
            set { strPoint_Rate_Gui = value; }

        }

        private string strSqlString;
        public string SqlString
        {
            get { return strSqlString;  }
            set { strSqlString = value; }

        }
        string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        string _Religion;
        public string Religion
        {
            get { return _Religion; }
            set { _Religion = value; }
        }
        string _AllowRedeem;
        public string AllowRedeem
        {
            get { return _AllowRedeem; }
            set { _AllowRedeem = value; }
        }
        string _Parth;
        public string Parth
        {
            get { return _Parth; }
            set { _Parth = value; }
        }
        string _SheetName;
        public string SheetName
        {
            get { return _SheetName; }
            set { _SheetName = value; }
        }

        //public void CustomerUpdate()
        //{
        //    try
        //    {
        //        dbcon.connection.Open();
        //        SqlCommand command = new SqlCommand("sp_CustomerUpdate", dbcon.connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.Clear();
        //        command.Parameters.Add(new SqlParameter("@Error", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
        //        command.Parameters.Add(new SqlParameter("@Cus_Code", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CusCode));
        //        command.Parameters.Add(new SqlParameter("@Cus_Name", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CusName));
        //        command.Parameters.Add(new SqlParameter("@Address1", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Address1));
        //        command.Parameters.Add(new SqlParameter("@Address2", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Address2));
        //        command.Parameters.Add(new SqlParameter("@Address3", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Address3));
        //        command.Parameters.Add(new SqlParameter("@Address4", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Address4));
        //        command.Parameters.Add(new SqlParameter("@Address5", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Address5));
        //        command.Parameters.Add(new SqlParameter("@PhoneNo", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, PhoneNumber));
        //        command.Parameters.Add(new SqlParameter("@Fax", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Fax));
        //        command.Parameters.Add(new SqlParameter("@OfficePhone", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, OfficePhone));
        //        command.Parameters.Add(new SqlParameter("@Other", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Other));
        //        command.Parameters.Add(new SqlParameter("@Mobile", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Mobile));
        //        command.Parameters.Add(new SqlParameter("@ContactPersion", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ContactPersion));
        //        command.Parameters.Add(new SqlParameter("@E_mail", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Email));
        //        command.Parameters.Add(new SqlParameter("@Web", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Web));
        //        command.Parameters.Add(new SqlParameter("@NICNumber", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, NICNumber));
        //        command.Parameters.Add(new SqlParameter("@Birthday", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Birthday));
        //        command.Parameters.Add(new SqlParameter("@Cus_Type", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CustomerType));
        //        command.Parameters.Add(new SqlParameter("@Inactive", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Inactive));
        //        command.Parameters.Add(new SqlParameter("@Referance", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Referance));
        //        command.Parameters.Add(new SqlParameter("@InsertUser", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginUser));
        //        command.Parameters.Add(new SqlParameter("@ModUser", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginUser));
        //        command.Parameters.Add(new SqlParameter("@Age", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Age));
        //        command.Parameters.Add(new SqlParameter("@WorkShop", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Workshop));
        //        command.Parameters.Add(new SqlParameter("@Abroad", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Abroad));
        //        command.Parameters.Add(new SqlParameter("@Wesak", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Wesak));
        //        command.Parameters.Add(new SqlParameter("@NewYear", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, NewYear));
        //        command.Parameters.Add(new SqlParameter("@SendBirthday", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, SendBirthday));
        //        command.Parameters.Add(new SqlParameter("@MachineDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateTime.Now));
        //        command.ExecuteNonQuery();
        //    }
        //    finally
        //    {
        //        dbcon.connection.Close();
        //    }
        //}

        public void CustomerUpdate()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("CRM_sp_CustomerUpdate", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Error", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@Cus_Code", CusCode));
                command.Parameters.Add(new SqlParameter("@Cus_Name", CusName));
                command.Parameters.Add(new SqlParameter("@FirstName", FirstName));
                command.Parameters.Add(new SqlParameter("@SecondName", SecondName));
                command.Parameters.Add(new SqlParameter("@Address1", Address1));
                command.Parameters.Add(new SqlParameter("@Address2", Address2));
                command.Parameters.Add(new SqlParameter("@Address3", Address3));
                //command.Parameters.Add(new SqlParameter("@Address4", Address4));
                command.Parameters.Add(new SqlParameter("@Address5", Address5));
                command.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNumber));
                command.Parameters.Add(new SqlParameter("@Fax", Fax));
                command.Parameters.Add(new SqlParameter("@OfficePhone", OfficePhone));
                command.Parameters.Add(new SqlParameter("@Other", Other));
                command.Parameters.Add(new SqlParameter("@Mobile", Mobile));
                command.Parameters.Add(new SqlParameter("@NoMobile", NoMobile));

                command.Parameters.Add(new SqlParameter("@ContactPersion", ContactPersion));
                command.Parameters.Add(new SqlParameter("@E_mail", Email));
                command.Parameters.Add(new SqlParameter("@Web", Web));
                command.Parameters.Add(new SqlParameter("@NICNumber", NICNumber));
                command.Parameters.Add(new SqlParameter("@Birthday", Birthday));
                command.Parameters.Add(new SqlParameter("@Cus_Type", CustomerType));
                command.Parameters.Add(new SqlParameter("@Inactive", Inactive));
                command.Parameters.Add(new SqlParameter("@Referance", Referance));
                command.Parameters.Add(new SqlParameter("@InsertUser", LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@ModUser", LoginManager.UserName));
                command.Parameters.Add(new SqlParameter("@Age", Age));
                command.Parameters.Add(new SqlParameter("@WorkShop", Workshop));
                command.Parameters.Add(new SqlParameter("@Abroad", Abroad));
                command.Parameters.Add(new SqlParameter("@Wesak", Wesak));
                command.Parameters.Add(new SqlParameter("@NewYear", NewYear));
                command.Parameters.Add(new SqlParameter("@SendBirthday", SendBirthday));
                command.Parameters.Add(new SqlParameter("@MachineDate", DateTime.Now));
                command.Parameters.Add(new SqlParameter("@Festival", Festival));
                command.Parameters.Add(new SqlParameter("@Status", Status));
                command.Parameters.Add(new SqlParameter("@SpouseName", SpouseName));
                command.Parameters.Add(new SqlParameter("@Card_No", Card_No));
                command.Parameters.Add(new SqlParameter("@IssueDate", CardIssueDate));
                command.Parameters.Add(new SqlParameter("@Occupation", Occupation));
                command.Parameters.Add(new SqlParameter("@MaritalStatus", MaritalStatus));
                command.Parameters.Add(new SqlParameter("@SpouseBDay", SpouseBDay));
                command.Parameters.Add(new SqlParameter("@GroupCode", GroupCode));
                command.Parameters.Add(new SqlParameter("@GroupName", GroupName));
                command.Parameters.Add(new SqlParameter("@Anniversary", Anniversary));
                command.Parameters.Add(new SqlParameter("@Loca", Loca));
                command.Parameters.Add(new SqlParameter("@LocaName", LocaName));
                command.Parameters.Add(new SqlParameter("@CustCategory", strCustCategory));
                //command.Parameters.Add(new SqlParameter("@Point_Rate_Gui", Point_Rate_Gui));
                command.Parameters.Add(new SqlParameter("@RetMsg", SqlDbType.VarChar, 500, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@Focus", SqlDbType.VarChar, 100, ParameterDirection.Output, false, 0, 0, "", DataRowVersion.Default, ""));

                command.Parameters.Add(new SqlParameter("@Gender", Gender));
                command.Parameters.Add(new SqlParameter("@Religion", Religion));
                command.Parameters.Add(new SqlParameter("@AllowRedeem", AllowRedeem));

                command.Parameters.Add(new SqlParameter("@IsVat", IsVat));
                command.Parameters.Add(new SqlParameter("@VatNo", VatNo));
                command.Parameters.Add(new SqlParameter("@CreditLimit", CusCredit_Limit));
                command.Parameters.Add(new SqlParameter("@CreditPeriod", CusCredit_Period));
                command.Parameters.Add(new SqlParameter("@Discount", CusDiscount));
                command.Parameters.Add(new SqlParameter("@PayType", PayType));


                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;

                Focuseds = (string)(command.Parameters["@Focus"].Value);
                MessageBox.Show((string)(command.Parameters["@RetMsg"].Value), "Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void TourGuideCommUpdate()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("CRM_MAST_Sp_TourGuideCommission", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Cus_No", CusCode));
                command.Parameters.Add(new SqlParameter("@CommRate", CommRate));
                command.Parameters.Add(new SqlParameter("@CreateUser", LoginManager.User));
                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
            }
            finally
            {
                dbcon.connection.Close();
            }
        }


        public void ExcelDataUpdate()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("CRM_sp_Customer_ImportXL", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Err_x", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@Path", Parth));
                command.Parameters.Add(new SqlParameter("@SheetName", SheetName));
                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void ExcelDataRead()
        {
            try
            {
                dbcon.connection.Close();
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("CRM_sp_CustomerUpdateExcel", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Error", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@CustCategory", CustCategory));
                command.ExecuteNonQuery();
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void CustomerOrderProdDetails()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("sp_CustomerOrderDetails", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Error", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Doc_No));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginLocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Iid));
                command.Parameters.Add(new SqlParameter("@Cus_Code", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CusCode));
                command.Parameters.Add(new SqlParameter("@Prod_Code", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Prod_Code));
                command.Parameters.Add(new SqlParameter("@Prod_Name", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Prod_Name));
                command.Parameters.Add(new SqlParameter("@Selling_Price", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Selling_Price));
                command.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Float, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Qty));
                command.Parameters.Add(new SqlParameter("@InsertUser", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginUser));
                command.Parameters.Add(new SqlParameter("@MachineDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateTime.Now));
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataset = new DataSet(), "GRN");
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void CustomerOrder()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("sp_CustomerOrderTempSave", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Error", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Doc_No));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginLocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "CPO"));
                command.Parameters.Add(new SqlParameter("@Cus_Code", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CusCode));
                command.Parameters.Add(new SqlParameter("@Doctor", SqlDbType.NVarChar, 70, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Doctor));
                command.Parameters.Add(new SqlParameter("@R_Sph", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, RSph));
                command.Parameters.Add(new SqlParameter("@R_Cyl", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, RCyl));
                command.Parameters.Add(new SqlParameter("@R_Axis", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, RAxis));
                command.Parameters.Add(new SqlParameter("@R_V_a", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, RV_A));
                command.Parameters.Add(new SqlParameter("@R_Base", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, RBase));
                command.Parameters.Add(new SqlParameter("@R_Dec", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, RDec));
                command.Parameters.Add(new SqlParameter("@R_Ht", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, RHt));
                command.Parameters.Add(new SqlParameter("@L_Sph", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LSph));
                command.Parameters.Add(new SqlParameter("@L_Cyl", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LCyl));
                command.Parameters.Add(new SqlParameter("@L_Axis", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LAxis));
                command.Parameters.Add(new SqlParameter("@L_V_a", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LV_A));
                command.Parameters.Add(new SqlParameter("@L_Base", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LBase));
                command.Parameters.Add(new SqlParameter("@L_Dec", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LDec));
                command.Parameters.Add(new SqlParameter("@L_Ht", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LHt));
                command.Parameters.Add(new SqlParameter("@Pd_Ncd", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Pd_Ncd));
                command.Parameters.Add(new SqlParameter("@Additional", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Additional));
                command.Parameters.Add(new SqlParameter("@PrescripDate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CollectDate));
                command.Parameters.Add(new SqlParameter("@InsertUser", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginUser));
                command.Parameters.Add(new SqlParameter("@MachineDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateTime.Now));
                command.ExecuteNonQuery();
                //SqlDataAdapter da = new SqlDataAdapter();
                //da.SelectCommand = command;
                //da.Fill(dataset = new DataSet(), "GRN");
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void CustomerOrderSave()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("sp_CustomerOrderSave", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Error", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Doc_No));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginLocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "CPO"));
                command.Parameters.Add(new SqlParameter("@ChargesName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Cat_Name));
                command.Parameters.Add(new SqlParameter("@ChargesAmount ", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, InvoiveAmount));
                command.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Discount));
                command.Parameters.Add(new SqlParameter("@Advance", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Advance));
                command.Parameters.Add(new SqlParameter("@CollectDate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CollectDate));
                command.Parameters.Add(new SqlParameter("@DueDate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DueDate));
                command.Parameters.Add(new SqlParameter("@InsertUser", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginUser));
                command.Parameters.Add(new SqlParameter("@MachineDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateTime.Now));
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataset = new DataSet(), "CustomerOrderHeader");
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void CustomerOrderWorkingProgressSave()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("sp_CustomerOrderWorkingProgressSave", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Error", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Doc_No));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginLocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "CPO"));
                command.Parameters.Add(new SqlParameter("@Cus_Code", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CusCode));
                command.Parameters.Add(new SqlParameter("@Workshop", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Workshop));
                command.Parameters.Add(new SqlParameter("@WorkshopName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, WorkshopName));
                command.Parameters.Add(new SqlParameter("@Transfer", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Transfer));
                command.Parameters.Add(new SqlParameter("@TransferDate", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TransferDate));
                command.Parameters.Add(new SqlParameter("@RemarkTransfer", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Remark1));
                command.Parameters.Add(new SqlParameter("@LensRedy", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LensRedy));
                command.Parameters.Add(new SqlParameter("@LensRedyDate", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LensRedyDate));
                command.Parameters.Add(new SqlParameter("@RemarkLensRedy", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Remark2));
                command.Parameters.Add(new SqlParameter("@Fitting", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Fitting));
                command.Parameters.Add(new SqlParameter("@FittingDate", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, FittingDate));
                command.Parameters.Add(new SqlParameter("@RemarkFitting", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Remark3));
                command.Parameters.Add(new SqlParameter("@Complete", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Complete));
                command.Parameters.Add(new SqlParameter("@CompleteDate", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CompleteDate));
                command.Parameters.Add(new SqlParameter("@RemarkComplete", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Remark4));
                command.Parameters.Add(new SqlParameter("@Reminder", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Reminder));
                command.Parameters.Add(new SqlParameter("@ReminderDate", SqlDbType.NVarChar, 25, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ReminderDate));
                command.Parameters.Add(new SqlParameter("@RemarkReminder", SqlDbType.NVarChar, 150, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Remark5));
                command.Parameters.Add(new SqlParameter("@InsertUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginUser));
                command.Parameters.Add(new SqlParameter("@ModUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginUser));
                command.Parameters.Add(new SqlParameter("@MachineDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateTime.Now));
                command.ExecuteNonQuery();
                //SqlDataAdapter da = new SqlDataAdapter();
                //da.SelectCommand = command;
                //da.Fill(dataset = new DataSet(), "CustomerOrderHeader");
            }
            finally
            {
                dbcon.connection.Close();
            }



        }

        public void CustomerJobFinish()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("sp_CustomerJobFinish", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Error", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Doc_No));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginLocaCode));
                command.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, InvoiveAmount));
                command.Parameters.Add(new SqlParameter("@ColletedDate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CollectDate));
                command.Parameters.Add(new SqlParameter("@NextVisitDate", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ReminderDate));
                command.Parameters.Add(new SqlParameter("@InsertUser", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginUser));
                command.Parameters.Add(new SqlParameter("@MachineDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateTime.Now));
                command.Parameters.Add(new SqlParameter("@Discount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Discount));
                //command.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataset = new DataSet(), "Job");
            }
            finally
            {
                dbcon.connection.Close();
            }

        }

        public void InvoiceApply()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("sp_InvoiceApply", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Error", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Doc_No));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginLocaCode));
                command.Parameters.Add(new SqlParameter("@Iid", SqlDbType.NVarChar, 7, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, "INV"));
                command.Parameters.Add(new SqlParameter("@DiscountAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Discount));
                command.Parameters.Add(new SqlParameter("@ChargesName", SqlDbType.NVarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Cat_Name));
                command.Parameters.Add(new SqlParameter("@ChargesAmount ", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, InvoiveAmount));
                command.Parameters.Add(new SqlParameter("@Reference", SqlDbType.NVarChar, 200, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Referance));
                command.Parameters.Add(new SqlParameter("@NetAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, NetAmount));
                command.Parameters.Add(new SqlParameter("@InsertUser", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginUser));
                command.Parameters.Add(new SqlParameter("@MachineDate", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, DateTime.Now));
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataset = new DataSet(), "CustomerOrderHeader");
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void TransactionCancel()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("sp_TransactionCancel", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Error", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, 0));
                command.Parameters.Add(new SqlParameter("@Msg", SqlDbType.NVarChar, 1000, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@Doc_No", SqlDbType.NVarChar, 15, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Doc_No));
                command.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginLocaCode));
                command.Parameters.Add(new SqlParameter("@InsertUser", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginUser));
                command.ExecuteNonQuery();
                //SqlDataAdapter da = new SqlDataAdapter();
                //da.SelectCommand = command;
                //da.Fill(dataset = new DataSet(), "No");

                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                string s = (string)(command.Parameters["@Msg"].Value);
                System.Windows.Forms.MessageBox.Show(s.ToString(), "Transaction Cancel", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public SqlConnection connDataset()
        {
            return dbcon.connection;
        }

        public void IndividualCusSMS()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand command = new SqlCommand("CRM_sp_SMSIndividualCustomer", dbcon.connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@msg", SqlDbType.NVarChar, 1000, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@Focus", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, false, 0, 0, "", DataRowVersion.Default, ""));
                command.Parameters.Add(new SqlParameter("@Cus_Code", SqlDbType.NVarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CusCode));
                strRemark1 = "";
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dataset = new DataSet(), "Customer");
                command.UpdatedRowSource = UpdateRowSource.OutputParameters;
                string s = (string)(command.Parameters["@msg"].Value);
                strRemark1 = (string)(command.Parameters["@Focus"].Value);
                if (!string.IsNullOrEmpty(s.ToString()))
                {
                    System.Windows.Forms.MessageBox.Show(s.ToString(), "SMS", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void ChildrenUpdate()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = dbcon.connection;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "crm_sp_ChildrenUpdate";
                comm.Parameters.Clear();
                comm.Parameters.Add(new SqlParameter("@EmpCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CusCode));
                comm.Parameters.Add(new SqlParameter("@Loca", SqlDbType.NVarChar, 10, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.LocaCode));
                comm.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ChildName));
                comm.Parameters.Add(new SqlParameter("@Sex", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ChildSex));
                comm.Parameters.Add(new SqlParameter("@Birthday", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ChildBirthday));
                comm.Parameters.Add(new SqlParameter("@CreateUser", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(dataset = new DataSet(), "dsChildrenDetails");
            }
            catch (Exception ex)
            {
                ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        public void ChildDelete()
        {
            try
            {
                dbcon.connection.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = dbcon.connection;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "CRM_sp_ChildrenDelete";
                comm.Parameters.Clear();
                comm.Parameters.Add(new SqlParameter("@EmpCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CusCode));
                comm.Parameters.Add(new SqlParameter("@ChildName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ChildName));
                comm.Parameters.Add(new SqlParameter("@ChildSex", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, ChildSex));
                SqlDataAdapter sda = new SqlDataAdapter(comm);
                sda.Fill(dataset = new DataSet(), "dsChildrenDetails");
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            finally
            {
                dbcon.connection.Close();
            }

        }

        public void SaveAdditionalInfo()
        {
            try
            {
                dbcon.connection.Close();
                dbcon.connection.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = dbcon.connection;
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "CRM_sp_AdditionalInfoSave";
                comm.Parameters.Clear();
                comm.Parameters.Add(new SqlParameter("@CustCode", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CusCode));
                comm.Parameters.Add(new SqlParameter("@CustName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CusName));
                comm.Parameters.Add(new SqlParameter("@OncePerWeek", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, OncePerWeek));
                comm.Parameters.Add(new SqlParameter("@TwicePerWeek", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, TwicePerWeek));
                comm.Parameters.Add(new SqlParameter("@OncePerMonth", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, OncePerMonth));
                comm.Parameters.Add(new SqlParameter("@CoupleOfWeek", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, CoupleOfWeek));
                comm.Parameters.Add(new SqlParameter("@PrivateVehicle", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, PrivateVehicle));
                comm.Parameters.Add(new SqlParameter("@RentVehicle", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, RentVehicle));
                comm.Parameters.Add(new SqlParameter("@Walking", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, Walking));
                comm.Parameters.Add(new SqlParameter("@RSRentVehicle", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, RSRentVehicle));
                comm.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, LoginManager.UserName));
                
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(dataset = new DataSet(), "dsAdditionalInfo");
            }
            catch (Exception ex)
            {
                ErrMessage(ex.Message.ToString(), ex.StackTrace.ToString());
            }
            finally
            {
                dbcon.connection.Close();
            }
        }

        







    }
}
