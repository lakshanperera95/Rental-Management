using System;
using System.Collections.Generic;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Windows.Forms;

namespace Inventory
{
    public class clsReport
    {

        public void DisplayReport(ReportDocument reportName, DataSet datasets, string ContentName)
        {
            if (datasets.Tables[0].Rows.Count < 1)
            {
                System.Windows.Forms.MessageBox.Show("No data found show the report", ContentName.ToString(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }
            frmReportViewer repVeiw = new frmReportViewer();
            repVeiw.DirectPrintVerRep = reportName;
            repVeiw.DirectPrintVerRep.SetDataSource(datasets);
            repVeiw.Text = ContentName.Trim();
            repVeiw.crystalReportViewer1.ReportSource = repVeiw.DirectPrintVerRep;
            repVeiw.WindowState = FormWindowState.Maximized;
            repVeiw.Show();
        }

        public void DisplayReport(ReportDocument reportName, DataSet datasets, string ContentName, string ReportTital)
        {
            if (datasets.Tables[0].Rows.Count < 1)
            {
                System.Windows.Forms.MessageBox.Show("No data found show the report", ContentName.ToString(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }
            frmReportViewer repVeiw = new frmReportViewer();
            repVeiw.DirectPrintVerRep = reportName;
            repVeiw.DirectPrintVerRep.SetDataSource(datasets);
            repVeiw.DirectPrintVerRep.SummaryInfo.ReportTitle = ReportTital;
            repVeiw.Text = ContentName.Trim();
            repVeiw.crystalReportViewer1.ReportSource = repVeiw.DirectPrintVerRep;
            repVeiw.WindowState = FormWindowState.Maximized;
            repVeiw.Show();
        }

        public void DisplayReport(ReportDocument reportName, DataSet datasets, string ContentName, string[,] formulaANDvalue, string ReportTital)
        {
            if (datasets.Tables[0].Rows.Count < 1)
            {
                System.Windows.Forms.MessageBox.Show("No data found show the report", ContentName.ToString(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }
            frmReportViewer repVeiw = new frmReportViewer();
            repVeiw.DirectPrintVerRep = reportName;
            repVeiw.DirectPrintVerRep.SetDataSource(datasets);
            repVeiw.DirectPrintVerRep.SummaryInfo.ReportTitle = ReportTital;
            for (int i = 0; i < formulaANDvalue.GetLength(0); i++)
            {
                //string d = formulaANDvalue[i, 0].ToString() + "," + formulaANDvalue[i, 1].ToString();
                repVeiw.DirectPrintVerRep.DataDefinition.FormulaFields[formulaANDvalue[i, 0].ToString()].Text = "\"" + formulaANDvalue[i, 1].ToString() + "\"";
            }
           
            repVeiw.Text = ContentName.Trim();
            repVeiw.crystalReportViewer1.ReportSource = repVeiw.DirectPrintVerRep;
            repVeiw.WindowState = FormWindowState.Maximized;
            repVeiw.Show();
        }

        public void DisplayReport(ReportDocument reportName, DataSet datasets, string ContentName, string[] formulafields, string[] formulavalue, string ReportTital)
        {
            if (datasets.Tables[0].Rows.Count < 1)
            {
                System.Windows.Forms.MessageBox.Show("No data found show the report", ContentName.ToString(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }
            frmReportViewer repVeiw = new frmReportViewer();
            repVeiw.DirectPrintVerRep = reportName;
            repVeiw.DirectPrintVerRep.SetDataSource(datasets);
            repVeiw.DirectPrintVerRep.SummaryInfo.ReportTitle = ReportTital;
            for (int i = 0; i < formulafields.Length; i++)
            {
                repVeiw.DirectPrintVerRep.DataDefinition.FormulaFields[formulafields[i].ToString()].Text = "\"" + formulavalue[i].ToString() + "\"";
            }
            repVeiw.Text = ContentName.Trim();
            repVeiw.crystalReportViewer1.ReportSource = repVeiw.DirectPrintVerRep;
            repVeiw.WindowState = FormWindowState.Maximized;
            repVeiw.Show();
        }

        
    }
}
