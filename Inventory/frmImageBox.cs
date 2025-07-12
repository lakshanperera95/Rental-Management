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
    public partial class frmImageBox : Form
    { 

        public frmImageBox()
        { 
            InitializeComponent();
        }

        private static frmImageBox getImageBox;
        public static frmImageBox _getImageBox
        {
            get { return getImageBox; }
            set { getImageBox = value; }
        }

        private string CurrentMainForm;
        public string _CurrentMainForm
        {
            get { return CurrentMainForm; }
            set { CurrentMainForm = value; }
        }

        private bool fitToMainForm;
        public bool _fitToMainForm
        {
            get { return fitToMainForm; }
            set { fitToMainForm = value; }
        }
  
        private void frmImageBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmImageBox._getImageBox = null;
        }

        private void frmImageBox_Load(object sender, EventArgs e)
        {
            //Load the Form At Position of Main Form

            frmWholeSaleInvoice CurrentMainForm = new frmWholeSaleInvoice();

            int WidthOfMain = CurrentMainForm.Width;
            int HeightofMain = CurrentMainForm.Height;
            int LocationMainX = CurrentMainForm.Location.X;
            int locationMainy = CurrentMainForm.Location.Y;
            this.ControlBox = false;

 
            //form2.StartPosition = FormStartPosition.Manual;
            //form2.Left = 500;
            //form2.Top = 500;
            //form2.ShowDialog();

              
           // this.Location = new Point(CurrentMainForm.Top, this.Top);
            //this.Location = new Point(this.Location.X - this.Location.Y, CurrentMainForm.Bounds.Top);

            //Set the Location
            //this.Location = new Point(LocationMainX + WidthOfMain, locationMainy); 
          // this.Location = new Point(this.Bounds.Right, this.Bounds.Top);//new Point(this.Width, this.Bounds.Top);
           this.Left = 1150;
           this.Top = 6;
            
        }

        private void frmImageBox_MouseDown(object sender, MouseEventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            
            
        }

        private void frmImageBox_LocationChanged(object sender, EventArgs e)
        {

        }
         


    }
}