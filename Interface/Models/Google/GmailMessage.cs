using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace Interface.Models.Google
{
    public class GmailMessagesService
    {
        public GmailMessagesService()
        {

        }

        public List<string> GetEmailSender(string userName,string password)
        {
            try
            {
                WebClient objclient = new WebClient();
                string response = null;
                XmlDocument xdoc = new XmlDocument();
                var listInbox = new List<string>();
                objclient.Credentials = new System.Net.NetworkCredential(userName.Replace("@gmail.com",""), password);
                response = Encoding.UTF8.GetString(objclient.DownloadData("https://mail.google.com/mail/feed/atom"));
                response = response.Replace("<feed version=\"0.3\" xmlns=\"http://purl.org/atom/ns#\"", "<feed>");
                xdoc.LoadXml(response);

          

                foreach (XmlNode node in xdoc.SelectNodes("/feed/entry"))
                {
                    var inner = node.SelectSingleNode("author").SelectSingleNode("email").InnerText;
                    if (inner.Contains("voice"))
                        listInbox.Add(inner);
                }
              return listInbox;
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }
    }

    public class GoogleVoiceViewModel
    {
        public string Text { get; set; }
        public string VoiceGmail { get; set; }
    }
    
}