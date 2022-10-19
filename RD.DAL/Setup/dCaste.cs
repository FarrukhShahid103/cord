using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dCaste : DataBaseHelper
    {
         DbCommand oCmd;
        IDataReader oDReader;
        public dCaste()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eCaste> getCaste(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.proc_GetCaste;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eCaste> oeListCaste = new List<eCaste>();
            
            while (oDReader.Read())
            {
                eCaste oeCaste = new eCaste();
                oeCaste.Caste_id = ValidateFields.GetSafeGuid(oDReader["caste_id"].ToString());
                oeCaste.Caste_name_eng = ValidateFields.GetSafeString(oDReader["caste_name_eng"].ToString());
                oeCaste.Caste_name_urd = ValidateFields.GetSafeString(oDReader["caste_name_urd"].ToString());
                oeCaste.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeCaste.Access_date_time = ValidateFields.GetSafeDateTime(oDReader["access_date_time"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oeCaste.Time_stamp = data;

                oeListCaste.Add(oeCaste);
            }
            totalRecord = oeListCaste.Count;

            return oeListCaste;
        }

        public updatedNewEntryInfo insertCaste(eCaste oeCaste)
        {
            string storProc = StoreProcedures.proc_InsertCaste;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeCaste != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@caste_id", DbType.Guid, oeCaste.Caste_id);
                        Db.AddInParameter(oCmd, "@caste_name_eng", DbType.String, oeCaste.Caste_name_eng);
                        Db.AddInParameter(oCmd, "@caste_name_urd", DbType.String, oeCaste.Caste_name_urd);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeCaste.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oeCaste.Access_date_time);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeCaste.Caste_id;
                            insertInfo.Success = true;
                        }
                        else
                        {
                            insertInfo.Success = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        insertInfo.Exception = ex.Message;
                    }
                }
            }
            return insertInfo;
        }

        public updatedNewEntryInfo deleteCaste(Guid? CasteId)
        {
            string storProc = StoreProcedures.proc_DeleteCaste;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@caste_id", DbType.Guid, CasteId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow != 0)
                    {
                        deleteInfo.Id = CasteId;
                        deleteInfo.Success = true;
                    }
                    else
                    {
                        deleteInfo.Success = false;
                    }
                }
                catch (Exception ex)
                {
                    deleteInfo.Exception = ex.Message;
                }
            }
            return deleteInfo;
        }

        public updatedNewEntryInfo updateCaste(eCaste oeCaste)
        {
            string storProc = StoreProcedures.proc_UpdateCaste;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeCaste != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@caste_id", DbType.Guid, oeCaste.Caste_id);
                        Db.AddInParameter(oCmd, "@caste_name_eng", DbType.String, oeCaste.Caste_name_eng);
                        Db.AddInParameter(oCmd, "@caste_name_urd", DbType.String, oeCaste.Caste_name_urd);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeCaste.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oeCaste.Access_date_time);
                        //Db.AddInParameter(oCmd, "@time_stamp", DbType.Binary, oeCaste.Time_stamp);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeCaste.Caste_id;
                            updateInfo.Success = true;
                        }
                        else
                        {
                            updateInfo.Success = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        updateInfo.Exception = ex.Message;
                    }
                }
            }
            return updateInfo;
        }
    }
}
