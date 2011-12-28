using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Security.Principal;
using System.Threading;
using System.Net;
using System.Globalization;
using System.Security.Cryptography;
using System.Resources;
using System.Reflection;
using System.Security.Permissions;
using System.Diagnostics;
using org.swordapp.client.windows.libraries;

namespace RightClickDeposit
{
    

    public partial class frmMain : Form
    {
        private SWORDClient sc = null;
        private string file;
        private string filename;
        private string filemd5;
        private DateTime filemodified;
        private long filesize;
        private string filemime;
        private string username = "";
        private bool includeMetadata = false;
        private Profile profile;
        private string action = "create";
        private string endpoint = null;
        private int depositId = -1;

        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(string file, Profile profile, string action, string endpoint, int depositId)
        {
            InitializeComponent();
            this.profile = profile;
            
                this.action = action;
                this.endpoint = endpoint;
                this.depositId = depositId;
            

            loadFile(file);

            if (profile.GetUsername() == null || "".Equals(profile.GetUsername()))
            {
                try
                {
                    this.username = WindowsIdentity.GetCurrent().Name.Split('\\')[1];
                }
                catch (Exception le)
                {
                    MessageBox.Show("Could not get username.\nReason: " + le.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else
            {
                this.username = profile.GetUsername();
            }

            sc = new SWORDClient(profile.GetServiceDocumentUri(), profile.GetUsername(), profile.GetPassword(), profile.GetOnBehalfOf());
            List<string> mimes = getAcceptableMimes();
            populateMimes(mimes);
            
            drawForm();
        }

        private void loadFile(string file)
        {
            this.file = file;
            try
            {
                FileInfo fi = new FileInfo(file);
                FileStream fs = new FileStream(file, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] checksum = md5.ComputeHash(fs);
                fs.Close();
                filename = fi.Name;
                filesize = fi.Length;
                filemodified = fi.LastWriteTime;
                filemd5 = BitConverter.ToString(checksum);
                filemime = Utilities.GetMIMEType(filename);
            }
            catch (Exception fe)
            {
                MessageBox.Show("Could not read file: " + file + "\nReason: " + fe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            drawForm();
        }

        private void drawForm() 
        {
            lblFilePath.Text = file;
            lblFileSize.Text = filesize.ToString();
            lblLastModified.Text = filemodified.ToString();
            lblChecksum.Text = filemd5;
            toolStripProgressBar.Maximum = 100;
            toolStripProgressBar.Minimum = 0;
            lblEndpoint.Text = endpoint;

            switch (action)
            {
                case "create":
                    lblActionMessage.Text = "Create and deposit new resource in:";
                    lblEndpoint.Text = profile.GetDepositUri();
                    break;
                case "update":
                   // pictureAction.LoadAsync("Resources/repository-96.png");
                    lblActionMessage.Text = "Update content of existing resource at:";
                    ((Control)tabControl1.TabPages[1]).Enabled = false;
                    break;
                case "delete":
                    lblFilePath.Text = "-";
                    lblFileSize.Text = "-";
                    lblLastModified.Text = "-";
                    lblChecksum.Text = "-";
                    cmbMime.Enabled = false;
                    lblActionMessage.Text = "Delete existing resource at:";
                    ((Control)tabControl1.TabPages[1]).Enabled = false;
                    btnUpload.Text = "Delete";
                    break;
                default:
                    lblActionMessage.Text = "Create and deposit new resource in:";
                    break;
            }
            
        }

        private void populateMimes(List<string> allowedMimes)
        {
            if (allowedMimes.Count > 0)
            {
                foreach (string allowedMime in allowedMimes)
                {
                    cmbMime.Items.Add(allowedMime);
                }
                if (allowedMimes.Contains(filemime))
                    cmbMime.SelectedItem = filemime;
            }
            else
            {
                cmbMime.Enabled = false;
            }
        }

        private List<string> getAcceptableMimes()
        {
            List<string> acceptableMimes = new List<string>();
            XmlDocument sd = sc.GetServiceDocument(profile.GetServiceDocumentUri());
            if (sd != null)
                
            {
                XmlNodeList mimeNodes = sd.GetElementsByTagName("accept");
                foreach (XmlNode mimeNode in mimeNodes)
                {
                    if(!acceptableMimes.Contains(mimeNode.InnerText))
                        acceptableMimes.Add(mimeNode.InnerText);
                }
            }

            if (acceptableMimes.Count == 0)
            {
                // If no acceptableMimes found, fudge it.
                acceptableMimes.Add("application/pdf");
                acceptableMimes.Add("application/zip");
                acceptableMimes.Add("text/plain");
                acceptableMimes.Add("image/gif");
                acceptableMimes.Add("image/png");
                acceptableMimes.Add("image/jpeg");
                acceptableMimes.Add("video/mpeg");
                acceptableMimes.Add("audio/mpeg");
                acceptableMimes.Add("application/doc");
                acceptableMimes.Add("application/docx");
                acceptableMimes.Add("application/xls");
                acceptableMimes.Add("application/xlsx");
            }

            return acceptableMimes;
        }

        void UploadProgressHandler(object sender, UploadProgressChangedEventArgs e)
        {
            double sent = ((double)e.BytesSent / 1024 / 1024);
            double total = ((double)e.TotalBytesToSend / 1024 / 1024);

            int realProgress = e.ProgressPercentage != 100 ? e.ProgressPercentage * 2 : e.ProgressPercentage;
            if (realProgress < 0 || realProgress > 100)
                realProgress = 0;
            string status = "Uploaded "
                + sent.ToString("F", CultureInfo.InvariantCulture) + " of "
                + total.ToString("F", CultureInfo.InvariantCulture) + "MB. "
                + " (" + realProgress + "%)";

            toolStripStatusLabel.Text = status;
            toolStripProgressBar.Value = realProgress;
          
        }

        void UploadDataProgressHandler(object sender, UploadProgressChangedEventArgs e)
        {
            double sent = ((double)e.BytesSent / 1024 / 1024);
            double total = ((double)e.TotalBytesToSend / 1024 / 1024);

            int realProgress = e.ProgressPercentage != 100 ? e.ProgressPercentage * 2 : e.ProgressPercentage;
            if (realProgress < 0 || realProgress > 100)
                realProgress = 0;
            string status = "Sending data to remote server... ";

            toolStripStatusLabel.Text = status;
            toolStripProgressBar.Value = realProgress;

        }


        void UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            string seIri = (string) e.UserState;
            toolStripProgressBar.Value = 100;
            switch (profile.GetFinalState())
            {
                case "Ask":
                    InProgressDialog(seIri);
                    break;
                case "In Progress":
                    UploadCompleteDialog(seIri);
                    break;
                case "Complete":
                    UploadCompleteDialog(seIri);
                    break;
                default:
                    InProgressDialog(seIri);
                    break;
            }
        }

        void UploadDataCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            MessageBox.Show("Your previous deposit was successfully deleted");
            toolStripProgressBar.Value = 100;
            toolStripStatusLabel.Text = "Delete successful ";
        }

        void AtomEntryCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            toolStripProgressBar.Value = 100;
            toolStripStatusLabel.Text = "Atom entry created successfully";
        }

        void DepositCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            toolStripProgressBar.Value = 100;
            toolStripStatusLabel.Text = "Deposit complete, 'in progress' is set to 'false'";
        }

        private void UploadFile(string file, string emIri, string seIri, string packaging, string contentType)
        {
            sc = new SWORDClient(emIri, profile.GetUsername(), profile.GetPassword(), profile.GetOnBehalfOf());
            sc.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressHandler);
            sc.UploadFileCompleted += new UploadFileCompletedEventHandler(UploadFileCompleted);
            sc.Headers["Content-Disposition"] = "attachment; filename=" + filename + "; charset=utf-8";
            sc.Headers["Content-Type"] = contentType;
            sc.Headers["X-Packaging"] = packaging;
            sc.Headers["Metadata-Relevant"] = "false";

            try
            {
                sc.UploadFileAsync(new Uri(emIri), "PUT", file, seIri);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void DeleteResource(string emIri, string seIri)
        {
            sc = new SWORDClient(seIri, profile.GetUsername(), profile.GetPassword(), profile.GetOnBehalfOf());
            sc.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressHandler);
            sc.UploadDataCompleted += new UploadDataCompletedEventHandler(UploadDataCompleted);

            try
            {
                sc.UploadDataAsync(new Uri(emIri), "DELETE", new byte[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        

        private void UploadCompleteDialog(string seIri)
        {
            // Ask if we should set In-Progress to false
            string messageBoxText = "Your deposit was completed successfully";

            string caption = "Deposit complete";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            // Display message box
            
            switch (profile.GetFinalState())
            {
                case "In Progress":
                    messageBoxText = "Your deposit was successful and has been left 'in progress' for later completion.";
                    break;
                case "Complete":
                    try
                    {
                        if (seIri != null && !"".Equals(seIri))
                        {
                            //client.setInProgress("false", seIri);
                            sc.CompleteDeposit(seIri, DepositCompleted, UploadDataProgressHandler);

                        }
                        else
                        {
                            MessageBox.Show("No SE-IRI");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not set 'in progress' attribute to 'false'.\nReason: " + ex.Message);
                    }
                    break;
                default:
                    break;
            }

            DialogResult completion = MessageBox.Show(messageBoxText, caption, buttons, icon);


            toolStripStatusLabel.Text = "Deposit completed successfully";
           // Application.Exit();
            // saveDepositInfo(emIri, seIri, stateIri, filename);
        }

        private void InProgressDialog(string seIri)
        {
            // Ask if we should set In-Progress to false
            string messageBoxText = "Your deposit was successful and is marked as 'in-progress' by the remote repository.\n" +
                "You can complete your deposit now or leave it in-progress.\n\nDo you wish to complete your deposit?";
                

            string caption = "Complete deposit?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            // Display message box
            DialogResult completion = MessageBox.Show(messageBoxText, caption, buttons, icon);

            // Process message box results
            switch (completion)
            {
                case DialogResult.Yes:
                    try
                    {
                        if (seIri != null && !"".Equals(seIri))
                        {
                            //client.setInProgress("false", seIri);
                            sc.CompleteDeposit(seIri, DepositCompleted, UploadDataProgressHandler);
                        }
                        else
                        {
                            MessageBox.Show("No SE-IRI");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not set 'in progress' attribute to 'false'.\nReason: " + ex.Message);
                    }
                    break;
                case DialogResult.No:
                    // Do nothing
                    break;

                default:
                    // Do nothing
                    break;
            }

            toolStripStatusLabel.Text = "Deposit completed successfully";
            Application.Exit();
           // saveDepositInfo(emIri, seIri, stateIri, filename);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            //toolStripStatusLabel.Text = "Preparing deposit...";
            //toolStripProgressBar.Value = 0;

            if (profile.GetUsername() == null || "".Equals(profile.GetUsername()) ||
                profile.GetPassword() == null || "".Equals(profile.GetPassword()))
            {
                frmLogin loginDialog = new frmLogin();

                if(profile.GetUsername() != null && !"".Equals(profile.GetUsername()))
                {
                    loginDialog.SetUsername(profile.GetUsername());
                }
               
                if ( loginDialog.ShowDialog() == DialogResult.OK)
                {
                    profile.SetUsername(loginDialog.GetUsername());
                    profile.SetPassword(loginDialog.GetPassword());
                    username = profile.GetUsername();
                    //client = new SwordClientHandler(profile.GetUsername(), profile.GetPassword(), profile.GetDepositUri());
                }
            }

            string emIri = null;
            string seIri = null;
            string stateIri = null;
            
            if (action.Equals("create"))
            {
                sc = new SWORDClient(profile.GetDepositUri(), profile.GetUsername(), profile.GetPassword(), profile.GetOnBehalfOf());
                XmlDocument receipt = sc.PostAtom(getAtomEntry());
                //MessageBox.Show("RESPONSE\n" + receipt);

                foreach (XmlNode link in receipt.GetElementsByTagName("link"))
                {
                    switch (link.Attributes["rel"].Value)
                    {
                        case "statement":
                            stateIri = link.Attributes["href"].Value;
                            break;
                        case "edit":
                            seIri = link.Attributes["href"].Value;
                            break;
                        case "edit-media":
                            emIri = link.Attributes["href"].Value;
                            break;
                        case "add":
                            break;

                        default:
                            break;
                    }
                }
            }
            else
            {
                emIri = endpoint;
                seIri = Deposit.loadDeposits(Program.userDataPath)[depositId].GetSeIri();
            }

            // Did we successfully retrieve an EM-IRI / SE-IRI?
            if (emIri != null && !"".Equals(emIri))
            {
                string contentType = filemime;
                if(cmbMime.Text != null && !"".Equals(cmbMime.Text))
                   contentType  = cmbMime.Text;
                
                if(action.Equals("delete"))
                {
                    DeleteResource(endpoint, seIri);
                    saveDepositInfo(emIri, seIri, stateIri, filename);
                }
                else
                {
                    UploadFile(file, emIri, seIri, profile.GetPackaging(), contentType);
                    saveDepositInfo(emIri, seIri, stateIri, filename);
                }
                
            }

        }

        private string getAtomEntry()
        {
            // Is this a good default? Just for atom purposes
            
            string metadata = "";
            string atomTitle = filename;

            if (includeMetadata)
            {
                string title = txtDCTitle.Text;
                atomTitle = title;
                DateTime date = dateTimePicker.Value;
                string dcAbstract = txtDCAbstract.Text;
                
                string[] creator = txtDCCreator.Lines;

                if(title != null && !"".Equals(title))
                    metadata += "<dcterms:title>" + title + "</dcterms:title>";

                if (date != null)
                    metadata += "<dcterms:date>" + String.Format("{0:s}", date) + "</dcterms:date>";

                foreach (string c in creator)
                {
                    metadata += "<dcterms:creator>" + c + "</dcterms:creator>";
                }

                if (dcAbstract != null && !"".Equals(dcAbstract))
                {
                    metadata += "<dcterms:abstract>" + dcAbstract + "</dcterms:abstract>";
                }
            }

            string atomEntry = "<?xml version=\"1.0\"?>" +
                                "<entry xmlns=\"http://www.w3.org/2005/Atom\" xmlns:dcterms=\"http://purl.org/dc/terms/\">" +
                                "<title>" + atomTitle + "</title>" +
                                "<id>" + filemd5.ToLower() + "</id>" +
                                "<updated>" + String.Format("{0:s}", DateTime.Now) + "</updated>" +
                                "<author><name>" + username + "</name></author>";
            atomEntry += metadata; 
            atomEntry += "</entry>\n";

            return atomEntry;
        }

        private void saveDepositInfo(string emIri, string seIri, string stateIri, string filename)
        {
            Dictionary<int, Deposit> deposits = Deposit.loadDeposits(Program.userDataPath);

            switch (action)
            {
                case "create":
                    int maxId = 0;
                    if(deposits.Count > 0)
                        maxId = deposits.Max(kvp => kvp.Key);
                    int id = maxId + 1;
                    Deposit deposit = new Deposit(id, profile.GetId(), filename, filesize, filemd5, DateTime.Now,
                        seIri, emIri, "stateIri", true, new XmlDocument(), profile.GetPackaging());
                    deposits.Add(id, deposit);
                    break;
                case "update":
                    deposits[depositId].SetFile(filename);
                    deposits[depositId].SetContentLength(filesize);
                    deposits[depositId].SetChecksum(filemd5);
                    deposits[depositId].SetProfile(profile.GetId());
                    deposits[depositId].SetUpdated(DateTime.Now);
                    deposits[depositId].SetPackaging(profile.GetPackaging());
                    
                    break;
                case "delete":
                    deposits.Remove(depositId);
                    break;
                default:
                    break;
            }
            
            Deposit.writeDeposits(Program.userDataPath, deposits.Values.ToList());

        }

        private void chkDublinCore_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDublinCore.Checked)
                enableMetadataForm();
            else
                disableMetadataForm();
        }

        private void enableMetadataForm()
        {
            lblDCTitle.Enabled = true;
            txtDCTitle.Enabled = true;
            lblDCCreator.Enabled = true;
            txtDCCreator.Enabled = true;
            lblDCDate.Enabled = true;
            dateTimePicker.Enabled = true;
            lblDCAbstract.Enabled = true;
            txtDCAbstract.Enabled = true;

            includeMetadata = true;

            if ("".Equals(txtDCTitle.Text))
            {
                txtDCTitle.Text = filename;
            }

            if ("".Equals(txtDCCreator.Text))
            {
                txtDCCreator.Text = username;
            }

            
        }

        private void disableMetadataForm()
        {
            lblDCTitle.Enabled = false;
            lblDCCreator.Enabled = false;
            txtDCCreator.Enabled = false;
            txtDCTitle.Enabled = false;
            lblDCDate.Enabled = false;
            dateTimePicker.Enabled = false;
            lblDCAbstract.Enabled = false;
            txtDCAbstract.Enabled = false;

            includeMetadata = false;
        }

        private void chkDublinCore_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkDublinCore.Checked)
                enableMetadataForm();
            else
                disableMetadataForm();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblFilePathLabel_Click(object sender, EventArgs e)
        {

        }

        private void chooseFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            loadFile(openFileDialog.FileName);
        }

        private void depositProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void manageProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process rcdpm = new Process();
            rcdpm.StartInfo.FileName = Application.StartupPath + "\\rcdpm.exe";
            rcdpm.StartInfo.Arguments = Program.defaultProfileDataPath;
            rcdpm.Start();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

    }
}
