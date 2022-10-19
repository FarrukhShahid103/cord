using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL;
using RD.EL;

namespace RD.BLL
{
    public class bFard
    {
        private static long totalRecord = -1;
        dFard odFard;
        public List<eFard> getFard(eFard oeFard, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeFard);
            odFard = new dFard();
            List<eFard> oeListFard = new List<eFard>();
            oeListFard = odFard.getFard(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListFard;
        }

        public updatedNewEntryInfo insertFard(eFard oeFard)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odFard = new dFard();
            insertInfo = odFard.insertFard(oeFard);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateFard(eFard oeFard)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odFard = new dFard();
            updateInfo = odFard.updateFard(oeFard);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteFard(eFard oeFard)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odFard = new dFard();
            deleteInfo = odFard.deleteFard(oeFard);
            return deleteInfo;
        }

        public static long GetFardCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eFard oeFard)
        {
            string result = "";

            if (oeFard.Fard_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "fard_id = '" + oeFard.Fard_id + "'";
            if (oeFard.Registry_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "registry_id = '" + oeFard.Registry_id + "'";
            if (oeFard.Fard_no != String.Empty && oeFard.Fard_no != null)
                result += (result == "" ? "" : " AND ") + "fard_no = '" + oeFard.Fard_no + "'";
            if (oeFard.Fard_objective != String.Empty && oeFard.Fard_objective != null)
                result += (result == "" ? "" : " AND ") + "fard_objective = '" + oeFard.Fard_objective + "'";
            if (oeFard.Is_shamlat != null && oeFard.Is_shamlat != false)
                result += (result == "" ? "" : " AND ") + "is_shamlat = '" + oeFard.Is_shamlat + "'";
            if (oeFard.Total_fee != null && oeFard.Total_fee != 0)
                result += (result == "" ? "" : " AND ") + "total_fee = '" + oeFard.Total_fee + "'";
            if (oeFard.Fard_status != false)
                result += (result == "" ? "" : " AND ") + "fard_status = '" + oeFard.Fard_status + "'";
            if (oeFard.Remarks != String.Empty && oeFard.Remarks != null)
                result += (result == "" ? "" : " AND ") + "remarks = '" + oeFard.Remarks + "'";
            if (oeFard.Is_active != null && oeFard.Is_active != false)
                result += (result == "" ? "" : " AND ") + "is_active = '" + oeFard.Is_active + "'";
            if (oeFard.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = '" + oeFard.User_id + "'";
            if (oeFard.Access_datetime != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_datetime = " + oeFard.Access_datetime;
            if (oeFard.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeFard.Time_stamp + "' ";

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }
    }
}
