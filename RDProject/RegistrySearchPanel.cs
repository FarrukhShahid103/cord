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

namespace RDProject
{
    public partial class RegistrySearchPanel : Form
    {
        DataGridViewRow DgvRow = null;
        DataGridViewTextBoxCell DgvCell = null;
        bRegistryType obRegistryType = new bRegistryType();
        List<eRegistry> List;
        public RegistrySearchPanel()
        {
            InitializeComponent();
        }

        private void RegistrySearchPanel_Load(object sender, EventArgs e)
        {
            LoadTerritories();
        }
        private void LoadTerritories()
        { 
            bRegistryType obRegistryType = new bRegistryType();
            eRegistryType oeRegistryType = new eRegistryType();
            List<eRegistryType> oeListRegistryType = obRegistryType.getRegistryType(oeRegistryType, "", "", 0, int.MaxValue);
            AddItem(oeListRegistryType, typeof(eRegistryType), "Registry_type_id", "Registry_type_description_eng", "< - SELECT - >");
            if (oeListRegistryType != null && oeListRegistryType.Count > 0)
            {
                cbxRegisteryType.DisplayMember = "Registry_type_description_eng";
                cbxRegisteryType.ValueMember = "Registry_type_id";
                cbxRegisteryType.DataSource = oeListRegistryType;
            }

            /// Load Districts
            bDistrict obDistrict = new bDistrict();
            List<eDistrict> oeListDistrict = new List<eDistrict>();
            eDistrict oeDistrict = new eDistrict();
            oeListDistrict = obDistrict.GetDistrict(oeDistrict, "", "", 0, int.MaxValue);
            AddItem(oeListDistrict, typeof(eDistrict), "District_id", "District_FullName", "< - SELECT - >");
            if (oeListDistrict != null && oeListDistrict.Count > 0)
            {
                cbxDistrict.DisplayMember = "District_FullName";
                cbxDistrict.ValueMember = "district_id";
                cbxDistrict.DataSource = oeListDistrict;
            }
        }
        private void CreateCellsWithBinding(List<eRegistry> list)
        {
            if (list.Count > 0)
            { 
               for(int i=0; i<list.Count; i++)
                {
                    DgvRow = new DataGridViewRow();

                    DgvCell = new DataGridViewTextBoxCell(); 
                    DgvCell.Value = list[i].Registery_Id;                                        
                    DgvRow.Cells.Add(DgvCell);

                    DgvCell = new DataGridViewTextBoxCell();                                      
                    DgvCell.Value = list[i].Registery_no;
                    DgvRow.Cells.Add(DgvCell);

                    DgvCell = new DataGridViewTextBoxCell();
                    DgvCell.Value = list[i].Registery_Date.Date.ToString("dd-MM-yyyy");
                    DgvRow.Cells.Add(DgvCell);

                    DgvCell = new DataGridViewTextBoxCell();
                    DgvCell.Value = list[i].Registry_Type_Description_Eng;
                    DgvRow.Cells.Add(DgvCell);

                    DgvCell = new DataGridViewTextBoxCell();
                    DgvCell.Value = list[i].District_Name_Eng;
                    DgvRow.Cells.Add(DgvCell);

                    DgvCell = new DataGridViewTextBoxCell();
                    DgvCell.Value = list[i].Tehsil_Name_Eng;
                    DgvRow.Cells.Add(DgvCell);


                    DgvCell = new DataGridViewTextBoxCell();
                    DgvCell.Value = list[i].Mauza_Name_Eng;
                    DgvRow.Cells.Add(DgvCell);

                    DgvRegistry.Rows.Add(DgvRow);
                    
                }
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

        private void cbxDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            /// Load Tehsils
            string ControlName = ((ComboBox)sender).Name;
            if (ControlName == "cbxDistrict")
            {
                if (new Guid(cbxDistrict.SelectedValue.ToString()) != Guid.Empty && cbxDistrict.SelectedValue != null)
                {
                    bTehsil manager = new bTehsil();
                    eTehsil oelTehsil = new eTehsil();
                    oelTehsil.District_id = new Guid(cbxDistrict.SelectedValue.ToString());
                    List<eTehsil> list = manager.getTehsil(oelTehsil, "", "", 0, int.MaxValue);
                    AddItem(list, typeof(eTehsil), "Tehsil_id", "Tehsil_name_eng", "< - SELECT - >");
                    if (list != null && list.Count > 0)
                    {
                        cbxTehsil.DisplayMember = "Tehsil_name_eng";
                        cbxTehsil.ValueMember = "Tehsil_id";
                        cbxTehsil.DataSource = list;
                    }
                }
            }
            else if (ControlName == "cbxTehsil")
            {               
                if (new Guid(cbxTehsil.SelectedValue.ToString()) != Guid.Empty)
                {
                    bMauza manager = new bMauza();
                    eMauza oelMauza = new eMauza();
                    oelMauza.Tehsil_id = new Guid(cbxTehsil.SelectedValue.ToString());
                    List<eMauza> list = manager.getMauza(oelMauza, "", "", 0, int.MaxValue);
                    AddItem(list, typeof(eMauza), "Mauza_id", "Mauza_name_eng", "< - SELECT - >");
                    if (list != null && list.Count > 0)
                    {
                        cbxMauza.DisplayMember = "mauza_name_eng";
                        cbxMauza.ValueMember = "mauza_id";
                        cbxMauza.DataSource = list;
                    }
                }
            }

        }

        private void chkCommon_CheckedChanged(object sender, EventArgs e)
        {
            string chkBoxName = ((CheckBox)sender).Name;
            if (chkBoxName == "chkTokenNo")
            {
                if (chkTokenNo.Checked)
                {
                    txtTokenNo.Enabled = true;
                }
                else
                {
                    txtTokenNo.Enabled = false;
                }
            }            
            else if (chkBoxName == "chkDate")
            {
                if (chkDate.Checked)
                {
                    RegistryDatePicker.Enabled = true;
                }
                else
                {
                    RegistryDatePicker.Enabled = false;
                }
            }            
            else if (chkBoxName == "chkRegistryType")
            {
                if (chkRegistryType.Checked)
                {
                    cbxRegisteryType.Enabled = true;
                }
                else
                {
                    cbxRegisteryType.Enabled = false;
                }
            }
            else if (chkBoxName == "chkTehsil")
            {
                if (chkTehsil.Checked)
                {
                    cbxTehsil.Enabled = true;
                }
                else
                {
                    cbxTehsil.Enabled = false;
                }
            }
            
            else if (chkBoxName == "chkDistrict")
            {
                if (chkDistrict.Checked)
                {
                    cbxDistrict.Enabled = true;
                }
                else
                {
                    cbxDistrict.Enabled = false;
                }
            }            
            else if (chkBoxName == "chkMauza")
            {
                if (chkMauza.Checked)
                {
                    cbxMauza.Enabled = true;
                }
                else
                {
                    cbxMauza.Enabled = false;
                }

            }
        }
        private string BuildCondition()
        {
            string Condition = "";
            
            if ( txtTokenNo.Enabled  && txtTokenNo.Text != string.Empty)
                Condition += (Condition == "" ? "" : " AND ") + "doc_number = '" + txtTokenNo.Text + "'";
            if (RegistryDatePicker.Enabled)
                Condition += (Condition == "" ? "" : " AND ") + "registry_date = '" + RegistryDatePicker.Value.Date + "'";           
            if ( cbxDistrict.Enabled && new Guid(cbxDistrict.SelectedValue.ToString()) != Guid.Empty)
                Condition += (Condition == "" ? "" : " AND ") + "district_id = '" + cbxDistrict.SelectedValue.ToString() + "'";
            if (cbxTehsil.Enabled && new Guid(cbxTehsil.SelectedValue.ToString()) != Guid.Empty)
                Condition += (Condition == "" ? "" : " AND ") + "Tehsil_id = N'" + cbxTehsil.SelectedValue.ToString() + "'";
            if (cbxMauza.Enabled && new Guid(cbxMauza.SelectedValue.ToString()) != Guid.Empty)
                Condition += (Condition == "" ? "" : " AND ") + "mauza_id = N'" + cbxMauza.SelectedValue.ToString() + "'";

            if (cbxRegisteryType.Enabled && new Guid(cbxRegisteryType.SelectedValue.ToString()) != Guid.Empty)
                Condition += (Condition == "" ? "" : " AND ") + "Registry_type_id = '" + cbxRegisteryType.SelectedValue.ToString() + "'";
            
            //Concatenate if any condition exists
            if (Condition != "")
                Condition = (" WHERE " + Condition);

            return Condition;
        }
        private void clreaGrid()
        {
            DgvRegistry.Rows.Clear();
        }

        private void RegistrySearchPanel_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string Condition = BuildCondition();
                if (Condition == string.Empty)
                {
                    clreaGrid();
                    MsgStatus.Text = "Search Parameters Not Provided";
                    return;
                }
                else
                {
                    List = obRegistryType.getRegistryTypeWihParams(Condition);
                }
                if (List != null && List.Count > 0)
                {
                    clreaGrid();
                    CreateCellsWithBinding(List);
                }
                else
                {
                    clreaGrid();
                    MsgStatus.Text = "No Registery Found";
                }
            }
            catch (Exception ex)
            {
                MsgStatus.Text = "Some Problem Occured While Searching...";
            }
        }
    }
}
