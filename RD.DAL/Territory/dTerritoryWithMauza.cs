using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dTerritoryWithMauza : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;

        public dTerritoryWithMauza()
        {
        }

        public override void InitializeAccessors()
        {

        }

        public List<eTerritoryWithMauza> getTerritoryWithMauza(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = "territory.proc_GetMauza";
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eTerritoryWithMauza> oeListTerritoryWithMauza = new List<eTerritoryWithMauza>();

            while (oDReader.Read())
            {
                eTerritoryWithMauza oeTerritoryWithMauza = new eTerritoryWithMauza();
                oeTerritoryWithMauza.District_id = ValidateFields.GetSafeGuid(oDReader["district_id"].ToString());
                oeTerritoryWithMauza.District_name_eng = ValidateFields.GetSafeString(oDReader["district_name_eng"].ToString());
                oeTerritoryWithMauza.District_name_urd = ValidateFields.GetSafeString(oDReader["district_name_urd"].ToString());
                oeTerritoryWithMauza.Tehsil_id = ValidateFields.GetSafeGuid(oDReader["tehsil_id"].ToString());
                oeTerritoryWithMauza.Tehsil_name_eng = ValidateFields.GetSafeString(oDReader["tehsil_name_eng"].ToString());
                oeTerritoryWithMauza.Tehsil_name_urd = ValidateFields.GetSafeString(oDReader["tehsil_name_urd"].ToString());                
                oeTerritoryWithMauza.Mauza_id = ValidateFields.GetSafeGuid(oDReader["mauza_id"].ToString());
                oeTerritoryWithMauza.Mauza_name_eng = ValidateFields.GetSafeString(oDReader["mauza_name_eng"].ToString());
                oeTerritoryWithMauza.Mauza_name_urd = ValidateFields.GetSafeString(oDReader["mauza_name_urd"].ToString());                
                oeTerritoryWithMauza.Had_bust_no = ValidateFields.GetSafeInteger(oDReader["had_bust_no"].ToString());
                oeTerritoryWithMauza.Feet_per_marla = ValidateFields.GetSafeInteger(oDReader["feet_per_marla"].ToString());
                oeTerritoryWithMauza.Preparation_year = ValidateFields.GetSafeInteger(oDReader["preparation_year"].ToString());
                oeTerritoryWithMauza.Is_mauza_sikni = ValidateFields.GetSafeBoolean(oDReader["is_mauza_sikni"].ToString());
                oeTerritoryWithMauza.Is_marla_calculation_unit = ValidateFields.GetSafeBoolean(oDReader["is_marla_calculation_unit"].ToString());
                oeTerritoryWithMauza.Area_format = ValidateFields.GetSafeInteger(oDReader["area_format"].ToString());
                oeTerritoryWithMauza.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeTerritoryWithMauza.Access_date_time = ValidateFields.GetSafeDateTime(oDReader["access_date_time"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oeTerritoryWithMauza.Time_stamp = data;

                oeListTerritoryWithMauza.Add(oeTerritoryWithMauza);
            }
            totalRecord = oeListTerritoryWithMauza.Count;

            return oeListTerritoryWithMauza;
        }

        public List<eTerritoryWithMauza> getTerritoryWithMauzaTown(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = "[territory].[proc_GetTerritoryWithTown]";
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eTerritoryWithMauza> oeListTerritoryWithMauza = new List<eTerritoryWithMauza>();

            while (oDReader.Read())
            {
                eTerritoryWithMauza oeTerritoryWithMauza = new eTerritoryWithMauza();

                oeTerritoryWithMauza.Town_id = ValidateFields.GetSafeGuid(oDReader["town_id"].ToString());
                oeTerritoryWithMauza.Town_name_eng = ValidateFields.GetSafeString(oDReader["town_name_eng"].ToString());
                oeTerritoryWithMauza.Town_name_urd = ValidateFields.GetSafeString(oDReader["town_name_urd"].ToString());
                oeTerritoryWithMauza.District_id = ValidateFields.GetSafeGuid(oDReader["district_id"].ToString());
                oeTerritoryWithMauza.District_name_eng = ValidateFields.GetSafeString(oDReader["district_name_eng"].ToString());
                oeTerritoryWithMauza.District_name_urd = ValidateFields.GetSafeString(oDReader["district_name_urd"].ToString());
                oeTerritoryWithMauza.Tehsil_id = ValidateFields.GetSafeGuid(oDReader["tehsil_id"].ToString());
                oeTerritoryWithMauza.Tehsil_name_eng = ValidateFields.GetSafeString(oDReader["tehsil_name_eng"].ToString());
                oeTerritoryWithMauza.Tehsil_name_urd = ValidateFields.GetSafeString(oDReader["tehsil_name_urd"].ToString());
                oeTerritoryWithMauza.Mauza_id = ValidateFields.GetSafeGuid(oDReader["mauza_id"].ToString());
                oeTerritoryWithMauza.Mauza_name_eng = ValidateFields.GetSafeString(oDReader["mauza_name_eng"].ToString());
                oeTerritoryWithMauza.Mauza_name_urd = ValidateFields.GetSafeString(oDReader["mauza_name_urd"].ToString());
                oeTerritoryWithMauza.Had_bust_no = ValidateFields.GetSafeInteger(oDReader["had_bust_no"].ToString());
                oeTerritoryWithMauza.Feet_per_marla = ValidateFields.GetSafeInteger(oDReader["feet_per_marla"].ToString());
                oeTerritoryWithMauza.Preparation_year = ValidateFields.GetSafeInteger(oDReader["preparation_year"].ToString());
                oeTerritoryWithMauza.Is_mauza_sikni = ValidateFields.GetSafeBoolean(oDReader["is_mauza_sikni"].ToString());
                oeTerritoryWithMauza.Is_marla_calculation_unit = ValidateFields.GetSafeBoolean(oDReader["is_marla_calculation_unit"].ToString());
                oeTerritoryWithMauza.Area_format = ValidateFields.GetSafeInteger(oDReader["area_format"].ToString());
                oeTerritoryWithMauza.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeTerritoryWithMauza.Access_date_time = ValidateFields.GetSafeDateTime(oDReader["access_date_time"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oeTerritoryWithMauza.Time_stamp = data;

                oeListTerritoryWithMauza.Add(oeTerritoryWithMauza);
            }
            totalRecord = oeListTerritoryWithMauza.Count;

            return oeListTerritoryWithMauza;
        }
    }
}
