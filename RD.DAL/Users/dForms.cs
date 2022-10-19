using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dForms : DataBaseHelper
    {
         DbCommand oCmd;
        IDataReader oDReader;
        public dForms()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eForms> getForms(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.proc_GetForms;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eForms> oeListForms = new List<eForms>();
            
            while (oDReader.Read())
            {
                eForms oeForms = new eForms();
                oeForms.Form_id = ValidateFields.GetSafeGuid(oDReader["form_id"].ToString());
                oeForms.Module_id = ValidateFields.GetSafeGuid(oDReader["module_id"].ToString());
                oeForms.Menu_id = ValidateFields.GetSafeGuid(oDReader["menu_id"].ToString());
                oeForms.Description_eng = ValidateFields.GetSafeString(oDReader["description_eng"].ToString());
                oeForms.Description_urd = ValidateFields.GetSafeString(oDReader["description_urd"].ToString());
                oeForms.Path = ValidateFields.GetSafeString(oDReader["path"].ToString());
                oeForms.Access_user_id = ValidateFields.GetSafeGuid(oDReader["access_user_id"].ToString());
                oeForms.Access_datetime = ValidateFields.GetSafeDateTime(oDReader["access_datetime"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oeForms.Time_stamp = data;

                oeListForms.Add(oeForms);
            }
            totalRecord = oeListForms.Count;

            return oeListForms;
        }

        public updatedNewEntryInfo insertForms(eForms oeForms)
        {
            string storProc = StoreProcedures.proc_InsertForms;
            int effectRow = -1;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeForms != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@Form_id", DbType.Guid, oeForms.Form_id);
                        Db.AddInParameter(oCmd, "@module_id", DbType.Guid, oeForms.Module_id);
                        Db.AddInParameter(oCmd, "@menu_id", DbType.Guid, oeForms.Menu_id);
                        Db.AddInParameter(oCmd, "@description_eng", DbType.String, oeForms.Description_eng);
                        Db.AddInParameter(oCmd, "@description_urd", DbType.String, oeForms.Description_urd);
                        Db.AddInParameter(oCmd, "@path", DbType.String, oeForms.Path);
                        Db.AddInParameter(oCmd, "@access_user_id", DbType.Guid, oeForms.Access_user_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeForms.Access_datetime);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow > 0)
                        {
                            insertInfo.Id = oeForms.Form_id;
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

        public updatedNewEntryInfo deleteForms(Guid? FormsId)
        {
            string storProc = StoreProcedures.proc_DeleteForms;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = -1;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@form_id", DbType.Guid, FormsId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow > 0)
                    {
                        deleteInfo.Id = FormsId;
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

        public updatedNewEntryInfo updateForms(eForms oeForms)
        {
            string storProc = StoreProcedures.proc_DeleteForms;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = -1;
            if (oeForms != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@Form_id", DbType.Guid, oeForms.Form_id);
                        Db.AddInParameter(oCmd, "@description_eng", DbType.String, oeForms.Description_eng);
                        Db.AddInParameter(oCmd, "@description_urd", DbType.String, oeForms.Description_urd);
                        Db.AddInParameter(oCmd, "@access_user_id", DbType.Guid, oeForms.Access_user_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeForms.Access_datetime);
                        Db.AddInParameter(oCmd, "@time_stamp", DbType.Binary, oeForms.Time_stamp);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow > 0)
                        {
                            updateInfo.Id = oeForms.Form_id;
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
