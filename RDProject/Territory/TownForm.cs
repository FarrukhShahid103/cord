using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RD.EL;
using RD.BLL;
using System.Collections;
using System.Reflection;

namespace RDProject.Territory
{
    public partial class TownForm : Form
    {
        private bool isException;
        public TownForm()
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
        private void LoadTehsil(Guid districtId)
        {
            bTehsil obTehsil = new bTehsil();
            List<eTehsil> oelListTehsil = new List<eTehsil>();
            //bTehsil manager = new bTehsil();
            eTehsil oelTehsil = new eTehsil();
            oelTehsil.District_id = districtId;
            List<eTehsil> list = obTehsil.getTehsil(oelTehsil, "", "", 1, int.MaxValue - 1);
            AddTehsilItem(list, typeof(eTehsil), "Tehsil_id", "Tehsil_FullName", "< - SELECT - >");
            if (list.Count > 0)
            {
                cbxTehsil.DisplayMember = "Tehsil_FullName";
                cbxTehsil.ValueMember = "Tehsil_id";
                cbxTehsil.DataSource = list;

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

        private void AddTehsilItem(IList list, Type type, string valueMember, string displayMember, string displayText)
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
            grdTown.AllowUserToAddRows = false;
            if (!isException)
            {
                grdTown.Rows.Add();
                isException = true;
            }
            grdTown.Focus();
            grdTown.CurrentCell = grdTown.Rows[this.grdTown.Rows.Count - 1].Cells[2];
            SendKeys.Send("{F2}");

        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (grdTown.Rows.Count > 0)
            {
                var result = MessageBox.Show("Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (this.grdTown.SelectedCells.Count > 0)
                    {
                        eTown oelTown = new eTown();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        DataGridViewRow R = grdTown.Rows[grdTown.SelectedCells[0].RowIndex];
                        if (R.Cells[0].Value == null) return;
                        

                        oelTown.Town_id = (Guid)R.Cells[0].Value;
                        bTown obj = new bTown();


                        info = obj.deleteTown(oelTown);
                        if (info.Success)
                        {
                            lblStatus.Text = "Record Deleted Successfully.";
                            this.grdTown.Rows.RemoveAt(this.grdTown.SelectedCells[0].RowIndex);
                            isException = false;
                        }
                        else
                        {
                            if (info.Exception.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                            {
                                lblStatus.Text = "record not deleted, associated town exists";
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

        private void cbDistrict_English_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid DistrictId = ValidateFields.GetSafeGuid(cbDistrict_English.SelectedValue);
            if (DistrictId != null && DistrictId != new Guid() && DistrictId != Guid.Empty)
            {
                LoadTehsil(DistrictId);
            }
            else
            {
                cbxTehsil.DataSource = null;
                cbxTehsil.Items.Clear();
                grdTown.DataSource = null;
                grdTown.AllowUserToAddRows = false;
                grdTown.Rows.Clear();
                btnAddRecord.Enabled = false;
                btnDeleteRecord.Enabled = false;
            }
        }

        private void cmbTehsil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTehsil.SelectedIndex != 0)
            {
                Guid TehsilId = ValidateFields.GetSafeGuid(cbxTehsil.SelectedValue);
                if (TehsilId != null && TehsilId != new Guid())
                {
                    FillGrid(TehsilId);
                    btnAddRecord.Enabled = true;
                    btnDeleteRecord.Enabled = true;
                }
            }
            else
            {
                grdTown.DataSource = null;
                grdTown.AllowUserToAddRows = false;
                grdTown.Rows.Clear();
                btnAddRecord.Enabled = false;
                btnDeleteRecord.Enabled = false;
            }
            isException = false;
        }

        private void FillGrid(Guid Tehsil_ID)
        {
            //grdTown.AutoGenerateColumns = false;
            //grdTown.AllowUserToAddRows = true;
            grdTown.Rows.Clear();

            bTown objTown = new bTown();
            eTown oelTown = new eTown();
            oelTown.Tehsil_id = Tehsil_ID;
            List<eTown> list = objTown.getTown(oelTown, "", "", 1, int.MaxValue - 1);

            if (list.Count > 0) grdTown.Rows.Add(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                grdTown.Rows[i].Cells[0].Value = list[i].Town_id;
                grdTown.Rows[i].Cells[1].Value = list[i].Town_name_eng;
                grdTown.Rows[i].Cells[2].Value = list[i].Town_name_urd;
            }
        }

        private void grdTown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

        }

        private void grdTown_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            lblStatus.Text = string.Empty;
            string headerText = grdTown.Columns[e.ColumnIndex].HeaderText;
            string TehsilName_eng = grdTown[1, e.RowIndex].EditedFormattedValue.ToString();
            string TehsilName_urd = grdTown[2, e.RowIndex].EditedFormattedValue.ToString();
            try
            {
                if (grdTown.IsCurrentRowDirty)
                {

                    if (string.IsNullOrEmpty(TehsilName_eng))
                    {
                        grdTown.Rows[e.RowIndex].ErrorText = "Town Name must not be empty";
                        lblStatus.Text = "Town Name must not be empty";
                        grdTown.CurrentCell = grdTown.Rows[e.RowIndex].Cells[1];
                        isException = true;
                        return;
                    }

                    if (string.IsNullOrEmpty(TehsilName_urd))
                    {
                        grdTown.Rows[e.RowIndex].ErrorText = "Town Name must not be empty";
                        grdTown.CurrentCell = grdTown.Rows[e.RowIndex].Cells[2];
                        lblStatus.Text = "Town Name must not be empty";
                        isException = true;
                        return;
                    }
                    Guid TehsilId = ValidateFields.GetSafeGuid(cbxTehsil.SelectedValue.ToString());
                    if (TehsilId != null && TehsilId != Guid.Empty)
                    {
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        eTown oelTown = new eTown();
                        bTown obj = new bTown();
                        DataGridViewRow R = grdTown.Rows[e.RowIndex];
                        oelTown.Tehsil_id = TehsilId;
                        oelTown.Town_name_eng = (string)R.Cells[1].Value;
                        oelTown.Town_name_urd = (string)R.Cells[2].Value;
                        oelTown.Access_date_time = DateTime.Now;
                        Guid townId = ValidateFields.GetSafeGuid(R.Cells[0].Value);

                        if (townId != null && townId != Guid.Empty)
                        {
                            oelTown.Town_id = townId;
                            info = obj.udpateTown(oelTown);
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
                                    lblStatus.Text = "record not Updated, " + info.Exception;
                                    isException = true;
                                }
                            }

                        }

                        else
                        {
                            oelTown.Town_id = Guid.NewGuid();
                            info = obj.insertTown(oelTown);
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

        private void TownForm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((ComboBox)sender).SelectedValue = (Guid)((ComboBox)sender).SelectedItem;
        }

        private void TownForm_Load(object sender, EventArgs e)
        {

        }

    }
}
