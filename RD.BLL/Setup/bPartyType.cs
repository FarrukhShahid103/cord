using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL;
using RD.EL;

namespace RD.BLL
{
    public class bPartyType
    {
        private static long totalRecord = -1;
        dPartyType odPartyType;
        public List<ePartyType> getPartyType(ePartyType oePartyType, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oePartyType);
            odPartyType = new dPartyType();
            List<ePartyType> oeListPartyType = new List<ePartyType>();
            oeListPartyType = odPartyType.getPartyType(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListPartyType;
        }

        public updatedNewEntryInfo insertPartyType(ePartyType oePartyType)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odPartyType = new dPartyType();
            insertInfo = odPartyType.insertPartyType(oePartyType);
            return insertInfo;
        }

        public updatedNewEntryInfo udpatePartyType(ePartyType oePartyType)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odPartyType = new dPartyType();
            updateInfo = odPartyType.updatePartyType(oePartyType);
            return updateInfo;
        }

        public updatedNewEntryInfo deletePartyType(ePartyType oePartyType)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odPartyType = new dPartyType();
            deleteInfo = odPartyType.deletePartyType(oePartyType.Registry_type_id);
            return deleteInfo;
        }

        public static long GetPartyTypeCount()
        {
            return totalRecord;
        }

        private string BuildCondition(ePartyType oePartyType)
        {
            string result = "";

            if (oePartyType.Party_type_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "party_type_id = '" + oePartyType.Registry_type_id + "'";
            if (oePartyType.Registry_type_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "registry_type_id = '" + oePartyType.Registry_type_id + "'";
            if (oePartyType.Party_name_eng != String.Empty && oePartyType.Party_name_eng != null)
                result += (result == "" ? "" : " AND ") + "party_name_eng = '" + oePartyType.Party_name_eng + "'";
            if (oePartyType.Party_name_urd != String.Empty && oePartyType.Party_name_urd != null)
                result += (result == "" ? "" : " AND ") + "party_name_urd = N'" + oePartyType.Party_name_urd + "'";
            if (oePartyType.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = " + oePartyType.User_id;
            if (oePartyType.Access_date_time != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_date_time = " + oePartyType.Access_date_time;

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }
    }
}
