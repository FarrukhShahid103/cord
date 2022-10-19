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
    public partial class Plot_English : Form
    {
        bPlot obPlot = new bPlot();
        ePlot oePlot = new ePlot();
        updatedNewEntryInfo EntityStatus = null;
        DataGridViewRow PlotRow = null;
        DataGridViewTextBoxCell PlotCell = null;
        
        List<ePlot> oeListPlots = null;


        public Guid RegistryId { get; set; }
        public DataGridViewRow UpdatePlotRow { get; set; }
        
        private void Plot_English_Load(object sender, EventArgs e)
        {
            GetAllPlotsByRegisty();
        }
        public Plot_English()
        {
            InitializeComponent();
        }
        private void UpdatePlot()
        {
            if (UpdatePlotRow != null)
            {
                grdPlot.Rows[UpdatePlotRow.Index].Cells["PlotNoCol"].Value = txtPlotNo.Text;
                grdPlot.Rows[UpdatePlotRow.Index].Cells["EastCol"].Value = txtEast.Text;
                grdPlot.Rows[UpdatePlotRow.Index].Cells["WestCol"].Value = txtWest.Text;
                grdPlot.Rows[UpdatePlotRow.Index].Cells["NorthCol"].Value = txtNorth.Text;
                grdPlot.Rows[UpdatePlotRow.Index].Cells["SouthCol"].Value = txtSouth.Text;
                grdPlot.Rows[UpdatePlotRow.Index].Cells["KhasraNoCol"].Value = txtKhasraNo.Text;
            }
        }
        private void GetAllPlotsByRegisty()
        {
            try
            {
                oePlot.Registry_Id = RegistryId;
                oeListPlots = obPlot.GetPlotsByRegistyId(oePlot);
                if (oeListPlots != null && oeListPlots.Count > 0)
                {
                    CreatePlotCellsWithBinding(oeListPlots, oePlot);
                }
            }
            catch (Exception)
            {

                lblMsg.Text = "Some Problem Occured While Loading Plots";
            }
        }
        private void FillControlsWithPlotDetail(DataGridViewRow PlotRowDetail)
        {
            if (UpdatePlotRow != null)
            {
                lblHiddenPlotId.Text = PlotRowDetail.Cells[0].Value.ToString();
                txtPlotNo.Text = PlotRowDetail.Cells[1].Value.ToString();
                txtEast.Text = PlotRowDetail.Cells[2].Value.ToString();
                txtWest.Text = PlotRowDetail.Cells[3].Value.ToString();
                txtSouth.Text = PlotRowDetail.Cells[4].Value.ToString();
                txtNorth.Text = PlotRowDetail.Cells[5].Value.ToString();
                txtKhasraNo.Text = PlotRowDetail.Cells[6].Value.ToString();
            }
        }
        private void CreatePlotCellsWithBinding(List<ePlot> oePlotsList, ePlot oePlot)
        {
            if (oePlotsList != null && oePlotsList.Count > 0)
            {
                for (int i = 0; i < oePlotsList.Count; i++)
                {
                    PlotRow = new DataGridViewRow();

                    PlotCell = new DataGridViewTextBoxCell();
                    PlotCell.Value = oePlotsList[i].Plot_Id;
                    PlotRow.Cells.Add(PlotCell);


                    PlotCell = new DataGridViewTextBoxCell();
                    PlotCell.Value = oePlotsList[i].PlotNo;
                    PlotRow.Cells.Add(PlotCell);


                    PlotCell = new DataGridViewTextBoxCell();
                    PlotCell.Value = oePlotsList[i].North;
                    PlotRow.Cells.Add(PlotCell);


                    PlotCell = new DataGridViewTextBoxCell();
                    PlotCell.Value = oePlotsList[i].East;
                    PlotRow.Cells.Add(PlotCell);


                    PlotCell = new DataGridViewTextBoxCell();
                    PlotCell.Value = oePlotsList[i].West;
                    PlotRow.Cells.Add(PlotCell);


                    PlotCell = new DataGridViewTextBoxCell();
                    PlotCell.Value = oePlotsList[i].South;
                    PlotRow.Cells.Add(PlotCell);


                    PlotCell = new DataGridViewTextBoxCell();
                    PlotCell.Value = oePlotsList[i].KhasraNo;
                    PlotRow.Cells.Add(PlotCell);

                    grdPlot.Rows.Add(PlotRow);
                }                
            }
            else
            {
                PlotRow = new DataGridViewRow();

                PlotCell = new DataGridViewTextBoxCell();
                PlotCell.Value = oePlot.Plot_Id;
                PlotRow.Cells.Add(PlotCell);


                PlotCell = new DataGridViewTextBoxCell();
                PlotCell.Value = oePlot.PlotNo;
                PlotRow.Cells.Add(PlotCell);


                PlotCell = new DataGridViewTextBoxCell();
                PlotCell.Value = oePlot.North;
                PlotRow.Cells.Add(PlotCell);


                PlotCell = new DataGridViewTextBoxCell();
                PlotCell.Value = oePlot.East;
                PlotRow.Cells.Add(PlotCell);


                PlotCell = new DataGridViewTextBoxCell();
                PlotCell.Value = oePlot.West;
                PlotRow.Cells.Add(PlotCell);


                PlotCell = new DataGridViewTextBoxCell();
                PlotCell.Value = oePlot.South;
                PlotRow.Cells.Add(PlotCell);


                PlotCell = new DataGridViewTextBoxCell();
                PlotCell.Value = oePlot.KhasraNo;
                PlotRow.Cells.Add(PlotCell);

                grdPlot.Rows.Add(PlotRow);
            }
            oePlotsList = null;
            oeListPlots = null;
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtPlotNo.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtEast.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtWest.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtSouth.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(txtNorth.Text))
            {
                return false;
            }
            //if (!string.IsNullOrEmpty(txtk.Text))
            //{
            //    return false;
            //}

            return true;

        }
        private void ClearFields()
        {
            txtKhasraNo.Text = string.Empty;
            txtPlotNo.Text = string.Empty;
            txtEast.Text = string.Empty;
            txtWest.Text = string.Empty;
            txtSouth.Text = string.Empty;
            txtNorth.Text = string.Empty;
            lblHiddenPlotId.Text = string.Empty;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                 if(string.IsNullOrEmpty(lblHiddenPlotId.Text)) //Insert Here....
                 {
                    oePlot.PlotNo = txtPlotNo.Text;
                    oePlot.Registry_Id = RegistryId;
                    oePlot.East = txtEast.Text;
                    oePlot.West = txtWest.Text;
                    oePlot.South = txtSouth.Text;
                    oePlot.North = txtNorth.Text;
                    oePlot.KhasraNo = txtKhasraNo.Text;
                    EntityStatus = obPlot.InsertPlot(oePlot);
                    if(EntityStatus.Success)
                    {
                        lblMsg.Text = "Plot Saved Successfully";
                        ClearFields();
                        CreatePlotCellsWithBinding(oeListPlots, oePlot);
                    }

                 }
                 else // Update Here...
                 {
                     oePlot.Plot_Id = new Guid(lblHiddenPlotId.Text);
                     oePlot.PlotNo = txtPlotNo.Text;
                     oePlot.East = txtEast.Text;
                     oePlot.West = txtWest.Text;
                     oePlot.South = txtSouth.Text;
                     oePlot.North = txtNorth.Text;
                     oePlot.KhasraNo = txtKhasraNo.Text;
                     EntityStatus = obPlot.UPdatePlot(oePlot);
                     if (EntityStatus.Success)
                     {
                         lblMsg.Text = "Plot Updated Successfully";
                         UpdatePlot();
                         ClearFields();
                     }
                  }
               }
                else
                {
                    lblMsg.Text = "Please Fill The Fields To Save Plot...";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Some Problem Occured While Saving...";
                ex.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblHiddenPlotId.Text))
            {
                oePlot.Plot_Id = new Guid(lblHiddenPlotId.Text);                
                EntityStatus = obPlot.DeletePlot(oePlot);
                try
                {
                    if (EntityStatus.Success)
                    {
                        lblMsg.Text = "Plot Deleted Successfully...";
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Some Problem Occured while Deleting Plot...";
                }
            }
            else
            {
                lblMsg.Text = "Plot Not Selected To Delete...";
            }
        }

        private void grdPlot_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdatePlotRow = grdPlot.Rows[e.RowIndex];
            FillControlsWithPlotDetail(UpdatePlotRow);
        }
      
        private void Plot_English_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Escape)
            //{
            //    ClearFields();
            //   // grdPlot.Rows.Clear();
            //}
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
