using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;
using RDProject.Properties;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Telerik.WinControls.UI;
using RDProject.GenClass;
using RD.EL;
using RD.BLL;

namespace RDProject
{
    public partial class frm_Inbox : Form
    {
        public frm_Inbox()
        {
            InitializeComponent();
            clsCulture.Localize(this, frm_Main.language);
        }

        private void frmInbox_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn dgvDate = new DataGridViewTextBoxColumn();
            //dgvDate.HeaderText = "تاریخ";
            dgvDate.HeaderText = clsCulture.GetLocalizedString("dgvStatusColDate", frm_Main.language);
            dgvDate.Name = "colDate";
            grdPerson.Columns.Add(dgvDate);

            DataGridViewTextBoxColumn dgvRegistryNo = new DataGridViewTextBoxColumn();
            dgvRegistryNo.HeaderText = "رجسٹری نمبر";
            dgvRegistryNo.HeaderText = clsCulture.GetLocalizedString("dgvStatusColRegistryNo", frm_Main.language);
            dgvRegistryNo.Name = "colRegistryNo";
            grdPerson.Columns.Add(dgvRegistryNo);

            DataGridViewTextBoxColumn dgvStage = new DataGridViewTextBoxColumn();
            dgvStage.HeaderText = "منظور شدہ";
            dgvStage.HeaderText = clsCulture.GetLocalizedString("dgvStatusColApproved", frm_Main.language);
            dgvStage.Name = "colStage";
            grdPerson.Columns.Add(dgvStage);

            DataGridViewButtonColumn dgvDescription = new DataGridViewButtonColumn();
            dgvDescription.Name = "colDescription";
            grdPerson.Columns.Add(dgvDescription);

            DataGridViewTextBoxColumn dgvStatus = new DataGridViewTextBoxColumn();
            dgvStatus.HeaderText = "سٹیٹس";
            dgvStatus.HeaderText = clsCulture.GetLocalizedString("dgvStatusColStatus", frm_Main.language);
            dgvStatus.Name = "colStatus";
            grdPerson.Columns.Add(dgvStatus);

            DataGridViewTextBoxColumn dgvRemarks = new DataGridViewTextBoxColumn();
            dgvRemarks.HeaderText = "ریماکس";
            dgvRemarks.HeaderText = clsCulture.GetLocalizedString("dgvStatusColRemarks", frm_Main.language);
            dgvRemarks.Name = "colRemarks";
            grdPerson.Columns.Add(dgvRemarks);

            if (Variables.Role == (int)Variables.Roles.SRO)
                grdPerson.Columns[5].Visible = false;
            else
                grdPerson.Columns[5].Visible = true;

            LoadRegistries();
        }

        private void LoadRegistries()
        {
            eRegistryOperations oeRegistryOperations = new eRegistryOperations();
            List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
            bRegistryOperations obRegistryOperations = new bRegistryOperations();
            oeRegistryOperations.Registery_stage = (int)Variables.Roles.SCO;
            oeListRegistryOperations = obRegistryOperations.getRegistryOperations(oeRegistryOperations, "", "", 0, int.MaxValue);
            if (oeListRegistryOperations != null && oeListRegistryOperations.Count > 0)
            {
                for (int i = 0; i < oeListRegistryOperations.Count; i++)
                {
                    grdPerson.Rows.Add();
                    grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colRegistryNo"].Value = oeListRegistryOperations[i].Registry_no;
                    grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colStage"].Value = oeListRegistryOperations[i].Registery_stage;
                    grdPerson.Rows[grdPerson.Rows.Count - 1].Cells["colRemarks"].Value = oeListRegistryOperations[i].Remarks;
                }
            }

            //Database db = DatabaseFactory.CreateDatabase("ConnStr");
            //try
            //{
            //    string sql = "select reg_status, remarks, registry_decision_date, registry_no, ISNULL(registery_stage, 0) AS registery_stage  from rd.RegistryOperations where registery_stage = @RegistryStage";
            //    DbCommand cmd = db.GetSqlStringCommand(sql);

            //    if (Variables.Role == (int)Variables.Roles.SRO)
            //        db.AddInParameter(cmd, "@RegistryStage", DbType.Int16, 1);
            //    if (Variables.Role == (int)Variables.Roles.SCO)
            //        db.AddInParameter(cmd, "@RegistryStage", DbType.Int16, 2);

            //    DataSet ds = db.ExecuteDataSet(cmd);
            //    if (ds != null && ds.Tables.Count > 0)
            //    {
            //        int i = 0;
            //        foreach (DataRow dRow in ds.Tables[0].Rows)
            //        {
            //            //DataGridViewRow dgvNewRow = new DataGridViewRow();
            //            grdPerson.Rows.Add();
            //            grdPerson.Rows[i].Cells["colDate"].Value = dRow["registry_decision_date"].ToString();
            //            grdPerson.Rows[i].Cells["colRegistryNo"].Value = dRow["registry_no"].ToString();
            //            grdPerson.Rows[i].Cells["colStage"].Value = dRow["registery_stage"].ToString();
            //            grdPerson.Rows[i].Cells["colStatus"].Value = dRow["reg_status"].ToString();
            //            if (grdPerson.Columns["colRemarks"].Visible)
            //            {
            //                grdPerson.Rows[i].Cells["colRemarks"].Value = dRow["remarks"].ToString();
            //            }
            //            //grdPerson.Rows.Add(dgvNewRow);
            //            i++;
            //        }
            //        //grdPerson.DataSource = ds.Tables[0];
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }

        private void grdPerson_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Variables.load = "0";
            if (e.ColumnIndex == 3)
            {
                if (grdPerson.Rows.Count > 0)
                {
                    Variables.load = "1";
                    //RDBasicInfoForm obj = new RDBasicInfoForm();
                    //frm_BasicInfo obj = new frm_BasicInfo();
                    frm_BasicInformation obj = new frm_BasicInformation();
                    Variables.registryNo =  grdPerson.Rows[e.RowIndex].Cells[1].Value.ToString();
                    obj.MdiParent = this.ParentForm;
                    //obj.txtRegistryNo_Leave(sender, e);
                    //obj.isLoading = true;
                    obj.Show();
                }
            }
        }

        private void grdPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                var result = MessageBox.Show("Close?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
    }
}
