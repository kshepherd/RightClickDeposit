using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.ModifyRegistry;
using Microsoft.Win32;
using System.Security.Principal;
using System.Security.Permissions;
using System.IO;
using org.swordapp.client.windows.libraries;

namespace org.swordapp.client.windows.profiles
{
    public partial class frmProfiles : Form
    {
        Dictionary<int,Profile> profiles;
        Profile currentProfile;
        ImageList imageList;
        

        public frmProfiles()
        {
            InitializeComponent();
            listProfiles();
            imageList = new ImageList();
            imageList.Images.Add(org.swordapp.client.windows.profiles.Properties.Resources.repository);
            listProfile.LargeImageList = imageList;
            
        }

        private void listProfiles()
        {
            profiles = Profile.loadProfiles(org.swordapp.client.windows.profiles.Program.defaultProfileDataPath);
            listProfile.Items.Clear();
            foreach (KeyValuePair<int, Profile> kv in profiles)
            {
                Profile profile = kv.Value;
                ListViewItem i = new ListViewItem(profile.GetName());
                i.Tag = profile.GetId();
                i.Text = profile.GetName();
                i.Name = profile.GetName();
                i.SubItems.Add(profile.GetServiceDocumentUri());
                i.ImageIndex = 0;
                
                
                listProfile.Items.Add(i);
                if (profile.IsDefault())
                    currentProfile = profile;
            }
            if (profiles.Count == 0)
                currentProfile = new Profile();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Profile p = getSelectedProfile();
            if (p != null)
            {
                currentProfile = p;
            }

            drawProfileForm();
                
        }

        private Profile getSelectedProfile()
        {
            string name;
            int id;
            Profile p = null;
            
            if (listProfile.SelectedItems.Count > 0)
            {
                name = listProfile.SelectedItems[0].Text;
                id = (int) listProfile.SelectedItems[0].Tag;
                p = profiles[id];

            }

            return p;
        }

        private void drawProfileForm()
        {
            txtProfileName.Text = currentProfile.GetName();
            txtServiceDocumentUri.Text = currentProfile.GetServiceDocumentUri();
            txtDefaultDepositUri.Text = currentProfile.GetDepositUri();
            txtUsername.Text = currentProfile.GetUsername();
            //txtPassword.Text = currentProfile.GetPassword();
            cmbAutoState.Text = currentProfile.GetFinalState();
            cmdMetadata.Text = currentProfile.GetMetadataInclusion();
            txtPackaging.Text = currentProfile.GetPackaging();
            txtOnBehalfOf.Text = currentProfile.GetOnBehalfOf();

            if (currentProfile.IsDefault())
                chkInRightClick.Checked = true;
            else
                chkInRightClick.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            currentProfile.SetName(txtProfileName.Text);
            currentProfile.SetServiceDocumentUri(txtServiceDocumentUri.Text);
            currentProfile.SetDepositUri(txtDefaultDepositUri.Text);
            currentProfile.SetUsername(txtUsername.Text);
            //currentProfile.SetPassword(txtPassword.Text);
            currentProfile.SetFinalState(cmbAutoState.Text);
            currentProfile.SetMetadataInclusion(cmdMetadata.Text);
            currentProfile.SetPackaging(txtPackaging.Text);
            currentProfile.SetOnBehalfOf(txtOnBehalfOf.Text);

            if (chkInRightClick.Checked)
                currentProfile.SetIsDefault(true);
            else
                currentProfile.SetIsDefault(false);

            if (profiles.ContainsKey(currentProfile.GetId()))
                profiles[currentProfile.GetId()] = currentProfile;
            else
                profiles.Add(currentProfile.GetId(), currentProfile);

            Profile.writeProfiles(Program.defaultProfileDataPath, profiles.Values.ToList());
            listProfiles();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistryKey bk = Registry.ClassesRoot;
            RegistryKey sk = bk.CreateSubKey("*\\shell\\RightClickDeposit");
            ModifyRegistry reg = new ModifyRegistry();
            reg.BaseRegistryKey = bk;
            reg.SubKey = "*\\shell\\RightClickDeposit";
            reg.Write("MUIVerb", "Deposit to");
            reg.Write("Icon", Application.StartupPath + "\\icons\\rcd.ico");
            string commandList = "";
            foreach(KeyValuePair<int,Profile> p in profiles)
            {
                if (p.Value.IsDefault())
                {
                    string commandName = "RightClickDeposit.deposit." + p.Value.GetId();
                    commandList += commandName + "; ";
                    RegistryKey cbk = Registry.LocalMachine;
                    RegistryKey ck = cbk.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell\\" + commandName);
                    ModifyRegistry regcmd = new ModifyRegistry();
                    regcmd.BaseRegistryKey = cbk;
                    regcmd.SubKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell\\" + commandName;
                    regcmd.Write("MUIVerb", p.Value.GetName());
                    regcmd.Write("Icon", Application.StartupPath + "\\icons\\add.ico");
                    //MessageBox.Show(regcmd.Read("MUIVerb"));
                    RegistryKey cck = cbk.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell\\" + commandName + "\\command");
                    regcmd.SubKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell\\" + commandName + "\\command";
                    regcmd.Write("", Application.StartupPath + "\\RightClickDeposit.exe " + p.Value.GetId() + " create \"%1\"");
                }
            }


            RegistryKey ubk = Registry.LocalMachine;
            RegistryKey uk = ubk.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell\\RightClickDeposit.update");
            ModifyRegistry regu = new ModifyRegistry();
            regu.BaseRegistryKey = ubk;
            regu.SubKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell\\RightClickDeposit.update";
            regu.Write("MUIVerb", "Update or delete previous deposits");
            regu.Write("Icon", Application.StartupPath + "\\icons\\update.ico");
           
            RegistryKey cuk = ubk.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell\\RightClickDeposit.update\\command");
            regu.SubKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell\\RightClickDeposit.update\\command";
            regu.Write("", Application.StartupPath + "\\RightClickDeposit.exe 0 update \"%1\"");
                
            RegistryKey pbk = Registry.LocalMachine;
            RegistryKey pk = pbk.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell\\RightClickDeposit.profiles");
            ModifyRegistry regp = new ModifyRegistry();
            regp.BaseRegistryKey = pbk;
            regp.SubKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell\\RightClickDeposit.profiles";
            regp.Write("MUIVerb", "Manage profiles (admin-only)");
            regp.Write("Icon", Application.StartupPath + "\\icons\\manage.ico");

            RegistryKey puk = pbk.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell\\RightClickDeposit.profiles\\command");
            regp.SubKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell\\RightClickDeposit.profiles\\command";
            regp.Write("", Application.StartupPath + "\\RightClickDeposit.exe profiles");

            commandList += "RightClickDeposit.update; RightClickDeposit.profiles";

            reg.Write("SubCommands", commandList);

            MessageBox.Show("Right-click explorer context menus updated successfully", "Menu update successful");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            currentProfile = new Profile();
            int maxId = 0;
            if (profiles.Count > 0)
                maxId = profiles.Max(kvp => kvp.Key);
            int id = maxId + 1;
            currentProfile.SetId(id);
            drawProfileForm();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Profile p = getSelectedProfile();

            if (p != null)
            {
                profiles.Remove(p.GetId());
            }

            Profile.writeProfiles(Program.defaultProfileDataPath, profiles.Values.ToList());
            listProfiles();
        }
    }
}
