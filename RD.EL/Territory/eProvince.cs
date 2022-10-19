using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL.Territory
{
    public class eProvince
    {
        #region Private Members

        private Guid province_id;
        private string province_name_eng;
        private string province_name_urd;

        #endregion

        #region Public Properties

        public Guid Province_id
        {
            get { return province_id; }
            set { province_id = value; }
        }

        public string Province_name_eng
        {
            get { return province_name_eng; }
            set { province_name_eng = value; }
        }

        public string Province_name_urd
        {
            get { return province_name_urd; }
            set { province_name_urd = value; }
        }

        #endregion
    }
}
