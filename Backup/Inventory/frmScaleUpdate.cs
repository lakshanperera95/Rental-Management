using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using clsLibrary;

namespace Inventory
{
    public partial class frmScaleUpdate : Form
    {
        public frmScaleUpdate()
        {
            InitializeComponent();
        }
        clsCommon objScale = new clsCommon();
        private static frmScaleUpdate _frmObjScaleUp;
        public static frmScaleUpdate frmObjScaleUp
        {
            get { return _frmObjScaleUp; }
            set { _frmObjScaleUp = value; }
        }


        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Refresh();
                lblmsge.Visible = false;
                this.Refresh();
                picLoad.Visible = true;
                this.Refresh();
                objScale.getDataReader("EXEC sp_DataUploadToScale");
                this.Refresh();
                picLoad.Visible = false;
                lblmsge.Visible = true;
                MessageBox.Show("Data Uploaded successful!",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                objScale.Errormsg(ex, "frmScaleUpdate-btnUpload_Click");
               
            }
        }

        private void frmScaleUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmObjScaleUp = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            frmObjScaleUp = null;
        }
    }
}