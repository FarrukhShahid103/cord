using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RD.BLL.Territory;
using RD.EL.Territory;
using System.Collections;
using System.Reflection;
using RD.EL;
using RD.BLL;

namespace RDProject
{
    public partial class ucTerritory : UserControl
    {
        public ucTerritory()
        {
            InitializeComponent();
        }

        private void setSourceLanguage(ComboBox cComboBox, string sEng, string sUrd, string language)
        {
            if (language == "ur")
            {
                cComboBox.DisplayMember = sUrd;    
            }
            else if (language == "en")
            {
                cComboBox.DisplayMember = sEng;
            }
        }

        private void loadDistrict()
        {
            bDistrict obDistrict = new bDistrict();
            List<eDistrict> oeListDistrict = new List<eDistrict>();
            eDistrict oeDistrict = new eDistrict();
            oeListDistrict = obDistrict.GetDistrict(oeDistrict, "", "", 0, 10);
            if (oeListDistrict != null && oeListDistrict.Count > 0)
            {
                setSourceLanguage(cbxDistrict, "district_name_eng", "district_name_urd", frm_MainMDI.language);
                cbxDistrict.ValueMember = "district_id";
                cbxDistrict.DataSource = oeListDistrict;
            }
        }
        
        private void cbxDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid DistrictId = new Guid(cbxDistrict.SelectedValue.ToString());
            if (DistrictId != Guid.Empty)
            {
                loadTehsil(DistrictId);
            }
        }

        private void loadTehsil(Guid DistrictId)
        {
            bTehsil obTehsil = new bTehsil();
            List<eTehsil> oeListTehsil = new List<eTehsil>();
            eTehsil oeTehsil = new eTehsil();
            oeTehsil.District_id = DistrictId;
            oeListTehsil = obTehsil.getTehsil(oeTehsil, "", "", 0, 10);
            if (oeListTehsil.Count > 0)
            {
                setSourceLanguage(cbxTehsil, "tehsil_name_eng", "tehsil_name_urd", frm_MainMDI.language);
                cbxTehsil.ValueMember = "tehsil_id";
                cbxTehsil.DataSource = oeListTehsil;
            }
            else
            {
                cbxTehsil.DataSource = null;
                cbxTehsil.Items.Clear();
            }
        }
        private void cbxTehsil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTehsil.Items.Count > 0)
            {
                Guid TehsilId = ValidateFields.GetSafeGuid(cbxTehsil.SelectedValue);
                if (TehsilId != Guid.Empty)
                {
                    loadMauza(TehsilId);
                }
                else
                {
                    cbxMauza.DataSource = null;
                    cbxMauza.Items.Clear();
                }
            }
        }

        private void loadMauza(Guid TehsilId)
        {
            bMauza obMauza = new bMauza();
            List<eMauza> oeListMauza = new List<eMauza>();
            eMauza oeMauza = new eMauza();
            oeMauza.Tehsil_id = TehsilId;
            oeListMauza = obMauza.getMauza(oeMauza, "", "", 0, 10);
            if (oeListMauza != null && oeListMauza.Count > 0)
            {
                setSourceLanguage(cbxMauza, "mauza_name_eng", "mauza_name_urd", frm_MainMDI.language);
                cbxMauza.ValueMember = "mauza_id";
            }
            cbxMauza.DataSource = oeListMauza;
            if (oeListMauza.Count == 0)
            {
                cbxMauza.Items.Clear();
            }
        }

        private void ucTerritory_Load(object sender, EventArgs e)
        {
            loadDistrict();            
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

        private void cbxMauza_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cbxMauza.SelectedValue.ToString());
        }
    }
}
