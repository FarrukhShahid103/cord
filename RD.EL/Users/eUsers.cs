using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eUsers
    {
        #region Private Members

        private Guid user_id;
        private string user_name;
        private string user_password;
        private string first_name;
        private string last_name;
        private string user_nic;
        private bool user_active_status;
        private byte[] user_thumb;
        private bool is_biomatric;
        private bool is_first_login;
        private string secret_question;
        private string secret_answer;
        private Guid dep_user_id;
        private DateTime access_datetime;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }

        public string User_password
        {
            get { return user_password; }
            set { user_password = value; }
        }

        public string First_name
        {
            get { return first_name; }
            set { first_name = value; }
        }

        public string Last_name
        {
            get { return last_name; }
            set { last_name = value; }
        }

        public string User_nic
        {
            get { return user_nic; }
            set { user_nic = value; }
        }

        public bool User_active_status
        {
            get { return user_active_status; }
            set { user_active_status = value; }
        }

        public byte[] User_thumb
        {
            get { return user_thumb; }
            set { user_thumb = value; }
        }

        public bool Is_biomatric
        {
            get { return is_biomatric; }
            set { is_biomatric = value; }
        }

        public bool Is_first_login
        {
            get { return is_first_login; }
            set { is_first_login = value; }
        }

        public string Secret_question
        {
            get { return secret_question; }
            set { secret_question = value; }
        }

        public string Secret_answer
        {
            get { return secret_answer; }
            set { secret_answer = value; }
        }

        public Guid Dep_user_id
        {
            get { return dep_user_id; }
            set { dep_user_id = value; }
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
