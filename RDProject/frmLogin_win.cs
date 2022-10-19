using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Security.Cryptography;
using System.IO;
using RD.BLL.General;
using System.Threading;
using System.Reflection;
using RDProject.GenClass;
using RD.EL;
using RD.BLL;

namespace RDProject
{


    public partial class frm_Login : Form, DPFP.Capture.EventHandler
    {
        #region Biometric 
        #region ....
        private DPFP.Capture.Capture Capturer;
        DPFP.Verification.Verification.Result result;

        protected virtual void ProcessSimple(DPFP.Sample Sample)
        {
            DrawPicture(ConvertSampleToBitmap(Sample));
            //lblMsg.Text = "The fingerprint was VERIFIED.";
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
                //StatusLine.Text = status;
                MessageBox.Show(status);
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
            ProcessSimple(Sample);

            Verificator = new DPFP.Verification.Verification();
            //UpdateStatus(0);
            //UpdateStatus(result.FARAchieved);
            eUsers oeUsers = new eUsers();
            oeUsers.User_name = txtUserName.Text.Trim();
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
                            lblMsg.Text = "User: " + oeListUsers[i].User_name + " Has Been Verified";
                            this.Invoke(new Function(delegate()
                            {
                                txtUserName.Text = oeListUsers[i].User_name;
                                txtPassword.Text = oeListUsers[i].User_password;
//                                txtUserName.AppendText(oeListUsers[i].User_name + "\r\n");
//                                txtPassword.AppendText(oeListUsers[i].User_password + "\r\n");
                                UserLogin();
                                
                            }));


                            break;
                        }
                        else
                        {
                            lblMsg.Text = "Record not found ...";
                        }
                        
                    }
                }
            }



            //if (oeListUsers != null && oeListUsers.Count == 1)
            //{
            //    byte[] bytes = null;
            //    bytes = oeListUsers[0].User_thumb;
            //    Template = new DPFP.Template();
            //    Template.DeSerialize(bytes);
            //    DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
            //    if (features != null)
            //    {
            //        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
            //        Verificator.Verify(features, Template, ref result);
            //        //        UpdateStatus(result.FARAchieved);
            //        if (result.Verified)
            //            lblMsg.Text = "User: " + oeListUsers[0].User_id + "Has Been Verified";
            //        else
            //            lblMsg.Text = "User: " + oeListUsers[0].User_id + "Has Been Verified";

            //    }
            //}
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
                    SetPrompt("Can't initiate capture operation!");
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            base.Text = "CORD - Login Form";

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


        void frmLogin_OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate()
            {
                Template = template;
                if (Template != null)
                    MessageBox.Show("The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment");
                else
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
            }));


        }


        private void UpdateStatus(int FAR)
        {
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
        }


        #endregion

#endregion biometric
        public frm_Login()
        {
            InitializeComponent();
            clsCulture.Localize(this, frm_MainMDI.language);
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void UserLogin()
        {
            if (Variables.isBiometric == "true")
            {
                if (Picture.Image == null)
                {
                    lblMsg.Text = "Place thumb first please...";
                    MessageBox.Show("Place thumb first please...");
                    return;
                }
            }

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                lblMsg.Text = "User name is missing...";
                txtUserName.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lblMsg.Text = "Password is missing ...";
                txtPassword.Focus();
                return;
            }

            eUsers oeUsers = new eUsers();
            oeUsers.User_name = txtUserName.Text.Trim();
            List<eUsers> oeListUsers = new List<eUsers>();
            bUsers obUsers = new bUsers();
            oeListUsers = obUsers.getUsers(oeUsers, "", "", 0, int.MaxValue);

            if (oeListUsers != null && oeListUsers.Count == 1)
            {
                Stop();
                if (string.Compare(txtPassword.Text, oeListUsers[0].User_password) == 0)
                {
                    eUserRoles oeUserRoles = new eUserRoles();
                    List<eUserRoles> oeListUserRoles = new List<eUserRoles>();
                    bUserRoles obUserRoles = new bUserRoles();
                    oeUserRoles.User_id = oeListUsers[0].User_id;
                    Variables.UserId = oeListUsers[0].User_id;
                    oeListUserRoles = obUserRoles.getUserRoles(oeUserRoles, "", "", 0, int.MaxValue);
                    if (oeListUserRoles != null && oeListUserRoles.Count == 1)
                    {
                        // admin =  A863EE6E-AFF8-4529-BC59-1E6A01BA6AED
                        // SR =     0BF53A3C-9385-4D3F-81D2-7BEF64A75507
                        // SCO =    5C42EEED-813B-4274-ABCA-CA3D18E445A9
                        eRole oeRole = new eRole();
                        List<eRole> oeListRole = new List<eRole>();
                        bRole obRole = new bRole();
                        oeRole.Role_id = oeListUserRoles[0].Role_id;
                        oeListRole = obRole.getRole(oeRole, "", "", 0, int.MaxValue);
                        if (oeListRole != null && oeListRole.Count == 1)
                        {
                            Variables.IsLoged = true;
                            frm_MainMDI f = new frm_MainMDI();
                            Variables.roleId = oeListRole[0].Role_id;
                            if (Variables.roleId == new Guid("0BF53A3C-9385-4D3F-81D2-7BEF64A75507"))   // For SR
                                //Variables.roleName = "SR";
                                Variables.roleName = "SCO";
                            else if (Variables.roleId == new Guid("5C42EEED-813B-4274-ABCA-CA3D18E445A9"))  // For SCO
                                Variables.roleName = "SCO";
                            else if (Variables.roleId == new Guid("A863EE6E-AFF8-4529-BC59-1E6A01BA6AED"))  // For Admin
                                Variables.roleName = "ADMIN";
                            Variables.UserName = txtUserName.Text.Trim();
                            if (frm_MainMDI.language == "en")
                                Variables.UserRole = oeListRole[0].Description_eng;
                            else if (frm_MainMDI.language == "ur")
                                Variables.UserRole = oeListRole[0].Description_urd;
                            else
                                Variables.UserRole = "";
                            this.Close();
                        }
                    }
                }
                else
                {
                    lblMsg.Text = "Please check username and password...";
                    Variables.IsLoged = false;
                }
            }
            else
            {
                lblMsg.Text = "Invalid username and password";
                Variables.IsLoged = false;
            }


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserLogin();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private int setOpecity(int nValue)
        {
            nValue--;
            if (nValue != 0)
            {
                setOpecity(nValue);
            }
            return nValue;
        }

        public void FadeForm(System.Windows.Forms.Form f, byte NumberOfSteps)
        {
            float StepVal = (float)(100f / NumberOfSteps);
            float fOpacity = 100f;
            for (byte b = 0; b < NumberOfSteps; b++)
            {
                f.Opacity = fOpacity / 100;
                f.Refresh();
                fOpacity -= StepVal;
            }
        }

        private void frmLogin_win_FormClosing(object sender, FormClosingEventArgs e)
        {
            //FadeForm(this, 15);
            Stop();
        }

        private void frmLogin_win_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
            if (Variables.isBiometric == "true")
            {
                Init();
                Start();
            }
            else
            {
                Picture.Visible = false;
            }
        }

        private void frmLogin_win_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                Application.Exit();

            if (e.KeyChar == (char)Keys.Enter)
                UserLogin();
        }
    }
}
