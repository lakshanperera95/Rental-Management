using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Inventory
{
    public partial class frmImageView : Form
    {
        public frmImageView()
        {
            InitializeComponent();
        }
        private static frmImageView _GetForm;
        public static frmImageView GetForm
        {
            get { return _GetForm; }
            set { _GetForm = value; }
        }
        private void frmImageView_Load(object sender, EventArgs e)
        {

        }

        private void frmImageView_FormClosed(object sender, FormClosedEventArgs e)
        {
            _GetForm = null;
        }
    }
}