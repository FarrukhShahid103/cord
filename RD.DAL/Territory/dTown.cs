using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dTown : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;

        public dTown()
        {
        }

        public override void InitializeAccessors()
        {

        }

        public List<eTown> getTown(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.proc_GetTown;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eTown> oeListTown = new List<eTown>();

            while (oDReader.Read())
            {
                eTown oeTown = new eTown();
                oeTown.Town_id = ValidateFields.GetSafeGuid(oDReader["town_id"].ToString());
                oeTown.Tehsil_id = ValidateFields.GetSafeGuid(oDReader["tehsil_id"].ToString());
                oeTown.Town_name_eng = ValidateFields.GetSafeString(oDReader["town_name_eng"].ToString());
                oeTown.Town_name_urd = ValidateFields.GetSafeString(oDReader["town_name_urd"].ToString());
                oeTown.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeTown.Access_date_time = ValidateFields.GetSafeDateTime(oDReader["access_date_time"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oeTown.Time_stamp = data;

                oeListTown.Add(oeTown);
            }
            totalRecord = oeListTown.Count;

            return oeListTown;
        }

        public updatedNewEntryInfo insertTown(eTown oeTown)
        {
            string storProc = StoreProcedures.proc_InsertTown;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeTown != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@town_id", DbType.Guid, oeTown.Town_id);
                        Db.AddInParameter(oCmd, "@tehsil_id", DbType.Guid, oeTown.Tehsil_id);
                        Db.AddInParameter(oCmd, "@town_name_eng", DbType.String, oeTown.Town_name_eng);
                        Db.AddInParameter(oCmd, "@town_name_urd", DbType.String, oeTown.Town_name_urd);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeTown.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oeTown.Access_date_time);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeTown.Town_id;
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

        public updatedNewEntryInfo deleteTown(Guid? TownId)
        {
            string storProc = StoreProcedures.proc_DeleteTown;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@town_id", DbType.Guid, TownId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow != 0)
                    {
                        deleteInfo.Id = TownId;
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

        public updatedNewEntryInfo updateTown(eTown oeTown)
        {
            string storProc = StoreProcedures.proc_UpdateTown;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeTown != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@town_id", DbType.Guid, oeTown.Town_id);
                        Db.AddInParameter(oCmd, "@tehsil_id", DbType.Guid, oeTown.Tehsil_id);
                        Db.AddInParameter(oCmd, "@town_name_eng", DbType.String, oeTown.Town_name_eng);
                        Db.AddInParameter(oCmd, "@town_name_urd", DbType.String, oeTown.Town_name_urd);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeTown.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oeTown.Access_date_time);
                        Db.AddInParameter(oCmd, "@time_stamp", DbType.Binary, oeTown.Time_stamp);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeTown.Town_id;
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
