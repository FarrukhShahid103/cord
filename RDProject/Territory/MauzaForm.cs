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
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;

namespace RDProject.Territory
{
    public partial class MauzaForm : Form
    {
        private bool isException;
        public MauzaForm()
        {
            InitializeComponent();
            loadDistrict();
            lblStatus.Text = string.Empty;
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            if (cbxTehsil.SelectedIndex != 0)
            {
                if (cbxAreaFormat.SelectedIndex != 0)
                {
                    grdMauza.AllowUserToAddRows = false;
                    if (!isException)
                    {
                        grdMauza.Rows.Add();
                        isException = true;
                    }
                    grdMauza.Focus();
                    grdMauza.CurrentCell = grdMauza.Rows[this.grdMauza.Rows.Count - 1].Cells["colMauzaNameUrd"];
                    SendKeys.Send("{F2}");
                }
                else
                {
                    lblStatus.Text = "Please choose area format";
                }
            }
            else
            {
                lblStatus.Text = "Please select tehsil";
            }
            
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (grdMauza.Rows.Count > 0)
            {
                var result = MessageBox.Show("Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (this.grdMauza.SelectedCells.Count > 0)
                    {
                        eMauza oelMauza = new eMauza();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        DataGridViewRow R = grdMauza.Rows[grdMauza.SelectedCells[0].RowIndex];
                        oelMauza.Mauza_id = ValidateFields.GetSafeGuid(R.Cells["colMauzaId"].Value);
                        bMauza obj = new bMauza();
                        info = obj.deleteMauza(oelMauza);
                        if (info.Success)
                        {
                            isException = false;
                            lblStatus.Text = "Record Deleted Successfully.";
                            this.grdMauza.Rows.RemoveAt(this.grdMauza.SelectedCells[0].RowIndex);
                        }
                        else
                        {
                            if (info.Exception.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                            {
                                lblStatus.Text = "record not deleted, associated mauza";
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

        private void cbDistrict_English_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid DistrictId = (Guid)cbDistrict_English.SelectedValue;
            if (DistrictId != null && DistrictId != new Guid())
            {
                LoadTehsil(DistrictId);
            }
            else
            {
                cbxTehsil.DataSource = null;
                cbxTehsil.Items.Clear();
                grdMauza.DataSource = null;
                grdMauza.AllowUserToAddRows = false;
                grdMauza.Rows.Clear();
                btnAddRecord.Enabled = false;
                btnDeleteRecord.Enabled = false;
                cbxAreaFormat.SelectedIndex = 0;
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
                btnDeleteRecord.Enabled = true;
                btnAddRecord.Enabled = true;
            }
        }

        private void cbxTehsil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTehsil.SelectedIndex != 0)
            {
                Guid TehsilId = ValidateFields.GetSafeGuid(cbxTehsil.SelectedValue);
                if (TehsilId != null && TehsilId != new Guid())
                {
                    loadTown(TehsilId);
                    //btnAddRecord.Enabled = true;
                    //btnDeleteRecord.Enabled = true;
                }
            }
            else
            {
                cbxTown.DataSource = null;
                cbxTown.Items.Clear();
                cbxTown.Enabled = false;
                grdMauza.DataSource = null;
                grdMauza.AllowUserToAddRows = false;
                grdMauza.Rows.Clear();
                btnAddRecord.Enabled = false;
                btnDeleteRecord.Enabled = false;
            }
            isException = false;

        }

        private void loadTown(Guid TehsilId)
        {
            if (TehsilId != Guid.Empty)
            {
                eTown oeTown = new eTown();
                List<eTown> oeListTown = new List<eTown>();
                bTown obTown = new bTown();
                oeTown.Tehsil_id = TehsilId;
                oeListTown = obTown.getTown(oeTown, "", "", 0, int.MaxValue);
                AddItem(oeListTown, typeof(eTown), "Town_id", "Town_name_eng", "< - SELECT - >");
                if (oeListTown != null && oeListTown.Count > 1)
                {
                    cbxTown.Enabled = true;
                    cbxTown.DisplayMember = "town_name_eng";
                    cbxTown.ValueMember = "town_id";
                    cbxTown.DataSource = oeListTown;
                    btnAddRecord.Enabled = true;
                    btnDeleteRecord.Enabled = true;
                    loadMauza(TehsilId, false);
                }
                else
                {
                    cbxTown.DataSource = null;
                    cbxTown.Items.Clear();
                    cbxTown.Enabled = false;
                    loadMauza(TehsilId, false);
                }
            }
        }

        private void loadMauza(Guid Id, bool isTown)
        {
            bMauza obMauza = new bMauza();
            List<eMauza> oeListMauza = new List<eMauza>();
            eMauza oeMauza = new eMauza();
            if (grdMauza.Rows.Count > 0)
            {
                grdMauza.DataSource = null;
                grdMauza.Rows.Clear();
            }
            if (isTown)
            {
                oeMauza.Town_id = Id;
            }
            else
            {
                oeMauza.Tehsil_id = Id;
            }
            oeListMauza = obMauza.getMauza(oeMauza, "", "", 0, int.MaxValue);
            //AddItem(oeListMauza, typeof(eMauza), "Mauza_id", "Mauza_name_eng", "< - SELECT - >");
            if (oeListMauza.Count > 0) grdMauza.Rows.Add(oeListMauza.Count);
            for (int i = 0; i < oeListMauza.Count; i++)
            {
                grdMauza.Rows[i].Cells["colMauzaId"].Value = oeListMauza[i].Mauza_id;
                grdMauza.Rows[i].Cells["colMauzaNameEng"].Value = oeListMauza[i].Mauza_name_eng;
                grdMauza.Rows[i].Cells["colMauzaNameUrd"].Value = oeListMauza[i].Mauza_name_urd;
            }
            if (oeListMauza == null || oeListMauza.Count == 0)
            {
                grdMauza.DataSource = null;
                grdMauza.Rows.Clear();
            }
        }

        private void FillGrid(Guid Tehsil_ID)
        {
            grdMauza.Rows.Clear();
            bMauza objMauza = new bMauza();
            eMauza oelMauza = new eMauza();
            oelMauza.Tehsil_id = Tehsil_ID;
            List<eMauza> list = objMauza.getMauza(oelMauza, "", "", 1, int.MaxValue-1);
            if (list.Count > 0) grdMauza.Rows.Add(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                grdMauza.Rows[i].Cells["colMauzaId"].Value = list[i].Mauza_id;
                grdMauza.Rows[i].Cells["colMauzaNameEng"].Value = list[i].Mauza_name_eng;
                grdMauza.Rows[i].Cells["colMauzaNameUrd"].Value = list[i].Mauza_name_urd;
            }
        }
        private void grdMauza_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void grdMauza_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void grdMauza_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            lblStatus.Text = string.Empty;
            string headerText = grdMauza.Columns[e.ColumnIndex].HeaderText;
            string TehsilName_eng = grdMauza[1, e.RowIndex].EditedFormattedValue.ToString();
            string TehsilName_urd = grdMauza[2, e.RowIndex].EditedFormattedValue.ToString();
            try
            {
                if (grdMauza.IsCurrentRowDirty)
                {

                    if (string.IsNullOrEmpty(TehsilName_eng))
                    {
                        grdMauza.Rows[e.RowIndex].ErrorText = "Mauza Name must not be empty";
                        lblStatus.Text = "Mauza Name must not be empty";
                        grdMauza.CurrentCell = grdMauza.Rows[e.RowIndex].Cells["colMauzaNameEng"];
                        grdMauza.AllowUserToAddRows = false;
                        //e.Cancel = true;
                        return;
                    }

                    if (string.IsNullOrEmpty(TehsilName_urd))
                    {
                        grdMauza.Rows[e.RowIndex].ErrorText = "Mauza Name must not be empty";
                        grdMauza.CurrentCell = grdMauza.Rows[e.RowIndex].Cells["colMauzaNameUrd"];
                        lblStatus.Text = "Mauza Name must not be empty";
                        //e.Cancel = true;
                        grdMauza.AllowUserToAddRows = false;
                        return;
                    }
                    
                    Guid MauzaId = ValidateFields.GetSafeGuid(grdMauza["colMauzaId", e.RowIndex].EditedFormattedValue.ToString());
                    if (MauzaId == Guid.Empty)
                    {
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        eMauza oelMauza = new eMauza();
                        bMauza obMauza = new bMauza();
                        if (cbxTown.Enabled)
                        {
                            
                            DataGridViewRow R = grdMauza.Rows[e.RowIndex];
                            oelMauza.Town_id = ValidateFields.GetSafeGuid(cbxTown.SelectedValue);
                            oelMauza.Tehsil_id = ValidateFields.GetSafeGuid(cbxTehsil.SelectedValue);
                            R.Cells["colMauzaId"].Value = Guid.NewGuid();
                            oelMauza.Mauza_id = ValidateFields.GetSafeGuid(R.Cells["colMauzaId"].Value);
                            oelMauza.Mauza_name_eng = (string)R.Cells["colMauzaNameEng"].Value;
                            oelMauza.Mauza_name_urd = (string)R.Cells["colMauzaNameUrd"].Value;
                            oelMauza.Access_date_time = DateTime.Now;
                            oelMauza.Area_format = (Int32)cbxAreaFormat.SelectedIndex;
                            info = obMauza.insertMauza(oelMauza);
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
                            DataGridViewRow R = grdMauza.Rows[e.RowIndex];
                            oelMauza.Town_id = null;
                            oelMauza.Tehsil_id = ValidateFields.GetSafeGuid(cbxTehsil.SelectedValue);
                            R.Cells["colMauzaId"].Value = Guid.NewGuid();
                            oelMauza.Mauza_id = ValidateFields.GetSafeGuid(R.Cells["colMauzaId"].Value);
                            oelMauza.Mauza_name_eng = (string)R.Cells["colMauzaNameEng"].Value;
                            oelMauza.Mauza_name_urd = (string)R.Cells["colMauzaNameUrd"].Value;
                            oelMauza.Access_date_time = DateTime.Now;
                            oelMauza.Area_format = (Int32)cbxAreaFormat.SelectedIndex;
                            info = obMauza.insertMauza(oelMauza);
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
                    }
                    else
                    {
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        eMauza oelMauza = new eMauza();
                        bMauza obMauza = new bMauza();
                        if (cbxTown.Enabled)
                        {

                            DataGridViewRow R = grdMauza.Rows[e.RowIndex];
                            oelMauza.Town_id = ValidateFields.GetSafeGuid(cbxTown.SelectedValue);
                            oelMauza.Tehsil_id = ValidateFields.GetSafeGuid(cbxTehsil.SelectedValue);
                            oelMauza.Mauza_id = ValidateFields.GetSafeGuid(R.Cells["colMauzaId"].Value);
                            oelMauza.Mauza_name_eng = (string)R.Cells["colMauzaNameEng"].Value;
                            oelMauza.Mauza_name_urd = (string)R.Cells["colMauzaNameUrd"].Value;
                            oelMauza.Access_date_time = DateTime.Now;
                            oelMauza.Area_format = (Int32)cbxAreaFormat.SelectedIndex;
                            info = obMauza.udpateMauza(oelMauza);
                            if (info.Success)
                            {
                                lblStatus.Text = "Record updated Successfully.";
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
                        else
                        {
                            DataGridViewRow R = grdMauza.Rows[e.RowIndex];
                            oelMauza.Town_id = Guid.Empty;
                            oelMauza.Tehsil_id = ValidateFields.GetSafeGuid(cbxTehsil.SelectedValue);
                            oelMauza.Mauza_id = ValidateFields.GetSafeGuid(R.Cells["colMauzaId"].Value);
                            oelMauza.Mauza_name_eng = (string)R.Cells["colMauzaNameEng"].Value;
                            oelMauza.Mauza_name_urd = (string)R.Cells["colMauzaNameUrd"].Value;
                            oelMauza.Access_date_time = DateTime.Now;
                            oelMauza.Area_format = (Int32)cbxAreaFormat.SelectedIndex;
                            info = obMauza.udpateMauza(oelMauza);
                            if (info.Success)
                            {
                                lblStatus.Text = "Record udpated Successfully.";
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
                                    lblStatus.Text = "record not udpated, " + info.Exception;
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

        private void MauzaForm_Load(object sender, EventArgs e)
        {
            cbxAreaFormat.SelectedIndex = 0;
        }

        private void MauzaForm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbxTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTown.SelectedIndex != 0 && cbxTown.Items.Count > 0 && cbxTown.SelectedIndex != -1)
            {
                Guid TownId = ValidateFields.GetSafeGuid(cbxTown.SelectedValue);
                loadMauza(TownId, true);
            }
            else
            {
                Guid TehsilId = ValidateFields.GetSafeGuid(cbxTehsil.SelectedValue);
                loadMauza(TehsilId, false);
            }
        }
        
    }
}
