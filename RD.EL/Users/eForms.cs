using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eForms
    {
        #region Private Members

        private Guid form_id;
        private Guid module_id;
        private Guid menu_id;
        private string description_eng;
        private string description_urd;
        private string path;
        private Guid access_user_id;
        private DateTime access_datetime;
        private byte[] time_stamp;

        #endregion

        #region Public Properties

        public Guid Form_id
        {
            get { return form_id; }
            set { form_id = value; }
        }

        public Guid Module_id
        {
            get { return module_id; }
            set { module_id = value; }
        }

        public Guid Menu_id
        {
            get { return menu_id; }
            set { menu_id = value; }
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

        public string Path
        {
            get { return path; }
            set { path = value; }
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
