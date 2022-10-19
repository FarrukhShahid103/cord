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

namespace RDProject.RD
{
    public partial class Person_English : Form
    {
        public Guid Registry_ID;
        public int Registry_No;
        private bool NewRecord;

        public Person_English()
        {
            InitializeComponent();
            fillColumnPersonGrid();
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

        protected void SetDefaultValues()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtCNIC.Clear();
            cbBuyerSeller.SelectedIndex = 0;
            chkBlock.Checked = false;
            chkDepartment.Checked = false;
            chkGovt.Checked = false;
            FillCaste();
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnSave.Text = "&Save";
            NewRecord = true;
            BindPersonGrid();
        }

        private void FillCaste()
        {
            eCaste oeCaste = new eCaste();
            bCaste obCaste = new bCaste();
            List<eCaste> oeListCaste = new List<eCaste>();
            oeListCaste = obCaste.getCaste(oeCaste, "", "", 0, int.MaxValue);
            AddItem(oeListCaste, typeof(eCaste), "Caste_id", "Caste_name_eng", "< - SELECT - >");
            if (oeListCaste != null && oeListCaste.Count > 0)
            {
                cbCaste.ValueMember = "Caste_id";
                cbCaste.DisplayMember = "Caste_name_eng";
                cbCaste.DataSource = oeListCaste;
            }
        }

        private void Person_English_Load(object sender, EventArgs e)
        {
            SetDefaultValues();
        }

        private void fillColumnPersonGrid()
        {
            DataGridViewTextBoxColumn dgvPersonId = new DataGridViewTextBoxColumn();
            dgvPersonId.Name = "colPersonId";
            dgvPersonId.Visible = false;
            grdPersons.Columns.Add(dgvPersonId);

            DataGridViewTextBoxColumn dgvPersonFN = new DataGridViewTextBoxColumn();
            dgvPersonFN.Name = "colPersonFN";
            dgvPersonFN.Visible = false;
            grdPersons.Columns.Add(dgvPersonFN);
        }

        private void BindPersonGrid()
        {
            if (grdPersons.Rows.Count > 0)
            {
                grdPersons.Rows.Clear();
            }
        }
    }
}
