using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL;
using RD.EL;

namespace RD.BLL
{
    public class bRoleRights
    {
        private static long totalRecord = -1;
        dRoleRights odRoleRights;
        public List<eRoleRights> getRoleRights(eRoleRights oeRoleRights, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeRoleRights);
            odRoleRights = new dRoleRights();
            List<eRoleRights> oeListRoleRights = new List<eRoleRights>();
            oeListRoleRights = odRoleRights.getRoleRights(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListRoleRights;
        }

        public updatedNewEntryInfo insertRoleRights(eRoleRights oeRoleRights)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odRoleRights = new dRoleRights();
            insertInfo = odRoleRights.insertRoleRights(oeRoleRights);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateRoleRights(eRoleRights oeRoleRights)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odRoleRights = new dRoleRights();
            updateInfo = odRoleRights.updateRoleRights(oeRoleRights);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteRoleRights(eRoleRights oeRoleRights)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odRoleRights = new dRoleRights();
            deleteInfo = odRoleRights.deleteRoleRights(oeRoleRights);
            return deleteInfo;
        }

        public static long GetRoleRightsCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eRoleRights oeRoleRights)
        {
            string result = "";

            if (oeRoleRights.Role_right_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "role_rights_id = '" + oeRoleRights.Role_right_id + "'";
            if (oeRoleRights.Form_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "form_id = '" + oeRoleRights.Form_id + "'";
            if (oeRoleRights.Role_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "role_id = '" + oeRoleRights.Role_id + "'";
            if (oeRoleRights.View_right != false)
                result += (result == "" ? "" : " AND ") + "view_right = '" + oeRoleRights.View_right + "'";
            if (oeRoleRights.Insert_right != false)
                result += (result == "" ? "" : " AND ") + "insert_right = '" + oeRoleRights.Insert_right + "'";
            if (oeRoleRights.Update_right != false)
                result += (result == "" ? "" : " AND ") + "update_right = '" + oeRoleRights.Update_right + "'";
            if (oeRoleRights.Delete_right != false)
                result += (result == "" ? "" : " AND ") + "delete_right = '" + oeRoleRights.Delete_right + "'";
            if (oeRoleRights.Print_right != false)
                result += (result == "" ? "" : " AND ") + "print_right = '" + oeRoleRights.Print_right + "'";

            if (oeRoleRights.Access_datetime != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_datetime = " + oeRoleRights.Access_datetime;
            if (oeRoleRights.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeRoleRights.Time_stamp + "' ";

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }

    }
}
