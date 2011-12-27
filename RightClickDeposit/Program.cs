using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using uk.ac.soton.ses;

namespace RightClickDeposit
{
    
    public class FileUpload
    {
        private SwordClientHandler c;
        private string emIri;
        private string file;
        private string packaging;
        private string contentType;
        private UploadProgress p;

        public FileUpload(SwordClientHandler c, string file, string emIri, string packaging, string contentType, UploadProgress p)
        {
            this.c = c;
            this.file = file;
            this.emIri = emIri;
            this.packaging = packaging;
            this.contentType = contentType;
            this.p = p;
        }

        public void doUpload()
        {
            string responseCode = c.updateFileInResource(file, emIri, packaging, contentType, p);
            
        }

    };
     

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
           //string file = null;
           //string action = null;
           string endpoint = null;
           int depositId = -1;
           Profile currentProfile = null;
           Dictionary<int, Profile> profiles = Profile.loadProfiles(defaultProfileDataPath);
           Dictionary<int, Deposit> deposits = Deposit.loadDeposits(userDataPath);

           Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);

           if (profiles.Count == 0)
           {
               MessageBox.Show("No profiles were found. Launching profile configuration utility");
               Application.Run(new frmProfiles());
           }
           else
           {

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

    public class Profile
    {
        private int id;
        private string name;
        private string sdIri;
        private string depositIri;
        private bool isDefault;
        private string username;
        private string password;
        private string finalState = "Ask";
        private string metadataInclusion = "Optional";

        public Profile()
        {
        }

        public int GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public string GetServiceDocumentUri()
        {
            return sdIri;
        }

        public string GetDepositUri()
        {
            return depositIri;
        }

        public bool IsDefault()
        {
            return isDefault;
        }

        public string GetUsername()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }

        public string GetFinalState()
        {
            return finalState;
        }

        public string GetMetadataInclusion()
        {
            return metadataInclusion;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetServiceDocumentUri(string sdIri)
        {
            this.sdIri = sdIri;
        }

        public void SetDepositUri(string depositIri)
        {
            this.depositIri = depositIri;
        }
        
        public void SetIsDefault(bool isDefault) {
            this.isDefault = isDefault;
        }

        public void SetUsername(string username)
        {
            this.username = username;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public void SetFinalState(string finalState)
        {
            this.finalState = finalState;
        }

        public void SetMetadataInclusion(string metadataInclusion)
        {
            this.metadataInclusion = metadataInclusion;
        }

        public XmlDocument marshall()
        {
            XmlDocument profileDoc = new XmlDocument();
            XmlNode rootNode = profileDoc.CreateElement("Profile");
            
            XmlNode idElement = profileDoc.CreateElement("ID");
            idElement.InnerText = this.id.ToString();
            rootNode.AppendChild(idElement);

            XmlNode nameElement = profileDoc.CreateElement("Name");
            nameElement.InnerText = this.name;
            rootNode.AppendChild(nameElement);

            XmlNode sdElement = profileDoc.CreateElement("ServiceDocumentUri");
            sdElement.InnerText = this.sdIri;
            rootNode.AppendChild(sdElement);

            XmlNode depositElement = profileDoc.CreateElement("DefaultDepositUri");
            depositElement.InnerText = this.depositIri;
            rootNode.AppendChild(depositElement);

            XmlNode isDefaultElement = profileDoc.CreateElement("Default");
            isDefaultElement.InnerText = this.isDefault.ToString();
            rootNode.AppendChild(isDefaultElement);

            XmlNode usernameElement = profileDoc.CreateElement("Username");
            usernameElement.InnerText = this.username;
            rootNode.AppendChild(usernameElement);

            XmlNode passwordElement = profileDoc.CreateElement("Password");
            passwordElement.InnerText = this.password;
            rootNode.AppendChild(passwordElement);

            XmlNode stateElement = profileDoc.CreateElement("FinalState");
            stateElement.InnerText = this.finalState;
            rootNode.AppendChild(stateElement);

            XmlNode metadataElement = profileDoc.CreateElement("MetadataInclusion");
            metadataElement.InnerText = this.metadataInclusion;
            rootNode.AppendChild(metadataElement);

            profileDoc.AppendChild(rootNode);

            return profileDoc;

        }

        public static void writeProfiles(string path, List<Profile> profiles)
        {
            XmlDocument profilesDoc = new XmlDocument();
            XmlNode rootNode = profilesDoc.CreateElement("Profiles");
            

            foreach (Profile profile in profiles)
            {
                XmlDocument profileDoc = profile.marshall();
                rootNode.AppendChild(rootNode.OwnerDocument.ImportNode(profileDoc.DocumentElement, true));
            }

            profilesDoc.AppendChild(rootNode);

            profilesDoc.Save(path);
        }

        public static Dictionary<int, Profile> loadProfiles(string path)
        {
            
            Dictionary<int, Profile> profiles = new Dictionary<int, Profile>();
            Profile p = new Profile();
            XmlTextReader xr = new XmlTextReader(path);

            XmlDocument profilesDoc = new XmlDocument();
            try
            {
                profilesDoc.Load(path);
            }
            catch (FileNotFoundException fe)
            {
                System.IO.File.WriteAllLines(path, new string[1]{"<Profiles></Profiles>"});
            }

            foreach(XmlNode profileNode in profilesDoc.GetElementsByTagName("Profile"))
            {
                p = new Profile();

                foreach(XmlNode profileEl in profileNode.ChildNodes)
                {
                    switch(profileEl.Name)
                    {
                        case "ID":
                            p.SetId(int.Parse(profileEl.InnerText));
                            break;
                        case "Name":
                            p.SetName(profileEl.InnerText);
                            break;
                        case "ServiceDocumentUri":
                            p.SetServiceDocumentUri(profileEl.InnerText);
                            break;
                        case "DefaultDepositUri":
                            p.SetDepositUri(profileEl.InnerText);
                            break;
                        case "Default":
                            p.SetIsDefault(bool.Parse(profileEl.InnerText));
                            break;
                        case "Username":
                            p.SetUsername(profileEl.InnerText);
                            break;
                        case "Password":
                            p.SetPassword(profileEl.InnerText);
                            break;
                        case "FinalState":
                            p.SetFinalState(profileEl.InnerText);
                            break;
                        case "MetadataInclusion":
                            p.SetMetadataInclusion(profileEl.InnerText);
                            break;
                        default:
                            break;
                    }
                }
                profiles.Add(p.GetId(), p);
            }
            return profiles;
        }
    }

    public class Deposit
    {
        private int id;
        private int profile;
        private string seIri;
        private string emIri;
        private string stateIri;
        private string file;
        private string checksum;
        private long contentLength;
        private string packaging;
        private bool inProgress;
        private XmlDocument metadata;
        private DateTime updated;

        public Deposit()
        {
        }

        public Deposit(string seIri, string emIri, string file)
        {
            this.seIri = seIri;
            this.emIri = emIri;
            this.file = file;
         //   this.packaging = packaging;
         //   this.inProgress = inProgress;
         //   this.updated = updated;
        }

        public Deposit(int id, int profile, string file,
            long contentLength, string checksum, DateTime updated,
            string seIri, string emIri, string stateIri, bool inProgress,
            XmlDocument metadata, string packaging)
        {
            // Ignoring metadata, packaging and stateIri for now...
            this.id = id;
            this.profile = profile;
            this.file = file;
            this.contentLength = contentLength;
            this.checksum = checksum;
            this.updated = updated;
            this.seIri = seIri;
            this.emIri = emIri;
            this.inProgress = inProgress;
        }


        public int GetId()
        {
            return id;
        }

        public int GetProfile()
        {
            return profile;
        }

        public string GetFile()
        {
            return file;
        }

        public string GetChecksum()
        {
            return checksum;
        }

        public long GetContentLength()
        {
            return contentLength;
        }

        public DateTime GetUpdated()
        {
            return updated;
        }

        public string GetSeIri()
        {
            return seIri;
        }

        public string GetEmIri()
        {
            return emIri;
        }

        public string GetStateIri()
        {
            return stateIri;
        }

        public bool GetInProgress()
        {
            return inProgress;
        }

        public string GetFileName()
        {
            return file;
        }

        public XmlDocument GetMetadata()
        {
            return metadata;
        }

        public string GetPackaging()
        {
            return packaging;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetProfile(int profile)
        {
            this.profile = profile;
        }

        public void SetFile(string file)
        {
            this.file = file;
        }

        public void SetContentLength(long contentLength)
        {
            this.contentLength = contentLength;
        }

        public void SetUpdated(DateTime updated)
        {
            this.updated = updated;
        }

        public void SetChecksum(string checksum)
        {
            this.checksum = checksum;
        }

        public void SetSeIri(string seIri)
        {
            this.seIri = seIri;
        }

        public void SetEmIri(string emIri)
        {
            this.emIri = emIri;
        }

        public void SetStateIri(string stateIri)
        {
            this.stateIri = stateIri;
        }

        public void SetInProgress(bool inProgress)
        {
            this.inProgress = inProgress;
        }

        public void SetMetadata(XmlDocument metadata)
        {
            this.metadata = metadata;
        }

        public void SetPackaging(string packaging)
        {
            this.packaging = packaging;
        }

        public XmlDocument Marshall()
        {
            XmlDocument depositDoc = new XmlDocument();
            XmlNode rootNode = depositDoc.CreateElement("Deposit");

            XmlNode idElement = depositDoc.CreateElement("Id");
            idElement.InnerText = this.id.ToString();
            rootNode.AppendChild(idElement);

            XmlNode profileElement = depositDoc.CreateElement("Profile");
            profileElement.InnerText = this.profile.ToString();
            rootNode.AppendChild(profileElement);

            XmlNode fileElement = depositDoc.CreateElement("RemoteFilename");
            fileElement.InnerText = this.file;
            rootNode.AppendChild(fileElement);

            XmlNode md5Element = depositDoc.CreateElement("RemoteMd5");
            md5Element.InnerText = this.checksum;
            rootNode.AppendChild(md5Element);

            XmlNode sizeElement = depositDoc.CreateElement("RemoteFileSize");
            sizeElement.InnerText = this.contentLength.ToString();
            rootNode.AppendChild(sizeElement);

            XmlNode updatedElement = depositDoc.CreateElement("Updated");
            updatedElement.InnerText = this.updated.ToString();
            rootNode.AppendChild(updatedElement);

            XmlNode seElement = depositDoc.CreateElement("SeIri");
            seElement.InnerText = this.seIri;
            rootNode.AppendChild(seElement);

            XmlNode emElement = depositDoc.CreateElement("EmIri");
            emElement.InnerText = this.emIri;
            rootNode.AppendChild(emElement);

            XmlNode statementElement = depositDoc.CreateElement("StateIri");
            statementElement.InnerText = this.stateIri;
            rootNode.AppendChild(statementElement);

            XmlNode inProgressElement = depositDoc.CreateElement("InProgress");
            inProgressElement.InnerText = this.inProgress.ToString();
            rootNode.AppendChild(inProgressElement);

            //XmlNode metadataElement = depositDoc.CreateElement("Metadata");
            //metadataElement.AppendChild(metadataElement.OwnerDocument.ImportNode(metadata.DocumentElement, true));
            //rootNode.AppendChild(metadataElement);

            XmlNode packagingElement = depositDoc.CreateElement("Packaging");
            packagingElement.InnerText = this.packaging;
            rootNode.AppendChild(packagingElement);

            depositDoc.AppendChild(rootNode);

            return depositDoc;

        }

        public static void writeDeposits(string path, List<Deposit> deposits)
        {
            XmlDocument depositsDoc = new XmlDocument();
            XmlNode rootNode = depositsDoc.CreateElement("Deposits");


            foreach (Deposit deposit in deposits)
            {
                XmlDocument depositDoc = deposit.Marshall();
                rootNode.AppendChild(rootNode.OwnerDocument.ImportNode(depositDoc.DocumentElement, true));
            }

            depositsDoc.AppendChild(rootNode);

            depositsDoc.Save(path);
        }

        public static Dictionary<int, Deposit> loadDeposits(string path)
        {
            Dictionary<int, Deposit> deposits = new Dictionary<int, Deposit>();
            Deposit d = new Deposit();
            XmlTextReader xr = new XmlTextReader(path);

            XmlDocument depositsDoc = new XmlDocument();
            depositsDoc.Load(path);

            foreach (XmlNode depositNode in depositsDoc.GetElementsByTagName("Deposit"))
            {
                d = new Deposit();

                foreach (XmlNode depositEl in depositNode.ChildNodes)
                {
                    switch (depositEl.Name)
                    {
                        case "Id":
                            d.SetId(int.Parse(depositEl.InnerText));
                            break;
                        case "Profile":
                            d.SetProfile(int.Parse(depositEl.InnerText));
                            break;
                        case "RemoteFilename":
                            d.SetFile(depositEl.InnerText);
                            break;
                        case "RemoteMd5":
                            d.SetChecksum(depositEl.InnerText);
                            break;
                        case "RemoteFileSize":
                            d.SetContentLength(long.Parse(depositEl.InnerText));
                            break;
                        case "Updated":
                            d.SetUpdated(DateTime.Parse(depositEl.InnerText));
                            break;
                        case "SeIri":
                            d.SetSeIri(depositEl.InnerText);
                            break;
                        case "EmIri":
                            d.SetEmIri(depositEl.InnerText);
                            break;
                        case "StateIri":
                            d.SetStateIri(depositEl.InnerText);
                            break;
                        case "InProgress":
                            d.SetInProgress(bool.Parse(depositEl.InnerText));
                            break;
                        case "Metadata":
                            XmlDocument xd = new XmlDocument();
                            XmlNode xn = depositEl;
                            xd.AppendChild(xn);
                            d.SetMetadata(xd);
                            break;
                        case "Packaging":
                            d.SetPackaging(depositEl.InnerText);
                            break;
                        default:
                            break;
                    }
                }
                deposits.Add(d.GetId(), d);
            }
            return deposits;
        }

    }

    public static class Utilities
    {
      
        /* We use this rather crude-looking MIME lookup dictionary
         * to make sure we get 'simple' MIME strings, eg. application/zip for .zip
         * files instead of application/x-zip.
         * We also don't want to be reading in every file in case some are large.
         */
        private static readonly Dictionary<string, string> MIMETypesDictionary = new Dictionary<string, string>
      {
        {"ai", "application/postscript"},
        {"aif", "audio/x-aiff"},
        {"aifc", "audio/x-aiff"},
        {"aiff", "audio/x-aiff"},
        {"asc", "text/plain"},
        {"atom", "application/atom+xml"},
        {"au", "audio/basic"},
        {"avi", "video/x-msvideo"},
        {"bcpio", "application/x-bcpio"},
        {"bin", "application/octet-stream"},
        {"bmp", "image/bmp"},
        {"cdf", "application/x-netcdf"},
        {"cgm", "image/cgm"},
        {"class", "application/octet-stream"},
        {"cpio", "application/x-cpio"},
        {"cpt", "application/mac-compactpro"},
        {"csh", "application/x-csh"},
        {"css", "text/css"},
        {"dcr", "application/x-director"},
        {"dif", "video/x-dv"},
        {"dir", "application/x-director"},
        {"djv", "image/vnd.djvu"},
        {"djvu", "image/vnd.djvu"},
        {"dll", "application/octet-stream"},
        {"dmg", "application/octet-stream"},
        {"dms", "application/octet-stream"},
        {"doc", "application/msword"},
        {"dtd", "application/xml-dtd"},
        {"dv", "video/x-dv"},
        {"dvi", "application/x-dvi"},
        {"dxr", "application/x-director"},
        {"eps", "application/postscript"},
        {"etx", "text/x-setext"},
        {"exe", "application/octet-stream"},
        {"ez", "application/andrew-inset"},
        {"gif", "image/gif"},
        {"gram", "application/srgs"},
        {"grxml", "application/srgs+xml"},
        {"gtar", "application/x-gtar"},
        {"hdf", "application/x-hdf"},
        {"hqx", "application/mac-binhex40"},
        {"htm", "text/html"},
        {"html", "text/html"},
        {"ice", "x-conference/x-cooltalk"},
        {"ico", "image/x-icon"},
        {"ics", "text/calendar"},
        {"ief", "image/ief"},
        {"ifb", "text/calendar"},
        {"iges", "model/iges"},
        {"igs", "model/iges"},
        {"jnlp", "application/x-java-jnlp-file"},
        {"jp2", "image/jp2"},
        {"jpe", "image/jpeg"},
        {"jpeg", "image/jpeg"},
        {"jpg", "image/jpeg"},
        {"js", "application/x-javascript"},
        {"kar", "audio/midi"},
        {"latex", "application/x-latex"},
        {"lha", "application/octet-stream"},
        {"lzh", "application/octet-stream"},
        {"m3u", "audio/x-mpegurl"},
        {"m4a", "audio/mp4a-latm"},
        {"m4b", "audio/mp4a-latm"},
        {"m4p", "audio/mp4a-latm"},
        {"m4u", "video/vnd.mpegurl"},
        {"m4v", "video/x-m4v"},
        {"mac", "image/x-macpaint"},
        {"man", "application/x-troff-man"},
        {"mathml", "application/mathml+xml"},
        {"me", "application/x-troff-me"},
        {"mesh", "model/mesh"},
        {"mid", "audio/midi"},
        {"midi", "audio/midi"},
        {"mif", "application/vnd.mif"},
        {"mov", "video/quicktime"},
        {"movie", "video/x-sgi-movie"},
        {"mp2", "audio/mpeg"},
        {"mp3", "audio/mpeg"},
        {"mp4", "video/mp4"},
        {"mpe", "video/mpeg"},
        {"mpeg", "video/mpeg"},
        {"mpg", "video/mpeg"},
        {"mpga", "audio/mpeg"},
        {"ms", "application/x-troff-ms"},
        {"msh", "model/mesh"},
        {"mxu", "video/vnd.mpegurl"},
        {"nc", "application/x-netcdf"},
        {"oda", "application/oda"},
        {"ogg", "application/ogg"},
        {"pbm", "image/x-portable-bitmap"},
        {"pct", "image/pict"},
        {"pdb", "chemical/x-pdb"},
        {"pdf", "application/pdf"},
        {"pgm", "image/x-portable-graymap"},
        {"pgn", "application/x-chess-pgn"},
        {"pic", "image/pict"},
        {"pict", "image/pict"},
        {"png", "image/png"}, 
        {"pnm", "image/x-portable-anymap"},
        {"pnt", "image/x-macpaint"},
        {"pntg", "image/x-macpaint"},
        {"ppm", "image/x-portable-pixmap"},
        {"ppt", "application/vnd.ms-powerpoint"},
        {"ps", "application/postscript"},
        {"qt", "video/quicktime"},
        {"qti", "image/x-quicktime"},
        {"qtif", "image/x-quicktime"},
        {"ra", "audio/x-pn-realaudio"},
        {"ram", "audio/x-pn-realaudio"},
        {"ras", "image/x-cmu-raster"},
        {"rdf", "application/rdf+xml"},
        {"rgb", "image/x-rgb"},
        {"rm", "application/vnd.rn-realmedia"},
        {"roff", "application/x-troff"},
        {"rtf", "text/rtf"},
        {"rtx", "text/richtext"},
        {"sgm", "text/sgml"},
        {"sgml", "text/sgml"},
        {"sh", "application/x-sh"},
        {"shar", "application/x-shar"},
        {"silo", "model/mesh"},
        {"sit", "application/x-stuffit"},
        {"skd", "application/x-koan"},
        {"skm", "application/x-koan"},
        {"skp", "application/x-koan"},
        {"skt", "application/x-koan"},
        {"smi", "application/smil"},
        {"smil", "application/smil"},
        {"snd", "audio/basic"},
        {"so", "application/octet-stream"},
        {"spl", "application/x-futuresplash"},
        {"src", "application/x-wais-source"},
        {"sv4cpio", "application/x-sv4cpio"},
        {"sv4crc", "application/x-sv4crc"},
        {"svg", "image/svg+xml"},
        {"swf", "application/x-shockwave-flash"},
        {"t", "application/x-troff"},
        {"tar", "application/x-tar"},
        {"tcl", "application/x-tcl"},
        {"tex", "application/x-tex"},
        {"texi", "application/x-texinfo"},
        {"texinfo", "application/x-texinfo"},
        {"tif", "image/tiff"},
        {"tiff", "image/tiff"},
        {"tr", "application/x-troff"},
        {"tsv", "text/tab-separated-values"},
        {"txt", "text/plain"},
        {"ustar", "application/x-ustar"},
        {"vcd", "application/x-cdlink"},
        {"vrml", "model/vrml"},
        {"vxml", "application/voicexml+xml"},
        {"wav", "audio/x-wav"},
        {"wbmp", "image/vnd.wap.wbmp"},
        {"wbmxl", "application/vnd.wap.wbxml"},
        {"wml", "text/vnd.wap.wml"},
        {"wmlc", "application/vnd.wap.wmlc"},
        {"wmls", "text/vnd.wap.wmlscript"},
        {"wmlsc", "application/vnd.wap.wmlscriptc"},
        {"wrl", "model/vrml"},
        {"xbm", "image/x-xbitmap"},
        {"xht", "application/xhtml+xml"},
        {"xhtml", "application/xhtml+xml"},
        {"xls", "application/vnd.ms-excel"},                        
        {"xml", "application/xml"},
        {"xpm", "image/x-xpixmap"},
        {"xsl", "application/xml"},
        {"xslt", "application/xslt+xml"},
        {"xul", "application/vnd.mozilla.xul+xml"},
        {"xwd", "image/x-xwindowdump"},
        {"xyz", "chemical/x-xyz"},
        {"zip", "application/zip"}
      };

            public static string GetMIMEType(string fileName)
            {
                if (MIMETypesDictionary.ContainsKey(Path.GetExtension(fileName).Remove(0, 1)))
                {
                    return MIMETypesDictionary[Path.GetExtension(fileName).Remove(0, 1)];
                }
                return "application/octet-stream";
            }
        
    }
}
