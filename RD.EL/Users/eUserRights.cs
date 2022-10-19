using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eUserRights
    {
        #region Private Members

        private Guid user_right_id;
        private Guid form_id;
        private Guid user_id;
        private bool? view_right;
        private bool? insert_right;
        private bool? update_right;
        private bool? delete_right;
        private bool? print_right;
        private Guid access_user_id;
        private DateTime access_datetime;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid User_right_id
        {
            get { return user_right_id; }
            set { user_right_id = value; }
        }

        public Guid Form_id
        {
            get { return form_id; }
            set { form_id = value; }
        }

        public Guid User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public bool? View_right
        {
            get { return view_right; }
            set { view_right = value; }
        }

        public bool? Insert_right
        {
            get { return insert_right; }
            set { insert_right = value; }
        }

        public bool? Update_right
        {
            get { return update_right; }
            set { update_right = value; }
        }

        public bool? Delete_right
        {
            get { return delete_right; }
            set { delete_right = value; }
        }

        public bool? Print_right
        {
            get { return print_right; }
            set { print_right = value; }
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
