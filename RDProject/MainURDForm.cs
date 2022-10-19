using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RDProject.GenClass;

namespace RDProject
{
    public partial class MainURDForm : Form
    {
        public static string language = "en";
        public MainURDForm()
        {
            InitializeComponent();
            clsCulture.Localize(this, language);
        }

        private void MainURDForm_Load(object sender, EventArgs e)
        {
            pnlMain.BackColor = Color.FromArgb(25,127,189);
            ToolStrip.BackColor = Color.FromArgb(25, 127, 189);
            MessageBox.Show(this.Size.ToString());
        }

        private void btnUrdu_Click(object sender, EventArgs e)
        {
            language = "ur";
            Variables.language = "ur";
            string message = clsCulture.GetLocalizedString("closeChildForm", language);
            //if (!frm_BasicInformation.isClose)
            //{
            //    var result = MessageBox.Show(message, "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //    if (result == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        objBasicInfo.Close();
            //        frm_BasicInformation.isClose = true;
            //        toolDocument_Click(sender, e);
            //        clsCulture.Localize(this, language);
            //    }
            //}
            //else
            //{
            //    clsCulture.Localize(this, language);
            //}    
        }
    }
}
