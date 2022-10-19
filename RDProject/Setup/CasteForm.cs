using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RD.EL.Setup;
using RD.BLL.Setup;
using RD.BLL;
using RD.EL;

namespace RDProject.Setup
{
    public partial class CastForm : Form
    {
        private bool isException;
        public CastForm()
        {
            InitializeComponent();
            lblStatus.Text = string.Empty;
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            grdCaste.AllowUserToAddRows = false;
            if (isException == false)
            {
                grdCaste.Rows.Add();
                isException = true;
            }
            grdCaste.Focus();
            grdCaste.CurrentCell = grdCaste.Rows[this.grdCaste.Rows.Count - 1].Cells[2];
            SendKeys.Send("{F2}");

        }

        private void FillGrid()
        {
            grdCaste.AutoGenerateColumns = false;
            grdCaste.AllowUserToAddRows = false;

            bCaste manager = new bCaste();
            eCaste oelCaste = new eCaste();

            List<eCaste> list = manager.getCaste(oelCaste, "", "", 1, 100);
            grdCaste.Rows.Add(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                grdCaste.Rows[i].Cells[0].Value = list[i].Caste_id;
                grdCaste.Rows[i].Cells[1].Value = list[i].Caste_name_eng;
                grdCaste.Rows[i].Cells[2].Value = list[i].Caste_name_urd;
            }
        }

        private void CastForm_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if (grdCaste.Rows.Count > 0)
            {
                var result = MessageBox.Show("Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (this.grdCaste.SelectedCells.Count > 0)
                    {
                        eCaste oelCaste = new eCaste();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        DataGridViewRow R = grdCaste.Rows[grdCaste.SelectedCells[0].RowIndex];
                        if (R.Cells[0].Value == null)
                        {
                            return;
                        }
                        oelCaste.Caste_id = (Guid)R.Cells[0].Value;
                        bCaste obj = new bCaste();
                        info = obj.deleteCaste(oelCaste);
                        if (info.Success)
                        {
                            lblStatus.Text = "Record Deleted Successfully.";
                            this.grdCaste.Rows.RemoveAt(this.grdCaste.SelectedCells[0].RowIndex);
                            isException = false;
                        }
                        else
                        {
                            if (info.Exception.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                            {
                                lblStatus.Text = "record not deleted, associated caste";
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
        }

        private void CastForm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void grdCaste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void grdCaste_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            lblStatus.Text = string.Empty;
            string headerText = grdCaste.Columns[e.ColumnIndex].HeaderText;
            string CasteName_eng = grdCaste[1, e.RowIndex].EditedFormattedValue.ToString();
            string CasteName_urd = grdCaste[2, e.RowIndex].EditedFormattedValue.ToString();
            try
            {
                if (grdCaste.IsCurrentRowDirty)
                {

                    if (string.IsNullOrEmpty(CasteName_eng))
                    {
                        grdCaste.Rows[e.RowIndex].ErrorText = "Caste Name must not be empty";
                        lblStatus.Text = "Caste Name must not be empty";
                        grdCaste.CurrentCell = grdCaste.Rows[e.RowIndex].Cells[1];

                        //e.Cancel = true;
                        return;
                    }

                    if (string.IsNullOrEmpty(CasteName_urd))
                    {
                        grdCaste.Rows[e.RowIndex].ErrorText = "Caste Name must not be empty";
                        grdCaste.CurrentCell = grdCaste.Rows[e.RowIndex].Cells[2];
                        lblStatus.Text = "Caste Name must not be empty";
                        //e.Cancel = true;
                        return;
                    }
                    string CasteId = grdCaste[0, e.RowIndex].EditedFormattedValue.ToString();
                    if (CasteId == string.Empty)
                    {
                        DataGridViewRow R = grdCaste.Rows[e.RowIndex];
                        R.Cells[0].Value = Guid.NewGuid();


                        
                        eCaste oelCaste = new eCaste();
                        updatedNewEntryInfo info = new updatedNewEntryInfo();
                        oelCaste.Caste_id = (Guid)R.Cells[0].Value;
                        oelCaste.User_id = Variables.UserId;
                        oelCaste.Access_date_time = DateTime.Now;
                        oelCaste.Caste_name_eng = (string)R.Cells[1].Value;
                        oelCaste.Caste_name_urd = (string)R.Cells[2].Value;

                        bCaste obj = new bCaste();

                        info = obj.insertCaste(oelCaste);
                        if (info.Success)
                        {
                            lblStatus.Text = "Record Added Successfully.";
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
                        DataGridViewRow R = grdCaste.Rows[e.RowIndex];
                        eCaste oelCaste = new eCaste();                        
                        updatedNewEntryInfo info = new updatedNewEntryInfo();

                        oelCaste.Caste_id = (Guid)R.Cells[0].Value;
                        oelCaste.User_id = Variables.UserId;
                        oelCaste.Access_date_time = DateTime.Now;
                        oelCaste.Caste_name_eng = (string)R.Cells[1].Value;
                        oelCaste.Caste_name_urd = (string)R.Cells[2].Value;


                        
                        bCaste obj = new bCaste();
                        info = obj.udpateCaste(oelCaste);
                        if (info.Success)
                        {
                            lblStatus.Text = "Record Updated Successfully.";
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

                //lblStatus.Text = string.Empty;
            }


        }


    }
}
