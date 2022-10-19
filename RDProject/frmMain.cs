using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using RD.BLL.General;
using System.Globalization;
using RDProject.GenClass;

namespace RDProject
{
    public partial class frm_Main : Form
    {
        //private System.ComponentModel.Container components = null;
        public static string language = "en";

        RDBasicInfoForm objBasic;
        frm_BasicInfo objBasicInfo;
        frm_Login objLogin;
        frm_Inbox objInbox;
        int nFirstOpen = 1;
        private static Size ChildSize = new Size(580, 200);
        public frm_Main()
        {
            //rm = new System.Resources.ResourceManager(typeof(frmMain));
            //rm = new System.Resources.ResourceManager("RDProject", System.Reflection.Assembly.GetExecutingAssembly());
            //LangHash.Add("English", Thread.CurrentThread.CurrentCulture);
            //LangHash.Add("Urdu", new System.Globalization.CultureInfo("ur"));
            //LangHash.Add("English", new System.Globalization.CultureInfo("en"));

            InitializeComponent();
            clsCulture.Localize(this, language);
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
        }

        public void onClosingLoginForm()
        {
            if (Variables.IsLoged)
            {
                btnLogin.Enabled = false;
                btnLogout.Enabled = true;
                lblUserName.Text += Variables.UserName;
                if (Variables.Role == 1)
                {
                    lblRole.Text += "سروس سنٹر افیشل";
                }
                else if (Variables.Role == 2)
                {
                    lblRole.Text += "سب رجسٹرار";
                }
                //menuStrip1.Enabled = true;

            }
            else
            {
                btnLogout.Enabled = false;
                btnLogin.Enabled = true;
            }

            //objLogin = new frmLogin_win();
            //if (!Variables.IsLoged)
            //{
            //    while (!objLogin.ShowLogin()) ;
            //}

            //if (!Variables.IsLoged)
            //{
            //    this.Close();
            //    return;
            //}
            //else
            //{
            //    pnlMenu.Enabled = true;
            //}
            //lblUserName.Text = "   صارف کا نام :" + Variables.strLoginName;
            //if (Variables.Role == 1)
            //{
            //    lblRole.Text = "   صارف کا کردار : سروس سنٹر افیشل";
            //}
            //else if (Variables.Role == 2)
            //{
            //    lblRole.Text = "   صارف کا کردار : سب رجسٹرار";
            //}
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!Variables.IsLoged)
            {
                btnLogout.Enabled = false;
                //menuStrip1.Enabled = false;
                //pnlMenu.Enabled = false;
                objLogin = new frm_Login();
                objLogin.StartPosition = FormStartPosition.CenterParent;
                objLogin.ShowDialog();
            }
            //onClosingLoginForm();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void toolMessage_Click(object sender, EventArgs e)
        {
            objInbox = new frm_Inbox();
            objInbox.MdiParent = this;
            objInbox.StartPosition = FormStartPosition.CenterParent;
            objInbox.Show();
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            //RDBasicInfoForm obj = new RDBasicInfoForm();
            objBasicInfo = new frm_BasicInfo();
            objBasicInfo.MdiParent = this;
            objBasicInfo.StartPosition = FormStartPosition.CenterParent;
            objBasicInfo.Show();
        }

        private void toolFind_Click(object sender, EventArgs e)
        {
            Inbox obj = new Inbox();
            obj.MdiParent = this;
            obj.StartPosition = FormStartPosition.CenterParent;
            obj.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Variables.IsLoged)
            {
                objLogin = new frm_Login();
                objLogin.ShowDialog();
                //Variables.IsLoged = true;
            }
        }

        private void toolRegDeed_Click(object sender, EventArgs e)
        {
            if (Variables.Role == (int)Variables.Roles.SCO)
            {
                objBasicInfo = new frm_BasicInfo();
                //frmBasicInfo obj = new frmBasicInfo();
                objBasicInfo.MdiParent = this;
                objBasicInfo.StartPosition = FormStartPosition.CenterParent;
                objBasicInfo.Show();
            }
            else
            {
                MessageBox.Show("access denied");
                return;
            }
        }


        private void toolUrdu_Click(object sender, EventArgs e)
        {
            language = "ur";
            clsCulture.Localize(this, language);
        }

        private void toolEnglish_Click(object sender, EventArgs e)
        {
            language = "en";
            clsCulture.Localize(this, language);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FadeForm(this, 100);
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

    }
}
