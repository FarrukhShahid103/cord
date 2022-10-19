using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;

namespace RDProject
{
    public partial class Form1 : Telerik.WinControls.UI.RadForm
    {
        public Form1()
        {

            LoginForm ch = new LoginForm();
            ch.ShowDialog();
            InitializeComponent();
        }


        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            if (Variables.Role == (int)Variables.Roles.SCO)
            {
                RDBasicInfoForm obj = new RDBasicInfoForm();
                obj.Show();
            }
            else
            {
                MessageBox.Show("access denied");
                return;
            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void radMenuItem3_Click(object sender, EventArgs e)
        {
            if (Variables.IsLoged == true && Variables.Role == (int)Variables.Roles.SRO)
            {
                Inbox obj = new Inbox();
                //obj.MdiParent = this;
                obj.StartPosition = FormStartPosition.CenterParent;
                obj.Show();
            }
            else
            {
                MessageBox.Show("access denied");
                return;
            }

        }

        private void radPanelDemo_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
