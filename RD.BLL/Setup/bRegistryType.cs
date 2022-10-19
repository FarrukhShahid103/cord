using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.EL.Setup;
using RD.EL;
using RD.DAL;

namespace RD.BLL
{
    public class bRegistryType
    {
        private static long totalRecord = -1;
        dRegistryType odRegistryType;
        public List<eRegistryType> getRegistryType(eRegistryType oeRegistryType, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeRegistryType);
            odRegistryType = new dRegistryType();
            List<eRegistryType> oeListRegistryType = new List<eRegistryType>();
            oeListRegistryType = odRegistryType.getRegistryType(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListRegistryType;
        }

        public List<eRegistry> getRegistryTypeWihParams(string condition)
        {
            odRegistryType = new dRegistryType();
            return odRegistryType.getRegistryTypeWihParams(condition);
        }

        public updatedNewEntryInfo insertRegistryType(eRegistryType oeRegistryType)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odRegistryType = new dRegistryType();
            insertInfo = odRegistryType.insertRegistryType(oeRegistryType);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateRegistryType(eRegistryType oeRegistryType)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odRegistryType = new dRegistryType();
            updateInfo = odRegistryType.updateRegistryType(oeRegistryType);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteRegistryType(eRegistryType oeRegistryType)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odRegistryType = new dRegistryType();
            deleteInfo = odRegistryType.deleteRegistryType(oeRegistryType.Registry_type_id);
            return deleteInfo;
        }

        public static long GetRegistryTypeCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eRegistryType oeRegistryType)
        {
            string result = "";

            if (oeRegistryType.Registry_type_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "Registry_type_id = '" + oeRegistryType.Registry_type_id + "'";
            if (oeRegistryType.Registry_type_description_eng != String.Empty && oeRegistryType.Registry_type_description_eng != null)
                result += (result == "" ? "" : " AND ") + "Registry_type_description_eng = N'" + oeRegistryType.Registry_type_description_eng + "'";
            if (oeRegistryType.Registry_type_description_urd != String.Empty && oeRegistryType.Registry_type_description_urd != null)
                result += (result == "" ? "" : " AND ") + "Registry_type_description_urd = N'" + oeRegistryType.Registry_type_description_urd + "'";

            if (oeRegistryType.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = " + oeRegistryType.User_id;
            if (oeRegistryType.Access_date_time != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_date_time = " + oeRegistryType.Access_date_time;
            if (oeRegistryType.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeRegistryType.Time_stamp + "' ";

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }
    }
}
