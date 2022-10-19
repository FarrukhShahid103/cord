using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.DAL;
using RD.EL;

namespace RD.BLL
{
    public class bRegistryPerson
    {
        private static long totalRecord = -1;
        dRegistryPerson odRegistryPerson;
        public List<eRegistryPerson> getRegistryPerson(eRegistryPerson oeRegistryPerson, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeRegistryPerson);
            odRegistryPerson = new dRegistryPerson();
            List<eRegistryPerson> oeListRegistryPerson = new List<eRegistryPerson>();
            oeListRegistryPerson = odRegistryPerson.getRegistryPerson(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListRegistryPerson;
        }

        public List<ePersonWithRegistry> getPersonByRegistryId(eRegistryPerson oeRegistryPerson, string sortExpression, string condition, long startRowIndex, int pageSize)
        {
            condition = BuildCondition(oeRegistryPerson);
            odRegistryPerson = new dRegistryPerson();
            List<ePersonWithRegistry> oeListePersonWithRegistry = new List<ePersonWithRegistry>();
            oeListePersonWithRegistry = odRegistryPerson.getPersonByRegistryId(sortExpression, condition, startRowIndex, pageSize, ref totalRecord);
            return oeListePersonWithRegistry;
        }

        public updatedNewEntryInfo insertRegistryPerson(eRegistryPerson oeRegistryPerson)
        {
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            odRegistryPerson = new dRegistryPerson();
            insertInfo = odRegistryPerson.insertRegistryPerson(oeRegistryPerson);
            return insertInfo;
        }

        public updatedNewEntryInfo udpateRegistryPerson(eRegistryPerson oeRegistryPerson)
        {
            updatedNewEntryInfo updateInfo = new updatedNewEntryInfo();
            odRegistryPerson = new dRegistryPerson();
            updateInfo = odRegistryPerson.updateRegistryPerson(oeRegistryPerson);
            return updateInfo;
        }

        public updatedNewEntryInfo deleteRegistryPerson(eRegistryPerson oeRegistryPerson)
        {
            updatedNewEntryInfo deleteInfo = new updatedNewEntryInfo();
            odRegistryPerson = new dRegistryPerson();
            deleteInfo = odRegistryPerson.deleteRegistryPerson(oeRegistryPerson);
            return deleteInfo;
        }

        public static long GetRegistryPersonCount()
        {
            return totalRecord;
        }

        private string BuildCondition(eRegistryPerson oeRegistryPerson)
        {
            string result = "";

            if (oeRegistryPerson.Registryperson_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "RegistryPerson_id = '" + oeRegistryPerson.Registryperson_id + "'";
            if (oeRegistryPerson.Registry_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "registry_id = '" + oeRegistryPerson.Registry_id + "'";
            if (oeRegistryPerson.Person_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "person_id = '" + oeRegistryPerson.Person_id + "'";
            if (oeRegistryPerson.Party_type_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "party_type_id = '" + oeRegistryPerson.Party_type_id + "'";
            if (oeRegistryPerson.Party_name_eng != null && oeRegistryPerson.Party_name_eng != string.Empty)
                result += (result == "" ? "" : " AND ") + "party_name_eng = '" + oeRegistryPerson.Party_name_eng + "'";
            if (oeRegistryPerson.Party_name_urd !=  null && oeRegistryPerson.Party_name_urd != string.Empty)
                result += (result == "" ? "" : " AND ") + "party_name_urd = '" + oeRegistryPerson.Party_name_urd + "'";
            if (oeRegistryPerson.User_id != Guid.Empty)
                result += (result == "" ? "" : " AND ") + "user_id = " + oeRegistryPerson.User_id;
            if (oeRegistryPerson.Access_datetime != DateTime.MinValue)
                result += (result == "" ? "" : " AND ") + "access_datetime = " + oeRegistryPerson.Access_datetime;
            if (oeRegistryPerson.Time_stamp != null)
                result += (result == "" ? "" : " AND ") + "time_stamp = '" + oeRegistryPerson.Time_stamp + "' ";

            //Concatenate if any condition exists
            if (result != "")
                result = (" WHERE " + result);

            return result;
        }
    }
}
