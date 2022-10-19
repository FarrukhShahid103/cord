using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RDProject.Setup;
using RDProject.RD;

namespace RDProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new InboxForm_English());
            //Application.Run(new frm_MainMDI());
            Application.Run(new DragImage_English());
            
            
        }
    }
}
