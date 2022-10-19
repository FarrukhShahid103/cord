using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using RD.EL.Territory;
using RD.BLL.Territory;
using RD.EL;
using RD.BLL;
using System.Configuration;

namespace RDProject.Territory
{
    public partial class TehsilForm : Form
    {

        private bool isException;
        public TehsilForm()
        {
            InitializeComponent();
            loadDistrict();
            lblStatus.Text = string.Empty;
        }

        private void loadDistrict()
        {
            bDistrict obDistrict = new bDistrict();
            List<eDistrict> oeListDistrict = new List<eDistrict>();
            eDistrict oeDistrict = new eDistrict();
            oeListDistrict = obDistrict.GetDistrict(oeDistrict, "", "", 0, int.MaxValue);
            AddItem(oeListDistrict, typeof(eDistrict), "District_id", "District_FullName", "< - SELECT - >");
            if (oeListDistrict != null && oeListDistrict.Count > 0)
            {
                cbDistrict_English.DisplayMember = "District_FullName";
                cbDistrict_English.ValueMember = "district_id";
                cbDistrict_English.DataSource = oeListDistrict;
            }
        }
       
        private void FillGrid(Guid District_ID)
        {
            if (grdTehsil.Rows.Count > 0)
            {
                grdTehsil.Rows.Clear();
            }

            bTehsil manager = new bTehsil();
            eTehsil oelTehsil = new eTehsil();
            oelTehsil.District_id = District_ID;
            List<eTehsil> list = manager.getTehsil(oelTehsil, "", "", 1, int.MaxValue);
            if (list.Count > 0) grdTehsil.Rows.Add(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                grdTehsil.Rows[i].Cells[0].Value = list[i].Tehsil_id;
                grdTehsil.Rows[i].Cells[1].Value = list[i].Tehsil_name_eng;
                grdTehsil.Rows[i].Cells[2].Value = list[i].Tehsil_name_urd;
            }
        }

     
        private void AddItem(IList list, Type type, string valueMember, string displayMember, string displayText)
        {
            Object obj = Activator.CreateInstance(type);
            PropertyInfo displayProperty = type.GetProperty(displayMember);
            displayProperty.SetValue(obj, displayText, null);
            PropertyInfo valueProperty = type.GetProperty(valueMember);
            Guid i = new Guid();
            valueProperty.SetValue(obj, i, null);
            list.Insert(0, obj);
        }

    

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            grdTehsil.AllowUserToAddRows = false;            
            if (cbDistrict_English.SelectedIndex != 0)
            {
                if (isException == false)
                {
                    grdTehsil.Rows.Add();
                    isException = true;
                }
                grdTehsil.Focus();
                grdTehsil.CurrentCell = grdTehsil.Rows[this.grdTehsil.Rows.Count - 1].Cells[2];
                SendKeys.Send("{F2}");
            }
            else
            {
                lblStatus.Text = "Please select district";
            }
        }


        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((ComboBox)sender).SelectedValue = (Guid)((ComboBox)sender).SelectedItem;
        }

        private void cbDistrict_English_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDistrict_English.SelectedIndex != 0)
            {
                Guid DistrictId = (Guid)cbDistrict_English.SelectedValue;
                if (DistrictId != null && DistrictId != new Guid())
                {
                    FillGrid(DistrictId);
                    btnAddRecord.Enabled = true;
                    btnDeleteRecord.Enabled = true;
                }
            }
            else
            {
                grdTehsil.DataSource = null;
                grdTehsil.AllowUserToAddRows = false;
                grdTehsil.Rows.Clear();
                btnAddRecord.Enabled = false;
                btnDeleteRecord.Enabled = false;
            }
            isException = false;
        }


        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            DataGridViewRow R = grdTehsil.Rows[grdTehsil.SelectedCells[0].RowIndex];
            if (R.Cells[0].Value == null)
            {
                return;
            }

            if (grdTehsil.Rows.Count > 0)
            {
                var result = MessageBox.Show("Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (this.grdTehsil.SelectedCells.Count > 0)
                    {
                        eTehsil oelTehsil = new eTehsil();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        oelTehsil.Tehsil_id = (Guid)R.Cells[0].Value;
                        bTehsil obj = new bTehsil();
                        info = obj.deleteTehsil(oelTehsil);
                        if (info.Success)
                        {
                            lblStatus.Text = "Record Deleted Successfully.";
                            this.grdTehsil.Rows.RemoveAt(this.grdTehsil.SelectedCells[0].RowIndex);
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

        private void TehsilForm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void grdTehsil_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdTehsil_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdTehsil_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            lblStatus.Text = string.Empty;
            string headerText = grdTehsil.Columns[e.ColumnIndex].HeaderText;
            string TehsilName_eng = grdTehsil[1, e.RowIndex].EditedFormattedValue.ToString();
            string TehsilName_urd = grdTehsil[2, e.RowIndex].EditedFormattedValue.ToString();
            try
            {
                if (grdTehsil.IsCurrentRowDirty)
                {

                    if (string.IsNullOrEmpty(TehsilName_eng))
                    {
                        grdTehsil.Rows[e.RowIndex].ErrorText = "Tehsil Name must not be empty";
                        lblStatus.Text = "Tehsil Name must not be empty";
                        grdTehsil.CurrentCell = grdTehsil.Rows[e.RowIndex].Cells[1];
                        isException = true;

                        //e.Cancel = true;
                        return;
                    }

                    if (string.IsNullOrEmpty(TehsilName_urd))
                    {
                        grdTehsil.Rows[e.RowIndex].ErrorText = "Tehsil Name must not be empty";
                        grdTehsil.CurrentCell = grdTehsil.Rows[e.RowIndex].Cells[2];
                        lblStatus.Text = "Tehsil Name must not be empty";
                        isException = true;
                        //e.Cancel = true;
                        return;
                    }
                    Guid DistrictId = ValidateFields.GetSafeGuid(cbDistrict_English.SelectedValue.ToString());
                    if (DistrictId != null && DistrictId != Guid.Empty)
                    {
                        string TehsilId = grdTehsil[0, e.RowIndex].EditedFormattedValue.ToString();
                        if (TehsilId == string.Empty)
                        {
                            DataGridViewRow R = grdTehsil.Rows[e.RowIndex];
                            R.Cells[0].Value = Guid.NewGuid();

                            eTehsil oelTehsil = new eTehsil();
                            updatedNewEntryInfo info = new updatedNewEntryInfo();
                            oelTehsil.District_id = (Guid)cbDistrict_English.SelectedValue;
                            oelTehsil.Tehsil_id = (Guid)R.Cells[0].Value;
                            oelTehsil.Tehsil_name_eng = (string)R.Cells[1].Value;
                            oelTehsil.Tehsil_name_urd = (string)R.Cells[2].Value;
                            oelTehsil.Access_date_time = DateTime.Now;
                            bTehsil obj = new bTehsil();
                            info = obj.insertTehsil(oelTehsil);
                            if (info.Success)
                            {
                                lblStatus.Text = "Record Added Successfully.";
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
                            DataGridViewRow R = grdTehsil.Rows[e.RowIndex];
                            eTehsil oelTehsil = new eTehsil();
                            updatedNewEntryInfo info = new updatedNewEntryInfo();
                            oelTehsil.District_id = (Guid)cbDistrict_English.SelectedValue;
                            oelTehsil.Tehsil_id = (Guid)R.Cells[0].Value;
                            oelTehsil.Tehsil_name_eng = (string)R.Cells[1].Value;
                            oelTehsil.Tehsil_name_urd = (string)R.Cells[2].Value;
                            oelTehsil.Access_date_time = DateTime.Now;

                            bTehsil obj = new bTehsil();
                            info = obj.udpateTehsil(oelTehsil);
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
                                    lblStatus.Text = "record not updated, " + info.Exception;
                                    isException = true;
                                }

                            }

                        }
                    }
                    else
                    {
                        lblStatus.Text = "District is missing ...";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception caught : " + ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void grdTehsil_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        
    }
}
