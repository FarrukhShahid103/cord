using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dRoleRights : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public dRoleRights()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eRoleRights> getRoleRights(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.proc_GetRoleRights;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eRoleRights> oeListRoleRights = new List<eRoleRights>();
            
            while (oDReader.Read())
            {
                eRoleRights oeRoleRights = new eRoleRights();
                oeRoleRights.Role_right_id = ValidateFields.GetSafeGuid(oDReader["role_right_id"].ToString());
                oeRoleRights.Form_id = ValidateFields.GetSafeGuid(oDReader["form_id"].ToString());
                oeRoleRights.Role_id = ValidateFields.GetSafeGuid(oDReader["role_id"].ToString());
                oeRoleRights.View_right = ValidateFields.GetSafeBoolean(oDReader["view_right"].ToString());
                oeRoleRights.Insert_right = ValidateFields.GetSafeBoolean(oDReader["insert_right"].ToString());
                oeRoleRights.Update_right = ValidateFields.GetSafeBoolean(oDReader["update_right"].ToString());
                oeRoleRights.Delete_right = ValidateFields.GetSafeBoolean(oDReader["delete_right"].ToString());
                oeRoleRights.Print_right = ValidateFields.GetSafeBoolean(oDReader["print_right"].ToString());
                oeRoleRights.Access_user_id = ValidateFields.GetSafeGuid(oDReader["access_user_id"].ToString());
                oeRoleRights.Access_datetime = ValidateFields.GetSafeDateTime(oDReader["access_datetime"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oeRoleRights.Time_stamp = data;

                oeListRoleRights.Add(oeRoleRights);
            }
            totalRecord = oeListRoleRights.Count;

            return oeListRoleRights;
        }

        public updatedNewEntryInfo insertRoleRights(eRoleRights oeRoleRights)
        {
            string storProc = StoreProcedures.proc_InsertRoleRights;
            int effectRow = -1;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeRoleRights != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@role_rights_id", DbType.Guid, oeRoleRights.Role_right_id);
                        Db.AddInParameter(oCmd, "@form_id", DbType.Guid, oeRoleRights.Form_id);
                        Db.AddInParameter(oCmd, "@role_id", DbType.Guid, oeRoleRights.Role_id);
                        Db.AddInParameter(oCmd, "@view_right", DbType.Boolean, oeRoleRights.View_right);
                        Db.AddInParameter(oCmd, "@insert_right", DbType.Boolean, oeRoleRights.Insert_right);
                        Db.AddInParameter(oCmd, "@update_right", DbType.Boolean, oeRoleRights.Update_right);
                        Db.AddInParameter(oCmd, "@delete_right", DbType.Boolean, oeRoleRights.Delete_right);
                        Db.AddInParameter(oCmd, "@print_right", DbType.Boolean, oeRoleRights.Print_right);
                        Db.AddInParameter(oCmd, "@access_user_id", DbType.Guid, oeRoleRights.Access_user_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeRoleRights.Access_datetime);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow > 0)
                        {
                            insertInfo.Id = oeRoleRights.Role_right_id;
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

        public updatedNewEntryInfo deleteRoleRights(eRoleRights oeRoleRights)
        {
            string storProc = StoreProcedures.proc_DeleteRoleRights;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = -1;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@role_right_id", DbType.Guid, oeRoleRights.Role_right_id);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow > 0)
                    {
                        deleteInfo.Id = oeRoleRights.Role_right_id;
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

        public updatedNewEntryInfo updateRoleRights(eRoleRights oeRoleRights)
        {
            string storProc = StoreProcedures.proc_DeleteRoleRights;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = -1;
            if (oeRoleRights != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@role_rights_id", DbType.Guid, oeRoleRights.Role_right_id);
                        Db.AddInParameter(oCmd, "@form_id", DbType.Guid, oeRoleRights.Form_id);
                        Db.AddInParameter(oCmd, "@role_id", DbType.Guid, oeRoleRights.Role_id);
                        Db.AddInParameter(oCmd, "@view_right", DbType.Boolean, oeRoleRights.View_right);
                        Db.AddInParameter(oCmd, "@insert_right", DbType.Boolean, oeRoleRights.Insert_right);
                        Db.AddInParameter(oCmd, "@update_right", DbType.Boolean, oeRoleRights.Update_right);
                        Db.AddInParameter(oCmd, "@delete_right", DbType.Boolean, oeRoleRights.Delete_right);
                        Db.AddInParameter(oCmd, "@print_right", DbType.Boolean, oeRoleRights.Print_right);
                        Db.AddInParameter(oCmd, "@access_user_id", DbType.Guid, oeRoleRights.Access_user_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeRoleRights.Access_datetime);
                        Db.AddInParameter(oCmd, "@time_stamp", DbType.Binary, oeRoleRights.Time_stamp);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow > 0)
                        {
                            updateInfo.Id = oeRoleRights.Role_right_id;
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
