using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.EL;
using RD.DAL;

namespace RD.BLL
{
    public class bUserRights
    {
        private static long totalRecord = -1;
        dUserRights odUserRights;
        public List<eUserRights> getUserRights(eUserRights oeUserRights, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeUserRights);
            odUserRights = new dUserRights();
            List<eUserRights> oeListUserRights = new List<eUserRights>();
            oeListUserRights = odUserRights.getUserRights(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListUserRights;
        }

        public updatedNewEntryInfo insertUserRights(eUserRights oeUserRights)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odUserRights = new dUserRights();
            insertInfo = odUserRights.insertUserRights(oeUserRights);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateUserRights(eUserRights oeUserRights)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odUserRights = new dUserRights();
            updateInfo = odUserRights.updateUserRights(oeUserRights);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteUserRights(eUserRights oeUserRights)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odUserRights = new dUserRights();
            deleteInfo = odUserRights.deleteUserRights(oeUserRights.User_id);
            return deleteInfo;
        }

        public static long GetUserRightsCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eUserRights oeUserRights)
        {
            string result = "";

            if (oeUserRights.User_right_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_right_id = '" + oeUserRights.User_right_id + "'";
            if (oeUserRights.Form_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "form_id = '" + oeUserRights.Form_id + "'";
            if (oeUserRights.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "User_id = '" + oeUserRights.User_id + "'";
            if (oeUserRights.View_right != null && oeUserRights.View_right != false)
                result += (result == "" ? "" : " AND ") + "view_right = '" + oeUserRights.View_right + "'";
            if (oeUserRights.Insert_right != null && oeUserRights.Insert_right != false)
                result += (result == "" ? "" : " AND ") + "insert_right = '" + oeUserRights.Insert_right + "'";
            if (oeUserRights.Update_right != null && oeUserRights.Update_right != false)
                result += (result == "" ? "" : " AND ") + "update_right = '" + oeUserRights.Update_right + "'";
            if (oeUserRights.Delete_right != null && oeUserRights.Delete_right != false)
                result += (result == "" ? "" : " AND ") + "delete_right = '" + oeUserRights.Delete_right + "'";
            if (oeUserRights.Print_right != null && oeUserRights.Print_right != false)
                result += (result == "" ? "" : " AND ") + "print_right = '" + oeUserRights.Print_right + "'";
            if (oeUserRights.Access_user_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "access_user_id = " + oeUserRights.Access_user_id;
            if (oeUserRights.Access_datetime != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_datetime = " + oeUserRights.Access_datetime;
            if (oeUserRights.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeUserRights.Time_stamp + "'";

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }

    }
}
