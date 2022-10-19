using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL;
using RD.EL;

namespace RD.BLL
{
    public class bRole
    {
        private static long totalRecord = -1;
        dRole odRole;
        public List<eRole> getRole(eRole oeRole, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeRole);
            odRole = new dRole();
            List<eRole> oeListRole = new List<eRole>();
            oeListRole = odRole.getRole(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListRole;
        }

        public updatedNewEntryInfo insertRole(eRole oeRole)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odRole = new dRole();
            insertInfo = odRole.insertRole(oeRole);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateRole(eRole oeRole)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odRole = new dRole();
            updateInfo = odRole.updateRole(oeRole);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteRole(eRole oeRole)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odRole = new dRole();
            deleteInfo = odRole.deleteRole(oeRole.Role_id);
            return deleteInfo;
        }

        public static long GetRoleCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eRole oeRole)
        {
            string result = "";

            if (oeRole.Role_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "role_id = '" + oeRole.Role_id + "'";
            if (oeRole.Description_eng != null && oeRole.Description_eng != string.Empty)
                result += (result == "" ? "" : " AND ") + "description_eng = '" + oeRole.Description_eng + "'";
            if (oeRole.Description_urd != null && oeRole.Description_urd != string.Empty)
                result += (result == "" ? "" : " AND ") + "description_urd = '" + oeRole.Description_urd + "'";
            if (oeRole.Access_user_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "access_user_id = '" + oeRole.Access_user_id + "'";
            if (oeRole.Access_datetime != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_datetime = " + oeRole.Access_datetime;
            if (oeRole.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeRole.Time_stamp + "'";

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }

    }
}
