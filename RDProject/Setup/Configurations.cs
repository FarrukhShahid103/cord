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
using System.Configuration;

namespace RDProject.Setup
{
    public partial class Configurations : Form
    {
        Guid sDistrict = Guid.Empty;
        Guid sTehsil = Guid.Empty;
        Guid sMauza = Guid.Empty;


        public Configurations()
        {
            InitializeComponent();
        }

        private void loadDistrict()
        {
            bDistrict obDistrict = new bDistrict();
            List<eDistrict> oeListDistrict = new List<eDistrict>();
            eDistrict oeDistrict = new eDistrict();
            oeListDistrict = obDistrict.GetDistrict(oeDistrict, "", "", 0, int.MaxValue);
            AddItem(oeListDistrict, typeof(eDistrict), "District_id", "District_name_eng", "< - SELECT - >");
            if (oeListDistrict != null && oeListDistrict.Count > 0)
            {
                //setSourceLanguage(cbxDistrict, "district_name_eng", "district_name_urd", frm_MainMDI.language);
                cbxDistrict.DisplayMember = "district_name_eng";
                cbxDistrict.ValueMember = "district_id";
                cbxDistrict.DataSource = oeListDistrict;
            }
        }

        private void loadTehsil(Guid DistrictId)
        {
            bTehsil obTehsil = new bTehsil();
            List<eTehsil> oeListTehsil = new List<eTehsil>();
            eTehsil oeTehsil = new eTehsil();
            oeTehsil.District_id = DistrictId;
            oeListTehsil = obTehsil.getTehsil(oeTehsil, "", "", 0, int.MaxValue);
            AddItem(oeListTehsil, typeof(eTehsil), "Tehsil_id", "Tehsil_name_eng", "< - SELECT - >");
            if (oeListTehsil.Count > 0)
            {
                cbxTehsil.DisplayMember = "tehsil_name_eng";
                cbxTehsil.ValueMember = "tehsil_id";
                cbxTehsil.DataSource = oeListTehsil;
                cbxTown.DataSource = null;
                cbxTown.Items.Clear();
                cbxMauza.DataSource = null;
                cbxMauza.Items.Clear();
            }
            else
            {
                cbxTehsil.DataSource = null;
                cbxTehsil.Items.Clear();
            }
        }

        private void loadMauza(Guid Id, bool isTown)
        {
            bMauza obMauza = new bMauza();
            List<eMauza> oeListMauza = new List<eMauza>();
            eMauza oeMauza = new eMauza();
            if (isTown)
            {
                oeMauza.Town_id = Id;
            }
            else
            {
                oeMauza.Tehsil_id = Id;
            }
            oeListMauza = obMauza.getMauza(oeMauza, "", "", 0, int.MaxValue);
            AddItem(oeListMauza, typeof(eMauza), "Mauza_id", "Mauza_name_eng", "< - SELECT - >");
            if (oeListMauza != null && oeListMauza.Count > 0)
            {
                cbxMauza.DisplayMember = "mauza_name_eng";
                cbxMauza.ValueMember = "mauza_id";
            }
            cbxMauza.DataSource = oeListMauza;
            if (oeListMauza.Count == 0)
            {
                cbxMauza.Items.Clear();
            }
        }


        //private void loadDefaultValueDistrict()
        //{
        //    sDistrict = ValidateFields.GetSafeGuid(ConfigurationManager.AppSettings["district"].ToString());
        //    if (sDistrict != Guid.Empty)
        //    {
        //        cbxDistrict.SelectedValue = sDistrict;
        //    }
        //}

        //private void loadDefaultValueTehsil()
        //{
        //    sTehsil = ValidateFields.GetSafeGuid(ConfigurationManager.AppSettings["tehsil"].ToString());
        //    if (sTehsil != Guid.Empty)
        //    {
        //        cbxTehsil.SelectedValue = sTehsil;
        //    }
        //}

        //private void loadDefaultValueMauza()
        //{
        //    sMauza = ValidateFields.GetSafeGuid(ConfigurationManager.AppSettings["mauza"].ToString());
        //    if (sMauza != Guid.Empty)
        //    {
        //        cbxMauza.SelectedValue = sMauza;
        //    }
        //}

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

        private void Configurations_Load(object sender, EventArgs e)
        {
            loadDistrict();
            cbxDistrict.SelectedValue = Variables.defaultDistrict;
            cbxTehsil.SelectedValue = Variables.defaultTehsil;
            cbxTown.SelectedValue = Variables.defaultTown;
            cbxMauza.SelectedValue = Variables.defaultMauza;
            chkIsBioMatric.Checked = ValidateFields.GetSafeBoolean(Variables.ScanningFromApplication);
            chkIsTown.Checked = Variables.isTown;
            chkScanningFromApp.Checked = Variables.ScanningFromApplication;
            if (Variables.defaultTown != Guid.Empty || cbxTown.Items.Count > 1)
                chkIsTown.Enabled = true;
            else
                chkIsTown.Enabled = false;

        }

