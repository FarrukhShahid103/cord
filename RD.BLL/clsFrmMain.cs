using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.BLL.General
{
    public static class clsFrmMain
    {
        private static string sUsername;
        private static string sRole;

        public static string SUsername
        {
            get { return sUsername; }
            set { sUsername = value; }
        }
        

        public static string SRole
        {
            get { return sRole; }
            set { sRole = value; }
        }
    }
}
