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
using System.Collections;
using System.Reflection;

using System.Globalization;

namespace RDProject.RD
{
    public partial class InboxForm_Urdu : Form
    {
        frm_Login fLogin;
        eRegistryOperations oeSearchRegistryOperation = new eRegistryOperations();
        bRegistryOperations obRegistryOperations = new bRegistryOperations();
        int StartIndex = 0;
        int pageSize = 10;
        int EventControl = 0;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        public InboxForm_Urdu()
        {
            InitializeComponent();
            chkFresh.ForeColor = Color.FromArgb(225, 46, 46);
            chkSendToSR.ForeColor = Color.FromArgb(248, 140, 24);
            chkFinalize.ForeColor = Color.Green;
        }

        private void InboxForm_Urdu_Load(object sender, EventArgs e)
        {
            ddlPageSize.SelectedIndex = 0;
            if (!Variables.IsLoged)
            {
                fLogin = new frm_Login();
                fLogin.ShowDialog();
                //setToolStatus();
                if (Variables.IsLoged)
                {
                    //btnLogout.Text = "Logout";
                }
            }
            if (Variables.roleName.ToUpper() == "SCO")
            {
                CreateColumns();
                //bindSCOColumn();
                pnlState.Visible = true;
                chkAll_CheckedChanged(sender, e);
            }
            else if (Variables.roleName.ToUpper() == "SR")
            {
                CreateColumns();
                bindSRColumn();
                pnlState.Visible = false;
            }
        }


        private List<eRegistryOperations> GetRegistryOperationsByPaging(int regStage, bool isAll)
        {
            eRegistryOperations oeRegistryOperations = new eRegistryOperations();
            if (!isAll)
            {
                oeRegistryOperations.Registery_stage = regStage;
            }
            List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
            StartIndex = Convert.ToInt32(ddlTotalPages.SelectedItem == null ? "1" : ddlTotalPages.SelectedItem);
            //PageSize = Convert.ToInt32(ddlPageSize.SelectedItem == null ? "10" : ddlPageSize.SelectedItem);

            if (btn_Search.Enabled)
            {
                oeListRegistryOperations = obRegistryOperations.getRegistryOperations(BuildRegistryValues(), "access_datetime", "", StartIndex, PageSize);
            }
            else
            {
                oeListRegistryOperations = obRegistryOperations.getRegistryOperations(oeRegistryOperations, "access_datetime", "", StartIndex, PageSize);
            }
            if (oeListRegistryOperations != null && oeListRegistryOperations.Count > 0)
            {
                if ((bRegistryOperations.GetRegistryOperationsCount() % Convert.ToInt32(ddlPageSize.SelectedItem == null ? "10" : ddlPageSize.SelectedItem)) == 0)
                    SetDropDownPages((int)(bRegistryOperations.GetRegistryOperationsCount() / Convert.ToInt32(ddlPageSize.SelectedItem == null ? "10" : ddlPageSize.SelectedItem)));

                else
                    SetDropDownPages(Convert.ToInt32(bRegistryOperations.GetRegistryOperationsCount() / Convert.ToInt64(ddlPageSize.SelectedItem == null ? "10" : ddlPageSize.SelectedItem)) + 1);
            }
            return oeListRegistryOperations;
        }
        private void SetDropDownPages(int TotalPages)
        {
            if (ddlTotalPages.Items.Count > 0)
            {
                ddlTotalPages.Items.Clear();
            }
            for (int i = 0; i < TotalPages; i++)
            {
                ddlTotalPages.Items.Add((i + 1).ToString());
            }
            EventControl = 0;
            ddlTotalPages.SelectedIndex = 0;

        }

