using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RD.BLL.Territory;
using System.Data.SqlClient;
using RD.EL;
using RD.BLL;

namespace RDProject.Territory
{
    public partial class frmDistrictSetup : Form
    {
        private bool isException;
        public frmDistrictSetup()
        {
            InitializeComponent();
            lblStatus.Text = string.Empty;
        }
        private void FillGrid()
        {
            grdDistrict.AutoGenerateColumns = false;
            bDistrict manager = new bDistrict();
            eDistrict oelDistrict = new eDistrict();
            List<eDistrict> list = manager.GetDistrict(oelDistrict, "", "", 1, 10);
            if (list != null && list.Count > 0)
            {
                grdDistrict.Rows.Add(list.Count);
                for (int i = 0; i < list.Count; i++)
                {
                    grdDistrict.Rows[i].Cells[0].Value = list[i].District_id;
                    grdDistrict.Rows[i].Cells[1].Value = list[i].District_name_eng;
                    grdDistrict.Rows[i].Cells[2].Value = list[i].District_name_urd;
                }
            }
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            grdDistrict.AllowUserToAddRows = false;
            if (isException == false)
            {
                grdDistrict.Rows.Add();
                isException = true;
            }
            grdDistrict.Focus();            
            grdDistrict.CurrentCell = grdDistrict.Rows[this.grdDistrict.Rows.Count - 1].Cells[2];
            SendKeys.Send("{F2}");
        }

        private void DistrictForm_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (grdDistrict.Rows.Count > 0)
            {
                var result = MessageBox.Show("Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (this.grdDistrict.SelectedCells.Count > 0)
                    {
                        eDistrict oelDistrict = new eDistrict();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        DataGridViewRow R = grdDistrict.Rows[grdDistrict.SelectedCells[0].RowIndex];
                        if (R.Cells[0].Value == null)
                        {
                            return;
                        }

                        oelDistrict.District_id = (Guid)R.Cells[0].Value;

                        bDistrict obj = new bDistrict();
                        info = obj.DeleteDistrict(oelDistrict);
                        if (info.Success)
                        {
                            lblStatus.Text = "Record Deleted Successfully.";
                            this.grdDistrict.Rows.RemoveAt(this.grdDistrict.SelectedCells[0].RowIndex);
                            isException = false;
                        }
                        else
                        {
                            if (info.Exception.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                            {
                                lblStatus.Text = "record not deleted, associated with tehsil";
                                isException = true;
                            }
                            else
                            {
                                lblStatus.Text = "record not deleted, " + info.Exception;
                                isException = true;
                            }
                        }

                    }
                }
            }
        }

        private void frmDistrictSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm_MainMDI obj = new frm_MainMDI();
            obj.Refresh();
        }
        
        private void frmDistrictSetup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                var result = MessageBox.Show("Close?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void grdDistrict_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            lblStatus.Text = string.Empty;
            string headerText = grdDistrict.Columns[e.ColumnIndex].HeaderText;
            string DistrictName_eng = grdDistrict[1, e.RowIndex].EditedFormattedValue.ToString();
            string DistrictName_urd = grdDistrict[2, e.RowIndex].EditedFormattedValue.ToString();            
            try
            {
                if (grdDistrict.IsCurrentRowDirty)
                {

                    if (string.IsNullOrEmpty(DistrictName_eng))
                    {
                        grdDistrict.Rows[e.RowIndex].ErrorText = "District Name must not be empty";
                        lblStatus.Text = "District Name must not be empty";
                        grdDistrict.CurrentCell = grdDistrict.Rows[e.RowIndex].Cells[1];
                        isException = true;
                        //e.Cancel = true;
                        return;
                    }

                    if (string.IsNullOrEmpty(DistrictName_urd))
                    {
                        grdDistrict.Rows[e.RowIndex].ErrorText = "District Name must not be empty";                        
                        grdDistrict.CurrentCell = grdDistrict.Rows[e.RowIndex].Cells[2];
                        lblStatus.Text = "District Name must not be empty";
                        //e.Cancel = true;
                        isException = true;
                        return;
                    }
                    string DistrictId = grdDistrict[0, e.RowIndex].EditedFormattedValue.ToString();
                    if (DistrictId == string.Empty)
                    {
                        DataGridViewRow R = grdDistrict.Rows[e.RowIndex];
                        R.Cells[0].Value = Guid.NewGuid();

                        eDistrict oelDistrict = new eDistrict();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        oelDistrict.District_id = (Guid)R.Cells[0].Value;
                        oelDistrict.Province_id = 1;
                        oelDistrict.District_name_eng = (string)R.Cells[1].Value;
                        oelDistrict.District_name_urd = (string)R.Cells[2].Value;
                        oelDistrict.User_id = Variables.UserId;
                        oelDistrict.Access_date_time = DateTime.Now;
                        bDistrict obj = new bDistrict();
                        info = obj.InsertDistrict(oelDistrict);
                        if (info.Success)
                        {
                            lblStatus.Text = "Record inserted Successfully.";
                            isException = false;
                        }
                        else
                        {
                            if (info.Exception.Contains("duplicate key"))
                            {
                                lblStatus.Text = "record already exists;";
                                isException = true;
                            }
                            else
                            {
                                lblStatus.Text = "record not inserted, " + info.Exception;
                                isException = true;
                            }
                        }

                    }
                    else
                    {
                        DataGridViewRow R = grdDistrict.Rows[e.RowIndex];
                        eDistrict oelDistrict = new eDistrict();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        oelDistrict.District_id = (Guid)R.Cells[0].Value;
                        oelDistrict.Province_id = 1;
                        oelDistrict.District_name_eng = (string)R.Cells[1].Value;
                        oelDistrict.District_name_urd = (string)R.Cells[2].Value;
                        oelDistrict.User_id = Variables.UserId;
                        oelDistrict.Access_date_time = DateTime.Now;
                        bDistrict obj = new bDistrict();
                        info = obj.UdpateDistrict(oelDistrict);
                        if (info.Success)
                        {
                            lblStatus.Text = "Record Updated Successfully.";
                            isException = false;
                        }
                        else
                        {
                            if (info.Exception.Contains("duplicate key"))
                            {
                                lblStatus.Text = "record already exists;";
                                isException = true;
                            }
                            else
                            {
                                lblStatus.Text = "record not inserted, " + info.Exception;
                                isException = true;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception caught : " + ex.Message.ToString());
            }
            finally
            {

                //lblStatus.Text = string.Empty;
            }
        }

        private void grdDistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void frmDistrictSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_MainMDI obj = new frm_MainMDI();
            obj.Refresh();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

    }
}
