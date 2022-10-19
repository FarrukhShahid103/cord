using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RD.EL.Users;
using RD.EL;
using RD.BLL;
using System.Reflection;
using System.Collections;
using System.IO;

namespace RDProject.Setup
{
    public partial class CreateUserEng : Form, DPFP.Capture.EventHandler
    {
        #region ....
        private DPFP.Capture.Capture Capturer;
        int iThumbStage;

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
//            MakeReport("The fingerprint sample was captured.");
            //SetPrompt("Scan the same fingerprint again.");
            if (iThumbStage == 1)
            {
                ProcessCreate(Sample);
            }
            if (iThumbStage == 2)
            {
                ProcessSimple(Sample);
                Verificator = new DPFP.Verification.Verification();
                eUsers oeUsers = new eUsers();
                this.Invoke(new Function(delegate()
                {
                    oeUsers.User_name = cbUserName.Text.Trim();

                }));

                List<eUsers> oeListUsers = new List<eUsers>();
                bUsers obUsers = new bUsers();
                oeListUsers = obUsers.getUsers(oeUsers, "", "", 0, int.MaxValue);
                for (int i = 0; i < oeListUsers.Count; i++)
                {
                    oeListUsers[i].User_name.ToString();
                    byte[] bytes = null;
                    Guid id = oeListUsers[i].User_id;
                    bytes = oeListUsers[i].User_thumb;
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
                                
                                this.Invoke(new Function(delegate()
                                {
                                    StatusLine.Text = "User: " + oeListUsers[i].User_name + " Has Been Verified";
                                    lblRegisterThumb.Enabled = false;
                                }));
                                Stop();
                                
                                break;
                            }
                            else
                            {
                                this.Invoke(new Function(delegate()
                                {
                                    StatusLine.Text = "Record not found ...";
                                    lblRegisterThumb.Enabled = false;
                                }));
                                Stop();
                            }

                        }
                    }

                }
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

        private DPFP.Processing.Enrollment Enroller;
        private DPFP.Template Template;
        private delegate void OnTemplateEventHandler(DPFP.Template template);
        private event OnTemplateEventHandler OnTemplate;
        private DPFP.Verification.Verification Verificator;
        protected void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
                else
                    SetPrompt("Can't initiate capture operation!");
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (iThumbStage == 1)
            {
                base.Text = "Fingerprint Enrollment";
                Enroller = new DPFP.Processing.Enrollment();			// Create an enrollment.
                UpdateStatus();
            }
            else if (iThumbStage == 2)
            {
                base.Text = "Fingerprint Verification";
                //Verificator = new DPFP.Verification.Verification();
            }

        }
        private void UpdateStatus()
        {
            SetStatus(String.Format("Fingerprint samples needed: {0}", Enroller.FeaturesNeeded));
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
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
            if (features != null)
            {
                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                Verificator.Verify(features, Template, ref result);
                //UpdateStatus(result.FARAchieved);
                if (result.Verified)
                    MakeReport("The fingerprint was VERIFIED.");
                else
                    MakeReport("The fingerprint was NOT VERIFIED.");
            }
        }
    
        void CreateUserEng_OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate()
            {
                Template = template;
                if (Template != null)
                {
                    MessageBox.Show("The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment");
                    lblRegisterThumb.Enabled = false;
                }
                else
                {
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
                    lblRegisterThumb.Enabled = false;
                }
            }));


        }

