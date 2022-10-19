using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RD.BLL;
using RD.EL;
using System.Collections;
using System.Reflection;

namespace RDProject.Setup
{
    public partial class PartyTypeForm : Form
    {
        private bool isException;
        public PartyTypeForm()
        {
            InitializeComponent();
            loadRegistryType();
            lblStatus.Text = string.Empty;
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


        private void loadRegistryType()
        {
            bRegistryType obRegistryType = new bRegistryType();
            eRegistryType oeRegistryType = new eRegistryType();
            List<eRegistryType> oeListRegistryType = new List<eRegistryType>();

            oeListRegistryType = obRegistryType.getRegistryType(oeRegistryType, "", "", 0, int.MaxValue);
            AddItem(oeListRegistryType, typeof(eRegistryType), "Registry_type_id", "Registry_type_description_eng", "< - SELECT - >");
            if (oeListRegistryType != null && oeListRegistryType.Count > 0)
            {
                cbRegistryType.DisplayMember = "registry_type_description_eng";
                cbRegistryType.ValueMember = "registry_type_id";
                cbRegistryType.DataSource = oeListRegistryType;
            }
        }

        private void FillGrid(Guid RegistryTypeID)
        {
            grdPartyType.AutoGenerateColumns = false;
            grdPartyType.AllowUserToAddRows = false;
            grdPartyType.Rows.Clear();

            bPartyType manager = new bPartyType();
            ePartyType oePartyType = new ePartyType();
            oePartyType.Registry_type_id = RegistryTypeID; 
            
            List<ePartyType> list = manager.getPartyType(oePartyType, "", "", 1, 10);
            if (list.Count > 0) grdPartyType.Rows.Add(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                grdPartyType.Rows[i].Cells[0].Value = list[i].Party_type_id;
                grdPartyType.Rows[i].Cells[1].Value = list[i].Party_name_eng;
                grdPartyType.Rows[i].Cells[2].Value = list[i].Party_name_urd;
            }
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            if (cbRegistryType.SelectedIndex != 0)
            {
                grdPartyType.AllowUserToAddRows = false;
                if (isException == false)
                {
                    grdPartyType.Rows.Add();
                    isException = true;
                }
                grdPartyType.Focus();
                grdPartyType.CurrentCell = grdPartyType.Rows[this.grdPartyType.Rows.Count - 1].Cells[2];
                SendKeys.Send("{F2}");
            }
            else
            {
                lblStatus.Text = "Please select Party Type";
            }
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            DataGridViewRow R = grdPartyType.Rows[grdPartyType.SelectedCells[0].RowIndex];
            if (R.Cells[0].Value == null) return;

            var result = MessageBox.Show("Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (this.grdPartyType.SelectedCells.Count > 0 )
                {
                    ePartyType oePartyType = new ePartyType();                    
                    updatedNewEntryInfo info = new updatedNewEntryInfo();
                    oePartyType.Party_type_id = (Guid)R.Cells[0].Value;
                    bPartyType obj = new bPartyType();
                    
                    info = obj.deletePartyType(oePartyType);
                    if (info.Success)
                    {
                        lblStatus.Text = "Record Deleted Successfully.";
                        this.grdPartyType.Rows.RemoveAt(this.grdPartyType.SelectedCells[0].RowIndex);
                        isException = false;
                    }
                    else
                    {
                        if (info.Exception.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                        {
                            lblStatus.Text = "record not deleted, associated";
                            isException = true;
                        }
                        else
                        {
                            lblStatus.Text = "record not deleted, " + info.Exception;
                            isException = true;
                        }

                    }
                }
            }
        }

        private void cbRegistryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRegistryType.SelectedIndex != 0)
            {
                Guid RegistryTypeId = (Guid)cbRegistryType.SelectedValue;
                if (RegistryTypeId != null && RegistryTypeId != new Guid())
                {
                    FillGrid(RegistryTypeId);
                }
            }
            else
            {
                grdPartyType.DataSource = null;
                grdPartyType.Rows.Clear();
            }
        }

