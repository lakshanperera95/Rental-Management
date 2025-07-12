using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using clsLibrary;
using Inventory.Properties;
using System.Net.NetworkInformation;


namespace Inventory
{
    public partial class Splash : Form
    {
       
        static Thread th = null;
        static Splash splash = null;

        int min = 0;
        int max = 473;

        public Splash()
        {
            InitializeComponent();
            timer1.Start();
        }

        static private void CreateSplash()
        {
            splash = new Splash();
            Application.Run(splash);
        }

        static public void ShowSplash()
        {
            if (th != null)
                return;
            th = new Thread(new ThreadStart(Splash.CreateSplash));
            th.IsBackground = true;
            th.ApartmentState = ApartmentState.STA;
            th.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int lable = (int)((min / max) * 100);

            if (min >= max)
            {
                timer1.Stop();
                this.Hide();
                //this.Close();

                if (MainClass.getmdi() == null)
                {
                    MainClass.ShowMdi();
                }
                else
                {
                    MainClass.getmdi().Focus();
                }
            }
            min = min + 4;
            pnlProgress.Width = min;

            if (min == 100)
            {
                timer1.Interval = 60;
                lblStates.Text = "Checking Database Connection..."; 

                clsSplash dbstate = new clsSplash(); 

                if (dbstate.checkCon() == 1)
                {
                    timer1.Stop();
                    MessageBox.Show("Error in Initializing Database connection", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
            }
            if (min > 150)
            {
                timer1.Interval = 1;
                lblStates.Text = "Initializing components...";
                lblStates.Refresh();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            try
            {
                lblVersion.Text = "Version  SM " + Application.ProductVersion.Remove(0, 2).ToString();
                if (!Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "").Equals("dd/MM/yyyy"))
                {
                    Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy");
                }
                String sMacAddress = string.Empty;
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)// only return MAC Address from first card
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                        LoginManager.MacAddress = sMacAddress;

                    }
                }

                string MachineName = System.Environment.MachineName.ToString();
                LoginManager.MachinName = MachineName.Trim();

                try
                {
                     BackgroundImage = Image.FromFile(@"..\Splash.JPG");
                }
                catch (Exception)
                {
                    
                      this.BackgroundImage = global::Inventory.Properties.Resources.Splash1;
                }
            }
            finally
            {

            }
        }
    }
}