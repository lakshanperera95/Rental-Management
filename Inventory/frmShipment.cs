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
    public partial class frmShipment : Form
    {
        public frmShipment()
        {
            InitializeComponent();
        }

        private static frmShipment objShip;
        public static frmShipment _objShip
        {
            get { return objShip; }
            set { objShip = value; }
        }

        private frmSearch search = new frmSearch();
        clsCommon Common = new clsCommon();

        private void frmShipment_FormClosed(object sender, FormClosedEventArgs e)
        {
            objShip = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.IsDisposed)
                {
                    search = new frmSearch();

                }

                Common.getDataSet("SELECT ShipmentCode AS Code, ShipmentDescription AS Department FROM tb_Shipment WHERE Loca='"+LoginManager.LocaCode+"' AND (ShipmentCode LIKE '%" + txtShipmentCode.Text.Trim() + "%') AND (ShipmentDescription LIKE '%" + txtShipmentDescription.Text.Trim() + "%') ORDER BY ShipmentCode", "dtShipment");

                search.dgSearch.DataSource = Common.Ads.Tables["dtShipment"];
                search.prop_Focus = txtShipmentCode;
                search.Cont_Descript = txtShipmentDescription;
                search.Show();
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtShipmentCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtShipmentDescription.Text.Trim() != string.Empty)
                {
                    Common.getDataSet("SELECT ShipmentCode, ShipmentDescription, CONVERT(VARCHAR(10),ShipmentDate,103) ShipmentDate FROM tb_Shipment WHERE ShipmentCode='" + txtShipmentCode.Text.Trim() + "' AND Loca='"+LoginManager.LocaCode+"' ", "dtShipment");

                    if (Common.Ads.Tables["dtShipment"].Rows.Count >0)
                    {
                        txtShipmentCode.Text = Common.Ads.Tables["dtShipment"].Rows[0]["ShipmentCode"].ToString();
                        txtShipmentDescription.Text = Common.Ads.Tables["dtShipment"].Rows[0]["ShipmentDescription"].ToString();
                        dtpDate.Text = Common.Ads.Tables["dtShipment"].Rows[0]["ShipmentDate"].ToString();
                    }
                    txtShipmentDescription.Focus();
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void txtShipmentDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                dtpDate.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtShipmentCode.Text = txtShipmentDescription.Text = string.Empty;
            dtpDate.ResetText();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do You Want To Save This Shipment ?",this.Text,  MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (txtShipmentCode.Text.Trim()==string.Empty)
                    {
                        MessageBox.Show("Invalid Data",this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        txtShipmentCode.Focus();
                        return;
                    }

                    if (txtShipmentDescription.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Invalid Data", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        txtShipmentDescription.Focus();
                        return;
                    }

                    Common.Recordfind("SELECT ShipmentCode FROM tb_Shipment WHERE (Loca='"+LoginManager.LocaCode+"' AND ShipmentCode = '"+txtShipmentCode.Text.Trim()+"') ");
                    if (Common.RecordFind)
                    {
                        if (MessageBox.Show("Shipment Already Have! Do You Want To Update/Change It ?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No)
                        {
                            return;
                        }
                    }

                    Common.getDataSet("EXEC [sp_ShipmentUpdate]	@Err_x=0,@Loca='" + LoginManager.LocaCode + "', @Code='" + txtShipmentCode.Text + "',@Description='" + txtShipmentDescription.Text + "', @ShipmentDate='" + dtpDate.Text.Trim() + "',@User_Name='" + LoginManager.UserName + "'", "dtShipment");

                    if (Common.Ads.Tables["dtShipment"].Rows.Count>0)
                    {
                        MessageBox.Show("Shipment " + Common.Ads.Tables["dtShipment"].Rows[0][0].ToString() + " Saved Succussfully !",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClear.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                clsClear.ErrMessage(ex.Message, ex.StackTrace);
            }
        }

        private void frmShipment_Load(object sender, EventArgs e)
        {

        }

    }
}