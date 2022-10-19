using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL;
using RD.EL;

namespace RD.BLL
{
    public class bUsers
    {
        private static long totalRecord = -1;
        dUsers odUsers;
        public List<eUsers> getUsers(eUsers oeUsers, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeUsers);
            odUsers = new dUsers();
            List<eUsers> oeListUsers = new List<eUsers>();
            oeListUsers = odUsers.getUsers(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListUsers;
        }

        public updatedNewEntryInfo insertUsers(eUsers oeUsers)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odUsers = new dUsers();
            insertInfo = odUsers.insertUsers(oeUsers);
            return insertInfo;
        }

        public updatedNewEntryInfo insertUserWithRole(eUsers oeUsers, eUserRoles oeUserRoles)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odUsers = new dUsers();
            insertInfo = odUsers.insertUserWithRole(oeUsers, oeUserRoles);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateUsers(eUsers oeUsers)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odUsers = new dUsers();
            updateInfo = odUsers.updateUsers(oeUsers);
            return updateInfo;
        }

        public updatedNewEntryInfo updateUserWithRole(eUsers oeUsers, eUserRoles oeUserRole)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odUsers = new dUsers();
            updateInfo = odUsers.updateUserWithRole(oeUsers, oeUserRole);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteUsers(eUsers oeUsers)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odUsers = new dUsers();
            deleteInfo = odUsers.deleteUsers(oeUsers.User_id);
            return deleteInfo;
        }

        public static long GetUsersCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eUsers oeUsers)
        {
            string result = "";

            if (oeUsers.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "User_id = '" + oeUsers.User_id + "'";
            if (oeUsers.User_name != null && oeUsers.User_name != string.Empty)
                result += (result == "" ? "" : " AND ") + " convert( NVARCHAR(100), decryptbykey( user_name )) = '" + oeUsers.User_name + "'";
            if (oeUsers.User_password != null && oeUsers.User_password != string.Empty)
                result += (result == "" ? "" : " AND ") + "user_password = '" + oeUsers.User_password + "'";
            if (oeUsers.First_name != String.Empty && oeUsers.First_name != null)
                result += (result == "" ? "" : " AND ") + "first_name = '" + oeUsers.First_name + "'";
            if (oeUsers.Last_name != String.Empty && oeUsers.Last_name != null)
                result += (result == "" ? "" : " AND ") + "last_name = '" + oeUsers.Last_name + "'";
            if (oeUsers.User_nic != String.Empty && oeUsers.User_nic != null)
                result += (result == "" ? "" : " AND ") + "user_nic = '" + oeUsers.User_nic + "'";
            if (oeUsers.User_active_status != null && oeUsers.User_active_status != false)
                result += (result == "" ? "" : " AND ") + "user_active_status = '" + oeUsers.User_active_status + "'";
            if (oeUsers.User_thumb != null)
                result += (result == "" ? "" : " AND ") + "user_thumb = '" + oeUsers.User_thumb + "'";
            if (oeUsers.Is_biomatric != null && oeUsers.Is_biomatric != false)
                result += (result == "" ? "" : " AND ") + "is_biomatric_on = '" + oeUsers.Is_biomatric + "'";
            if (oeUsers.Is_first_login != null && oeUsers.Is_first_login != false)
                result += (result == "" ? "" : " AND ") + "is_first_login = '" + oeUsers.Is_first_login + "'";
            if (oeUsers.Secret_question != String.Empty && oeUsers.Secret_question != null)
                result += (result == "" ? "" : " AND ") + "secret_question = '" + oeUsers.Secret_question + "'";
            if (oeUsers.Secret_answer != String.Empty && oeUsers.Secret_answer != null)
                result += (result == "" ? "" : " AND ") + "secret_answer = '" + oeUsers.Secret_answer + "'";
            if (oeUsers.Dep_user_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "dep_user_id = '" + oeUsers.Dep_user_id + "'";
            if (oeUsers.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = " + oeUsers.User_id;
            if (oeUsers.Access_datetime != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_datetime = " + oeUsers.Access_datetime;
            if (oeUsers.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeUsers.Time_stamp + "'";

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }
    }
}
