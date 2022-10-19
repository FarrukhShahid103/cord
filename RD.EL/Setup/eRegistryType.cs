using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eRegistryType
    {
        #region Private Members

        private Guid registry_type_id;
        private string registry_type_description_eng;
        private string registry_type_description_urd;
        private Guid user_id;
        private DateTime access_date_time;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid Registry_type_id
        {
            get { return registry_type_id; }
            set { registry_type_id = value; }
        }

        public string Registry_type_description_eng
        {
            get { return registry_type_description_eng; }
            set { registry_type_description_eng = value; }
        }

        public string Registry_type_description_urd
        {
            get { return registry_type_description_urd; }
            set { registry_type_description_urd = value; }
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

        public byte[] Time_stamp
        {
            get { return time_stamp; }
            set { time_stamp = value; }
        }

        #endregion
    }
}
