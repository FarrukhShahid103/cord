using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.EL.Territory;
using RD.EL;
using RD.DAL;

namespace RD.BLL
{
    public class bTehsil
    {
        private static long totalRecord = -1;
        dTehsil odTehsil;
        public List<eTehsil> getTehsil(eTehsil oeTehsil, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeTehsil);
            odTehsil = new dTehsil();
            List<eTehsil> oeListTehsil = new List<eTehsil>();
            oeListTehsil = odTehsil.getTehsil(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListTehsil;
        }

        public updatedNewEntryInfo insertTehsil(eTehsil oeTehsil)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odTehsil = new dTehsil();
            insertInfo = odTehsil.insertTehsil(oeTehsil);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateTehsil(eTehsil oeTehsil)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odTehsil = new dTehsil();
            updateInfo = odTehsil.updateTehsil(oeTehsil);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteTehsil(eTehsil oeTehsil)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odTehsil = new dTehsil();
            deleteInfo = odTehsil.deleteTehsil(oeTehsil.Tehsil_id);
            return deleteInfo;
        }

        public static long GetTehsilCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eTehsil oeTehsil)
        {
            string result = "";

            if (oeTehsil.Tehsil_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "tehsil_id = '" + oeTehsil.Tehsil_id + "'";
            if (oeTehsil.District_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "district_id = '" + oeTehsil.District_id + "'";
            if (oeTehsil.Tehsil_name_eng != String.Empty && oeTehsil.Tehsil_name_eng != null)
                result += (result == "" ? "" : " AND ") + "tehsil_name_eng = N'" + oeTehsil.Tehsil_name_eng + "'";
            if (oeTehsil.Tehsil_name_urd != String.Empty && oeTehsil.Tehsil_name_urd != null)
                result += (result == "" ? "" : " AND ") + "tehsil_name_urd = N'" + oeTehsil.Tehsil_name_urd + "'";
            if (oeTehsil.Is_locked != null && oeTehsil.Is_locked != false)
                result += (result == "" ? "" : " AND ") + "is_locked = " + oeTehsil.Is_locked + "";
            if (oeTehsil.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = " + oeTehsil.User_id;
            if (oeTehsil.Access_date_time != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_date_time = " + oeTehsil.Access_date_time;
            if (oeTehsil.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeTehsil.Time_stamp + "' ";

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }

    }
}
