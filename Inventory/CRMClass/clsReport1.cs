using System;
using System.Collections.Generic;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;

namespace Inventory.CRMClass
{
  public   class clsReport1
    {

        public void DisplayReport(ReportDocument reportName, DataSet datasets, string ContentName)
        {
            if (datasets.Tables[0].Rows.Count < 1)
            {
                System.Windows.Forms.MessageBox.Show("No data found show the report", ContentName.ToString(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }
            frmReport repVeiw = new frmReport();
            repVeiw.virtualReport = reportName;
            repVeiw.virtualReport.SetDataSource(datasets);
            repVeiw.Text = ContentName.Trim();
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
            repVeiw.VirtuaReport = reportName;
            repVeiw.VirtuaReport.SetDataSource(datasets);
            repVeiw.VirtuaReport.SummaryInfo.ReportTitle = ReportTital;
            repVeiw.Text = ContentName.Trim();
            repVeiw.Show();
        }

        public void DisplayReport(ReportDocument reportName, DataSet datasets, string ContentName, string[,] formulaANDvalue, string ReportTital)
        {

            if (datasets != null)
            {
                if (datasets.Tables[0].Rows.Count < 1)
                {
                    System.Windows.Forms.MessageBox.Show("No data found show the report", ContentName.ToString(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return;
                }

                frmReport repVeiw = new frmReport();
                repVeiw.virtualReport = reportName;
                repVeiw.virtualReport.SetDataSource(datasets);
                repVeiw.virtualReport.SummaryInfo.ReportTitle = ReportTital;

                if (formulaANDvalue != null)
                {

                    for (int i = 0; i < formulaANDvalue.GetLength(0); i++)
                    {
                        //string d = formulaANDvalue[i, 0].ToString() + "," + formulaANDvalue[i, 1].ToString();
                        repVeiw.virtualReport.DataDefinition.FormulaFields[formulaANDvalue[i, 0].ToString()].Text = "\"" + formulaANDvalue[i, 1].ToString() + "\"";
                    }
                }
                repVeiw.Text = ContentName.Trim();
                repVeiw.Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No data found show the report", ContentName.ToString(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }
        }

        public void DisplayReport(ReportDocument reportName, DataSet datasets, string ContentName, string[] formulafields, string[] formulavalue, string ReportTital)
        {
            if (datasets.Tables[0].Rows.Count < 1)
            {
                System.Windows.Forms.MessageBox.Show("No data found show the report", ContentName.ToString(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }
            frmReport repVeiw = new frmReport();
            repVeiw.virtualReport = reportName;
            repVeiw.virtualReport.SetDataSource(datasets);
            repVeiw.virtualReport.SummaryInfo.ReportTitle = ReportTital;
            for (int i = 0; i < formulafields.Length; i++)
            {
                repVeiw.virtualReport.DataDefinition.FormulaFields[formulafields[i].ToString()].Text = "\"" + formulavalue[i].ToString() + "\"";
            }
            repVeiw.Text = ContentName.Trim();
            repVeiw.Show();
        }

    }
}
