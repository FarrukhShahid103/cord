using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using RD.EL;

namespace RD.DAL
{
    public class dRole : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public dRole()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eRole> getRole(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.proc_GetRole;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eRole> oeListRole = new List<eRole>();
            
            while (oDReader.Read())
            {
                eRole oeRole = new eRole();
                oeRole.Role_id = ValidateFields.GetSafeGuid(oDReader["role_id"].ToString());
                oeRole.Description_eng = ValidateFields.GetSafeString(oDReader["description_eng"].ToString());
                oeRole.Description_urd = ValidateFields.GetSafeString(oDReader["description_urd"].ToString());
                oeRole.Access_user_id = ValidateFields.GetSafeGuid(oDReader["access_user_id"].ToString());
                oeRole.Access_datetime = ValidateFields.GetSafeDateTime(oDReader["access_datetime"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oeRole.Time_stamp = data;

                oeListRole.Add(oeRole);
            }
            totalRecord = oeListRole.Count;

            return oeListRole;
        }

        public updatedNewEntryInfo insertRole(eRole oeRole)
        {
            string storProc = StoreProcedures.proc_InsertRole;
            int effectRow = -1;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeRole != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@role_id", DbType.Guid, oeRole.Role_id);
                        Db.AddInParameter(oCmd, "@description_eng", DbType.String, oeRole.Description_eng);
                        Db.AddInParameter(oCmd, "@description_urd", DbType.String, oeRole.Description_urd);
                        Db.AddInParameter(oCmd, "@access_user_id", DbType.Guid, oeRole.Access_user_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeRole.Access_datetime);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow > 0)
                        {
                            insertInfo.Id = oeRole.Role_id;
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

        public updatedNewEntryInfo deleteRole(Guid? RoleId)
        {
            string storProc = StoreProcedures.proc_DeleteRole;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = -1;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@role_id", DbType.Guid, RoleId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow > 0)
                    {
                        deleteInfo.Id = RoleId;
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

        public updatedNewEntryInfo updateRole(eRole oeRole)
        {
            string storProc = StoreProcedures.proc_DeleteRole;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = -1;
            if (oeRole != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@role_id", DbType.Guid, oeRole.Role_id);
                        Db.AddInParameter(oCmd, "@description_eng", DbType.String, oeRole.Description_eng);
                        Db.AddInParameter(oCmd, "@description_urd", DbType.String, oeRole.Description_urd);
                        Db.AddInParameter(oCmd, "@access_user_id", DbType.Guid, oeRole.Access_user_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeRole.Access_datetime);
                        Db.AddInParameter(oCmd, "@time_stamp", DbType.Binary, oeRole.Time_stamp);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow > 0)
                        {
                            updateInfo.Id = oeRole.Role_id;
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
