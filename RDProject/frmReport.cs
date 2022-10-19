using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.Common;
using System.Configuration;
using RD.EL;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace RDProject
{
    public partial class frmReport : Form
    {
        public int docNo;
        public Guid mauzaId;
        public Guid FardGuidId;

       

        ConnectionInfo oConnectionInfo = new ConnectionInfo();

        public frmReport()
        {
            InitializeComponent();
        }

        public Guid FardId()
        {

            List<eFard> list = new List<eFard>();
            //mauzaId = new Guid("67465637-403D-4023-BDB6-8803FFE7F02B");
            //docNo = 6;
            if (mauzaId != Guid.Empty && mauzaId != null)
            {
                list = GetFardFromLrmis(mauzaId, docNo);
                if (list != null && list.Count > 0)
                {
                    FardGuidId = list[0].Fard_id;
                }
            }
            return FardGuidId;
        }

        public List<eFard> GetFardFromLrmis(Guid mauzaId, int docNo)
        {
            List<eFard> oeListFard = new List<eFard>();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["lrmis"].ConnectionString.ToString();
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    Guid MauzaId = mauzaId;
                    int DocNo = docNo;
                    conn.Open();
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("fard.proc_GetFard_New", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sort_expression", "");
                        cmd.Parameters.AddWithValue("@condition", " where document_id='" + docNo + "' and mauza_id = '" + mauzaId + "'");
                        cmd.Parameters.AddWithValue("@start_row_index", 0);
                        cmd.Parameters.AddWithValue("@page_size", 10);
                        cmd.Parameters.AddWithValue("@total_records", 10);

                        SqlDataReader Reader = cmd.ExecuteReader();
                        while (Reader.Read())
                        {
                            eFard oeFard = new eFard();
                            oeFard.Fard_id = ValidateFields.GetSafeGuid(Reader["fard_id"].ToString());
                            oeListFard.Add(oeFard);
                        }
                    }
                    conn.Close();
                }


                return oeListFard;
            }

            catch (System.Data.SqlClient.SqlException ex)
            {

            }
            return oeListFard;
        }
        private string FardType()
        {
            string strFardType=string.Empty;
            int countKhasra;
            int countKhewat;
            //int countKhatuni;
            int countPerson;
            try
            {
                countKhasra = GetFardKhasraCountByFardId(FardGuidId);
                countPerson = GetFardPersonCountByFardId(FardGuidId);
                if (countKhasra > 0)
                    strFardType = "FardKhasra";
                else
                {
                    if (countPerson == 0 && countKhasra == 0)
                    {
                        countKhewat = GetFardKhewatsByFardId(FardGuidId);
                        if (countKhewat > 0)
                            strFardType = "FardKhewat";
                    }
                    else if (countPerson > 0 && countKhasra == 0)
                    {
                        strFardType = "FardPerson";
                    }
                    else 
                    {
                        strFardType = "FardKhasra";
                    }
                }

                return strFardType;
            }

            catch (Exception ex)
            {

                return "";
            }
        }
        public static Int32 GetFardKhasraCountByFardId(Guid fardId)
        {
            Int32 Count = 0;
            try
            {
                
                string connectionString = ConfigurationManager.ConnectionStrings["lrmis"].ConnectionString.ToString();
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conn.Open();
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("[fard].[proc_GetCountFardKhasraByFardID]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fard_id", fardId);
                        Count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    conn.Close();
                }

                
                //return oeListFard;
            }

            catch (System.Data.SqlClient.SqlException ex)
            {

            }
            return Count;
        }
        public static Int32 GetFardPersonCountByFardId(Guid fardId)
        {

            Int32 Count = 0;
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["lrmis"].ConnectionString.ToString();
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conn.Open();
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("[fard].[proc_GetFardPersonsByFardId]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fard_id", fardId);
                        
                        SqlDataReader Reader = cmd.ExecuteReader();
                        while (Reader.Read())
                        {
                            //eFard oeFard = new eFard();
                            //oeFard.Fard_id = ValidateFields.GetSafeGuid(Reader["fard_id"].ToString());
                            Count++;
                        }
                    }
                    conn.Close();
                }


               
            }

            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return Count;
        }

        public static Int32 GetFardKhewatsByFardId(Guid fardId)
        {

            Int32 Count = 0;
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["lrmis"].ConnectionString.ToString();
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conn.Open();
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("[fard].[proc_GetFardKhewats]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sort_expression", "");
                        cmd.Parameters.AddWithValue("@condition", " where fard_id = '" + fardId + "'");
                        cmd.Parameters.AddWithValue("@start_row_index", 0);
                        cmd.Parameters.AddWithValue("@page_size", 10);
                        cmd.Parameters.AddWithValue("@total_records", 10);
                        

                        SqlDataReader Reader = cmd.ExecuteReader();
                        while (Reader.Read())
                        {
                            Count++;
                        }
                    }
                    conn.Close();
                }


                
            }

            catch (System.Data.SqlClient.SqlException ex)
            {

            }
            return Count;
        }
        public static Int32 GetKhatuniCountbyFardId(Guid fardId, bool isUpdated)
        {

            Int32 Count = 0;
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["lrmis"].ConnectionString.ToString();
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString))
                {
                    conn.Open();
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("[fard].[proc_GetCountKhatunibyFardId]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@fard_id", fardId);
                        cmd.Parameters.AddWithValue("@updated", isUpdated);
                        Count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    conn.Close();
                }

            }

            catch (System.Data.SqlClient.SqlException ex)
            {

            }

            return Count;
           

        }
        private void frmReport_Load(object sender, EventArgs e)
        {
            FardId();
            if (FardGuidId != Guid.Empty && FardGuidId != null)
            {
                ReportDocument report = new ReportDocument();

                string rptType = FardType();
                if (!(string.IsNullOrEmpty(rptType)))
                    report.Load(Application.StartupPath + "/Reports/" + rptType + ".rpt");
                else
                    return;
                //show here that the fard has no type 


               
                
                TableLogOnInfo oTableLogOnInfo = new TableLogOnInfo();
                DbConnectionStringBuilder connectionBuilder = new DbConnectionStringBuilder();
                connectionBuilder.ConnectionString = ConfigurationManager.ConnectionStrings["lrmis"].ConnectionString;
                oConnectionInfo.ServerName = connectionBuilder["Data Source"].ToString();
                oConnectionInfo.DatabaseName = connectionBuilder["initial catalog"].ToString();
                oConnectionInfo.UserID = connectionBuilder["user id"].ToString();
                oConnectionInfo.Password = connectionBuilder["password"].ToString();
                oConnectionInfo.Type = ConnectionInfoType.SQL;

                
                foreach (CrystalDecisions.CrystalReports.Engine.Table oTable in report.Database.Tables)
                {
                    oTableLogOnInfo = oTable.LogOnInfo;
                    oTableLogOnInfo.ConnectionInfo = oConnectionInfo;
                    oTable.ApplyLogOnInfo(oTableLogOnInfo);
                }


                ParameterFieldDefinitions crParamFieldDefinitions = report.DataDefinition.ParameterFields;
                foreach (ParameterFieldDefinition def in crParamFieldDefinitions)
                {

                    if (def.ReportName == "")
                    {
                        if (def.ParameterFieldName == "fard_id")
                        {
                            ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                            ParameterValues crCurrentValues = def.CurrentValues;


                            Guid FardID = FardGuidId;

                            crParamDiscreteValue.Value = "{" + FardID + "}";
                            crCurrentValues.Add(crParamDiscreteValue);
                            def.ApplyCurrentValues(crCurrentValues);
                        }
                        else if (def.ParameterFieldName == "@mauza_id")
                        {
                            ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                            ParameterValues crCurrentValues = def.CurrentValues;

                            //Guid mauzaId = new Guid("20761f48-4ea4-4be9-b79d-c1fec26aa8da");
                            crParamDiscreteValue.Value = "{" + mauzaId + "}";
                            crCurrentValues.Add(crParamDiscreteValue);
                            def.ApplyCurrentValues(crCurrentValues);
                        }
                        else if (def.ParameterFieldName == "mauza_id")
                        {
                            ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                            ParameterValues crCurrentValues = def.CurrentValues;

                            //Guid mauza_id = new Guid("20761f48-4ea4-4be9-b79d-c1fec26aa8da");
                            crParamDiscreteValue.Value = "{" + mauzaId + "}";
                            crCurrentValues.Add(crParamDiscreteValue);
                            def.ApplyCurrentValues(crCurrentValues);
                        }

                        else if (def.ParameterFieldName == "@is_updated")
                        {
                            ParameterDiscreteValue crParamDiscreteValue = new ParameterDiscreteValue();
                            ParameterValues crCurrentValues = def.CurrentValues;


                            crParamDiscreteValue.Value = true;
                            crCurrentValues.Add(crParamDiscreteValue);
                            def.ApplyCurrentValues(crCurrentValues);
                        }
                    }
                }

                crystalReportViewer1.ReportSource = report;
            }
        }

        private void frmReport_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {

                this.Close();
            }

        }
    }
}