#endregion

        private bool NewReocrd = true;
        private Guid user_id = Guid.Empty;
        List<eForms> oeListForms = new List<eForms>();
        public CreateUserEng()
        {
            InitializeComponent();
            fillUserRoleDropDown();
            fillUserRightsDropDown();
        }

        private void CreateUserEng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Control ctl;
                ctl = (Control)sender;
                ctl.SelectNextControl(ActiveControl, true, true, true, true);
            }


            if (e.KeyChar == (char)Keys.Escape)
            {
                if (cbUserName.Focused)
                {
                    this.Close();
                }
                else
                {
                    cbUserName.Enabled = true;
                    cbUserName.Focus();
                    return;
                }
            }
        }

        DPFP.Sample Sample;
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void cbUserName_Leave(object sender, EventArgs e)
        {
            if (cbUserName.Text == string.Empty)
            {
                cbUserName.Enabled = true;
                cbUserName.Focus();
                lblMsg.Text = "Username Field must have a value..";
                return;
            }

            NewReocrd = true;
            cbUserName.Enabled = false;

            List<eUsers> oeListUsers = new List<eUsers>();
            eUsers oeUsers = new eUsers();
            bUsers obUsers = new bUsers();
            oeUsers.User_name = cbUserName.Text.Trim();

            oeListUsers = obUsers.getUsers(oeUsers, "", "", 0, int.MaxValue);
            if (oeListUsers != null && oeListUsers.Count > 0)
            {
                eUserRoles oeUserRoles = new eUserRoles();
                oeUserRoles.User_id = oeListUsers[0].User_id;
                List<eUserRoles> oeListUserRoles = new List<eUserRoles>();
                bUserRoles obUserRoles = new bUserRoles();
                oeListUserRoles = obUserRoles.getUserRoles(oeUserRoles, "", "", 0, 100);
                if (oeListUserRoles != null && oeListUserRoles.Count > 0)
                {
                    cbUserRole.SelectedValue = oeListUserRoles[0].Role_id;
                }
                
                txtFirstName.Text = oeListUsers[0].First_name;
                txtLastName.Text = oeListUsers[0].Last_name;
                txtPassword.Text = oeListUsers[0].User_password;
                txtCNIC.Text = oeListUsers[0].User_nic;
                txtSecretAnswer.Text = oeListUsers[0].Secret_answer;
                txtSecretQuestion.Text = oeListUsers[0].Secret_question;
                chkBioMetricLogin.Checked = ValidateFields.GetSafeBoolean(oeListUsers[0].Is_biomatric);
                chkActive.Checked = ValidateFields.GetSafeBoolean(oeListUsers[0].User_active_status);
                user_id = oeListUsers[0].User_id;

                if (oeListUsers[0].User_thumb != null)
                {
                    lblRegisterThumb.Text = "Verify &Thumb";
  
                }
                else
                {
                    lblRegisterThumb.Text = "Register &Thumb";
                   }
                pnlThumb.Enabled = true;
                cbxUserRights.Enabled = true;
                lblMsg.Text = "Username is found";
                NewReocrd = false;
                btnSave.Text = "&Update";
            }
            else
            {
                lblMsg.Text = "";
                NewReocrd = true;
                btnSave.Text = "&Save";
            }
            gbxUserRights.Enabled = true;
        }

        private void setDefaultValue()
        {
            txtSecretAnswer.Clear();
            txtPassword.Clear();
            txtLastName.Clear();
            txtFirstName.Clear();
            txtCNIC.Clear();
            cbxUserRights.SelectedIndex = 0;
            chkBioMetricLogin.Checked = false;
            chkActive.Checked = true;
            gbxUserRights.Enabled = false;
            checkedFalse();
            
        }

        private void fillUserRoleDropDown()
        {
            eRole oeRole = new eRole();
            List<eRole> oeListRole = new List<eRole>();
            bRole obRole = new bRole();
            oeListRole = obRole.getRole(oeRole, "", "", 0, int.MaxValue);
            AddItem(oeListRole, typeof(eRole), "Role_id", "Description_eng", "< - SELECT - >");
            if (oeListRole != null && oeListRole.Count > 0)
            {
                cbUserRole.DataSource = oeListRole;
                cbUserRole.DisplayMember = "description_eng";
                cbUserRole.ValueMember = "role_id";
            }
        }

        private void fillUserRightsDropDown()
        {
            eForms oeForms = new eForms();
            bForms obForms = new bForms();
            oeListForms = obForms.getForms(oeForms, "", "", 0, int.MaxValue);
            AddItem(oeListForms, typeof(eForms), "Form_id", "Description_eng", "< - SELECT - >");
            if (oeListForms != null && oeListForms.Count > 0)
            {
                cbxUserRights.DataSource = oeListForms;
                cbxUserRights.DisplayMember = "description_eng";
                cbxUserRights.ValueMember = "form_id";
            }
            if (cbxUserRights.SelectedIndex == 0)
            {
                chkUpdate.Enabled = false;
                chkPrint.Enabled = false;
                chkView.Enabled = false;
                chkDelete.Enabled = false;
                chkInsert.Enabled = false;
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

        private void CreateUserEng_Load(object sender, EventArgs e)
        {
            pnlThumb.Enabled = false; 
            FillAllUsers();
        } 

        private void FillAllUsers()
        {
            List<eUsers> oeListUsers = new List<eUsers>();
            eUsers oeUsers = new eUsers();
            bUsers obUsers = new bUsers();
            oeListUsers = obUsers.getUsers(oeUsers, "", "", 0, int.MaxValue);
            if (oeListUsers != null && oeListUsers.Count > 0)
            {
                cbUserName.DataSource = oeListUsers;
                cbUserName.DisplayMember = "user_name";
                cbUserName.ValueMember = "user_id";
            }

        }

        private void cbUserName_Enter(object sender, EventArgs e)
        {
            setDefaultValue();
            Picture.Image = null;
            pnlThumb.Enabled = false;
            lblRegisterThumb.Enabled = true;
            lblRegisterThumb.Text = "Register &Thumb";
            StatusLine.Clear();
            Stop();
        }

        private bool controlValidate()
        {
            bool result = true;
            if (cbUserName.Text.Trim() == string.Empty)
            {
                cbUserName.Focus();
                result = false;
                return result;
            }
            if (txtPassword.Text == string.Empty)
            {
                txtPassword.Focus();
                result = false;
                return result;
            }
            if (txtFirstName.Text == string.Empty)
            {
                txtFirstName.Focus();
                result = false;
                return result;
            }
            if (txtLastName.Text == string.Empty)
            {
                txtLastName.Focus();
                result = false;
                return result;
            }
            if (txtCNIC.Text == string.Empty)
            {
                txtCNIC.Focus();
                result = false;
                return result;
            }
            if (cbUserRole.SelectedIndex == 0)
            {
                cbUserRole.Focus();
                result = false;
                return result;
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            eUserRights oeUserRights = new eUserRights();
            bUserRights obUserRights = new bUserRights();
            
            eUserRoles oeUserRoles = new eUserRoles();
            List<eUserRoles> oeListUserRoles = new List<eUserRoles>();
            bUserRoles obUserRoles = new bUserRoles();

            bUsers obUsers = new bUsers();
            eUsers oeUsers = new eUsers();
            updatedNewEntryInfo info = new updatedNewEntryInfo();
            oeUsers.First_name = txtFirstName.Text.Trim();
            oeUsers.Last_name = txtLastName.Text.Trim();
            oeUsers.User_password = txtPassword.Text.Trim();
            oeUsers.Secret_question = txtSecretQuestion.Text.Trim();
            oeUsers.Secret_answer = txtSecretAnswer.Text.Trim();
            oeUsers.User_nic = txtCNIC.Text.Trim();
            oeUsers.User_active_status = chkActive.Checked;
            oeUsers.Is_biomatric = chkBioMetricLogin.Checked;
            oeUsers.Access_datetime = DateTime.Now;
            if (NewReocrd)
            {
                if (controlValidate())
                {
                    oeUsers.User_id = Guid.NewGuid();
                    user_id = oeUsers.User_id;
                    oeUsers.User_name = cbUserName.Text;
                    Image image = Picture.Image;
                    if (image != null)
                    {
                        string filePath = Application.StartupPath + "\\" + oeUsers.User_id + ".jpg";
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                        FileStream fstream = new FileStream(filePath, FileMode.Create);
                        image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        fstream.Close();

                        MemoryStream fingerprintData = new MemoryStream();
                        Template = new DPFP.Template();
                        Template.Serialize(fingerprintData);
                        fingerprintData.Position = 0;
                        BinaryReader br = new BinaryReader(fingerprintData);
                        Byte[] bytes = br.ReadBytes((Int32)fingerprintData.Length);
                        oeUsers.User_thumb = bytes;
                    }
                    else
                    {
                        oeUsers.User_thumb = null;
                    }
                    oeUserRoles.User_roles_id = Guid.NewGuid();
                    oeUserRoles.Role_id = new Guid(cbUserRole.SelectedValue.ToString());
                    oeUserRoles.Access_user_id = Guid.Empty;
                    info = obUsers.insertUserWithRole(oeUsers, oeUserRoles);
                    if (info.Success)
                    {
                        cbxUserRights.Enabled = true;
                        if (oeListForms != null && oeListForms.Count > 0)
                        {
                            for (int i = 1; i < oeListForms.Count; i++)
                            {
                                oeUserRights.User_right_id = Guid.NewGuid();
                                oeUserRights.User_id = user_id;
                                oeUserRights.Form_id = oeListForms[i].Form_id;
                                oeUserRights.Insert_right = chkInsert.Checked;
                                oeUserRights.Print_right = chkPrint.Checked;
                                oeUserRights.Update_right = chkUpdate.Checked;
                                oeUserRights.View_right = chkView.Checked;
                                oeUserRights.Delete_right = chkDelete.Checked;
                                oeUserRights.Access_user_id = Variables.UserId;
                                oeUserRights.Access_datetime = DateTime.Now;
                                info = obUserRights.insertUserRights(oeUserRights);
                            }
                        }

                        lblMsg.ForeColor = Color.Green;
                        lblMsg.Text = "User " + cbUserName.Text + " created successfully";
                        cbUserName.Enabled = true;
                        cbUserName.Focus();
                        //pnlThumb.Enabled = true;
                    }
                    else
                    {
                        lblMsg.Text = "User not created, " + info.Exception;
                        lblMsg.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                eUsers oeusers = new eUsers();
                bUsers obusers = new bUsers();
                //oeusers.User_id = user_id;
                oeusers.User_name = cbUserName.Text;
                List<eUsers> oelistusers = new List<eUsers>();
                oelistusers = obusers.getUsers(oeusers, "", "", 0, int.MaxValue);
                if (oelistusers != null && oelistusers.Count > 0)
                {
                    if (oelistusers[0].User_thumb != null)
                    {
                        oelistusers[0].User_thumb = oelistusers[0].User_thumb;
                    }
                    else
                    {
                        if (lblRegisterThumb.Text == "Register &Thumb" && lblRegisterThumb.Enabled)
                        {
                            oeUsers.User_thumb = null;
                        }
                        else
                        {
                            MemoryStream fingerprintData = new MemoryStream();
                            Template.Serialize(fingerprintData);
                            fingerprintData.Position = 0;
                            BinaryReader br = new BinaryReader(fingerprintData);
                            Byte[] bytes = br.ReadBytes((Int32)fingerprintData.Length);
                            oeUsers.User_thumb = bytes;
                        }
                    }
                }
                oeUserRoles.User_roles_id = Guid.NewGuid();
                oeUserRoles.Role_id = new Guid(cbUserRole.SelectedValue.ToString());
                oeUserRoles.Access_user_id = Guid.Empty;
                info = obUsers.updateUserWithRole(oeUsers, oeUserRoles);
                if (info.Success)
                {
                    cbxUserRights.Enabled = true;
                    if (oeListForms != null && oeListForms.Count > 0)
                    {
                        for (int i = 1; i < oeListForms.Count; i++)
                        {
                            oeUserRights.User_right_id = Guid.NewGuid();
                            oeUserRights.User_id = user_id;
                            oeUserRights.Form_id = oeListForms[i].Form_id;
                            oeUserRights.Insert_right = chkInsert.Checked;
                            oeUserRights.Print_right = chkPrint.Checked;
                            oeUserRights.Update_right = chkUpdate.Checked;
                            oeUserRights.View_right = chkView.Checked;
                            oeUserRights.Delete_right = chkDelete.Checked;
                            oeUserRights.Access_user_id = Variables.UserId;
                            oeUserRights.Access_datetime = DateTime.Now;
                            info = obUserRights.udpateUserRights(oeUserRights);
                        }
                    }

                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Text = "User " + cbUserName.Text + " created successfully";
                    cbUserName.Enabled = true;
                    cbUserName.Focus();
                    //pnlThumb.Enabled = true;
                }
                else
                {
                    lblMsg.Text = "User not created, " + info.Exception;
                    lblMsg.ForeColor = Color.Red;
                }
            }
        }

        private void checkedFalse()
        {
            chkView.Checked = false;
            chkPrint.Checked = false;
            chkInsert.Checked = false;
            chkUpdate.Checked = false;
            chkDelete.Checked = false;
        }

        private void cbxUserRights_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxUserRights.SelectedIndex == 0)
            {
                checkedFalse();
                chkUpdate.Enabled = false;
                chkPrint.Enabled = false;
                chkView.Enabled = false;
                chkDelete.Enabled = false;
                chkInsert.Enabled = false;
            }
            else
            {
                chkUpdate.Enabled = true;
                chkPrint.Enabled = true;
                chkView.Enabled = true;
                chkDelete.Enabled = true;
                chkInsert.Enabled = true;
                eUserRights oeUserRights = new eUserRights();
                List<eUserRights> oeListUserRights = new List<eUserRights>();
                bUserRights obUserRights = new bUserRights();
                oeUserRights.User_id = user_id;
                oeUserRights.Form_id = ValidateFields.GetSafeGuid(cbxUserRights.SelectedValue.ToString());
                oeListUserRights = obUserRights.getUserRights(oeUserRights, "", "", 0, int.MaxValue);
                if (oeListUserRights != null && oeListUserRights.Count == 1)
                {
                    chkView.Checked = ValidateFields.GetSafeBoolean(oeListUserRights[0].View_right);
                    chkPrint.Checked = ValidateFields.GetSafeBoolean(oeListUserRights[0].Print_right);
                    chkInsert.Checked = ValidateFields.GetSafeBoolean(oeListUserRights[0].Insert_right);
                    chkUpdate.Checked = ValidateFields.GetSafeBoolean(oeListUserRights[0].Update_right);
                    chkDelete.Checked = ValidateFields.GetSafeBoolean(oeListUserRights[0].Delete_right);
                }
            }
        }

        private void chkView_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxStatus();
        }

        private void checkBoxStatus()
        {
            eUserRights oeUserRights = new eUserRights();
            List<eUserRights> oeListUserRights = new List<eUserRights>();
            bUserRights obUserRights = new bUserRights();
            updatedNewEntryInfo info = new updatedNewEntryInfo();
            oeUserRights.Form_id = ValidateFields.GetSafeGuid(cbxUserRights.SelectedValue.ToString());
            oeUserRights.User_id = user_id;
            oeListUserRights = obUserRights.getUserRights(oeUserRights, "", "", 0, int.MaxValue);
            if (oeListUserRights != null && oeListUserRights.Count == 1)
            {
                oeUserRights.User_right_id = oeListUserRights[0].User_right_id;
                oeUserRights.View_right = chkView.Checked;
                oeUserRights.Print_right = chkPrint.Checked;
                oeUserRights.Insert_right = chkInsert.Checked;
                oeUserRights.Update_right = chkUpdate.Checked;
                oeUserRights.Delete_right = chkDelete.Checked;
                oeUserRights.Access_datetime = DateTime.Now;
                oeUserRights.Access_user_id = Variables.UserId;
                info = obUserRights.udpateUserRights(oeUserRights);
            }
        }

        private void chkPrint_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxStatus();
        }

        private void chkInsert_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxStatus();
        }

        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxStatus();
        }

        private void chkDelete_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxStatus();
        }

        private void cbUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            eRoleRights oeRoleRights = new eRoleRights();
            List<eRoleRights> oeListRoleRights = new List<eRoleRights>();
            bRoleRights obRoleRights = new bRoleRights();
            //todo: complete the functionality of roleRights
        }

        private void lblRegisterThumb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (chkBioMetricLogin.Checked)
            {
                if (lblRegisterThumb.Text.ToLower() == "register &thumb")
                {
                    iThumbStage = 1;
                    Init();
                    Start();
                    OnTemplate += new OnTemplateEventHandler(CreateUserEng_OnTemplate);
                }
                else if (lblRegisterThumb.Text.ToLower() == "verify &thumb")
                {
                    iThumbStage = 2;
                    Init();
                    Start();
                }
            }
            else
            {
                lblMsg.Text = "Please check Bio metric";
                StatusLine.Text = "";
            }
        }

        private void chkBioMetricLogin_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkBioMetricLogin.Checked)
            //{
            //    pnlThumb.Enabled = true;
            //}
            //else
            //{
            //    pnlThumb.Enabled = false;
            //}

        }

        private void lblVerify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

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

        private void CreateUserEng_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }        
    }
}
