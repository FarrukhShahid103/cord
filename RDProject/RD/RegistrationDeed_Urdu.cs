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

namespace RDProject.RD
{
    public partial class RegistrationDeed_Urdu : Form, DPFP.Capture.EventHandler
    {

        eRegistryOperations oeRegistryOperations;
        bRegistryOperations obRegistryOperations;
        eRegistryOperations oeGeneralRegistryOperation = new eRegistryOperations();
        private bool NewRecord;
        private Guid RegistryId;
        public bool fromIndexing;
        public bool isInbox = false;
        private Guid personId;
        private Guid registryPersonId;
        private bool isPersonUpdate = false;
        WebCam webcam;
        private string areaValue = string.Empty;
        private string transferedAreaValue = string.Empty;
        private int iThumbStage = 0;
        private Int64 _acre;
        private Int64 _kanal;
        private Int64 _marla;
        private Int64 _feet;
        private Int64 _sarsai;
        private Int64 _yard;
        private short _feetPerMarla;
        private short _tabIndex;
        private enAreaFormat _areaFormat;
        private Guid mauzaId;
        private int feetPerMaralFromMauzaId = 272;
        bool isConfig = false;
        Guid sDistrict = Guid.Empty;
        Guid sTehsil = Guid.Empty;
        Guid sMauza = Guid.Empty;
        public int iRegistryStage = 0;

        public enum enAreaFormat
        {
            Acre = 0,
            KanalMarla,
            KanalMarlaFeet,
            KanalMarlaSarsai,
            KanalMarlaYard
        }

        public RegistrationDeed_Urdu()
        {
            InitializeComponent();
        }

        #region ....
        private DPFP.Capture.Capture Capturer;
        DPFP.Verification.Verification.Result result;

