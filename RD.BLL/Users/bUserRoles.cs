using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL;
using RD.EL;

namespace RD.BLL
{
    public class bUserRoles
    {
        private static long totalRecord = -1;
        dUserRoles odUserRoles;
        public List<eUserRoles> getUserRoles(eUserRoles oeUserRoles, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeUserRoles);
            odUserRoles = new dUserRoles();
            List<eUserRoles> oeListUserRoles = new List<eUserRoles>();
            oeListUserRoles = odUserRoles.getUserRoles(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListUserRoles;
        }

        public updatedNewEntryInfo insertUserRoles(eUserRoles oeUserRoles)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odUserRoles = new dUserRoles();
            insertInfo = odUserRoles.insertUserRoles(oeUserRoles);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateUserRoles(eUserRoles oeUserRoles)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odUserRoles = new dUserRoles();
            updateInfo = odUserRoles.updateUserRoles(oeUserRoles);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteUserRoles(eUserRoles oeUserRoles)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odUserRoles = new dUserRoles();
            deleteInfo = odUserRoles.deleteUserRoles(oeUserRoles.User_id);
            return deleteInfo;
        }

        public static long GetUserRolesCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eUserRoles oeUserRoles)
        {
            string result = "";
            if (oeUserRoles.User_roles_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_roles_id = '" + oeUserRoles.User_roles_id + "'";
            if (oeUserRoles.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = '" + oeUserRoles.User_id + "'";
            if (oeUserRoles.Role_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "role_id = '" + oeUserRoles.Role_id + "'";
            if (oeUserRoles.Access_user_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "access_user_id = " + oeUserRoles.Access_user_id;
            if (oeUserRoles.Access_datetime != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_datetime = " + oeUserRoles.Access_datetime;
            if (oeUserRoles.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeUserRoles.Time_stamp + "'";

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }

    }
}