        private void CreateColumns()
        {
            DataGridViewTextBoxColumn dgvRegistryId = new DataGridViewTextBoxColumn();
            dgvRegistryId.Name = "colRegistryId";

            dgvRegistryId.Visible = false;
            grdInbox.Columns.Add(dgvRegistryId);

            DataGridViewTextBoxColumn dgvRegistryNo = new DataGridViewTextBoxColumn();
            dgvRegistryNo.HeaderText = "رجسٹری نمبر";
            dgvRegistryNo.Name = "colRegistryNo";
            dgvRegistryNo.Visible = false;
            grdInbox.Columns.Add(dgvRegistryNo);

            DataGridViewTextBoxColumn dgvDastaweezNo = new DataGridViewTextBoxColumn();
            dgvDastaweezNo.HeaderText = "دستاویز نمبر";
            dgvDastaweezNo.Name = "colDastaweezNo";
            dgvDastaweezNo.Width = 150;
            grdInbox.Columns.Add(dgvDastaweezNo);

            DataGridViewTextBoxColumn dgvDate = new DataGridViewTextBoxColumn();

            
            dgvDate.HeaderText = "تاریخ";
            dgvDate.Name = "colDate";
            dgvDate.DefaultCellStyle.Format = "dd/MM/yyyy";            
            grdInbox.Columns.Add(dgvDate);

            DataGridViewTextBoxColumn dgvStatus = new DataGridViewTextBoxColumn();
            dgvStatus.HeaderText = "سٹیٹس";
            dgvStatus.Name = "colStatus";
            dgvStatus.Visible = false;
            grdInbox.Columns.Add(dgvStatus);

            DataGridViewTextBoxColumn dgvRemarks = new DataGridViewTextBoxColumn();
            dgvRemarks.HeaderText = "ریمارکس";
            dgvRemarks.Name = "colRemarks";
            dgvRemarks.Width = 500;
            grdInbox.Columns.Add(dgvRemarks);

            DataGridViewButtonColumn dgvDescription = new DataGridViewButtonColumn();
            dgvDescription.HeaderText = ".";
            dgvDescription.Name = "colDescription";
            dgvDescription.Width = 75;
            grdInbox.Columns.Add(dgvDescription);
            //if (Variables.Role == (int)Variables.Roles.SRO)
            //    grdInbox.Columns[5].Visible = false;
            //else
            //    grdInbox.Columns[5].Visible = true;

        }

        private void PagingEvents(object sender, EventArgs e)
        {

        }
        private void bindSCOColumn(int regStage, bool isAll)
        {
            eRegistryOperations oeRegistryOperations = new eRegistryOperations();
            List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
            oeListRegistryOperations = GetRegistryOperationsByPaging(regStage, isAll);
            if (grdInbox.Rows.Count > 0)
            {
                grdInbox.DataSource = null;
                grdInbox.Rows.Clear();
            }
            if (oeListRegistryOperations != null && oeListRegistryOperations.Count > 0)
            {
                int registryStage = -1;
                for (int i = 0; i < oeListRegistryOperations.Count; i++)
                {
                    registryStage = oeListRegistryOperations[i].Registery_stage.Value;
                    grdInbox.Rows.Add();
                    grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colRegistryNo"].Value = oeListRegistryOperations[i].Registry_no;
                    grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colDastaweezNo"].Value = oeListRegistryOperations[i].Doc_number;
                    grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colDate"].Value = oeListRegistryOperations[i].Registry_date.ToShortDateString();
                    registryStage = oeListRegistryOperations[i].Registery_stage.Value;
                    if (registryStage == 0)
                    {
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
                        grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(225, 120, 117);
                    }
                    if (registryStage == 1)
                    {
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
                        grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(253, 195, 87);
                    }
                    if (registryStage == 2)
                    {
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
                        grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(170, 248, 152);
                    }
                    grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
                    grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colRemarks"].Value = oeListRegistryOperations[i].Remarks;
                }
                EventControl = 1;
            }

            //eRegistryOperations oeRegistryOperations = new eRegistryOperations();
            //List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
            //oeListRegistryOperations = GetRegistryOperationsByPaging();
            //if (oeListRegistryOperations != null && oeListRegistryOperations.Count > 0)
            //{
            //    int registryStage = -1;
            //    for (int i = 0; i < oeListRegistryOperations.Count; i++)
            //    {
            //        registryStage = oeListRegistryOperations[i].Registery_stage.Value;
            //        if (registryStage != 1 && registryStage != 4)
            //        {
            //            grdInbox.Rows.Add();
            //            grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colRegistryNo"].Value = oeListRegistryOperations[i].Registry_no;
            //            grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colDate"].Value = oeListRegistryOperations[i].Registry_date.ToShortDateString();
            //            //grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colDescription"].Value = oeListRegistryOperations[i].;
            //            registryStage = oeListRegistryOperations[i].Registery_stage.Value;
            //            if (registryStage == 0)
            //            {
            //                grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
            //                grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.BlueViolet;
            //            }
            //            if (registryStage == 2)
            //            {
            //                grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
            //                //grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(185, 218, 205);
            //                grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Green;
            //            }
            //            if (registryStage == 3)
            //            {
            //                grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
            //                //grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(170, 36, 48);
            //                grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
            //            }
            //            if (registryStage == 5)
            //            {
            //                grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
            //                //grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(160, 160, 162);
            //                grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Gray;
            //            }

            //            grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
            //            grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colRemarks"].Value = oeListRegistryOperations[i].Remarks;
            //        }
            //    }
            //}
        }

