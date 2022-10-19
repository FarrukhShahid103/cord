using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL.Users
{
    public class eMenu
    {
        #region Private Members

        private Guid manu_id;
        private string description_eng;
        private string description_urd;
        private int parent_id;

        #endregion

        #region Public Properties

        public Guid Manu_id
        {
            get { return manu_id; }
            set { manu_id = value; }
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

        public int Parent_id
        {
            get { return parent_id; }
            set { parent_id = value; }
        }

        #endregion
    }
}
