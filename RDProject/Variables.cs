using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
//using System.Configuration;

namespace RDProject
{
    public static class Variables
    {
        public static bool IsLoged = false;
        public static string UserName = string.Empty;
        public static Guid UserId = Guid.Empty;
        public static int Role = -1;
        public static string UserRole = "";
        public static string registryNo = "0";
        public static string load = "0";
        public static string Scan = "T";
        public static string language = "";
        public static string isEnglish;
        public static string isBiometric;
        public static bool ScanningFromApplication;
        public static Guid roleId = Guid.Empty;
        public static string roleName = null;
        public static bool isTown = false;
        public static Guid defaultDistrict = Guid.Empty;
        public static Guid defaultTehsil = Guid.Empty;
        public static Guid defaultTown = Guid.Empty;
        public static Guid defaultMauza = Guid.Empty;

        public static int iStatus = 0;

        public static string frm_district_id = "9F751010-C75F-4B0B-8415-AB1F0609E81D";
        public static string frm_tehsil_id = "F9C50D81-BB2A-46DA-9F7A-4AA36F9C3B45";
        public static string frm_mauza_id = "89621CE4-5E9B-4C78-A84B-0B6E403864AF";
        public static string frm_registration_id = "B24CA4AA-1BE2-4062-A22D-4A564FE20A5D";
        public static string frm_inbox_id = "0081701F-A619-4A2E-8BF1-B29C468F8099";
        private const int EM_SETCUEBANNER = 0x1501;
        //public static Guid configDistrict = new Guid(ConfigurationManager.AppSettings["district"].ToString());
        //public static Guid configTehsil = new Guid(ConfigurationManager.AppSettings["tehsil"].ToString());
        //public static Guid configMauza = new Guid(ConfigurationManager.AppSettings["mauza"].ToString());

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        public static void SetCue(TextBox textBox, string cue)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, cue);
        }

        public static void SetCue(DateTimePicker textBox, string cue)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, cue);
        }

        public static void ClearCue(TextBox textBox)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, string.Empty);
        }

        //public static string[] comboItems = new string[] { "-- < SELECT > --", "Witness", "Seller", "Buyer" };
        //public static string[] cbHibba = new string[] { "-- < SELECT > --", "Witness", "Wahab", "Ayub" };
        //public static string[] cbRehan = new string[] { "-- < SELECT > --", "Witness", "Rahan", "Murthan" };
        //public static string[] cbTabadala = new string[] { "-- < SELECT > --", "Witness", "Tabadala Dehinda", "Tabadala Garhinda" };
        //public static string[] cbDastabdari = new string[] { "-- < SELECT > --", "Witness", "Dastabdari", "Dahinda" }; 

        public static void CloseAllMdiChildForms()
        {
            foreach (var form in Application.OpenForms.Cast<Form>().Where(f => f.IsMdiChild).ToArray())
                form.Close();
        }
       
        public enum Roles
        {
            SCO = 1,
            SRO = 2,
            SCI = 3
        }

        public enum Parties
        {
            seller = 1,
            Buyer = 2,            
        }

        public enum PartyType
        {
            

        }

        private enum RegistryStatus
        {
            RegistryJustInSaveCondition = 0,
            SendToSR = 1,
            CompleteStatus = 2,
            RejectedStatus = 3,
            DeferStatus = 4,
            SendToSCI= 5
        }

        //public static double BankBalance(string _bankbalance, TextBox textboxCurrentBalance)
        //{
        //    {
        //        _bankbalance = textboxCurrentBalance.Text;
        //        textboxCurrentBalance.Text = string.format("{0:0,0}", value);
        //        textboxCurrenctBalance.Text = string.format("{0:C}", value);
        //    }
        //}
    }
}
