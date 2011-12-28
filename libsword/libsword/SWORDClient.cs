using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

namespace org.swordapp.client.windows.libraries
{
    public class SWORDClient : WebClient
    {
        private string endpoint;
        private string username;
        private string password;
        private string onBehalfOf;

        public SWORDClient()
        {
                
        }

        public SWORDClient(string endpoint, string username, string password, string onBehalfOf)
        {
            this.endpoint = endpoint;
            this.username = username;
            this.password = password;
            this.onBehalfOf = onBehalfOf;

            CredentialCache cc = new CredentialCache();
            cc.Add(new Uri(endpoint), "Basic", new NetworkCredential(username, password, "Authenticate"));
            this.Credentials = cc;
            this.Headers.Add(HttpRequestHeader.Authorization, "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(username + ':' + password)));
            if(onBehalfOf != null && !onBehalfOf.Equals(""))
            {
                this.Headers["On-Behalf-Of"] = onBehalfOf;
            }
        }

        public void SetEndpoint(string endpoint)
        {
            this.endpoint = endpoint;
        }

        public string GetEndpoint()
        {
            return endpoint;
        }

        public void SetUsername(string username)
        {
            this.username = username;
        }

        public string GetUsername()
        {
            return username;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public string GetPassword()
        {
            return password;
        }

        public void SetOnBehalfOf(string onBehalfOf)
        {
            this.onBehalfOf = onBehalfOf;
        }

        public string GetOnBehalfOf(string onBehalfOf)
        {
            return onBehalfOf;
        }


        public XmlDocument GetServiceDocument(string endpoint)
        {
            string response;
            XmlDocument receipt = new XmlDocument();
            try
            {
                response = DownloadString(new Uri(endpoint));
                receipt.LoadXml(response);
            }
            catch (Exception ex)
            {
                // Handle non-Webexception errors
            }
            return receipt;
        }

        public void PutFile(string file, string contentType, string packaging) //, UploadFileCompletedEventHandler completed, UploadProgressChangedEventHandler changed)
        {
          //  this.UploadFileCompleted += completed;
          //  this.UploadProgressChanged += changed;
            FileInfo fi = new FileInfo(file);
            string filename = fi.Name;
            this.Headers["Content-Disposition"] = "attachment; filename=" + filename + "; charset=utf-8";
            this.Headers["Content-Type"] = contentType;
            this.Headers["X-Packaging"] = packaging;
            this.Headers["Metadata-Relevant"] = "false";
            this.Headers["In-Progress"] = "true";

            try
            {
                UploadFileAsync(new Uri(endpoint), "PUT", filename);
            }
            catch (Exception ex)
            {
                // Exceptions are handled here, but not WebExceptions
            }
        }

        public void DeleteResource(string endpoint, UploadDataCompletedEventHandler completed, UploadProgressChangedEventHandler changed)
        {
            this.UploadDataCompleted += completed;
            this.UploadProgressChanged += changed;
            try
            {
                UploadDataAsync(new Uri(endpoint), "DELETE", new byte[0]);
            }
            catch (Exception ex)
            {
                // Exceptions are handled here, but not WebExceptions
            }
        }

        public XmlDocument PostAtom(string atom)
        {
            string response;
            XmlDocument receipt = new XmlDocument();
            this.Headers["Content-Type"] = "application/atom+xml;charset=utf-8;type=entry";
            this.Headers["In-Progress"] = "true";
            
            try
            {
                response = UploadString(new Uri(endpoint), "POST", atom);
                receipt.LoadXml(response);
            }
            catch (Exception ex)
            {
                response = "";
                // Exceptions are handled here, but not WebExceptions
            }

            return receipt;
        }

        public void CompleteDeposit(string endpoint, UploadDataCompletedEventHandler completed, UploadProgressChangedEventHandler changed)
        {
            this.Headers["In-Progress"] = "false";
            this.UploadDataCompleted += completed;
            this.UploadProgressChanged += changed;
            try
            {
                UploadDataAsync(new Uri(endpoint), "POST", new byte[0]);
            }
            catch (Exception ex)
            {
                // Exceptions are handled here, but not WebExceptions
            }
        }
    }
}
