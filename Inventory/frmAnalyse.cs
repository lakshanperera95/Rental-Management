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
    public partial class frmAnalyse : Form
    {
        public int intRepOption;    //1000   For Sales Analyse Report   1100    Purchasing analyse Report

        clsAnalyse objAnalyse = new clsAnalyse();
        private string   strTempDocNo;
        public frmAnalyse()
        {
            InitializeComponent();
        }

        private static frmAnalyse Analyse;

        private frmSearch search = new frmSearch();

        public static frmAnalyse GetAnalyse
        {
            get { return Analyse; }
            set { Analyse = value; }
        }

        private void frmAnalyse_Load(object sender, EventArgs e)
        {
            try
            {
                objAnalyse.SqlStatement = "SELECT Analyse_Temp FROM DocumentNoDetails WHERE Loca = ";
                objAnalyse.GetTempDocumentNo();
                strTempDocNo = objAnalyse.TempDocNo;
                dataGridViewCollection.DataSource = objAnalyse.TempCollection.Tables["Collection"];
                dataGridViewCollection.Refresh();
                dataGridViewSelected.DataSource = objAnalyse.TempSelected.Tables["Selected"];
                dataGridViewSelected.Refresh();

                if (intRepOption == 1300)
                {
                    lblSecondDateFrom.Visible = true;
                    lblSecondDateTo.Visible = true;
                    dtpSecondDateFrom.Visible = true;
                    dtpSecondDateTo.Visible = true;
                }
                else
                {
                    lblSecondDateFrom.Visible = false;
                    lblSecondDateTo.Visible = false;
                    dtpSecondDateFrom.Visible = false;
                    dtpSecondDateTo.Visible = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 001. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmAnalyse_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Analyse = null;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 002. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmAnalyse_FormClosing(object sender, FormClosingEventArgs e)
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 003. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.Dispose();
                Analyse = null;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 004. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void radioButtonProduct_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonProduct.Checked == true)
                {
                    MainClass.mdi.Cursor = Cursors.WaitCursor;
                    objAnalyse.RetriveProductDetails();
                    dataGridViewCollection.DataSource = objAnalyse.TempCollection.Tables["Collection"];
                    dataGridViewCollection.Refresh();
                    dataGridViewSelected.DataSource = objAnalyse.TempSelected.Tables["Selected"];
                    dataGridViewSelected.Refresh();
                    btnSelectCode.Enabled = false;
                    btnSelectAllCode.Enabled = true;
                    MainClass.getmdi().Cursor = Cursors.Default;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 005. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void radioButtonDepartment_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonDepartment.Checked == true)
                {
                    MainClass.mdi.Cursor = Cursors.WaitCursor;
                    objAnalyse.RetriveDepartmentDetails();
                    dataGridViewCollection.DataSource = objAnalyse.TempCollection.Tables["Collection"];
                    dataGridViewCollection.Refresh();
                    dataGridViewSelected.DataSource = objAnalyse.TempSelected.Tables["Selected"];
                    dataGridViewSelected.Refresh();
                    btnSelectCode.Enabled = false;
                    btnSelectAllCode.Enabled = true;
                    MainClass.getmdi().Cursor = Cursors.Default;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 006. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void radioButtonCategory_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonCategory.Checked == true)
                {
                    MainClass.mdi.Cursor = Cursors.WaitCursor;
                    objAnalyse.RetriveCategoryDetails();
                    dataGridViewCollection.DataSource = objAnalyse.TempCollection.Tables["Collection"];
                    dataGridViewCollection.Refresh();
                    dataGridViewSelected.DataSource = objAnalyse.TempSelected.Tables["Selected"];
                    dataGridViewSelected.Refresh();
                    btnSelectCode.Enabled = false;
                    btnSelectAllCode.Enabled = true;
                    MainClass.getmdi().Cursor = Cursors.Default;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 007. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void radioButtonSupplier_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonSupplier.Checked == true)
                {
                    MainClass.mdi.Cursor = Cursors.WaitCursor;
                    objAnalyse.RetriveSupplierDetails();
                    dataGridViewCollection.DataSource = objAnalyse.TempCollection.Tables["Collection"];
                    dataGridViewCollection.Refresh();
                    dataGridViewSelected.DataSource = objAnalyse.TempSelected.Tables["Selected"];
                    dataGridViewSelected.Refresh();
                    btnSelectCode.Enabled = false;
                    btnSelectAllCode.Enabled = true;
                    MainClass.getmdi().Cursor = Cursors.Default;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 008. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewCollection_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                if (dataGridViewCollection.SelectedRows.Count <= 0 || dataGridViewCollection.SelectedRows[0].Cells[0].ToString() == "")
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    objAnalyse.Code = dataGridViewCollection.SelectedRows[0].Cells[0].Value.ToString();
                    objAnalyse.AddCodeToSelected();
                    //dataGridViewCollection.DataSource = objAnalyse.TempCollection.Tables["Collection"];
                    //dataGridViewCollection.Refresh();
                    dataGridViewSelected.DataSource = objAnalyse.TempSelected.Tables["Selected"];
                    dataGridViewSelected.Refresh();
                    btnSelectCode.Enabled = false;
                    btnRemoveCode.Enabled = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 009. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewCollection_Click(object sender, EventArgs e)
        {
            try
            {
                btnSelectCode.Enabled = true;
                btnSelectAllCode.Enabled = true;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 010. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSelectCode_Click(object sender, EventArgs e)
        {
            try
            {
                objAnalyse.Code = dataGridViewCollection.SelectedRows[0].Cells[0].Value.ToString();
                objAnalyse.AddCodeToSelected();
                dataGridViewCollection.DataSource = objAnalyse.TempCollection.Tables["Collection"];
                dataGridViewCollection.Refresh();
                dataGridViewSelected.DataSource = objAnalyse.TempSelected.Tables["Selected"];
                dataGridViewSelected.Refresh();
                btnSelectCode.Enabled = false;
                btnRemoveCode.Enabled = false;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 011. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnSelectAllCode_Click(object sender, EventArgs e)
        {
            try
            {
                MainClass.mdi.Cursor = Cursors.WaitCursor;
                objAnalyse.AddAllCodeToSelected();
                dataGridViewCollection.DataSource = objAnalyse.TempCollection.Tables["Collection"];
                dataGridViewCollection.Refresh();
                dataGridViewSelected.DataSource = objAnalyse.TempSelected.Tables["Selected"];
                dataGridViewSelected.Refresh();
                btnSelectCode.Enabled = false;
                btnSelectAllCode.Enabled = false;
                btnRemoveCode.Enabled = false;
                MainClass.getmdi().Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 012. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewSelected_Click(object sender, EventArgs e)
        {
            try
            {
                btnRemoveCode.Enabled = true;
                btnRemoveAllCode.Enabled = true;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 013. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void dataGridViewSelected_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                if ( dataGridViewSelected.SelectedRows.Count <= 0 || dataGridViewSelected.SelectedRows[0].Cells[0].ToString() == "" )
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    objAnalyse.Code = dataGridViewSelected.SelectedRows[0].Cells[0].Value.ToString();
                    objAnalyse.RemoveCodeToSelected ();
                    dataGridViewCollection.DataSource = objAnalyse.TempCollection.Tables["Collection"];
                    dataGridViewCollection.Refresh();
                    dataGridViewSelected.DataSource = objAnalyse.TempSelected.Tables["Selected"];
                    dataGridViewSelected.Refresh();
                    btnRemoveCode.Enabled = false;
                    btnSelectAllCode.Enabled = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 014. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnRemoveCode_Click(object sender, EventArgs e)
        {
            try
            {
                if ( dataGridViewSelected.SelectedRows.Count <= 0 || dataGridViewSelected.SelectedRows[0].Cells[0].ToString() == "" )
                {
                    MessageBox.Show("Select Data", "Select", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    objAnalyse.Code = dataGridViewSelected.SelectedRows[0].Cells[0].Value.ToString();
                    objAnalyse.RemoveCodeToSelected ();
                    dataGridViewCollection.DataSource = objAnalyse.TempCollection.Tables["Collection"];
                    dataGridViewCollection.Refresh();
                    dataGridViewSelected.DataSource = objAnalyse.TempSelected.Tables["Selected"];
                    dataGridViewSelected.Refresh();
                    btnRemoveCode.Enabled = false;
                    btnRemoveAllCode.Enabled = false;
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 015. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnRemoveAllCode_Click(object sender, EventArgs e)
        {
            try
            {
                objAnalyse.RemoveAllCodeToSelected();
                dataGridViewCollection.DataSource = objAnalyse.TempCollection.Tables["Collection"];
                dataGridViewCollection.Refresh();
                dataGridViewSelected.DataSource = objAnalyse.TempSelected.Tables["Selected"];
                dataGridViewSelected.Refresh();
                btnSelectCode.Enabled = false;
                btnRemoveAllCode.Enabled = false;
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 016. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DataSet dsDataForReport = new DataSet();
            clsReportViewer objRepView = new clsReportViewer();

            frmReportViewer objRepViewer = new frmReportViewer();

            try
            {
                objRepViewer.Text = this.Text;
//                if (DateTime.Parse(dtDateFrom.Text) > DateTime.Parse(dtDateTo.Text))
                if (DateTime.Parse(string.Format("{0:dd/MM/yyyy}", dtDateFrom.Text)) > DateTime.Parse(string.Format("{0:dd/MM/yyyy}", dtDateTo.Text)))
                {
                    MessageBox.Show("Selected Date Is Not Valid. Please Select Valid Date Range.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                objAnalyse.DateFrom = dtDateFrom.Text.Trim();
                objAnalyse.DateTo = dtDateTo.Text.Trim();
                objAnalyse.Loca = LoginManager.LocaCode;
                MainClass.mdi.Cursor = Cursors.WaitCursor;
                if (intRepOption == 1000)
                {
                    if (radioButtonProduct.Checked == true) //Sales Analyse
                    {
                        objAnalyse.Iid = "PR";
                        objAnalyse.ProductDailySalesSummary();
                        objRepView.SqlStatement = "select Day_Name Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, tbSalesAnalyseType2.Prod_Code, Product.Prod_Name, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbSalesAnalyseType2 INNER JOIN Product ON tbSalesAnalyseType2.Prod_Code = Product.Prod_Code WHERE tbSalesAnalyseType2.doc_no = '" + strTempDocNo + "' AND Loca = " + LoginManager.LocaCode + " Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptProductDailySalesAnalys ProdDailySaleDet = new rptProductDailySalesAnalys();
                        ProdDailySaleDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ProdDailySaleDet;
                    }
                    else if (radioButtonDepartment.Checked == true)
                    {
                        objAnalyse.Iid = "DP";
                        objAnalyse.ProductDailySalesSummary();
                        objRepView.SqlStatement = "select Day_Name Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, tbSalesAnalyseType2.Prod_Code, Department.Dept_Name Prod_Name, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbSalesAnalyseType2 INNER JOIN Department ON tbSalesAnalyseType2.Prod_Code = Department.Dept_Code WHERE tbSalesAnalyseType2.doc_no = '" + strTempDocNo + "' AND Loca = " + LoginManager.LocaCode + " Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptDepartmentDailySalesAnalys DeptDailySaleDet = new rptDepartmentDailySalesAnalys();
                        DeptDailySaleDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DeptDailySaleDet;
                    }

                    else if (radioButtonCategory.Checked == true)
                    {
                        objAnalyse.Iid = "CT";
                        objAnalyse.ProductDailySalesSummary();
                        objRepView.SqlStatement = "select Day_Name Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, tbSalesAnalyseType2.Prod_Code, Category.Cat_Name Prod_Name, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbSalesAnalyseType2 INNER JOIN Category ON tbSalesAnalyseType2.Prod_Code = Category.Cat_Code WHERE tbSalesAnalyseType2.doc_no = '" + strTempDocNo + "' AND Loca = " + LoginManager.LocaCode + " Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCategoryDailySalesAnalys CatDailySaleDet = new rptCategoryDailySalesAnalys();
                        CatDailySaleDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = CatDailySaleDet;
                    }
                    else if (radioButtonSupplier.Checked == true)
                    {
                        objAnalyse.Iid = "SP";
                        objAnalyse.ProductDailySalesSummary();
                        objRepView.SqlStatement = "select Day_Name Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, tbSalesAnalyseType2.Prod_Code, Supplier.Supp_Name Prod_Name, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbSalesAnalyseType2 INNER JOIN Supplier ON tbSalesAnalyseType2.Prod_Code = Supplier.Supp_Code WHERE tbSalesAnalyseType2.doc_no = '" + strTempDocNo + "' AND Loca = " + LoginManager.LocaCode + " Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSupplierDailySalesAnalys CatDailySaleDet = new rptSupplierDailySalesAnalys();
                        CatDailySaleDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = CatDailySaleDet;
                    }
                    else
                    {
                        MainClass.getmdi().Cursor = Cursors.Default;
                        return;
                    }
                }
                else if (intRepOption == 1100)
                {
                    if (radioButtonProduct.Checked == true) //Sales Analyse
                    {
                        objAnalyse.Iid = "PR";
                        objAnalyse.ProductDailyPurchasing();
                        objRepView.SqlStatement = "select Day_Name Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, tbSalesAnalyseType2.Prod_Code, Product.Prod_Name, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbSalesAnalyseType2 INNER JOIN Product ON tbSalesAnalyseType2.Prod_Code = Product.Prod_Code WHERE tbSalesAnalyseType2.doc_no = '" + strTempDocNo + "' AND Loca = " + LoginManager.LocaCode + " Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptProductDailyPurchaseAnalys ProdDailyPurchDet = new rptProductDailyPurchaseAnalys();
                        ProdDailyPurchDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ProdDailyPurchDet;
                    }
                    else if (radioButtonDepartment.Checked == true)
                    {
                        objAnalyse.Iid = "DP";
                        objAnalyse.ProductDailyPurchasing();
                        objRepView.SqlStatement = "select Day_Name Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, tbSalesAnalyseType2.Prod_Code, Department.Dept_Name Prod_Name, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbSalesAnalyseType2 INNER JOIN Department ON tbSalesAnalyseType2.Prod_Code = Department.Dept_Code WHERE tbSalesAnalyseType2.doc_no = '" + strTempDocNo + "' AND Loca = " + LoginManager.LocaCode + " Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptDepartmentDailyPurchaseAnalys DeptDailyPurDet = new rptDepartmentDailyPurchaseAnalys();
                        DeptDailyPurDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DeptDailyPurDet;
                    }
                    else if (radioButtonCategory.Checked == true)
                    {
                        objAnalyse.Iid = "CT";
                        objAnalyse.ProductDailyPurchasing();
                        objRepView.SqlStatement = "select Day_Name Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, tbSalesAnalyseType2.Prod_Code, Category.Cat_Name Prod_Name, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbSalesAnalyseType2 INNER JOIN Category ON tbSalesAnalyseType2.Prod_Code = Category.Cat_Code WHERE tbSalesAnalyseType2.doc_no = '" + strTempDocNo + "' AND Loca = " + LoginManager.LocaCode + " Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCategoryDailyPurchaseAnalys CatDailyPurcDet = new rptCategoryDailyPurchaseAnalys();
                        CatDailyPurcDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = CatDailyPurcDet;
                    }
                    else if (radioButtonSupplier.Checked == true)
                    {
                        objAnalyse.Iid = "SP";
                        objAnalyse.ProductDailyPurchasing();
                        objRepView.SqlStatement = "select Day_Name Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, tbSalesAnalyseType2.Prod_Code, Supplier.Supp_Name Prod_Name, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbSalesAnalyseType2 INNER JOIN Supplier ON tbSalesAnalyseType2.Prod_Code = Supplier.Supp_Code WHERE tbSalesAnalyseType2.doc_no = '" + strTempDocNo + "' AND Loca = " + LoginManager.LocaCode + " Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSupplierDailyPurchaseAnalys SuppDailyPurDet = new rptSupplierDailyPurchaseAnalys();
                        SuppDailyPurDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = SuppDailyPurDet;
                    }
                    else
                    {
                        MainClass.getmdi().Cursor = Cursors.Default;
                        return;
                    }
                }
                //ProductDailyProfitSummary
                else if (intRepOption == 1200)//Profit Reports
                {
                    if (radioButtonProduct.Checked == true) //Sales Analyse
                    {
                        objAnalyse.Iid = "PR";
                        objAnalyse.ProductDailyProfitSummary();
                        objRepView.SqlStatement = "select Day_Name Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, tbSalesAnalyseType2.Prod_Code, Product.Prod_Name, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbSalesAnalyseType2 INNER JOIN Product ON tbSalesAnalyseType2.Prod_Code = Product.Prod_Code WHERE tbSalesAnalyseType2.doc_no = '" + strTempDocNo + "' AND Loca = " + LoginManager.LocaCode + " Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptProductDailyProfitAnalys ProdDailySaleDet = new rptProductDailyProfitAnalys();
                        ProdDailySaleDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ProdDailySaleDet;
                    }
                    else if (radioButtonDepartment.Checked == true)
                    {
                        objAnalyse.Iid = "DP";
                        objAnalyse.ProductDailyProfitSummary();
                        objRepView.SqlStatement = "select Day_Name Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, tbSalesAnalyseType2.Prod_Code, Department.Dept_Name Prod_Name, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbSalesAnalyseType2 INNER JOIN Department ON tbSalesAnalyseType2.Prod_Code = Department.Dept_Code WHERE tbSalesAnalyseType2.doc_no = '" + strTempDocNo + "' AND Loca = " + LoginManager.LocaCode + " Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptDepartmentDailySalesAnalys DeptDailySaleDet = new rptDepartmentDailySalesAnalys();
                        DeptDailySaleDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DeptDailySaleDet;
                    }

                    else if (radioButtonCategory.Checked == true)
                    {
                        objAnalyse.Iid = "CT";
                        objAnalyse.ProductDailyProfitSummary();
                        objRepView.SqlStatement = "select Day_Name Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, tbSalesAnalyseType2.Prod_Code, Category.Cat_Name Prod_Name, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbSalesAnalyseType2 INNER JOIN Category ON tbSalesAnalyseType2.Prod_Code = Category.Cat_Code WHERE tbSalesAnalyseType2.doc_no = '" + strTempDocNo + "' AND Loca = " + LoginManager.LocaCode + " Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCategoryDailySalesAnalys CatDailySaleDet = new rptCategoryDailySalesAnalys();
                        CatDailySaleDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = CatDailySaleDet;
                    }
                    else if (radioButtonSupplier.Checked == true)
                    {
                        objAnalyse.Iid = "SP";
                        objAnalyse.ProductDailyProfitSummary();
                        objRepView.SqlStatement = "select Day_Name Month_Name, Sale_Amount, Purch_amount, Sale_Qty, Purch_Qty, tbSalesAnalyseType2.Prod_Code, Supplier.Supp_Name Prod_Name, Idx, 'Date From " + dtDateFrom.Text + "' DateFrom, 'Date To " + dtDateTo.Text + "' DateTo from tbSalesAnalyseType2 INNER JOIN Supplier ON tbSalesAnalyseType2.Prod_Code = Supplier.Supp_Code WHERE tbSalesAnalyseType2.doc_no = '" + strTempDocNo + "' AND Loca = " + LoginManager.LocaCode + " Order by Idx";
                        objRepView.DataSetName = "tbReportMonthlyAnalyse";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSupplierDailySalesAnalys CatDailySaleDet = new rptSupplierDailySalesAnalys();
                        CatDailySaleDet.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = CatDailySaleDet;
                    }
                    else
                    {
                        MainClass.getmdi().Cursor = Cursors.Default;
                        return;
                    }
                }
                //Sales Comparison
                else if (intRepOption == 1300)
                {
                    objAnalyse.SecDateFrom = dtpSecondDateFrom.Text.Trim();
                    objAnalyse.SecDateTo = dtpSecondDateTo.Text.Trim();

                    if (radioButtonProduct.Checked == true) //Sales Analyse
                    {
                        objAnalyse.Iid = "PR";
                        objAnalyse.SalesComparison();
                        objRepView.SqlStatement = "select tbProductComparison.Prod_Code, tbProductComparison.Prod_Name, tbProductComparison.Code, Department.Dept_Name [Description], tbProductComparison.Purchase_price,tbProductComparison.Selling_Price, tbProductComparison.Loca, Location.Loca_Descrip, tbProductComparison.First_Qty, tbProductComparison.First_Amount, tbProductComparison.Second_Qty, tbProductComparison.Second_Amount, '" + dtDateFrom.Text + "' FirstDateFrom, '" + dtDateTo.Text + "' FirstDateTo, '" + dtpSecondDateFrom.Text + "' SecondDateFrom, '" + dtpSecondDateTo.Text + "' SecondDateTo from tbProductComparison inner join department on tbProductComparison.Code = Department.Dept_Code inner join Location on tbProductComparison.Loca = Location.Loca";
                        objRepView.DataSetName = "dsProductSalesComparison";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptProductSaleComp ProdSaleComp = new rptProductSaleComp();
                        ProdSaleComp.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = ProdSaleComp;
                    }
                    else if (radioButtonDepartment.Checked == true)
                    {
                        objAnalyse.Iid = "DP";
                        objAnalyse.SalesComparison();
                        objRepView.SqlStatement = "select tbProductComparison.Prod_Code, tbProductComparison.Prod_Name, tbProductComparison.Code, Department.Dept_Name [Description], tbProductComparison.Purchase_price,tbProductComparison.Selling_Price, tbProductComparison.Loca, Location.Loca_Descrip, tbProductComparison.First_Qty, tbProductComparison.First_Amount, tbProductComparison.Second_Qty, tbProductComparison.Second_Amount, '" + dtDateFrom.Text + "' FirstDateFrom, '" + dtDateTo.Text + "' FirstDateTo, '" + dtpSecondDateFrom.Text + "' SecondDateFrom, '" + dtpSecondDateTo.Text + "' SecondDateTo from tbProductComparison inner join department on tbProductComparison.Code = Department.Dept_Code inner join Location on tbProductComparison.Loca = Location.Loca";
                        objRepView.DataSetName = "dsProductSalesComparison";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptDeptSaleComp DeptSaleComp = new rptDeptSaleComp();
                        DeptSaleComp.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = DeptSaleComp;
                    }

                    else if (radioButtonCategory.Checked == true)
                    {
                        objAnalyse.Iid = "CT";
                        objAnalyse.SalesComparison();
                        objRepView.SqlStatement = "select tbProductComparison.Prod_Code, tbProductComparison.Prod_Name, tbProductComparison.Code, Category.Cat_Name [Description], tbProductComparison.Purchase_price,tbProductComparison.Selling_Price, tbProductComparison.Loca, Location.Loca_Descrip, tbProductComparison.First_Qty, tbProductComparison.First_Amount, tbProductComparison.Second_Qty, tbProductComparison.Second_Amount, '" + dtDateFrom.Text + "' FirstDateFrom, '" + dtDateTo.Text + "' FirstDateTo, '" + dtpSecondDateFrom.Text + "' SecondDateFrom, '" + dtpSecondDateTo.Text + "' SecondDateTo from tbProductComparison inner join Category on tbProductComparison.Code = Category.Cat_Code inner join Location on tbProductComparison.Loca = Location.Loca";
                        objRepView.DataSetName = "dsProductSalesComparison";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptCategorySaleComp CategorySaleComp = new rptCategorySaleComp();
                        CategorySaleComp.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = CategorySaleComp;
                    }
                    else if (radioButtonSupplier.Checked == true)
                    {
                        objAnalyse.Iid = "SP";
                        objAnalyse.SalesComparison();
                        objRepView.SqlStatement = "select tbProductComparison.Prod_Code, tbProductComparison.Prod_Name, tbProductComparison.Code, Supplier.Supp_Name [Description], tbProductComparison.Purchase_price,tbProductComparison.Selling_Price, tbProductComparison.Loca, Location.Loca_Descrip, tbProductComparison.First_Qty, tbProductComparison.First_Amount, tbProductComparison.Second_Qty, tbProductComparison.Second_Amount, '" + dtDateFrom.Text + "' FirstDateFrom, '" + dtDateTo.Text + "' FirstDateTo, '" + dtpSecondDateFrom.Text + "' SecondDateFrom, '" + dtpSecondDateTo.Text + "' SecondDateTo from tbProductComparison inner join Supplier on tbProductComparison.Code = Supplier.Supp_Code inner join Location on tbProductComparison.Loca = Location.Loca";
                        objRepView.DataSetName = "dsProductSalesComparison";
                        objRepView.RetrieveData();
                        dsDataForReport = objRepView.TempResultSet;
                        rptSupplierSaleComp SupplierSaleComp = new rptSupplierSaleComp();
                        SupplierSaleComp.SetDataSource(dsDataForReport);
                        objRepViewer.crystalReportViewer1.ReportSource = SupplierSaleComp;
                    }
                    else
                    {
                        MainClass.getmdi().Cursor = Cursors.Default;
                        return;
                    }
                }

                objRepViewer.WindowState = FormWindowState.Maximized;
                MainClass.getmdi().Cursor = Cursors.Default;
                objRepViewer.Show();
            }
            catch (Exception ex)
            {

                //Write to Log
                DateTime dtCurrentDate = DateTime.Now;
                FileStream fileStream = new FileStream(@"..\ErrorLog.txt", FileMode.Append);
                StreamWriter m_streamWriter = new StreamWriter(fileStream);
                try
                {
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 017. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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

        private void frmAnalyse_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control == true)
                {
                    if (e.KeyCode == Keys.D)
                    {
                        this.btnDisplay.PerformClick();
                    }
                    else
                    {

                        if (e.KeyCode == Keys.E)
                        {
                            this.btnClose.PerformClick();
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
                    m_streamWriter.WriteLine("Date/Time :' " + string.Format("{0:dd/MM/yyyy HH:mm:ss}", dtCurrentDate) + "'frmAnalyse 018.. Error Description " + ex.Message + " 'Location :' " + LoginManager.LocaCode + " 'User Name :' " + LoginManager.UserName.Trim() + " '");
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