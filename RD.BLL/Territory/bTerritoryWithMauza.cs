using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL;
using RD.EL;

namespace RD.BLL
{
    public class bTerritoryWithMauza
    {
        private static long totalRecord = -1;
        dTerritoryWithMauza odTerritoryWithMauza;
        public List<eTerritoryWithMauza> getTerritoryWithMauza(eTerritoryWithMauza oeTerritoryWithMauza, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeTerritoryWithMauza);
            odTerritoryWithMauza = new dTerritoryWithMauza();
            List<eTerritoryWithMauza> oeListTerritoryWithMauza = new List<eTerritoryWithMauza>();
            oeListTerritoryWithMauza = odTerritoryWithMauza.getTerritoryWithMauza(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListTerritoryWithMauza;
        }

        public List<eTerritoryWithMauza> getTerritoryWithMauzaTown(eTerritoryWithMauza oeTerritoryWithMauza, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeTerritoryWithMauza);
            odTerritoryWithMauza = new dTerritoryWithMauza();
            List<eTerritoryWithMauza> oeListTerritoryWithMauza = new List<eTerritoryWithMauza>();
            oeListTerritoryWithMauza = odTerritoryWithMauza.getTerritoryWithMauzaTown(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListTerritoryWithMauza;
        }

        private string BuildCondition(eTerritoryWithMauza oeTerritoryWithMauza)
        {
            string result = "";
            if (oeTerritoryWithMauza.Town_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "town_id = '" + oeTerritoryWithMauza.Town_id + "'";
            if (oeTerritoryWithMauza.Town_name_eng != String.Empty && oeTerritoryWithMauza.Town_name_eng != null)
                result += (result == "" ? "" : " AND ") + "town_name_eng = '" + oeTerritoryWithMauza.Town_name_eng + "'";
            if (oeTerritoryWithMauza.Town_name_urd != String.Empty && oeTerritoryWithMauza.Town_name_urd != null)
                result += (result == "" ? "" : " AND ") + "town_name_urd = N'" + oeTerritoryWithMauza.Town_name_urd + "'";
            if (oeTerritoryWithMauza.District_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "district_id = '" + oeTerritoryWithMauza.District_id + "'";
            if (oeTerritoryWithMauza.District_name_eng != String.Empty && oeTerritoryWithMauza.District_name_eng != null)
                result += (result == "" ? "" : " AND ") + "district_name_eng = '" + oeTerritoryWithMauza.District_name_eng + "'";
            if (oeTerritoryWithMauza.District_name_urd != String.Empty && oeTerritoryWithMauza.District_name_urd != null)
                result += (result == "" ? "" : " AND ") + "district_name_urd = N'" + oeTerritoryWithMauza.District_name_urd + "'";
            if (oeTerritoryWithMauza.Tehsil_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "tehsil_id = '" + oeTerritoryWithMauza.Tehsil_id + "'";
            if (oeTerritoryWithMauza.Tehsil_name_eng != String.Empty && oeTerritoryWithMauza.Tehsil_name_eng != null)
                result += (result == "" ? "" : " AND ") + "tehsil_name_eng = '" + oeTerritoryWithMauza.Tehsil_name_eng + "'";
            if (oeTerritoryWithMauza.Tehsil_name_urd != String.Empty && oeTerritoryWithMauza.Tehsil_name_urd != null)
                result += (result == "" ? "" : " AND ") + "tehsil_name_urd = N'" + oeTerritoryWithMauza.Tehsil_name_urd + "'";
            if (oeTerritoryWithMauza.Mauza_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "mauza_id = '" + oeTerritoryWithMauza.Mauza_id + "'";
            if (oeTerritoryWithMauza.Mauza_name_eng != String.Empty && oeTerritoryWithMauza.Mauza_name_eng != null)
                result += (result == "" ? "" : " AND ") + "mauza_name_eng = N'" + oeTerritoryWithMauza.Mauza_name_eng + "'";
            if (oeTerritoryWithMauza.Mauza_name_urd != String.Empty && oeTerritoryWithMauza.Mauza_name_urd != null)
                result += (result == "" ? "" : " AND ") + "mauza_name_urd = N'" + oeTerritoryWithMauza.Mauza_name_urd + "'";
            
            if (oeTerritoryWithMauza.Had_bust_no != 0)
                result += (result == "" ? "" : " AND ") + "had_bust_no = " + oeTerritoryWithMauza.Had_bust_no + "";
            if (oeTerritoryWithMauza.Feet_per_marla != 0)
                result += (result == "" ? "" : " AND ") + "feet_per_marla = " + oeTerritoryWithMauza.Feet_per_marla + "";
            if (oeTerritoryWithMauza.Preparation_year != 0)
                result += (result == "" ? "" : " AND ") + "preparation_year = " + oeTerritoryWithMauza.Preparation_year + "";
            if (oeTerritoryWithMauza.Is_mauza_sikni != false)
                result += (result == "" ? "" : " AND ") + "is_mauza_sikni = " + oeTerritoryWithMauza.Is_mauza_sikni + "";
            if (oeTerritoryWithMauza.Is_marla_calculation_unit != false)
                result += (result == "" ? "" : " AND ") + "is_marla_calculation_unit = " + oeTerritoryWithMauza.Is_marla_calculation_unit + "";
            if (oeTerritoryWithMauza.Area_format != 0)
                result += (result == "" ? "" : " AND ") + "area_format = " + oeTerritoryWithMauza.Area_format + "";

            if (oeTerritoryWithMauza.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = " + oeTerritoryWithMauza.User_id;
            if (oeTerritoryWithMauza.Access_date_time != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_date_time = " + oeTerritoryWithMauza.Access_date_time;
            if (oeTerritoryWithMauza.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeTerritoryWithMauza.Time_stamp + "' ";

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }
    }
}
