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
using System.Text.RegularExpressions;
using System.Collections;
using System.Reflection;
using RDProject;
using System.IO;
using System.Configuration;
using System.Globalization;

using OutlookStyleControls;
using System.Windows.Forms.VisualStyles;

namespace RDProject.RD
{
    public partial class RegistrationDeedForm : Form
    {

        eRegistryOperations oeRegistryOperations;
        bRegistryOperations obRegistryOperations;
        eRegistryOperations oeGeneralRegistryOperation = new eRegistryOperations();
        private bool NewRecord;
        private Guid RegistryId;
        public bool fromIndexing;
        public bool isInbox = false;
        private string areaValue = string.Empty;
        private string transferedAreaValue = string.Empty;
        private int iThumbStage = 0;
        public int iRegistryStage = 0;
        Guid sDistrict = Guid.Empty;
        Guid sTehsil = Guid.Empty;
        Guid sMauza = Guid.Empty;
        private int feetPerMaralFromMauzaId = 272;
        bool isException;
        string lastvalue;
        private enAreaFormat _areaFormat;
        private Int64 _acre;
        private Int64 _kanal;
        private Int64 _marla;
        private Int64 _feet;
        private Int64 _sarsai;
        private Int64 _yard;
        private short _feetPerMarla;
        private short _tabIndex;
        int bitForSearchImage = 0;

        public enum enAreaFormat
        {
            Acre = 0,
            KanalMarla,
            KanalMarlaFeet,
            KanalMarlaSarsai,
            KanalMarlaYard
        }

