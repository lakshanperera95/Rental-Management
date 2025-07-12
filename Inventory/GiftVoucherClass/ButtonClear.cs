using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Inventory
{
    public partial class ButtonClear : UserControl
    {
        public ButtonClear()
        {
            InitializeComponent();
        }

        private Form _FormMinimize;

        public Form FormMinimize
        {
            get { return _FormMinimize; }
            set { _FormMinimize = value; }
        }


        private void pnlClose_MouseEnter(object sender, EventArgs e)
        {
            pnlMinimize.BackgroundImage = global::Inventory.Properties.Resources.MinimizButtonOverSmall; 
        }

        private void pnlClose_MouseLeave(object sender, EventArgs e)
        {
            pnlMinimize.BackgroundImage = global::Inventory.Properties.Resources.MinimizButtonSmall; 
        }

        private void pnlMinimize_Click(object sender, EventArgs e)
        {
            FormMinimize.WindowState = FormWindowState.Minimized;
        }
    }
}
