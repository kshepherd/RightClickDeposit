using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace org.swordapp.client.windows.libraries
{
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
            try
            {
                depositsDoc.Load(path);
            }
            catch (FileNotFoundException fe)
            {
                System.IO.File.WriteAllLines(path, new string[1] { "<Deposits></Deposits>" });
            }
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
}
