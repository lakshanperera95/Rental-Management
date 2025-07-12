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
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        private int Err;

        private static frmCategory category;
        private frmSearch search = new frmSearch();
        private clsCategory ObjCategory = new clsCategory();
        private string strSqlString;
        private string strDatasetName;
        string searchW = "";

        public static frmCategory GetCategory {
            get 
            {
                return category;
            }

            set 
            {
                category = value;
            }
        }

        //Department

        void filldata() {
            try
            {
                if (search.Descript != null)
                {
                    txtCategory.Text = search.Code.Trim();
                    txtCatDescript.Text = search.Descript.Trim();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCategory 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDepSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();

                }

                searchW = (txtDepartment.Text == string.Empty && txtDepDescript.Text != string.Empty) ? " WHERE Dept_Name LIKE '%" + txtDepDescript.Text.Trim() + "%'" : (txtDepartment.Text != string.Empty && txtDepDescript.Text == string.Empty) ? " WHERE Dept_Code LIKE '%" + txtDepartment.Text.Trim() + "%'" : "";
                strSqlString = "SELECT Dept_Code AS Code, Dept_Name AS Department FROM Department " + searchW + " ORDER BY Code";
                strDatasetName = "dsDepartment";
                ObjCategory.SqlString = strSqlString;
                ObjCategory.DatasetName = strDatasetName;

                ObjCategory.RetrieveFields_Department();
                
                search.dgSearch.DataSource = ObjCategory.GetDataset1.Tables[strDatasetName];
                search.prop_Focus = txtDepartment;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCategory 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

       // Category

        private void btnCatSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();
                }

                if (txtDepartment.Text == string.Empty)
                {
                    MessageBox.Show("Please Select the Department", "Category", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnDepSearch.Focus();
                }

                else
                {
                    searchW = (txtCategory.Text == string.Empty && txtCatDescript.Text != string.Empty) ? " WHERE Dept_Code = '" + txtDepartment.Text.Trim() + "' AND Cat_Name LIKE '%" + txtCatDescript.Text.Trim() + "%'" : (txtCategory.Text != string.Empty && txtCatDescript.Text == string.Empty) ? " WHERE Cat_Code LIKE '%" + txtCategory.Text.Trim() + "%'" : " WHERE Dept_Code = '" + txtDepartment.Text.Trim() + "'";
                    strSqlString = "SELECT Cat_Code AS [Category Code], Cat_Name AS [Category Name] FROM Category " + searchW + " ORDER BY [Category Code]";
                    strDatasetName = "dsCategory";

                    ObjCategory.SqlString = strSqlString;
                    ObjCategory.DatasetName = strDatasetName;
                    ObjCategory.RetrieveFields_Category();
                    search.dgSearch.DataSource = ObjCategory.GetDataset1.Tables[strDatasetName];
                    search.prop_Focus = txtCategory;
                    search.Cont_Descript = txtCatDescript;
                    search.Show();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCategory 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                if ((txtCategory.Text == string.Empty) || (txtCatDescript.Text == string.Empty))
                {
                    MessageBox.Show("Category Detail Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Err++;
                }

                if ((txtDepartment.Text == string.Empty) || (txtCategory.Text == string.Empty))
                {
                    MessageBox.Show("Department Detail Not Found", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Err++;
                }

                if (txtDepartment.Text.Contains("'") || txtDepDescript.Text.Contains("'") || txtCategory.Text.Contains("'") || txtCatDescript.Text.Contains("'"))
                {
                    Err++;
                    MessageBox.Show("Invalid characters in Textfeilds Please check the characters entered.", "Invalid character ['] found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                ObjCategory.SqlString = "select * from category Where Dept_code <> '" + txtDepartment.Text.Trim() + "' and cat_code = '" + txtCategory.Text.Trim() + "'";
                ObjCategory.ReadCategoryDetails();
                if (ObjCategory.RecordFound == true)
                {
                    MessageBox.Show("Category Code Found on Different Department. Please veryfy Category Code.", "Category Code Duplicating", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCategory.Focus();
                    return;
                }

                if (Err == 0)
                {
                    ObjCategory.ErrorCode = 0;
                    ObjCategory.Department = txtDepartment.Text.Trim().ToUpper();
                    ObjCategory.Category = txtCategory.Text.Trim().ToUpper();
                    ObjCategory.CatDescript = txtCatDescript.Text.Trim().ToUpper();

                    //clear all the properties used in search form
                    search.Code = string.Empty;
                    search.Descript = string.Empty;
                    search.prop_Focus = null;
                    search.prop_Name = string.Empty;

                    ObjCategory.UpdateData();

                    clsClear.getclear().clearfeilds(category, txtDepartment);
                    clsClear.getclear().clearfeilds(grpMain, txtDepartment);

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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCategory 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategory.Text != string.Empty)
                {
                    if (MessageBox.Show("Do you really want to delete the record ?  " + txtCategory.Text + "", " Department Details",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                          == DialogResult.Yes)
                    {
                        ObjCategory.Category = txtCategory.Text.Trim().ToUpper();
                        ObjCategory.ReadCategoryRelatedDetails();
                        if (ObjCategory.RecordFound == true)
                        {
                            MessageBox.Show("Product Found Under This Catgory. Can't Delete Catgory.", "Category Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        
                        else
                        {
                            ObjCategory.DeleteData(txtDepartment.Text, txtCategory.Text);

                            clsClear.getclear().clearfeilds(category, txtDepartment);
                            clsClear.getclear().clearfeilds(grpMain, txtDepartment);
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCategory 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                clsClear.getclear().clearfeilds(category, txtDepartment);
                clsClear.getclear().clearfeilds(grpMain, txtDepartment);
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCategory 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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
                this.Close();
                this.Dispose();
                category = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCategory 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                category = null;
            }
            catch (Exception ex)
            {
                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCategory 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtDepartment.Text.Trim() != string.Empty)
                {
                    ObjCategory.SqlString = "select * from Department Where Dept_code = '" + txtDepartment.Text.Trim() + "'";
                    ObjCategory.ReadDepartmentDetails();
                    if (ObjCategory.RecordFound == true)
                    {
                        txtDepartment.Text = ObjCategory.Department;
                        txtDepDescript.Text = ObjCategory.DeptName;
                    }
                    txtDepDescript.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCategory 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtCategory.Text.Trim() != string.Empty)
                {
                    ObjCategory.SqlString = "select * from category Where Dept_code = '" + txtDepartment.Text.Trim() + "' and cat_code = '" + txtCategory.Text.Trim() + "'";
                    ObjCategory.ReadCategoryDetails();
                    if (ObjCategory.RecordFound == true)
                    {
                        txtCategory.Text = ObjCategory.Category;
                        txtCatDescript.Text = ObjCategory.CatDescript;
                    }
                    txtCatDescript.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCategory 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtDepDescript_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCategory.Focus();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCategory 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void txtCatDescript_KeyDown(object sender, KeyEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCategory 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control == true)
                {
                    if (e.KeyCode == Keys.S)
                    {
                        this.btnSave.PerformClick();
                    }
                    else
                    {
                        if (e.KeyCode == Keys.D)
                        {
                            this.btnDelete.PerformClick();
                        }
                        else
                        {
                            if (e.KeyCode == Keys.L)
                            {
                                this.btnClear.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmCategory 013.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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