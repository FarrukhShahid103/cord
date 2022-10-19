using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.EL;
using RD.DAL;

namespace RD.BLL
{
    public class bTown
    {
        private static long totalRecord = -1;
        dTown odTown;
        public List<eTown> getTown(eTown oeTown, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeTown);
            odTown = new dTown();
            List<eTown> oeListTown = new List<eTown>();
            oeListTown = odTown.getTown(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListTown;
        }

        public updatedNewEntryInfo insertTown(eTown oeTown)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odTown = new dTown();
            insertInfo = odTown.insertTown(oeTown);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateTown(eTown oeTown)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odTown = new dTown();
            updateInfo = odTown.updateTown(oeTown);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteTown(eTown oeTown)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odTown = new dTown();
            deleteInfo = odTown.deleteTown(oeTown.Town_id);
            return deleteInfo;
        }

        public static long GetTownCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eTown oeTown)
        {
            string result = "";

            if (oeTown.Town_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "town_id = '" + oeTown.Town_id + "'";
            if (oeTown.Tehsil_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "tehsil_id = '" + oeTown.Tehsil_id + "'";
            if (oeTown.Town_name_eng != String.Empty && oeTown.Town_name_eng != null)
                result += (result == "" ? "" : " AND ") + "town_name_eng = N'" + oeTown.Town_name_eng + "'";
            if (oeTown.Town_name_urd != String.Empty && oeTown.Town_name_urd != null)
                result += (result == "" ? "" : " AND ") + "Town_name_urd = N'" + oeTown.Town_name_urd + "'";
            if (oeTown.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = " + oeTown.User_id;
            if (oeTown.Access_date_time != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_date_time = " + oeTown.Access_date_time;
            if (oeTown.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeTown.Time_stamp + "' ";

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }

    }
}
