using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dUserRights : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public dUserRights()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eUserRights> getUserRights(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.proc_GetUserRights;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eUserRights> oeListUserRights = new List<eUserRights>();
            
            while (oDReader.Read())
            {
                eUserRights oeUserRights = new eUserRights();
                oeUserRights.User_right_id = ValidateFields.GetSafeGuid(oDReader["user_right_id"].ToString());
                oeUserRights.Form_id = ValidateFields.GetSafeGuid(oDReader["form_id"].ToString());
                oeUserRights.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeUserRights.View_right = ValidateFields.GetSafeBoolean(oDReader["view_right"].ToString());
                oeUserRights.Insert_right = ValidateFields.GetSafeBoolean(oDReader["insert_right"].ToString());
                oeUserRights.Update_right = ValidateFields.GetSafeBoolean(oDReader["update_right"].ToString());
                oeUserRights.Delete_right = ValidateFields.GetSafeBoolean(oDReader["delete_right"].ToString());
                oeUserRights.Print_right = ValidateFields.GetSafeBoolean(oDReader["print_right"].ToString());
                oeUserRights.Access_user_id = ValidateFields.GetSafeGuid(oDReader["access_user_id"].ToString());
                oeUserRights.Access_datetime = ValidateFields.GetSafeDateTime(oDReader["access_datetime"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oeUserRights.Time_stamp = data;

                oeListUserRights.Add(oeUserRights);
            }
            totalRecord = oeListUserRights.Count;

            return oeListUserRights;
        }

        public updatedNewEntryInfo insertUserRights(eUserRights oeUserRights)
        {
            string storProc = StoreProcedures.proc_InsertUserRights;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeUserRights != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@user_right_id", DbType.Guid, oeUserRights.User_right_id);
                        Db.AddInParameter(oCmd, "@form_id", DbType.Guid, oeUserRights.Form_id);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeUserRights.User_id);
                        Db.AddInParameter(oCmd, "@view_right", DbType.Boolean, oeUserRights.View_right);
                        Db.AddInParameter(oCmd, "@insert_right", DbType.Boolean, oeUserRights.Insert_right);
                        Db.AddInParameter(oCmd, "@update_right", DbType.Boolean, oeUserRights.Update_right);
                        Db.AddInParameter(oCmd, "@delete_right", DbType.Boolean, oeUserRights.Delete_right);
                        Db.AddInParameter(oCmd, "@print_right", DbType.Boolean, oeUserRights.Print_right);
                        Db.AddInParameter(oCmd, "@access_user_id", DbType.Guid, oeUserRights.Access_user_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeUserRights.Access_datetime);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeUserRights.User_id;
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

        public updatedNewEntryInfo deleteUserRights(Guid? UserRightsId)
        {
            string storProc = StoreProcedures.proc_DeleteUserRights;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = -1;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@user_right_id", DbType.Guid, UserRightsId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow > 0)
                    {
                        deleteInfo.Id = UserRightsId;
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

        public updatedNewEntryInfo updateUserRights(eUserRights oeUserRights)
        {
            string storProc = StoreProcedures.proc_UpdateUserRights;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeUserRights != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@user_right_id", DbType.Guid, oeUserRights.User_right_id);
                        Db.AddInParameter(oCmd, "@form_id", DbType.Guid, oeUserRights.Form_id);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeUserRights.User_id);
                        Db.AddInParameter(oCmd, "@view_right", DbType.Boolean, oeUserRights.View_right);
                        Db.AddInParameter(oCmd, "@insert_right", DbType.Boolean, oeUserRights.Insert_right);
                        Db.AddInParameter(oCmd, "@update_right", DbType.Boolean, oeUserRights.Update_right);
                        Db.AddInParameter(oCmd, "@delete_right", DbType.Boolean, oeUserRights.Delete_right);
                        Db.AddInParameter(oCmd, "@print_right", DbType.Boolean, oeUserRights.Print_right);
                        Db.AddInParameter(oCmd, "@access_user_id", DbType.Guid, oeUserRights.Access_user_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeUserRights.Access_datetime);
                        Db.AddInParameter(oCmd, "@time_stamp", DbType.Byte, oeUserRights.Time_stamp);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeUserRights.User_id;
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
