using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RDProject
{
    public partial class ScanPicture : Telerik.WinControls.UI.ShapedForm
    {
        public ScanPicture()
        {
            InitializeComponent();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void ScanPicture_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
