using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eTown
    {
        #region Private Members

        private Guid town_id;
        private Guid tehsil_id;
        private string town_name_eng;
        private string town_name_urd;
        private Guid user_id;
        private DateTime access_date_time;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid Town_id
        {
            get { return town_id; }
            set { town_id = value; }
        }

        public Guid Tehsil_id
        {
            get { return tehsil_id; }
            set { tehsil_id = value; }
        }

        public string Town_name_eng
        {
            get { return town_name_eng; }
            set { town_name_eng = value; }
        }

        public string Town_name_urd
        {
            get { return town_name_urd; }
            set { town_name_urd = value; }
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
