using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL.Territory;
using RD.EL.Territory;
using RD.EL;

namespace RD.BLL
{
    public class bDistrict
    {
        private static long totalRecord = -1;
        dDistrict odDistrict;
        public List<eDistrict> GetDistrict(eDistrict oeDistrict, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeDistrict);
            odDistrict = new dDistrict();
            List<eDistrict> oeListDistrict = new List<eDistrict>();
            oeListDistrict = odDistrict.GetDistrict(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListDistrict;
        }

        public updatedNewEntryInfo InsertDistrict(eDistrict oeDistrict)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odDistrict = new dDistrict();
            insertInfo = odDistrict.InsertDistrict(oeDistrict);
            return insertInfo;
        }

        public updatedNewEntryInfo UdpateDistrict(eDistrict oeDistrict)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odDistrict = new dDistrict();
            updateInfo = odDistrict.UpdateDistrict(oeDistrict);
            return updateInfo;
        }

        public updatedNewEntryInfo DeleteDistrict(eDistrict oeDistrict)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odDistrict = new dDistrict();
            deleteInfo = odDistrict.DeleteDistrict(oeDistrict.District_id);
            return deleteInfo;
        }

        public static long GetDistrictCount()
        {
            return totalRecord;
        }
        private string BuildCondition(eDistrict oeDistrict)
        {
            string result = "";

            if (oeDistrict.District_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "district_id = '" + oeDistrict.District_id + "'";
            if (oeDistrict.Province_id != 0)
                result += (result == "" ? "" : " AND ") + "province_id = '" + oeDistrict.Province_id + "'";
            if (oeDistrict.District_name_eng != String.Empty && oeDistrict.District_name_eng != null)
                result += (result == "" ? "" : " AND ") + "district_name_eng = N'" + oeDistrict.District_name_eng + "'";
            if (oeDistrict.District_name_urd != String.Empty && oeDistrict.District_name_urd != null)
                result += (result == "" ? "" : " AND ") + "district_name_urd = N'" + oeDistrict.District_name_urd + "'";
            if (oeDistrict.Is_locked != null && oeDistrict.Is_locked != false)
                result += (result == "" ? "" : " AND ") + "is_locked = " + oeDistrict.Is_locked + "";
            if (oeDistrict.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = " + oeDistrict.User_id;
            if (oeDistrict.Access_date_time != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_date_time = " + oeDistrict.Access_date_time;
            if (oeDistrict.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeDistrict.Time_stamp + "' ";

            if (result != "")
                result = (" WHERE " + result);

            return result;
        }
    }
}
