using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.EL;
using RD.DAL;

namespace RD.BLL
{
    public class bRegistryOperations
    {
        private static long totalRecord = -1;
        dRegistryOperations odRegistryOperations;
        public List<eRegistryOperations> getRegistryOperations(eRegistryOperations oeRegistryOperations, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeRegistryOperations);
            odRegistryOperations = new dRegistryOperations();
            List<eRegistryOperations> oeListRegistryOperations = new List<eRegistryOperations>();
            oeListRegistryOperations = odRegistryOperations.getRegistryOperations(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListRegistryOperations;
        }

        public updatedNewEntryInfo insertRegistryOperations(eRegistryOperations oeRegistryOperations)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odRegistryOperations = new dRegistryOperations();
            insertInfo = odRegistryOperations.insertRegistryOperations(oeRegistryOperations);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateRegistryOperations(eRegistryOperations oeRegistryOperations)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odRegistryOperations = new dRegistryOperations();
            updateInfo = odRegistryOperations.updateRegistryOperations(oeRegistryOperations);
            return updateInfo;
        }

        public updatedNewEntryInfo UpdateRegistryOperationsStage(eRegistryOperations oeRegistryOperations)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odRegistryOperations = new dRegistryOperations();
            updateInfo = odRegistryOperations.UpdateRegistryOperationsStage(oeRegistryOperations.Registry_id, oeRegistryOperations.Registery_stage.Value, oeRegistryOperations.Remarks);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteRegistryOperations(eRegistryOperations oeRegistryOperations)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odRegistryOperations = new dRegistryOperations();
            deleteInfo = odRegistryOperations.deleteRegistryOperations(oeRegistryOperations.Registry_id);
            return deleteInfo;
        }

        public static long GetRegistryOperationsCount()
        {
            return totalRecord;
        }

        public int maxRegNo(string strQry)
        {
            odRegistryOperations = new dRegistryOperations();
            return odRegistryOperations.maxRegNo(strQry);
        }

        public List<eRegistryOperations> searchRegistryNo(string strQry)
        {
            odRegistryOperations = new dRegistryOperations();
            return odRegistryOperations.searchRegistryNo(strQry);
        }

        private string BuildCondition(eRegistryOperations oeRegistryOperations)
        {
            string result = "";
            if (oeRegistryOperations.Registry_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "registry_id = '" + oeRegistryOperations.Registry_id + "'";
            if (oeRegistryOperations.Mauza_id != null && oeRegistryOperations.Mauza_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "mauza_id = '" + oeRegistryOperations.Mauza_id + "'";
            if (oeRegistryOperations.Service_centre_id != null && oeRegistryOperations.Service_centre_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "service_centre_id = '" + oeRegistryOperations.Service_centre_id + "'";
            if (oeRegistryOperations.Subregistrar_id != null && oeRegistryOperations.Subregistrar_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "subregistrar_id = '" + oeRegistryOperations.Subregistrar_id + "'";
            if (oeRegistryOperations.Registery_stage != null && oeRegistryOperations.Registery_stage != -1)
                result += (result == "" ? "" : " AND ") + "registery_stage = '" + oeRegistryOperations.Registery_stage + "'";
                //result += (result == "" ? "" : " AND ") + "registery_stage <> '1'";
            else if(oeRegistryOperations.Registery_stage == 1)
                result += (result == "" ? "" : " AND ") + "registery_stage = '1'";
            if (oeRegistryOperations.Registry_type_id != null && oeRegistryOperations.Registry_type_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "registry_type_id = '" + oeRegistryOperations.Registry_type_id + "'";
            if (oeRegistryOperations.Registry_no != null && oeRegistryOperations.Registry_no != string.Empty)
                result += (result == "" ? "" : " AND ") + "registry_no = '" + oeRegistryOperations.Registry_no + "'";
            if (oeRegistryOperations.Bahi_no != null && oeRegistryOperations.Bahi_no != string.Empty)
                result += (result == "" ? "" : " AND ") + "bahi_no = '" + oeRegistryOperations.Bahi_no + "'";
            if (oeRegistryOperations.Jild_no != null && oeRegistryOperations.Jild_no != string.Empty)
                result += (result == "" ? "" : " AND ") + "jild_no = '" + oeRegistryOperations.Jild_no + "'";
            if (oeRegistryOperations.Doc_number != null && oeRegistryOperations.Doc_number != string.Empty)
                result += (result == "" ? "" : " AND ") + "doc_number = '" + oeRegistryOperations.Doc_number + "'";
            if (oeRegistryOperations.Mutation_Fee != null && oeRegistryOperations.Mutation_Fee != 0)
                result += (result == "" ? "" : " AND ") + "Mutation_Fee = '" + oeRegistryOperations.Mutation_Fee + "'";
            if (oeRegistryOperations.Cvt != null && oeRegistryOperations.Cvt != 0)
                result += (result == "" ? "" : " AND ") + "CVT = '" + oeRegistryOperations.Cvt + "'";
            if (oeRegistryOperations.Stamp_Duty != null && oeRegistryOperations.Stamp_Duty != 0)
                result += (result == "" ? "" : " AND ") + "Stamp_Duty = '" + oeRegistryOperations.Stamp_Duty + "'";

            if (oeRegistryOperations.Registry_fee != null && oeRegistryOperations.Registry_fee != 0)
                result += (result == "" ? "" : " AND ") + "registry_fee = '" + oeRegistryOperations.Registry_fee + "'";
            if (oeRegistryOperations.Tma_fee != null && oeRegistryOperations.Tma_fee != 0)
                result += (result == "" ? "" : " AND ") + "tma_fee = '" + oeRegistryOperations.Tma_fee + "'";
            if (oeRegistryOperations.District_council_fee != null && oeRegistryOperations.District_council_fee != 0)
                result += (result == "" ? "" : " AND ") + "district_council_fee = " + oeRegistryOperations.District_council_fee + "";
            if (oeRegistryOperations.Challan_fee != null && oeRegistryOperations.Challan_fee != 0)
                result += (result == "" ? "" : " AND ") + "challan_fee = " + oeRegistryOperations.Challan_fee + "";
            if (oeRegistryOperations.Selling_price != null && oeRegistryOperations.Selling_price != 0)
                result += (result == "" ? "" : " AND ") + "selling_price = " + oeRegistryOperations.Selling_price + "";
            if (oeRegistryOperations.Amount != 0)
                result += (result == "" ? "" : " AND ") + "amount = '" + oeRegistryOperations.Amount + "'";
            if (oeRegistryOperations.Is_active != false)
                result += (result == "" ? "" : " AND ") + "is_active = '" + oeRegistryOperations.Is_active + "'";
            if (oeRegistryOperations.Remarks != null && oeRegistryOperations.Remarks != string.Empty)
                result += (result == "" ? "" : " AND ") + "remarks = '" + oeRegistryOperations.Remarks + "'";
            if (oeRegistryOperations.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = " + oeRegistryOperations.User_id;
            if (oeRegistryOperations.Access_datetime != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_datetime = " + oeRegistryOperations.Access_datetime;
            if (oeRegistryOperations.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeRegistryOperations.Time_stamp + "' ";
            if (oeRegistryOperations.Registry_date != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "registry_date = '" + oeRegistryOperations.Registry_date + "' ";

            if (result != "")
                result = (" WHERE " + result);

            return result;
        }
    }
}
