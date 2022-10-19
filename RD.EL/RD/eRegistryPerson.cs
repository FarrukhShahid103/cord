using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eRegistryPerson
    {
        #region Private Members

        private Guid registryperson_id;
        private Guid registry_id;
        private Guid person_id;
        private Guid party_type_id;
        private string party_name_eng;
        private string party_name_urd;
        private Int64 total_area;
        private Int64 transferred_area;
        private string total_share;
        private string transferred_share;
        private Guid user_id;
        private DateTime access_datetime;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid Registryperson_id
        {
            get { return registryperson_id; }
            set { registryperson_id = value; }
        }

        public Guid Registry_id
        {
            get { return registry_id; }
            set { registry_id = value; }
        }

        public Guid Person_id
        {
            get { return person_id; }
            set { person_id = value; }
        }

        public Guid Party_type_id
        {
            get { return party_type_id; }
            set { party_type_id = value; }
        }

        public string Party_name_urd
        {
            get { return party_name_urd; }
            set { party_name_urd = value; }
        }

        public string Party_name_eng
        {
            get { return party_name_eng; }
            set { party_name_eng = value; }
        }

        public Guid User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public DateTime Access_datetime
        {
            get { return access_datetime; }
            set { access_datetime = value; }
        }

        public byte[] Time_stamp
        {
            get { return time_stamp; }
            set { time_stamp = value; }
        }

        public Int64 Total_area
        {
            get { return total_area; }
            set { total_area = value; }
        }

        public Int64 Transferred_area
        {
            get { return transferred_area; }
            set { transferred_area = value; }
        }

        public string Total_share
        {
            get { return total_share; }
            set { total_share = value; }
        }

        public string Transferred_share
        {
            get { return transferred_share; }
            set { transferred_share = value; }
        }

        #endregion
    }
}
