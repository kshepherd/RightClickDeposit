using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Diagnostics;
using org.swordapp.client.windows.libraries;

namespace org.swordapp.client.windows
{
    static class Program
    {
       public static string profileDataPath = Application.UserAppDataPath + "\\profiles.xml";
       public static string defaultProfileDataPath = Application.CommonAppDataPath + "\\profiles.xml";
        
        
       public static string userDataPath = Application.UserAppDataPath + "\\deposits.xml";
       public static string action = "create";
       public static string file = null;
       public static int idArg;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       [STAThread]
       static void Main(string[] args)
       {
           //MessageBox.Show(defaultProfileDataPath);
           //string file = null;
           //string action = null;
           string endpoint = null;
           int depositId = -1;
           Profile currentProfile = null;
           Dictionary<int, Profile> profiles = Profile.loadProfiles(defaultProfileDataPath);
           Dictionary<int, Deposit> deposits = Deposit.loadDeposits(userDataPath);

           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);

           if (args.Length == 1)
           {
               if (args[0].Equals("profiles"))
               {
                   //MessageBox.Show("CWD: " + Directory.GetCurrentDirectory() + "\nStartup Path: " + Application.StartupPath);
                   Process rcdpm = new Process();
                   rcdpm.StartInfo.FileName = Application.StartupPath + "\\rcdpm.exe";
                   rcdpm.StartInfo.Arguments = defaultProfileDataPath;
                   rcdpm.Start();
                   Application.Exit();
               }
           }
           else
           {
               if (profiles.Count == 0)
               {
                   MessageBox.Show("No profiles were found. Please use the 'manage profiles' command to create one or more profiles\n(Requires administrative privileges)");
                   Application.Exit();
               }

               if (args.Length > 2)
               {

                   idArg = int.Parse(args[0]);
                   action = args[1];
                   file = args[2];

                   switch (action)
                   {
                       case "create":
                           int profileId = idArg;
                           if (profiles.ContainsKey(profileId))
                           {
                               currentProfile = profiles[profileId];
                           }
                           else
                           {
                               MessageBox.Show("Could not locate profile with ID \"" + profileId + "\"", "Error loading profile");
                               Application.Exit();
                           }
                           break;

                       case "update":
                           frmDeposits depositSelector = new frmDeposits(deposits);
                           depositSelector.TopMost = true;
                           depositSelector.Focus();
                           DialogResult res = depositSelector.ShowDialog();
                           if (res == DialogResult.OK)
                           {
                               action = depositSelector.GetAction();
                               depositId = depositSelector.GetSelectedDeposit();
                               if (deposits.ContainsKey(depositId))
                               {
                                   if (profiles.ContainsKey(deposits[depositId].GetProfile()))
                                   {
                                       int profile = deposits[depositId].GetProfile();
                                       currentProfile = profiles[profile];
                                       if (action.Equals("update"))
                                           endpoint = deposits[depositId].GetEmIri();
                                       else
                                           endpoint = deposits[depositId].GetSeIri();
                                   }
                               }
                           }
                           else
                           {
                               // MessageBox.Show("Error: Could not get all deposit and profile information for selected deposit.");
                               Application.Exit();
                           }

                           break;
                           /*
                       case "delete":
                           frmDeposits depositDeleter = new frmDeposits(deposits);
                           DialogResult resd = depositDeleter.ShowDialog();
                           if (resd == DialogResult.OK)
                           {
                               depositId = depositDeleter.GetSelectedDeposit();
                               if (deposits.ContainsKey(depositId))
                               {
                                   if (profiles.ContainsKey(deposits[depositId].GetProfile()))
                                   {
                                       int profile = deposits[depositId].GetProfile();
                                       currentProfile = profiles[profile];
                                       endpoint = deposits[depositId].GetSeIri();
                                   }
                               }
                           }
                           else
                           {
                               //MessageBox.Show("Error: Could not get all deposit and profile information for selected deposit.");
                               Application.Exit();
                           }
                           break;
                            * */
                       default:
                           break;
                   }

               }

               // if action is 'update', show form to select previous deposit

               if (file != null && currentProfile != null)
               {
                   Application.Run(new frmMain(file, currentProfile, action, endpoint, depositId));

               }
           }
       }
    }
}
