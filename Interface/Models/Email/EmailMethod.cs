using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Implement;
using Infrastructure.Service.Interface;
using Interface.Repository;
using Interface.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interface.Models.Email
{
    public class EmailMethod :Controller
    {
        public ApplicationDbContext _context;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public RoleManager<IdentityRole> RoleManager { get; set; }

        private readonly IRepositoryBase<SettingEnt, byte> _settingRepo;
        private readonly IRepositoryBase<EmailSettingEnt, byte> _emailsettingRepo;

        public readonly ISettingService _settingService;

        public EmailMethod()
        {
            _settingRepo = new RepositoryBase<SettingEnt, byte>();
            _emailsettingRepo = new RepositoryBase<EmailSettingEnt, byte>();
  


            _context = new ApplicationDbContext();
        }
        public EmailMethod(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }



        public string SendEmailConfirmAgain(string userID, string email)
        {
            if (!_settingService.UseEmailService())
                return "سرویس ایمیل غیر فعال است";

            var callbackUrl = Url.Action("ConfirmEmail", "Account",
                  new { userId = userID, code = UserManager.GenerateEmailConfirmationToken(userID) }, protocol: Request.Url.Scheme);

            var EmailValue = new EmailValue();
            EmailValue.WebsiteName = _settingService.DefaultWebsiteName();

            EmailValue.HomePage = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
            EmailValue.Login = Url.Action("Login", "Account", null, protocol: Request.Url.Scheme);
            EmailValue.ButtonClick = callbackUrl;
            EmailValue.ButtonText = "لینک فعال سازی";
            EmailValue.EmailTitle = "ارسال دوباره تایید حساب کاربری";
            EmailValue.Content = "لطفا حساب کاربری خود را از طریق لینک فعال سازی زیر فعال کنید.";
            EmailValue.Phone = _settingService.WebsitePhoneNumber();
            EmailValue.LogoURL = _settingService.GetWebsiteLogo();
            var Content = this.RenderPartialToString("_MailSender", EmailValue);

            return
                 new MailSender(_settingService.DefaultEmailSetting()).SendMail(EmailValue.EmailTitle, Content, email);

        }
        public string SendPasswordReset(string userID, string email)
        {
            if (!_settingService.UseEmailService())
                return "سرویس ایمیل غیر فعال است";

            var callbackUrl = Url.Action("ResetPassword", "Account",
                  new { userId = userID, code = UserManager.GeneratePasswordResetToken(userID) }, protocol: Request.Url.Scheme);

            var EmailValue = new EmailValue();
            EmailValue.WebsiteName = _settingService.DefaultWebsiteName();

            EmailValue.HomePage = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
            EmailValue.Login = Url.Action("Login", "Account", null, protocol: Request.Url.Scheme);
            EmailValue.ButtonClick = callbackUrl;
            EmailValue.ButtonText = "تغییر رمز عبور";
            EmailValue.EmailTitle = "تغیر رمز عبور";
            EmailValue.Content = "لطفا رمز عبور خود را از طریق لینک زیر تغییر دهید.";
            EmailValue.Phone = _settingService.WebsitePhoneNumber();
            EmailValue.LogoURL = _settingService.GetWebsiteLogo();
            var Content = this.RenderPartialToString("_MailSender", EmailValue);

            return
                 new MailSender(_settingService.DefaultEmailSetting()).SendMail(EmailValue.EmailTitle, Content, email);

        }
        public string SendEmailConfirm(string userID, string email)
        {
            if (!_settingService.UseEmailService())
                return "سرویس ایمیل غیر فعال است";

            var callbackUrl = Url.Action("ConfirmEmail", "Account",
                           new { userId = userID, code = UserManager.GenerateEmailConfirmationToken(userID) }, protocol: Request.Url.Scheme);

            var EmailValue = new EmailValue();
            EmailValue.WebsiteName = _settingService.DefaultWebsiteName();

            EmailValue.HomePage = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
            EmailValue.Login = Url.Action("Login", "Account", null, protocol: Request.Url.Scheme);
            EmailValue.ButtonClick = callbackUrl;
            EmailValue.ButtonText = "تایید حساب کاربری";
            EmailValue.EmailTitle = "ارسال  تایید حساب کاربری";
            EmailValue.Content = "لطفا حساب کاربری خود را از طریق لینک فعال سازی زیر فعال کنید.";
            EmailValue.Phone = _settingService.WebsitePhoneNumber();
            EmailValue.LogoURL = _settingService.GetWebsiteLogo();
            var Content = this.RenderPartialToString("_MailSender", EmailValue);

            return
                 new MailSender(_settingService.DefaultEmailSetting()).SendMail(EmailValue.EmailTitle, Content, email);

        }
        public string SendEmail(string title, string content, params string[] email)
        {

            if (!_settingService.UseEmailService())
                return "سرویس ایمیل غیر فعال است";

            var EmailValue = new EmailValue();
            EmailValue.WebsiteName = _settingService.DefaultWebsiteName();

            EmailValue.HomePage = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
            EmailValue.Login = Url.Action("Login", "Account", null, protocol: Request.Url.Scheme);
            EmailValue.EmailTitle = title;
            EmailValue.Content = content;
            EmailValue.Phone = _settingService.WebsitePhoneNumber();
            EmailValue.LogoURL = _settingService.GetWebsiteLogo();

            var Content = this.RenderPartialToString("_MailSender", EmailValue);
            return
                 new MailSender(_settingService.DefaultEmailSetting()).SendMail(EmailValue.EmailTitle, Content, email);

        }

        public string SendEmailByUserID(string title, string content, string UserID)
        {
            if (!_settingService.UseEmailService())
                return "سرویس ایمیل غیر فعال است";

            string email = "";
            var appUser = _context.Users.Where(p => p.Id == UserID).FirstOrDefault();
            if (appUser != null)
                email =  appUser.Email;
            if (UserID == "Admin")
                email = _settingService.DefaultReciverEmail();

            var EmailValue = new EmailValue();
            EmailValue.WebsiteName = _settingService.DefaultWebsiteName();

            EmailValue.HomePage = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
            EmailValue.Login = Url.Action("Login", "Account", null, protocol: Request.Url.Scheme);
            EmailValue.EmailTitle = title;
            EmailValue.Content = content;
            EmailValue.Phone = _settingService.WebsitePhoneNumber();
            EmailValue.LogoURL = _settingService.GetWebsiteLogo();

            var Content = this.RenderPartialToString("_MailSender", EmailValue);
            return
                 new MailSender(_settingService.DefaultEmailSetting()).SendMail(EmailValue.EmailTitle, Content, email);

        }

        public string ChangeEmailConfirm(string userID, string email)
        {
            if (!_settingService.UseEmailService())
                return "سرویس ایمیل غیر فعال است";

            var callbackUrl = Url.Action("ConfirmChangeEmail", "Account",
                  new { userId = userID, code = UserManager.GenerateEmailConfirmationToken(userID) }, protocol: Request.Url.Scheme);

            var EmailValue = new EmailValue();
            EmailValue.WebsiteName = _settingService.DefaultWebsiteName();
            EmailValue.HomePage = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
            EmailValue.Login = Url.Action("Login", "Account", null, protocol: Request.Url.Scheme);
            EmailValue.ButtonClick = callbackUrl;
            EmailValue.ButtonText = "تایید تغییر ایمیل";
            EmailValue.EmailTitle = "ارسال  تایید تغییر ایمیل";
            EmailValue.Content = "لطفا ایمیل جدید خود را با کلیک بر روی لینک زیر تایید کنید.";
            EmailValue.Phone = _settingService.WebsitePhoneNumber();
            EmailValue.LogoURL = _settingService.GetWebsiteLogo();
            var Content = this.RenderPartialToString("_MailSender", EmailValue);

            return
                 new MailSender(_settingService.DefaultEmailSetting()).SendMail(EmailValue.EmailTitle, Content, email);
        }

    }
}