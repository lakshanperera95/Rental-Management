using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using clsLibrary;
using DbConnection;
using System.IO;
using System.Data.SqlClient; 
using Inventory.Properties;

namespace Inventory
{
    public partial class frmUserRole : Form
    {
        public frmUserRole()
        {
            InitializeComponent();
        }

        private static frmUserRole objUserRole;

        public static frmUserRole AobjUserRole
        {
            get { return objUserRole; }
            set { objUserRole = value; }
        }

        bool FormLoaded = false;

        public string  UserRole { get; set; }
        private void frmUserRole_Load(object sender, EventArgs e)
        {
            //dbcon objclsUserRole = new dbcon();

            try
            {
                string sqlStatement = "SELECT UserRole_Id,UserRole_Description FROM tbUserRoleMaster ORDER BY UserRole_Id";
                DataSet d1 = dbcon.getDataset(sqlStatement, "dsUserRole");

                cmbUserRole.DataSource = d1.Tables[0];
                cmbUserRole.DisplayMember =  "UserRole_Description";
                cmbUserRole.ValueMember   =  "UserRole_Id";



                //sqlStatement = "SELECT MenuID, MenuName, ParentMenuID FROM tb_MenuList where flag=1 ORDER BY MenuID";
                //DataSet d2 = dbcon.getDataset(sqlStatement, "dsMenuList");

                //foreach (DataRow dr in d2.Tables[0].Rows)
                //{

                //    TreeNode[] t = trvMenuList.Nodes.Find(dr["ParentMenuID"].ToString(), true);
                //    if (t.Length > 0)
                //    {
                //        t[0].Nodes.Add(dr["MenuID"].ToString(), dr["MenuName"].ToString());
                //    }
                //    else
                //    {
                //        trvMenuList.Nodes.Add(dr["MenuID"].ToString(), dr["MenuName"].ToString());
                //    }

                //}

                sqlStatement = "SELECT MenuID, MenuName, ParentMenuID FROM tb_MenuList where flag=1 ORDER BY Id_no Asc";
                DataSet d2 = dbcon.getDataset(sqlStatement, "dsMenuList");

                foreach (DataRow dr in d2.Tables[0].Rows)
                {
                    string PrMnId = dr["ParentMenuID"].ToString();
                    string MnId = dr["MenuID"].ToString();
                    string MnNm = dr["MenuName"].ToString();

                    TreeNode[] t = trvMenuList.Nodes.Find(PrMnId, true);
                    if (t.Length > 0)
                    {
                        t[0].Nodes.Add(MnId, MnNm);
                    }
                    else
                    {
                        trvMenuList.Nodes.Add(MnId, MnNm);
                    }
                }

                rdbEditExisting.Checked = true;
                rdbEditExisting_CheckedChanged(sender, e);
                cmbUserRole.Text = UserRole;
                FormLoaded = true;
                cmbUserRole_SelectedIndexChanged(sender, e);

                if (Settings.Default.AdvanceUserSet==true)
                {
                    grpAdvance.Visible = true;
                    grpAdvance.Enabled = true;

                }
                else
                {
                    this.Width = this.Width - grpAdvance.Width;
                    grpAdvance.Visible = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmTransferGoodNote 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmUserRole_FormClosed(object sender, FormClosedEventArgs e)
        {
            objUserRole = null;
        }

        private void rdbCreateNew_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCreateNew.Checked)
            {
                cmbUserRole.Visible = false;
                txtUserRole.Visible = true;
            }
        }

        private void rdbEditExisting_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEditExisting.Checked)
            {
                cmbUserRole.Visible = true;
                txtUserRole.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          //  clsDBTrans objclsUserRole = new clsDBTrans();
            try
            {
                if (MessageBox.Show("Do you want to save this record?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    

                    if (rdbEditExisting.Checked)
                    {
                        saveTreeNode(trvMenuList.Nodes, Convert.ToInt32(cmbUserRole.SelectedValue));
                        SaveAdvanceSettings(Convert.ToInt32(cmbUserRole.SelectedValue));
                    }
                    else
                    {
                        string sqlStatement = "SELECT * FROM tbUserRoleMaster WHERE UserRole_Description='" + txtUserRole.Text.Trim() + "'";
                        SqlDataReader r1= dbcon.GetReader(sqlStatement);
                        if (r1.Read())
                        {
                            MessageBox.Show("User role already exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtUserRole.Focus();
                            return;
                        }

                        int UserRoleId = 0;
                        sqlStatement = "EXEC sp_UserRole_Save @UserRole='" + txtUserRole.Text.Trim() + "', @CreateUser='" + LoginManager.UserName.Trim() + "'";
                        SqlDataReader r2=  dbcon.GetReader(sqlStatement);
                        if (r2.Read())
                        {
                            UserRoleId = Convert.ToInt32(r2["UserRoleId"].ToString());
                        }
                        r1.Close();
                        r2.Close();
                        saveTreeNode(trvMenuList.Nodes, UserRoleId);

                        SaveAdvanceSettings(UserRoleId);
                    }

                    dbcon.CloseReader();
                    MessageBox.Show(this, "Save complete !", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    frmUserProfile.GetUserProfile.txtUserName_KeyDown(sender, new KeyEventArgs(Keys.Enter));
                }
              
                
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }
        public void SaveAdvanceSettings(int userRole)
        {
            try
            {
                if (grpAdvance.Visible == true)
                {
                    string sqlStatement = "EXEC [dbo].[sp_UserRoleSettings_Save]  @UserRoleId = "+userRole+",@DiscPerc = '"+txtAdvancePercentage.Value.ToString()+"',@CreateUser = '"+LoginManager.UserName+"',@AllowDisc="+chkAllowDiscs.Checked+ ",@GRNAPP = "+chkGRNApply.Checked+ ",@POAPP = " + chkPOApply.Checked + ",@SRNAPP = " + chkSRNApply.Checked + ",@TOGAPP = " + chkTOGApply.Checked + ",@OPBAPP = " + chkCrDeOpBalPassword.Checked + ",@PRDAPP = " + chkProdSave.Checked + ",@BATCAPP = " + chkBatchPriceUpdate.Checked + ",@BillRep="+chkBillRePrint.Checked+"    ";
                    dbcon.GetReader(sqlStatement);
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex);
            }
        }

        private void saveTreeNode(TreeNodeCollection nodeCollection, int UserRoleId)
        {
          //  clsDBTrans objclsUserRole = new clsDBTrans();

            foreach (TreeNode node in nodeCollection)
            {
                string MenuId = node.Name;
                string MenuName = node.Text;
                string ParentMenuId = "0";

                if (node.Parent != null)
                {
                    ParentMenuId = node.Parent.Name;
                }

                bool Allow = node.Checked;

                string sqlStatement = "EXEC sp_UserRoleDetails_Save @UserRoleId=" + UserRoleId.ToString() + ", @MenuId='" + MenuId + "', @MenuName='" + MenuName + "', @ParentMenuId='" + ParentMenuId + "', @Allow=" + Allow + "";
                dbcon.GetReader(sqlStatement);


                if (node.Nodes.Count > 0)
                {
                    saveTreeNode(node.Nodes, UserRoleId);
                }

              
            }
           //dbcon.CloseReader();
        }

        private void cmbUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormLoaded)
            {
               // clsDBTrans objclsUserRole = new clsDBTrans();
                try
                {
                    string sqlStatement = "SELECT MenuId,Allow FROM tb_UserRoleDetails WHERE UserRoleId=" + cmbUserRole.SelectedValue.ToString();
                   SqlDataReader r3= dbcon.GetReader(sqlStatement);

                    while (r3.Read())
                    {
                        TreeNode[] tn = trvMenuList.Nodes.Find(r3["MenuId"].ToString(), true);
                        if (tn.Length > 0)
                        {
                            tn[0].Checked = Convert.ToBoolean(r3["Allow"].ToString());
                        }
                    }

                    if(Settings.Default.AdvanceUserSet==true)
                    {
                        sqlStatement = "SELECT AllowDisc,DiscPer,GRNAPP,POAPP,SRNAPP,TOGAPP,OPBAPP,PRDAPP,BATCAPP,BillReprint FROM dbo.tb_UserRoleSettings WHERE UserRoleID=" + cmbUserRole.SelectedValue.ToString()+"  ";
                        

                       if(dbcon.getDataset(sqlStatement, "DS").Tables[0].Rows.Count>0)
                        {
                            chkAllowDiscs.Checked = Convert.ToBoolean(dbcon.getDataset(sqlStatement, "DS").Tables[0].Rows[0][0]);
                            txtAdvancePercentage.Value = Convert.ToInt32(dbcon.getDataset(sqlStatement, "DS").Tables[0].Rows[0][1]);
                            chkGRNApply.Checked = Convert.ToBoolean(dbcon.getDataset(sqlStatement, "DS").Tables[0].Rows[0][2]);
                            chkPOApply.Checked = Convert.ToBoolean(dbcon.getDataset(sqlStatement, "DS").Tables[0].Rows[0][3]);
                            chkSRNApply.Checked = Convert.ToBoolean(dbcon.getDataset(sqlStatement, "DS").Tables[0].Rows[0][4]);
                            chkTOGApply.Checked = Convert.ToBoolean(dbcon.getDataset(sqlStatement, "DS").Tables[0].Rows[0][5]);
                            chkCrDeOpBalPassword.Checked = Convert.ToBoolean(dbcon.getDataset(sqlStatement, "DS").Tables[0].Rows[0][6]);
                            chkProdSave.Checked = Convert.ToBoolean(dbcon.getDataset(sqlStatement, "DS").Tables[0].Rows[0][7]);
                            chkBatchPriceUpdate.Checked = Convert.ToBoolean(dbcon.getDataset(sqlStatement, "DS").Tables[0].Rows[0][8]);
                            chkBillRePrint.Checked = Convert.ToBoolean(dbcon.getDataset(sqlStatement, "DS").Tables[0].Rows[0][9]);
                        }
                    }

                


                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    
                 //  dbcon.CloseConnection();
                  
                }
            }
        }

        private void trvMenuList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                CheckTreeViewNode(e.Node, e.Node.Checked);
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.ToString(), ex.StackTrace.ToString());
            }
        }

        private void CheckTreeViewNode(TreeNode node, Boolean isChecked)
        {
            try
            {
                foreach (TreeNode item in node.Nodes)
                {
                    item.Checked = isChecked;

                    if (item.Nodes.Count > 0)
                    {
                        this.CheckTreeViewNode(item, isChecked);
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.ToString(), ex.StackTrace.ToString());
            }
        }

        private void frmUserRole_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frmUserProfile.GetUserProfile.txtUserName_KeyDown(sender, new KeyEventArgs(Keys.Enter));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmUserProfile.GetUserProfile.txtUserName_KeyDown(sender, new KeyEventArgs(Keys.Enter));

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chkAllowDiscs_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAllowDiscs.Checked==false)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                txtAdvancePercentage.Value = 1;
            }
        }
    }
}