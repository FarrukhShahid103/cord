using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL.Territory
{
    public class eServiceCentre
    {
        #region Private Members

        private Guid service_centre_id;
        private string service_centre_name_eng;
        private string service_centre_name_urd;
        private bool is_locked;
        private Guid access_user_id;
        private DateTime access_datetime;

        #endregion

        #region Public Properties

        public Guid Service_centre_id
        {
            get { return service_centre_id; }
            set { service_centre_id = value; }
        }

        public string Service_centre_name_eng
        {
            get { return service_centre_name_eng; }
            set { service_centre_name_eng = value; }
        }

        public string Service_centre_name_urd
        {
            get { return service_centre_name_urd; }
            set { service_centre_name_urd = value; }
        }

        public bool Is_locked
        {
            get { return is_locked; }
            set { is_locked = value; }
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
        
        #endregion
    }
}
