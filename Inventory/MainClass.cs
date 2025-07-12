using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clsLibrary;
using DbConnection;

namespace Inventory
{
    public partial class  MainClass
    {
        public static Splash splsh = null;
        public static MDI mdi = null;
        public static frmLogin login = null;
         

        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);     
                splsh  = new Splash(); 
                Application.Run(splsh);            
            }
            catch (Exception ex)
            {             
                 MessageBox.Show(ex.Message, "Inventory ",MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public static void ShowMdi() {
            mdi = new MDI();
            mdi.Show();       
        }
        public static void ShowLogin() {

            //frmLogin = new frmLogin();
            //frmLogin.MdiParent = mdi;
            //frmLogin.Show();
        }
        public static MDI getmdi() {
            return mdi;
        }

        public static DataSet DtAllItems;

        clsWholeSaleInvoice objWholeInvoice = new clsWholeSaleInvoice();
        public async static void LoadItemData()
        {
            try
            {
                string ogf = "", RtnQry = "";

                string SqlStatement = "SELECT * FROM  Location WHERE OGF =1 and Loca='" + LoginManager.LocaCode + "'";
                
                if (clsWholeSaleInvoice.Getogfst(SqlStatement).Tables[0].Rows.Count > 0)
                {
                    ogf = " and P.OGF = 1";
                }

                SqlStatement = "SELECT P.Prod_Code AS [Product Code],P.Prod_Name AS [Product Name], CAST(P.Purchase_price AS DECIMAL(18,3)) [Purchase Price], CAST(P.Whole_Price AS DECIMAL(18,2)) [Whole Price], CAST(P.Selling_Price AS DECIMAL(18,2)) [Retail Price] ,CAST(P.MinimumPrice AS DECIMAL(18,2)) [Minimum Price], CAST(P.Marked_Price AS DECIMAL(18,2)) [M.M Price], SM.Qty [Stock],P.Disc_str[Discount]     FROM Product P INNER JOIN Stock_Master SM ON P.Prod_Code = SM.Prod_Code WHERE SM.Loca = '" + LoginManager.LocaCode + "' AND P.LockedItem = 'F'  " + ogf + " " + RtnQry + " ORDER BY P.Prod_Name ASC";
               

                DtAllItems = clsWholeSaleInvoice.Getogfst(SqlStatement);

                MainClass.mdi.notifyIcon1.Text = "Sync Started";
                MainClass.mdi.notifyIcon1.Icon = SystemIcons.Information;
                MainClass.mdi.notifyIcon1.Visible = true;

                // Show a notification
                MainClass.mdi.notifyIcon1.BalloonTipTitle = "Sync";
                MainClass.mdi.notifyIcon1.BalloonTipText = "Products Downloaded.";
                MainClass.mdi.notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                MainClass.mdi.notifyIcon1.ShowBalloonTip(3000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        public static void StartListening()
        {
            SqlDependency.Stop(dbcon.ConnectionString);
            SqlDependency.Start(dbcon.ConnectionString);

            ListenForChanges();
        }

        private static void ListenForChanges()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dbcon.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(" SELECT Prod_Code,Prod_Name,Purchase_price,Selling_Price,Marked_Price,Whole_Price  FROM dbo.Product", connection))
                    {
                        SqlDependency dependency = new SqlDependency(command);
                        dependency.OnChange += new OnChangeEventHandler(OnProductTableChange);
                        command.ExecuteReader(); // Execute the command to start listening
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private static void OnProductTableChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                Console.WriteLine("Product table has changed. Reloading data...");
                Task.Run(() => LoadItemData()); // Run in background to avoid interrupting main process

                // Re-listen for changes
                ListenForChanges();
            }
        }

    }
}
