using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL.Territory;
using RD.EL;

namespace RD.DAL
{
    public class dMauza : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;

        public dMauza()
        {
        }

        public override void InitializeAccessors()
        {

        }

        public List<eMauza> getMauza(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = "territory.proc_GetMauza";
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eMauza> oeListMauza = new List<eMauza>();

            while (oDReader.Read())
            {
                eMauza oeMauza = new eMauza();
                oeMauza.Mauza_id = ValidateFields.GetSafeGuid(oDReader["mauza_id"].ToString());
                oeMauza.Tehsil_id = ValidateFields.GetSafeGuid(oDReader["tehsil_id"].ToString());
                oeMauza.Town_id = ValidateFields.GetSafeGuid(oDReader["town_id"].ToString());
                oeMauza.Mauza_name_eng = ValidateFields.GetSafeString(oDReader["mauza_name_eng"].ToString());
                oeMauza.Mauza_name_urd = ValidateFields.GetSafeString(oDReader["mauza_name_urd"].ToString());
                oeMauza.Had_bust_no = ValidateFields.GetSafeInteger(oDReader["had_bust_no"].ToString());
                oeMauza.Feet_per_marla = ValidateFields.GetSafeInteger(oDReader["feet_per_marla"].ToString());
                oeMauza.Preparation_year = ValidateFields.GetSafeInteger(oDReader["preparation_year"].ToString());
                oeMauza.Is_mauza_sikni = ValidateFields.GetSafeBoolean(oDReader["is_mauza_sikni"].ToString());
                oeMauza.Is_marla_calculation_unit = ValidateFields.GetSafeBoolean(oDReader["is_marla_calculation_unit"].ToString());
                oeMauza.Area_format = ValidateFields.GetSafeInteger(oDReader["area_format"].ToString());
                oeMauza.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeMauza.Access_date_time = ValidateFields.GetSafeDateTime(oDReader["access_date_time"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oeMauza.Time_stamp = data;

                oeListMauza.Add(oeMauza);
            }
            totalRecord = oeListMauza.Count;

            return oeListMauza;
        }

        public updatedNewEntryInfo insertMauza(eMauza oeMauza)
        {
            string storProc = StoreProcedures.proc_InsertMauza;// "territory.proc_InsertMauza";
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeMauza != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@mauza_id", DbType.Guid, oeMauza.Mauza_id);
                        Db.AddInParameter(oCmd, "@tehsil_id", DbType.Guid, oeMauza.Tehsil_id);
                        Db.AddInParameter(oCmd, "@town_id", DbType.Guid, oeMauza.Town_id);
                        Db.AddInParameter(oCmd, "@mauza_name_eng", DbType.String, oeMauza.Mauza_name_eng);
                        Db.AddInParameter(oCmd, "@mauza_name_urd", DbType.String, oeMauza.Mauza_name_urd);
                        Db.AddInParameter(oCmd, "@had_bust_no", DbType.Int32, oeMauza.Had_bust_no);
                        Db.AddInParameter(oCmd, "@feet_per_marla", DbType.Int32, oeMauza.Feet_per_marla);
                        Db.AddInParameter(oCmd, "@preparation_year", DbType.Int32, oeMauza.Preparation_year);
                        
                        Db.AddInParameter(oCmd, "@is_mauza_sikni", DbType.Boolean, oeMauza.Is_mauza_sikni);
                        Db.AddInParameter(oCmd, "@is_marla_calculation_unit", DbType.Boolean, oeMauza.Is_marla_calculation_unit);
                     
                        Db.AddInParameter(oCmd, "@area_format", DbType.Int32, oeMauza.Area_format);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeMauza.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oeMauza.Access_date_time);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeMauza.Mauza_id;
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

        public updatedNewEntryInfo deleteMauza(Guid? MauzaId)
        {
            string storProc = StoreProcedures.proc_DeleteMauza; //"[territory].[proc_DeleteMauza]";
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@mauza_id", DbType.Guid, MauzaId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow != 0)
                    {
                        deleteInfo.Id = MauzaId;
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

        public updatedNewEntryInfo updateMauza(eMauza oeMauza)
        {
            string storProc = StoreProcedures.proc_UpdateMauza;// "territory.proc_UpdateMauza";
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeMauza != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@mauza_id", DbType.Guid, oeMauza.Mauza_id);
                        Db.AddInParameter(oCmd, "@tehsil_id", DbType.Guid, oeMauza.Tehsil_id);
                        Db.AddInParameter(oCmd, "@town_id", DbType.Guid, oeMauza.Town_id);
                        Db.AddInParameter(oCmd, "@mauza_name_eng", DbType.String, oeMauza.Mauza_name_eng);
                        Db.AddInParameter(oCmd, "@mauza_name_urd", DbType.String, oeMauza.Mauza_name_urd);
                        Db.AddInParameter(oCmd, "@had_bust_no", DbType.Boolean, oeMauza.Had_bust_no);
                        Db.AddInParameter(oCmd, "@feet_per_marla", DbType.Int32, oeMauza.Feet_per_marla);
                        Db.AddInParameter(oCmd, "@preparation_year", DbType.Int32, oeMauza.Preparation_year);
                        Db.AddInParameter(oCmd, "@is_mauza_sikni", DbType.Boolean, oeMauza.Is_mauza_sikni);
                        Db.AddInParameter(oCmd, "@is_marla_calculation_unit", DbType.Boolean, oeMauza.Is_marla_calculation_unit);
                        Db.AddInParameter(oCmd, "@area_format", DbType.Int32, oeMauza.Area_format);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeMauza.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oeMauza.Access_date_time);
                        Db.AddInParameter(oCmd, "@time_stamp", DbType.Binary, oeMauza.Time_stamp);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeMauza.Mauza_id;
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
