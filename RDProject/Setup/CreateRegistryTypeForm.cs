using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RD.BLL;
using RD.EL;

namespace RDProject.Setup
{
    public partial class CreateRegistryTypeForm : Form
    {
        private bool isException;
        public CreateRegistryTypeForm()
        {
            InitializeComponent();
            lblStatus.Text = string.Empty;
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            grdRegistryType.AllowUserToAddRows = false;
            if (isException == false)
            {
                grdRegistryType.Rows.Add();
                isException = true;
            }
            grdRegistryType.Focus();
            grdRegistryType.CurrentCell = grdRegistryType.Rows[this.grdRegistryType.Rows.Count - 1].Cells[2];
            SendKeys.Send("{F2}");            
        }

        private void FillGrid()
        {
            grdRegistryType.AutoGenerateColumns = false;
            grdRegistryType.AllowUserToAddRows = false;

            bRegistryType manager = new bRegistryType();
            eRegistryType oelRegistryType = new eRegistryType();
            List<eRegistryType> list = manager.getRegistryType(oelRegistryType, "", "", 1, 10);
            if (list != null && list.Count > 0)
            {
                grdRegistryType.Rows.Add(list.Count);
                for (int i = 0; i < list.Count; i++)
                {
                    grdRegistryType.Rows[i].Cells[0].Value = list[i].Registry_type_id;
                    grdRegistryType.Rows[i].Cells[1].Value = list[i].Registry_type_description_eng;
                    grdRegistryType.Rows[i].Cells[2].Value = list[i].Registry_type_description_urd;
                }
            }
        }

        private void CreateRegistryTypeForm_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (grdRegistryType.Rows.Count > 0)
            {
                var result = MessageBox.Show("Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (this.grdRegistryType.SelectedCells.Count > 0)
                    {

                        eRegistryType oelRegistryType = new eRegistryType();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        DataGridViewRow R = grdRegistryType.Rows[grdRegistryType.SelectedCells[0].RowIndex];
                        if (R.Cells[0].Value == null)
                        {
                            return;
                        }
                        oelRegistryType.Registry_type_id = (Guid)R.Cells[0].Value;
                        bRegistryType obj = new bRegistryType();
                        info = obj.deleteRegistryType(oelRegistryType);
                        if (info.Success)
                        {
                            lblStatus.Text = "Record Deleted Successfully.";
                            this.grdRegistryType.Rows.RemoveAt(this.grdRegistryType.SelectedCells[0].RowIndex);
                            isException = false;
                        }
                        else
                        {
                            if (info.Exception.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                            {
                                lblStatus.Text = "record not deleted, associated caste";
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

        private void CreateRegistryTypeForm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void grdRegistryType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void grdRegistryType_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            lblStatus.Text = string.Empty;
            string headerText = grdRegistryType.Columns[e.ColumnIndex].HeaderText;
            string RegistryTypeName_eng = grdRegistryType[1, e.RowIndex].EditedFormattedValue.ToString();
            string RegistryTypeName_urd = grdRegistryType[2, e.RowIndex].EditedFormattedValue.ToString();
            try
            {
                if (grdRegistryType.IsCurrentRowDirty)
                {

                    if (string.IsNullOrEmpty(RegistryTypeName_eng))
                    {
                        grdRegistryType.Rows[e.RowIndex].ErrorText = "Registry Type Name must not be empty";
                        lblStatus.Text = "Registry Type Name must not be empty";
                        grdRegistryType.CurrentCell = grdRegistryType.Rows[e.RowIndex].Cells[1];

                        //e.Cancel = true;
                        return;
                    }

                    if (string.IsNullOrEmpty(RegistryTypeName_urd))
                    {
                        grdRegistryType.Rows[e.RowIndex].ErrorText = "District Name must not be empty";
                        grdRegistryType.CurrentCell = grdRegistryType.Rows[e.RowIndex].Cells[2];
                        lblStatus.Text = "District Name must not be empty";
                        //e.Cancel = true;
                        return;
                    }
                    string RegistryTypeId = grdRegistryType[0, e.RowIndex].EditedFormattedValue.ToString();
                    if (RegistryTypeId == string.Empty)
                    {
                        DataGridViewRow R = grdRegistryType.Rows[e.RowIndex];
                        R.Cells[0].Value = Guid.NewGuid();


                        eRegistryType oelRegistryType = new eRegistryType();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        oelRegistryType.Registry_type_id = (Guid)R.Cells[0].Value;
                        oelRegistryType.User_id = Variables.UserId;
                        oelRegistryType.Access_date_time = DateTime.Now;
                        oelRegistryType.Registry_type_description_eng = (string)R.Cells[1].Value;
                        oelRegistryType.Registry_type_description_urd = (string)R.Cells[2].Value;
                        bRegistryType obj = new bRegistryType();
                        info = obj.insertRegistryType(oelRegistryType);
                        if (info.Success)
                        {
                            lblStatus.Text = "Record Added Successfully.";
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
                        DataGridViewRow R = grdRegistryType.Rows[e.RowIndex];
                        eRegistryType oelRegistryType = new eRegistryType();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        oelRegistryType.Registry_type_id = (Guid)R.Cells[0].Value;
                        oelRegistryType.User_id = Variables.UserId;
                        oelRegistryType.Access_date_time = DateTime.Now;
                        oelRegistryType.Registry_type_description_eng = (string)R.Cells[1].Value;
                        oelRegistryType.Registry_type_description_urd = (string)R.Cells[2].Value;


                        bRegistryType obj = new bRegistryType();
                        info = obj.udpateRegistryType(oelRegistryType);
                        if (info.Success)
                        {
                            lblStatus.Text = "Record Updated Successfully.";
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
                                lblStatus.Text = "record not updated, " + info.Exception;
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
    }
}
