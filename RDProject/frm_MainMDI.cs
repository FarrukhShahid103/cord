 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RDProject.GenClass;
using RDProject.Territory;
using RDProject.Setup;
using RDProject.RD;
using RD.EL;
using RD.BLL;
using System.Configuration;
//using RDProject.Territory;

namespace RDProject
{
    public partial class frm_MainMDI : Form
    {
        public static string language = "en";
        frm_BasicInformation objBasicInfo;
        frm_Login fLogin;

        public frm_MainMDI()
        {
            InitializeComponent();            
            CheckLanguage();
            Variables.isBiometric = ConfigurationManager.AppSettings["isBiometric"].ToString();
            Variables.isTown = ValidateFields.GetSafeBoolean(ConfigurationManager.AppSettings["isTown"].ToString());
            Variables.ScanningFromApplication = ValidateFields.GetSafeBoolean(ConfigurationManager.AppSettings["scanningFromApplication"].ToString());
            Variables.defaultDistrict = ValidateFields.GetSafeGuid(ConfigurationManager.AppSettings["defaultDistrict"].ToString());
            Variables.defaultTehsil = ValidateFields.GetSafeGuid(ConfigurationManager.AppSettings["defaultTehsil"].ToString());
            Variables.defaultMauza = ValidateFields.GetSafeGuid(ConfigurationManager.AppSettings["defaultMauza"].ToString());
            Variables.defaultTown = ValidateFields.GetSafeGuid(ConfigurationManager.AppSettings["defaultTown"].ToString());
        }

        private void CheckLanguage()
        {
            Variables.isEnglish = ConfigurationManager.AppSettings["isEnglish"].ToString();
        }

