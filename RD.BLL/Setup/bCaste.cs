using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL;
using RD.EL;

namespace RD.BLL
{
    public class bCaste
    {
        private static long totalRecord = -1;
        dCaste odCaste;
        public List<eCaste> getCaste(eCaste oeCaste, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeCaste);
            odCaste = new dCaste();
            List<eCaste> oeListCaste = new List<eCaste>();
            oeListCaste = odCaste.getCaste(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListCaste;
        }

        public updatedNewEntryInfo insertCaste(eCaste oeCaste)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odCaste = new dCaste();
            insertInfo = odCaste.insertCaste(oeCaste);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateCaste(eCaste oeCaste)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odCaste = new dCaste();
            updateInfo = odCaste.updateCaste(oeCaste);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteCaste(eCaste oeCaste)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odCaste = new dCaste();
            deleteInfo = odCaste.deleteCaste(oeCaste.Caste_id);
            return deleteInfo;
        }

        public static long GetCasteCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eCaste oeCaste)
        {
            string result = "";

            if (oeCaste.Caste_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "caste_id = '" + oeCaste.Caste_id + "'";
            if (oeCaste.Caste_name_eng != String.Empty && oeCaste.Caste_name_eng != null)
                result += (result == "" ? "" : " AND ") + "caste_name_eng = '" + oeCaste.Caste_name_eng + "'";
            if (oeCaste.Caste_name_urd != String.Empty && oeCaste.Caste_name_urd != null)
                result += (result == "" ? "" : " AND ") + "caste_name_urd = N'" + oeCaste.Caste_name_urd + "'";
            if (oeCaste.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = " + oeCaste.User_id;
            if (oeCaste.Access_date_time != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_date_time = " + oeCaste.Access_date_time;
            if (oeCaste.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeCaste.Time_stamp + "' ";
            if (result != "")
                result = (" WHERE " + result);
            return result;
        }
    }
}