        private void bindSRColumn()
        {
            eRegistryOperations oeRegistryOperations = new eRegistryOperations();
            List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
            bRegistryOperations obRegistryOperations = new bRegistryOperations();
            oeListRegistryOperations = GetRegistryOperationsByPaging(0,true);
            if (oeListRegistryOperations != null && oeListRegistryOperations.Count > 0)
            {

                if (grdInbox.Rows.Count > 0)
                {
                    grdInbox.DataSource = null;
                    grdInbox.Rows.Clear();
                }
                int registryStage = -1;
                for (int i = 0; i < oeListRegistryOperations.Count; i++)
                {
                    registryStage = oeListRegistryOperations[i].Registery_stage.Value;
                    if (registryStage == 1 || registryStage == 4)
                    {
                        grdInbox.Rows.Add();
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colRegistryNo"].Value = oeListRegistryOperations[i].Registry_no;
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colDastaweezNo"].Value = oeListRegistryOperations[i].Doc_number;
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colDate"].Value = oeListRegistryOperations[i].Registry_date.ToShortDateString();
                        //grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colDescription"].Value = oeListRegistryOperations[i].;
                        registryStage = oeListRegistryOperations[i].Registery_stage.Value;
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
                        //grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(185, 218, 205);

                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colRemarks"].Value = oeListRegistryOperations[i].Remarks;

                        registryStage = oeListRegistryOperations[i].Registery_stage.Value;
                        if (registryStage == 1)
                        {
                            grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
                            grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(185, 218, 205);
                        }
                        if (registryStage == 4)
                        {
                            grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
                            grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(170, 36, 48);
                        }
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colRemarks"].Value = oeListRegistryOperations[i].Remarks;
                    }
                }
                EventControl = 1;
            }
        }

