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
    public partial class Fard_Urdu : Form
    {
        public int registryNo = -1;
        public Guid registryId;
        public bool NewRecord;
        private Guid fardId;
        public Guid mauzaId;
     
        public Fard_Urdu()
        {
            InitializeComponent();
        }

        private void GetFardByRegistryID()
        {
            eFard oeFard = new eFard();
            oeFard.Registry_id = registryId;
            List<eFard> oeListFard = new List<eFard>();
            bFard obFard = new bFard();
            oeListFard = obFard.getFard(oeFard, "", "", 0, int.MaxValue);
            if (oeListFard != null && oeListFard.Count == 1)
            {
                fardId = oeListFard[0].Fard_id;
                txtFardNo.Text = oeListFard[0].Fard_no;
                txtFardObjective.Text = oeListFard[0].Fard_objective;                
                txtTotalFee.Text = oeListFard[0].Total_fee.ToString();
                txtRemarks.Text = oeListFard[0].Remarks;
                chkShamlat.Checked = oeListFard[0].Is_shamlat;
                btnSave.Text = "تبدیل کریں";
                btnDelete.Enabled = true;
                txtFardNo.Enabled = false;
                txtFardObjective.Focus();
                NewRecord = false;
            }
            else
            {
                NewRecord = true;
                txtFardNo.Enabled = true;
            }
        }

        private bool checkFardFieldEmpty()
        {
            bool isEmpty = true;
            if (txtFardNo.Text == string.Empty)
            {
                isEmpty = false;
                txtFardNo.Focus();
                lblMsg.Text = "فرد نمبر درج کریں";
                return isEmpty;
            }

            //if (txtTotalFee.Text == string.Empty)
            //{
            //    isEmpty = false;
            //    txtTotalFee.Focus();
            //    return isEmpty;
            //}
            return isEmpty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkFardFieldEmpty())
            {
                eFard oeFard = new eFard();
                List<eFard> oeListFard = new List<eFard>();
                bFard obFard = new bFard();
                updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();

                oeFard.Registry_id = registryId;
                oeFard.Fard_no = txtFardNo.Text;
                oeFard.Fard_objective = txtFardObjective.Text;
                //oeFard.Total_fee = Convert.ToInt32(txtTotalFee.Text);
                oeFard.Is_active = true;
                oeFard.Is_shamlat = chkShamlat.Checked;
                oeFard.Remarks = txtRemarks.Text;
                oeFard.Access_datetime = DateTime.Now;
                oeFard.User_id = Variables.UserId;
                if (NewRecord)
                {
                    oeFard.Fard_id = Guid.NewGuid();
                    insertInfo = obFard.insertFard(oeFard);
                    if (insertInfo.Success)
                        lblMsg.Text = "ریکارڈ کامیابی کے ساتھ محفوظ کر دیاگیا ھے۔";
                    else
                        lblMsg.Text = "مسلہؑ آ گیا ھے۔";                        
                }
                else
                {
                    oeFard.Fard_id = fardId;
                    insertInfo = obFard.udpateFard(oeFard);
                    if (insertInfo.Success)
                        lblMsg.Text = "ریکارڈ کامیابی کے ساتھ تبدیل کر دیاگیا ھے۔";
                    else
                        lblMsg.Text = "مسلہؑ آ گیا ھے۔";
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Fard_Urdu_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            GetFardByRegistryID();

        }

        private void Fard_Urdu_KeyPress(object sender, KeyPressEventArgs e)
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
