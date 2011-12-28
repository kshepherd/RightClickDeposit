using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace org.swordapp.client.windows.libraries
{
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
        private string packaging;
        private string onBehalfOf;

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

        public string GetPackaging()
        {
            return packaging;
        }

        public string GetOnBehalfOf()
        {
            return onBehalfOf;
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

        public void SetIsDefault(bool isDefault)
        {
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

        public void SetPackaging(string packaging)
        {
            this.packaging = packaging;
        }

        public void SetOnBehalfOf(string onBehalfOf)
        {
            this.onBehalfOf = onBehalfOf;
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

            XmlNode packagingElement = profileDoc.CreateElement("Packaging");
            packagingElement.InnerText = this.packaging;
            rootNode.AppendChild(packagingElement);

            XmlNode onBehalfOfElement = profileDoc.CreateElement("OnBehalfOf");
            packagingElement.InnerText = this.onBehalfOf;
            rootNode.AppendChild(onBehalfOfElement);

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
                System.IO.File.WriteAllLines(path, new string[1] { "<Profiles></Profiles>" });
            }

            foreach (XmlNode profileNode in profilesDoc.GetElementsByTagName("Profile"))
            {
                p = new Profile();

                foreach (XmlNode profileEl in profileNode.ChildNodes)
                {
                    switch (profileEl.Name)
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
                        case "Packaging":
                            p.SetPackaging(profileEl.InnerText);
                            break;
                        case "OnBehalfOf":
                            p.SetOnBehalfOf(profileEl.InnerText);
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
}