        private void frm_MainMDI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.F2)
            {
                //btnRegistrationDeed_Click(sender, e);
            }
        }

        private bool userFormAccessRights(Guid formId)
        {
            bool isActive = true;
            eUserRights oeUserRights = new eUserRights();
            List<eUserRights> oeListUserRights = new List<eUserRights>();
            oeUserRights.User_id = Variables.UserId;
            oeUserRights.Form_id = formId;
            bUserRights obUserRights = new bUserRights();
            oeListUserRights = obUserRights.getUserRights(oeUserRights, "", "", 0, int.MaxValue);
            if (oeListUserRights != null && oeListUserRights.Count == 1)
            {
                isActive = oeListUserRights[0].View_right.Value;
            }
            return isActive;
        }

        private void btnDistrict_Click(object sender, EventArgs e)
        {
            Guid frm_id = ValidateFields.GetSafeGuid(Variables.frm_district_id);
            if (userFormAccessRights(frm_id))
            {
                frmDistrictSetup obj = new frmDistrictSetup();
                obj.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are not allowed to open this document");
            }
        }

        private void btnTehsil_Click(object sender, EventArgs e)
        {
            Guid frm_id = ValidateFields.GetSafeGuid(Variables.frm_tehsil_id);
            if (userFormAccessRights(frm_id))
            {
                TehsilForm obj = new TehsilForm();
                obj.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are not allowed to open this document");
            }
        }

        private void btnMauza_Click(object sender, EventArgs e)
        {
            MauzaForm obj = new MauzaForm();
            obj.ShowDialog();

            //Guid frm_id = ValidateFields.GetSafeGuid(Variables.frm_mauza_id);
            //if (userFormAccessRights(frm_id))
            //{
            //    MauzaForm obj = new MauzaForm();
            //    obj.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("You are not allowed to open this document");
            //}
        }

        private void btnUrdu_Click(object sender, EventArgs e)
        {
            Variables.CloseAllMdiChildForms();
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("isEnglish");
            config.AppSettings.Settings.Add("isEnglish", "false");
            config.Save(ConfigurationSaveMode.Minimal);
            ToolStrip_English.Visible = false;
            toolStrip_Urdu.Visible = true;
            setToolStatus();
        }

        private void btnRegistrationDeed_Click(object sender, EventArgs e)
        {
            if (Variables.UserName == string.Empty)
            {
                fLogin = new frm_Login();
                fLogin.ShowDialog();
                if (Variables.UserName != string.Empty)
                {
                    btnLogout.Text = "Logout";
                    RegistrationDeedForm obj = new RegistrationDeedForm();
                    obj.MdiParent = this;
                    obj.Show();
                }
            }
            else
            {
                RegistrationDeedForm obj = new RegistrationDeedForm();
                obj.MdiParent = this;
                obj.Show();

            }
        }

        private void setToolStatus()
        {

            CheckLanguage();
            if (Variables.isEnglish == "false")
            {
                toolLabelUsername.Text = "صارف کا نام : " + Variables.UserName.ToUpper();
                toolLabelRole.Text = "صارف کا کردار : " + Variables.UserRole;
                StatusBar.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                toolLabelUsername.Text = "Username : " + Variables.UserName.ToUpper();
                toolLabelRole.Text = "User Role : " + Variables.UserRole;
                StatusBar.RightToLeft = RightToLeft.No;
            }
        }

        private void disableAllButton()
        {
            btnUserManagement_English.Enabled = false;
            btnUserManagement_Urdu.Enabled = false;
            btnRegistrationDeed_English.Enabled = false;
            btnRegistrationDeed_Urdu.Enabled = false;
            btnSetup_English.Enabled = false;
            btnSetup_Urdu.Enabled = false;
            btnInbox_English.Enabled = false;
            btnInbox_Urdu.Enabled = false;
            btnLanguage_English.Enabled = false;
            btnLanguage_Urdu.Enabled = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (btnLogout.Text.ToUpper() == "LOGIN")
            {

                if (!Variables.IsLoged)
                {
                    fLogin = new frm_Login();
                    fLogin.ShowDialog();
                    fLogin.StartPosition = FormStartPosition.CenterParent;
                    setToolStatus();
                    if (Variables.IsLoged)
                    {
                        btnLogout.Text = "Logout";
                        enableButtonWithRole();
                    }
                }
                else
                {
                    setToolStatus();
                    btnLogout.Text = "Logout";
                }
            }
            else
            {
                 var result = MessageBox.Show("want to close?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                 if (result == System.Windows.Forms.DialogResult.Yes)
                 {
                     Variables.UserName = string.Empty;
                     Variables.UserRole = string.Empty;
                     btnLogout.Text = "Login";
                     Variables.IsLoged = false;
                     Variables.CloseAllMdiChildForms();
                     disableAllButton();
                 }
                 setToolStatus();
            }
        }


        private void frm_MainMDI_Load(object sender, EventArgs e)
        {
            disableAllButton();
            if(Variables.isEnglish == "true")
            {
                ToolStrip_English.Visible = true;
                toolStrip_Urdu.Visible = false;
            }
            else
            {
                ToolStrip_English.Visible = false;
                toolStrip_Urdu.Visible = true;
            }
            toolLabelRole.Text = string.Empty;
            toolLabelUsername.Text = string.Empty;
            if (!Variables.IsLoged)
            {
                fLogin = new frm_Login();
                fLogin.ShowDialog();
                setToolStatus();
                if (Variables.IsLoged)
                {
                    enableButtonWithRole();
                    if (Variables.isEnglish == "true")
                        btnLogout.Text = "Logout";
                    else
                        btnLogin_Urdu.Text = "لاگ آوؑٹ";
                }
            }
        }

        private void enableButtonWithRole()
        {
            if (Variables.roleName.ToUpper() == "SR" || Variables.roleName.ToUpper() == "ADMIN")
            {
                btnRegistrationDeed_English.Enabled = false;
                btnRegistrationDeed_Urdu.Enabled = false;
                btnUserManagement_English.Enabled = true;
                btnUserManagement_Urdu.Enabled = true;
                btnSetup_English.Enabled = true;
                btnSetup_Urdu.Enabled = true;
                btnInbox_English.Enabled = true;
                btnInbox_Urdu.Enabled = true;
                btnLanguage_English.Enabled = true;
                btnLanguage_Urdu.Enabled = true;
                
            }
            else
            {
                btnRegistrationDeed_English.Enabled = true;
                btnRegistrationDeed_Urdu.Enabled = true;
                btnUserManagement_English.Enabled = true;
                btnUserManagement_Urdu.Enabled = true;
                btnSetup_English.Enabled = true;
                btnSetup_Urdu.Enabled = true;
                btnInbox_English.Enabled = true;
                btnInbox_Urdu.Enabled = true;
                btnLanguage_English.Enabled = true;
                btnLanguage_Urdu.Enabled = true;

            }
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            //if (Variables.roleName.ToUpper() == "ADMIN")
            //{
                CreateUserEng obj = new CreateUserEng();
                obj.ShowDialog();
            //}
            //else
            //{
                //MessageBox.Show("You are not allowed to open this document");
            //}
        }

        private void btnInbox_Click(object sender, EventArgs e)
        {
            InboxForm_English obj = new InboxForm_English();
            obj.MdiParent = this;
            obj.Show();
        }

        private void btnCaste_Click(object sender, EventArgs e)
        {
            CastForm obj = new CastForm();
            obj.ShowDialog();
        }

        private void registryTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateRegistryTypeForm obj = new CreateRegistryTypeForm();
            obj.ShowDialog();
        }

        private void btnDistrict_Urdu_Click(object sender, EventArgs e)
        {
            Guid frm_id = ValidateFields.GetSafeGuid(Variables.frm_district_id);
            if (userFormAccessRights(frm_id))
            {
                frmDistrictSetup obj = new frmDistrictSetup();
                obj.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are not allowed to open this document");
            }

        }

        private void btnUrdu_Urdu_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Add("isEnglish", "false");
            config.Save(ConfigurationSaveMode.Minimal);
            if(Variables.IsLoged)            
            btnLogin_Urdu.Text = "لاگ آوؑٹ";
        }

        private void btnEnglish_English_Click(object sender, EventArgs e)
        {
            Variables.CloseAllMdiChildForms();
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings.Remove("isEnglish");
            config.AppSettings.Settings.Add("isEnglish", "true");
            config.Save(ConfigurationSaveMode.Minimal);
            ToolStrip_English.Visible = true;
            toolStrip_Urdu.Visible = false;
            btnLogout.Text = "Logout";
            setToolStatus();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
        }

        private void btnRegistrationDeed_Urdu_Click(object sender, EventArgs e)
        {
            if (Variables.UserName == string.Empty)
            {
                fLogin = new frm_Login();
                fLogin.ShowDialog();
                if (Variables.UserName != string.Empty)
                {
                    
                    btnLogin_Urdu.Text = "لاگ آوؑٹ";
                    RegistrationDeed_Urdu obj = new RegistrationDeed_Urdu();
                    obj.StartPosition = FormStartPosition.WindowsDefaultLocation;
                   // RD_Urd obj = new RD_Urd();
                    obj.MdiParent = this;
                    obj.Show();
                }
            }
            else
            {
                RegistrationDeed_Urdu obj = new RegistrationDeed_Urdu();
                //RD_Urd obj = new RD_Urd();
                obj.MdiParent = this;
                obj.Show();
            }
        }

        private void btnTehsil_Urdu_Click(object sender, EventArgs e)
        {
            Guid frm_id = ValidateFields.GetSafeGuid(Variables.frm_tehsil_id);
            if (userFormAccessRights(frm_id))
            {
                TehsilForm obj = new TehsilForm();
                obj.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are not allowed to open this document");
            }
        }

        private void btnUserManagement_Urdu_Click(object sender, EventArgs e)
        {
            //if (Variables.roleName.ToUpper() == "ADMIN")
            //{
            CreateUserEng obj = new CreateUserEng();
            obj.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("آپ کو اس دستاویز کو دیکھنے کی اجازت نہیں ہے");
            //}
        }

        private void btnLogin_Urdu_Click(object sender, EventArgs e)
        {
            if (btnLogin_Urdu.Text.ToUpper() == "لاگ ان")
            {

                if (!Variables.IsLoged)
                {
                    fLogin = new frm_Login();
                    fLogin.ShowDialog();
                    fLogin.StartPosition = FormStartPosition.CenterParent;
                    setToolStatus();
                    if (Variables.IsLoged)
                    {
                        //btnLogout.Text = "لاگ آوٗٹ";
                        if (Variables.isEnglish == "true")
                        {
                            btnLogout.Text = "Logout";
                        }
                        else
                        {
                            btnLogin_Urdu.Text = "لاگ آوٗٹ";
                        }
                    }
                }
                else
                {
                    setToolStatus();
                    if (Variables.isEnglish == "true")
                    {
                        btnLogout.Text = "Logout";
                    }
                    else
                    {
                        btnLogout.Text = "لاگ آوٗٹ";
                    }
                }
            }
            else
            {
                var result = MessageBox.Show("کیا آپ دستاویز کو بند کرنا چاہتے ہیں؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Variables.UserName = string.Empty;
                    Variables.UserRole = string.Empty;                   
                    if (Variables.isEnglish == "true")
                        btnLogout.Text = "Login";
                    else
                    {
                        btnLogin_Urdu.Text = "لاگ ان";
                    }
                    Variables.IsLoged = false;
                    Variables.CloseAllMdiChildForms();
                }
                setToolStatus();
            }
        }

        private void btnMauza_Urdu_Click(object sender, EventArgs e)
        {
            Guid frm_id = ValidateFields.GetSafeGuid(Variables.frm_mauza_id);
            if (userFormAccessRights(frm_id))
            {
                MauzaForm obj = new MauzaForm();
                obj.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are not allowed to open this document");
            }
        }

        private void btnCaste_Urdu_Click(object sender, EventArgs e)
        {
            CastForm obj = new CastForm();
            obj.ShowDialog();
        }

        private void btnRegistyType_Urdu_Click(object sender, EventArgs e)
        {
            CreateRegistryTypeForm obj = new CreateRegistryTypeForm();
            obj.ShowDialog();
        }

        private void btnInbox_Urdu_Click(object sender, EventArgs e)
        {
            InboxForm_Urdu obj = new InboxForm_Urdu();
            obj.MdiParent = this;
            obj.Show();            
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configurations obj = new Configurations();
            obj.MdiParent = this;
            obj.Show(); 
        }

        private void btnTown_English_Click(object sender, EventArgs e)
        {
            TownForm obj = new TownForm();
            obj.ShowDialog();

        }

        private void btnPartyType_Click(object sender, EventArgs e)
        {
            PartyTypeForm obj = new PartyTypeForm();
            obj.ShowDialog();
        }

        private void btnTown_Urdu_Click(object sender, EventArgs e)
        {
            TownForm obj = new TownForm();
            obj.ShowDialog();

        }

        private void btnPartyType_Urdu_Click(object sender, EventArgs e)
        {
            PartyTypeForm obj = new PartyTypeForm();
            obj.ShowDialog();
        }

        private void btnConfiguration_Urdu_Click(object sender, EventArgs e)
        {
            Configurations obj = new Configurations();
            obj.ShowDialog();
        }
    }
}
