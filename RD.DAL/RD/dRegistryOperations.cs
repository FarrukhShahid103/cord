using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using RD.EL;

namespace RD.DAL
{
    public class dRegistryOperations : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public dRegistryOperations()
        {

        }

        public override void InitializeAccessors()
        {

        }

        public List<eRegistryOperations> getRegistryOperations(string sortExpression, string condition, long startRowIndex, int pageSize, ref long totalRecord)
        {
            string storProc = StoreProcedures.Proc_GetRegistryOperations;
            oCmd = Db.GetStoredProcCommand(storProc);
            Db.AddInParameter(oCmd, "@sort_expression", DbType.String, sortExpression);
            Db.AddInParameter(oCmd, "@condition", DbType.String, condition);
            Db.AddInParameter(oCmd, "@start_row_index", DbType.Int64, startRowIndex);
            Db.AddInParameter(oCmd, "@page_size", DbType.Int32, pageSize);
            Db.AddOutParameter(oCmd, "@total_records", DbType.Int64,-1);
           
            
            oDReader = Db.ExecuteReader(oCmd);
            
            List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
            
            while (oDReader.Read())
            {
                eRegistryOperations oeRegistryOperatins = new eRegistryOperations();
                oeRegistryOperatins.Registry_id = ValidateFields.GetSafeGuid(oDReader["registry_id"].ToString());
                oeRegistryOperatins.Mauza_id = ValidateFields.GetSafeGuid(oDReader["mauza_id"].ToString());
                oeRegistryOperatins.Service_centre_id = ValidateFields.GetSafeGuid(oDReader["service_centre_id"].ToString());
                //oeRegistryOperatins.Fard_id = ValidateFields.GetSafeGuid(oDReader["fard_id"].ToString());
                //oeRegistryOperatins.Khasra_id = ValidateFields.GetSafeGuid(oDReader["khasra_id"].ToString());
                oeRegistryOperatins.Subregistrar_id = ValidateFields.GetSafeGuid(oDReader["subregistrar_id"].ToString());
                oeRegistryOperatins.Registery_stage = ValidateFields.GetSafeInteger(oDReader["registery_stage"].ToString());
                oeRegistryOperatins.Commission_type = ValidateFields.GetSafeInteger(oDReader["comission_type"].ToString());
                oeRegistryOperatins.Registry_type_id = ValidateFields.GetSafeGuid(oDReader["registry_type_id"].ToString());
                oeRegistryOperatins.Registry_no = ValidateFields.GetSafeString(oDReader["registry_no"].ToString());
                oeRegistryOperatins.Bahi_no = ValidateFields.GetSafeString(oDReader["bahi_no"].ToString());
                oeRegistryOperatins.Jild_no = ValidateFields.GetSafeString(oDReader["jild_no"].ToString());
                oeRegistryOperatins.Doc_number = ValidateFields.GetSafeString(oDReader["doc_number"].ToString());
                oeRegistryOperatins.Mutation_Fee = ValidateFields.GetSafeInteger(oDReader["Mutation_Fee"].ToString());
                oeRegistryOperatins.Cvt = ValidateFields.GetSafeInteger(oDReader["CVT"].ToString());
                oeRegistryOperatins.Stamp_Duty = ValidateFields.GetSafeInteger(oDReader["Stamp_Duty"].ToString());
                oeRegistryOperatins.Registry_fee = ValidateFields.GetSafeInteger(oDReader["registry_fee"].ToString());
                oeRegistryOperatins.Tma_fee = ValidateFields.GetSafeInteger(oDReader["tma_fee"].ToString());
                oeRegistryOperatins.District_council_fee= ValidateFields.GetSafeInteger(oDReader["district_council_fee"].ToString());
                oeRegistryOperatins.Challan_fee = ValidateFields.GetSafeInteger(oDReader["challan_fee"].ToString());
                oeRegistryOperatins.Selling_price = ValidateFields.GetSafeInteger(oDReader["selling_price"].ToString());
                oeRegistryOperatins.Amount = ValidateFields.GetSafeInteger(oDReader["amount"].ToString());
                oeRegistryOperatins.Is_active= ValidateFields.GetSafeBoolean(oDReader["is_active"].ToString());
                oeRegistryOperatins.Remarks = ValidateFields.GetSafeString(oDReader["remarks"].ToString());

                oeRegistryOperatins.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                oeRegistryOperatins.Access_datetime = ValidateFields.GetSafeDateTime(oDReader["access_datetime"].ToString());                
                byte[] data = (byte[])oDReader["time_stamp"];
                oeRegistryOperatins.Time_stamp = data;
                oeRegistryOperatins.Registry_date = ValidateFields.GetSafeDateTime(oDReader["registry_date"].ToString());
                oeRegistryOperatins.Is_urban = ValidateFields.GetSafeInteger(oDReader["is_urban"].ToString());
                oeListRegistryOperations.Add(oeRegistryOperatins);
            }
            oDReader.Close();
            if (Db.GetParameterValue(oCmd, "@total_records") != null)
            {
                totalRecord = (Int64)Db.GetParameterValue(oCmd, "@total_records");       
            }
            
            return oeListRegistryOperations;
        }