        private void PartyTypeForm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void grdPartyType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((ComboBox)sender).SelectedValue = (Guid)((ComboBox)sender).SelectedItem;
        }

        private void PartyTypeForm_Load(object sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;
        }

        private void grdPartyType_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            lblStatus.Text = string.Empty;
            string headerText = grdPartyType.Columns[e.ColumnIndex].HeaderText;
            string PartyTypeName_eng = grdPartyType[1, e.RowIndex].EditedFormattedValue.ToString();
            string PartyTypeName_urd = grdPartyType[2, e.RowIndex].EditedFormattedValue.ToString();
            try
            {
                if (grdPartyType.IsCurrentRowDirty)
                {

                    if (string.IsNullOrEmpty(PartyTypeName_eng))
                    {
                        grdPartyType.Rows[e.RowIndex].ErrorText = "Party Name must not be empty";
                        lblStatus.Text = "Party Name must not be empty";
                        grdPartyType.CurrentCell = grdPartyType.Rows[e.RowIndex].Cells[1];
                        isException = true;
                        //e.Cancel = true;
                        return;
                    }

                    if (string.IsNullOrEmpty(PartyTypeName_urd))
                    {
                        grdPartyType.Rows[e.RowIndex].ErrorText = "Party Name must not be empty";
                        grdPartyType.CurrentCell = grdPartyType.Rows[e.RowIndex].Cells[2];
                        lblStatus.Text = "Party Name must not be empty";
                        isException = true;
                        //e.Cancel = true;
                        return;
                    }
                    string PartyTypeId = grdPartyType[0, e.RowIndex].EditedFormattedValue.ToString();
                    if (PartyTypeId == string.Empty)
                    {
                        DataGridViewRow R = grdPartyType.Rows[e.RowIndex];
                        R.Cells[0].Value = Guid.NewGuid();
                        
                        ePartyType oePartyType = new ePartyType();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        oePartyType.Registry_type_id = (Guid)cbRegistryType.SelectedValue;
                        oePartyType.Party_type_id = (Guid)R.Cells[0].Value;
                        oePartyType.Party_name_eng = (string)R.Cells[1].Value;
                        oePartyType.Party_name_urd = (string)R.Cells[2].Value;
                        oePartyType.Access_date_time = DateTime.Now;
                        
                        bPartyType obj = new bPartyType();
                        info = obj.insertPartyType(oePartyType);
                        if (info.Success)
                        {
                            lblStatus.Text = "Record Added Successfully.";
                            isException = false;
                        }
                        else
                        {

                            if (info.Exception.Contains("duplicate key"))
                            {
                                lblStatus.Text = "record already exists;";
                                isException = true;
                            }
                            else
                            {
                                lblStatus.Text = "record not inserted, " + info.Exception;
                                isException = true;
                            }
                        }
                    }
                    else
                    {
                        DataGridViewRow R = grdPartyType.Rows[e.RowIndex];
                        ePartyType oePartyType = new ePartyType();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        oePartyType.Registry_type_id = (Guid)cbRegistryType.SelectedValue;
                        oePartyType.Party_type_id = (Guid)R.Cells[0].Value;
                        oePartyType.Party_name_eng = (string)R.Cells[1].Value;
                        oePartyType.Party_name_urd = (string)R.Cells[2].Value;
                        oePartyType.Access_date_time = DateTime.Now;

                        
                        bPartyType obj = new bPartyType();
                        info = obj.udpatePartyType(oePartyType);
                        if (info.Success)
                        {
                            lblStatus.Text = "Record Updated Successfully.";
                            isException = false;
                        }
                        else
                        {

                            if (info.Exception.Contains("duplicate key"))
                            {
                                lblStatus.Text = "record already exists;";
                                isException = true;
                            }
                            else
                            {
                                lblStatus.Text = "record not updated, " + info.Exception;
                                isException = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception caught : " + ex.Message.ToString());
            }
            finally
            {

            }
        }
    }
}
