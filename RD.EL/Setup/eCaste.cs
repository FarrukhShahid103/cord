using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eCaste
    {
        #region Private Members

        private Guid caste_id;
        private string caste_name_eng;
        private string caste_name_urd;
        private Guid user_id;
        private DateTime access_date_time;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid Caste_id
        {
            get { return caste_id; }
            set { caste_id = value; }
        }

        public string Caste_name_eng
        {
            get { return caste_name_eng; }
            set { caste_name_eng = value; }
        }

        public string Caste_name_urd
        {
            get { return caste_name_urd; }
            set { caste_name_urd = value; }
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
