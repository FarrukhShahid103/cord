using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.EL;
using System.Data.Common;
using System.Data;
using RD.EL.Setup;

namespace RD.DAL
{
    public class dRegistryType : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public dRegistryType()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eRegistryType> getRegistryType(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.proc_GetRegistryType;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eRegistryType> oeListRegistryType = new List<eRegistryType>();
            
            while (oDReader.Read())
            {
                eRegistryType oeRegistryType = new eRegistryType();
                oeRegistryType.Registry_type_id = ValidateFields.GetSafeGuid(oDReader["Registry_type_id"].ToString());
                oeRegistryType.Registry_type_description_eng = ValidateFields.GetSafeString(oDReader["Registry_type_description_eng"].ToString());
                oeRegistryType.Registry_type_description_urd = ValidateFields.GetSafeString(oDReader["Registry_type_description_urd"].ToString());
                oeRegistryType.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeRegistryType.Access_date_time = ValidateFields.GetSafeDateTime(oDReader["access_date_time"].ToString());
                byte[] data = (byte[])oDReader["time_stamp"];
                oeRegistryType.Time_stamp = data;

                oeListRegistryType.Add(oeRegistryType);
            }
            totalRecord = oeListRegistryType.Count;

            return oeListRegistryType;
        }
        public List<eRegistry> getRegistryTypeWihParams(string condition)
        {
            string storProc = StoreProcedures.proc_GetRegistryTypeWithParams;
            oCmd = Db.GetStoredProcCommand(storProc);
            //Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            //Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            //Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            //Db.AddOutParameter(oCmd, "@total_records", DbType.Int64, -1);
            oDReader = Db.ExecuteReader(oCmd);
            List<eRegistry> oeListRegistryType = new List<eRegistry>();

            while (oDReader.Read())
            {
                eRegistry oeRegistry = new eRegistry();

                oeRegistry.Registery_Id = ValidateFields.GetSafeGuid(oDReader["registry_id"].ToString());
                oeRegistry.Registery_no = ValidateFields.GetSafeString(oDReader["registry_no"].ToString());
                oeRegistry.Doc_number = ValidateFields.GetSafeString(oDReader["doc_number"].ToString());
                oeRegistry.Registery_Date = ValidateFields.GetSafeDateTime(oDReader["registry_date"].ToString());
                oeRegistry.District_Name_Eng = ValidateFields.GetSafeString(oDReader["District_name_eng"].ToString());
                oeRegistry.District_Name_Urd = ValidateFields.GetSafeString(oDReader["District_name_urd"].ToString());
                oeRegistry.Tehsil_Name_Eng = ValidateFields.GetSafeString(oDReader["tehsil_name_eng"].ToString());
                oeRegistry.Tehsil_Name_Urd = ValidateFields.GetSafeString(oDReader["tehsil_name_urd"].ToString());
                oeRegistry.Mauza_Name_Eng = ValidateFields.GetSafeString(oDReader["mauza_name_eng"].ToString());
                oeRegistry.Mauza_Name_Urd = ValidateFields.GetSafeString(oDReader["mauza_name_urd"].ToString());
                oeRegistry.Registry_Type_Description_Eng = ValidateFields.GetSafeString(oDReader["Registry_type_description_eng"].ToString());
                oeRegistry.Registry_Type_Description_Urd = ValidateFields.GetSafeString(oDReader["Registry_type_description_urd"].ToString());

                oeListRegistryType.Add(oeRegistry);
            }          
            return oeListRegistryType;
        }
        public updatedNewEntryInfo insertRegistryType(eRegistryType oeRegistryType)
        {
            string storProc = StoreProcedures.proc_InsertRegistryType;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeRegistryType != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@Registry_type_id", DbType.Guid, oeRegistryType.Registry_type_id);
                        Db.AddInParameter(oCmd, "@Registry_type_description_eng", DbType.String, oeRegistryType.Registry_type_description_eng);
                        Db.AddInParameter(oCmd, "@Registry_type_description_urd", DbType.String, oeRegistryType.Registry_type_description_urd);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeRegistryType.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oeRegistryType.Access_date_time);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeRegistryType.Registry_type_id;
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

        public updatedNewEntryInfo deleteRegistryType(Guid? registryId)
        {
            string storProc = StoreProcedures.proc_DeleteRegistryType;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@Registry_type_id", DbType.Guid, registryId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow != 0)
                    {
                        deleteInfo.Id = registryId;
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

        public updatedNewEntryInfo updateRegistryType(eRegistryType oeRegistryType)
        {
            string storProc = StoreProcedures.proc_UpdateRegistryType;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeRegistryType != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@Registry_type_id", DbType.Guid, oeRegistryType.Registry_type_id);
                        Db.AddInParameter(oCmd, "@Registry_type_description_eng", DbType.Guid, oeRegistryType.Registry_type_description_eng);
                        Db.AddInParameter(oCmd, "@Registry_type_description_urd", DbType.String, oeRegistryType.Registry_type_description_urd);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeRegistryType.User_id);
                        Db.AddInParameter(oCmd, "@access_date_time", DbType.DateTime, oeRegistryType.Access_date_time);
                        Db.AddInParameter(oCmd, "@time_stamp", DbType.Binary, oeRegistryType.Time_stamp);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeRegistryType.Registry_type_id;
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
