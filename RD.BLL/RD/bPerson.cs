using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL;
using RD.EL;

namespace RD.BLL
{
    public class bPerson
    {
        private static long totalRecord = -1;
        dPerson odPerson;
        public List<ePerson> getPerson(ePerson oePerson, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oePerson);
            odPerson = new dPerson();
            List<ePerson> oeListPerson = new List<ePerson>();
            oeListPerson = odPerson.getPerson(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListPerson;
        }

        public List<ePerson> searchPersonRecord(ePerson oePerson, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = SearchCondition(oePerson);
            odPerson = new dPerson();
            List<ePerson> oeListPerson = new List<ePerson>();
            oeListPerson = odPerson.getPerson(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListPerson;
        }

        public updatedNewEntryInfo insertPerson(ePerson oePerson)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odPerson = new dPerson();
            insertInfo = odPerson.insertPerson(oePerson);
            return insertInfo;
        }

        public updatedNewEntryInfo udpatePerson(ePerson oePerson, bool isEnglish)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odPerson = new dPerson();
            updateInfo = odPerson.updatePerson(oePerson, isEnglish);
            return updateInfo;
        }

        public updatedNewEntryInfo deletePerson(ePerson oePerson)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odPerson = new dPerson();
            deleteInfo = odPerson.deletePerson(oePerson.Person_id);
            return deleteInfo;
        }        

        public static long GetPersonCount()
        {
            return totalRecord;
        }

        private string SearchCondition(ePerson oePerson)
        {
            string result = "";

            if (oePerson.First_name_eng != String.Empty && oePerson.First_name_eng != null)
                result += (result == "" ? "" : " AND ") + "first_name_eng like '%" + oePerson.First_name_eng + "%'";
            if (oePerson.Last_name_eng != String.Empty && oePerson.Last_name_eng != null)
                result += (result == "" ? "" : " AND ") + "last_name_eng like '%" + oePerson.Last_name_eng + "%'";
            if (oePerson.First_name_urd != String.Empty && oePerson.First_name_urd != null)
                result += (result == "" ? "" : " AND ") + "first_name_urd like N'%" + oePerson.First_name_urd + "%'";
            if (oePerson.Last_name_urd != String.Empty && oePerson.Last_name_urd != null)
                result += (result == "" ? "" : " AND ") + "last_name_urd like N'%" + oePerson.Last_name_urd + "%'";
            if (oePerson.Nic != String.Empty && oePerson.Nic != null)
                result += (result == "" ? "" : " AND ") + "nic like '%" + oePerson.Nic + "%'";

            if (result != "")
                result = (" WHERE " + result);

            return result;
        }

        private string BuildCondition(ePerson oePerson)
        {
            string result = "";

            if (oePerson.Person_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "Person_id = '" + oePerson.Person_id + "'";
            if (oePerson.Mauza_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "mauza_id = '" + oePerson.Mauza_id + "'";
            if (oePerson.First_name_eng != String.Empty && oePerson.First_name_eng != null)
                result += (result == "" ? "" : " AND ") + "first_name_eng = '" + oePerson.First_name_eng + "'";
            if (oePerson.Last_name_eng != String.Empty && oePerson.Last_name_eng != null)
                result += (result == "" ? "" : " AND ") + "last_name_eng = '" + oePerson.Last_name_eng + "'";
            if (oePerson.Address_eng != String.Empty && oePerson.Address_eng != null)
                result += (result == "" ? "" : " AND ") + "address_eng = '" + oePerson.Address_eng + "'";
            if (oePerson.First_name_urd != String.Empty && oePerson.First_name_urd != null)
                result += (result == "" ? "" : " AND ") + "first_name_urd = N'" + oePerson.First_name_urd + "'";
            if (oePerson.Last_name_urd != String.Empty && oePerson.Last_name_urd != null)
                result += (result == "" ? "" : " AND ") + "last_name_urd = N'" + oePerson.Last_name_urd + "'";
            if (oePerson.Address_urd != String.Empty && oePerson.Address_urd != null)
                result += (result == "" ? "" : " AND ") + "address_urd = N'" + oePerson.Address_urd + "'";
            if (oePerson.Nic != String.Empty && oePerson.Nic != null)
                result += (result == "" ? "" : " AND ") + "nic = '" + oePerson.Nic + "'";
            if (oePerson.Caste_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "caste_id = '" + oePerson.Caste_id + "'";
            if (oePerson.Relation_id != 0)
                result += (result == "" ? "" : " AND ") + "relation_id = '" + oePerson.Relation_id + "'";
            if (oePerson.Is_govt != false)
                result += (result == "" ? "" : " AND ") + "is_govt = '" + oePerson.Is_govt + "'";
            if (oePerson.Is_department != false)
                result += (result == "" ? "" : " AND ") + "is_department = '" + oePerson.Is_department + "'";
            if (oePerson.Is_kashmiri != false)
                result += (result == "" ? "" : " AND ") + "is_kashmiri = '" + oePerson.Is_kashmiri + "'";
            if (oePerson.Is_active != false)
                result += (result == "" ? "" : " AND ") + "is_active = '" + oePerson.Is_active + "'";
            if (oePerson.Thumb != null)
                result += (result == "" ? "" : " AND ") + "thumb = '" + oePerson.Thumb + "'";
            if (oePerson.Pic_path != String.Empty && oePerson.Pic_path != null)
                result += (result == "" ? "" : " AND ") + "pic_path = '" + oePerson.Pic_path + "'";
            if (oePerson.Person_pic != null)
                result += (result == "" ? "" : " AND ") + "person_pic = '" + oePerson.Person_pic + "'";
            if (oePerson.Is_blocked != false)
                result += (result == "" ? "" : " AND ") + "is_blocked = '" + oePerson.Is_blocked + "'";
            if (oePerson.Block_detail != String.Empty && oePerson.Block_detail != null)
                result += (result == "" ? "" : " AND ") + "block_detail = '" + oePerson.Block_detail + "'";
            if (oePerson.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = " + oePerson.User_id;
            if (oePerson.Access_date_time != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_date_time = " + oePerson.Access_date_time;
            if (oePerson.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oePerson.Time_stamp + "' ";

            if (result != "")
                result = (" WHERE " + result);

            return result;
        }

    }
}
