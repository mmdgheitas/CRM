using EASendMail;
using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Interface.Utilities
{
    public class mysendemail
    {
        private EmailSettingEnt _emailSetting;
        public mysendemail(EmailSettingEnt _emailSetting)
        {
            this._emailSetting = _emailSetting;
        }
        public string SendMail(string subject, string body, params string[] toMails)
        {

            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");
                SmtpClient oSmtp = new SmtpClient();

                // Set sender email address, please change it to yours
                oMail.From = _emailSetting.ReciverEmail;
                // Set recipient email address, please change it to yours
                oMail.To = toMails.FirstOrDefault();
                // Set email subject
                oMail.Subject = "test email from c# project";

                // Set email body
                oMail.TextBody = "this is a test email sent from c# project, do not reply";

                // Your SMTP server address
                SmtpServer oServer = new SmtpServer(_emailSetting.SmtpHost);
                // User and password for ESMTP authentication, if your server doesn't require
                // User authentication, please remove the following codes.
                oServer.User = _emailSetting.EmailAddress;
                oServer.Password = _emailSetting.Password;

                // If your smtp server requires TLS connection, please add this line
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                // If your smtp server requires implicit SSL connection on 465 port, please add this line
                oServer.Port = _emailSetting.PortNumber;
                // oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;


                try
                {
                    oSmtp.SendMailToQueue(oServer, oMail);
   

                }
                catch (Exception ep)
                {
                    Console.WriteLine("failed to send email with the following error:");
                    Console.WriteLine(ep.Message);
                }


                return "success";
            }
            catch (Exception ex)
            {

                return "error";
            }
        }
    }
}