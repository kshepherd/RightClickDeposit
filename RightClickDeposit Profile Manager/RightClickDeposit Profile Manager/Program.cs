using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using org.swordapp.client.windows.libraries;

namespace org.swordapp.client.windows.profiles
{
    static class Program
    {
        public static string profileDataPath = Application.UserAppDataPath + "\\profiles.xml";
        public static string defaultProfileDataPath = "C:\\ProgramData\\RightClickDeposit\\RightClickDeposit\\1.0.0.0\\profiles.xml";
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
                defaultProfileDataPath = args[0];
            Application.Run(new frmProfiles());
        }
    }
}
