using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dUserRoles:DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public dUserRoles()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eUserRoles> getUserRoles(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.proc_GetUserRoles;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eUserRoles> oeListUserRoles = new List<eUserRoles>();
            
            while (oDReader.Read())
            {
                eUserRoles oeUserRoles = new eUserRoles();
                oeUserRoles.User_roles_id = ValidateFields.GetSafeGuid(oDReader["user_roles_id"].ToString());
                oeUserRoles.User_id = ValidateFields.GetSafeGuid(oDReader["User_id"].ToString());
                oeUserRoles.Role_id = ValidateFields.GetSafeGuid(oDReader["role_id"].ToString());
                oeUserRoles.Access_user_id = ValidateFields.GetSafeGuid(oDReader["access_user_id"].ToString());
                oeUserRoles.Access_datetime = ValidateFields.GetSafeDateTime(oDReader["access_datetime"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oeUserRoles.Time_stamp = data;

                oeListUserRoles.Add(oeUserRoles);
            }
            totalRecord = oeListUserRoles.Count;

            return oeListUserRoles;
        }

        public updatedNewEntryInfo insertUserRoles(eUserRoles oeUserRoles)
        {
            string storProc = StoreProcedures.proc_InsertUserRoles;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeUserRoles != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@user_roles_id", DbType.Guid, oeUserRoles.User_roles_id);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeUserRoles.User_id);
                        Db.AddInParameter(oCmd, "@role_id", DbType.Guid, oeUserRoles.Role_id);
                        Db.AddInParameter(oCmd, "@access_user_id", DbType.Guid, oeUserRoles.Access_user_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeUserRoles.Access_datetime);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeUserRoles.User_id;
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

        public updatedNewEntryInfo deleteUserRoles(Guid? UserRolesId)
        {
            string storProc = StoreProcedures.proc_DeleteUserRoles;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = -1;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@user_roles_id", DbType.Guid, UserRolesId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow > 0)
                    {
                        deleteInfo.Id = UserRolesId;
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

        public updatedNewEntryInfo updateUserRoles(eUserRoles oeUserRoles)
        {
            string storProc = StoreProcedures.proc_UpdateUserRoles;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeUserRoles != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@user_roles_id", DbType.Guid, oeUserRoles.User_roles_id);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeUserRoles.User_id);
                        Db.AddInParameter(oCmd, "@role_id", DbType.Guid, oeUserRoles.Role_id);
                        Db.AddInParameter(oCmd, "@access_user_id", DbType.Guid, oeUserRoles.Access_user_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeUserRoles.Access_datetime);
                        Db.AddInParameter(oCmd, "@time_stamp", DbType.Binary, oeUserRoles.Time_stamp);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeUserRoles.User_id;
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

    }
}