        private void grdInbox_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                e.Value = "تفصیل";
                //e.CellStyle.WrapMode = DataGridViewTriState.False;
            }
        }

        private void grdInbox_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 6)
                {
                    string regNo = grdInbox.Rows[e.RowIndex].Cells["colRegistryNo"].Value.ToString();
                    string sDateTime = grdInbox.Rows[e.RowIndex].Cells["colDate"].Value.ToString();
                    RegistrationDeed_Urdu obj = new RegistrationDeed_Urdu();
                    obj.Show();
                    obj.txtRegistryNo.Text = regNo;
                    obj.fromIndexing = true;
                    obj.txtDate.Text = sDateTime;
                    obj.txtRegistryNo_Leave(sender, e);
                }
            }
        }

        private void InboxForm_Urdu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Control ctl;
                ctl = (Control)sender;
                ctl.SelectNextControl(ActiveControl, true, true, true, true);
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (grdInbox.Focused)
                {
                    this.Close();
                }
                else
                {
                    grdInbox.Enabled = true;
                    grdInbox.SelectAll();
                    grdInbox.Focus();
                    return;
                }
            }
        }
        private void clreaGrid()
        {
            grdInbox.Rows.Clear();
        }
        private void LoadRegistryTypes()
        {
            bRegistryType obRegistryType = new bRegistryType();
            eRegistryType oeRegistryType = new eRegistryType();
            List<eRegistryType> oeListRegistryType = obRegistryType.getRegistryType(oeRegistryType, "", "", 0, int.MaxValue);
            AddItem(oeListRegistryType, typeof(eRegistryType), "Registry_type_id", "Registry_type_description_urd", "چنیں");
            if (oeListRegistryType != null && oeListRegistryType.Count > 0)
            {
                cbxRegisteryType.DisplayMember = "Registry_type_description_urd";
                cbxRegisteryType.ValueMember = "Registry_type_id";
                cbxRegisteryType.DataSource = oeListRegistryType;
            }
        }
        private void AddItem(IList list, Type type, string valueMember, string displayMember, string displayText)
        {
            Object obj = Activator.CreateInstance(type);
            PropertyInfo displayProperty = type.GetProperty(displayMember);
            displayProperty.SetValue(obj, displayText, null);
            PropertyInfo valueProperty = type.GetProperty(valueMember);
            Guid i = new Guid();
            valueProperty.SetValue(obj, i, null);
            list.Insert(0, obj);
        }
        private eRegistryOperations BuildRegistryValues()
        {
            // string Condition = "";

            if (txtDastaweezNo.Enabled && txtDastaweezNo.Text != string.Empty)
                oeSearchRegistryOperation.Registry_no = txtDastaweezNo.Text;

            if (RegistryDatePicker.Enabled)
            {
                oeSearchRegistryOperation.Registry_date = Convert.ToDateTime(RegistryDatePicker.Value.ToShortDateString());
            }
            else
                oeSearchRegistryOperation.Registry_date = DateTime.MinValue;

            if (cbxRegisteryType.Enabled && new Guid(cbxRegisteryType.SelectedValue.ToString()) != Guid.Empty)
                oeSearchRegistryOperation.Registry_type_id = new Guid(cbxRegisteryType.SelectedValue.ToString());

            return oeSearchRegistryOperation;
        }
        private void chkCommon_CheckedChanged(object sender, EventArgs e)
        {
            string chkBoxName = ((CheckBox)sender).Name;
            if (chkBoxName == "chkDastaweezNo")
            {
                if (chkDastaweezNo.Checked)
                {
                    txtDastaweezNo.Enabled = true;
                }
                else
                {
                    txtDastaweezNo.Enabled = false;
                }
            }
            else if (chkBoxName == "chkDate")
            {
                if (chkDate.Checked)
                {
                    RegistryDatePicker.Enabled = true;
                }
                else
                {
                    RegistryDatePicker.Enabled = false;
                }
            }
            else if (chkBoxName == "chkRegistryType")
            {
                if (chkRegistryType.Checked)
                {
                    cbxRegisteryType.Enabled = true;
                    LoadRegistryTypes();
                }
                else
                {
                    cbxRegisteryType.DataSource = null;
                    cbxRegisteryType.Items.Clear();
                    cbxRegisteryType.Enabled = false;
                }
            }
            if (((CheckBox)sender).Checked)
            {
                btn_Search.Enabled = true;
            }
            else
            {
                btn_Search.Enabled = false;
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                eRegistryOperations oeRegistryOperations = new eRegistryOperations();
                bRegistryOperations obRegistryOperations = new bRegistryOperations();
                List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
                oeRegistryOperations = BuildCondition(oeRegistryOperations);
                oeListRegistryOperations = obRegistryOperations.getRegistryOperations(oeRegistryOperations, "", "", 0, int.MaxValue);
                if (grdInbox.Rows.Count > 0)
                {
                    grdInbox.DataSource = null;
                    grdInbox.Rows.Clear();
                }
                if (oeListRegistryOperations != null & oeListRegistryOperations.Count > 0)
                {
                    int registryStage = -1;
                    for (int i = 0; i < oeListRegistryOperations.Count; i++)
                    {
                        registryStage = oeListRegistryOperations[i].Registery_stage.Value;
                        grdInbox.Rows.Add();
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colRegistryNo"].Value = oeListRegistryOperations[i].Registry_no;
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colDastaweezNo"].Value = oeListRegistryOperations[i].Doc_number;
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colDate"].Value = oeListRegistryOperations[i].Registry_date.ToShortDateString();
                        registryStage = oeListRegistryOperations[i].Registery_stage.Value;
                        if (registryStage == 0)
                        {
                            grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
                            //grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Maroon;
                            grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(225, 120, 117);
                        }
                        if (registryStage == 1)
                        {
                            grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
                            grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(253, 195, 87);
                        }
                        if (registryStage == 2)
                        {
                            grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
                            grdInbox.Rows[grdInbox.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(170, 248, 152);
                        }
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colStatus"].Value = oeListRegistryOperations[i].Registery_stage;
                        grdInbox.Rows[grdInbox.Rows.Count - 1].Cells["colRemarks"].Value = oeListRegistryOperations[i].Remarks;
                    }
                    EventControl = 1;
                }

                //if (Variables.roleName.ToUpper() == "SCO")
                //{
                //    grdInbox.Columns.Clear();
                //    CreateColumns();
                //    //bindSCOColumn(0, );
                //    pnlState.Visible = true;
                //}
                //else if (Variables.roleName.ToUpper() == "SR")
                //{
                //    grdInbox.Columns.Clear();
                //    CreateColumns();
                //    bindSRColumn();
                //    pnlState.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                msgStatus.Text = "Some Problem Occured While Searching...";
            }
        }

        private eRegistryOperations BuildCondition(eRegistryOperations oeRegistryOperation)
        {
            if (txtDastaweezNo.Enabled && txtDastaweezNo.Text != string.Empty)
                oeRegistryOperation.Doc_number = txtDastaweezNo.Text.Trim();
            //Condition += (Condition == "" ? "" : " AND ") + "registry_no = '" + txtDastaweezNo.Text + "'";
            if (RegistryDatePicker.Enabled)
                oeRegistryOperation.Registry_date = RegistryDatePicker.Value.Date;
            //Condition += (Condition == "" ? "" : " AND ") + "registry_date = '" + RegistryDatePicker.Value.Date + "'";
            if (cbxRegisteryType.Enabled && new Guid(cbxRegisteryType.SelectedValue.ToString()) != Guid.Empty)
                oeRegistryOperation.Registry_type_id = ValidateFields.GetSafeGuid(cbxRegisteryType.SelectedValue);
            //Condition += (Condition == "" ? "" : " AND ") + "Registry_type_id = '" + cbxRegisteryType.SelectedValue.ToString() + "'";
            return oeRegistryOperation;
        }

        //private void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        // {
        //     if (Variables.roleName.ToUpper() == "SCO")
        //     {
        //         CreateColumns();
        //         //bindSCOColumn();
        //         pnlState.Visible = true;
        //         chkAll_CheckedChanged(sender, e);
        //     }
        //     else if (Variables.roleName.ToUpper() == "SR")
        //     {
        //         CreateColumns();
        //         bindSRColumn();
        //         pnlState.Visible = false;
        //     }
        // }
        private void ddlPageSize_SelectedValueChanged(object sender, EventArgs e)
        {
            if (EventControl == 1)
            {
                PageSize = Convert.ToInt32(ddlPageSize.SelectedItem);
                if (Variables.roleName.ToUpper() == "SCO")
                {
                    bindSCOColumn(0, true);

                }
                else if (Variables.roleName.ToUpper() == "SR")
                {

                    bindSRColumn();
                    pnlState.Visible = false;
                }
            }
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                clearGrid();
                chkFinalize.Checked = false;
                chkFresh.Checked = false;
                chkSendToSR.Checked = false;
                bindSCOColumn(0, true);
            }
            else
            {
                grdInbox.DataSource = null;
                grdInbox.Rows.Clear();
            }
        }

        private void chkInitialStep_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFresh.Checked)
            {
                clearGrid();
                chkAll.Checked = false;
                chkSendToSR.Checked = false;
                chkFinalize.Checked = false;
                bindSCOColumn(0, false);
            }
        }

        private void chkSendToSR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSendToSR.Checked)
            {
                clearGrid();
                chkAll.Checked = false;
                chkFresh.Checked = false;
                chkFinalize.Checked = false;
                bindSCOColumn(1, false);
            }
        }

        private void chkFinalize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFinalize.Checked)
            {
                clearGrid();
                chkAll.Checked = false;
                chkFresh.Checked = false;
                chkSendToSR.Checked = false;
                bindSCOColumn(2, false);
            }
        }

        private void clearGrid()
        {
            if (grdInbox.Rows.Count > 0)
            {
                grdInbox.DataSource = null;
                grdInbox.Rows.Clear();
            }
        }

        private void ddlTotalPages_SelectedValueChanged(object sender, EventArgs e)
        {
            if (EventControl == 1)
            {
                if (Variables.roleName.ToUpper() == "SCO")
                {
                    bindSCOColumn(0, true);

                }
                else if (Variables.roleName.ToUpper() == "SR")
                {

                    bindSRColumn();
                    pnlState.Visible = false;
                }
            }
            EventControl = 0;
        }

        private void btn_First_Click(object sender, EventArgs e)
        {
            PageSize = 10;
            EventControl = 0;
            ddlPageSize.Text = PageSize.ToString();
            bindSCOColumn(0, true);
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            if (PageSize > 10 || PageSize == 100)
            {
                PageSize = PageSize - 10;
                EventControl = 0;
                ddlPageSize.Text = PageSize.ToString();
                bindSCOColumn(0, true);
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (PageSize == 10 || PageSize > 10 && PageSize < 100)
            {
                PageSize = PageSize + 10;
                EventControl = 0;
                ddlPageSize.Text = PageSize.ToString();
                bindSCOColumn(0, true);

            }

        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            PageSize = 100;
            EventControl = 0;
            ddlPageSize.Text = PageSize.ToString();
            bindSCOColumn(0, true);
        }

    }
}
