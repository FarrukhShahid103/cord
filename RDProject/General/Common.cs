using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RDProject
{
    public class Common
    {
        public static void setSourceLanguage(ComboBox cComboBox, string sEng, string sUrd, string language)
        {
            if (language == "ur")
            {
                cComboBox.DisplayMember = sUrd;
            }
            else if (language == "en")
            {
                cComboBox.DisplayMember = sEng;
            }
        }
    }
}
