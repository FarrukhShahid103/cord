using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using RD.EL.Territory;
using RD.EL;

namespace RD.DAL
{
    public class dTehsil : DataBaseHelper
    {
        DataSet oSet;
        DbCommand oCmd;
        IDataReader oDReader;
        public dTehsil()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eTehsil> getTehsil(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.proc_GetTehsil;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eTehsil> oeListTehsil = new List<eTehsil>();
            
            while (oDReader.Read())
            {
                eTehsil oeTehsil = new eTehsil();
                oeTehsil.Tehsil_id = ValidateFields.GetSafeGuid(oDReader["tehsil_id"].ToString());
                oeTehsil.District_id = ValidateFields.GetSafeGuid(oDReader["district_id"].ToString());
                oeTehsil.Tehsil_name_eng = ValidateFields.GetSafeString(oDReader["tehsil_name_eng"].ToString());
                oeTehsil.Tehsil_name_urd = ValidateFields.GetSafeString(oDReader["tehsil_name_urd"].ToString());
                oeTehsil.Tehsil_FullName = ValidateFields.GetSafeString(oDReader["tehsil_name_eng"].ToString() + "," + oDReader["tehsil_name_urd"].ToString());
                oeTehsil.Is_locked = ValidateFields.GetSafeBoolean(oDReader["is_locked"].ToString());
                oeTehsil.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeTehsil.Access_date_time = ValidateFields.GetSafeDateTime(oDReader["access_date_time"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oeTehsil.Time_stamp = data;

                oeListTehsil.Add(oeTehsil);
            }
            totalRecord = oeListTehsil.Count;

            return oeListTehsil;
        }

        public updatedNewEntryInfo insertTehsil(eTehsil oeTehsil)
        {
            string storProc = StoreProcedures.proc_InsertTehsil;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeTehsil != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@tehsil_id", DbType.Guid, oeTehsil.Tehsil_id);
                        Db.AddInParameter(oCmd, "@district_id", DbType.Guid, oeTehsil.District_id);
                        Db.AddInParameter(oCmd, "@tehsil_name_eng", DbType.String, oeTehsil.Tehsil_name_eng);
                        Db.AddInParameter(oCmd, "@tehsil_name_urd", DbType.String, oeTehsil.Tehsil_name_urd);
                        Db.AddInParameter(oCmd, "@is_locked", DbType.Boolean, oeTehsil.Is_locked);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeTehsil.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oeTehsil.Access_date_time);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeTehsil.Tehsil_id;
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

        public updatedNewEntryInfo deleteTehsil(Guid? tehsilId)
        {
            string storProc = StoreProcedures.proc_DeleteTehsil; //"[territory].[proc_DeleteTehsil]";
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@tehsil_id", DbType.Guid, tehsilId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow != 0)
                    {
                        deleteInfo.Id = tehsilId;
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

        public updatedNewEntryInfo updateTehsil(eTehsil oeTehsil)
        {
            string storProc = StoreProcedures.proc_UpdateTehsil;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeTehsil != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@tehsil_id", DbType.Guid, oeTehsil.Tehsil_id);
                        Db.AddInParameter(oCmd, "@district_id", DbType.Guid, oeTehsil.District_id);
                        Db.AddInParameter(oCmd, "@tehsil_name_eng", DbType.String, oeTehsil.Tehsil_name_eng);
                        Db.AddInParameter(oCmd, "@tehsil_name_urd", DbType.String, oeTehsil.Tehsil_name_urd);
                        Db.AddInParameter(oCmd, "@is_locked", DbType.Boolean, oeTehsil.Is_locked);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeTehsil.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oeTehsil.Access_date_time);
                        Db.AddInParameter(oCmd, "@time_stamp", DbType.Binary, oeTehsil.Time_stamp);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeTehsil.Tehsil_id;
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