        public updatedNewEntryInfo insertRegistryOperations(eRegistryOperations oeRegistryOperations)
        {
            string storProc = StoreProcedures.proc_InsertRegistryOperations;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oeRegistryOperations != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@registry_id", DbType.Guid, oeRegistryOperations.Registry_id);
                        Db.AddInParameter(oCmd, "@mauza_id", DbType.Guid, oeRegistryOperations.Mauza_id);
                        Db.AddInParameter(oCmd, "@service_centre_id", DbType.Guid, oeRegistryOperations.Service_centre_id);
                        Db.AddInParameter(oCmd, "@subregistrar_id", DbType.Guid, oeRegistryOperations.Subregistrar_id);
                        Db.AddInParameter(oCmd, "@registery_stage", DbType.Int32, oeRegistryOperations.Registery_stage);
                        Db.AddInParameter(oCmd, "@comission_type", DbType.Int32, oeRegistryOperations.Commission_type);
                        Db.AddInParameter(oCmd, "@registry_type_id", DbType.Guid, oeRegistryOperations.Registry_type_id);
                        Db.AddInParameter(oCmd, "@registry_no", DbType.String, oeRegistryOperations.Registry_no);
                        Db.AddInParameter(oCmd, "@bahi_no", DbType.String, oeRegistryOperations.Bahi_no);
                        Db.AddInParameter(oCmd, "@jild_no", DbType.String, oeRegistryOperations.Jild_no);
                        Db.AddInParameter(oCmd, "@doc_number", DbType.String, oeRegistryOperations.Doc_number);
                        Db.AddInParameter(oCmd, "@Mutation_Fee", DbType.Int32, oeRegistryOperations.Mutation_Fee);
                        Db.AddInParameter(oCmd, "@CVT", DbType.Int32, oeRegistryOperations.Cvt);
                        Db.AddInParameter(oCmd, "@Stamp_Duty", DbType.Int32, oeRegistryOperations.Stamp_Duty);
                        Db.AddInParameter(oCmd, "@registry_fee", DbType.Int32, oeRegistryOperations.Registry_fee);
                        Db.AddInParameter(oCmd, "@tma_fee", DbType.Int32, oeRegistryOperations.Tma_fee);
                        Db.AddInParameter(oCmd, "@district_council_fee", DbType.Int32, oeRegistryOperations.District_council_fee);
                        Db.AddInParameter(oCmd, "@challan_fee", DbType.Int32, oeRegistryOperations.Challan_fee);
                        Db.AddInParameter(oCmd, "@selling_price", DbType.Int32, oeRegistryOperations.Selling_price);
                        Db.AddInParameter(oCmd, "@amount", DbType.Int32, oeRegistryOperations.Amount);
                        Db.AddInParameter(oCmd, "@is_active", DbType.Boolean, oeRegistryOperations.Is_active);
                        Db.AddInParameter(oCmd, "@remarks", DbType.String, oeRegistryOperations.Remarks);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeRegistryOperations.User_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeRegistryOperations.Access_datetime);
                        Db.AddInParameter(oCmd, "@registry_date", DbType.DateTime, oeRegistryOperations.Registry_date);
                        Db.AddInParameter(oCmd, "@is_urban", DbType.Int32, oeRegistryOperations.Is_urban);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            insertInfo.Id = oeRegistryOperations.Registry_id;
                            insertInfo.Success = true;
                        }
                        else
                        {
                            insertInfo.Success = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        insertInfo.Exception = ex.Message.ToString();
                    }
                }
            }
            return insertInfo;
        }

        public updatedNewEntryInfo deleteRegistryOperations(Guid? registryId)
        {
            string storProc = StoreProcedures.proc_DeleteRegistryOperations;
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            int effectRow = -1;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@registry_id", DbType.Guid, registryId);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow > 0)
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
                    throw ex;
                }
            }
            return deleteInfo;
        }

        public updatedNewEntryInfo updateRegistryOperations(eRegistryOperations oeRegistryOperations)
        {
            string storProc = StoreProcedures.proc_UpdateRegistryOperations;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            if (oeRegistryOperations != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@registry_id", DbType.Guid, oeRegistryOperations.Registry_id);
                        Db.AddInParameter(oCmd, "@mauza_id", DbType.Guid, oeRegistryOperations.Mauza_id);
                        Db.AddInParameter(oCmd, "@service_centre_id", DbType.Guid, oeRegistryOperations.Service_centre_id);
                        Db.AddInParameter(oCmd, "@subregistrar_id", DbType.Guid, oeRegistryOperations.Subregistrar_id);
                        Db.AddInParameter(oCmd, "@registery_stage", DbType.Int32, oeRegistryOperations.Registery_stage);
                        Db.AddInParameter(oCmd, "@comission_type", DbType.Int32, oeRegistryOperations.Commission_type);
                        Db.AddInParameter(oCmd, "@registry_type_id", DbType.Guid, oeRegistryOperations.Registry_type_id);
                        Db.AddInParameter(oCmd, "@registry_no", DbType.String, oeRegistryOperations.Registry_no);
                        Db.AddInParameter(oCmd, "@bahi_no", DbType.String, oeRegistryOperations.Bahi_no);
                        Db.AddInParameter(oCmd, "@jild_no", DbType.String, oeRegistryOperations.Jild_no);
                        Db.AddInParameter(oCmd, "@doc_number", DbType.String, oeRegistryOperations.Doc_number);
                        Db.AddInParameter(oCmd, "@Mutation_Fee", DbType.Int32, oeRegistryOperations.Mutation_Fee);
                        Db.AddInParameter(oCmd, "@CVT", DbType.Int32, oeRegistryOperations.Cvt);
                        Db.AddInParameter(oCmd, "@Stamp_Duty", DbType.Int32, oeRegistryOperations.Stamp_Duty);
                        Db.AddInParameter(oCmd, "@registry_fee", DbType.Int32, oeRegistryOperations.Registry_fee);
                        Db.AddInParameter(oCmd, "@tma_fee", DbType.Int32, oeRegistryOperations.Tma_fee);
                        Db.AddInParameter(oCmd, "@district_council_fee", DbType.Int32, oeRegistryOperations.District_council_fee);
                        Db.AddInParameter(oCmd, "@challan_fee", DbType.Int32, oeRegistryOperations.Challan_fee);
                        Db.AddInParameter(oCmd, "@selling_price", DbType.Int32, oeRegistryOperations.Selling_price);
                        Db.AddInParameter(oCmd, "@amount", DbType.Int32, oeRegistryOperations.Amount);
                        Db.AddInParameter(oCmd, "@is_active", DbType.Boolean, oeRegistryOperations.Is_active);
                        Db.AddInParameter(oCmd, "@remarks", DbType.String, oeRegistryOperations.Remarks);
                        Db.AddInParameter(oCmd, "@user_id", DbType.Guid, oeRegistryOperations.User_id);
                        Db.AddInParameter(oCmd, "@access_datetime", DbType.DateTime, oeRegistryOperations.Access_datetime);
                        Db.AddInParameter(oCmd, "@registry_date", DbType.DateTime, oeRegistryOperations.Registry_date);
                        Db.AddInParameter(oCmd, "@is_urban", DbType.Int32, oeRegistryOperations.Is_urban);
                        //Db.AddInParameter(oCmd, "@time_stamp", DbType.Binary, oeRegistryOperations.Time_stamp);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            updateInfo.Id = oeRegistryOperations.Registry_id;
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

        public updatedNewEntryInfo UpdateRegistryOperationsStage(Guid registry_id, int registry_stage, string remarks)
        {
            string storProc = StoreProcedures.proc_UpdateRegistryOperationsStage;
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            int effectRow = 0;
            using (oCmd = Db.GetStoredProcCommand(storProc))
            {
                try
                {
                    Db.AddInParameter(oCmd, "@registry_id", DbType.Guid, registry_id);
                    Db.AddInParameter(oCmd, "@registery_stage", DbType.Int32, registry_stage);
                    Db.AddInParameter(oCmd, "@remarks", DbType.String, remarks);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow != 0)
                    {
                        updateInfo.Id = registry_id;
                        updateInfo.IdNumeric = registry_stage;
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
            
            return updateInfo;
        }


        public int maxRegNo(string strQry)
        {
            int RegNo = -1;
            using (oCmd = Db.GetSqlStringCommand(strQry))
            {
                oCmd.CommandTimeout = 0;
                oDReader = Db.ExecuteReader(oCmd);
                while (oDReader.Read())
                {
                    RegNo = ValidateFields.GetSafeInteger(oDReader["MaxReg"].ToString());
                }
            }
            return RegNo;
        }

        public List<eRegistryOperations> searchRegistryNo(string strQry)
        {
            using (oCmd = Db.GetSqlStringCommand(strQry))
            {
                oDReader = Db.ExecuteReader(oCmd);
                List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
                while (oDReader.Read())
                {
                    eRegistryOperations oeRegistryOperatins = new eRegistryOperations();
                    oeRegistryOperatins.Registry_id = ValidateFields.GetSafeGuid(oDReader["registry_id"].ToString());
                    oeRegistryOperatins.Mauza_id = ValidateFields.GetSafeGuid(oDReader["mauza_id"].ToString());
                    oeRegistryOperatins.Service_centre_id = ValidateFields.GetSafeGuid(oDReader["service_centre_id"].ToString());
                    oeRegistryOperatins.Subregistrar_id = ValidateFields.GetSafeGuid(oDReader["subregistrar_id"].ToString());
                    oeRegistryOperatins.Registery_stage = ValidateFields.GetSafeInteger(oDReader["registery_stage"].ToString());
                    oeRegistryOperatins.Commission_type = ValidateFields.GetSafeInteger(oDReader["comission_type"].ToString());
                    oeRegistryOperatins.Registry_type_id = ValidateFields.GetSafeGuid(oDReader["registry_type_id"].ToString());
                    oeRegistryOperatins.Registry_no = ValidateFields.GetSafeString(oDReader["registry_no"].ToString());
                    oeRegistryOperatins.Bahi_no = ValidateFields.GetSafeString(oDReader["bahi_no"].ToString());
                    oeRegistryOperatins.Jild_no = ValidateFields.GetSafeString(oDReader["jild_no"].ToString());
                    oeRegistryOperatins.Doc_number = ValidateFields.GetSafeString(oDReader["doc_number"].ToString());
                    oeRegistryOperatins.Mutation_Fee = ValidateFields.GetSafeInteger(oDReader["Mutation_Fee"].ToString());
                    oeRegistryOperatins.Cvt = ValidateFields.GetSafeInteger(oDReader["CVT"].ToString());
                    oeRegistryOperatins.Stamp_Duty = ValidateFields.GetSafeInteger(oDReader["Stamp_Duty"].ToString());
                    oeRegistryOperatins.Registry_fee = ValidateFields.GetSafeInteger(oDReader["registry_fee"].ToString());
                    oeRegistryOperatins.Tma_fee = ValidateFields.GetSafeInteger(oDReader["tma_fee"].ToString());
                    oeRegistryOperatins.District_council_fee = ValidateFields.GetSafeInteger(oDReader["district_council_fee"].ToString());
                    oeRegistryOperatins.Challan_fee = ValidateFields.GetSafeInteger(oDReader["challan_fee"].ToString());
                    oeRegistryOperatins.Selling_price = ValidateFields.GetSafeInteger(oDReader["selling_price"].ToString());
                    oeRegistryOperatins.Amount = ValidateFields.GetSafeInteger(oDReader["amount"].ToString());
                    oeRegistryOperatins.Is_active = ValidateFields.GetSafeBoolean(oDReader["is_active"].ToString());
                    oeRegistryOperatins.Remarks = ValidateFields.GetSafeString(oDReader["remarks"].ToString());
                    oeRegistryOperatins.Is_urban = ValidateFields.GetSafeInteger(oDReader["is_urban"].ToString());

                    oeRegistryOperatins.User_id = ValidateFields.GetSafeGuid(oDReader["user_id"].ToString());
                    oeRegistryOperatins.Access_datetime = ValidateFields.GetSafeDateTime(oDReader["access_datetime"].ToString());
                    byte[] data = (byte[])oDReader["time_stamp"];
                    oeRegistryOperatins.Time_stamp = data;
                    oeRegistryOperatins.Registry_date = ValidateFields.GetSafeDateTime(oDReader["registry_date"].ToString());

                    oeListRegistryOperations.Add(oeRegistryOperatins);
                }
                return oeListRegistryOperations;
            }
        }
    }
}
