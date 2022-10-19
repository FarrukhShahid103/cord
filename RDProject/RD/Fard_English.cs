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

namespace RDProject.RD
{
    public partial class Fard_English : Form
    {
        public int registryNo = -1;
        public Guid registryId;
        public bool NewRecord;
        private Guid fardId;
        public Guid mauzaId;

        eFard oeFard = new eFard();
        bFard obFard = new bFard();

        List<eFard> oeListFard = null;

        updatedNewEntryInfo EntityStatus = null;

        public Fard_English()
        {
            InitializeComponent();
        }

        private void GetFardByRegistryID()
        {
            oeFard.Registry_id = registryId;
            oeListFard = obFard.getFard(oeFard, "", "", 0, int.MaxValue);
            if (oeListFard !=null && oeListFard.Count ==1)
            {
                fardId = oeListFard[0].Fard_id;
                txtFardNo.Text = oeListFard[0].Fard_no;
                txtFardObjective.Text = oeListFard[0].Fard_objective;
                txtTotalFee.Text = oeListFard[0].Total_fee.ToString();
                txtRemarks.Text = oeListFard[0].Remarks;
                chkShamlat.Checked = oeListFard[0].Is_shamlat;
                btnSave.Text = "&Update";
                btnDelete.Enabled = true;
                txtFardNo.Enabled = true;
                txtFardObjective.Focus();
                NewRecord = false;
            }
            else
            {
                NewRecord = true;
                txtFardNo.Enabled = true;
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtFardNo.Text))
            {
                txtFardNo.Focus();
                lblMsg.Text = "Fard No. is missing; must have value.";
                return false;
            }
            return true;
        }
      

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                oeFard.Registry_id = registryId;
                oeFard.Fard_no = txtFardNo.Text;
                oeFard.Fard_objective = txtFardObjective.Text;
                oeFard.Is_active = true;
                oeFard.Is_shamlat = chkShamlat.Checked;
                oeFard.Remarks = txtRemarks.Text;
                oeFard.Access_datetime = DateTime.Now;
                oeFard.User_id = Variables.UserId;
                if (NewRecord)
                {
                    oeFard.Fard_id = Guid.NewGuid();
                    EntityStatus = obFard.insertFard(oeFard);
                    if (EntityStatus.Success)
                        MessageBox.Show("Fard insert successfully");
                    else
                        MessageBox.Show("Fard not insert");
                }
                else
                {
                    oeFard.Fard_id = fardId;
                    EntityStatus = obFard.udpateFard(oeFard);
                    if (EntityStatus.Success)
                        MessageBox.Show("Fard update successfully");
                    else
                        MessageBox.Show("Fard not udpate");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Fard_English_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            GetFardByRegistryID();
            
        }

        private void Fard_English_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Control ctl;
                ctl = (Control)sender;
                ctl.SelectNextControl(ActiveControl, true, true, true, true);
            }


            if (e.KeyChar == (char)Keys.Escape)
            {
                if (txtFardNo.Focused)
                {
                    this.Close();
                }
                else
                {
                    txtFardNo.Enabled = true;
                    txtFardNo.Focus();
                    return;
                }
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReport objReportViewer = new frmReport();
            //mauzaId = new Guid("67465637-403D-4023-BDB6-8803FFE7F02B");
            if (mauzaId != null && mauzaId != new Guid() && txtFardNo.Text != string.Empty)
            {
                objReportViewer.mauzaId = mauzaId;
                objReportViewer.docNo = Convert.ToInt32(txtFardNo.Text);
                objReportViewer.Show();
            }
        }
    }
}
