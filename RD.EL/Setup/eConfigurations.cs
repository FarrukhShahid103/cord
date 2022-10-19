using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class eConfigurations
    {
        #region Private Members

        private int config_id;
        private string config_key;
        private string config_value;

        #endregion

        #region Public Properties

        public int Config_id
        {
            get { return config_id; }
            set { config_id = value; }
        }

        public string Config_key
        {
            get { return config_key; }
            set { config_key = value; }
        }

        public string Config_value
        {
            get { return config_value; }
            set { config_value = value; }
        }

        #endregion
    }
}