        private void SetDefaultCellStyles()
        {
            this.Grid.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8);
            this.grdPersons.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8);
        }


        public RegistrationDeedForm()
        {
            InitializeComponent();
        }


        private void btnScanning_Click(object sender, EventArgs e)
        {
            if (isRegistryIdExist())
            {
                if (Variables.ScanningFromApplication)
                {
                    ScanningForm_English obj = new ScanningForm_English();
                    eRegistryImages oeRegistryImages = new eRegistryImages();
                    List<eRegistryImages> oeListRegistryImages = new List<eRegistryImages>();
                    bRegistryImages obRegistryImages = new bRegistryImages();
                    oeRegistryImages.Registry_id = RegistryId;
                    oeListRegistryImages = obRegistryImages.getRegistryImages(oeRegistryImages, "", "", 0, int.MaxValue);
                    if (oeListRegistryImages != null && oeListRegistryImages.Count > 0)
                    {
                        obj.NewRecord = false;
                    }
                    else
                    {
                        obj.NewRecord = true;
                    }
                    obj.Registry_ID = RegistryId;
                    obj.ShowDialog();

                }
                else
                {
                    ScannedFileUpload_English obj = new ScannedFileUpload_English();
                    eRegistryImages oeRegistryImages = new eRegistryImages();
                    List<eRegistryImages> oeListRegistryImages = new List<eRegistryImages>();
                    bRegistryImages obRegistryImages = new bRegistryImages();
                    oeRegistryImages.Registry_id = RegistryId;
                    oeListRegistryImages = obRegistryImages.getRegistryImages(oeRegistryImages, "", "", 0, int.MaxValue);
                    if (oeListRegistryImages != null && oeListRegistryImages.Count > 0)
                    {
                        obj.NewRecord = false;
                    }
                    else
                    {
                        obj.NewRecord = true;
                    }

                    obj.Registry_ID = RegistryId;
                    obj.ShowDialog();
                }
            }
            else
            {
                MessageDisplay("", true);
            }           
        }

        private bool isRegistryIdExist()
        {
            bool isExist = false; ;
            if (RegistryId != Guid.Empty)
            {
                eRegistryOperations oeRegistryOperations = new eRegistryOperations();
                List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
                bRegistryOperations obRegistryOperations = new bRegistryOperations();
                oeRegistryOperations.Registry_id = RegistryId;
                oeListRegistryOperations = obRegistryOperations.getRegistryOperations(oeRegistryOperations, "", "", 0, int.MaxValue);
                if (oeListRegistryOperations != null && oeListRegistryOperations.Count > 0)
                {
                    isExist = true;
                }
            }
            return isExist;
        }

        private void btnKhasra_Click(object sender, EventArgs e)
        {
            if (isRegistryIdExist())
            {
                Khasra_English obj = new Khasra_English();

                if (iRegistryStage != 0)
                {
                    obj.btnSave.Enabled = false;
                    obj.btnDelete.Enabled = false;
                }
                obj.Registry_No = Convert.ToInt32(txtRegistryNo.Text);
                obj.AreaFormatForExpose = (int)AreaFormat;
                obj.Registry_ID = RegistryId;
                obj.mauzaId = (ValidateFields.GetSafeGuid(cbxMauza.SelectedValue) == Guid.Empty) ? Guid.Empty : ValidateFields.GetSafeGuid(cbxMauza.SelectedValue);
                obj.lblMsg.Text = "Khasra Entry for the registry number : " + txtRegistryNo.Text;
                obj.ShowDialog();
            }
            else
            {
                MessageDisplay("registry not found ...", true);
            }
        }

        private void btnVerifyFard_Click(object sender, EventArgs e)
        {
            if (isRegistryIdExist())
            {
                Fard_English obj = new Fard_English();
                if (iRegistryStage != 0)
                {
                    obj.btnSave.Enabled = false;
                    obj.btnDelete.Enabled = false;
                    obj.btnReport.Enabled = true;
                }
                else
                {
                    obj.btnSave.Enabled = true;
                    obj.btnDelete.Enabled = true;
                }
                obj.registryNo = Convert.ToInt32(txtRegistryNo.Text);
                obj.registryId = RegistryId;
                obj.mauzaId = ValidateFields.GetSafeGuid(cbxMauza.SelectedValue.ToString());
                obj.lblMsg.Text = "Fard entry for the registry number : " + txtRegistryNo.Text;
                obj.ShowDialog();
            }
            else
            {
                MessageDisplay("registry not found ...", true);
            }
        }

        private void loadRegistryType()
        {
            eRegistryType oeRegistryType = new eRegistryType();
            bRegistryType obRegistryType = new bRegistryType();
            List<eRegistryType> oeListRegistryType = new List<eRegistryType>();
            oeListRegistryType = obRegistryType.getRegistryType(oeRegistryType, "", "", 0, int.MaxValue);
            AddItem(oeListRegistryType, typeof(eRegistryType), "Registry_type_id", "Registry_type_description_eng", "< - SELECT - >");
            if (oeListRegistryType != null && oeListRegistryType.Count > 0)
            {
                ddlRegistryType.ValueMember = "Registry_type_id";
                ddlRegistryType.DisplayMember = "Registry_type_description_eng";
                ddlRegistryType.DataSource = oeListRegistryType;
            }
        }

        private int maxRegNo()
        {
            int regNo = -1;
            string strQry = "SELECT ISNULL(MAX(CAST(rd.RegistryOperations.registry_no AS INT)),0)+1 AS MaxReg FROM rd.RegistryOperations WHERE registry_date = '" + DateTime.Parse(txtDate.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-CA")) + "'";
            bRegistryOperations obRegistryOperations = new bRegistryOperations();
            regNo = obRegistryOperations.maxRegNo(strQry);
            return regNo;
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
                cbxDistrict.DisplayMember = "district_name_eng";
                cbxDistrict.ValueMember = "district_id";
                cbxDistrict.DataSource = oeListDistrict;
            }
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
                cbxMauza.DataSource = null;
                cbxMauza.Items.Clear();
            }
        }

   
        private void loadTehsil(Guid DistrictId)
        {
            bTehsil obTehsil = new bTehsil();
            List<eTehsil> oeListTehsil = new List<eTehsil>();
            eTehsil oeTehsil = new eTehsil();
            oeTehsil.District_id = DistrictId;
            oeListTehsil = obTehsil.getTehsil(oeTehsil, "", "", 0, int.MaxValue);
            AddItem(oeListTehsil, typeof(eTehsil),  "Tehsil_id", "Tehsil_name_eng", "< - SELECT - >");
            if (oeListTehsil.Count > 0)
            {
                cbxTehsil.DisplayMember = "tehsil_name_eng";
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
            if (cbxTehsil.SelectedIndex != 0 && cbxTehsil.Items.Count > 0 && cbxTehsil.SelectedIndex != -1)
            {
                Guid TehsilId = ValidateFields.GetSafeGuid(cbxTehsil.SelectedValue);
                if (Variables.isTown && rbUrban.Checked)
                {
                    loadTown(TehsilId);
                }
                else
                {
                    loadMauza(TehsilId);
                }

            }
            else
            {
                cbxTown.DataSource = null;
                cbxTown.Items.Clear();
                cbxMauza.DataSource = null;
                cbxMauza.Items.Clear();
            }
        }

        private void loadTown(Guid TehsilId)
        {
            eTown oeTown = new eTown();
            List<eTown> oeListTown = new List<eTown>();
            bTown obTown = new bTown();
            oeTown.Tehsil_id = TehsilId;
            oeListTown = obTown.getTown(oeTown, "", "", 0, int.MaxValue);
            AddItem(oeListTown, typeof(eTown), "Town_id", "Town_name_eng", "< - SELECT - >");
            if (oeListTown != null && oeListTown.Count > 0)
            {
                cbxTown.DisplayMember = "town_name_eng";
                cbxTown.ValueMember = "town_id";
            }
            cbxTown.DataSource = oeListTown;
        }

        private int GetMauzaAreaFormat(Guid MauzaId)
        {
            int result = -1;
            bMauza obMauza = new bMauza();
            List<eMauza> oeListMauza = new List<eMauza>();
            eMauza oeMauza = new eMauza();
            oeMauza.Mauza_id = MauzaId;
            oeListMauza = obMauza.getMauza(oeMauza, "", "", 0, int.MaxValue);
            if (oeListMauza != null && oeListMauza.Count > 0)
            {
                result = oeListMauza[0].Area_format;
            }
            return result;
        }

        private void loadMauza(Guid id)
        {
            bMauza obMauza = new bMauza();
            List<eMauza> oeListMauza = new List<eMauza>();
            eMauza oeMauza = new eMauza();
            if (Variables.isTown && rbUrban.Checked)
            {
                oeMauza.Town_id = id;
            }
            else
            {
                oeMauza.Tehsil_id = id;
            }
            oeListMauza = obMauza.getMauza(oeMauza, "", "", 0, int.MaxValue);
            AddItem(oeListMauza, typeof(eMauza), "Mauza_id", "Mauza_name_eng", "< - SELECT - >");
            if (oeListMauza != null && oeListMauza.Count > 0)
            {
                cbxMauza.DisplayMember = "mauza_name_eng";
                cbxMauza.ValueMember = "mauza_id";
            }
            cbxMauza.DataSource = oeListMauza;
            //ddlAreaFormat.SelectedIndex = oeListMauza[0].Area_format;
            ddlAreaFormat.SelectedIndex = 2;
            if (oeListMauza.Count == 0)
            {
                cbxMauza.Items.Clear();
            }
        }

        private void cbxTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlTown.Visible)
            {
                if (cbxTown.SelectedIndex != 0 && cbxTown.Items.Count > 0 && cbxTown.SelectedIndex != -1)
                {
                    Guid TownId = ValidateFields.GetSafeGuid(cbxTown.SelectedValue);
                    loadMauza(TownId);
                }
            }
        }

        private void MessageDisplay(string sMessage, bool isSuccess)
        {
            lblMsg.Text = sMessage;
            if (isSuccess)
                lblMsg.ForeColor = Color.SteelBlue;
            else
            {
                lblMsg.ForeColor = Color.Red;                
            }
        }

        private bool validateRegField()
        {
            bool temp = true;
            Guid DistrictId = ValidateFields.GetSafeGuid(cbxDistrict.SelectedValue);
            if (DistrictId == Guid.Empty)
            {
                MessageDisplay("District must have a value..", false);
                cbxDistrict.Focus();
                temp = false;
                return temp;
            }

            Guid TehsilId = ValidateFields.GetSafeGuid(cbxTehsil.SelectedValue);
            if (TehsilId == Guid.Empty)
            {
                MessageDisplay("Tehsil must have a value..", false);
                cbxTehsil.Focus();
                temp = false;
                return temp;
            }

            Guid MauzaId = ValidateFields.GetSafeGuid(cbxMauza.SelectedValue);
            if (MauzaId == Guid.Empty)
            {
                MessageDisplay("Mauza must have a value..", false);
                cbxMauza.Focus();
                temp = false;
                return temp;
            }

            Guid RegistryType = ValidateFields.GetSafeGuid(ddlRegistryType.SelectedValue);
            if (RegistryType == Guid.Empty)
            {
                MessageDisplay("Registry Type must have a value..", false);
                ddlRegistryType.Enabled = true;
                ddlRegistryType.Focus();
                temp = false;
                return temp;
            }
            return temp;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateRegField())
            {
                obRegistryOperations = new bRegistryOperations();
                oeRegistryOperations = new eRegistryOperations();
                updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
                int isUrban = -1;
                if (!NewRecord)
                {
                    if(iRegistryStage == 0 || iRegistryStage == 1)
                    {
                        oeRegistryOperations.Registry_id = oeGeneralRegistryOperation.Registry_id;
                        oeRegistryOperations.Mauza_id = oeGeneralRegistryOperation.Mauza_id;
                        oeRegistryOperations.Service_centre_id = null;
                        oeRegistryOperations.Subregistrar_id = null;
                        oeRegistryOperations.Registry_type_id = new Guid(ddlRegistryType.SelectedValue.ToString());
                        oeRegistryOperations.Commission_type = cbxBy.SelectedIndex;
                        oeRegistryOperations.Registry_no = txtRegistryNo.Text.Trim();
                        oeRegistryOperations.Registry_date = oeGeneralRegistryOperation.Registry_date;
                        oeRegistryOperations.Registery_stage = iRegistryStage;
                        oeRegistryOperations.Bahi_no = txtBahiNumber.Text.Trim();
                        oeRegistryOperations.Jild_no = txtJildNumber.Text.Trim();
                        oeRegistryOperations.Doc_number = txtDocumentNumber.Text.Trim();
                        oeRegistryOperations.Tma_fee = oeGeneralRegistryOperation.Tma_fee;
                        oeRegistryOperations.Challan_fee = oeGeneralRegistryOperation.Challan_fee;
                        oeRegistryOperations.Selling_price = oeGeneralRegistryOperation.Selling_price;
                        oeRegistryOperations.Amount = Convert.ToInt32(txtAmount.Text.Trim());
                        oeRegistryOperations.Registry_fee = Convert.ToInt32(txtRegistrationFee.Text.Trim());
                        oeRegistryOperations.District_council_fee = Convert.ToInt32(txtDistrictFee.Text.Trim());
                        oeRegistryOperations.Mutation_Fee = Convert.ToInt32(txtMutationFee.Text.Trim());
                        oeRegistryOperations.Cvt = Convert.ToInt32(txtCVT.Text.Trim());
                        oeRegistryOperations.Stamp_Duty = Convert.ToInt32(txtStampDuty.Text.Trim());
                        oeRegistryOperations.Is_active = oeGeneralRegistryOperation.Is_active;
                        oeRegistryOperations.Remarks = oeGeneralRegistryOperation.Remarks;
                        oeRegistryOperations.Is_urban = oeGeneralRegistryOperation.Is_urban;
                        oeRegistryOperations.User_id = Variables.UserId;
                        oeRegistryOperations.Access_datetime = DateTime.Now;

                        insertInfo = obRegistryOperations.udpateRegistryOperations(oeRegistryOperations);
                        if (insertInfo.Success)
                        {
                            MessageDisplay("Registry Updated", true);
                            Grid.Enabled = true;
                            if (iRegistryStage == 0)
                            {
                               
                            }
                        }
                        else
                        {

                            MessageDisplay("Registry not updated۔", false);
                        }
                    }
                    else
                    {
                        MessageDisplay("No Change in Registry", false);
                    }
                }
                else
                {

                    if (rbUrban.Checked)
                    {
                        isUrban = 1;
                    }
                    else
                    {
                        isUrban = 0;
                    }
                    if (RegistryId == null || RegistryId == new Guid()) RegistryId = Guid.NewGuid();

                    oeRegistryOperations.Registry_id = RegistryId;
                    if (ValidateFields.GetSafeGuid(cbxMauza.SelectedValue) == Guid.Empty)
                        oeRegistryOperations.Mauza_id = null;
                    else
                        oeRegistryOperations.Mauza_id = ValidateFields.GetSafeGuid(cbxMauza.SelectedValue);
                    oeRegistryOperations.Service_centre_id = null;
                    oeRegistryOperations.Subregistrar_id = null;
                    oeRegistryOperations.Registery_stage = 0;
                    oeRegistryOperations.Registry_type_id = new Guid(ddlRegistryType.SelectedValue.ToString());
                    oeRegistryOperations.Commission_type = cbxBy.SelectedIndex;
                    oeRegistryOperations.Registry_no = txtRegistryNo.Text.Trim();
                    oeRegistryOperations.Registry_date = DateTime.Parse(txtDate.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-CA"));
                    oeRegistryOperations.Bahi_no = txtBahiNumber.Text.Trim();
                    oeRegistryOperations.Jild_no = txtJildNumber.Text.Trim();
                    oeRegistryOperations.Doc_number = txtDocumentNumber.Text.Trim();
                    oeRegistryOperations.Registry_fee = (string.IsNullOrEmpty(txtRegistrationFee.Text) ? 0 : Convert.ToInt32(txtRegistrationFee.Text.Trim()));
                    oeRegistryOperations.Tma_fee = null;
                    oeRegistryOperations.District_council_fee = (string.IsNullOrEmpty(txtDistrictFee.Text) ? 0 : Convert.ToInt32(txtDistrictFee.Text.Trim()));
                    oeRegistryOperations.Mutation_Fee = (string.IsNullOrEmpty(txtMutationFee.Text) ? 0 : Convert.ToInt32(txtMutationFee.Text.Trim()));
                    oeRegistryOperations.Cvt = (string.IsNullOrEmpty(txtCVT.Text) ? 0 : Convert.ToInt32(txtCVT.Text.Trim()));
                    oeRegistryOperations.Stamp_Duty = (string.IsNullOrEmpty(txtStampDuty.Text) ? 0 : Convert.ToInt32(txtStampDuty.Text.Trim()));
                    oeRegistryOperations.Challan_fee = null;
                    oeRegistryOperations.Selling_price = null;
                    oeRegistryOperations.Amount = ValidateFields.GetSafeInteger(txtAmount.Text.Trim());
                    oeRegistryOperations.Is_active = true;
                    oeRegistryOperations.Remarks = "";
                    oeRegistryOperations.Is_urban = isUrban;

                    oeRegistryOperations.User_id = Variables.UserId;
                    oeRegistryOperations.Access_datetime = DateTime.Now;
                    insertInfo = obRegistryOperations.insertRegistryOperations(oeRegistryOperations);
                    if (insertInfo.Success)
                    {
                        //AddPerson();
                        MessageDisplay("Registry Saved successfully!!", true);
                        Grid.Enabled = true;
                        cbxPartyType.Focus();
                        btnSave.Enabled = false;
                        btnKhasra.Enabled = true;
                        btnVerifyFard.Enabled = true;
                        btnSentToSR.Visible = true;
                        btnSentToSR.Enabled = true;
                        btnPrint.Enabled = true;
                        btnPrint.Visible = true;
                        if (Variables.isTown) { btnPlot.Visible = true; btnPlot.Enabled = true; }
                        btnSearchPerson.Enabled = true;

                        ddlRegistryType.Enabled = false;
                        pnlLeft.Visible = false;
                        btnShowPanel.Text = "Show Panel";
                    }
                    else
                    {
                        MessageDisplay("Registry not Saved", false);
                    }
                }
            }
        }
   
        private void fillCasteComboBox(DataGridView grd)
        {
            bCaste obCaste = new bCaste();
            eCaste oeCaste = new eCaste();
            List<eCaste> oeListCaste = new List<eCaste>();
            oeListCaste = obCaste.getCaste(oeCaste, "", "", 0, int.MaxValue);
            AddItem(oeListCaste, typeof(eCaste), "Caste_id", "Caste_name_eng", "< - SELECT - >");
            if (oeListCaste != null && oeListCaste.Count > 0)
            {
                ((DataGridViewComboBoxColumn)grd.Columns["cCaste"]).DataSource = oeListCaste;
                ((DataGridViewComboBoxColumn)grd.Columns["cCaste"]).DisplayMember = "Caste_name_eng";
                ((DataGridViewComboBoxColumn)grd.Columns["cCaste"]).ValueMember = "Caste_id";
            }
        }

        private void fillDesignationCombBox()
        {
            List<Variables.desi> oDesi = new List<Variables.desi>();
            Array itemValues = System.Enum.GetValues(typeof(Variables.Designation_eng));
            for (int i = 0; i < itemValues.Length; i++)
            {
                Variables.desi objDes = new Variables.desi();
                objDes.DesignVal = i + 1;
                objDes.DesignData = ((RDProject.Variables.Designation_eng[])(itemValues))[i].ToString();
                oDesi.Add(objDes);
            }
            if (oDesi != null && oDesi.Count > 0)
            {
                ((DataGridViewComboBoxColumn)Grid.Columns["cDesignation"]).DataSource = oDesi;
                ((DataGridViewComboBoxColumn)Grid.Columns["cDesignation"]).DisplayMember = "DesignData";
                ((DataGridViewComboBoxColumn)Grid.Columns["cDesignation"]).ValueMember = "DesignVal";
            }
        }

        private void fillColumnGridOfRegistryInfo()
        {
            DataGridViewTextBoxColumn dgvRegistryId = new DataGridViewTextBoxColumn();
            dgvRegistryId.Name = "colRegistryId";
            dgvRegistryId.Visible = false;

            DataGridViewTextBoxColumn dgvMauzaId = new DataGridViewTextBoxColumn();
            dgvMauzaId.Name = "colMauzaId";
            dgvMauzaId.Visible = false;

            DataGridViewTextBoxColumn dgvRegistryStage = new DataGridViewTextBoxColumn();
            dgvRegistryStage.Name = "colRegistryStage";
            dgvRegistryStage.Visible = false;

            DataGridViewTextBoxColumn dgvRegistryNo = new DataGridViewTextBoxColumn();
            dgvRegistryNo.HeaderText = "Registry No";
            dgvRegistryNo.Name = "colRegistryNo";

            DataGridViewTextBoxColumn dgvDate = new DataGridViewTextBoxColumn();
            dgvDate.HeaderText = "Date";
            dgvDate.Name = "colDate";

            DataGridViewTextBoxColumn dgvAmount = new DataGridViewTextBoxColumn();
            dgvAmount.HeaderText = "Amount";
            dgvAmount.Name = "colAmount";

            DataGridViewTextBoxColumn dgvRemarks = new DataGridViewTextBoxColumn();
            dgvRemarks.HeaderText = "Remarks";
            dgvRemarks.Name = "colRemarks";
            
        }

        private void BindColumnGridOfRegistryInfo()
        {
            eRegistryType oeRegistryType = new eRegistryType();
            List<eRegistryType> oeListRegistryType = new List<eRegistryType>();
            bRegistryType obRegistryType = new bRegistryType();            
            
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void RegistrationDeedForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (Grid.Focused) return;
                Control ctl;
                ctl = (Control)sender;
                ctl.SelectNextControl(ActiveControl, true, true, true, true);
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (Variables.roleName.ToUpper() == "SR")
                {
                    this.Close();
                }

                if (txtRegistryNo.Focused)
                {
                    this.Close();
                }
                else
                {
                    txtRegistryNo.Enabled = true;
                    txtRegistryNo.Select();
                    txtRegistryNo.Focus();
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

        private void txtRegistryNo_Enter(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 0)
            {
                Grid.Rows.Clear();
            }
            Grid.Enabled = false;
            cbxBy.SelectedIndex = 0;
            loadDistrict();
            pnlLeft.Visible = true;
            lblMsg.Text = string.Empty;
            NewRecord = true;
            txtDate.ResetText();
           loadRegistryType();
            ddlRegistryType.SelectedIndex = 0;
            if (!cbxDistrict.Enabled)
            {
                cbxDistrict.Enabled = true;
            }
            if (!cbxTehsil.Enabled)
            {
                cbxTehsil.Enabled = true;
            }
            if (!cbxMauza.Enabled)
            {
                cbxMauza.Enabled = true;
            }
            txtAmount.Text = "0";
            txtDocumentNumber.Text = string.Empty;
            txtBahiNumber.Text = string.Empty;
            txtJildNumber.Text = string.Empty;
            txtMutationFee.Clear();
            txtCVT.Clear();
            txtStampDuty.Clear();
            txtDistrictFee.Clear();
            txtRegistrationFee.Clear();
            btnScanning.Enabled = false;
            btnKhasra.Enabled = false;
            btnVerifyFard.Enabled = false;
            btnSearchPerson.Enabled = false;
            btnSentToSR.Visible = false;
            btnSentToSCI.Visible = false;
            btnSave.Text = "&Save";
            btnShowPanel.Text = "Hide Panel";
            btnSave.Enabled = false;
            txtRegistryNo.Enabled = true;
            gbxUrbanRural.Enabled = true;
            pnlBasicInfoMiddle.Visible = false;
            pnlBasicInfoBottom.Enabled = true;
            txtAmount.Enabled = true;
            
            NewRecord = true;
            loadRegistryType();
            if (checkCurrentDate())
            {
                txtRegistryNo.Text = maxRegNo().ToString();
            }
            else
            {
                txtRegistryNo.Clear();
            }
            pnlBasicInfoMiddle.Visible = false;

            btnSave.Enabled = false;
            btnDelete.Enabled = false;

            btnScanning.Visible = false;

            btnPrint.Visible = false;
            btnSearch.Visible = false;
            
            btnKhasra.Visible = true;
            btnKhasra.Enabled = false;
            btnVerifyFard.Visible = true;
            btnVerifyFard.Enabled = false;

            btnPlot.Visible = false;
            btnPlot.Enabled = false;
            btnSentToSR.Visible = false;
            btnSentToSR.Enabled = false;
            btnSentToSCI.Visible = false;
            btnSentToSCI.Enabled = false;

            iRegistryStage = 0;


            cbxDistrict.SelectedValue = Variables.defaultDistrict;
            cbxTehsil.SelectedValue = Variables.defaultTehsil;           
            cbxTown.SelectedValue = Variables.defaultTown;
            if (!Variables.isTown)
                loadMauza(Variables.defaultTehsil);
            else if (Variables.isTown)
                loadMauza(Variables.defaultTown);
            cbxMauza.SelectedValue = Variables.defaultMauza;
            if (Variables.defaultMauza != null && Variables.defaultMauza != Guid.Empty)
            {
                ddlAreaFormat.SelectedIndex = 2; // GetMauzaAreaFormat(Variables.defaultMauza);
            }

            btnSave.Enabled = true;
            isException = false;
            pnlLeft.Visible = true;
            pnlSearchPerson.Visible = false;
            pnlRegistryPerson.Visible = true;
            pnlRegistryPerson.Dock = DockStyle.Fill;
            Grid.DataSource = null;
            Grid.Rows.Clear();
        }

        private void RegistrationDeedForm_Load(object sender, EventArgs e)
        {
            fillColumnPersonGrid();
            pnlRegistryPerson.Dock = DockStyle.Fill;
            //Grid.Dock = DockStyle.Fill;
            //pnlCommands.Visible = true;
            fillColumnGridOfRegistryInfo();
            pnlBasicInfoMiddle.Visible = false;
            btnNewRegistry.Visible = true;
            btnSearchPerson.Enabled = true;
            rbRural_CheckedChanged(sender, e);
            txtRegistryNo.Focus();
            fillCasteComboBox(Grid);
            fillCasteComboBox(grdPersons);
            fillDesignationCombBox();
        }

        private void loadTerritoryFromMauza(Guid MauzaID, bool isUrban)
        {
            bTerritoryWithMauza obTerritoryWithMauza = new bTerritoryWithMauza();
            List<eTerritoryWithMauza> oeListTerritory = new List<eTerritoryWithMauza>();
            eTerritoryWithMauza oTerritoryWithMauza = new eTerritoryWithMauza();
            oTerritoryWithMauza.Mauza_id = MauzaID;
            if (isUrban)
            {
                oeListTerritory = obTerritoryWithMauza.getTerritoryWithMauzaTown(oTerritoryWithMauza, "", "", 0, int.MaxValue);
                if (oeListTerritory != null && oeListTerritory.Count > 0)
                {
                    cbxTown.DisplayMember = "town_name_eng";
                    cbxTown.ValueMember = "town_id";
                    cbxTown.DataSource = oeListTerritory;
                }
            }
            else
            {
                oeListTerritory = obTerritoryWithMauza.getTerritoryWithMauza(oTerritoryWithMauza, "", "", 0, int.MaxValue);
            }

            if (oeListTerritory != null && oeListTerritory.Count == 0)
            {
                oeListTerritory = obTerritoryWithMauza.getTerritoryWithMauza(oTerritoryWithMauza, "", "", 0, int.MaxValue);
            }
            if (oeListTerritory != null && oeListTerritory.Count > 0)
            {
                cbxDistrict.DisplayMember = "district_name_eng";
                cbxDistrict.ValueMember = "district_id";
                cbxDistrict.DataSource = oeListTerritory;
                
                cbxTehsil.DisplayMember = "tehsil_name_eng";
                cbxTehsil.ValueMember = "tehsil_id";
                cbxTehsil.DataSource = oeListTerritory;

                cbxTown.DisplayMember = "town_name_eng";
                cbxTown.ValueMember = "town_id";
                cbxTown.DataSource = oeListTerritory;

                cbxMauza.DisplayMember = "mauza_name_eng";
                cbxMauza.ValueMember = "mauza_id";
                cbxMauza.DataSource = oeListTerritory;
            }
            else
            {
                cbxTehsil.DataSource = null;
                cbxTehsil.Items.Clear();
            }
        }

        private int checkRegistryStage(Guid regId)
        {
            int regStage = -1;
            eRegistryOperations oeRegistryOperations = new eRegistryOperations();
            List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
            bRegistryOperations obRegistryOperations = new bRegistryOperations();
            oeRegistryOperations.Registry_id = regId;
            oeListRegistryOperations = obRegistryOperations.getRegistryOperations(oeRegistryOperations, "", "", 0, int.MaxValue);
            if (oeListRegistryOperations != null && oeListRegistryOperations.Count == 1)
            {
                regStage = oeListRegistryOperations[0].Registery_stage.Value;
            }
            else if(oeListRegistryOperations != null && oeListRegistryOperations.Count > 1)
            {
                MessageDisplay("Please contact administrator", false);
            }
            return regStage;
        }

        private void disableSRField()
        {
            //txtDate.Enabled = false;
            cbxTehsil.Enabled = false;
            cbxDistrict.Enabled = false;
            cbxMauza.Enabled = false;
            txtAmount.Enabled = false;
            txtMutationFee.Enabled = false;
            txtCVT.Enabled = false;
            txtStampDuty.Enabled = false;
            txtDistrictFee.Enabled = false;
            txtRegistrationFee.Enabled = false;
            btnScanning.Enabled = false;
            btnDelete.Enabled = false;
            btnSentToSR.Visible = false;

            txtDocumentNumber.Focus();
        }

        private bool ValidateShare(string Share)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(Share, "^[1-9]+[0-9]*[/][1-9]+[0-9]*$");
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
  
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (isRegistryIdExist())
            {
                SRApprovalForm_English obj = new SRApprovalForm_English();
                obj.registry_stage = 2;
                obj.RegistryId = RegistryId;
                obj.ShowDialog();
            }
            else
            {
                MessageDisplay("Registry not exist, create registry first", false);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (isRegistryIdExist())
            {
                SRApprovalForm_English obj = new SRApprovalForm_English();
                obj.registry_stage = 3;
                obj.RegistryId = RegistryId;
                obj.ShowDialog();
            }
            else
            {
                MessageDisplay("Registry not exist, create registry first", false);
            }
        }

        private void txtRegistryNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)'-')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void ddlRegistryType_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (ddlRegistryType.SelectedIndex != 0)
            {
                Guid registryTypeId = ValidateFields.GetSafeGuid(ddlRegistryType.SelectedValue.ToString());
                fillPartyTypeComboBox(registryTypeId);
            }
        }

        private void fillPartyTypeComboBox(Guid registryTypeId)
        {
            if (cbxPartyType.Items.Count > 0)
            {
                cbxPartyType.DataSource = null;
                cbxPartyType.Items.Clear();
            }
            ePartyType oePartyType = new ePartyType();
            List<ePartyType> oeListPartyType = new List<ePartyType>();
            List<ePartyType> oeListPartyTypeCopy = new List<ePartyType>();

            bPartyType obPartyType = new bPartyType();
            if (registryTypeId != Guid.Empty)
            {
                oePartyType.Registry_type_id = registryTypeId;
                oeListPartyType = obPartyType.getPartyType(oePartyType, "", "", 0, int.MaxValue);
                AddItem(oeListPartyType, typeof(ePartyType), "Party_type_id", "Party_name_eng", "< - SELECT - >");
                if (oeListPartyType != null && oeListPartyType.Count > 0)
                {
                    cbxPartyType.DataSource = oeListPartyType;
                    cbxPartyType.DisplayMember = "party_name_eng";
                    cbxPartyType.ValueMember = "party_type_id";
                    cbxPartyType.SelectedIndex = 0;
                }
                if (oeListPartyType.Count > 1)
                {
                    cbxPartyType.SelectedIndex = 1;
                }
                else
                {
                    cbxPartyType.SelectedIndex = 0;
                }
            }
            if (cbxBy.SelectedIndex != 0 && cbxBy.Text.Contains("Commission"))
            {
                for (int i = 0; i < cbxPartyType.Items.Count; i++)
                {
                    if (((ePartyType)(cbxPartyType.Items[i])).Party_name_eng.Contains("POA"))
                    {
                        oeListPartyType.RemoveAt(i);
                        cbxPartyType.DataSource = null;
                        cbxPartyType.Items.Clear();
                        cbxPartyType.DataSource = oeListPartyType;
                        cbxPartyType.DisplayMember = "Party_name_eng";
                        cbxPartyType.ValueMember = "party_type_id";
                        break;
                    }
                }
            }
            else if (cbxBy.SelectedIndex != 0 && cbxBy.Text.Contains("POA"))
            {
                for (int i = 0; i < cbxPartyType.Items.Count; i++)
                {
                    if (((ePartyType)(cbxPartyType.Items[i])).Party_name_eng.Contains("Commission"))
                    {
                        oeListPartyType.RemoveAt(i);
                        cbxPartyType.DataSource = null;
                        cbxPartyType.Items.Clear();
                        cbxPartyType.DataSource = oeListPartyType;
                        cbxPartyType.DisplayMember = "Party_name_eng";
                        cbxPartyType.ValueMember = "party_type_id";
                        break;
                    }
                }
            }
            else if (cbxBy.SelectedIndex != 0 && cbxBy.Text.Contains("Party"))
            {
                foreach (ePartyType EPT in oeListPartyType)
                {
                    if (EPT.Party_name_eng.Contains("Commission") || EPT.Party_name_eng.Contains("POA"))
                    {
                    }
                    else
                    {
                        oeListPartyTypeCopy.Add(EPT);
                    }
                }
                cbxPartyType.DataSource = null;
                cbxPartyType.Items.Clear();
                cbxPartyType.DataSource = oeListPartyTypeCopy;
                cbxPartyType.DisplayMember = "Party_name_eng";
                cbxPartyType.ValueMember = "party_type_id";
            }
        }

        private void btnViewScanImage_Click(object sender, EventArgs e)
        {
            if (isRegistryIdExist())
            {
                eRegistryImages oeRegistryImages = new eRegistryImages();
                List<eRegistryImages> oeListRegistryImages = new List<eRegistryImages>();
                bRegistryImages obRegistryImages = new bRegistryImages();
                ScanningForm_English obj = new ScanningForm_English();
                obj.Registry_ID = RegistryId;
                obj.NewRecord = false;
                obj.ShowDialog();
            }
            else
            {
                MessageDisplay("Registry not exist, please create registry first", true);
            }
        }
        
        private void btnNewRegistry_Click(object sender, EventArgs e)
        {
            txtRegistryNo.Enabled = true;
            txtRegistryNo_Enter(sender, e);
            txtRegistryNo.Focus();
            txtDate.ResetText();
            btnSave.Enabled = true;
            
        }

        private void btnSentToSR_Click(object sender, EventArgs e)
        {
            eRegistryOperations oeRegistryOperations = new eRegistryOperations();
            bRegistryOperations obRegistryOperations = new bRegistryOperations();
            updatedNewEntryInfo info = new updatedNewEntryInfo();
            oeRegistryOperations.Registry_id = RegistryId;
            oeRegistryOperations.Registery_stage = 1;
            info = obRegistryOperations.UpdateRegistryOperationsStage(oeRegistryOperations);
            if (info.Success)
            {
                MessageDisplay("Registry send to Sub Registrar", true);
                txtRegistryNo_Enter(sender, e);
                //txtRegistryNo.Enabled = true;
                //txtRegistryNo.Focus();
                pnlLeft.Visible = true;
                pnlSearchPerson.Visible = false;
                pnlRegistryPerson.Visible = true;
                pnlRegistryPerson.Dock = DockStyle.Fill;
                Grid.DataSource = null;
                Grid.Rows.Clear();
            }
            else
            {
                MessageDisplay("Registry not send to Sub Registrar, please contact administration", false);
            }
        }

        private void btnDefer_Click(object sender, EventArgs e)
        {
            if (isRegistryIdExist())
            {
                SRApprovalForm_English obj = new SRApprovalForm_English();
                obj.registry_stage= 4;
                obj.RegistryId = RegistryId;
                obj.ShowDialog();
            }
            else
            {
                MessageDisplay("Registry not exist, create registry first", false);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RegistrySearchPanel obj = new RegistrySearchPanel();
            obj.Show();
        }

        private bool checkCurrentDate()
        {
            bool isMatch = false;
            if (DateTime.Now.Date == DateTime.Parse(txtDate.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-CA")).Date)
            {
                isMatch = true;
            }
            return isMatch;
        }

        private List<eRegistryImages> GetRegistryImage()
        {
            eRegistryImages oeRegistryImages = new eRegistryImages();
            List<eRegistryImages> oList = new List<eRegistryImages>();
            oeRegistryImages.Registry_id = RegistryId;
            bRegistryImages obRegistryImages = new bRegistryImages();

            oList = obRegistryImages.getRegistryImages(oeRegistryImages, "", "", 1, 2);
            return oList;
        }

        private void btnSentToSCI_Click(object sender, EventArgs e)
        {
            eRegistryOperations oeRegistryOperations = new eRegistryOperations();
            bRegistryLrmisSync obRegistrySyncOperations = new bRegistryLrmisSync();
            updatedNewEntryInfo info = new updatedNewEntryInfo();
            //oeRegistryOperations.Registry_id = RegistryId;
            oeRegistryOperations.Registry_no = txtRegistryNo.Text;
            oeRegistryOperations.User_id = Variables.UserId;
            oeRegistryOperations.Access_datetime = DateTime.Now;
            //oeRegistryOperations.Registery_stage = 5;
            oeRegistryOperations.Jild_no = txtJildNumber.Text;
            oeRegistryOperations.Bahi_no = txtBahiNumber.Text;
            oeRegistryOperations.Registery_stage = 1;
            if (GetRegistryImage().Count > 0)
            {
                oeRegistryOperations.Image_file = ValidateFields.GetSafeByte(GetRegistryImage()[0].Image_file);
            }
            else
            {
                oeRegistryOperations.Image_file = null;
            }
            oeRegistryOperations.RegistryDescription = ddlRegistryType.Text;
            info = obRegistrySyncOperations.InsertLrmisRegistrySync(oeRegistryOperations, "lrmis");
            if (info.Success)
            {
                oeRegistryOperations = new eRegistryOperations();
                obRegistryOperations = new bRegistryOperations();
                oeRegistryOperations.Registry_id = RegistryId;
                oeRegistryOperations.Registery_stage = 2;
                info = obRegistryOperations.UpdateRegistryOperationsStage(oeRegistryOperations);
                if (info.Success)
                {
                    MessageDisplay("Registry sent to SCI", true);
                    txtRegistryNo.Enabled = true;
                    txtRegistryNo.Focus();
                }
                else
                {
                    MessageDisplay("Registry not send to SCI with stage, please contact administration", false);
                }
            }
            else
            {
                MessageDisplay("Registry not send to SCI, please contact administration", false);
            }
        }

        private void btnRegisterThumb_Click(object sender, EventArgs e)
        {
            //MessageDisplay("", false);            
            //if (btnRegisterThumb.Text.ToLower() == "register")
            //{
            //    iThumbStage = 1;
            //    Init();
            //    Start();
            //    OnTemplate += new OnTemplateEventHandler(RegistrationDeedForm_OnTemplate);
            //}
            //else if (btnRegisterThumb.Text.ToLower() == "verify")
            //{
            //    iThumbStage = 2;
            //    Init();
            //    Start();
            //}
        }

        private void rbUrban_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUrban.Checked)
            {
                lblDistCouncilFee.Text = "Corporation Fee.:";
                if (!Variables.isTown)
                {
                    pnlTown.Visible = false;
                }
                else
                {
                    pnlTown.Visible = true;
                    btnPlot.Visible = true;
                }
            }
        }

        private void rbRural_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRural.Checked)
            {
                lblDistCouncilFee.Text = "Dist. Council Fee.:";
                pnlTown.Visible = false;
                btnPlot.Visible = false;
            }
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            if (isRegistryIdExist())
            {
                Plot_English obj = new Plot_English();
                if (iRegistryStage != 0)
                {
                    obj.btnSave.Enabled = false;
                    obj.btnDelete.Enabled = false;
                }
                obj.RegistryId = RegistryId;
                obj.ShowDialog();
            }
            else
            {
                MessageDisplay("Registry not exist", false);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReportSample obj = new ReportSample();
            obj.registryId = RegistryId;
            obj.Show();
            
        }

        private void txtDocumentNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtBahiNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtJildNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtRegistryNo_Validated(object sender, EventArgs e)
        {
            checkCurrentDate();
            Variables.SetCue(txtDate, "Please enter existing Tokan #");
        }

        public void txtDate_Leave(object sender, EventArgs e)
        {
            txtRegistryNo.Enabled = false;
            if (!string.IsNullOrEmpty(txtRegistryNo.Text) && Convert.ToInt32(txtRegistryNo.Text) != 0)
            {
                string strQry = "SELECT * FROM rd.RegistryOperations WHERE registry_no = '" + txtRegistryNo.Text.Trim() + "' AND registry_date = '" + DateTime.Parse(txtDate.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-CA")) + "' AND is_active = 1";
                bRegistryOperations obRegistryOperations = new bRegistryOperations();
                List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
                oeListRegistryOperations = obRegistryOperations.searchRegistryNo(strQry);
                if (oeListRegistryOperations != null && oeListRegistryOperations.Count == 1)
                {
                    MessageDisplay("Record found and loading ....", true);
                    //pnlLeft.Visible = false;
                    Grid.Enabled = true;
                    Grid.Focus();
                    //btnShowPanel.Text = "Show Panel";
                    NewRecord = false;
                    rbRural.Enabled = false;
                    rbUrban.Enabled = false;

                    iRegistryStage = (int)oeListRegistryOperations[0].Registery_stage;
                    if (oeListRegistryOperations[0].Registery_stage == 0)
                    {
                        
                        cbxDistrict.Enabled = false;
                        ddlRegistryType.Enabled = false;
                        cbxTehsil.Enabled = false;
                        cbxMauza.Enabled = false;
                        cbxTown.Enabled = false;
                        pnlBasicInfoMiddle.Visible = false;
                        btnSentToSR.Visible = true;
                        btnSentToSR.Enabled = true;
                        btnKhasra.Visible = true;
                        btnKhasra.Enabled = true;
                        btnVerifyFard.Visible = true;
                        btnVerifyFard.Enabled = true;
                        btnSave.Text = "&Update";
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSearchPerson.Enabled = true;
                        btnPrint.Visible = true;
                        btnPrint.Enabled = true;

                    }

                    if (oeListRegistryOperations[0].Registery_stage == 1)
                    {
                        ddlRegistryType.Enabled = false;
                        cbxDistrict.Enabled = false;
                        cbxTehsil.Enabled = false;
                        cbxMauza.Enabled = false;
                        cbxTown.Enabled = false;
                        pnlBasicInfoBottom.Enabled = false;
                        txtAmount.Enabled = false;
                        pnlBasicInfoMiddle.Visible = true;
                        pnlBasicInfoMiddle.Enabled = true;
                        btnSave.Text = "&Update";
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSentToSCI.Visible = true;
                        btnSentToSCI.Enabled = true;
                        btnKhasra.Enabled = true;
                        btnVerifyFard.Enabled = true;
                        btnScanning.Visible = true;
                        btnScanning.Enabled = true;
                        btnPrint.Visible = true;
                        btnPrint.Enabled = true;

                    }

                    if (oeListRegistryOperations[0].Registery_stage == 2)
                    {
                        cbxTehsil.Enabled = false;
                        cbxDistrict.Enabled = false;
                        cbxMauza.Enabled = false;
                        txtAmount.Enabled = false;
                        pnlBasicInfoBottom.Enabled = false;
                        pnlBasicInfoMiddle.Enabled = false;
                        btnSearchPerson.Enabled = false;
                        pnlBasicInfoMiddle.Visible = true;
                        btnKhasra.Enabled = true;
                        btnVerifyFard.Enabled = true;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        btnPrint.Visible = false;
                        btnScanning.Enabled = true;
                        btnSentToSCI.Visible = false;
                        btnPlot.Enabled = false;
                        btnPrint.Visible = true;
                        btnPrint.Enabled = true;

                    }

                    if (oeListRegistryOperations[0].Registery_stage == 5)
                    {
                        MessageDisplay("In Active Record", false);
                        //MessageBox.Show("In Active Record");
                        cbxTehsil.Enabled = false;
                        cbxDistrict.Enabled = false;
                        cbxMauza.Enabled = false;
                        txtAmount.Enabled = false;
                        pnlBasicInfoBottom.Enabled = false;
                        pnlBasicInfoMiddle.Enabled = false;
                        btnSearchPerson.Enabled = false;
                        pnlBasicInfoMiddle.Visible = true;
                        btnKhasra.Enabled = true;
                        btnVerifyFard.Enabled = true;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        btnPrint.Visible = false;
                        btnScanning.Enabled = true;
                        btnSentToSCI.Visible = false;
                        btnPlot.Enabled = false;
                        btnPrint.Visible = true;
                        btnPrint.Enabled = true;
                    }
                    if (oeListRegistryOperations[0].Is_urban == 1)
                    {
                        pnlTown.Visible = true;
                        rbUrban.Checked = true;
                        btnPlot.Visible = true;
                        btnPlot.Enabled = true;
                    }
                    else
                    {
                        pnlTown.Visible = false;
                        rbRural.Checked = true;

                        btnPlot.Visible = false;
                        btnPlot.Enabled = false;

                    }
                    gbxUrbanRural.Enabled = false;
                    txtRegistryNo.Text = oeListRegistryOperations[0].Registry_no;
                    RegistryId = oeListRegistryOperations[0].Registry_id;
                    txtDate.Text = oeListRegistryOperations[0].Registry_date.ToShortDateString();
                    ddlRegistryType.SelectedValue = oeListRegistryOperations[0].Registry_type_id;
                    cbxBy.SelectedIndex = (int)oeListRegistryOperations[0].Commission_type;
                    loadTerritoryFromMauza((Guid)(oeListRegistryOperations[0].Mauza_id), rbUrban.Checked);
                    txtAmount.Text = oeListRegistryOperations[0].Amount.ToString();
                    txtDocumentNumber.Text = oeListRegistryOperations[0].Doc_number.ToString();
                    txtBahiNumber.Text = oeListRegistryOperations[0].Bahi_no.ToString();
                    txtJildNumber.Text = oeListRegistryOperations[0].Jild_no.ToString();
                    txtMutationFee.Text = oeListRegistryOperations[0].Mutation_Fee.ToString();
                    txtCVT.Text = oeListRegistryOperations[0].Cvt.ToString();
                    txtStampDuty.Text = oeListRegistryOperations[0].Stamp_Duty.ToString();
                    txtDistrictFee.Text = oeListRegistryOperations[0].District_council_fee.ToString();
                    txtRegistrationFee.Text = oeListRegistryOperations[0].Registry_fee.ToString();
                    oeGeneralRegistryOperation = oeListRegistryOperations[0];
                    ddlRegistryType.Enabled = false;
                    MessageDisplay("", true);
                    //loadPersonsOnRegistryNo();
                }
                else
                {
                    rbRural.Enabled = true;
                    rbUrban.Enabled = true;
                    iRegistryStage = 0;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                    NewRecord = true;
                    ddlRegistryType.Enabled = true;
                    
                    RegistryId = Guid.NewGuid();
                    cbxDistrict.Enabled = true;
                    cbxTehsil.Enabled = true;
                    cbxTown.Enabled = true;
                    cbxMauza.Enabled = true;
                    btnSave.Text = "&Save";

                    MessageDisplay("New Registry ...", true);
                }
            }
        }

        private void cbxMauza_Leave(object sender, EventArgs e)
        {
            bMauza obMauza = new bMauza();
            List<eMauza> oeListMauza = new List<eMauza>();
            eMauza oeMauza = new eMauza();
            if (Variables.isTown)
            {
                oeMauza.Town_id = (Guid)cbxTehsil.SelectedValue;
            }
            else
            {
                oeMauza.Tehsil_id = (Guid)cbxTehsil.SelectedValue;
            }
        }

        private void RegistrationDeedForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.S)
            {
                if (btnSave.Enabled == true)
                if (btnSave.Text == "&Save") btnSave_Click(sender, e);
            }

            if (e.Alt && e.KeyCode == Keys.N)
            {
                AddPerson();

            }
            if (e.Alt && e.KeyCode == Keys.D)
            {
                // delete here
            }

            if (e.Alt && e.KeyCode == Keys.C)
            {

                if (btnScanning.Enabled == true) btnScanning_Click(sender, e);
            }

            if (e.Alt && e.KeyCode == Keys.F)
            {
                if (btnVerifyFard.Enabled == true) btnVerifyFard_Click(sender, e);
            }

            if (e.Alt && e.KeyCode == Keys.K)
            {
                if (btnKhasra.Enabled == true) btnKhasra_Click(sender, e);
            }

            if (e.Alt && e.KeyCode == Keys.P)
            {
                if (btnPlot.Enabled == true) btnPlot_Click(sender, e);
            }


            if (e.Alt && e.KeyCode == Keys.I)
            {
                if (btnSentToSCI.Enabled == true) btnSentToSCI_Click(sender, e);
            }

            if (e.Alt && e.KeyCode == Keys.H)
            {
                if (btnShowPanel.Enabled == true) btnShowPanel_Click(sender, e);

            }
            if (e.Alt && e.KeyCode == Keys.A)
            {
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
             var result = MessageBox.Show("Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
             if (result == System.Windows.Forms.DialogResult.Yes)
             {
                 eRegistryOperations oeRegistryOperations = new eRegistryOperations();
                 bRegistryOperations obRegistryOperations = new bRegistryOperations();
                 updatedNewEntryInfo info = new updatedNewEntryInfo();
                 oeRegistryOperations.Registry_id = RegistryId;
                 oeRegistryOperations.Registery_stage = 5;
                 oeGeneralRegistryOperation.Is_active = false;
                 oeRegistryOperations.Remarks = "Blocked";

                 info = obRegistryOperations.UpdateRegistryOperationsStage(oeRegistryOperations);
                 if (info.Success)
                 {
                     MessageDisplay("Record is Blocked", true);
                 }

                 txtRegistryNo.Enabled = true;
                 txtRegistryNo.Focus();
             }
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            Camera_English obj = new Camera_English();
            obj.ShowDialog();
        }

        private void btnShowPanel_Click(object sender, EventArgs e)
        {
            if (!pnlLeft.Visible)
            {
                btnShowPanel.Text = "Hide Panel";
                pnlLeft.Visible = true;
                return;
            }
            else if (pnlLeft.Visible)
            {
                btnShowPanel.Text = "Show Panel";
                pnlLeft.Visible = false;
                return;
            }
        }

        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                e.Value = "Save";
            }

            if (e.ColumnIndex == 15)
            {
                e.Value = "Delete";
            }


            else if (e.ColumnIndex == 16)
            {
                e.Value = "Picture";
            }
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 16)
            {
                CameraPupop();
            }
            if (e.ColumnIndex == 15)
            {
                personRecordDelete();
            }

            if (e.ColumnIndex == 14)
            {
                personRecordSaveUpdate(e.RowIndex, e.ColumnIndex);
            }
        }

        private void CameraPupop()
        {
            Camera_English obj = new Camera_English();
            obj.personid = ValidateFields.GetSafeGuid(Grid.Rows[Grid.CurrentCellAddress.Y].Cells["cPersonID"].Value);
            if (obj.personid != Guid.Empty && Grid.Rows[Grid.CurrentCellAddress.Y].Cells["ccnic"].Value != null)
            {
                obj.lblMsg.Text = "Picture & Thumb Impressions for the Person Name : " + Grid.Rows[Grid.CurrentCellAddress.Y].Cells["cFirstName"].Value.ToString() + " CNIC : " + Grid.Rows[Grid.CurrentCellAddress.Y].Cells["ccnic"].Value.ToString();
                obj.ShowDialog();
            }
            else
            {
                obj.lblMsg.Text = "Please save person";
            }
        }

        private void personRecordDelete()
        {
            var result = MessageBox.Show("Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (this.Grid.SelectedCells.Count > 0)
                {
                    eRegistryPerson oeregistryperson = new eRegistryPerson();
                    updatedNewEntryInfo info = new updatedNewEntryInfo();
                    DataGridViewRow R = Grid.Rows[Grid.SelectedCells[0].RowIndex];
                    if (R.Cells["cPersonId"].Value == null)
                    {
                        return;
                    }
                    oeregistryperson.Registryperson_id = (Guid)R.Cells["cRegistryPersonID"].Value;

                    bRegistryPerson obj = new bRegistryPerson();

                    info = obj.deleteRegistryPerson(oeregistryperson);
                    if (info.Success)
                    {
                        MessageDisplay("Record Deleted Successfully.", true);
                        this.Grid.Rows.RemoveAt(this.Grid.SelectedCells[0].RowIndex);
                        isException = false;
                    }
                    else
                    {
                        if (info.Exception.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        {
                            MessageDisplay("record not deleted, associated", false);
                            isException = true;
                        }
                        else
                        {
                            MessageDisplay("record not deleted, " + info.Exception, false);
                            isException = true;
                        }
                    }
                }
            }
        }

        private void personRecordSaveUpdate(int rowIndex, int columnIndex)
        {
            MessageDisplay("", true);
            string headerText = Grid.Columns[columnIndex].HeaderText;
            //Guid partytype = ValidateFields.GetSafeGuid(Grid[0, e.RowIndex].Value);
            Guid partytype = ValidateFields.GetSafeGuid(cbxPartyType.SelectedValue);
            string firstname = Grid["cfirstname", rowIndex].EditedFormattedValue.ToString();
            string lastname = Grid["clastname", rowIndex].EditedFormattedValue.ToString();
            string address = Grid["cAddress", rowIndex].EditedFormattedValue.ToString();
            string cnic = Grid["ccnic", rowIndex].EditedFormattedValue.ToString();
            Guid casteid = ValidateFields.GetSafeGuid(Grid["cCaste", rowIndex].Value);
            int? designation = null;
            if (Grid.Columns["cDesignation"].Visible)
            {
                designation = ValidateFields.GetSafeInteger(Grid["cDesignation", rowIndex].Value); ;
            }
            string license = null;
            if (Grid.Columns["cLicenseNo"].Visible)
            {
                license = Grid["cLicenseNo", rowIndex].EditedFormattedValue.ToString();
            }
            
            bool isdepartment = Convert.ToBoolean(Grid["cdepartment", rowIndex].Value);
            bool isgovt = Convert.ToBoolean(Grid["cgovt", rowIndex].Value);
            string totalarea = Grid["ctotalarea", rowIndex].EditedFormattedValue.ToString();
            string totalshare = Grid["ctotalshare", rowIndex].EditedFormattedValue.ToString();
            string transferarea = Grid["ctransferarea", rowIndex].EditedFormattedValue.ToString();
            string transfershare = Grid["ctransfershare", rowIndex].EditedFormattedValue.ToString();
            Image img = null;
            if (bitForSearchImage == 1)
            {
                //if (Grid.Rows[Grid.CurrentCellAddress.Y].Cells["cCamera"].Value != null)
                //{
                //    img = (Bitmap)((new ImageConverter()).ConvertFrom(Grid.Rows[Grid.CurrentCellAddress.Y].Cells["cCamera"].Value));
                //}
            }
            else if (bitForSearchImage == 0)
            {
                //img = (Image)Grid.Rows[Grid.CurrentCellAddress.Y].Cells["cCamera"].Value;
            }
            //Image img = (Bitmap)((new ImageConverter()).ConvertFrom(Grid.Rows[Grid.CurrentCellAddress.Y].Cells["cCamera"].Value));
            try
            {
                //if (Grid.IsCurrentRowDirty)
                {
                    if (partytype == new Guid())
                    {
                        Grid.Rows[rowIndex].ErrorText = "party tyep must not be empty";
                        cbxPartyType.Enabled = true;
                        cbxPartyType.Focus();
                        MessageDisplay("party type must not be empty", false);
                        return;
                    }

                    if (string.IsNullOrEmpty(firstname))
                    {
                        Grid.Rows[rowIndex].ErrorText = "Name must not be empty";
                        MessageDisplay("name must not be empty", false);
                        Grid.CurrentCell = Grid.Rows[rowIndex].Cells["cFirstName"];
                        return;
                    }

                    if (string.IsNullOrEmpty(lastname))
                    {
                        Grid.Rows[rowIndex].ErrorText = "Last Name must not be empty";
                        Grid.CurrentCell = Grid.Rows[rowIndex].Cells["cLastName"];
                        MessageDisplay("Last Name must not be empty", false);
                        return;
                    }

                    if (string.IsNullOrEmpty(cnic))
                    {
                        Grid.Rows[rowIndex].ErrorText = "CNIC must not be empty";
                        Grid.CurrentCell = Grid.Rows[rowIndex].Cells["cCNIC"];
                        MessageDisplay("CNIC must not be empty", false);
                        return;
                    }

                    if (casteid == new Guid() && !Grid.Columns["cDesignation"].Visible)
                    {
                        Grid.Rows[rowIndex].ErrorText = "Caste name must not be empty";
                        Grid.CurrentCell = Grid.Rows[rowIndex].Cells["ccaste"];
                        MessageDisplay("Caste must not be empty", false);
                        return;
                    }

                    if (!string.IsNullOrEmpty(totalarea))
                    {
                        if (!ValidateArea(totalarea))
                        {
                            Grid.Rows[rowIndex].ErrorText = "Area must be enter in right format";
                            Grid.CurrentCell = Grid.Rows[rowIndex].Cells["cTotalArea"];
                            MessageDisplay("Please enter validate total area format", false);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(transferarea))
                    {
                        if (!ValidateArea(transferarea))
                        {
                            Grid.Rows[rowIndex].ErrorText = "Transfer area must be enter in right format";
                            Grid.CurrentCell = Grid.Rows[rowIndex].Cells["cTransferArea"];
                            MessageDisplay("Please enter validate transfer area format", false);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(totalshare))
                    {
                        if (!ValidateShare(totalshare))
                        {
                            Grid.Rows[rowIndex].ErrorText = "Total share must be enter in right format";
                            Grid.CurrentCell = Grid.Rows[rowIndex].Cells["cTotalShare"];
                            MessageDisplay("Please enter valid total share", false);
                            return;
                        }
                    }

                    if (!string.IsNullOrEmpty(transfershare))
                    {
                        if (!ValidateShare(transfershare))
                        {
                            Grid.Rows[rowIndex].ErrorText = "Transfer share must be enter in right format";
                            Grid.CurrentCell = Grid.Rows[rowIndex].Cells["cTransferShare"];
                            MessageDisplay("Please enter valid transfer share", false);
                            return;
                        }
                    }
                    Guid personid = ValidateFields.GetSafeGuid(Grid["cPersonID", rowIndex].Value);
                    ePerson oepersons = new ePerson();
                    oepersons.Person_id = personid;
                    bPerson obpersons = new bPerson();
                    List<ePerson> oelistpersons = new List<ePerson>();
                    oelistpersons = obpersons.getPerson(oepersons, "", "", 0, 2);
                    if (personid == Guid.Empty)
                    {
                        DataGridViewRow R = Grid.Rows[rowIndex];
                        R.Cells["cPersonID"].Value = Guid.NewGuid();
                        R.Cells["cRegistryPersonId"].Value = Guid.NewGuid();

                        updatedNewEntryInfo info = new updatedNewEntryInfo();

                        ePerson oeperson = new ePerson();
                        oeperson.Person_id = ValidateFields.GetSafeGuid(R.Cells["cPersonID"].Value);
                        oeperson.First_name_eng = firstname;
                        oeperson.Last_name_eng = lastname;
                        oeperson.Nic = cnic;
                        oeperson.Address_eng = address;
                        oeperson.Caste_id = casteid;
                        oeperson.User_id = Variables.UserId;
                        oeperson.Is_govt = isgovt;
                        oeperson.Is_department = isdepartment;
                        oeperson.Access_date_time = DateTime.Now;
                        oeperson.Is_active = true;
                        oeperson.Mauza_id = ValidateFields.GetSafeGuid(cbxMauza.SelectedValue.ToString());
                        oeperson.Pic_path = "";
                        oeperson.Thumb = oeperson.Thumb;
                        oeperson.Person_pic = oeperson.Person_pic;
                        oeperson.Designation = designation;
                        oeperson.License_no = license;

                        bPerson obperson = new bPerson();
                        List<ePerson> oelistperson = new List<ePerson>();
                        info = obperson.insertPerson(oeperson);
                        if (info.Success)
                        {
                            eRegistryPerson oeregistryperson = new eRegistryPerson();
                            bRegistryPerson obregistryperson = new bRegistryPerson();
                            oeregistryperson.Access_datetime = DateTime.Now;
                            oeregistryperson.Person_id = ValidateFields.GetSafeGuid(R.Cells["cPersonID"].Value);
                            oeregistryperson.User_id = Variables.UserId;
                            oeregistryperson.Registry_id = RegistryId;
                            oeregistryperson.Registryperson_id = ValidateFields.GetSafeGuid(R.Cells["cRegistryPersonId"].Value);
                            oeregistryperson.Party_type_id = partytype;

                            FeetPerMarla = 272;
                            if (totalarea != string.Empty)
                            {
                                areaValue = totalarea.Trim();
                                string areaToFeet = AreaToFeet(areaValue, 272);
                                oeregistryperson.Total_area = ValidateFields.GetSafeInt64(areaToFeet);
                            }
                            else
                            {
                                oeregistryperson.Total_area = 0;
                            }
                            if (transferarea != string.Empty)
                            {
                                areaValue = transferarea.Trim();
                                string transferAreaToFeet = AreaToFeet(areaValue, 272);
                                oeregistryperson.Transferred_area = ValidateFields.GetSafeInt64(transferAreaToFeet);
                            }
                            else
                            {
                                oeregistryperson.Transferred_area = 0;
                            }

                            oeregistryperson.Total_share = totalshare;
                            oeregistryperson.Transferred_share = transfershare;
                            info = obregistryperson.insertRegistryPerson(oeregistryperson);
                            if (info.Success)
                            {
                                MessageDisplay("Person Added Successfully.", true);
                                AddPerson();
                                isException = false;
                            }
                        }
                        else
                        {
                            MessageDisplay("person not inserted, " + info.Exception, false);
                            isException = true;
                        }
                    }
                    else
                    {
                        ePerson oeperson = new ePerson();
                        bPerson obperson = new bPerson();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        oeperson.Person_id = personid;
                        oeperson.First_name_eng = firstname;
                        oeperson.Last_name_eng = lastname;
                        oeperson.Nic = cnic;
                        oeperson.Address_eng = address;
                        oeperson.Caste_id = casteid;
                        oeperson.User_id = Variables.UserId;
                        oeperson.Is_govt = isgovt;
                        oeperson.Is_department = isdepartment;
                        oeperson.Access_date_time = DateTime.Now;
                        oeperson.Is_active = true;
                        oeperson.Mauza_id = ValidateFields.GetSafeGuid(cbxMauza.SelectedValue.ToString());
                        oeperson.Pic_path = "";
                        oeperson.Designation = designation;
                        oeperson.License_no = license;
                        oeperson.Thumb = oelistpersons[0].Thumb;

                        if (oelistpersons[0].Person_pic != null)
                        {
                            //string filePath = Application.StartupPath + "\\" + oeperson.Person_id + ".jpg";
                            //if (File.Exists(filePath))
                            //{
                            //    File.Delete(filePath);
                            //}
                            //FileStream fstream = new FileStream(filePath, FileMode.Create);
                            //img.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                            //fstream.Close();

                            oeperson.Person_pic = oelistpersons[0].Person_pic; //System.IO.File.ReadAllBytes(filePath);
                        }
                        else
                        {
                            oeperson.Person_pic = null;
                        }
                        info = obperson.udpatePerson(oeperson, true);
                        if (info.Success)
                        {
                            eRegistryPerson oeregistryperson = new eRegistryPerson();
                            bRegistryPerson obregistryperson = new bRegistryPerson();
                            List<eRegistryPerson> oelistregistryperson = new List<eRegistryPerson>();
                            oeregistryperson.Registry_id = RegistryId;
                            oeregistryperson.Person_id = ValidateFields.GetSafeGuid(info.Id);
                            oeregistryperson.Party_type_id = partytype;
                            oelistregistryperson = obregistryperson.getRegistryPerson(oeregistryperson, "", "", 0, int.MaxValue);
                            if (oelistregistryperson != null && oelistregistryperson.Count == 1)
                            {
                                oeregistryperson.Registryperson_id = oelistregistryperson[0].Registryperson_id;
                                oeregistryperson.Access_datetime = DateTime.Now;
                                oeregistryperson.User_id = Variables.UserId;
                                oeregistryperson.Party_type_id = partytype;
                                FeetPerMarla = 272;
                                if (totalarea != string.Empty)
                                {
                                    areaValue = totalarea.Trim();
                                    string areaToFeet = AreaToFeet(areaValue, 272);
                                    oeregistryperson.Total_area = ValidateFields.GetSafeInt64(areaToFeet);
                                }
                                else
                                {
                                    oeregistryperson.Total_area = 0;
                                }
                                if (transferarea != string.Empty)
                                {
                                    areaValue = transferarea.Trim();
                                    string transferAreaToFeet = AreaToFeet(areaValue, 272);
                                    oeregistryperson.Transferred_area = ValidateFields.GetSafeInt64(transferAreaToFeet);
                                }
                                else
                                {
                                    oeregistryperson.Transferred_area = 0;
                                }

                                oeregistryperson.Total_share = totalshare;
                                oeregistryperson.Transferred_share = transfershare;
                                info = obregistryperson.udpateRegistryPerson(oeregistryperson);
                                MessageDisplay("Person Updated Successfully.", true);
                                isException = false;
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

        private void Grid_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //MessageDisplay("", true);
            //string headerText = Grid.Columns[e.ColumnIndex].HeaderText;
            //Guid partytype = ValidateFields.GetSafeGuid(Grid[0, e.RowIndex].Value);
            //string firstname = Grid["cfirstname", e.RowIndex].EditedFormattedValue.ToString();
            //string lastname = Grid["clastname", e.RowIndex].EditedFormattedValue.ToString();
            //string address = Grid["cAddress", e.RowIndex].EditedFormattedValue.ToString();
            //string cnic = Grid["ccnic", e.RowIndex].EditedFormattedValue.ToString();
            //Guid casteid = ValidateFields.GetSafeGuid(Grid[5, e.RowIndex].Value);
            //bool isdepartment = Convert.ToBoolean(Grid["cdepartment", e.RowIndex].Value);
            //bool isgovt = Convert.ToBoolean(Grid["cgovt", e.RowIndex].Value);
            //string totalarea = Grid["ctotalarea", e.RowIndex].EditedFormattedValue.ToString();
            //string totalshare = Grid["ctotalshare", e.RowIndex].EditedFormattedValue.ToString();
            //string transferarea = Grid["ctransferarea", e.RowIndex].EditedFormattedValue.ToString();
            //string transfershare = Grid["ctransfershare", e.RowIndex].EditedFormattedValue.ToString();
            //Image img = (Image)Grid.Rows[Grid.CurrentCellAddress.Y].Cells[14].Value;
            //try
            //{
            //    if (Grid.IsCurrentRowDirty)
            //    {
            //        if (partytype == new Guid())
            //        {
            //            Grid.Rows[e.RowIndex].ErrorText = "party tyep must not be empty";
            //            Grid.CurrentCell = Grid.Rows[e.RowIndex].Cells[0];
            //            MessageDisplay("party type must not be empty", false);
            //            return;
            //        }

                    
            //        else if (string.IsNullOrEmpty(firstname))
            //        {
            //            Grid.Rows[e.RowIndex].ErrorText = "Name must not be empty";
            //            MessageDisplay("name must not be empty", false);
            //            Grid.CurrentCell = Grid.Rows[e.RowIndex].Cells[1];
            //            return;
            //        }

            //        else if (string.IsNullOrEmpty(lastname))
            //        {
            //            Grid.Rows[e.RowIndex].ErrorText = "Last Name must not be empty";
            //            Grid.CurrentCell = Grid.Rows[e.RowIndex].Cells[2];
            //            MessageDisplay("Last Name must not be empty", false);
            //            return;
            //        }
            //        else if (string.IsNullOrEmpty(cnic))
            //        {
            //            Grid.Rows[e.RowIndex].ErrorText = "CNIC must not be empty";
            //            Grid.CurrentCell = Grid.Rows[e.RowIndex].Cells[4];
            //            MessageDisplay("CNIC must not be empty", false);
            //            return;
            //        }
            //        else if (casteid == new Guid())
            //        {
            //            Grid.Rows[e.RowIndex].ErrorText = "Caste name must not be empty";
            //            Grid.CurrentCell = Grid.Rows[e.RowIndex].Cells["ccaste"];
            //            MessageDisplay("Caste must not be empty", false);
            //            return;
            //        }
            //        Guid personid = ValidateFields.GetSafeGuid(Grid[15, e.RowIndex].Value);
            //        if (personid == new Guid())
            //        {
            //            DataGridViewRow R = Grid.Rows[e.RowIndex];
            //            R.Cells[15].Value = Guid.NewGuid();
            //            R.Cells[16].Value = Guid.NewGuid();

            //            updatedNewEntryInfo info = new updatedNewEntryInfo();

            //            ePerson oeperson = new ePerson();
            //            oeperson.Person_id = (Guid)R.Cells[15].Value;
            //            oeperson.First_name_eng = firstname;
            //            oeperson.Last_name_eng = lastname;
            //            oeperson.Nic = cnic;
            //            oeperson.Address_eng = address;
            //            oeperson.Caste_id = casteid;
            //            oeperson.User_id = Variables.UserId;
            //            oeperson.Is_govt = isgovt;
            //            oeperson.Is_department = isdepartment;
            //            oeperson.Access_date_time = DateTime.Now;
            //            oeperson.Is_active = true;
            //            oeperson.Mauza_id = ValidateFields.GetSafeGuid(cbxMauza.SelectedValue.ToString());
            //            oeperson.Pic_path = "";
            //           // Image img = null;//Picture.Image;
            //            if (img != null)
            //            {
            //                string filePath = Application.StartupPath + "\\" + oeperson.Person_id + ".jpg";
            //                if (File.Exists(filePath))
            //                {
            //                    File.Delete(filePath);
            //                }
            //                FileStream fstream = new FileStream(filePath, FileMode.Create);
            //                img.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //                fstream.Close();

            //                MemoryStream fingerprintData = new MemoryStream();
            //                Template.Serialize(fingerprintData);
            //                fingerprintData.Position = 0;
            //                BinaryReader br = new BinaryReader(fingerprintData);
            //                Byte[] bytes = br.ReadBytes((Int32)fingerprintData.Length);
            //                oeperson.Thumb = bytes;//System.IO.File.ReadAllBytes(filePath);
            //            }
            //            else
            //            {
            //                oeperson.Thumb = null;
            //            }

            //            bPerson obperson = new bPerson();
            //            List<ePerson> oelistperson = new List<ePerson>();
            //            info = obperson.insertPerson(oeperson);
            //            if (info.Success)
            //            {
            //                eRegistryPerson oeregistryperson = new eRegistryPerson();
            //                bRegistryPerson obregistryperson = new bRegistryPerson();
            //                oeregistryperson.Access_datetime = DateTime.Now;
            //                oeregistryperson.Person_id = (Guid)R.Cells[15].Value;
            //                oeregistryperson.User_id = Variables.UserId;
            //                oeregistryperson.Registry_id = RegistryId;
            //                oeregistryperson.Registryperson_id = (Guid)R.Cells[16].Value;
            //                oeregistryperson.Party_type_id = partytype;
            //                oeregistryperson.Total_area = 0;
            //                oeregistryperson.Transferred_area = 0;
            //                oeregistryperson.Total_share = totalshare;
            //                oeregistryperson.Transferred_share = transfershare;
            //                info = obregistryperson.insertRegistryPerson(oeregistryperson);
            //                MessageDisplay("Person Added Successfully.", true);
            //                isException = false;
            //            }
            //            else
            //            {
            //                MessageDisplay("person not inserted, " + info.Exception, false);
            //                isException = true;
            //            }
            //        }
            //        else
            //        {
            //            ePerson oeperson = new ePerson();
            //            bPerson obperson = new bPerson();
            //            updatedNewEntryInfo info = new updatedNewEntryInfo();
            //            oeperson.Person_id = personid;

                        
                        
            //            oeperson.First_name_eng = firstname;
            //            oeperson.Last_name_eng = lastname;
            //            oeperson.Nic = cnic;
            //            oeperson.Address_eng = address;
            //            oeperson.Caste_id = casteid;
            //            oeperson.User_id = Variables.UserId;
            //            oeperson.Is_govt = isgovt;
            //            oeperson.Is_department = isdepartment;
            //            oeperson.Access_date_time = DateTime.Now;
            //            oeperson.Is_active = true;
            //            oeperson.Mauza_id = ValidateFields.GetSafeGuid(cbxMauza.SelectedValue.ToString());
            //            oeperson.Pic_path = "";
                        
            //            if (img != null)
            //            {
            //                string filePath = Application.StartupPath + "\\" + oeperson.Person_id + ".jpg";
            //                if (File.Exists(filePath))
            //                {
            //                    File.Delete(filePath);
            //                }
            //                FileStream fstream = new FileStream(filePath, FileMode.Create);
            //                img.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //                fstream.Close();

            //                oeperson.Person_pic = System.IO.File.ReadAllBytes(filePath);
            //            }
            //            else
            //            {
            //                oeperson.Person_pic = null;
            //            }
            //            info = obperson.udpatePerson(oeperson, false);
            //            if (info.Success)
            //            {
            //                eRegistryPerson oeregistryperson = new eRegistryPerson();
            //                bRegistryPerson obregistryperson = new bRegistryPerson();
            //                List<eRegistryPerson> oelistregistryperson = new List<eRegistryPerson>();
            //                oeregistryperson.Registry_id = RegistryId;
            //                oeregistryperson.Person_id = ValidateFields.GetSafeGuid(info.Id);
            //                oelistregistryperson = obregistryperson.getRegistryPerson(oeregistryperson, "", "", 0, int.MaxValue);
            //                if (oelistregistryperson != null && oelistregistryperson.Count == 1)
            //                {
            //                    oeregistryperson.Registryperson_id = oelistregistryperson[0].Registryperson_id;
            //                    oeregistryperson.Access_datetime = DateTime.Now;
            //                    oeregistryperson.User_id = Variables.UserId;
            //                    oeregistryperson.Party_type_id = partytype;
            //                    oeregistryperson.Total_area = 0;
            //                    oeregistryperson.Transferred_area = 0;                                
            //                    oeregistryperson.Total_share = totalshare;
            //                    oeregistryperson.Transferred_share = transferarea;
            //                    info = obregistryperson.udpateRegistryPerson(oeregistryperson);
            //                    MessageDisplay("Person Updated Successfully.", true);
            //                    isException = false;
            //                }
            //            }
                        
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Exception caught : " + ex.Message.ToString());
            //}
            //finally
            //{

            //    //lblStatus.Text = string.Empty;
            //}
        }

        private void loadPersonsOnRegistryNo()
        {
            eRegistryPerson oeRegistryPerson = new eRegistryPerson();
            List<ePersonWithRegistry> oeListPersonWithRegistry = new List<ePersonWithRegistry>();
            bRegistryPerson obRegistryPerson = new bRegistryPerson();
            List<eRegistryPerson> oeListRegistryPerson = new List<eRegistryPerson>();

            eCaste oeCaste = new eCaste();
            List<eCaste> oeListCaste = new List<eCaste>();
            bCaste obCaste = new bCaste();
            Guid caste_id = Guid.Empty;

            string sPersonType = string.Empty;
            oeRegistryPerson.Registry_id = RegistryId;
            oeListPersonWithRegistry = obRegistryPerson.getPersonByRegistryId(oeRegistryPerson, "", "", 0, int.MaxValue);
            if (oeListPersonWithRegistry != null && oeListPersonWithRegistry.Count > 0)
            {
                if (Grid.Rows.Count > 0)
                {
                    Grid.Rows.Clear();
                }

                for (int i = 0; i < oeListPersonWithRegistry.Count; i++)
                {
                    Grid.Rows.Add();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cPersonID"].Value = oeListPersonWithRegistry[i].Person_id;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cRegistryPersonId"].Value = oeListPersonWithRegistry[i].Registryperson_id;                    
                    cbxPartyType.SelectedValue = oeListPersonWithRegistry[i].Party_type_id;
                    oeRegistryPerson.Person_id = oeListPersonWithRegistry[i].Person_id;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cfirstname"].Value = oeListPersonWithRegistry[i].First_name_eng;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["clastname"].Value = oeListPersonWithRegistry[i].Last_name_eng;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cAddress"].Value = oeListPersonWithRegistry[i].Address_eng;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["ccnic"].Value = oeListPersonWithRegistry[i].Nic;//.Replace("\0", "");
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cCaste"].Value = oeListPersonWithRegistry[i].Caste_id;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cgovt"].Value = oeListPersonWithRegistry[i].Is_govt;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cdepartment"].Value = oeListPersonWithRegistry[i].Is_department;                    
                   // Grid.Rows[Grid.Rows.Count - 1].Cells["cCamera"].Value = oeListPersonWithRegistry[i].Person_pic;


                    //Grid.Rows[Grid.Rows.Count - 1].Cells["ctotalarea"].Value = oeListPersonWithRegistry[i].Total_area;


                    Grid.Rows[Grid.Rows.Count - 1].Height = 100;

                }
            }
            else
            {
                Grid.DataSource = null;
                Grid.Rows.Clear();
            }
        }

        private void txtRegistryNo_Leave(object sender, EventArgs e)
        {
            txtRegistryNo.Enabled = false;
        }

        private void btnRemovePerson_Click(object sender, EventArgs e)
        {
            if (Grid.Rows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure to delete a person?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (this.Grid.SelectedCells.Count > 0)
                    {
                        eRegistryPerson oeregistryperson = new eRegistryPerson();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        DataGridViewRow R = Grid.Rows[Grid.SelectedCells[0].RowIndex];
                        if (R.Cells[16].Value == null)
                        {
                            return;
                        }
                        oeregistryperson.Registryperson_id = (Guid)R.Cells["cRegistryPersonID"].Value;

                        bRegistryPerson obj = new bRegistryPerson();

                        info = obj.deleteRegistryPerson(oeregistryperson);
                        if (info.Success)
                        {
                            MessageDisplay("Record Deleted Successfully.", true);
                            this.Grid.Rows.RemoveAt(this.Grid.SelectedCells[0].RowIndex);
                            isException = false;
                        }
                        else
                        {
                            if (info.Exception.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                            {
                                MessageDisplay("record not deleted, associated", false);
                                isException = true;
                            }
                            else
                            {
                                MessageDisplay("record not deleted, " + info.Exception, false);
                                isException = true;
                            }
                        }
                    }
                }
            }

        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (Grid.CurrentCell != null)
                {
                    e.SuppressKeyPress = true;
                    int iColumn = Grid.CurrentCell.ColumnIndex;
                    if (iColumn == 14)
                    {
                        personRecordSaveUpdate(Grid.CurrentRow.Index, iColumn);
                        return;
                    }
                    if (iColumn == 15)
                    {
                        personRecordDelete();
                        return;
                    }
                    if (iColumn == 16)
                    {
                        CameraPupop();
                    }

                    int iRow = Grid.CurrentCell.RowIndex;
                    if (iColumn == 16)
                        Grid.CurrentCell = Grid[1, 0];
                    else
                    {
                        DataGridViewCell gridCell = Grid[iColumn, iRow];
                        Grid.CurrentCell = GetNextCell(gridCell);
                        //Grid.CurrentCell = Grid[iColumn + 1, iRow];
                    }
                }
            }
        }

        private void Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DataGridViewRow R = Grid.Rows[e.RowIndex];
            //if (R.Cells["cPersonID"].Value == null) R.Cells["cPersonID"].Value = Guid.NewGuid();
            //if (R.Cells["cRegistryPersonId"].Value == null) R.Cells["cRegistryPersonId"].Value = Guid.NewGuid();

        }

        private void AddPerson()
        {
            //if (isException == false)
            //{
            //    Grid.Rows.Add();
            //    isException = true;
            //}
            
            Grid.Focus();
            Grid.Rows.Add();
            Grid.CurrentCell = Grid.Rows[this.Grid.Rows.Count - 1].Cells["cFirstName"];
            SendKeys.Send("{F4}");
            bitForSearchImage = 0;
        }

        private void Grid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7) SendKeys.Send("{F4}");
        }

        private void Grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            MessageDisplay("", true);
        }

        private void cbxPartyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _areaFormat = (enAreaFormat)ddlAreaFormat.SelectedIndex;
            if (cbxPartyType.SelectedIndex > 0)
            {
                Guid PartyTypeID = (Guid)cbxPartyType.SelectedValue;
                if (PartyTypeID != null && PartyTypeID != new Guid())
                {
                    if (isRegistryIdExist())
                    {
                        FillGrid(PartyTypeID);
                        AddPerson();
                    }
                }
            }
            isException = false;
        }

        private void FillGrid(Guid PartyTypeId)
        {
            eRegistryPerson oeRegistryPerson = new eRegistryPerson();
            List<ePersonWithRegistry> oeListPersonWithRegistry = new List<ePersonWithRegistry>();
            bRegistryPerson obRegistryPerson = new bRegistryPerson();
            List<eRegistryPerson> oeListRegistryPerson = new List<eRegistryPerson>();

            eCaste oeCaste = new eCaste();
            List<eCaste> oeListCaste = new List<eCaste>();
            bCaste obCaste = new bCaste();
            Guid caste_id = Guid.Empty;

            string sPersonType = string.Empty;
            oeRegistryPerson.Registry_id = RegistryId;
            oeRegistryPerson.Party_type_id = PartyTypeId;
            oeListPersonWithRegistry = obRegistryPerson.getPersonByRegistryId(oeRegistryPerson, "", "", 0, int.MaxValue);
            if (oeListPersonWithRegistry != null && oeListPersonWithRegistry.Count > 0)
            {
                if (Grid.Rows.Count > 0)
                {
                    Grid.Rows.Clear();
                }
                showHideGridColumn();
                for (int i = 0; i < oeListPersonWithRegistry.Count; i++)
                {
                    Grid.Rows.Add();
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cPersonID"].Value = oeListPersonWithRegistry[i].Person_id;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cRegistryPersonId"].Value = oeListPersonWithRegistry[i].Registryperson_id;
                    cbxPartyType.SelectedValue = oeListPersonWithRegistry[i].Party_type_id;
                    oeRegistryPerson.Person_id = oeListPersonWithRegistry[i].Person_id;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cfirstname"].Value = oeListPersonWithRegistry[i].First_name_eng;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["clastname"].Value = oeListPersonWithRegistry[i].Last_name_eng;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cAddress"].Value = oeListPersonWithRegistry[i].Address_eng;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["ccnic"].Value = oeListPersonWithRegistry[i].Nic;//.Replace("\0", "");
                    if (oeListPersonWithRegistry[i].Designation != 0)
                    {
                        Grid.Rows[Grid.Rows.Count - 1].Cells["cDesignation"].Value = oeListPersonWithRegistry[i].Designation;//.Replace("\0", "");
                    }
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cLicenseNo"].Value = oeListPersonWithRegistry[i].License_no;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cCaste"].Value = oeListPersonWithRegistry[i].Caste_id;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cgovt"].Value = oeListPersonWithRegistry[i].Is_govt;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cdepartment"].Value = oeListPersonWithRegistry[i].Is_department;
                    FeetPerMarla = (short)feetPerMaralFromMauzaId;
                    areaValue = oeListPersonWithRegistry[i].Total_area.ToString();
                    long areaValueAgainstMauza = Convert.ToInt64(areaValue);
                    areaValue = FeetToArea(areaValueAgainstMauza, feetPerMaralFromMauzaId, AreaFormat);
                    if (areaValue == "0")
                    {
                        Grid.Rows[Grid.Rows.Count - 1].Cells["cTotalArea"].Value = "";
                    }
                    else
                    {
                        Grid.Rows[Grid.Rows.Count - 1].Cells["cTotalArea"].Value = areaValue;
                    }
                    transferedAreaValue = oeListPersonWithRegistry[i].Transferred_area.ToString();
                    //Area = areaValue;
                    long transferedAareaVal = Convert.ToInt64(transferedAreaValue);
                    transferedAreaValue = FeetToArea(transferedAareaVal, feetPerMaralFromMauzaId, AreaFormat);
                    if (transferedAreaValue == "0")
                    {
                        Grid.Rows[Grid.Rows.Count - 1].Cells["cTransferArea"].Value = "";
                    }
                    else
                    {
                        Grid.Rows[Grid.Rows.Count - 1].Cells["cTransferArea"].Value = transferedAreaValue;
                    }
                    //Grid.Rows[Grid.Rows.Count - 1].Cells["cTotalArea"].Value = oeListPersonWithRegistry[i].Total_area;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cTotalShare"].Value = oeListPersonWithRegistry[i].Total_share.Replace("\0", "");
                    //Grid.Rows[Grid.Rows.Count - 1].Cells["cTransferArea"].Value = oeListPersonWithRegistry[i].Transferred_area;
                    Grid.Rows[Grid.Rows.Count - 1].Cells["cTransferShare"].Value = oeListPersonWithRegistry[i].Transferred_share.Replace("\0", "");
                    //Grid.Rows[Grid.Rows.Count - 1].Cells["cCamera"].Value = oeListPersonWithRegistry[i].Person_pic;
                    Grid.Rows[Grid.Rows.Count - 1].Height = 100;
                }
            }
            else
            {
                Grid.DataSource = null;
                Grid.Rows.Clear();
                showHideGridColumn();
            }
        }

        private void showHideGridColumn()
        {
            if (cbxPartyType.Text.ToString().ToLower().Contains("commi"))
            {
                Grid.Columns["cAddress"].Visible = false;
                Grid.Columns["cCaste"].Visible = false;
                Grid.Columns["cgovt"].Visible = false;
                Grid.Columns["cdepartment"].Visible = false;
                Grid.Columns["cTotalArea"].Visible = false;
                Grid.Columns["cTransferArea"].Visible = false;
                Grid.Columns["cTotalShare"].Visible = false;
                Grid.Columns["cTransferShare"].Visible = false;

                Grid.Columns["cDesignation"].Visible = true;
                Grid.Columns["cLicenseNo"].Visible = true;
            }
            else
            {
                Grid.Columns["cAddress"].Visible = true;
                Grid.Columns["cCaste"].Visible = true;
                Grid.Columns["cgovt"].Visible = true;
                Grid.Columns["cdepartment"].Visible = true;
                Grid.Columns["cTotalArea"].Visible = true;
                Grid.Columns["cTransferArea"].Visible = true;
                Grid.Columns["cTotalShare"].Visible = true;
                Grid.Columns["cTransferShare"].Visible = true;

                Grid.Columns["cDesignation"].Visible = false;
                Grid.Columns["cLicenseNo"].Visible = false;
            }
        }

        private string FeetToArea(Int64 feet, int feetPerMarla, enAreaFormat format)
        {
            string areaValue = "0";
            double result;
            //double kanal, marla, sarsai, result;

            if (feetPerMarla > 0 && feet > 0)
            {
                switch (format)
                {
                    case enAreaFormat.KanalMarlaFeet:
                        {
                            _kanal = feet / 20 / feetPerMarla;

                            _marla = (feet / feetPerMarla) % 20;
                            _feet = feet % feetPerMarla;
                            //_feet = Convert.ToInt64(Math.Round(Convert.ToDouble(_feet) / Convert.ToDouble(feetPerMarla), MidpointRounding.AwayFromZero));

                            //if (_feet == 1)
                            {
                                if (_feet == feetPerMarla)
                                {
                                    _marla = _marla + 1;
                                    _feet = 0;
                                }
                                if (_marla == 20)
                                {
                                    _kanal = _kanal + 1;
                                    _marla = 0;
                                }
                                // _feet = 0;
                            }

                            areaValue = _kanal + "-" + _marla + "-" + _feet;
                            break;
                        }
                    case enAreaFormat.KanalMarlaSarsai:
                        {
                            _kanal = feet / 20 / feetPerMarla;
                            _marla = (feet / feetPerMarla) % 20;
                            _feet = feet % feetPerMarla;
                            _sarsai = Convert.ToInt64(Math.Round((_feet / (feetPerMarla / 9.0)), MidpointRounding.AwayFromZero));

                            if (_sarsai == 9)
                            {
                                _marla = _marla + 1;
                                if (_marla == 20)
                                {
                                    _kanal = _kanal + 1;
                                    _marla = 0;
                                }
                                _sarsai = 0;
                            }

                            areaValue = _kanal + "-" + _marla + "-" + _sarsai;
                            break;
                        }
                    case enAreaFormat.KanalMarla:
                        {
                            _kanal = feet / 20 / feetPerMarla;

                            _marla = Convert.ToInt64(Math.Round(Math.Round(((Convert.ToDouble(feet) / feetPerMarla) % 20.0), 2), MidpointRounding.AwayFromZero));

                            if (_marla == 20)
                            {
                                _marla = 0;
                                _kanal = _kanal + 1;
                            }
                            areaValue = _kanal + "-" + _marla;
                            break;
                        }
                    case enAreaFormat.Acre:
                        {
                            if (feetPerMarla == 225)
                            {
                                result = Math.Round((feet / 9.65 / 20 / feetPerMarla), MidpointRounding.AwayFromZero);
                                _acre = Convert.ToInt64(result);
                            }
                            else if (feetPerMarla == 272)
                            {
                                result = Math.Round((feet / 8.0 / 20 / feetPerMarla), MidpointRounding.AwayFromZero);
                                _acre = Convert.ToInt64(result);
                            }

                            areaValue = _acre.ToString();
                            break;
                        }

                    case enAreaFormat.KanalMarlaYard:
                        {
                            _kanal = feet / 20 / feetPerMarla;
                            _marla = (feet / feetPerMarla) % 20;
                            _feet = feet % feetPerMarla;
                            _yard = Convert.ToInt64(Math.Round((_feet / 9.07), MidpointRounding.AwayFromZero));

                            if (_yard == Convert.ToInt64(Math.Round((feetPerMarla / 9.07), MidpointRounding.AwayFromZero)))
                            {
                                _marla = _marla + 1;
                                _yard = 0;
                            }
                            if (_marla == 20)
                            {
                                _kanal = _kanal + 1;
                                _marla = 0;
                            }

                            areaValue = _kanal + "-" + _marla + "-" + _yard;
                            break;
                        }
                }
            }
            return areaValue;
        }

        private string AreaToFeet(string areaValue, int feetPerMarla)
        {
            string[] values = areaValue.Split('-');
            long Result = 0;
            if (values.GetUpperBound(0) == 2 && values.Length > 2)
            {
                switch ((enAreaFormat)Convert.ToInt64(ddlAreaFormat.SelectedIndex))
                {
                    case enAreaFormat.KanalMarlaFeet:
                        {
                            _kanal = Convert.ToInt64(values[0]);
                            _marla = Convert.ToInt64(values[1]);
                            _feet = Convert.ToInt64(values[2]);
                            break;
                        }
                    case enAreaFormat.KanalMarlaSarsai:
                        {
                            _kanal = Convert.ToInt64(values[0]);
                            _marla = Convert.ToInt64(values[1]);
                            _sarsai = Convert.ToInt64(values[2]);
                            _feet = Convert.ToInt64(Math.Round(((feetPerMarla / 9.0) * _sarsai), MidpointRounding.AwayFromZero));
                            break;
                        }
                    case enAreaFormat.KanalMarlaYard:
                        {
                            _kanal = Convert.ToInt64(values[0]);
                            _marla = Convert.ToInt64(values[1]);
                            _yard = Convert.ToInt64(values[2]);
                            _feet = Convert.ToInt64(Math.Round((_yard * 9.07), MidpointRounding.AwayFromZero));
                            break;
                        }
                }
            }
            else if (values.GetUpperBound(0) == 1)
            {
                _kanal = Convert.ToInt64(values[0]);
                _marla = Convert.ToInt64(values[1]);
            }
            else if (values.GetUpperBound(0) == 0)
            {
                if (feetPerMarla == 225)
                {
                    Result = Convert.ToInt64(Math.Round((Convert.ToDouble(values[0]) * 9.65 * 20 * feetPerMarla), MidpointRounding.AwayFromZero));
                }
                else if (feetPerMarla == 272)
                {
                    Result = Convert.ToInt64(values[0]) * 8 * 20 * feetPerMarla;
                }
            }

            Result = Result + (_kanal * 20 * feetPerMarla);
            Result = Result + (_marla * feetPerMarla);
            Result = Result + _feet;
            return Convert.ToString(Result);
        }

        #region Properties

        public string Area
        {
            get
            {
                if (!string.IsNullOrEmpty(areaValue) && areaValue != ddlAreaFormat.Text)
                {
                    return AreaToFeet(areaValue, FeetPerMarla);
                }
                else
                    return "0";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    areaValue = FeetToArea(Convert.ToInt64(value), FeetPerMarla, AreaFormat);
                }
            }
        }

        //public string AreaStr
        //{
        //    get
        //    {
        //        return txtTotalArea.Text.Trim();
        //    }
        //    set
        //    {
        //       txtTotalArea.Text = value;
        //    }
        //}

        

        public bool EnableArea
        {
            set
            {
                
                //this.txtTotalArea.Enabled = value;
            }
        }

        public bool ShowAreaFormat
        {
            set
            {
                this.ddlAreaFormat.Visible = value;
            }
        }

        public bool ShowAll
        {
            set
            {
                this.ddlAreaFormat.Visible = value;
               // this.txtTotalArea.Visible = value;
            }
        }

        public System.Drawing.Color BackColor
        {
            set
            {
                //this.txtTotalArea.BorderStyle = BorderStyle.FixedSingle;
                //txtTotalArea.BorderStyle = BorderStyle.Solid;
            }
        }

        public bool DefaultFormatOnly
        {
            set
            {
                this.ddlAreaFormat.Visible = value;
            }
        }

        public short FeetPerMarla
        {
            set
            {
                if (value > 0 && value <= short.MaxValue)
                    _feetPerMarla = value;
                else
                    _feetPerMarla = 0;
            }
            get
            {
                return _feetPerMarla;
            }
        }

        public enAreaFormat AreaFormat
        {
            get
            {
                return _areaFormat;
            }
            set
            {
                _areaFormat = value;
                ddlAreaFormat.SelectedIndex = Convert.ToInt32(value);
                //Variables.SetCue(txtTotalArea, ddlAreaFormat.Text);
                _areaFormat = (enAreaFormat)ddlAreaFormat.SelectedIndex;
            }
        }

        public short TabIndex
        {
            get
            {
                return _tabIndex;
            }
            set
            {
                _tabIndex = value;
               // txtTotalArea.TabIndex = (short)(value++);
                ddlAreaFormat.TabIndex = (short)(value++);

            }
        }

        public string AreaFromFeet(Int64 feet, int feetPerMarla, enAreaFormat format)
        {
            string areaValue = "0";
            double result;
            //double kanal, marla, sarsai, result;

            if (feetPerMarla > 0 && feet > 0)
            {
                switch (format)
                {
                    case enAreaFormat.KanalMarlaFeet:
                        {
                            _kanal = feet / 20 / feetPerMarla;
                            _marla = (feet / feetPerMarla) % 20;
                            _feet = feet % feetPerMarla;
                            //_feet = Convert.ToInt64(Math.Round(Convert.ToDouble(_feet) / Convert.ToDouble(feetPerMarla), MidpointRounding.AwayFromZero));

                            if (_feet == 1)
                            {
                                _marla = _marla + 1;
                                if (_marla == 20)
                                {
                                    _kanal = _kanal + 1;
                                    _marla = 0;
                                }
                                _feet = 0;
                            }

                            areaValue = _kanal + "-" + _marla + "-" + _feet;
                            break;
                        }
                    case enAreaFormat.KanalMarlaSarsai:
                        {
                            _kanal = feet / 20 / feetPerMarla;
                            _marla = (feet / feetPerMarla) % 20;
                            _feet = feet % feetPerMarla;
                            _sarsai = Convert.ToInt64(Math.Round((_feet / (feetPerMarla / 9.0)), MidpointRounding.AwayFromZero));

                            if (_sarsai == 9)
                            {
                                _marla = _marla + 1;
                                if (_marla == 20)
                                {
                                    _kanal = _kanal + 1;
                                    _marla = 0;
                                }
                                _sarsai = 0;
                            }

                            areaValue = _kanal + "-" + _marla + "-" + _sarsai;
                            break;
                        }
                    case enAreaFormat.KanalMarla:
                        {
                            _kanal = feet / 20 / feetPerMarla;
                            //_marla = Convert.ToInt64(Math.Round(((Convert.ToDouble(feet) / feetPerMarla) % 20.0), MidpointRounding.AwayFromZero));
                            _marla = Convert.ToInt64(Math.Round(Math.Round(((Convert.ToDouble(feet) / feetPerMarla) % 20.0), 2), MidpointRounding.AwayFromZero));
                            //_marla = (feet / feetPerMarla) % 20;
                            if (_marla == 20)
                            {
                                _marla = 0;
                                _kanal = _kanal + 1;
                            }
                            areaValue = _kanal + "-" + _marla;
                            break;
                        }
                    case enAreaFormat.Acre:
                        {
                            if (feetPerMarla == 225)
                            {
                                result = Math.Round((feet / 9.65 / 20 / feetPerMarla), MidpointRounding.AwayFromZero);
                                _acre = Convert.ToInt64(result);
                            }
                            else if (feetPerMarla == 272)
                            {
                                result = Math.Round((feet / 8.0 / 20 / feetPerMarla), MidpointRounding.AwayFromZero);
                                _acre = Convert.ToInt64(result);
                            }

                            areaValue = _acre.ToString();
                            break;
                        }
                }
            }
            return areaValue;
        }

        #endregion

        #region Utilities Functions

        private bool ValidateArea(string AreaValue)
        {
            if (AreaValue == string.Empty)
            {
                return true;
            }
            else if (Regex.IsMatch(AreaValue, "^[0-9--]*$"))
            {
                switch ((enAreaFormat)Convert.ToInt32(ddlAreaFormat.SelectedIndex))
                {
                    case enAreaFormat.KanalMarlaFeet:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(AreaValue, @"^((\d)+(-)(\d)+(-)(\d)+)$");
                        }
                    case enAreaFormat.KanalMarlaSarsai:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(AreaValue, @"^((\d)+(-)(\d)+(-)(\d)+)$");
                        }
                    case enAreaFormat.KanalMarla:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(AreaValue, @"^((\d)+(-)(\d)+)$");
                        }
                    case enAreaFormat.Acre:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(AreaValue, @"^(\d+)$");
                        }
                    case enAreaFormat.KanalMarlaYard:
                        {
                            return System.Text.RegularExpressions.Regex.IsMatch(AreaValue, @"^((\d)+(-)(\d)+(-)(\d)+)$");
                        }
                }
            }

            return false;
        }


        #endregion

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (Grid.CurrentCell != null)
                {
                    if (Grid.CurrentCell.Visible)
                    {
                        Grid.CurrentCell = GetNextCell(Grid.CurrentCell);
                        e.Handled = true;
                    }
                }
            }
        }
        private DataGridViewCell GetNextCell(DataGridViewCell currentCell)
        {
            int i = 0;
            DataGridViewCell nextCell = currentCell;
            if (currentCell != null)
            {
                do
                {
                    int nextCellIndex = (nextCell.ColumnIndex + 1) % 17;  //Grid.ColumnCount
                    int nextRowIndex = nextCellIndex == 0 ? (nextCell.RowIndex + 1) % Grid.RowCount : nextCell.RowIndex;
                    nextCell = Grid.Rows[nextRowIndex].Cells[nextCellIndex];
                    i++;
                } while (!nextCell.Visible && i < Grid.RowCount * 17);

            }
            return nextCell;
        }

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            if (isRegistryIdExist())
            {
                if (btnSearchPerson.Text.ToUpper() == "HIDE SEARCH PERSON")
                {
                    btnSearchPerson.Text = "Search Person";
                    pnlSearchPerson.Visible = false;
                    pnlRegistryPerson.Visible = true;
                    pnlRegistryPerson.Dock = DockStyle.Fill;
                }
                else
                {
                    pnlSearchPerson.Visible = true;
                    pnlRegistryPerson.Visible = false;
                    pnlSearchPerson.Dock = DockStyle.Fill;
                    btnSearchPerson.Text = "Hide Search Person";
                }
            }
        }

        private bool SearchControlEmpty()
        {
            bool temp = true;

            if (txtFirstName.Text != string.Empty)
            {
                temp = false;
            }
            if (txtFather.Text != string.Empty)
            {
                temp = false;
            }
            if (txtCNIC.Text != string.Empty)
            {
                temp = false;
            }

            return temp;
        }

        private void fillColumnPersonGrid()
        {
            DataGridViewTextBoxColumn dgvRegistryPersonId = new DataGridViewTextBoxColumn();
            dgvRegistryPersonId.Name = "cRegistryPersonId";
            dgvRegistryPersonId.Visible = false;
            grdPersons.Columns.Add(dgvRegistryPersonId);


            DataGridViewTextBoxColumn dgvPersonId = new DataGridViewTextBoxColumn();
            dgvPersonId.Name = "cPersonId";
            dgvPersonId.Visible = false;
            grdPersons.Columns.Add(dgvPersonId);

            DataGridViewTextBoxColumn dgvPartyTypeId = new DataGridViewTextBoxColumn();
            dgvPartyTypeId.Name = "cPartyTypeId";
            dgvPartyTypeId.Visible = false;
            grdPersons.Columns.Add(dgvPartyTypeId);

            //DataGridViewTextBoxColumn dgvCastId = new DataGridViewTextBoxColumn();
            //dgvCastId.Name = "colCasteId";
            //dgvCastId.Visible = false;
            //grdPersons.Columns.Add(dgvCastId);

            //DataGridViewTextBoxColumn dgvRelationID = new DataGridViewTextBoxColumn();
            //dgvRelationID.Name = "colRelationId";
            //dgvRelationID.Visible = false;
            //grdPersons.Columns.Add(dgvRelationID);

            //DataGridViewComboBoxColumn dgvPersonType = new DataGridViewComboBoxColumn();
            //dgvPersonType.HeaderText = "Person Type";
            //dgvPersonType.Name = "colPersonType";
            //grdPersons.Columns.Add(dgvPersonType);

            DataGridViewTextBoxColumn dgvFirstName = new DataGridViewTextBoxColumn();
            dgvFirstName.HeaderText = "First Name";
            dgvFirstName.ReadOnly = true;
            dgvFirstName.Name = "cFirstName";
            grdPersons.Columns.Add(dgvFirstName);

            //DataGridViewTextBoxColumn dgvRelationName = new DataGridViewTextBoxColumn();
            //dgvRelationName.HeaderText = "Relation";
            //dgvRelationName.Name = "colRelationName";
            //grdPersons.Columns.Add(dgvRelationName);


            DataGridViewTextBoxColumn dgvLastName = new DataGridViewTextBoxColumn();
            dgvLastName.HeaderText = "Last Name";
            dgvLastName.ReadOnly = true;
            dgvLastName.Name = "cLastName";
            grdPersons.Columns.Add(dgvLastName);

            DataGridViewTextBoxColumn dgvAddress = new DataGridViewTextBoxColumn();
            dgvAddress.HeaderText = "Address";
            dgvAddress.ReadOnly = true;
            dgvAddress.Name = "cAddress";
            grdPersons.Columns.Add(dgvAddress);

            DataGridViewTextBoxColumn dgvCNIC = new DataGridViewTextBoxColumn();
            dgvCNIC.HeaderText = "CNIC";
            dgvCNIC.ReadOnly = true;
            dgvCNIC.Name = "cCNIC";
            grdPersons.Columns.Add(dgvCNIC);

            DataGridViewComboBoxColumn dgvCasteName = new DataGridViewComboBoxColumn();
            dgvCasteName.HeaderText = "Caste";
            //dgvCasteName.ReadOnly = true;
            dgvCasteName.Name = "cCaste";
            grdPersons.Columns.Add(dgvCasteName);

            DataGridViewCheckBoxColumn dgvIsGovt = new DataGridViewCheckBoxColumn();
            dgvIsGovt.HeaderText = "Government";
            dgvIsGovt.ReadOnly = true;
            dgvIsGovt.Name = "cIsGovt";
            grdPersons.Columns.Add(dgvIsGovt);

            DataGridViewCheckBoxColumn dgvIsDepartment = new DataGridViewCheckBoxColumn();
            dgvIsDepartment.HeaderText = "Department";
            dgvIsDepartment.ReadOnly = true;
            dgvIsDepartment.Name = "cIsDepartment";
            grdPersons.Columns.Add(dgvIsDepartment);

            DataGridViewImageColumn dgvPersonPic = new DataGridViewImageColumn();
            dgvPersonPic.HeaderText = ".";
            dgvPersonPic.Visible = false;
            dgvPersonPic.Name = "cPersonPic";
            grdPersons.Columns.Add(dgvPersonPic);

        }

        private void bindPersonGrid(ePerson oePerson, bool isSearch)
        {
            if (grdPersons.Rows.Count > 0)
            {
                grdPersons.Rows.Clear();
            }
            bPerson obPerson = new bPerson();
            List<ePerson> oeListPerson = new List<ePerson>();
            eCaste oeCaste = new eCaste();
            List<eCaste> oeListCaste = new List<eCaste>();
            bCaste obCaste = new bCaste();

            Guid caste_id = Guid.Empty;
            if (isSearch)
                oeListPerson = obPerson.searchPersonRecord(oePerson, "", "", 0, int.MaxValue);
            else
                oeListPerson = obPerson.getPerson(oePerson, "", "", 0, int.MaxValue);

            if (oeListPerson != null && oeListPerson.Count > 0)
            {
                for (int i = 0; i < oeListPerson.Count; i++)
                {
                    grdPersons.Rows.Add();
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["cPersonId"].Value = oeListPerson[i].Person_id;
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["cCaste"].Value = oeListPerson[i].Caste_id;
                    //grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["colRelationId"].Value = oeListPerson[i].Relation_id;
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["cFirstName"].Value = oeListPerson[i].First_name_eng.Replace("\0", "");
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["cLastName"].Value = oeListPerson[i].Last_name_eng.Replace("\0", "");
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["cCNIC"].Value = oeListPerson[i].Nic.Replace("\0", "");
                    //caste_id = oeListPerson[i].Caste_id;
                    //if (caste_id != Guid.Empty)
                    //{
                    //    oeCaste.Caste_id = caste_id;
                    //    oeListCaste = obCaste.getCaste(oeCaste, "", "", 0, int.MaxValue);
                    //    if (oeListCaste != null && oeListCaste.Count > 0)
                    //    {
                    //        grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["colCasteName"].Value = oeListCaste[0].Caste_name_eng.Replace("\0", "");
                    //    }
                    //}
                    //grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["colRelationName"].Value = cbxRelation.Items[oeListPerson[i].Relation_id].ToString().Trim();

                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["cIsGovt"].Value = oeListPerson[i].Is_govt;
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["cIsDepartment"].Value = oeListPerson[i].Is_department;
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["cAddress"].Value = oeListPerson[i].Address_eng.Replace("\0", "");
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["cPersonPic"].Value = oeListPerson[i].Person_pic;
                    //grdPersons.Rows[grdPersons.Rows.Count - 1].Height = 100;
                }
            }
        }

        private void grdPersons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isRegistryIdExist() && Variables.roleName.ToUpper() == "SCO")
            {
                //if (grdPersons.SelectedRows[0].Cells["cPersonType"].Value == null || ValidateFields.GetSafeGuid(grdPersons.SelectedRows[0].Cells["cPersonType"].Value) == Guid.Empty)
                //{
                //    MessageDisplay("Person Type missing", false);
                //    return;
                //}
                if (Grid.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgvRow in Grid.Rows)
                    {
                        if (ValidateFields.GetSafeString(dgvRow.Cells["cPersonId"].Value) == ValidateFields.GetSafeString(grdPersons.Rows[e.RowIndex].Cells["cPersonId"].Value))
                        {
                            return;
                        }
                    }
                }
                if (cbxPartyType.Items.Count > 1 && cbxPartyType.SelectedIndex != 0)
                {
                    eRegistryPerson oeRegistryPerson = new eRegistryPerson();
                    bRegistryPerson obRegistryPerson = new bRegistryPerson();
                    updatedNewEntryInfo info = new updatedNewEntryInfo();
                    oeRegistryPerson.Registryperson_id = Guid.NewGuid();
                    oeRegistryPerson.Registry_id = RegistryId;
                    oeRegistryPerson.Person_id = ValidateFields.GetSafeGuid(grdPersons.Rows[e.RowIndex].Cells["cPersonId"].Value);
                    //string sPersonType = .Text;
                    oeRegistryPerson.Party_type_id = ValidateFields.GetSafeGuid(cbxPartyType.SelectedValue);
                    oeRegistryPerson.Access_datetime = DateTime.Now;

                    oeRegistryPerson.User_id = Variables.UserId;
                    info = obRegistryPerson.insertRegistryPerson(oeRegistryPerson);
                    if (info.Success)
                    {
                        Grid.Rows.Add();
                        Grid.Rows[Grid.Rows.Count - 1].Cells["cRegistryPersonId"].Value = info.Id; //grdPersons.Rows[e.RowIndex].Cells["cRegistryPersonId"].Value;
                        Grid.Rows[Grid.Rows.Count - 1].Cells["cPersonID"].Value = grdPersons.Rows[e.RowIndex].Cells["cPersonId"].Value;
                        Grid.Rows[Grid.Rows.Count - 1].Cells["cCaste"].Value = grdPersons.Rows[e.RowIndex].Cells["cCaste"].Value;
                        //Grid.Rows[Grid.Rows.Count - 1].Cells["cRelationId"].Value = grdPersons.Rows[e.RowIndex].Cells["colRelationId"].Value;
                        //Grid.Rows[Grid.Rows.Count - 1].Cells["colPersonType"].Value = grdPersons.Rows[e.RowIndex].Cells["colPersonType"].FormattedValue;
                        Grid.Rows[Grid.Rows.Count - 1].Cells["cFirstName"].Value = grdPersons.Rows[e.RowIndex].Cells["cFirstName"].Value.ToString().Replace("\0", "");
                        Grid.Rows[Grid.Rows.Count - 1].Cells["cLastName"].Value = grdPersons.Rows[e.RowIndex].Cells["cLastName"].Value.ToString().Replace("\0", "");
                        Grid.Rows[Grid.Rows.Count - 1].Cells["cCNIC"].Value = grdPersons.Rows[e.RowIndex].Cells["cCNIC"].Value.ToString().Replace("\0", "");
                        //Grid.Rows[Grid.Rows.Count - 1].Cells["cCasteName"].Value = grdPersons.Rows[e.RowIndex].Cells["cCaste"].Value;
                        //Grid.Rows[Grid.Rows.Count - 1].Cells["colRelationName"].Value = grdPersons.Rows[e.RowIndex].Cells["colRelationName"].Value;
                        Grid.Rows[Grid.Rows.Count - 1].Cells["cGovt"].Value = grdPersons.Rows[e.RowIndex].Cells["cIsGovt"].Value;
                        Grid.Rows[Grid.Rows.Count - 1].Cells["cDepartment"].Value = grdPersons.Rows[e.RowIndex].Cells["cIsDepartment"].Value;
                        Grid.Rows[Grid.Rows.Count - 1].Cells["cAddress"].Value = grdPersons.Rows[e.RowIndex].Cells["cAddress"].Value.ToString().Replace("\0", "");
                        //Grid.Rows[Grid.Rows.Count - 1].Cells["cCamera"].Value = grdPersons.Rows[e.RowIndex].Cells["cPersonPic"].Value;
                        Grid.Rows[Grid.Rows.Count - 1].Height = 100;
                        MessageDisplay("Person Added Successfully", true);
                        btnSearchPerson.Text = "Search Person";
                        pnlSearchPerson.Visible = false;
                        pnlRegistryPerson.Visible = true;
                        pnlRegistryPerson.Dock = DockStyle.Fill;
                        bitForSearchImage = 1;
                    }
                    else
                    {
                        MessageDisplay("Please contact administrator", false);
                    }
                }
                else
                {
                    MessageDisplay("Please select or add party type", false);
                }
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            ePerson oePerson = new ePerson();
            bool temp = SearchControlEmpty();
            if (!temp)
            {
                oePerson.First_name_eng = txtFirstName.Text.Trim();
                oePerson.Last_name_eng = txtFather.Text.Trim();
                oePerson.Nic = txtCNIC.Text.Trim();
                bindPersonGrid(oePerson, true);
            }
            else
            {
                bindPersonGrid(oePerson, false);
            }
        }

        private void cbxBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRegistryType.Items.Count != 0 && ddlRegistryType.SelectedIndex != 0)
            {
                Guid registryTypeId = ValidateFields.GetSafeGuid(ddlRegistryType.SelectedValue.ToString());
                fillPartyTypeComboBox(registryTypeId);
            }
        }
    }
}
