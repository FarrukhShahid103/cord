using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL.Users
{
    public class eUserServiceCentre
    {
        #region Private Members

        private Guid user_service_centre_id;
        private Guid user_id;
        private Guid service_centre_id;
        private bool active_status;
        private Guid access_user_id;
        private DateTime access_date_time;

        #endregion

        #region Public Properties

        public Guid User_service_centre_id
        {
            get { return user_service_centre_id; }
            set { user_service_centre_id = value; }
        }

        public Guid User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public Guid Service_centre_id
        {
            get { return service_centre_id; }
            set { service_centre_id = value; }
        }

        public bool Active_status
        {
            get { return active_status; }
            set { active_status = value; }
        }

        public Guid Access_user_id
        {
            get { return access_user_id; }
            set { access_user_id = value; }
        }

        public DateTime Access_date_time
        {
            get { return access_date_time; }
            set { access_date_time = value; }
        }

        #endregion
    }
}
