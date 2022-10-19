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
using System.Configuration;
using System.Data.SqlClient;

namespace RDProject.RD
{
    public partial class SRApprovalForm_English : Form, DPFP.Capture.EventHandler
    {
        public int registry_stage;
        public Guid RegistryId;
        public SRApprovalForm_English()
        {
            InitializeComponent();
        }

        #region ....
        private DPFP.Capture.Capture Capturer;
        DPFP.Verification.Verification.Result result;

        protected virtual void ProcessSimple(DPFP.Sample Sample)
        {
            DrawPicture(ConvertSampleToBitmap(Sample));
            lblMsg.Text = "The fingerprint was VERIFIED.";
            
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
            Stop();
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

            //base.Text = "Fingerprint Enrollment";

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



        private void SRApprovalForm_English_KeyPress(object sender, KeyPressEventArgs e)
        {   
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (Picture.Image == null)
            {
                lblMsg.Text = "Thumb is missing, place thumb please";
                return;
            }
            
            eRegistryOperations oeRegistryOperations = new eRegistryOperations();
            bRegistryOperations obRegistryOperations = new bRegistryOperations();
            updatedNewEntryInfo info = new updatedNewEntryInfo();
            oeRegistryOperations.Registry_id = RegistryId;
            oeRegistryOperations.Registery_stage = registry_stage;
            oeRegistryOperations.Remarks = txtRemarks.Text;
                
            info = obRegistryOperations.UpdateRegistryOperationsStage(oeRegistryOperations);
            if (info.Success)
            {
                if (info.IdNumeric == 2)
                {
                    MessageDisplay("Registry has been approved and sent to SCO", true);
                }
                else if (info.IdNumeric == 3)
                {
                    MessageDisplay("Registry has been rejected and sent to SCO", true);
                }
                else if (info.IdNumeric == 4)
                {
                    MessageDisplay("Registry is in defer stage", true);
                }
            }
            btnApproved.Enabled = false;
                //here we will send this registery to LRMIS SCI console as a complaint
                //SendRegisteryToLRMISSCIConsole();
        }

        private void SendRegisteryToLRMISSCIConsole()
        {
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["lrmis"].ConnectionString.ToString();
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    
                    conn.Open();
                    Guid operation_id = Guid.NewGuid();
                    Guid mauza_id = new Guid("B6DDC3B3-7F73-47BE-BB02-6934D6E855C5");
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("[generic].[proc_InsertKioskOperations]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@operation_id", operation_id);
                        cmd.Parameters.AddWithValue("@mauza_id", null);
                        cmd.Parameters.AddWithValue("@operation_date", null);
                        cmd.Parameters.AddWithValue("@operation_type", null);
                        cmd.Parameters.AddWithValue("@status", null);
                        cmd.Parameters.AddWithValue("@Opearion_No", "007");
                        cmd.Parameters.AddWithValue("@operation_remarks", null);
                        cmd.Parameters.AddWithValue("@revisit_date", null);
                        cmd.Parameters.AddWithValue("@user_id", null);
                        cmd.Parameters.AddWithValue("@access_datetime", null);

                        int comd = cmd.ExecuteNonQuery();

                    }

                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("[generic].[proc_InsertComplaint]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@complaint_id", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@fard_id", null);
                        cmd.Parameters.AddWithValue("@mauza_id", mauza_id);
                        cmd.Parameters.AddWithValue("@complaint_no", "007");
                        cmd.Parameters.AddWithValue("@person_id", Guid.Empty);
                        cmd.Parameters.AddWithValue("@operation_id", operation_id);
                        cmd.Parameters.AddWithValue("@visit_purpose", "رجسٹری");
                        cmd.Parameters.AddWithValue("@complaint_type", "رجسٹری رجسٹریشن ڈیڈ ");
                        cmd.Parameters.AddWithValue("@complaint_detail", "رجسٹری رجسٹریشن ڈیڈ سے ایس سی او کے ان باکس میں آَی ہے");
                        cmd.Parameters.AddWithValue("@officer_name", "نام موجود نہیں");
                        cmd.Parameters.AddWithValue("@re_visit_date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@new_caste_id", null);
                        cmd.Parameters.AddWithValue("@new_name", null);
                        cmd.Parameters.AddWithValue("@status", 3);
                        cmd.Parameters.AddWithValue("@user_id", Guid.Empty);
                        cmd.Parameters.AddWithValue("@report_patwari", null);
                        cmd.Parameters.AddWithValue("@command_revenue_officer", null);
                        cmd.Parameters.AddWithValue("@access_datetime", DateTime.Now);

                        int comd = cmd.ExecuteNonQuery();
                        
                    }
                    conn.Close();
                }



            }

            catch (System.Data.SqlClient.SqlException ex)
            {

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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SRApprovalForm_English_Load(object sender, EventArgs e)
        {
            eRegistryOperations oeRegistryOperations = new eRegistryOperations();
            List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
            bRegistryOperations obRegistryOperations = new bRegistryOperations();
            oeRegistryOperations.Registry_id = RegistryId;
            oeListRegistryOperations = obRegistryOperations.getRegistryOperations(oeRegistryOperations, "", "", 0, int.MaxValue);
            if (oeListRegistryOperations != null && oeListRegistryOperations.Count == 1)
            {
                txtRemarks.Text = oeListRegistryOperations[0].Remarks;
            }

            if (registry_stage == 2)
            {
                txtRemarks.Enabled = false;
                btnApproved.Text = "&Approved";
            }
            else if(registry_stage == 3)
            {
                txtRemarks.Enabled = true;
                btnApproved.Text = "&Reject";
            }
            else if (registry_stage == 4)
            {
                txtRemarks.Enabled = true;
                btnApproved.Text = "&Defer";
            }

            Init();
            Start();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SRApprovalForm_English_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }
    }
}
