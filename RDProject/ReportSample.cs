using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System.Data.Common;
using System.Configuration;

namespace RDProject
{
    public partial class ReportSample : Form
    {
        public Guid registryId = Guid.Empty;
        public ReportSample()
        {
            InitializeComponent();
        }
        ConnectionInfo oConnectionInfo = new ConnectionInfo();

        private void ReportSample_Load(object sender, EventArgs e)
        {
            ReportDocument RptDocument = new ReportDocument();
            RptDocument.Load(Application.StartupPath + "//Reports//rdParties.rpt");
            TableLogOnInfo oTableLogOnInfo = new TableLogOnInfo();
            DbConnectionStringBuilder connectionBuilder = new DbConnectionStringBuilder();
            connectionBuilder.ConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            oConnectionInfo.ServerName = connectionBuilder["Data Source"].ToString();
            oConnectionInfo.DatabaseName = connectionBuilder["initial catalog"].ToString();
            oConnectionInfo.UserID = connectionBuilder["user id"].ToString();
            oConnectionInfo.Password = connectionBuilder["password"].ToString();
            oConnectionInfo.Type = ConnectionInfoType.SQL;


            foreach (CrystalDecisions.CrystalReports.Engine.Table oTable in RptDocument.Database.Tables)
            {
                oTableLogOnInfo = oTable.LogOnInfo;
                oTableLogOnInfo.ConnectionInfo = oConnectionInfo;
                oTable.ApplyLogOnInfo(oTableLogOnInfo);
            }


            ParameterFieldDefinitions crParamFieldDefinitions = RptDocument.DataDefinition.ParameterFields;
            foreach (ParameterFieldDefinition def in crParamFieldDefinitions)
            {

                if (def.ReportName == "")
                {
                    if (def.ParameterFieldName == "@Registry_id")
                    {
                        ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                        ParameterValues crCurrentValues = def.CurrentValues;

                        if (registryId != Guid.Empty)
                        {
                            Guid RegistryId = registryId;
                            crParamDiscreteValue.Value = "{" + RegistryId + "}";
                            crCurrentValues.Add(crParamDiscreteValue);
                            def.ApplyCurrentValues(crCurrentValues);
                        }
                        else
                        {
                            
                        }
                    }
                   
                }
            }
            crystalReportViewer1.ReportSource = RptDocument;
        }
    }
}
