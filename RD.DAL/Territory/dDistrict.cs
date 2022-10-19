using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using RD.EL.Territory;
using RD.EL;

namespace RD.DAL.Territory
{
    public class dDistrict : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;

        public override void InitializeAccessors()
        {
        }

        public List<eDistrict> GetDistrict(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.proc_GetDistrict;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int32, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int32, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eDistrict> oeListDistrict = new List<eDistrict>();

            while (oDReader.Read())
            {
                eDistrict oeDistrict = new eDistrict();
                oeDistrict.District_id = ValidateFields.GetSafeGuid(oDReader["district_id"].ToString());
                oeDistrict.Province_id = ValidateFields.GetSafeInteger(oDReader["Province_id"].ToString());
                oeDistrict.District_name_eng = ValidateFields.GetSafeString(oDReader["district_name_eng"].ToString());
                oeDistrict.District_name_urd = ValidateFields.GetSafeString(oDReader["district_name_urd"].ToString());
                oeDistrict.District_FullName = ValidateFields.GetSafeString(oDReader["district_name_eng"].ToString() + "," + oDReader["district_name_urd"].ToString());
                oeDistrict.Is_locked = ValidateFields.GetSafeBoolean(oDReader["is_locked"].ToString());
                oeDistrict.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeDistrict.Access_date_time = ValidateFields.GetSafeDateTime(oDReader["access_date_time"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oeDistrict.Time_stamp = data;

                oeListDistrict.Add(oeDistrict);
            }
            totalRecord = oeListDistrict.Count;

            return oeListDistrict;
        }

        public updatedNewEntryInfo InsertDistrict(eDistrict oeDistrict)
        {
            string storProc = StoreProcedures.proc_InsertDistrict;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeDistrict != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@district_id", DbType.Guid, oeDistrict.District_id);
                        Db.AddInParameter(oCmd, "@province_id", DbType.Int32, oeDistrict.Province_id);
                        Db.AddInParameter(oCmd, "@district_name_eng", DbType.String, oeDistrict.District_name_eng);
                        Db.AddInParameter(oCmd, "@district_name_urd", DbType.String, oeDistrict.District_name_urd);
                        //Db.AddInParameter(oCmd, "@is_locked", DbType.Boolean, oeDistrict.Is_locked);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeDistrict.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oeDistrict.Access_date_time);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeDistrict.District_id;
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

        public updatedNewEntryInfo DeleteDistrict(Guid? DistrictId)
        {
            string storProc = StoreProcedures.proc_DeleteDistrict;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@District_id", DbType.Guid, DistrictId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow != 0)
                    {
                        deleteInfo.Id = DistrictId;
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

        public updatedNewEntryInfo UpdateDistrict(eDistrict oeDistrict)
        {
            string storProc = StoreProcedures.proc_UpdateDistrict;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeDistrict != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@district_id", DbType.Guid, oeDistrict.District_id);
                        Db.AddInParameter(oCmd, "@province_id", DbType.Int32, oeDistrict.Province_id);
                        Db.AddInParameter(oCmd, "@district_name_eng", DbType.String, oeDistrict.District_name_eng);
                        Db.AddInParameter(oCmd, "@district_name_urd", DbType.String, oeDistrict.District_name_urd);
                        Db.AddInParameter(oCmd, "@is_locked", DbType.Boolean, oeDistrict.Is_locked);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeDistrict.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oeDistrict.Access_date_time);
                        //Db.AddInParameter(oCmd, "@time_stamp", DbType.Binary, oeDistrict.Time_stamp);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeDistrict.District_id;
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
