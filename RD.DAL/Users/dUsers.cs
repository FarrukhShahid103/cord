using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dUsers:DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public dUsers()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eUsers> getUsers(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.proc_GetUserN;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eUsers> oeListUsers = new List<eUsers>();
            
            while (oDReader.Read())
            {
                eUsers oeUsers = new eUsers();
                oeUsers.User_id = ValidateFields.GetSafeGuid(oDReader["User_id"].ToString());
                oeUsers.User_name = ValidateFields.GetSafeString(oDReader["user_name"].ToString());
                oeUsers.User_password = ValidateFields.GetSafeString(oDReader["user_password"].ToString());
                oeUsers.First_name = ValidateFields.GetSafeString(oDReader["first_name"].ToString());
                oeUsers.Last_name = ValidateFields.GetSafeString(oDReader["last_name"].ToString());
                oeUsers.User_nic = ValidateFields.GetSafeString(oDReader["user_nic"].ToString());
                oeUsers.User_active_status = ValidateFields.GetSafeBoolean(oDReader["user_active_status"].ToString());
                if (oDReader["user_thumb"] != DBNull.Value)
                    oeUsers.User_thumb = (byte[])oDReader["user_thumb"];
                oeUsers.Is_biomatric = ValidateFields.GetSafeBoolean(oDReader["is_biomatric_on"].ToString());
                oeUsers.Is_first_login = ValidateFields.GetSafeBoolean(oDReader["is_first_login"].ToString());
                oeUsers.Secret_question = ValidateFields.GetSafeString(oDReader["secret_question"].ToString());
                oeUsers.Secret_answer = ValidateFields.GetSafeString(oDReader["secret_answer"].ToString());
                oeUsers.Dep_user_id = ValidateFields.GetSafeGuid(oDReader["dep_user_id"].ToString());
                oeUsers.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeUsers.Access_datetime = ValidateFields.GetSafeDateTime(oDReader["access_datetime"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oeUsers.Time_stamp = data;

                oeListUsers.Add(oeUsers);
            }
            totalRecord = oeListUsers.Count;

            return oeListUsers;
        }

        public updatedNewEntryInfo insertUsers(eUsers oeUsers)
        {
            string storProc = StoreProcedures.proc_InsertUserN;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeUsers != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeUsers.User_id);
                        Db.AddInParameter(oCmd, "@user_name", DbType.String, oeUsers.User_name);
                        Db.AddInParameter(oCmd, "@user_password", DbType.String, oeUsers.User_password);
                        Db.AddInParameter(oCmd, "@first_name", DbType.String, oeUsers.First_name);
                        Db.AddInParameter(oCmd, "@last_name", DbType.String, oeUsers.Last_name);
                        Db.AddInParameter(oCmd, "@user_nic", DbType.String, oeUsers.User_nic);
                        Db.AddInParameter(oCmd, "@user_active_status", DbType.Boolean, oeUsers.User_active_status);
                        Db.AddInParameter(oCmd, "@is_first_login", DbType.Boolean, oeUsers.Is_first_login);
                        Db.AddInParameter(oCmd, "@is_biomatric_on", DbType.Boolean, oeUsers.Is_biomatric);
                        Db.AddInParameter(oCmd, "@user_thumb", DbType.Binary, oeUsers.User_thumb);
                        Db.AddInParameter(oCmd, "@secret_question", DbType.String, oeUsers.Secret_question);
                        Db.AddInParameter(oCmd, "@secret_answer", DbType.String, oeUsers.Secret_answer);
                        Db.AddInParameter(oCmd, "@dep_user_id", DbType.Guid, oeUsers.Dep_user_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeUsers.Access_datetime);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeUsers.User_id;
                            insertInfo.Success = true;
                        }
                        else
                        {
                            insertInfo.Success = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return insertInfo;
        }

        public updatedNewEntryInfo deleteUsers(Guid? UsersId)
        {
            string storProc = StoreProcedures.proc_DeleteUser;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = -1;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@User_id", DbType.Guid, UsersId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow > 0)
                    {
                        deleteInfo.Id = UsersId;
                        deleteInfo.Success = true;
                    }
                    else
                    {
                        deleteInfo.Success = false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return deleteInfo;
        }

        public updatedNewEntryInfo updateUsers(eUsers oeUsers)
        {
            string storProc = StoreProcedures.proc_UpdateUser;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeUsers != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeUsers.User_id);
                        Db.AddInParameter(oCmd, "@user_name", DbType.String, oeUsers.User_name);
                        Db.AddInParameter(oCmd, "@user_password", DbType.String, oeUsers.User_password);
                        Db.AddInParameter(oCmd, "@first_name", DbType.String, oeUsers.First_name);
                        Db.AddInParameter(oCmd, "@last_name", DbType.String, oeUsers.Last_name);
                        Db.AddInParameter(oCmd, "@user_nic", DbType.String, oeUsers.User_nic);
                        Db.AddInParameter(oCmd, "@user_active_status", DbType.Boolean, oeUsers.User_active_status);
                        Db.AddInParameter(oCmd, "@is_first_login", DbType.Boolean, oeUsers.Is_first_login);
                        Db.AddInParameter(oCmd, "@is_biomatric_on", DbType.Boolean, oeUsers.Is_biomatric);
                        Db.AddInParameter(oCmd, "@user_thumb", DbType.Binary, oeUsers.User_thumb);
                        Db.AddInParameter(oCmd, "@time_stamp", DbType.Binary, oeUsers.Time_stamp);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeUsers.User_id;
                            updateInfo.Success = true;
                        }
                        else
                        {
                            updateInfo.Success = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return updateInfo;
        }

        public updatedNewEntryInfo updateUserWithRole(eUsers oeUsers, eUserRoles oeUserRoles)
        {
            string storProc = StoreProcedures.proc_UpdateUserWithRole;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeUsers != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeUsers.User_id);
                        Db.AddInParameter(oCmd, "@user_name", DbType.String, oeUsers.User_name);
                        Db.AddInParameter(oCmd, "@user_password", DbType.String, oeUsers.User_password);
                        Db.AddInParameter(oCmd, "@first_name", DbType.String, oeUsers.First_name);
                        Db.AddInParameter(oCmd, "@last_name", DbType.String, oeUsers.Last_name);
                        Db.AddInParameter(oCmd, "@user_nic", DbType.String, oeUsers.User_nic);
                        Db.AddInParameter(oCmd, "@user_active_status", DbType.Boolean, oeUsers.User_active_status);
                        Db.AddInParameter(oCmd, "@is_first_login", DbType.Boolean, oeUsers.Is_first_login);
                        Db.AddInParameter(oCmd, "@is_biomatric_on", DbType.Boolean, oeUsers.Is_biomatric);
                        Db.AddInParameter(oCmd, "@user_thumb", DbType.Binary, oeUsers.User_thumb);
                        Db.AddInParameter(oCmd, "@time_stamp", DbType.Binary, oeUsers.Time_stamp);

                        Db.AddInParameter(oCmd, "@role_id", DbType.Guid, oeUserRoles.Role_id);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeUsers.User_id;
                            updateInfo.Success = true;
                        }
                        else
                        {
                            updateInfo.Success = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return updateInfo;
        }

        public updatedNewEntryInfo insertUserWithRole(eUsers oeUsers, eUserRoles oeUserRole)
        {
            string storProc = StoreProcedures.proc_InsertUserWithRole;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeUsers != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeUsers.User_id);
                        Db.AddInParameter(oCmd, "@user_name", DbType.String, oeUsers.User_name);
                        Db.AddInParameter(oCmd, "@user_password", DbType.String, oeUsers.User_password);
                        Db.AddInParameter(oCmd, "@first_name", DbType.String, oeUsers.First_name);
                        Db.AddInParameter(oCmd, "@last_name", DbType.String, oeUsers.Last_name);
                        Db.AddInParameter(oCmd, "@user_nic", DbType.String, oeUsers.User_nic);
                        Db.AddInParameter(oCmd, "@user_active_status", DbType.Boolean, oeUsers.User_active_status);
                        Db.AddInParameter(oCmd, "@is_first_login", DbType.Boolean, oeUsers.Is_first_login);
                        Db.AddInParameter(oCmd, "@is_biomatric_on", DbType.Boolean, oeUsers.Is_biomatric);
                        Db.AddInParameter(oCmd, "@user_thumb", DbType.Binary, oeUsers.User_thumb);
                        Db.AddInParameter(oCmd, "@secret_question", DbType.String, oeUsers.Secret_question);
                        Db.AddInParameter(oCmd, "@secret_answer", DbType.String, oeUsers.Secret_answer);
                        Db.AddInParameter(oCmd, "@dep_user_id", DbType.Guid, oeUsers.Dep_user_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeUsers.Access_datetime);
                        Db.AddInParameter(oCmd, "@user_roles_id", DbType.Guid, oeUserRole.User_roles_id);
                        Db.AddInParameter(oCmd, "@role_id", DbType.Guid, oeUserRole.Role_id);
                        Db.AddInParameter(oCmd, "@access_user_id", DbType.Guid, oeUserRole.Access_user_id);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeUsers.User_id;
                            insertInfo.Success = true;
                        }
                        else
                        {
                            insertInfo.Success = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        insertInfo.Success = false;
                        insertInfo.Exception = ex.Message.ToString();
                    }
                }
            }
            return insertInfo;
        }
    }
}
