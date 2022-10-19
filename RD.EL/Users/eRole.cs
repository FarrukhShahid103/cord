using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eRole
    {
        #region Private Members

        private Guid role_id;
        private string description_eng;
        private string description_urd;
        private Guid access_user_id;
        private DateTime access_datetime;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid Role_id
        {
            get { return role_id; }
            set { role_id = value; }
        }

        public string Description_eng
        {
            get { return description_eng; }
            set { description_eng = value; }
        }

        public string Description_urd
        {
            get { return description_urd; }
            set { description_urd = value; }
        }

        public Guid Access_user_id
        {
            get { return access_user_id; }
            set { access_user_id = value; }
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

        #endregion
    }
}
