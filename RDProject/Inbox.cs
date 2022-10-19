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


namespace RDProject
{
    public partial class Inbox : Telerik.WinControls.UI.ShapedForm
    {
        public Inbox()
        {
            InitializeComponent();

            LoadRegistries();
        }


        private void LoadRegistries()
        {
            Database db = DatabaseFactory.CreateDatabase("ConnStr");
            try
            {
                string sql = "select reg_status, remarks, registry_decision_date, registry_no, ISNULL(registery_stage, 0) AS registery_stage  from rd.RegistryOperations where registery_stage = @RegistryStage";
                DbCommand cmd = db.GetSqlStringCommand(sql);
                if (Variables.Role == (int)Variables.Roles.SRO)
                    db.AddInParameter(cmd, "@RegistryStage", DbType.Int16, 1);
                if (Variables.Role == (int)Variables.Roles.SCO)
                    db.AddInParameter(cmd, "@RegistryStage", DbType.Int16, 2);
                DataSet ds = db.ExecuteDataSet(cmd);
                grdPerson.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void Inbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        private void grdPerson_CommandCellClick(object sender, EventArgs e)
        {
            Variables.load = "0";
            GridCommandCellElement gCommand = (sender as GridCommandCellElement);
            if (gCommand.ColumnIndex == 3)
            {
                Variables.load = "1";             
                RDBasicInfoForm obj = new RDBasicInfoForm();
                Variables.registryNo = grdPerson.SelectedRows[0].Cells[1].Value.ToString();                
                obj.txtRegistryNo_Leave(sender, e);
                obj.isLoading = true;
                obj.Show();
            }

        }

        private void Inbox_Load(object sender, EventArgs e)
        {
            if (Variables.Role == (int)Variables.Roles.SRO)
                grdPerson.Columns[5].IsVisible = false;
            else
                grdPerson.Columns[5].IsVisible = true;

        }

        
    }
}
