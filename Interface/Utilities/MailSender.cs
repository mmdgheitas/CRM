using Infrastructure.Entity;
using Infrastructure.Service.Interface;
using Interface.Controllers;
using Interface.Data;
using Interface.Models;
using Interface.Repository;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Stimulsoft.System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interface.Utilities
{

    public interface IMailSender
    {
        Task<string> SendMail(string subject, string body, params string[] toMails);
        Task<string> SendMailWithMemberID(string subject, string body, string memberId, params string[] toMails);
         Task<string> SendMailAsync(string subject, string body, params string[] toMails);
        Task<string> SendMailByAttach(string subject, string body, string mail, params string[] attachments);

    }
    public class MailSender  : IMailSender
    {

        private EmailSettingEnt _emailSetting;
        public readonly ISettingService _settingService;
        public readonly IReportService _reportService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor context;
        public MailSender(ISettingService settingService, IReportService reportService, UserManager<ApplicationUser> uManager, IHttpContextAccessor _context)
        {
            this._settingService = settingService;
            this._reportService = reportService;
            userManager = uManager;
            context = _context;



        }


        public async Task<string> SendMail(string subject, string body, params string[] toMails)
        {
            try
            {
                _emailSetting = await _settingService.DefaultEmailSettingAsync();
                MailMessage mailMsg = new MailMessage();
                //--
                mailMsg.BodyEncoding = Encoding.UTF8;
                mailMsg.HeadersEncoding = Encoding.UTF8;
                mailMsg.SubjectEncoding = Encoding.UTF8;
                mailMsg.Priority = MailPriority.High;
                mailMsg.IsBodyHtml = true;
                //--
                SmtpClient SmtpServer = new SmtpClient(_emailSetting.SmtpHost);
                mailMsg.From = new MailAddress(_emailSetting.EmailAddress, _emailSetting.DisplayName);

                foreach (var mail in toMails)
                {
                    mailMsg.To.Add(new MailAddress(mail));
                }
                mailMsg.Subject = subject;
                mailMsg.Body = body;
                SmtpServer.Port = _emailSetting.PortNumber;
                SmtpServer.EnableSsl = _emailSetting.SSLEnable;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_emailSetting.EmailAddress, _emailSetting.Password);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

                SmtpServer.Send(mailMsg);

                #region Report Email To Data Base
                var CuretUserFullName = "";
                try
                {
                    if (context.HttpContext.User.Identity.IsAuthenticated)
                    {
                        CuretUserFullName = context.HttpContext.User.Identity.Name;
                    }
                }
                catch { }

                foreach (var mail in toMails)
                {
                    if (!string.IsNullOrEmpty(mail))
                    {
                        var ReportEmail = new ReportEmailEnt();
                        ReportEmail.Subject = subject;
                        ReportEmail.Content = body;
                        ReportEmail.ReciverEmail = mail;
                        ReportEmail.SentDate = DateTime.Now.SystemTime();
                        ReportEmail.Sender = _emailSetting.EmailAddress;

                        //ReportEmail.MemberID = HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.GetUserId();

                        ReportEmail.ReciverFullName = CuretUserFullName;
                        try
                        {
                            if (!await userManager.IsInRoleAsync((await userManager.FindByEmailAsync(mail)), "Administrator"))
                                _reportService.AddRepoEmail(ReportEmail);
                                
                        }
                        catch
                        {

                        }
                    }
                }
                #endregion

                return "success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public async Task<string> SendMailWithMemberID(string subject, string body, string memberId, params string[] toMails)
        {

            int step = 0;
            try
            {
                _emailSetting = await _settingService.DefaultEmailSettingAsync();
                MailMessage mailMsg = new MailMessage();
                //--
                mailMsg.BodyEncoding = Encoding.UTF8;
                mailMsg.HeadersEncoding = Encoding.UTF8;
                mailMsg.SubjectEncoding = Encoding.UTF8;
                mailMsg.Priority = MailPriority.High;
                mailMsg.IsBodyHtml = true;
                //--
                step++;
                SmtpClient SmtpServer = new SmtpClient(_emailSetting.SmtpHost);
                mailMsg.From = new MailAddress(_emailSetting.EmailAddress, _emailSetting.DisplayName);
                step++;
                foreach (var mail in toMails)
                {
                    mailMsg.To.Add(new MailAddress(mail));
                }
                step++;
                mailMsg.Subject = subject;
                mailMsg.Body = body;
                SmtpServer.Port = _emailSetting.PortNumber;
                SmtpServer.EnableSsl = _emailSetting.SSLEnable;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_emailSetting.EmailAddress, _emailSetting.Password);
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                step++;
                SmtpServer.Send(mailMsg);
                step++;
                #region Report Email To Data Base
                // var ControllerBase = new ControllerBaseController();
                // var IdentityManager = new IdentityManager(new ApplicationDbContext());
                var CuretUserFullName = "";
                try
                {
                    CuretUserFullName = context.HttpContext.User.Identity.Name;
                }
                catch { }

                foreach (var mail in toMails)
                {
                    var ReportEmail = new ReportEmailEnt();
                    ReportEmail.Subject = subject;
                    ReportEmail.Content = body;
                    ReportEmail.ReciverEmail = mail;
                    ReportEmail.SentDate = DateTime.Now.SystemTime();
                    ReportEmail.Sender = _emailSetting.EmailAddress;

                    //  ReportEmail.LibraryID = HttpContext.Current.User.LibraryId();
                    ReportEmail.MemberID = memberId;
                    ReportEmail.ReciverFullName = CuretUserFullName;
                    step++;
                    try
                    {
                        if (!await userManager.IsInRoleAsync((await userManager.FindByEmailAsync(mail)), "Administrator"))
                            _reportService.AddRepoEmail(ReportEmail);
                    }
                    catch
                    {
                        //   var a = ControllerBase._reportService.AddRepoEmail(ReportEmail);
                    }
                }
                #endregion
                step++;
                return "success";
            }
            catch (Exception ex)
            {
                return "STEP=" + step + "-" + ex.ToString();
            }

        }
        public async Task<string> SendMailAsync(string subject, string body, params string[] toMails)
        {
            try
            {

                _emailSetting = await _settingService.DefaultEmailSettingAsync();

                MailMessage mailMsg = new MailMessage();
                //--
                mailMsg.BodyEncoding = Encoding.UTF8;
                mailMsg.HeadersEncoding = Encoding.UTF8;
                mailMsg.SubjectEncoding = Encoding.UTF8;
                mailMsg.Priority = MailPriority.High;
                mailMsg.IsBodyHtml = true;
                //--
                SmtpClient SmtpServer = new SmtpClient(_emailSetting.SmtpHost);

                mailMsg.From = new MailAddress(_emailSetting.EmailAddress, _emailSetting.DisplayName);
                foreach (var mail in toMails)
                {
                    if (!string.IsNullOrEmpty(mail))
                        mailMsg.To.Add(new MailAddress(mail));
                }
                mailMsg.Subject = subject;
                mailMsg.Body = body;
                SmtpServer.Port = _emailSetting.PortNumber;

                SmtpServer.EnableSsl = _emailSetting.SSLEnable;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_emailSetting.EmailAddress, _emailSetting.Password);


                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

                var CuretUserFullName = "";
                try
                {
                    var rrr = context.HttpContext.User;
                    if (context.HttpContext.User.Identity.IsAuthenticated)
                        CuretUserFullName = context.HttpContext.User.Identity.Name;
                }
                catch { }


                await SmtpServer.SendMailAsync(mailMsg);


                #region Report Email To Data Base
          
              //  var CuretUserFullName = "";
                try
                {
                    if(context.HttpContext.User.Identity.IsAuthenticated)
                        CuretUserFullName = context.HttpContext.User.Identity.Name;
                }
                catch { }

                foreach (var mail in toMails)
                {
                    if (!string.IsNullOrEmpty(mail))
                    {
                        var ReportEmail = new ReportEmailEnt();
                        ReportEmail.Subject = subject;
                        ReportEmail.Content = body;
                        ReportEmail.ReciverEmail = mail;
                        ReportEmail.SentDate = DateTime.Now.SystemTime();
                        ReportEmail.Sender = _emailSetting.EmailAddress;

                        //ReportEmail.MemberID = HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.GetUserId();

                        ReportEmail.ReciverFullName = CuretUserFullName;
                        try
                        {
                            if (!await userManager.IsInRoleAsync((await userManager.FindByEmailAsync(mail)), "Administrator"))
                                _reportService.AddRepoEmail(ReportEmail);
                        }
                        catch
                        {
                          //  ControllerBase._reportService.AddRepoEmail(ReportEmail);
                        }
                    }
                }
                #endregion

                return "success";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }

        }


        public async Task<string> SendMailByAttach(string subject, string body, string mail, params string[] attachments)
        {
            try
            {

                _emailSetting = await _settingService.DefaultEmailSettingAsync();
                MailMessage mailMsg = new MailMessage();
                //--
                mailMsg.BodyEncoding = Encoding.UTF8;
                mailMsg.HeadersEncoding = Encoding.UTF8;
                mailMsg.SubjectEncoding = Encoding.UTF8;
                mailMsg.Priority = MailPriority.High;
                mailMsg.IsBodyHtml = true;
                //--
                SmtpClient SmtpServer = new SmtpClient(_emailSetting.SmtpHost);

                mailMsg.From = new MailAddress(_emailSetting.EmailAddress, _emailSetting.DisplayName);
                foreach (var attachment in attachments)
                {
                    mailMsg.Attachments.Add(new Attachment(attachment));
                }

                mailMsg.To.Add(new MailAddress(mail));

                mailMsg.Subject = subject;
                mailMsg.Body = body;
                SmtpServer.Port = _emailSetting.PortNumber;
                SmtpServer.Port = _emailSetting.PortNumber;

                SmtpServer.EnableSsl = _emailSetting.SSLEnable;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_emailSetting.EmailAddress, _emailSetting.Password);
                // SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;


                SmtpServer.Send(mailMsg);

                #region Report Email To Data Base
              
                var CuretUserFullName = "";
                try
                {

                    if(context.HttpContext.User.Identity.IsAuthenticated)
                        CuretUserFullName = context.HttpContext.User.Identity.Name;
                }
                catch { }

                var ReportEmail = new ReportEmailEnt();
                ReportEmail.Subject = subject;
                ReportEmail.Content = body;
                ReportEmail.ReciverEmail = mail;
                ReportEmail.SentDate = DateTime.Now.SystemTime();
                ReportEmail.Sender = _emailSetting.EmailAddress;
                //  ReportEmail.LibraryID = HttpContext.Current.User.LibraryId();

                ReportEmail.ReciverFullName = CuretUserFullName;
                try
                {
                 
                    if (!await userManager.IsInRoleAsync((await userManager.FindByEmailAsync(mail)), "Administrator"))
                        _reportService.AddRepoEmail(ReportEmail);
                }
                catch
                {
                 //   var a = ControllerBase._reportService.AddRepoEmail(ReportEmail);
                }

                #endregion

                return "success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}