        protected virtual void ProcessSimple(DPFP.Sample Sample)
        {
            DrawPicture(ConvertSampleToBitmap(Sample));
        }

        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    SetPrompt("Using the fingerprint reader, scan your fingerprint.");
                }
                catch
                {
                    SetPrompt("Can't initiate capture!");
                }
            }
        }

        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    SetPrompt("Can't terminate capture!");
                }
            }
        }
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
            Bitmap bitmap = null;												            // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);									// TODO: return bitmap as a result
            return bitmap;
        }
        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();	// Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);			// TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }
        protected void SetStatus(string status)
        {
            this.Invoke(new Function(delegate()
            {
                StatusLine.Text = status;
            }));
        }
        protected void SetPrompt(string prompt)
        {
            this.Invoke(new Function(delegate()
            {
                string sPromt = prompt;
            }));
        }
        protected void MakeReport(string message)
        {
            this.Invoke(new Function(delegate()
            {
                //StatusText.AppendText(message + "\r\n");
            }));
        }

        private void DrawPicture(Bitmap bitmap)
        {
            this.Invoke(new Function(delegate()
            {
                Picture.Image = new Bitmap(bitmap, Picture.Size);	// fit the image into the picture box
            }));
        }


        #region EventHandler Members:

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            MakeReport("The fingerprint sample was captured.");
            SetPrompt("Scan the same fingerprint again.");
            if (iThumbStage == 1)
            {
                ProcessCreate(Sample);
            }
            if (iThumbStage == 2)
            {
                ProcessVerify(Sample);
            }

        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {

        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {

        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {

        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {

        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
        }
        #endregion
        #endregion

        #region bio

        public DPFP.Processing.Enrollment Enroller;
        public DPFP.Template Template;
        public delegate void OnTemplateEventHandler(DPFP.Template template);
        public event OnTemplateEventHandler OnTemplate;
        public DPFP.Verification.Verification Verificator;



        protected void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
                else
                    SetPrompt(" آپریشن کا آغاز نہیں کر سکت!");
            }
            catch
            {
                MessageBox.Show("آپریشن شروع نہیں کر سکتے ہیں!", "خرابی", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (iThumbStage == 1)
            {
                Enroller = new DPFP.Processing.Enrollment();			// Create an enrollment.
                UpdateStatus();
            }

        }
        private void UpdateStatus()
        {
            SetStatus(String.Format("{0} : فنگر پرنٹ کے نمونے کی ضرورت", Enroller.FeaturesNeeded));
        }

        protected void ProcessCreate(DPFP.Sample Sample)
        {
            ProcessSimple(Sample);
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
            if (features != null) try
                {
                    MakeReport("The fingerprint feature set was created.");
                    Enroller.AddFeatures(features);

                }
                finally
                {
                    UpdateStatus();
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:
                            OnTemplate(Enroller.Template);
                            SetPrompt("Click Close, and then click Fingerprint Verification.");
                            Stop();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:
                            Enroller.Clear();
                            Stop();
                            UpdateStatus();
                            OnTemplate(null);
                            Start();
                            break;
                    }
                }
        }

        protected void ProcessVerify(DPFP.Sample Sample)
        {
            ProcessSimple(Sample);
            Verificator = new DPFP.Verification.Verification();
            ePerson oePerson = new ePerson();

            List<ePerson> oeListPerson = new List<ePerson>();
            bPerson obPersons = new bPerson();
            oeListPerson = obPersons.getPerson(oePerson, "", "", 0, int.MaxValue);

            for (int i = 0; i < oeListPerson.Count; i++)
            {

                byte[] bytes = null;
                Guid id = oeListPerson[i].Person_id;
                bytes = oeListPerson[i].Thumb;
                Template = new DPFP.Template();
                Template.DeSerialize(bytes);
                if (bytes != null)
                {
                    DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
                    if (features != null)
                    {
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

                        try
                        {
                            Verificator.Verify(features, Template, ref result);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        if (result.Verified)
                        {
                            //lblMsg.Text = "User: " + oeListUsers[i].User_name + " Has Been Verified";
                            this.Invoke(new Function(delegate()
                            {

                                txtFirstName.Text = oeListPerson[i].First_name_urd.Replace("\0", "");
                                txtLastName.Text = oeListPerson[i].Last_name_urd.Replace("\0", ""); 
                                MessageDisplay(txtFirstName.Text + " کی تصدیق ھو گئ ہے ", true);
                                btnRegisterThumb.Enabled = false;
                            }));
                            break;
                        }
                        else
                        {
                            this.Invoke(new Function(delegate()
                            {
                                MessageDisplay("ریکارڈ نہیں ملا...", false);
                            }));                           
                        }

                    }
                }
            }



            //DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
            //if (features != null)
            //{
            //    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
            //    Verificator.Verify(features, Template, ref result);

            //    //UpdateStatus(result.FARAchieved);
            //    if (result.Verified)
            //        MakeReport("The fingerprint is VERIFIED.");
            //    else
            //        MakeReport("The fingerprint is NOT VERIFIED.");
            //}
        }

        protected void process2(DPFP.Sample sample)
        {
            //DPFP.FeatureSet features = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Verification);
            //bool verified = false;
            //if (features != null)
            //{
            //    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

            //    eUsers oeUsers = new eUsers();
            //    oeUsers.User_name = txtUserName.Text.Trim();
            //    List<eUsers> oeListUsers = new List<eUsers>();
            //    bUsers obUsers = new bUsers();
            //    oeListUsers = obUsers.getUsers(oeUsers, "", "", 0, int.MaxValue);


            //    foreach (var at in oeListUsers)
            //    {
            //        Verificator.Verify(features, Template, ref result);
            //        if (result.Verified)
            //        {
            //            register(oeListUsers[0].User_id);
            //            verified = true;
            //            break;
            //        }
            //    }
            //}
            //if (!verified)
            //    error("Invalid student.");
        }



        private void UpdateStatus(int FAR)
        {
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
        }


        #endregion

        private void btnScanning_Click(object sender, EventArgs e)
        {
            if (isRegistryIdExist())
            {
                ScanningForm_English obj = new ScanningForm_English();
                obj.NewRecord = true;
                obj.Registry_ID = RegistryId;
                obj.ShowDialog();
                //eRegistryImages oeRegistryImages = new eRegistryImages();
                //List<eRegistryImages> oeListRegistryImages = new List<eRegistryImages>();
                //bRegistryImages obRegistryImages = new bRegistryImages();
                //oeRegistryImages.Registry_id = RegistryId;
                //oeListRegistryImages = obRegistryImages.getRegistryImages(oeRegistryImages, "", "", 0, int.MaxValue);
                //if (oeListRegistryImages != null && oeListRegistryImages.Count > 0)
                //{
                //    obj.NewRecord = false;
                //}
                //else
                //{
                //    obj.NewRecord = true;
                //}
            }
            else
            {
                MessageDisplay("اس رجسٹری کے متعلقہ ریکارڈ نہیں ہے۔ مہربانی کر کے پہلے رجسٹری بنائیں۔", true);
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
                Khasra_Urdu obj = new Khasra_Urdu();
                obj.Registry_No = Convert.ToInt32(txtRegistryNo.Text);
                obj.AreaFormatForExpose = (int)AreaFormat;
                obj.Registry_ID = RegistryId;
                obj.mauzaId = (ValidateFields.GetSafeGuid(cbxMauza.SelectedValue) == Guid.Empty) ? Guid.Empty : ValidateFields.GetSafeGuid(cbxMauza.SelectedValue);
                obj.lblMsg.Text = "اندراج خسرہ رجسٹری نمبر : " + txtRegistryNo.Text;
                obj.ShowDialog();
            }
            else
            {
                MessageDisplay("اس رجسٹری کے متعلقہ ریکارڈ نہیں ہے۔ مہربانی کر کے پہلے رجسٹری بنائیں۔", true);
            }
        }

        private void btnVerifyFard_Click(object sender, EventArgs e)
        {
            if (isRegistryIdExist())
            {
                Fard_Urdu obj = new Fard_Urdu();
                obj.registryNo = Convert.ToInt32(txtRegistryNo.Text);
                obj.registryId = RegistryId;
//                obj.mauzaId = ValidateFields.GetSafeGuid((cbxMauza.SelectedIndex!=0)?cbxMauza.SelectedValue.ToString() : null);
                obj.mauzaId = ValidateFields.GetSafeGuid(cbxMauza.SelectedValue.ToString());

                obj.lblMsg.Text = "اندراج فرد رجسٹری نمبر : " + txtRegistryNo.Text;
                obj.ShowDialog();
            }
            else
            {
                MessageDisplay("اس رجسٹری کے متعلقہ ریکارڈ نہیں ہے۔ مہربانی کر کے پہلے رجسٹری بنائیں۔", true);
            }
        }

        private void loadRegistryType()
        {
            eRegistryType oeRegistryType = new eRegistryType();
            bRegistryType obRegistryType = new bRegistryType();
            List<eRegistryType> oeListRegistryType = new List<eRegistryType>();
            oeListRegistryType = obRegistryType.getRegistryType(oeRegistryType, "", "", 0, int.MaxValue);
            AddItem(oeListRegistryType, typeof(eRegistryType), "Registry_type_id", "Registry_type_description_urd", "< - چنیں - >");
            if (oeListRegistryType != null && oeListRegistryType.Count > 0)
            {
                ddlRegistryType.ValueMember = "Registry_type_id";
                ddlRegistryType.DisplayMember = "Registry_type_description_urd";
                //Common.setSourceLanguage(ddlRegistryType, "Registry_type_description_eng", "Registry_type_description_urd", frm_MainMDI.language);
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
            AddItem(oeListDistrict, typeof(eDistrict), "District_id", "District_name_urd", "< - چنیں - >");
            if (oeListDistrict != null && oeListDistrict.Count > 0)
            {
                //setSourceLanguage(cbxDistrict, "district_name_eng", "district_name_urd", frm_MainMDI.language);
                cbxDistrict.DisplayMember = "district_name_urd";
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
                // isConfig = false;
            }
        }


        private void loadTehsil(Guid DistrictId)
        {
            bTehsil obTehsil = new bTehsil();
            List<eTehsil> oeListTehsil = new List<eTehsil>();
            eTehsil oeTehsil = new eTehsil();
            oeTehsil.District_id = DistrictId;
            oeListTehsil = obTehsil.getTehsil(oeTehsil, "", "", 0, int.MaxValue);
            AddItem(oeListTehsil, typeof(eTehsil), "Tehsil_id", "Tehsil_name_urd", "< - چنیں - >");
            if (oeListTehsil.Count > 0)
            {
                cbxTehsil.DisplayMember = "tehsil_name_urd";
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
                if (rbUrban.Checked)
                {
                    if (Variables.isTown)
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


        private void loadTown(Guid TehsilId)
        {
            eTown oeTown = new eTown();
            List<eTown> oeListTown = new List<eTown>();
            bTown obTown = new bTown();
            oeTown.Tehsil_id = TehsilId;
            oeListTown = obTown.getTown(oeTown, "", "", 0, int.MaxValue);
            AddItem(oeListTown, typeof(eTown), "Town_id", "Town_name_urd", "< - چنیں - >");
            if (oeListTown != null && oeListTown.Count > 0)
            {
                cbxTown.DisplayMember = "town_name_urd";
                cbxTown.ValueMember = "town_id";
            }
            cbxTown.DataSource = oeListTown;
        }

        private void loadMauza(Guid id)
        {
            bMauza obMauza = new bMauza();
            List<eMauza> oeListMauza = new List<eMauza>();
            eMauza oeMauza = new eMauza();
            if (rbUrban.Checked)
            {
                if (Variables.isTown)
                {
                    oeMauza.Town_id = id;
                }
                else
                {
                    oeMauza.Tehsil_id = id;
                }
            }
            else
            {
                oeMauza.Tehsil_id = id;
            }
            oeListMauza = obMauza.getMauza(oeMauza, "", "", 0, int.MaxValue);
            AddItem(oeListMauza, typeof(eMauza), "Mauza_id", "Mauza_name_urd", "< - چنیں - >");
            if (oeListMauza != null && oeListMauza.Count > 0)
            {
                cbxMauza.DisplayMember = "mauza_name_urd";
                cbxMauza.ValueMember = "mauza_id";
            }
            cbxMauza.DataSource = oeListMauza;
            ddlAreaFormat.SelectedIndex = oeListMauza[0].Area_format;
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
                MessageDisplay("قسم رجسٹری کا انتخاب کریں۔", false);
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
                    int regStage = checkRegistryStage(RegistryId);
                    
                    //if (regStage == 0 || regStage == 1)
                    if (iRegistryStage == 0 || iRegistryStage == 1)
                    {
                        oeRegistryOperations.Registry_id = oeGeneralRegistryOperation.Registry_id;
                        oeRegistryOperations.Mauza_id = oeGeneralRegistryOperation.Mauza_id;
                        oeRegistryOperations.Service_centre_id = null;
                        oeRegistryOperations.Subregistrar_id = null;
                        oeRegistryOperations.Registry_type_id = new Guid(ddlRegistryType.SelectedValue.ToString());
                        oeRegistryOperations.Registry_no = txtRegistryNo.Text.Trim();
                        oeRegistryOperations.Registry_date = oeGeneralRegistryOperation.Registry_date; //DateTime.Parse(txtDate.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-CA"));
                        
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
                            MessageDisplay("رجسٹری کامیابی سے تبدیل ھو گیؑ ھے۔", true);
                            if (iRegistryStage == 0)
                            {
                                btnAddPerson_Click(sender, e);
                            }
                        }
                        else
                        {

                            MessageDisplay("رجسٹری کے ریکارڈ کو تبدیل نہیں ھو سکی۔", false);
                        }
                    }
                    else
                    {
                        MessageDisplay("Registry Cannot be modified, because of SR", false);
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
                        MessageDisplay("رجسٹری کا اندرا ج ہو گیا ہے۔", true);
                        btnKhasra.Enabled = true;
                        btnVerifyFard.Enabled = true;
                        btnSentToSR.Visible = true;
                        btnSentToSR.Enabled = true;
                        btnPrint.Enabled = true;
                        btnPrint.Visible = true;
                        if (Variables.isTown) { btnPlot.Visible = true; btnPlot.Enabled = true; }
                        btnAddPerson.Enabled = true;
                        btnSearchPerson.Enabled = true;

                        ddlRegistryType.Enabled = false;

                        btnAddPerson_Click(sender, e);
                        pnlLeft.Visible = false;
                    }
                    else
                    {
                        MessageDisplay("رجسٹری کا اندراج نہیں ہو سکا", false);
                    }
                }
            }
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
                if (grdSelectedPersons.Rows.Count > 0)
                {
                    grdSelectedPersons.Rows.Clear();
                }
                if (grdPersons.Columns.Count <= 1)
                {
                    fillColumnSelectedPersonGrid();
                }

                for (int i = 0; i < oeListPersonWithRegistry.Count; i++)
                {
                    grdSelectedPersons.Rows.Add();
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colRegistryPersonId"].Value = oeListPersonWithRegistry[i].Registryperson_id;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colPersonId"].Value = oeListPersonWithRegistry[i].Person_id;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colPartyTypeId"].Value = oeListPersonWithRegistry[i].Party_type_id;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colCasteId"].Value = oeListPersonWithRegistry[i].Caste_id;

                    oeRegistryPerson.Person_id = oeListPersonWithRegistry[i].Person_id;
                    
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colPersonType"].Value = oeListPersonWithRegistry[i].Party_name_urd; 
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colFirstName"].Value = oeListPersonWithRegistry[i].First_name_urd;//.Replace("\0", "");
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colLastName"].Value = oeListPersonWithRegistry[i].Last_name_urd;//.Replace("\0", "");
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colCNIC"].Value = oeListPersonWithRegistry[i].Nic.Replace("\0", "");

                    caste_id = oeListPersonWithRegistry[i].Caste_id;
                    if (caste_id != Guid.Empty)
                    {
                        oeCaste.Caste_id = caste_id;
                        oeListCaste = obCaste.getCaste(oeCaste, "", "", 0, int.MaxValue);
                        if (oeListCaste != null && oeListCaste.Count > 0)
                        {
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colCasteName"].Value = oeListCaste[0].Caste_name_urd.Replace("\0", "");
                        }
                    }
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colIsGovt"].Value = oeListPersonWithRegistry[i].Is_govt;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colIsDepartment"].Value = oeListPersonWithRegistry[i].Is_department;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colAddress"].Value = oeListPersonWithRegistry[i].Address_urd;//.Replace("\0", "");
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colPersonPic"].Value = oeListPersonWithRegistry[i].Person_pic;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Height = 100;

                }
            }
            else
            {
                grdSelectedPersons.DataSource = null;
                grdSelectedPersons.Rows.Clear();
            }
            if (grdSelectedPersons.Rows.Count > 0)
            {
                //VerifyStage();
            }
            else
            {
                //Stop();
            }
        }

        private void resetFields()
        {
            lblMsg.Text = string.Empty;
            NewRecord = true;
            splitContainer1.Panel1Collapsed = true;
            if (!string.IsNullOrEmpty(txtDate.Text))
            {
                txtRegistryNo.Text = maxRegNo().ToString();
            }
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
            cbxDistrict.SelectedIndex = 0;
            cbxTehsil.SelectedIndex = -1;
            cbxMauza.SelectedIndex = -1;
            //txtDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            //txtDate.CustomFormat = "dd/MM/yyyy";
            //txtDate.Format = DateTimePickerFormat.Custom;
            //txtDate.ResetText();
            txtAmount.Text = "0";
            //decimal cubic = Convert.ToDecimal(txtAmount.Text);
            //txtAmount.Text = string.Format("{0:c}", Convert.ToDecimal(cubic));
            txtDocumentNumber.Text = string.Empty;
            txtBahiNumber.Text = string.Empty;
            txtJildNumber.Text = string.Empty;
            txtMutationFee.Clear();
            txtCVT.Clear();
            txtStampDuty.Clear();
            txtDistrictFee.Clear();
            txtRegistrationFee.Clear();
            pnlPersonDetail.Visible = false;
            btnScanning.Enabled = false;
            btnKhasra.Enabled = false;
            btnVerifyFard.Enabled = false;
            btnAddPerson.Enabled = false;
            btnSearchPerson.Enabled = false;
            btnSentToSR.Visible = false;
            btnSentToSCI.Visible = false;
            btnSave.Text = "محفوظ کریں";
            btnSave.Enabled = false;
            txtRegistryNo.Enabled = true;
            btnPrint.Visible = false;
            gbxUrbanRural.Enabled = true;
            pnlBasicInfoMiddle.Visible = false;
            pnlBasicInfoBottom.Enabled = true;
            txtAmount.Enabled = true;
            //rbRural.Checked = true;

            if (grdPersons.Rows.Count > 0)
            {
                grdPersons.Rows.Clear();
            }
            if (grdSelectedPersons.Rows.Count > 0)
            {
                grdSelectedPersons.Rows.Clear();
            }
            Picture.Image = null;
            cbxDistrict.SelectedValue = Variables.defaultDistrict;
            cbxTehsil.SelectedValue = Variables.defaultTehsil;
            cbxTown.SelectedValue = Variables.defaultTown;
            cbxMauza.SelectedValue = Variables.defaultMauza;
            btnSave.Enabled = true;
        }

        private void fillCasteComboBox()
        {
            bCaste obCaste = new bCaste();
            eCaste oeCaste = new eCaste();
            List<eCaste> oeListCaste = new List<eCaste>();
            oeListCaste = obCaste.getCaste(oeCaste, "", "", 0, int.MaxValue);
            AddItem(oeListCaste, typeof(eCaste), "Caste_id", "Caste_name_urd", "< - چنیں - >");
            if (oeListCaste != null && oeListCaste.Count > 0)
            {
                //DataGridViewComboBoxColumn col = grdRegistryInfo.Columns["colCaste"] as DataGridViewComboBoxColumn;
                cbxCaste.DataSource = oeListCaste;
                cbxCaste.DisplayMember = "caste_name_urd";
                cbxCaste.ValueMember = "caste_id";
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
            dgvRegistryNo.HeaderText = "رجسٹری نمبر";
            dgvRegistryNo.Name = "colRegistryNo";

            DataGridViewTextBoxColumn dgvDate = new DataGridViewTextBoxColumn();
            dgvDate.HeaderText = "تاریخ";
            dgvDate.Name = "colDate";

            DataGridViewTextBoxColumn dgvAmount = new DataGridViewTextBoxColumn();
            dgvAmount.HeaderText = "روپے";
            dgvAmount.Name = "colAmount";

            DataGridViewTextBoxColumn dgvRemarks = new DataGridViewTextBoxColumn();
            dgvRemarks.HeaderText = "ریمارکس";
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

        private void RegistrationDeed_Urdu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
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
                    return;
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
            loadDistrict();
            pnlLeft.Visible = true;
            lblMsg.Text = string.Empty;
            NewRecord = true;
            txtDate.ResetText();
            splitContainer1.Panel1Collapsed = true;
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
            pnlPersonDetail.Visible = false;
            btnScanning.Enabled = false;
            btnKhasra.Enabled = false;
            btnVerifyFard.Enabled = false;
            btnAddPerson.Enabled = false;
            btnSearchPerson.Enabled = false;
            btnSentToSR.Visible = false;
            btnSentToSCI.Visible = false;
            btnSave.Text = "محفوظ کریں";
            btnSave.Enabled = false;
            txtRegistryNo.Enabled = true;
            gbxUrbanRural.Enabled = true;
            pnlBasicInfoMiddle.Visible = false;
            pnlBasicInfoBottom.Enabled = true;
            txtAmount.Enabled = true;
            if (grdPersons.Rows.Count > 0)
            {
                grdPersons.Rows.Clear();
            }
            if (grdSelectedPersons.Rows.Count > 0)
            {
                grdSelectedPersons.Rows.Clear();
            }
            Picture.Image = null;

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
            btnAddPerson.Text = "نیا شخص";
            StatusLine.Clear();

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

            //cbxRelation.SelectedIndex = 0;

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
                ddlAreaFormat.SelectedIndex = GetMauzaAreaFormat(Variables.defaultMauza);
            }

            btnSave.Enabled = true;

            txtSearchCNIC.Clear();
            txtSearchFirstName.Clear();
            txtSearchLastName.Clear();

        }
        
        private void RegistrationDeed_Urdu_Load(object sender, EventArgs e)
        {
            txtDate.CustomFormat = "dd/MM/yyyy";
            txtDate.Format = DateTimePickerFormat.Custom;
            try
            {
                webcam = new WebCam();
                webcam.InitializeWebCam(ref imgVideo);
                btnCapture.Visible = true;
            }
            catch (Exception ex)
            {

                MessageDisplay("Camera device is missing", false);
                btnCapture.Visible = false;
            }
            pnlPersonDetail.Visible = false;

            fillColumnGridOfRegistryInfo();
            if (pnlPersonDetail.Visible)
            {
                fillCasteComboBox();
            }
            fillColumnPersonGrid();
            fillColumnSelectedPersonGrid();
            pnlBasicInfoMiddle.Visible = false;
            btnNewRegistry.Visible = true;
            btnAddPerson.Enabled = true;
            btnSearchPerson.Enabled = true;
            grdSelectedPersons.ReadOnly = false;
            rbRural_CheckedChanged(sender, e);
            txtRegistryNo.Focus();


        }


        private void fillColumnPersonGrid()
        {
            DataGridViewTextBoxColumn dgvRegistryPersonId = new DataGridViewTextBoxColumn();
            dgvRegistryPersonId.Name = "colRegistryPersonId";
            dgvRegistryPersonId.Visible = false;
            grdPersons.Columns.Add(dgvRegistryPersonId);


            DataGridViewTextBoxColumn dgvPersonId = new DataGridViewTextBoxColumn();
            dgvPersonId.Name = "colPersonId";
            dgvPersonId.Visible = false;
            grdPersons.Columns.Add(dgvPersonId);

            DataGridViewTextBoxColumn dgvPartyTypeId = new DataGridViewTextBoxColumn();
            dgvPartyTypeId.Name = "colPartyTypeId";
            dgvPartyTypeId.Visible = false;
            grdPersons.Columns.Add(dgvPartyTypeId);

            DataGridViewTextBoxColumn dgvCastId = new DataGridViewTextBoxColumn();
            dgvCastId.Name = "colCasteId";
            dgvCastId.Visible = false;
            grdPersons.Columns.Add(dgvCastId);

            DataGridViewComboBoxColumn dgvPersonType = new DataGridViewComboBoxColumn();
            dgvPersonType.HeaderText = "پارٹی کی قسم";
            dgvPersonType.Name = "colPersonType";
            grdPersons.Columns.Add(dgvPersonType);
            //((DataGridViewComboBoxColumn)grdPersons.Columns["colPersonType"]).DataSource = null;
            //((DataGridViewComboBoxColumn)grdPersons.Columns["colPersonType"]).DataSource = cbBuyerSeller.DataSource;

            //DataGridViewTextBoxColumn dgvPersonType = new DataGridViewTextBoxColumn();
            //dgvPersonType.HeaderText = "Person Type";
            //dgvPersonType.Name = "colPersonType";
            //grdPersons.Columns.Add(dgvPersonType);

            DataGridViewTextBoxColumn dgvFirstName = new DataGridViewTextBoxColumn();
            dgvFirstName.HeaderText = "نام";
            dgvFirstName.ReadOnly = true;
            dgvFirstName.Name = "colFirstName";
            grdPersons.Columns.Add(dgvFirstName);

            DataGridViewTextBoxColumn dgvLastName = new DataGridViewTextBoxColumn();
            dgvLastName.HeaderText = "ولدیت / زوجیت";
            dgvLastName.ReadOnly = true;
            dgvLastName.Name = "colLastName";
            grdPersons.Columns.Add(dgvLastName);

            DataGridViewTextBoxColumn dgvCNIC = new DataGridViewTextBoxColumn();
            dgvCNIC.HeaderText = "شناختی کارڈ نمبر";
            dgvCNIC.ReadOnly = true;
            dgvCNIC.Name = "colCNIC";
            grdPersons.Columns.Add(dgvCNIC);

            DataGridViewTextBoxColumn dgvCasteName = new DataGridViewTextBoxColumn();
            dgvCasteName.HeaderText = "ذات";
            dgvCasteName.ReadOnly = true;
            dgvCasteName.Name = "colCasteName";
            grdPersons.Columns.Add(dgvCasteName);

            DataGridViewCheckBoxColumn dgvIsGovt = new DataGridViewCheckBoxColumn();
            dgvIsGovt.HeaderText = "حکومت";
            dgvIsGovt.ReadOnly = true;
            dgvIsGovt.Name = "colIsGovt";
            grdPersons.Columns.Add(dgvIsGovt);

            DataGridViewCheckBoxColumn dgvIsDepartment = new DataGridViewCheckBoxColumn();
            dgvIsDepartment.HeaderText = "محکمہ";
            dgvIsGovt.ReadOnly = true;
            dgvIsDepartment.Name = "colIsDepartment";
            grdPersons.Columns.Add(dgvIsDepartment);

            DataGridViewTextBoxColumn dgvAddress = new DataGridViewTextBoxColumn();
            dgvAddress.HeaderText = "پتہ";
            dgvAddress.ReadOnly = true;
            dgvAddress.Name = "colAddress";
            grdPersons.Columns.Add(dgvAddress);

            DataGridViewImageColumn dgvPersonPic = new DataGridViewImageColumn();
            dgvPersonPic.HeaderText = ".";
            dgvPersonPic.Visible = false;
            dgvPersonPic.Name = "colPersonPic";
            grdPersons.Columns.Add(dgvPersonPic);

        }

        private void fillColumnSelectedPersonGrid()
        {
            DataGridViewTextBoxColumn dgvRegistryPersonId = new DataGridViewTextBoxColumn();
            dgvRegistryPersonId.Name = "colRegistryPersonId";
            dgvRegistryPersonId.Visible = false;
            grdSelectedPersons.Columns.Add(dgvRegistryPersonId);

            DataGridViewTextBoxColumn dgvPersonId = new DataGridViewTextBoxColumn();
            dgvPersonId.Name = "colPersonId";
            dgvPersonId.Visible = false;
            grdSelectedPersons.Columns.Add(dgvPersonId);

            DataGridViewTextBoxColumn dgvPartyTypeId = new DataGridViewTextBoxColumn();
            dgvPartyTypeId.Name = "colPartyTypeId";
            dgvPartyTypeId.Visible = false;
            grdSelectedPersons.Columns.Add(dgvPartyTypeId);

            DataGridViewTextBoxColumn dgvCastId = new DataGridViewTextBoxColumn();
            dgvCastId.Name = "colCasteId";
            dgvCastId.Visible = false;
            grdSelectedPersons.Columns.Add(dgvCastId);

            DataGridViewTextBoxColumn dgvPersonType = new DataGridViewTextBoxColumn();
            dgvPersonType.HeaderText = "پارٹی کی قسم ";
            dgvPersonType.Name = "colPersonType";
            grdSelectedPersons.Columns.Add(dgvPersonType);

            DataGridViewTextBoxColumn dgvFirstName = new DataGridViewTextBoxColumn();
            dgvFirstName.HeaderText = "نام";
            dgvFirstName.Name = "colFirstName";
            grdSelectedPersons.Columns.Add(dgvFirstName);

            DataGridViewTextBoxColumn dgvLastName = new DataGridViewTextBoxColumn();
            dgvLastName.HeaderText = "ولدیت / زوجیت";
            dgvLastName.Name = "colLastName";
            grdSelectedPersons.Columns.Add(dgvLastName);

            DataGridViewTextBoxColumn dgvCNIC = new DataGridViewTextBoxColumn();
            dgvCNIC.HeaderText = "شناختی کارڈ نمبر";
            dgvCNIC.Name = "colCNIC";
            grdSelectedPersons.Columns.Add(dgvCNIC);

            DataGridViewTextBoxColumn dgvCasteName = new DataGridViewTextBoxColumn();
            dgvCasteName.HeaderText = "ذات";
            dgvCasteName.Name = "colCasteName";
            grdSelectedPersons.Columns.Add(dgvCasteName);

            DataGridViewCheckBoxColumn dgvIsGovt = new DataGridViewCheckBoxColumn();
            dgvIsGovt.HeaderText = "حکومت";
            dgvIsGovt.Name = "colIsGovt";
            grdSelectedPersons.Columns.Add(dgvIsGovt);

            DataGridViewCheckBoxColumn dgvIsDepartment = new DataGridViewCheckBoxColumn();
            dgvIsDepartment.HeaderText = "محکمہ";
            dgvIsDepartment.Name = "colIsDepartment";
            grdSelectedPersons.Columns.Add(dgvIsDepartment);

            DataGridViewTextBoxColumn dgvAddress = new DataGridViewTextBoxColumn();
            dgvAddress.HeaderText = "پتہ";
            dgvAddress.Name = "colAddress";
            dgvAddress.Width = 30;
            grdSelectedPersons.Columns.Add(dgvAddress);

            DataGridViewImageColumn dgvPersonPic = new DataGridViewImageColumn();
            dgvPersonPic.HeaderText = ".";
            dgvPersonPic.Name = "colPersonPic";
            dgvPersonPic.Width = 15;
            grdSelectedPersons.Columns.Add(dgvPersonPic);

            DataGridViewButtonColumn dgvDelete = new DataGridViewButtonColumn();
            dgvDelete.HeaderText = "..";
            dgvDelete.Name = "colDelete";
            dgvDelete.Width = 10;
            grdSelectedPersons.Columns.Add(dgvDelete);
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
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["colPersonId"].Value = oeListPerson[i].Person_id;

                    //eRegistryPerson oeRegistryPerson = new eRegistryPerson();
                    //bRegistryPerson obRegistryPerson = new bRegistryPerson();
                    //List<eRegistryPerson> oeListRegistryPerson = new List<eRegistryPerson>();
                    //oeRegistryPerson.Person_id = oeListPerson[i].Person_id;

                    //oeListRegistryPerson = obRegistryPerson.getRegistryPerson(oeRegistryPerson, "", "", 0, int.MaxValue);
                    //if (oeListRegistryPerson != null && oeListRegistryPerson.Count == 1)
                    //{
                    //    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["colPartyTypeId"].Value = oeListRegistryPerson[0].Party_type_id;
                    //}

                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["colCasteId"].Value = oeListPerson[i].Caste_id;


                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["colFirstName"].Value = oeListPerson[i].First_name_urd.Replace("\0", "");
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["colLastName"].Value = oeListPerson[i].Last_name_urd.Replace("\0", "");
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["colCNIC"].Value = oeListPerson[i].Nic.Replace("\0", "");

                    caste_id = oeListPerson[i].Caste_id;
                    if (caste_id != Guid.Empty)
                    {
                        oeCaste.Caste_id = caste_id;
                        oeListCaste = obCaste.getCaste(oeCaste, "", "", 0, int.MaxValue);
                        if (oeListCaste != null && oeListCaste.Count > 0)
                        {
                            grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["colCasteName"].Value = oeListCaste[0].Caste_name_urd.Replace("\0", "");
                        }
                    }
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["colIsGovt"].Value = oeListPerson[i].Is_govt;
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["colIsDepartment"].Value = oeListPerson[i].Is_department;
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["colAddress"].Value = oeListPerson[i].Address_urd.Replace("\0", "");
                    grdPersons.Rows[grdPersons.Rows.Count - 1].Cells["colPersonPic"].Value = oeListPerson[i].Person_pic;
                    //grdPersons.Rows[grdPersons.Rows.Count - 1].Height = 100;
                }
            }
        }

        private void searchPersonRecordByNameAndCNIC()
        {
            ePerson oePerson = new ePerson();
            oePerson.First_name_urd = txtSearchFirstName.Text.Trim();
            oePerson.Last_name_urd = txtSearchLastName.Text.Trim();
            oePerson.Nic = txtSearchCNIC.Text;
            bindPersonGrid(oePerson, true);
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
            if (oeListTerritory.Count > 0)
            {
                cbxDistrict.DisplayMember = "district_name_urd";
                cbxDistrict.ValueMember = "district_id";
                cbxDistrict.DataSource = oeListTerritory;


                cbxTehsil.DisplayMember = "tehsil_name_urd";
                cbxTehsil.ValueMember = "tehsil_id";
                cbxTehsil.DataSource = oeListTerritory;

                cbxMauza.DisplayMember = "mauza_name_urd";
                cbxMauza.ValueMember = "mauza_id";
                cbxMauza.DataSource = oeListTerritory;
                AreaFormat = (enAreaFormat)oeListTerritory[0].Area_format;
                feetPerMaralFromMauzaId = oeListTerritory[0].Feet_per_marla;
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
            else if (oeListRegistryOperations != null && oeListRegistryOperations.Count > 1)
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

        private void disableSCOField()
        {            
            cbxTehsil.Enabled = false;
            cbxDistrict.Enabled = false;
            cbxMauza.Enabled = false;
            txtAmount.Enabled = false;
            pnlBasicInfoBottom.Enabled = false;
            pnlBasicInfoMiddle.Enabled = false;
            btnAddPerson.Enabled = false;
            btnSearchPerson.Enabled = false;
            pnlBasicInfoMiddle.Visible = true;
            btnAddPerson.Enabled = false;
            btnKhasra.Enabled = false;
            btnVerifyFard.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnPrint.Visible = false;
            pnlPersonDetail.Visible = false;
            btnScanning.Enabled = false;
            btnNewRegistry.Enabled = false;
            btnSentToSCI.Visible = false;
            btnPlot.Enabled = false;      
        }

        public void txtRegistryNo_Leave(object sender, EventArgs e)
        {
            if (fromIndexing)
            {
                splitContainer1.Panel1Collapsed = true;
            }
            txtRegistryNo.Enabled = false;
            if (!string.IsNullOrEmpty(txtRegistryNo.Text) && Convert.ToInt32(txtRegistryNo.Text) != 0)
            {
                string strQry = "SELECT * FROM rd.RegistryOperations WHERE registry_no = '" + txtRegistryNo.Text.Trim() + "' AND registry_date = '" + DateTime.Parse(txtDate.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-CA")) + "' AND is_active = 1";
                bRegistryOperations obRegistryOperations = new bRegistryOperations();
                List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
                oeListRegistryOperations = obRegistryOperations.searchRegistryNo(strQry);
                if (oeListRegistryOperations != null && oeListRegistryOperations.Count == 1)
                {
                    if (oeListRegistryOperations[0].Registery_stage == 0)
                    {
                        cbxDistrict.Enabled = false;
                        ddlRegistryType.Enabled = false;
                        cbxTehsil.Enabled = false;
                        cbxMauza.Enabled = false;
                        cbxTown.Enabled = false;
                        pnlBasicInfoMiddle.Visible = false;
                        btnSentToSR.Visible = true;
                        btnKhasra.Enabled = true;
                        btnVerifyFard.Enabled = true;
                        btnSave.Text = "تبدیل کریں";
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                        btnAddPerson.Enabled = true;
                        btnSearchPerson.Enabled = true;
                        btnPrint.Visible = true;
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
                        btnSave.Text = "اپ ڈیٹ";
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSentToSCI.Visible = true;
                        btnScanning.Enabled = true;
                        btnPrint.Visible = false;
                        //btnSentToSR.Visible = true;
                        //btnSentToSR.Text = "&Finalize";
                    }

                    if (oeListRegistryOperations[0].Registery_stage == 2)
                    {
                        disableSCOField();
                    }
                    //else
                    //{
                    //    //Todo: enable field for new registry entry

                    //    btnDelete.Enabled = true;
                    //    btnAddPerson.Enabled = true;
                    //    btnSearchPerson.Enabled = true;
                    //    btnSave.Text = "&Update";
                    //    btnSave.Enabled = true;
                    //}
                    //if (oeListRegistryOperations[0].Registery_stage == 0 && Variables.roleName.ToUpper() == "SCO")
                    //{
                    //    btnSentToSR.Visible = true;
                    //    btnKhasra.Enabled = true;
                    //    btnVerifyFard.Enabled = true;
                    //}
                    //if (oeListRegistryOperations[0].Registery_stage == 2 && Variables.roleName.ToUpper() == "SCO")
                    //{
                    //    btnSentToSCI.Visible = true;
                    //}
                    NewRecord = false;
                    if (oeListRegistryOperations[0].Is_urban == 1)
                    {
                        pnlTown.Visible = true;
                        rbUrban.Checked = true;
                    }
                    else
                    {
                        pnlTown.Visible = false;
                        rbRural.Checked = true;
                    }
                    gbxUrbanRural.Enabled = false;
                    txtRegistryNo.Text = oeListRegistryOperations[0].Registry_no;
                    RegistryId = oeListRegistryOperations[0].Registry_id;
                    txtDate.Text = oeListRegistryOperations[0].Registry_date.ToShortDateString();
                    ddlRegistryType.SelectedValue = oeListRegistryOperations[0].Registry_type_id;
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
                    //txtRegistryNo.Enabled = false;
                    // btnScanning.Enabled = true;
                    //btnKhasra.Enabled = true;
                    //btnVerifyFard.Enabled = true;

                    ddlRegistryType.Enabled = false;
                    loadPersonsOnRegistryNo();
                    isConfig = false;
                }
                else if (oeListRegistryOperations != null && oeListRegistryOperations.Count == 0)
                {
                    if (validateRegField())
                    {
                        updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
                        int isUrban = -1;
                        RegistryId = Guid.NewGuid();
                        if (rbUrban.Checked)
                        {
                            isUrban = 1;
                        }
                        else
                        {
                            isUrban = 0;
                        }
                        oeRegistryOperations = new eRegistryOperations();
                        obRegistryOperations = new bRegistryOperations();
                        oeRegistryOperations.Registry_id = RegistryId;
                        if (ValidateFields.GetSafeGuid(cbxMauza.SelectedValue) == Guid.Empty)
                            oeRegistryOperations.Mauza_id = null;
                        else
                            oeRegistryOperations.Mauza_id = ValidateFields.GetSafeGuid(cbxMauza.SelectedValue);
                        oeRegistryOperations.Service_centre_id = null;
                        oeRegistryOperations.Subregistrar_id = null;
                        oeRegistryOperations.Registery_stage = 0;
                        oeRegistryOperations.Registry_type_id = new Guid(ddlRegistryType.SelectedValue.ToString());
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
                            MessageDisplay("Registry successfully inserted", true);
                            //BindColumnGridOfRegistryInfo();
                            btnKhasra.Enabled = true;
                            btnVerifyFard.Enabled = true;
                            btnAddPerson.Enabled = true;
                            btnSearchPerson.Enabled = true;
                            btnSave.Enabled = false;
                            ddlRegistryType.Enabled = false;
                            btnSentToSR.Visible = true;
                            btnAddPerson_Click(sender, e);
                        }
                        else
                        {
                            MessageDisplay("Registry not entered", false);
                        }
                    }
                    else
                    {
                        if (!checkCurrentDate())
                        {
                            // MessageDisplay("You can't enter new registry", false);
                        }
                        else
                        {
                            btnSave.Enabled = true;
                            NewRecord = true;
                            ddlRegistryType.Enabled = true;
                            RegistryId = Guid.NewGuid();
                            isConfig = true;
                            cbxDistrict.Enabled = true;
                            cbxTehsil.Enabled = true;
                            cbxTown.Enabled = true;
                            cbxMauza.Enabled = true;
                            //loadDistrict();
                            btnSave.Text = "محفوظ کریں";
                        }
                    }
                }
                else
                {
                    if (!checkCurrentDate())
                    {
                        MessageDisplay("آپ نئ رجسٹری نہیں بنا سکتے۔", false);
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        NewRecord = true;
                        ddlRegistryType.Enabled = true;
                        RegistryId = Guid.NewGuid();
                        isConfig = true;
                        cbxDistrict.Enabled = true;
                        cbxTehsil.Enabled = true;
                        cbxTown.Enabled = true;
                        cbxMauza.Enabled = true;
                        //loadDistrict();
                        btnSave.Text = "محفوظ کریں";
                    }
                }
            }
            else
            {
                MessageDisplay("رجسٹری نمبر کا اندراج کریں", false);
                txtRegistryNo.Enabled = true;
                txtRegistryNo.Focus();
                return;
            }
            if (checkRegistryStage(RegistryId) == 0 || checkRegistryStage(RegistryId) == -1)
            {
                pnlBasicInfoMiddle.Visible = false;
            }
            else
            {
                pnlBasicInfoMiddle.Visible = true;
            }

            #region Comment before SR role break
            /*
            if (fromIndexing)
            {
                splitContainer1.Panel1Collapsed = true;
            }
            txtRegistryNo.Enabled = false;
            if (!string.IsNullOrEmpty(txtRegistryNo.Text) && Convert.ToInt32(txtRegistryNo.Text) != 0)
            {
                string strQry = "SELECT * FROM rd.RegistryOperations WHERE registry_no = '" + txtRegistryNo.Text.Trim() + "' AND registry_date = '" + DateTime.Parse(txtDate.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-CA")) + "' AND is_active = 1";
                bRegistryOperations obRegistryOperations = new bRegistryOperations();
                List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
                oeListRegistryOperations = obRegistryOperations.searchRegistryNo(strQry);
                if (oeListRegistryOperations != null && oeListRegistryOperations.Count == 1)
                {
                    if (oeListRegistryOperations[0].Registery_stage != 1 && oeListRegistryOperations[0].Registery_stage != 0)
                    {
                        disableSCOField();
                    }
                    else
                    {
                        //Todo: enable field for new registry entry

                        btnDelete.Enabled = true;
                        btnAddPerson.Enabled = true;
                        btnSearchPerson.Enabled = true;
                        btnSave.Text = "&Update";
                        btnSave.Enabled = true;
                    }
                    if (oeListRegistryOperations[0].Registery_stage == 0 && Variables.roleName.ToUpper() == "SCO")
                    {
                        btnSentToSR.Visible = true;
                        btnKhasra.Enabled = true;
                        btnVerifyFard.Enabled = true;
                    }
                    if (oeListRegistryOperations[0].Registery_stage == 2 && Variables.roleName.ToUpper() == "SCO")
                    {
                        btnSentToSCI.Visible = true;
                    }
                    NewRecord = false;
                    if (oeListRegistryOperations[0].Is_urban == 1)
                    {
                        pnlTown.Visible = true;
                        rbUrban.Checked = true;
                    }
                    else
                    {
                        pnlTown.Visible = false;
                        rbRural.Checked = true;
                    }
                    if (oeListRegistryOperations[0].Registery_stage == 5)
                    {
                        btnScanning.Enabled = false;
                    }
                    else
                    {
                        btnScanning.Enabled = true;
                    }
                    gbxUrbanRural.Enabled = false;
                    txtRegistryNo.Text = oeListRegistryOperations[0].Registry_no;                    
                    RegistryId = oeListRegistryOperations[0].Registry_id;
                    txtDate.Text = oeListRegistryOperations[0].Registry_date.ToShortDateString();
                    ddlRegistryType.SelectedValue = oeListRegistryOperations[0].Registry_type_id;
                    loadTerritoryFromMauza((Guid)(oeListRegistryOperations[0].Mauza_id),rbUrban.Checked);
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
                    txtRegistryNo.Enabled = false;
                   // btnScanning.Enabled = true;
                    //btnKhasra.Enabled = true;
                    //btnVerifyFard.Enabled = true;
                    if (Variables.roleName.ToUpper() == "SR")
                    {
                        disableSRField();
                    }
                    else
                    {
                        //btnAddPerson.Enabled = true;
                        //btnSearchPerson.Enabled = true;
                    }
                    //btnSave.Text = "Update";
                    //btnSave.Enabled = true;
                    ddlRegistryType.Enabled = false;
                    loadPersonsOnRegistryNo();
                    isConfig = false;
                }
                else
                {
                    if (!checkCurrentDate())
                    {
                        MessageDisplay("You can't enter new registry", false);
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        NewRecord = true;
                        ddlRegistryType.Enabled = true;
                        RegistryId = Guid.NewGuid();
                        isConfig = true;
                        //loadDistrict();
                        btnSave.Text = "Save";
                    }
                }
            }
            else
            {
                MessageDisplay("Please enter valid registry number",false);
                txtRegistryNo.Enabled = true;
                txtRegistryNo.Focus();
                return;
            }
            if (checkRegistryStage(RegistryId) == 0 || checkRegistryStage(RegistryId) == -1)
            {
                pnlBasicInfoMiddle.Visible = false;
            }
            else
            {
                pnlBasicInfoMiddle.Visible = true;
            }
            */
            #endregion
        }

        private bool checkPersonEmptyField()
        {
            bool isEmpty = true;
            if (txtFirstName.Text == string.Empty)
            {
                isEmpty = false;
                txtFirstName.Focus();
                MessageDisplay("شخص کے نام کا اندراج کریں۔", false);
                return isEmpty;
            }
            if (txtLastName.Text == string.Empty)
            {
                isEmpty = false;
                txtLastName.Focus();
                MessageDisplay("ولدیت / زوجیت کا اندراج کریں۔", false);
                return isEmpty;
            }

            if (txtCNIC.Text == string.Empty)
            {
                isEmpty = false;
                txtCNIC.Focus();
                MessageDisplay("شناختی کارڈ کا اندراج کریں۔ ", false);
                return isEmpty;
            }

            if (cbxCaste.SelectedIndex == 0)
            {
                isEmpty = false;
                cbxCaste.Focus();
                MessageDisplay("قوم کا انتخاب کریں", false);
                return isEmpty;
            }

            if (cbPartyType.SelectedIndex == 0 || cbPartyType.SelectedItem == null)
            {
                isEmpty = false;
                cbPartyType.Focus();
                MessageDisplay("پارٹی کی قسم کا انتخاب کریں۔", false);
                return isEmpty;
            }

            if (txtTotalArea.Text != string.Empty)
            {
                if (!ValidateArea(txtTotalArea.Text.Trim()))
                {
                    isEmpty = false;
                    txtTotalArea.Focus();
                    MessageDisplay("کل رقبہ کا اندراج ٹھیک کریں۔", false);
                    return isEmpty;
                }
            }

            if (txtTransferArea.Text != string.Empty)
            {
                if (!ValidateArea(txtTransferArea.Text.Trim()))
                {
                    isEmpty = false;
                    txtTransferArea.Focus();
                    MessageDisplay("منتقل رقبہ کا ٹھیک اندراج کریں۔", false);
                    return isEmpty;
                }
            }
            if (txtTotalShare.Text != string.Empty)
            {
                if (!ValidateShare(txtTotalShare.Text))
                {
                    isEmpty = false;
                    txtTotalShare.Focus();
                    MessageDisplay("کل حصہ درست کریں", false);
                    return isEmpty;
                }
            }

            if (txtTransferShare.Text != string.Empty)
            {
                if (!ValidateShare(txtTransferShare.Text))
                {
                    isEmpty = false;
                    txtTransferShare.Focus();
                    MessageDisplay("حصہ منتقلہ درست کریں", false);
                    return isEmpty;
                }
            }

            return isEmpty;
        }

        private bool ValidateShare(string Share)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(Share, "^[1-9]+[0-9]*[/][1-9]+[0-9]*$");
        }

        private void btnInsertPerson_Click(object sender, EventArgs e)
        {
            if (btnInsertPerson.Text == "شخص کا اندراج") isPersonUpdate = false;
            if (checkPersonEmptyField())
            {
                eRegistryPerson oeRegistryPerson = new eRegistryPerson();
                bRegistryPerson obRegistryPerson = new bRegistryPerson();
                List<eRegistryPerson> oeListRegistryPerson = new List<eRegistryPerson>();
                ePerson oePerson = new ePerson();
                bPerson obPerson = new bPerson();
                updatedNewEntryInfo info = new updatedNewEntryInfo();

                oePerson.First_name_urd = txtFirstName.Text.Trim();
                oePerson.Last_name_urd = txtLastName.Text.Trim();
                oePerson.Address_urd = txtAddress.Text.Trim();
                oePerson.Nic = txtCNIC.Text;
                if (cbxCaste.Items.Count > 0)
                {
                    oePerson.Caste_id = ValidateFields.GetSafeGuid(cbxCaste.SelectedValue.ToString());
                }
                oePerson.Is_govt = chkGovt.Checked;
                oePerson.Is_department = chkDepartment.Checked;
                //oePerson.Is_blocked = chkBlock.Checked;
                oePerson.User_id = Variables.UserId;
                oePerson.Access_date_time = DateTime.Now;
                oePerson.Is_active = true;
                oePerson.Mauza_id = ValidateFields.GetSafeGuid(cbxMauza.SelectedValue.ToString());
                oePerson.Pic_path = "";

                Image img = Picture.Image;
                if (img != null)
                {
                    string filePath = Application.StartupPath + "\\" + oePerson.Person_id + ".jpg";
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    FileStream fstream = new FileStream(filePath, FileMode.Create);
                    img.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    fstream.Close();

                    MemoryStream fingerprintData = new MemoryStream();
                    Template.Serialize(fingerprintData);
                    fingerprintData.Position = 0;
                    BinaryReader br = new BinaryReader(fingerprintData);
                    Byte[] bytes = br.ReadBytes((Int32)fingerprintData.Length);


                    oePerson.Thumb = bytes;//System.IO.File.ReadAllBytes(filePath);
                }
                else
                {
                    oePerson.Thumb = null;
                }
                if (isPersonUpdate)
                {
                    oePerson.Person_id = personId;
                    Image image = imgCapture.Image;
                    if (image != null)
                    {
                        string filePath = Application.StartupPath + "\\" + oePerson.Person_id + ".jpg";
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                        FileStream fstream = new FileStream(filePath, FileMode.Create);
                        image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        fstream.Close();

                        oePerson.Person_pic = System.IO.File.ReadAllBytes(filePath);
                    }
                    else
                    {
                        oePerson.Person_pic = null;
                    }
                    info = obPerson.udpatePerson(oePerson, false);
                }
                else
                {
                    oePerson.Person_id = Guid.NewGuid();

                    Image image = imgCapture.Image;
                    if (image != null)
                    {
                        string filePath = Application.StartupPath + "\\" + oePerson.Person_id + ".jpg";
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                        FileStream fstream = new FileStream(filePath, FileMode.Create);
                        image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        fstream.Close();

                        oePerson.Person_pic = System.IO.File.ReadAllBytes(filePath);
                    }
                    else
                    {
                        oePerson.Person_pic = null;
                    }
                    info = obPerson.insertPerson(oePerson);
                }

                if (info.Success)
                {
                    oeRegistryPerson.Registry_id = RegistryId;
                    oeRegistryPerson.Person_id = ValidateFields.GetSafeGuid(info.Id);
                    //string sPersonType = cbPartyType.Text.ToString();

                    //*****************************************************//
                    //Guid sTypeId = ValidateFields.GetSafeGuid(cbPartyType.SelectedValue);
                    //*****************************************************//


                    if (isPersonUpdate)
                    {
                        oeListRegistryPerson = obRegistryPerson.getRegistryPerson(oeRegistryPerson, "", "", 0, int.MaxValue);
                        if (oeListRegistryPerson != null && oeListRegistryPerson.Count == 1)
                        {
                            oeRegistryPerson.Registryperson_id = oeListRegistryPerson[0].Registryperson_id;
                            oeRegistryPerson.Access_datetime = DateTime.Now;
                            oeRegistryPerson.User_id = Variables.UserId;
                            oeRegistryPerson.Party_type_id = ValidateFields.GetSafeGuid(cbPartyType.SelectedValue);
                            //oeRegistryPerson.Party_name_eng = cbPartyType.Text.ToString();
                            //oeRegistryPerson.Is_seller = getSellerBuyerType(sPersonType);
                            //Area = txtTotalArea.Text.Trim();
                            if (txtTotalArea.Text != string.Empty)
                            {
                                areaValue = txtTotalArea.Text.Trim();
                                string areaToFeet = AreaToFeet(areaValue, feetPerMaralFromMauzaId);
                                oeRegistryPerson.Total_area = ValidateFields.GetSafeInt64(areaToFeet);
                            }
                            else
                            {
                                oeRegistryPerson.Total_area = 0;
                            }
                            if (txtTransferArea.Text != string.Empty)
                            {
                                areaValue = txtTransferArea.Text.Trim();
                                string transferAreaToFeet = AreaToFeet(areaValue, feetPerMaralFromMauzaId);
                                oeRegistryPerson.Transferred_area = ValidateFields.GetSafeInt64(transferAreaToFeet);
                            }
                            else
                            {
                                oeRegistryPerson.Transferred_area = 0;
                            }

                            oeRegistryPerson.Total_share = txtTotalShare.Text.Trim();
                            oeRegistryPerson.Transferred_share = txtTransferShare.Text.Trim();
                            info = obRegistryPerson.udpateRegistryPerson(oeRegistryPerson);

                        }
                        else
                        {
                            oeRegistryPerson.Access_datetime = DateTime.Now;
                            oeRegistryPerson.User_id = Variables.UserId;
                            oeRegistryPerson.Registryperson_id = Guid.NewGuid();
                            oeRegistryPerson.Party_type_id = ValidateFields.GetSafeGuid(cbPartyType.SelectedValue);
                            //oeRegistryPerson.Party_name_eng = cbPartyType.Text.ToString();
                            //oeRegistryPerson.Is_seller = getSellerBuyerType(sPersonType);
                            //FeetPerMarla = 272;
                            FeetPerMarla = (short)feetPerMaralFromMauzaId;
                            if (txtTotalArea.Text != string.Empty)
                            {
                                areaValue = txtTotalArea.Text.Trim();
                                string areaToFeet = AreaToFeet(areaValue, feetPerMaralFromMauzaId);
                                oeRegistryPerson.Total_area = ValidateFields.GetSafeInt64(areaToFeet);
                            }
                            else
                            {
                                oeRegistryPerson.Total_area = 0;
                            }
                            if (txtTransferArea.Text != string.Empty)
                            {
                                areaValue = txtTransferArea.Text.Trim();
                                string transferAreaToFeet = AreaToFeet(areaValue, feetPerMaralFromMauzaId);
                                oeRegistryPerson.Transferred_area = ValidateFields.GetSafeInt64(transferAreaToFeet);
                            }
                            else
                            {
                                oeRegistryPerson.Transferred_area = 0;
                            }
                            oeRegistryPerson.Total_share = txtTotalShare.Text.Trim();
                            oeRegistryPerson.Transferred_share = txtTransferShare.Text.Trim();
                            info = obRegistryPerson.insertRegistryPerson(oeRegistryPerson);
                        }
                    }
                    else
                    {
                        oeRegistryPerson.Access_datetime = DateTime.Now;
                        oeRegistryPerson.User_id = Variables.UserId;
                        oeRegistryPerson.Registryperson_id = Guid.NewGuid();
                        oeRegistryPerson.Party_type_id = ValidateFields.GetSafeGuid(cbPartyType.SelectedValue);
                        //oeRegistryPerson.Party_name_eng = cbPartyType.Text.ToString();
                        //oeRegistryPerson.Is_seller = getSellerBuyerType(sPersonType);
                        //FeetPerMarla = 272;
                        FeetPerMarla = (short)feetPerMaralFromMauzaId;
                        if (txtTotalArea.Text != string.Empty)
                        {
                            areaValue = txtTotalArea.Text.Trim();
                            string areaToFeet = AreaToFeet(areaValue, feetPerMaralFromMauzaId);
                            oeRegistryPerson.Total_area = ValidateFields.GetSafeInt64(areaToFeet);
                        }
                        else
                        {
                            oeRegistryPerson.Total_area = 0;
                        }
                        if (txtTransferArea.Text != string.Empty)
                        {
                            areaValue = txtTransferArea.Text.Trim();
                            string transferAreaToFeet = AreaToFeet(areaValue, feetPerMaralFromMauzaId);
                            oeRegistryPerson.Transferred_area = ValidateFields.GetSafeInt64(transferAreaToFeet);
                        }
                        else
                        {
                            oeRegistryPerson.Transferred_area = 0;
                        }
                        oeRegistryPerson.Total_share = txtTotalShare.Text.Trim();
                        oeRegistryPerson.Transferred_share = txtTransferShare.Text.Trim();
                        info = obRegistryPerson.insertRegistryPerson(oeRegistryPerson);
                    }
                    //oeRegistryPerson.Is_seller = cbBuyerSeller.SelectedIndex;
                    int match = 0;
                    if (info.Success)
                    {
                        if (grdSelectedPersons.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow dRow in grdSelectedPersons.Rows)
                            {
                                if (ValidateFields.GetSafeString(dRow.Cells["colPersonId"].Value) == ValidateFields.GetSafeString(oeRegistryPerson.Person_id))
                                {
                                    dRow.Cells["colRegistryPersonId"].Value = oeRegistryPerson.Registryperson_id;
                                    dRow.Cells["colPersonId"].Value = oePerson.Person_id;
                                    dRow.Cells["colPartyTypeId"].Value = oeRegistryPerson.Party_type_id;
                                    dRow.Cells["colCasteId"].Value = oePerson.Caste_id;
                                    dRow.Cells["colPersonType"].Value = cbPartyType.Text.ToString(); // grdPersons.Rows[e.RowIndex].Cells["colPersonType"].Value;
                                    dRow.Cells["colFirstName"].Value = oePerson.First_name_urd;
                                    dRow.Cells["colLastName"].Value = oePerson.Last_name_urd;
                                    dRow.Cells["colCNIC"].Value = oePerson.Nic;
                                    dRow.Cells["colCasteName"].Value = (cbxCaste.SelectedItem == null) ? "" : cbxCaste.Text.ToString();
                                    dRow.Cells["colIsGovt"].Value = oePerson.Is_govt;
                                    dRow.Cells["colIsDepartment"].Value = oePerson.Is_department;
                                    dRow.Cells["colAddress"].Value = oePerson.Address_urd;
                                    dRow.Cells["colPersonPic"].Value = oePerson.Person_pic;
                                    dRow.Height = 100;
                                    //pnlPersonDetail.Visible = false;
                                    MessageDisplay("صارف کا ریکارڈ تبدیل ہو گیا ہے۔", true);
                                    match = 1;
                                    resetPersonFields();
                                    //return;
                                }
                            }
                        }
                        if (match == 0)
                        {
                            grdSelectedPersons.Rows.Add();
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colRegistryPersonId"].Value = oeRegistryPerson.Registryperson_id;
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colPersonId"].Value = oePerson.Person_id;
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colPartyTypeId"].Value = oeRegistryPerson.Party_type_id;
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colCasteId"].Value = oePerson.Caste_id;
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colPersonType"].Value = cbPartyType.Text.ToString(); // grdPersons.Rows[e.RowIndex].Cells["colPersonType"].Value;
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colFirstName"].Value = oePerson.First_name_urd;
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colLastName"].Value = oePerson.Last_name_urd;
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colCNIC"].Value = oePerson.Nic;
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colCasteName"].Value = (cbxCaste.SelectedItem == null && cbxCaste.Text == string.Empty) ? "" : cbxCaste.Text;
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colIsGovt"].Value = oePerson.Is_govt;
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colIsDepartment"].Value = oePerson.Is_department;
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colAddress"].Value = oePerson.Address_urd;
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colPersonPic"].Value = oePerson.Person_pic;
                            grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Height = 100;
                            //pnlPersonDetail.Visible = false;
                            MessageDisplay("شخص کا اندراج ہو گیا ہے۔", true);
                            oePerson = new ePerson();
                            bindPersonGrid(oePerson, false);
                            match = 0;
                            resetPersonFields();
                        }
                    }
                    else
                    {
                        //todo: delete fucntionality of person
                    }
                }
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private int getSellerBuyerType(string sPersonType)
        {
            int sellorStatus = -1;
            //string sPersonType = cbBuyerSeller.SelectedItem.ToString();// grdPersons.Rows[e.RowIndex].Cells["colPersonType"].Value.ToString();
            switch (sPersonType.ToUpper())
            {
                case "WITNESS":
                    sellorStatus = 1;
                    break;
                case "BUYER":
                    sellorStatus = 2;
                    break;
                case "SELLER":
                    sellorStatus = 3;
                    break;
                case "WAHAB":
                    sellorStatus = 2;
                    break;
                case "MAHOOB":
                    sellorStatus = 3;
                    break;
                case "TABADLA DAHINDA":
                    sellorStatus = 2;
                    break;
                case "TABADLA GARINDA":
                    sellorStatus = 3;
                    break;

                case "گواہ":
                    sellorStatus = 1;
                    break;
                case "مشتری":
                    sellorStatus = 2;
                    break;
                case "بائع":
                    sellorStatus = 3;
                    break;
                case "واحب":
                    sellorStatus = 2;
                    break;
                case "ماحوب":
                    sellorStatus = 3;
                    break;
                case "تبادلہ دہندہ":
                    sellorStatus = 2;
                    break;
                case "تبادلہ گرندہ":
                    sellorStatus = 3;
                    break;
                default:
                    break;
            }
            return sellorStatus;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            if (isRegistryIdExist())
            {
                if (pnlPersonDetail.Visible == true)
                {
                    pnlPersonDetail.Visible = false;
                }
                else
                {
                    pnlPersonDetail.Visible = true;
                }
                if (pnlPersonDetail.Visible)
                {
                    btnAddPerson.Text = "شخص کو چھپائیں";
                    fillCasteComboBox();
                    splitContainer1.Panel1Collapsed = true;
                    resetPersonFields();
                    isPersonUpdate = false;
                    txtFirstName.Focus();
                    try
                    {
                        webcam = new WebCam();
                        webcam.InitializeWebCam(ref imgVideo);
                        webcam.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageDisplay("کیمرہ موجود نہیں ہے۔", false);
                    }
                    imgVideo.Visible = true;
                    imgCapture.Visible = false;
                }
                else
                {
                    btnAddPerson.Text = "نیا شخص";
                }
            }
            else
            {
                MessageDisplay("رجسٹری موجود نہیں ہے", false);
            }
        }        

        private void resetPersonFields()
        {
            pnlPersonDetail.Visible = true;
            fillCasteComboBox();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAddress.Clear();
            txtCNIC.Clear();
            cbxCaste.SelectedIndex = 0;
            cbPartyType.SelectedIndex = 0;
            txtTotalArea.Clear();
            txtTransferArea.Clear();
            txtTotalShare.Clear();
            txtTransferShare.Clear();
            //chkBlock.Checked = false;
            chkDepartment.Checked = false;
            chkGovt.Checked = false;
            btnInsertPerson.Text = "شخص کا اندراج";
            //cbGender.SelectedIndex = 0;
            ddlAreaFormat.SelectedIndex = 2;
            imgCapture.Image = null;
            //imgCapture.Visible = true;
            //imgVideo.Visible = false;
            Picture.Image = null;
            btnRegisterThumb.Enabled = true;
            btnRegisterThumb.Text = "رجسٹر";
            Stop();
            StatusLine.Clear();
        }

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            if (isRegistryIdExist())
            {
                if (splitContainer1.Panel1Collapsed == true)
                    splitContainer1.Panel1Collapsed = false;
                else
                    splitContainer1.Panel1Collapsed = true;

                ePerson oePerson = new ePerson();
                bindPersonGrid(oePerson, false);
                txtSearchCNIC.Enabled = true;
                txtSearchFirstName.Enabled = true;
                txtSearchLastName.Enabled = true;
            }
        }

        private void grdPersons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string strPersonType = grdPersons.SelectedRows[0].Cells[2].Value.tostring();
            if (isRegistryIdExist() && Variables.roleName.ToUpper() == "SCO")
            {
                if (grdPersons.SelectedRows[0].Cells["colPersonType"].Value == null || ValidateFields.GetSafeGuid(grdPersons.SelectedRows[0].Cells["colPersonType"].Value) == Guid.Empty)
                {
                    MessageDisplay("شخص کی قسم نہیں ہے۔", false);
                    return;
                }
                if (grdSelectedPersons.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dgvRow in grdSelectedPersons.Rows)
                    {
                        if (ValidateFields.GetSafeString(dgvRow.Cells["colPersonId"].Value) == ValidateFields.GetSafeString(grdPersons.Rows[e.RowIndex].Cells["colPersonId"].Value))
                        {
                            return;
                        }
                    }
                }
                eRegistryPerson oeRegistryPerson = new eRegistryPerson();
                bRegistryPerson obRegistryPerson = new bRegistryPerson();
                updatedNewEntryInfo info = new updatedNewEntryInfo();
                oeRegistryPerson.Registryperson_id = Guid.NewGuid();
                oeRegistryPerson.Registry_id = RegistryId;
                oeRegistryPerson.Person_id = ValidateFields.GetSafeGuid(grdPersons.Rows[e.RowIndex].Cells["colPersonId"].Value);
                string sPersonType = cbPartyType.Text;
                oeRegistryPerson.Party_type_id = ValidateFields.GetSafeGuid(cbPartyType.SelectedValue);
                //oeRegistryPerson.Party_name_eng = cbPartyType.Text.ToString();
                //oeRegistryPerson.Is_seller = getSellerBuyerType(sPersonType);
                oeRegistryPerson.Access_datetime = DateTime.Now;
                oeRegistryPerson.User_id = Variables.UserId;
                info = obRegistryPerson.insertRegistryPerson(oeRegistryPerson);
                if (info.Success)
                {
                    grdSelectedPersons.Rows.Add();
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colRegistryPersonId"].Value = grdPersons.Rows[e.RowIndex].Cells["colRegistryPersonId"].Value;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colPersonId"].Value = grdPersons.Rows[e.RowIndex].Cells["colPersonId"].Value;
                    //grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colPartyTypeId"].Value = grdPersons.Rows[e.RowIndex].Cells["colPartyTypeId"].Value;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colCasteId"].Value = grdPersons.Rows[e.RowIndex].Cells["colCasteId"].Value;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colPersonType"].Value = grdPersons.Rows[e.RowIndex].Cells["colPersonType"].FormattedValue;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colFirstName"].Value = grdPersons.Rows[e.RowIndex].Cells["colFirstName"].Value;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colLastName"].Value = grdPersons.Rows[e.RowIndex].Cells["colLastName"].Value;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colCNIC"].Value = grdPersons.Rows[e.RowIndex].Cells["colCNIC"].Value;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colCasteName"].Value = grdPersons.Rows[e.RowIndex].Cells["colCasteName"].Value;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colIsGovt"].Value = grdPersons.Rows[e.RowIndex].Cells["colIsGovt"].Value;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colIsDepartment"].Value = grdPersons.Rows[e.RowIndex].Cells["colIsDepartment"].Value;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colAddress"].Value = grdPersons.Rows[e.RowIndex].Cells["colAddress"].Value;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Cells["colPersonPic"].Value = grdPersons.Rows[e.RowIndex].Cells["colPersonPic"].Value;
                    grdSelectedPersons.Rows[grdSelectedPersons.Rows.Count - 1].Height = 100;
                    MessageDisplay("شخص کا اندراج ہو گیا ہے۔", true);
                }
                else
                {
                    MessageDisplay("آفسر سے رجوع کریں۔", false);
                }
            }
        }

        private void valuesBindWithControlFromGrid(DataGridView obj)
        {
            fillCasteComboBox();
            //ddlAreaFormat.SelectedIndex = 2;
            ddlAreaFormat.SelectedIndex = (int)AreaFormat;
            //AreaFormat = enAreaFormat.KanalMarlaFeet;
            eRegistryPerson oeRegistryPerson = new eRegistryPerson();
            List<eRegistryPerson> oeListRegistryPerson = new List<eRegistryPerson>();
            bRegistryPerson obRegistryPerson = new bRegistryPerson();
            registryPersonId = ValidateFields.GetSafeGuid(obj.Rows[obj.SelectedRows[0].Index].Cells["colRegistryPersonId"].Value);
            if (registryPersonId != Guid.Empty)
            {
                ///////********************     Working in this task because gridPerson has no RegistryPerson information
                oeRegistryPerson.Registryperson_id = registryPersonId;
                oeListRegistryPerson = obRegistryPerson.getRegistryPerson(oeRegistryPerson, "", "", 0, int.MaxValue);
                if (oeListRegistryPerson != null && oeListRegistryPerson.Count == 1)
                {
                    //FeetPerMarla = 272;
                    FeetPerMarla = (short)feetPerMaralFromMauzaId;
                    areaValue = oeListRegistryPerson[0].Total_area.ToString();
                    long areaValueAgainstMauza = Convert.ToInt64(areaValue);
                    areaValue = FeetToArea(areaValueAgainstMauza, feetPerMaralFromMauzaId, AreaFormat);
                    //Area = areaValue;
                    if (areaValue == "0")
                    {
                        txtTotalArea.Clear();
                    }
                    else
                    {
                        txtTotalArea.Text = areaValue;
                    }
                    transferedAreaValue = oeListRegistryPerson[0].Transferred_area.ToString();
                    //Area = areaValue;
                    long transferedAareaVal = Convert.ToInt64(transferedAreaValue);
                    transferedAreaValue = FeetToArea(transferedAareaVal, feetPerMaralFromMauzaId, AreaFormat);
                    if (transferedAreaValue == "0")
                    {
                        txtTransferArea.Clear();
                    }
                    else
                    {
                        txtTransferArea.Text = transferedAreaValue;
                    }
                    txtTotalShare.Text = oeListRegistryPerson[0].Total_share;
                    txtTransferShare.Text = oeListRegistryPerson[0].Transferred_share;
                }
            }
            else
            {
                txtTotalArea.Clear();
                txtTransferArea.Clear();
                txtTotalShare.Clear();
                txtTransferShare.Clear();
            }

            personId = ValidateFields.GetSafeGuid(obj.Rows[obj.SelectedRows[0].Index].Cells["colPersonId"].Value);
            ePerson oePerson = new ePerson();
            List<ePerson> oeListPerson = new List<ePerson>();
            bPerson obPerson = new bPerson();
            oePerson.Person_id = personId;
            oeListPerson = obPerson.getPerson(oePerson, "", "", 0, int.MaxValue);
            if (oeListPerson != null && oeListPerson.Count > 0)
            {
                if (oeListPerson[0].Thumb == null)
                {
                    btnRegisterThumb.Text = "رجسٹر";
                }
                else
                {
                    btnRegisterThumb.Text = "تصدیق کریں";
                }
            }

            txtFirstName.Text = obj.Rows[obj.SelectedRows[0].Index].Cells["colFirstName"].Value.ToString();
            txtLastName.Text = obj.Rows[obj.SelectedRows[0].Index].Cells["colLastName"].Value.ToString();
            txtAddress.Text = obj.Rows[obj.SelectedRows[0].Index].Cells["colAddress"].Value.ToString();
            txtCNIC.Text = obj.Rows[obj.SelectedRows[0].Index].Cells["colCNIC"].Value.ToString();
            cbxCaste.SelectedValue = obj.Rows[obj.SelectedRows[0].Index].Cells["colCasteId"].Value;
            Guid partyId = ValidateFields.GetSafeGuid(obj.Rows[obj.SelectedRows[0].Index].Cells["colPartyTypeId"].Value);
            cbPartyType.SelectedValue = partyId;
            //string sPersonType = ValidateFields.GetSafeString(obj.Rows[obj.SelectedRows[0].Index].Cells["colPersonType"].Value);
            //cbPartyType.SelectedIndex = getSellerBuyerType(sPersonType);
            chkDepartment.Checked = ValidateFields.GetSafeBoolean(obj.Rows[obj.SelectedRows[0].Index].Cells["colIsDepartment"].Value);
            chkGovt.Checked = ValidateFields.GetSafeBoolean(obj.Rows[obj.SelectedRows[0].Index].Cells["colIsGovt"].Value);
            imgVideo.Visible = false;
            imgCapture.Visible = true;
            if (obj.Rows[obj.SelectedRows[0].Index].Cells["colPersonPic"].Value != null)
            {
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(obj.Rows[obj.SelectedRows[0].Index].Cells["colPersonPic"].Value));
                imgCapture.Image = x;
            }
            else
            {
                //string defaultImagePath = Application.StartupPath + "\\" + ConfigurationManager.AppSettings["defaultImage"].ToString();
                //var imageBytes = File.ReadAllBytes(defaultImagePath);
                //var image = imageBytes.ToImage();
                //image.Save("output.bmp");
                //byte[] imgByte = Convert.FromBase64String(defaultImagePath);
                //Image x = (Bitmap)((new ImageConverter()).ConvertFromString(defaultImagePath));
                imgCapture.Image = null;// Image.FromFile(string.Format(@"StdImage\{0}", defaultImagePath));
            }
            pnlPersonDetail.Visible = true;
            isPersonUpdate = true;
            btnInsertPerson.Text = "شخص میں تبدیلی";
            btnAddPerson.Text = "شخص کو چھپائیں";
        }

        private void grdSelectedPersons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (iRegistryStage == 0)
            {
                if (grdSelectedPersons.SelectedRows.Count > 0)
                {
                    valuesBindWithControlFromGrid(grdSelectedPersons);
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Stop();
            if (isRegistryIdExist())
            {
                SRApprovalForm_English obj = new SRApprovalForm_English();
                obj.registry_stage = 2;
                obj.RegistryId = RegistryId;
                obj.ShowDialog();
            }
            else
            {
                MessageDisplay("اس رجسٹری کے متعلقہ ریکارڈ نہیں ہے۔ مہربانی کر کے پہلے رجسٹری بنائیں۔", true);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            Stop();
            if (isRegistryIdExist())
            {
                SRApprovalForm_English obj = new SRApprovalForm_English();
                obj.registry_stage = 3;
                obj.RegistryId = RegistryId;
                obj.ShowDialog();
            }
            else
            {
                MessageDisplay("اس رجسٹری کے متعلقہ ریکارڈ نہیں ہے۔ مہربانی کر کے پہلے رجسٹری بنائیں۔", true);
            }
        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            if (grdPersons.SelectedRows.Count > 0)
            {
                valuesBindWithControlFromGrid(grdPersons);
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

        private void grdSelectedPersons_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                e.Value = "خارج کریں";                
            }
            e.CellStyle.WrapMode = DataGridViewTriState.False;
        }

        private void grdSelectedPersons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 13)
            {
                if (iRegistryStage == 0)
                {
                    var result = MessageBox.Show("Are you sure to delete a record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        DataGridViewRow dgvRow = grdSelectedPersons.Rows[e.RowIndex];
                        deletePersonFromSelectedPersonGrid(dgvRow);
                    }
                }
            }
        }

        private void deletePersonFromSelectedPersonGrid(DataGridViewRow dgvrow)
        {
            eRegistryPerson oeRegistryPerson = new eRegistryPerson();
            List<eRegistryPerson> oeListRegistryPerson = new List<eRegistryPerson>();
            bRegistryPerson obRegistryPerson = new bRegistryPerson();
            updatedNewEntryInfo info = new updatedNewEntryInfo();
            oeRegistryPerson.Person_id = ValidateFields.GetSafeGuid(dgvrow.Cells["colPersonId"].Value);
            oeRegistryPerson.Registry_id = RegistryId;
            oeListRegistryPerson = obRegistryPerson.getRegistryPerson(oeRegistryPerson, "", "", 0, int.MaxValue);
            if (oeListRegistryPerson != null && oeListRegistryPerson.Count == 1)
            {
                oeRegistryPerson.Registryperson_id = oeListRegistryPerson[0].Registryperson_id;
                info = obRegistryPerson.deleteRegistryPerson(oeRegistryPerson);
                if (info.Success)
                {
                    MessageDisplay("شخص کا ریکارڈ خارج ہو گیا ہے۔", true);
                    loadPersonsOnRegistryNo();
                }
            }
            else
                loadPersonsOnRegistryNo();
        }

        
        private void btnCapture_Click(object sender, EventArgs e)
        {
            imgCapture.Image = imgVideo.Image;
            imgCapture.Visible = true;
            imgVideo.Visible = false;
        }

        private void ddlRegistryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRegistryType.SelectedIndex != 0)
            {
                ePartyType oePartyType = new ePartyType();
                oePartyType.Registry_type_id = ValidateFields.GetSafeGuid(ddlRegistryType.SelectedValue.ToString());
                fillPartyTypeComboBox(oePartyType);
                //((DataGridViewComboBoxColumn)grdPersons.Columns["colPersonType"]).DataSource = cbBuyerSeller;
            }
        }

        private void fillPartyTypeComboBox(ePartyType oePartyType)
        {
            List<ePartyType> oeListPartyType = new List<ePartyType>();
            bPartyType obPartyType = new bPartyType();
            oeListPartyType = obPartyType.getPartyType(oePartyType, "", "", 0, int.MaxValue);
            //AddItem(oeListPartyType, typeof(ePartyType), "Party_type_id", "Party_name_urd", "گواہ");
            AddItem(oeListPartyType, typeof(ePartyType), "Party_type_id", "Party_name_urd", "< - چنیں - >");
            if (oeListPartyType != null && oeListPartyType.Count > 0)
            {
                ((DataGridViewComboBoxColumn)grdPersons.Columns["colPersonType"]).DataSource = oeListPartyType;
                ((DataGridViewComboBoxColumn)grdPersons.Columns["colPersonType"]).DisplayMember = "party_name_urd";
                ((DataGridViewComboBoxColumn)grdPersons.Columns["colPersonType"]).ValueMember = "party_type_id";
                cbPartyType.DataSource = oeListPartyType;
                cbPartyType.DisplayMember = "party_name_urd";
                cbPartyType.ValueMember = "party_type_id";
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

        public string AreaStr
        {
            get
            {
                return txtTotalArea.Text.Trim();
            }
            set
            {
                txtTotalArea.Text = value;
            }
        }

        //public bool IsValidArea
        //{
        //    get
        //    {
        //        return ValidateArea();
        //    }
        //}

        public bool EnableArea
        {
            set
            {
                this.txtTotalArea.Enabled = value;
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
                this.txtTotalArea.Visible = value;
            }
        }

        public System.Drawing.Color BackColor
        {
            set
            {
                this.txtTotalArea.BorderStyle = BorderStyle.FixedSingle;
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
                txtTotalArea.TabIndex = (short)(value++);
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

        private void ddlAreaFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Variables.SetCue(txtTotalArea, ddlAreaFormat.Text);
            _areaFormat = (enAreaFormat)ddlAreaFormat.SelectedIndex;
        }

        private void txtTotalShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)'/')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void txtTransferShare_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)'/')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void txtTotalArea_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTransferArea_KeyPress(object sender, KeyPressEventArgs e)
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

        private void grdSelectedPersons_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {

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
                MessageDisplay("رجسٹری سب رجسٹرار کو بھیجی جا چکی ہے", true);
                txtRegistryNo.Enabled = true;
                txtRegistryNo.Focus();
            }
            else
            {
                MessageDisplay("رجستری سب رجسٹرار کو نہیں بھیجی گئی، مہربانی کر کے افسر سے رجوع کریں۔", false);
            }

           
        }

        private void RegistrationDeed_Urdu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RegistrySearchPanel obj = new RegistrySearchPanel();
            obj.Show();
        }

        private void txtDate_Leave(object sender, EventArgs e)
        {
            if (fromIndexing)
            {
                splitContainer1.Panel1Collapsed = true;
            }
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
                        btnSave.Text = "تبدیل کریں";
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                        btnAddPerson.Enabled = true;
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
                        btnSave.Text = "تبدیل کریں";
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
                        btnAddPerson.Enabled = false;
                        btnSearchPerson.Enabled = false;
                        pnlBasicInfoMiddle.Visible = true;
                        btnAddPerson.Enabled = false;
                        btnKhasra.Enabled = true;
                        btnVerifyFard.Enabled = true;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        btnPrint.Visible = false;
                        pnlPersonDetail.Visible = false;
                        btnScanning.Enabled = true;
                        btnSentToSCI.Visible = false;
                        btnPlot.Enabled = false;
                        btnPrint.Visible = true;
                        btnPrint.Enabled = true;

                    }

                    if (oeListRegistryOperations[0].Registery_stage == 5)
                    {
                        MessageDisplay("In Active Record", false);
                        MessageBox.Show("In Active Record");
                        cbxTehsil.Enabled = false;
                        cbxDistrict.Enabled = false;
                        cbxMauza.Enabled = false;
                        txtAmount.Enabled = false;
                        pnlBasicInfoBottom.Enabled = false;
                        pnlBasicInfoMiddle.Enabled = false;
                        btnAddPerson.Enabled = false;
                        btnSearchPerson.Enabled = false;
                        pnlBasicInfoMiddle.Visible = true;
                        btnAddPerson.Enabled = false;
                        btnKhasra.Enabled = true;
                        btnVerifyFard.Enabled = true;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        btnPrint.Visible = false;
                        pnlPersonDetail.Visible = false;
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

                    loadPersonsOnRegistryNo();

                    MessageDisplay("", true);
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

        private bool checkCurrentDate()
        {
            bool isMatch = false;
            if (DateTime.Now.Date == DateTime.Parse(txtDate.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-CA")).Date)
            {
                isMatch = true;
            }
            return isMatch;
        }

        void RegistrationDeedForm_OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate()
            {
                Template = template;
                if (Template != null)
                {
                    MessageBox.Show("The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment");
                    btnRegisterThumb.Enabled = false;
                    StatusLine.Enabled = false;
                }
                else
                {
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
                    btnRegisterThumb.Enabled = false;
                    StatusLine.Enabled = false;
                }
            }));
        }

        private void txtDate_Enter(object sender, EventArgs e)
        {
            
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
                    MessageDisplay("رجسٹری ایس سی آئی کو بھیجی جا چکی ہے", true);
                    txtRegistryNo.Enabled = true;
                    txtRegistryNo.Focus();
                }
                else
                {
                    MessageDisplay("رجسٹری ایس سی آئی کو نہیں بھیجی گئ، مہربانی کر کے افسر سی رجوع کریں", false);
                }
            }
            else
            {
                MessageDisplay("رجسٹری ایس سی آئی کو نہیں بھیجی گئ، مہربانی کر کے افسر سی رجوع کریں", false);
            }
        }

        private void btnRegisterThumb_Click(object sender, EventArgs e)
        {
            MessageDisplay("", false);
            if (btnRegisterThumb.Text == "رجسٹر")
            {
                iThumbStage = 1;
                Init();
                Start();
                OnTemplate += new OnTemplateEventHandler(RegistrationDeedForm_OnTemplate);
            }
            else if (btnRegisterThumb.Text.ToLower() == "تصدیق کریں")
            {
                iThumbStage = 2;
                Init();
                Start();
            }
        }

        private void rbUrban_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUrban.Checked)
            {
                lblDistCouncilFee.Text = "کارپوریشن فیس";
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
                lblDistCouncilFee.Text = "ڈسٹرکٹ کونسل فیس :";
                pnlTown.Visible = false;
                btnPlot.Visible = false;
            }

        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            if (isRegistryIdExist())
            {
                Plot_English obj = new Plot_English();
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

        private void VerifyStage()
        {
            iThumbStage = 2;
            Init();
            Start();
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

        private void txtAmount_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            //Remove previous formatting, or the decimal check will fail
            //string value = txtAmount.Text.Replace(",", "").Replace("Rs", "");
            //decimal ul;
            ////Check we are indeed handling a number
            //if (decimal.TryParse(value, out ul))
            //{
            //    //Unsub the event so we don't enter a loop
            //    txtAmount.TextChanged -= txtAmount_TextChanged;
            //    //Format the text as currency
            //    txtAmount.Text = string.Format(CultureInfo.CreateSpecificCulture("ur-PK"), "{0:C}", ul);
            //    txtAmount.TextChanged += txtAmount_TextChanged;
            //}
        }

        private void txtRegistryNo_Validated(object sender, EventArgs e)
        {
            checkCurrentDate();
            Variables.SetCue(txtDate, "Please enter existing Tokan #");
        }

        private void btnDeletePerson_Click(object sender, EventArgs e)
        {

        }

    
        private void txtSearchFirstName_Validated(object sender, EventArgs e)
        {
            searchPersonRecordByNameAndCNIC();
        }

        private void grdSelectedPersons_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //int regStage = checkRegistryStage(RegistryId);
            if (iRegistryStage == 0)
            //if (regStage == 0)
            {
                if (grdSelectedPersons.SelectedRows.Count > 0)
                {
                    valuesBindWithControlFromGrid(grdSelectedPersons);
                }
            }

        }



        

    }
}
