using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class ePartyType
    {
        #region Private Members

        private Guid party_type_id;
        private Guid registry_type_id;
        private string party_name_eng;
        private string party_name_urd;
        private Guid user_id;
        private DateTime access_date_time;

        #endregion

        #region Public Properties

        public Guid Party_type_id
        {
            get { return party_type_id; }
            set { party_type_id = value; }
        }

        public Guid Registry_type_id
        {
            get { return registry_type_id; }
            set { registry_type_id = value; }
        }

        public string Party_name_eng
        {
            get { return party_name_eng; }
            set { party_name_eng = value; }
        }

        public string Party_name_urd
        {
            get { return party_name_urd; }
            set { party_name_urd = value; }
        }

        public Guid User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public DateTime Access_date_time
        {
            get { return access_date_time; }
            set { access_date_time = value; }
        }

        #endregion
    }
}