        private void cbxDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDistrict.Items.Count > 0 && cbxDistrict.SelectedIndex != 0 && cbxDistrict.SelectedIndex != -1)
            {
                Guid DistrictId = new Guid(cbxDistrict.SelectedValue.ToString());
                loadTehsil(DistrictId);
            }
            else
            {
                cbxTehsil.DataSource = null;
                cbxTehsil.Items.Clear();
                cbxTown.DataSource = null;
                cbxTown.Items.Clear();
                cbxMauza.DataSource = null;
                cbxMauza.Items.Clear();
                chkIsTown.Enabled = false;
            }
            //loadDefaultValueDistrict();
        }

        private void cbxTehsil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTehsil.SelectedIndex != 0 && cbxTehsil.Items.Count > 0)
            {
                Guid TehsilId = ValidateFields.GetSafeGuid(cbxTehsil.SelectedValue);
                loadTown(TehsilId);
                //loadMauza(TehsilId);
            }
            else
            {
                cbxTown.DataSource = null;
                cbxTown.Items.Clear();
                cbxMauza.DataSource = null;
                cbxMauza.Items.Clear();
                chkIsTown.Enabled = false;
            }
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
                    cbxMauza.DataSource = null;
                    cbxMauza.Items.Clear();
                    chkIsTown.Enabled = true;
                }
                else
                {
                    cbxTown.DataSource = null;
                    cbxTown.Items.Clear();
                    cbxTown.Enabled = false;
                    loadMauza(TehsilId, false);
                    chkIsTown.Enabled = false;
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
                cbxMauza.DataSource = null;
                cbxMauza.Items.Clear();
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbxDistrict.SelectedIndex <= 0)
            {
                cbxDistrict.Focus();
                lblMsg.Text = "District is missing ...";
                return;
            }
            else if (cbxTehsil.SelectedIndex <= 0)
            {
                cbxTehsil.Focus();
                lblMsg.Text = "Tehsil is missing ...";
                return;
            }
            else if (cbxMauza.SelectedIndex <= 0)
            {
                cbxMauza.Focus();
                lblMsg.Text = "Mauza name is missing ...";
                return;
            }
            //if (cbxTown.SelectedIndex <= 0)
            //{
            //    cbxTown.Focus();
            //    lblMsg.Text = "Town is missing ...";
            //    return;
            //}
            
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("defaultDistrict");
            config.AppSettings.Settings.Add("defaultDistrict", cbxDistrict.SelectedValue.ToString());
            Variables.defaultDistrict = ValidateFields.GetSafeGuid(cbxDistrict.SelectedValue);
            if (cbxTehsil.Items.Count > 1)
            {
                config.AppSettings.Settings.Remove("defaultTehsil");
                config.AppSettings.Settings.Add("defaultTehsil", cbxTehsil.SelectedValue.ToString());
                Variables.defaultTehsil = ValidateFields.GetSafeGuid(cbxTehsil.SelectedValue);
            }
            if (cbxTown.Items.Count > 1)
            {
                config.AppSettings.Settings.Remove("defaultTown");
                config.AppSettings.Settings.Add("defaultTown", cbxTown.SelectedValue.ToString());
                Variables.defaultTown = ValidateFields.GetSafeGuid(cbxTown.SelectedValue);
            }
            if (cbxMauza.Items.Count > 1)
            {
                config.AppSettings.Settings.Remove("defaultMauza");
                config.AppSettings.Settings.Add("defaultMauza", cbxMauza.SelectedValue.ToString());
                Variables.defaultMauza = ValidateFields.GetSafeGuid(cbxMauza.SelectedValue);
            }
            if (chkIsTown.Enabled)
            {
                config.AppSettings.Settings.Remove("isTown");
                config.AppSettings.Settings.Add("isTown", (Convert.ToString(chkIsTown.Checked)).ToLower());
                Variables.isTown = chkIsTown.Checked;
            }
            else
            {
                Variables.isTown = false;
            }
            config.AppSettings.Settings.Remove("isBiometric");
            config.AppSettings.Settings.Add("isBiometric", (Convert.ToString(chkIsBioMatric.Checked)).ToLower());
            Variables.isBiometric = chkIsBioMatric.Checked.ToString().ToLower();

            config.AppSettings.Settings.Remove("scanningFromApplication");
            config.AppSettings.Settings.Add("scanningFromApplication", (Convert.ToString(chkScanningFromApp.Checked)).ToLower());
            Variables.ScanningFromApplication = chkScanningFromApp.Checked;

            config.Save(ConfigurationSaveMode.Minimal);
            lblMsg.Text = "Record has been updated";
        }

        private void Configurations_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnReject_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
