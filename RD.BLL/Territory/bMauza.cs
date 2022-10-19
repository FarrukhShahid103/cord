using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.EL.Territory;
using RD.EL;
using RD.DAL;

namespace RD.BLL
{
    public class bMauza
    {
        private static long totalRecord = -1;
        dMauza odMauza;
        public List<eMauza> getMauza(eMauza oeMauza, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeMauza);
            odMauza = new dMauza();
            List<eMauza> oeListMauza = new List<eMauza>();
            oeListMauza = odMauza.getMauza(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListMauza;
        }

        public updatedNewEntryInfo insertMauza(eMauza oeMauza)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odMauza = new dMauza();
            insertInfo = odMauza.insertMauza(oeMauza);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateMauza(eMauza oeMauza)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odMauza = new dMauza();
            updateInfo = odMauza.updateMauza(oeMauza);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteMauza(eMauza oeMauza)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odMauza = new dMauza();
            deleteInfo = odMauza.deleteMauza(oeMauza.Mauza_id);
            return deleteInfo;
        }

        public static long GetMauzaCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eMauza oeMauza)
        {
            string result = "";

            if (oeMauza.Mauza_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "mauza_id = '" + oeMauza.Mauza_id + "'";
            if (oeMauza.Tehsil_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "tehsil_id = '" + oeMauza.Tehsil_id + "'";
            if (oeMauza.Town_id != null && oeMauza.Town_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "town_id = '" + oeMauza.Town_id + "'";
            if (oeMauza.Mauza_name_eng != String.Empty && oeMauza.Mauza_name_eng != null)
                result += (result == "" ? "" : " AND ") + "mauza_name_eng = N'" + oeMauza.Mauza_name_eng + "'";
            if (oeMauza.Mauza_name_urd != String.Empty && oeMauza.Mauza_name_urd != null)
                result += (result == "" ? "" : " AND ") + "mauza_name_urd = N'" + oeMauza.Mauza_name_urd + "'";
            if (oeMauza.Had_bust_no != 0)
                result += (result == "" ? "" : " AND ") + "had_bust_no = " + oeMauza.Had_bust_no + "";
            if (oeMauza.Feet_per_marla != 0)
                result += (result == "" ? "" : " AND ") + "feet_per_marla = " + oeMauza.Feet_per_marla + "";
            if (oeMauza.Preparation_year != 0)
                result += (result == "" ? "" : " AND ") + "preparation_year = " + oeMauza.Preparation_year + "";
            if (oeMauza.Is_mauza_sikni != false)
                result += (result == "" ? "" : " AND ") + "is_mauza_sikni = " + oeMauza.Is_mauza_sikni + "";
            if (oeMauza.Is_marla_calculation_unit != false)
                result += (result == "" ? "" : " AND ") + "is_marla_calculation_unit = " + oeMauza.Is_marla_calculation_unit + "";
            if (oeMauza.Area_format != 0)
                result += (result == "" ? "" : " AND ") + "area_format = " + oeMauza.Area_format + "";
            if (oeMauza.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = " + oeMauza.User_id;
            if (oeMauza.Access_date_time != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_date_time = " + oeMauza.Access_date_time;
            if (oeMauza.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeMauza.Time_stamp + "' ";

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }

    }
}
