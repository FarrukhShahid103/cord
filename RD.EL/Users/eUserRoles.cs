using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eUserRoles
    {
        #region Private Members

        private Guid user_roles_id;
        private Guid user_id;
        private Guid role_id;
        private Guid access_user_id;
        private DateTime access_datetime;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid User_roles_id
        {
            get { return user_roles_id; }
            set { user_roles_id = value; }
        }

        public Guid User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public Guid Role_id
        {
            get { return role_id; }
            set { role_id = value; }
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
