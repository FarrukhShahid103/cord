using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using RDProject.ResourceCulture;

namespace RDProject.GenClass
{
    public static class clsCulture
    {
        static string sFontSize = string.Empty;
        static string sFontName = string.Empty;
        public static void Localize(Control control, string lang)
        {
            if (control.Name.Contains("frm_"))
            {   
                string sLayout = GetLocalizedString("RightToLeftLayout", lang);
                Form objLay = (Form)control;
                objLay.RightToLeftLayout = sLayout == "true" ? true : false;
                sLayout = GetLocalizedString("RightToLeft", lang);
                objLay.RightToLeft = sLayout == "Yes" ? RightToLeft.Yes : RightToLeft.No;
            }
            sFontSize = GetLocalizedString("FontSize", lang);
            sFontName = GetLocalizedString("FontName", lang);
            string txt = string.Empty;
            if (control.Name.Contains("_"))
            {
                if (control.HasChildren)
                {
                    if (control.Controls.Count > 0)
                        Localize(control.Controls, lang);
                }
            }
            else
            {
                txt = GetLocalizedString(control.Name, lang);
                control.Text = txt == "" ? control.Text : txt;
                control.Font = new System.Drawing.Font(sFontName, Convert.ToInt32(sFontSize));
                if (control.Controls.Count > 0)
                    Localize(control.Controls, lang);
            }
        }

        private static void Localize(System.Windows.Forms.Control.ControlCollection controls, string lang)
        {
            String txt = string.Empty;
            foreach (Control child in controls)
            {
                if (child != null && child.Name.Contains("tbl_"))
                {
                    TableLayoutPanel objTblPnl = (TableLayoutPanel)child;
                    txt = GetLocalizedString("RightToLeft", lang);
                    objTblPnl.RightToLeft = txt == "Yes" ? RightToLeft.Yes : RightToLeft.No;
                }
                txt = GetLocalizedString(child.Name, lang);
                child.Text = txt == "" ? child.Text : txt;
                child.Font = new System.Drawing.Font(sFontName, Convert.ToInt32(sFontSize));
                if (child.Controls.Count > 0)
                    Localize(child, lang);
                else
                {
                    if (child != null && child.Name.Contains("menu_"))
                    {
                        MenuStrip objMenu = (MenuStrip)child;
                        if (objMenu.Items.Count > 0)
                        {
                            for (int i = 0; i < objMenu.Items.Count; i++)
                            {
                                ToolStripMenuItem objTsmi = (ToolStripMenuItem)objMenu.Items[i];
                                if (objTsmi.DropDownItems.Count > 0)
                                {
                                    txt = GetLocalizedString(objMenu.Items[i].Name, lang);
                                    objMenu.Items[i].Text = txt == "" ? objMenu.Items[i].Text : txt;
                                    objMenu.Items[i].Font = new System.Drawing.Font(sFontName, Convert.ToInt32(sFontSize));
                                    for (int j = 0; j < objTsmi.DropDownItems.Count; j++)
                                    {
                                        txt = GetLocalizedString(objTsmi.DropDownItems[j].Name, lang);
                                        objTsmi.DropDownItems[j].Text = txt == "" ? objTsmi.DropDownItems[j].Text : txt;
                                        objTsmi.DropDownItems[j].Font = new System.Drawing.Font(sFontName, Convert.ToInt32(sFontSize));
                                    }
                                }
                                else
                                {
                                    txt = GetLocalizedString(objMenu.Items[i].Name, lang);
                                    objMenu.Items[i].Text = txt == "" ? objMenu.Items[i].Text : txt;
                                    objMenu.Items[i].Font = new System.Drawing.Font(sFontName, Convert.ToInt32(sFontSize));
                                }
                            }
                        }
                    }
                }
            }
        }

        public static String GetLocalizedString(string objectName, string lang)
        {
            ResourceManager resx = RDProjectCul.ResourceManager;
            resx.IgnoreCase = true;
            CultureInfo culture = CultureInfo.CreateSpecificCulture(lang);
            return resx.GetObject(objectName) == null ? string.Empty : resx.GetString(objectName, culture);
        }
    }
}
