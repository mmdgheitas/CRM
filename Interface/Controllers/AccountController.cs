using AutoMapper;
using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Implement;
using Infrastructure.Service.Interface;
using Interface.Models;
using Interface.Repository;
using Interface.Utilities;


using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using Microsoft.AspNetCore.WebUtilities;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

using Stimulsoft.Report.Mvc;

using Stimulsoft.Report;
using System.Drawing;
using System.Transactions;

using Interface.Models.Google;


using System.IO;
using System.Threading;

using Interface.Models.Factor;

using System.Net.Http;
using Interface.Models.Plaid;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Interface.Data;
using Microsoft.AspNetCore.Identity;
using Interface.Models.ContactUs;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Stimulsoft.System.Web;
using System.Security.Policy;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Http;
using static Utility;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json;
using Interface.Models.Email;
using Acklann.Plaid.Entity;
using Microsoft.EntityFrameworkCore;




namespace Interface.Controllers
{
    public class AccountController : Controller
    {


        private readonly IFactorService _factorService;
        private readonly IFactorService _factorService2;
        private readonly ICalendarService _calendarService;
        private readonly ICalendarService _calendarService2;
        private readonly IRepositoryBase<TimeCardEnt, long> _timeCartRepo;
        public readonly ITimeCardService _timeService;
        private readonly ICustomerService _customerService;
        private readonly ISettingService _settingService;
        private readonly ILogService _MsgService;

        private readonly UserManager<ApplicationUser> UserManager;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IMailSender _mailSender;
        private readonly IMapper _mapper;
        string HomePage;
        string SecondSite;
        public AccountController(IFactorService _factorService, IFactorService _factorService2, ICalendarService calendarService, ICalendarService calendarService2, ICustomerService customerService, ILogService logService, SignInManager<ApplicationUser> signInManager, ISettingService settingService, ITimeCardService timeService, UserManager<ApplicationUser> uManager, IRazorViewToStringRenderer razorViewToStringRenderer, Microsoft.AspNetCore.Hosting.IHostingEnvironment env, IMapper mapper, IMailSender mailSender)
        {


            //  var Rqust = System.Web.HttpContext.Current.Request;

            this._settingService = settingService;
            ViewBag.sitetitle = _settingService.DefaultWebsiteName();
            UserManager = uManager;
            this._razorViewToStringRenderer = razorViewToStringRenderer;
            this._env = env;
            this._factorService = _factorService;
            this._factorService2 = _factorService2;
            this._calendarService = calendarService;
            this._calendarService2 = calendarService2;
            this._MsgService = logService;
            this._customerService = customerService;
            _timeService = timeService;
            this._signInManager = signInManager;
            _mapper = mapper;
            _mailSender = mailSender;

            //  AutoLoginUser();
        }

        [AllowAnonymous]
        public IActionResult Heartbeat()
        {
            _heartBeat();
            return Json(new { success = true, responseText = "OK" }/*, JsonRequestBehavior.AllowGet*/);
        }
        [AllowAnonymous]
        public async Task<IActionResult> ChangePageSize()
        {
            if (User.GetClaimValue("PageSize") == null || User.GetClaimValue("PageSize") == "")
            {
                User.AddUpdateClaim("PageSize", "min");
            }
            else
            {
                User.AddUpdateClaim("PageSize", "");
            }

            return Json(new { success = true, responseText = "OK" }/*, JsonRequestBehavior.AllowGet*/);
        }
        [AllowAnonymous]
        public async Task<IActionResult> ChangeNightMode()
        {
            if (User.GetClaimValue("NightMode") == null || User.GetClaimValue("NightMode") == "")
            {
                User.AddUpdateClaim("NightMode", "-night");
            }
            else
            {
                User.AddUpdateClaim("NightMode", "");
            }
            var appUser = await UserManager.FindByIdAsync(UserManager.GetUserId(User));
            appUser.NightMode = User.GetClaimValue("NightMode");
            var res = await UserManager.UpdateAsync(appUser);
            return Json(new { success = true, responseText = User.GetClaimValue("NightMode") }/*, JsonRequestBehavior.AllowGet*/);
        }
        [AllowAnonymous]
        public IActionResult ChangeSearchBorrow(string name)
        {
            if (User.GetClaimValue(name) == null || User.GetClaimValue(name) == "0")
            {
                User.AddUpdateClaim(name, "1");
            }
            else
            {
                User.AddUpdateClaim(name, "0");
            }

            return Json(new { success = true, responseText = "OK" }/*, JsonRequestBehavior.AllowGet*/);
        }
        [AllowAnonymous]
        public async Task _heartBeat()
        {
            //برای نگه داشتن اطلاعات کاربران آنلاین
            //#UserLogin
            string CookieName = "UserLogin_WebSite";
            if (false /*Session[CookieName] == null & Session["SessionWorking"].ToString() == "1"*/)//کاربر تازه وبسایت را باز کرده
            {
                if (User.Identity.IsAuthenticated)//کاربر قبلا وارد شده
                {
                    UpdateUserHeartBeat(await UserManager.FindByIdAsync(UserManager.GetUserId(User)), Request.HttpContext.Connection.RemoteIpAddress.ToString());
                }
                //تغییر سشن
                //Session[CookieName] = "1";
                //Session["SessionWorking"] = "1";



            }
            else//وبسایت قبلا باز شده
            {
                if (User.Identity.IsAuthenticated)//کاربر قبلا وارد شده
                {
                    UpdateUserHeartBeat(await UserManager.FindByIdAsync(UserManager.GetUserId(User)), Request.HttpContext.Connection.RemoteIpAddress.ToString());
                }

                //Session[CookieName] = "1";
                //Session["SessionWorking"] = "1";



            }
        }

        [AllowAnonymous]
        public IActionResult AccessDenied(string returnUrl)
        {
            string Absolutepath = "";
            //if (HttpContext.Request.UrlReferrer != null)
            //    Absolutepath = HttpContext.Request.UrlReferrer.AbsolutePath;
            return View(model: Absolutepath);
        }


        [AllowAnonymous]
        public IActionResult _websiteName()
        {
            var model = _settingService.DefaultWebsiteName();
            //if (HttpContext.Request.UrlReferrer != null)
            //    ViewBag.Back = HttpContext.Request.UrlReferrer.AbsolutePath;
            return PartialView("_websiteName", model);
        }


        [AllowAnonymous]
        public async Task<IActionResult> _userProfile()
        {
            var model = await UserManager.FindByIdAsync(UserManager.GetUserId(User));
            model = model ?? new ApplicationUser();
            return PartialView("_userProfile", model.Image);
        }


        [AllowAnonymous]
        public IActionResult _topMenu()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public async Task<IActionResult> _notificationView()
        {
            try
            {
                int numberOfNotificarion = await GetNumberOfNotification();

                return PartialView(numberOfNotificarion);
            }
            catch (Exception ex)
            {

                return PartialView(0);
            }
        }



        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl, string user, string passw)
        {


            #region Auto Login
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    var reqCookies = Request.Cookies["startToken"];
                    if (reqCookies != null)
                    {
                        if (!string.IsNullOrEmpty(reqCookies))
                        {
                            var appUser = await UserManager.FindByIdAsync(reqCookies.ToString());
                            if (appUser != null)
                            {
                                var password = EncryptString.StringCipher.DecryptString(appUser.LastToken);
                                var result = await _signInManager.PasswordSignInAsync(appUser.UserName, password, true, false);
                                if (result.Succeeded)
                                {
                                    UpdateUserHeartBeat(appUser, Request.HttpContext.Connection.RemoteIpAddress.ToString());
                                    await _MsgService.AddLog(new LogEnt()
                                    {
                                        Date = DateTime.Now.SystemTime(),
                                        UserID = appUser.Id,
                                        Description = "Login Auto",
                                        UserFullName = appUser.FirstName + "-" + Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                                        Type = 6,
                                        modifiedInfo = Request.Headers["User-Agent"].ToString(),
                                    });

                                    if (appUser.UserType == UserType.Admin)
                                    {
                                        #region Return to returnUrl
                                        string decodedUrl = "";
                                        if (!string.IsNullOrEmpty(returnUrl) & returnUrl != "logoff")
                                        {
                                            decodedUrl = Uri.EscapeDataString(returnUrl);

                                            decodedUrl = WebUtility.UrlDecode(returnUrl);


                                        }
                                        returnUrl = returnUrl ?? "";
                                        decodedUrl = decodedUrl ?? "";

                                        if (Url.IsLocalUrl(decodedUrl))//Login logic...
                                        {
                                            return Redirect(decodedUrl);
                                        }

                                        #endregion

                                        #region Return to Work Page

                                        if (!string.IsNullOrEmpty(appUser.UrlRedirect))
                                        {
                                            var decodedUrlRedirect = WebUtility.UrlDecode(appUser.UrlRedirect);
                                            decodedUrlRedirect = decodedUrlRedirect ?? "";
                                            if (Url.IsLocalUrl(decodedUrlRedirect))//Login logic...
                                            {
                                                return Redirect(decodedUrlRedirect);
                                            }
                                        }


                                        #endregion

                                        return RedirectToAction("Factors", "Factor");
                                    }
                                    else if (appUser.UserType == UserType.Installer | appUser.UserType == UserType.Estimator | appUser.UserType == UserType.Installer_Estimator)
                                    {
                                        #region Return to Work Page

                                        if (!string.IsNullOrEmpty(appUser.UrlRedirect))
                                        {
                                            var decodedUrlRedirect = WebUtility.UrlDecode(appUser.UrlRedirect);
                                            decodedUrlRedirect = decodedUrlRedirect ?? "";
                                            if (Url.IsLocalUrl(decodedUrlRedirect))//Login logic...
                                            {
                                                return Redirect(decodedUrlRedirect);
                                            }

                                        }


                                        #endregion

                                        return RedirectToAction("Index", "Admin");//TimeLine
                                    }
                                    else
                                    {
                                        return RedirectToAction("Index", "User");
                                    }

                                }


                            }
                            else
                            {
                                RemoveCookie("startToken");
                            }


                        }
                    }
                }
            }
            catch { }

            #endregion


            //  RemoveAllCach();

            #region Mobile Login

            var Appuser = UserManager.Users.ToList().Where(p => p.NationalCode == user || p.PhoneNumber == user || p.UserName == user).FirstOrDefault();

            if (Appuser != null & !string.IsNullOrEmpty(passw))
                if (await UserManager.CheckPasswordAsync(Appuser, passw))
                {
                    bool Administrator = await UserManager.IsInRoleAsync(Appuser, "Administrator");//اگر مدیر بود وارد شود فعال بودن و تاییدیه ایمیل چک نشود

                    bool Admin = await UserManager.IsInRoleAsync(Appuser, "Admin"); ;//مدیران=> اپراتور،مدیران کتابخانه مدیران سیستم

                    if (await UserManager.IsInRoleAsync(Appuser, "sysAdmin") || await UserManager.IsInRoleAsync(Appuser, "Admin") || await UserManager.IsInRoleAsync(Appuser, "Operator"))
                        Admin = true;
                    if (!Appuser.isActive & !Administrator & !Admin)
                    {
                        //  TempData["Message"] = "your account is inactive, please contact your administrator.";

                    }
                    var lastTime = _timeService.GetLastTimeHasntLunch(Appuser.Id);
                    if (lastTime != null)
                    {

                        if ((DateTime.Now.SystemTime() < Convert.ToDateTime(lastTime).AddMinutes(2)) & !Administrator & !Admin)

                        {
                            //  TempData["Message"] = "your account is inactive for " + (int)(Convert.ToDateTime(lastTime).AddMinutes(2) - DateTime.Now.SystemTime()).TotalMinutes + "minites";

                        }
                    }

                    if (!Appuser.EmailConfirmed & !Administrator & _settingService.UseEmailService())
                    {
                        // var Res = SendEmailConfirmAgain(user.Id, user.Email);
                        //   TempData["Message"] = "you account is not confirmed." + "<br />" + "to confirm your account please  <a href='/Account/ConfirmEmailAgain'>send your email confirmation .</a> ";

                    }

                    if (User.Identity.IsAuthenticated)
                        await _signInManager.SignOutAsync();


                    var result = await _signInManager.PasswordSignInAsync(Appuser.UserName, passw, true, false);

                    User.Identities.FirstOrDefault().AddClaim(new Claim("FullName", (Appuser?.FirstName ?? "")));
                    if (Appuser.UserType == UserType.Admin)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
            #endregion


            if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
            {
                ViewBag.ReturnURL = returnUrl;
            }
            if (User.Identity.IsAuthenticated)
            {
                if (returnUrl == "logoff")
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Login", "Account");
                }
                if (returnUrl != null)
                {
                    return RedirectToAction("AccessDenied", "Account");
                }
                try
                {
                    var userinfo = await UserManager.FindByIdAsync(UserManager.GetUserId(User));
                    #region Return to Work Page

                    if (!string.IsNullOrEmpty(userinfo.UrlRedirect))
                    {
                        var decodedUrlRedirect = WebUtility.UrlDecode(userinfo.UrlRedirect);
                        decodedUrlRedirect = decodedUrlRedirect ?? "";
                        if (Url.IsLocalUrl(decodedUrlRedirect))//Login logic...
                        {
                            return Redirect(decodedUrlRedirect);
                        }
                    }


                    #endregion

                    if (userinfo.UserType == UserType.Admin)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (userinfo.UserType == UserType.Installer | userinfo.UserType == UserType.Estimator | userinfo.UserType == UserType.Installer_Estimator)
                    {
                        return RedirectToAction("TimeLine", "Admin");
                    }
                    else if (userinfo.UserType == UserType.User)
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                catch { }
            }
            var model = new Login();
            model.RememberMe = true;

            try
            {

                var reqCookies = Request.Cookies["start"];
                if (reqCookies != null)
                {
                    ViewBag.Cookie = reqCookies.ToString();
                }
            }
            catch { ViewBag.Cookie = ""; }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login, string? returnUrl)
        {
            //Session["NumberofFailedLogins"] = Session["NumberofFailedLogins"] ?? "0";
            //if (Int32.Parse(Session["NumberofFailedLogins"].ToString() ?? "0") > 2 & (Session["Captcha"] == null || Session["Captcha"].ToString() != login.Captcha))
            //{
            //    TempData["Message"] = "The result of the Captcha is wrong.";
            //    TempData["Type"] = "danger";
            //    return View(login);
            //}

            //  Session["NumberofFailedLogins"] = Int32.Parse(Session["NumberofFailedLogins"].ToString() ?? "0") + 1;
            if (!ModelState.IsValid)
            {
                GetErrorListFromModelState(ModelState);
                TempData["Type"] = "danger";
                return View(login);
            }


            var UserList = UserManager.Users.ToList();
            var user = UserList.FirstOrDefault(p => p.PhoneNumber == login.UserName || p.Email == login.UserName);
            if (user == null)
            {
                TempData["Message"] = "Email or phone number is incorreect" + "<br />";
                TempData["Type"] = "danger";
                return View(login);
            }
            //  var passwordCorect = string.IsNullOrEmpty(user.LastToken) ? true : EncryptString.StringCipher.Decrypt(user.LastToken, "9500") == login.Password;
            //--------
            if (true /*UserManager.PasswordHasher.VerifyHashedPassword(user.PasswordHash, login.Password).ToString() == "success"*/)
            {
                bool Administrator = await UserManager.IsInRoleAsync(user, "Administrator");


                if (!user.isActive & !Administrator)
                {
                    TempData["Message"] = "your account is inactive, please contact your administrator.";
                    TempData["Type"] = "danger";
                    return View(login);
                }


                //var lastTime = _timeService.GetLastTimeHasntLunch(user.Id);
                //if (lastTime != null)
                //{
                //    if ((DateTime.Now.SystemTime() < Convert.ToDateTime(lastTime).AddMinutes(2)) & !Administrator)

                //    {
                //        TempData["Message"] = "your account is inactive for " + (int)(Convert.ToDateTime(lastTime).AddMinutes(2) - DateTime.Now.SystemTime()).TotalMinutes + "minites";
                //        TempData["Type"] = "danger";
                //        return View(login);
                //    }
                //}


                if (User.Identity.IsAuthenticated)
                    await _signInManager.SignOutAsync();
                var loginsuccess = true;
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, false);
                loginsuccess = result.Succeeded;




                if (loginsuccess)
                {

                    //  Session["NumberofFailedLogins"] = null;
                    User.Identities.FirstOrDefault().AddClaim(new Claim("FullName", (user?.FirstName ?? "")));

                    //UserManager.AddClaimAsync(user,);

                    #region Save Cookie 

                    try
                    {
                        var reqCookies = Request.Cookies["startToken"];
                        if (reqCookies == null)
                        {
                            var loginTimeOut = _settingService.LoginTimeOut();
                            if (loginTimeOut > 0)
                            {
                                var userInfo = new CookieOptions();
                                userInfo.Expires = DateTime.Now.SystemTime().AddDays(loginTimeOut);
                                userInfo.Path = "/";
                                Response.Cookies.Append("startToken", user.Id, userInfo);





                                await _MsgService.AddLog(new LogEnt()
                                {
                                    Date = DateTime.Now.SystemTime(),
                                    UserID = user.Id,
                                    Description = "Save Cookie at  Expire : " + DateTime.Now.SystemTime().AddDays(loginTimeOut).ToString("d"),
                                    UserFullName = user.FirstName + "-" + Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                                    Type = 5,
                                    modifiedInfo = Request.Headers["User-Agent"].ToString(),
                                });
                            }
                        }
                    }
                    catch { }
                    #endregion

                    #region Save Encrypt Password

                    var password = EncryptString.StringCipher.EncryptString(login.Password);
                    user.LastToken = password;
                    var resp = await UserManager.UpdateAsync(user);
                    #endregion

                    if (user.UserType == UserType.Admin)
                    {
                        #region Return to returnUrl
                        string decodedUrl = "";
                        if (!string.IsNullOrEmpty(returnUrl) & returnUrl != "logoff")
                        {
                            decodedUrl = WebUtility.UrlDecode(returnUrl);

                        }
                        returnUrl = returnUrl ?? "";
                        decodedUrl = decodedUrl ?? "";

                        if (Url.IsLocalUrl(decodedUrl))//Login logic...
                        {
                            return Redirect(decodedUrl);
                        }

                        #endregion

                        #region Return to Work Page

                        if (!string.IsNullOrEmpty(user.UrlRedirect))
                        {
                            var decodedUrlRedirect = WebUtility.UrlDecode(user.UrlRedirect);
                            decodedUrlRedirect = decodedUrlRedirect ?? "";
                            if (Url.IsLocalUrl(decodedUrlRedirect))//Login logic...
                            {
                                return Redirect(decodedUrlRedirect);
                            }
                        }


                        #endregion
                        // Session["wellcome"] = "wellcome";
                        User.AddUpdateClaim("PageSize", "min");
                        return RedirectToAction("Factors", "Factor");
                    }
                    else if (user.UserType == UserType.Installer | user.UserType == UserType.Estimator | user.UserType == UserType.Installer_Estimator)
                    {
                        #region Return to Work Page

                        if (!string.IsNullOrEmpty(user.UrlRedirect))
                        {
                            var decodedUrlRedirect = WebUtility.UrlDecode(user.UrlRedirect);
                            decodedUrlRedirect = decodedUrlRedirect ?? "";
                            if (Url.IsLocalUrl(decodedUrlRedirect))//Login logic...
                            {
                                return Redirect(decodedUrlRedirect);
                            }

                        }


                        #endregion
                        //   Session["wellcome"] = "wellcome";
                        User.AddUpdateClaim("PageSize", "min");

                        if (user.UserType == UserType.Admin)
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else if (user.UserType == UserType.Installer | user.UserType == UserType.Estimator | user.UserType == UserType.Installer_Estimator)
                        {
                            return RedirectToAction("TimeLine", "Admin");
                        }
                        else if (user.UserType == UserType.User)
                        {
                            return RedirectToAction("Index", "User");
                        }
                        else
                            return RedirectToAction("TimeLine", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }

                }
                else
                {
                    TempData["Message"] = "Error... please try again later.";
                    TempData["Type"] = "danger";
                    return View(login);
                }

            }
            else
            {
                TempData["Message"] = "the password is incorrect.";
                TempData["Type"] = "danger";
                return View(login);
            }

        }

        [AllowAnonymous]
        public IActionResult SchedulAppointment()
        {
            var model = EstimateModel(new RequestEstimateAppointmentModel());
            ViewBag.datetime = DateTime.Now.SystemTime().ToString("dddd, dd MMMM yyyy");

            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Test2()
        {
            var model = EstimateModel(new RequestEstimateAppointmentModel());
            ViewBag.datetime = DateTime.Now.SystemTime().ToString("dddd, dd MMMM yyyy");

            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        //[EnableCors("*", "*", "*")]
        [AllowAnonymous]
        public async Task<IActionResult> _loadtimeList()
        {
            try
            {
                var model = EstimateModel(new RequestEstimateAppointmentModel());
                ViewBag.datetime = DateTime.Now.SystemTime().ToString("dddd, dd MMMM yyyy");
                var res = await _razorViewToStringRenderer.RenderViewToStringAsync("_loadtimeList", model);

                return Json(new JsonData()
                {
                    success = true,
                    html = res
                });
            }
            catch (Exception ex)
            {
                return Json(new JsonData()
                {
                    success = false,
                    html = await _razorViewToStringRenderer.RenderViewToStringAsync("_loadtimeList", new RequestEstimateAppointmentModel() { ListDateTime = new List<DateTimeModel>() })
                });
            }

        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SchedulAppointment(RequestEstimateAppointmentModel item)
        {
            try
            {
                var model = _mapper.Map<RequestEstimateAppointmentEnt>(item);


                var job = _factorService.FactorDetails(item.FactorID);

                if (job != null & !item.Reschedul)
                    if (job.Status == FactorStatus.Measuring_Scheduled | job.Status == FactorStatus.Schedule_Measuring_Request)
                    {
                        TempData["Message"] = "The project has already been scheduled";
                        TempData["Type"] = "danger";
                        //if (Request.IsAjaxRequest())
                        return Json(new { success = false, responseText = TempData["Message"] }/*, JsonRequestBehavior.AllowGet*/);
                        //else
                        //    return View(EstimateModel(item));

                    }

                if (item.Reschedul == true)//in edit
                {
                    if (item.ID == 0)
                        item.ID = _factorService.FactorDetails(item.FactorID)?.RequestEstimateID ?? 0;
                    var request = _calendarService.RequestEstimateAppointmentDetails(item.ID);

                    var Appointment = _calendarService.EstimateAppointmentDetailsByRequestID(request.ID);
                    // var job = _factorService.FactorDetailsByRequestID(item.ID);
                    var Res = true;
                    if (Res)
                    {
                        Res = _calendarService.DeleteEstimateAppointment(Appointment.ID);
                        if (Res)
                        {
                            if(request.ID != 0)
                            Res = _calendarService.DeleteRequestEstimateAppointment(request.ID);
                        }
                    }
                    if (!Res)
                    {
                        return Json(new { success = false, responseText = "Error... Please try again" }/*, JsonRequestBehavior.AllowGet*/);
                    }
                    item.ID = 0;
                    model = _mapper.Map<RequestEstimateAppointmentEnt>(item);
                }

                try
                {
                    model.Canceled = false;
                    var time = DateTime.Parse(item.Time);
                    model.Date = DateTime.Parse(item.DateStr);
                    model.Date = new DateTime(model.Date.Year, model.Date.Month, model.Date.Day, time.Hour, time.Minute, 0);

                    model.Time = model.Date.ToString("HH:mm");

                    model.BookDate = DateTime.Now.SystemTime();

                }
                catch
                {
                    TempData["Message"] = "Error... Please check your inpute.";
                    TempData["Type"] = "danger";
                    //  if (Request.IsAjaxRequest())
                    return Json(new { success = false, responseText = TempData["Message"] }/*, JsonRequestBehavior.AllowGet*/);
                    //else
                    //    return View(EstimateModel(item));
                }
                if (_calendarService2.UserHasAppointmentInTime(item.InstallerID, model.Date))
                {
                    return Json(new { success = false, responseText = "You can't select this time, please select another time." }/*, JsonRequestBehavior.AllowGet*/);
                }

                var AppUser = UserManager.Users.FirstOrDefault(p => (p.Email != null ? p.Email == item.Email: true));
                if (job != null) AppUser = await UserManager.FindByIdAsync(job.CustomerID);
                if (AppUser == null & job == null)
                {
                    AppUser = new ApplicationUser();
                    AppUser.UserName = item.Email;
                    AppUser.FirstName = item.FullName;
                    AppUser.LastName = "";
                    AppUser.Address = item.Address;
                    AppUser.BirthDate = DateTime.Now.SystemTime();
                    AppUser.CityID = item.CityID;
                    AppUser.CompanyName = item.CompanyName;
                    AppUser.Email = item.Email;
                    AppUser.EmailConfirmed = true;
                    AppUser.ExpireDate = DateTime.Now.SystemTime().AddYears(50);
                    AppUser.isActive = true;
                    AppUser.LastLogin = DateTime.Now.SystemTime();
                    AppUser.RegisterDate = DateTime.Now.SystemTime();
                    AppUser.PhoneNumber = item.PhoneNumber;
                    AppUser.PhoneNumberConfirmed = true;
                    AppUser.HeartBeatDate = DateTime.Now.SystemTime();
                    //      AppUser.LockoutEndDateUtc = DateTime.Now.SystemTime();
                    AppUser.UserType = UserType.User;
                    AppUser.ZipCode = item.ZipCode;
                    var Res = await UserManager.CreateAsync(AppUser, item.PhoneNumber);
                    if (Res.Succeeded == false)
                    {
                        TempData["Message"] = "Error... Please try again.";
                        TempData["Type"] = "danger";
                        // if (Request.IsAjaxRequest())
                        return Json(new { success = false, responseText = TempData["Message"] }/*, JsonRequestBehavior.AllowGet*/);
                        //else
                        //    return View(EstimateModel(item));
                    }

                    if (!await UserManager.IsInRoleAsync(AppUser, "User"))
                        if (!(await UserManager.AddToRolesAsync(AppUser, new List<string> { "User" })).Succeeded)
                        {
                            TempData["Message"] = "Error... Please try again.";
                            TempData["Type"] = "danger";
                            // if (Request.IsAjaxRequest())
                            return Json(new { success = false, responseText = TempData["Message"] }/*, JsonRequestBehavior.AllowGet*/);
                            //else
                            //    return View(EstimateModel(item));
                        }

                }
                model.CustomerID = AppUser.Id;
                if (model.CityID == 0)
                    model.CityID = AppUser.CityID;


                if (!_calendarService.AddRequestEstimateAppointment(model))
                {
                    TempData["Message"] = "Error... Please try again";
                    TempData["Type"] = "danger";
                    // if (Request.IsAjaxRequest())
                    return Json(new { success = false, responseText = TempData["Message"] }/*, JsonRequestBehavior.AllowGet*/);
                    //else
                    //    return View(EstimateModel(item));
                }

                //Add Estimate Appointment

                var estimate = new EstimateAppointmentEnt();
                estimate.AppointmentDate = model.Date;
                estimate.EstimatorID = item.InstallerID;
                estimate.RequestEstimateAppointmentID = model.ID;
                estimate.EndAppointmentDate = estimate.AppointmentDate.AddHours(1);

                if (!_calendarService.AddEstimateAppointment(estimate))
                {
                    TempData["Message"] = "Error... Please try again";
                    TempData["Type"] = "danger";
                    // if (Request.IsAjaxRequest())
                    return Json(new { success = false, responseText = TempData["Message"] }/*, JsonRequestBehavior.AllowGet*/);
                    //else
                    //    return View(EstimateModel(item));

                }
                var factor = new FactorEnt();
                if (job == null)
                {
                    factor.PONumber = Int32.Parse(DateTime.Now.SystemTime().ToString("yyMMdd") + (await _factorService.GetLastFactorNumber(DateTime.Now.SystemTime()) + 1).ToString());
                    factor.PlaceOrderDate = DateTime.Now.SystemTime();
                    factor.Date = DateTime.Now.SystemTime();
                    factor.InvoiceDate = DateTime.Now;
                    factor.DueDate = DateTime.Now;

                    factor.CustomerID = model.CustomerID;
                    factor.Status = FactorStatus.Estimation;
                    factor.RegisterUserID = estimate.EstimatorID;
                    factor.IsFinish = false;
                    factor.PaidPrice = 0;
                    factor.Remaining = 0;
                    factor.Date = DateTime.Now.SystemTime();

                    factor.FactorPrice = 0;
                    factor.FactorTechnicalNote = "";
                    factor.RequestEstimateID = model.ID;

                    if (!_factorService.AddFactor(factor))
                    {
                        TempData["Message"] = "Error... Please try again";
                        TempData["Type"] = "danger";
                        // if (Request.IsAjaxRequest())
                        return Json(new { success = false, responseText = TempData["Message"] }/*, JsonRequestBehavior.AllowGet*/);
                        //else
                        //    return View(EstimateModel(item));
                    }
                    //  Session.Remove("Factors");
                }
                else
                {
                    factor = job;
                    factor.RequestEstimateID = model.ID;
                    _factorService.UpdateFactor(factor);
                }
                model.FactorID = factor.ID;
                _calendarService.UpdateRequestEstimateAppointment(model);
                if (item.ListJobType != null)
                    foreach (var jb in item.ListJobType)
                    {
                        if (jb.Select) _customerService.AddFactorJobTypes(jb.ID, factor.ID);
                        else _customerService.DeleteFactorJobType(jb.ID, factor.ID);
                    }
                try
                {

                    var OrderTo = await _factorService.CustomerOrderToDeatilsAsync(factor.ID);
                    OrderTo.Contact = item.FullName;
                    OrderTo.CompanyName = item.FullName;
                    OrderTo.Email = item.Email;
                    OrderTo.PhoneNumber = item.PhoneNumber;
                    OrderTo.StateID = item.StateID;
                    OrderTo.CityID = item.CityID;
                    OrderTo.ZipCode = item.ZipCode;
                    OrderTo.Address = item.Address;
                    OrderTo.FactorID = factor.ID;
                    OrderTo.UserID = factor.CustomerID;
                    var changeFactorTax = OrderTo.CityID != item.CityID ? true : false;
                    OrderTo.CityID = item.CityID;
                    if (OrderTo.ID == 0)
                        await _factorService.AddCustomerOrderToAsync(OrderTo);
                    else
                        await _factorService.EditCustomerOrdertoAsync(OrderTo);

                    if (changeFactorTax)
                    {
                        var NewTax = (await _factorService.CityDetailsAsync(item.CityID))?.Tax ?? 0;
                        await _factorService.UpdateFactorTaxAsync(OrderTo.FactorID);
                    }
                }
                catch { }



                #region Add Google Calendar Event
                //try
                //{
                //    String folder = System.Web.HttpContext.Current.Server.MapPath("/App_Data/Google/");
                //    var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                //                          new ClientSecrets
                //                          {
                //                              ClientId = System.Configuration.ConfigurationManager.AppSettings["ClientId"],
                //                              ClientSecret = System.Configuration.ConfigurationManager.AppSettings["ClientSecret"],

                //                          },

                //                          new[] { CalendarService.Scope.Calendar },
                //                          "user",
                //                          CancellationToken.None,
                //                            new FileDataStore(folder, true));


                //    // Create the service.
                //    var service = new CalendarService(new BaseClientService.Initializer
                //    {
                //        HttpClientInitializer = credential,
                //        ApplicationName = "Calendar API Sample",
                //    });
                //    model.City = new RepositoryBase<CityEnt, int>().GetAll().FirstOrDefault(p => p.ID == model.CityID);
                //    var difrenttime = _settingService.DefaultSetting()?.DifrentCalendarTime ?? 0;
                //    var myEvent = new Event
                //    {
                //        Summary = "Estimate Appointment " + factor.PONumber + " Glassma Llc",
                //        Location = model.Address + ", " + model.City?.CityName + ", " + model.City?.State?.StateName + ", " + model.ZipCode,
                //        Start = new EventDateTime()
                //        {
                //            DateTime = estimate.AppointmentDate.AddMinutes(difrenttime),
                //            //System.Configuration.ConfigurationManager.AppSettings["TimeZoneCalendar"],
                //        },
                //        End = new EventDateTime()
                //        {
                //            DateTime = estimate.AppointmentDate.AddMinutes(_settingService.DefaultSetting()?.EstimateInterval ?? 0).AddMinutes(difrenttime),
                //        },
                //        //Recurrence = new String[] { "RRULE:FREQ=WEEKLY;BYDAY=MO" },
                //        //If you want to add attendee
                //        Attendees = new List<EventAttendee>()
                //    {
                //        new EventAttendee { Email = model.Email},
                //        new EventAttendee { Email = UserManager?.GetEmail(estimate.EstimatorID) ?? ""},
                //      //  new EventAttendee { Email = "Glassma.llc@gmail.com"},
                //    },
                //    };

                //    var recurringEvent = service.Events.Insert(myEvent, "primary");

                //    recurringEvent.SendNotifications = true;
                //    await recurringEvent.ExecuteAsync();
                //}
                //catch (Exception ex)
                //{
                //    //TempData["Message"] = GetErrorListFromModelState(ModelState, ex.Message);
                //    //TempData["Type"] = "danger";
                //    //if (Request.IsAjaxRequest())
                //    //    return Json(new { success = false, responseText = TempData["Message"] }/*, JsonRequestBehavior.AllowGet*/);
                //    //else
                //    //    return View(EstimateModel(item));

                //}
                #endregion

                #region #MsgNotification
                try
                {
                    var estimatorUser = await UserManager.FindByIdAsync(estimate.EstimatorID);

                    _MsgService.AddMsgNotificationForAdmin("New Estimate Scheduling", "PO :" + factor.PONumber +
                                                            "\r\n Customer : " + AppUser.FirstName +
                                                            "\r\n Date :" + estimate.AppointmentDate.ToString("yyyy/MM/dd-hh:mm") +
                                                            "\r\n Estimator:" + (estimatorUser?.FirstName ?? "")

                                                            , DateTime.Now.SystemTime());

                    _MsgService.AddMsgNotificationForUser("New Estimate Scheduling", "PO :" + factor.PONumber +
                                                      "\r\n Customer : " + AppUser.FirstName +
                                                      "\r\n Date :" + estimate.AppointmentDate.ToString("yyyy/MM/dd-hh:mm") +
                                                      "\r\n Estimator:" + (estimatorUser?.FirstName ?? "")

                                                      , estimate.EstimatorID, DateTime.Now.SystemTime());

                }
                catch { }
                #endregion

                if (_settingService.DefaultSetting().AutoConfirmAppt)
                    await ChangeStatusFunction(factor, FactorStatus.Measuring_Scheduled);
                else
                    await ChangeStatusFunction(factor, FactorStatus.Schedule_Measuring_Request);


                #region Change Status
                //var notification = new RepositoryBase<StatusNotificationEnt, int>().GetAll().FirstOrDefault(p => p.status == FactorStatus.Measuring_Scheduled);
                //if (notification != null)
                //{
                //    SendEstimationReportToUserID("Work Order (" + factor.PONumber + ")", notification.NotificationText, AppUser.Id, factor.PrivateID);
                //    new RepositoryBase<EmailNotificationEnt, long>().Insert(new EmailNotificationEnt()
                //    {
                //        FactorID = factor.ID,
                //        NotificationText = notification.NotificationText,
                //        UserID = model.CustomerID,
                //        status = factor.Status,
                //    });
                //}

                #endregion

                _factorService.ResetAppoitmentChangeView(model.FactorID, UserManager.GetUserId(User));
                TempData["Message"] = "your request was sent successfully.";
                TempData["Type"] = "success";
                string linkID = factor.PrivateID.ToString();
                //   if (Request.IsAjaxRequest())
                return Json(new { success = true, responseText = "your request was sent successfully.", linkId = linkID, email = item.Email }/*, JsonRequestBehavior.AllowGet*/);
                //    else
                //        return RedirectToAction("ViewEstimateAppointment", "User", new { id = linkID });
            }
            catch (Exception ex)
            {

                TempData["Message"] = "Error : " + GetErrorListFromModelState(ModelState, ex.Message);
                TempData["Type"] = "danger";
                //if (Request.IsAjaxRequest())
                return Json(new { success = false, responseText = TempData["Message"] }/*, JsonRequestBehavior.AllowGet*/);
                //else
                //    return View(EstimateModel(item));
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> _cancelestimate(int id)
        {
            try
            {

                var request = _calendarService.RequestEstimateAppointmentDetails(id);

                var Appointment = _calendarService.EstimateAppointmentDetailsByRequestID(request.ID);
                var factor = _factorService.FactorDetails(request.FactorID);
                // var job = _factorService.FactorDetailsByRequestID(item.ID);
                var Res = true;
                if (Res)
                {
                    Res = _calendarService.DeleteEstimateAppointment(Appointment.ID);
                    if (Res)
                    {
                        Res = _calendarService.DeleteRequestEstimateAppointment(request.ID);
                    }
                }
                factor.Status = FactorStatus.Estimate_Sent;
                _factorService.EditFactor(factor);
                if (!Res)
                {
                    return Json(new { success = false, responseText = "Error... Please try again" }/*, JsonRequestBehavior.AllowGet*/);
                }
                return Json(new { success = true, responseText = "Appointment Canceled successfully" }/*, JsonRequestBehavior.AllowGet*/);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = "Error... Please try again" }/*, JsonRequestBehavior.AllowGet*/);

            }





        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> _cancelInstall(int id)
        {
            try
            {

                var request = _calendarService.RequestInstallAppointmentDetails(id);

                var InstallAppointment = _calendarService.InstallAppointmentDetailsByRequestID(request.ID);
                var factor = _factorService.FactorDetails(request.FactorID);

                var Res = true;
                if (Res)
                {
                    Res = _calendarService.DeleteInstallAppointment(InstallAppointment.ID);
                    if (Res)
                    {
                        Res = _calendarService.DeleteRequestInstallAppointment(request.ID);
                    }
                }
                if (!Res)
                {
                    return Json(new { success = false, responseText = "Error... Please try again" }/*, JsonRequestBehavior.AllowGet*/);
                }
                factor.Status = FactorStatus.Delivered_in_house;
                _factorService.EditFactor(factor);
                return Json(new { success = true, responseText = "Appointment Canceled successfully" }/*, JsonRequestBehavior.AllowGet*/);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = "Error... Please try again" }/*, JsonRequestBehavior.AllowGet*/);

            }





        }

        private async Task<RequestEstimateAppointmentModel> EstimateModel(RequestEstimateAppointmentModel model)
        {

            //  register.DocumentGroups = new List<DocumentGroup>();

            try
            {
                var ListDateModel = new List<DateTimeModel>();
                model.StartDate = DateTime.Now.SystemTime().ToString("yyyy/MM/dd");
                var end = _calendarService.ListAllWorkSchedulings().Where(p => p.UserType == UserType.Estimator || p.UserType == UserType.Installer_Estimator).Max(p => p.EndDate);
                model.EndDate = end.ToString("yyyy/MM/dd");

                for (DateTime d = DateTime.Now.SystemTime(); d.Date <= end.Date; d = d.AddDays(1))
                {
                    var listTime = await _calendarService.GetEstimateFreeWorkScheduling(d.ToString("yyyy/MM/dd"), DateTime.Now.SystemTime(), "");

                    if (listTime.Count > 0 & !listTime.Any(p => p.TimeStr.Contains("Nothing available")))
                        ListDateModel.Add(new DateTimeModel()
                        {
                            DateStr = d.ToString("dddd, dd MMMM yyyy"),
                            Date = d,
                            ListTimes = listTime
                        });
                }


                model.ListDateTime = ListDateModel.Take(5).ToList();
            }
            catch { }


            model.ListTime = await _calendarService.GetEstimateFreeWorkScheduling(model.DateStr, DateTime.Now.SystemTime(), "");
            model.ListJobType = _mapper.Map<List<JobTypeModel>>((_customerService.ListJobType()).Where(p => p.HideForCustomer == false).ToList());

            var CityList = new List<CityEnt>();
            var StateList = await _factorService.ListStateAsync();
            var SFirstID = model.StateID == 0 ? StateList.FirstOrDefault()?.ID ?? 0 : model.StateID;
            if (StateList.Count > 0)
                CityList = (await _factorService.ListCityAsync()).Where(p => p.StateId == SFirstID).ToList();

            ViewBag.ListCity = CityList;
            ViewBag.ListState = StateList;
            model.EmailSetting = _settingService.DefaultEmailSetting();
            model.FactorStatus = FactorStatus.Schedule_Measuring;
            model.InstallTime = _settingService.DefaultSetting()?.EstimateInterval ?? 0;
            if (model.InstallTime != 0 & model.InstallTime % 60 == 0)
                model.InstallTime = model.InstallTime / 60;

            return model;
        }

        [AllowAnonymous]
        public async Task<IActionResult> _ChangePassword()
        {
            var currentUser = await UserManager.FindByIdAsync(UserManager.GetUserId(User));
            var b = UserManager.CheckPasswordAsync(currentUser, "123456");
            return PartialView(b);
        }


        [AllowAnonymous]
        public IActionResult LogOff()
        {

            //   Session.Remove("UserLogin_WebSite");

              RemoveCookie();
            _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }



        #region Upload Download


        [AllowAnonymous]
        public async Task<IActionResult> _ShowUserPicture(int height = 35)
        {
            try
            {
                var user = await UserManager.FindByIdAsync(UserManager.GetUserId(User));
                var model = new UserImage();


                var relativePath = user.Image;
                // var absolutePath = HttpContext.Server.MapPath(relativePath);


                if (user.Image != null && System.IO.File.Exists(_env.WebRootPath + "/Content/Files/ProfileImages/" + relativePath))
                    model.ImageProfile = user.Image;
                else
                    model.ImageProfile = "default-image.jpg";

                model.Height = height;
                return PartialView(model);
            }
            catch (Exception ex)
            {

                return PartialView(new UserImage() { Height = 34 });
            }
        }


        [HttpPost]

        public async Task<IActionResult> UploadFile(IFormFile UploadImage, string id)
        {
            try
            {
                var user = await UserManager.FindByIdAsync(id);//گرفتن کاربر
                if (UploadImage == null)//اگر تصویرانتخاب نکرد کاری انجام نده
                    return Json(new { success = true }, "text/html"/*, JsonRequestBehavior.AllowGet*/);


                string[] formats = new string[] { ".jpg", ".png", ".jpeg" }; // add more if u like...
                bool validate = formats.Any(item => UploadImage.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
                if (!validate)//چک کردن فرمت های مجاز
                {
                    return Json(new { success = false, responseText = "لطفا تصاویر با فرمت های ،jpeg ،gif ،png،jpg را انتخاب کنید" }, "text/html"/*, JsonRequestBehavior.AllowGet*/);
                }
                DateTime d = DateTime.Parse(DateTime.Now.SystemTime().ToString());
                PersianCalendar pc = new PersianCalendar();//برای تغییر نام عکس
                string FileName = (string.Format("{0}-{1}-{2}--{3}-{4}-{5}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d), pc.GetHour(d), pc.GetMinute(d), pc.GetSecond(d))) + UploadImage.FileName.Replace("/", "");


                if (user.Image != null)//در صورتی که عکس وجو داشت آن را حذف کن
                {
                    string filePath = _env.WebRootPath + "/Content/Files/ProfileImages/" + user.Image;

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                string path = _env.WebRootPath + "/Content/Files/ProfileImages/" + FileName;

                if (validate)//چک کردن فرمت های مجاز
                {
                    System.Drawing.Image image = System.Drawing.Image.FromStream(UploadImage.OpenReadStream(), true, true);
                    var newImage = new Bitmap(1024, 768);
                    using (var g = Graphics.FromImage(newImage))
                    {
                        g.DrawImage(image, 0, 0, 1024, 768);

                    }
                    newImage.Save(path);
                }
                else
                {
                    using (var stream = System.IO.File.Create(path))
                    {
                        await UploadImage.CopyToAsync(stream);
                    }
                }                                                                                //   UploadImage.SaveAs(path);


                user.Image = FileName;
                if (!await UpdateUserInfo(user))
                    return Json(new { success = false, responseText = "خطا در ذخیره عکس، لطفا دوباره تلاش کنید" }, "text/html"/*, JsonRequestBehavior.AllowGet*/);



                return Json(new { success = true }, "text/html"/*, JsonRequestBehavior.AllowGet*/);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = "خطا در ذخیره عکس، لطفا دوباره تلاش کنید" }, "text/html"/*, JsonRequestBehavior.AllowGet*/);
            }

        }

        [HttpPost]
        public async Task<IActionResult> UploadPDF(IFormFile UploadPDF, long id)
        {
            try
            {
                if (UploadPDF == null)//اگر فایلی نکرد کاری انجام نده
                    return Json(new { success = true }, "text/html"/*, JsonRequestBehavior.AllowGet*/);


                string[] formats = new string[] { ".PDF", ".pdf", ".Pdf", ".doc", "docx" }; // add more if u like...
                bool validate = formats.Any(item => UploadPDF.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
                if (!validate)//چک کردن فرمت های مجاز
                {
                    return Json(new { success = false, responseText = "لطفا فایل با فرمت های  ،PDF,doc,docx  را انتخاب کنید" }, "text/html"/*, JsonRequestBehavior.AllowGet*/);
                }
                DateTime d = DateTime.Parse(DateTime.Now.SystemTime().ToString());
                PersianCalendar pc = new PersianCalendar();//برای تغییر نام فایل
                string FileName = (string.Format("{0}-{1}-{2}--{3}-{4}-{5}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d), pc.GetHour(d), pc.GetMinute(d), pc.GetSecond(d))) + UploadPDF.FileName.Replace("/", "");

                // var image = Image.FromStream(UploadPDF.InputStream, true, true);
                string path = _env.WebRootPath + "/Content/Files/EffectFiles/" + FileName;



                using (var stream = System.IO.File.Create(path))
                {
                    await UploadPDF.CopyToAsync(stream);
                }

                return Json(new { success = true }, "text/html"/*, JsonRequestBehavior.AllowGet*/);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "خطا در ذخیره فایل، لطفا دوباره تلاش کنید" + "<br />" + ex.ToString() }, "text/html"/*, JsonRequestBehavior.AllowGet*/);
            }

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> DeleteImageProfile(string id)
        {
            try
            {
                var user = await UserManager.FindByIdAsync(id);//گرفتن کاربر
                if (user == null)
                {
                    return Json(new { success = true }/*, JsonRequestBehavior.AllowGet*/);
                }
                if (user.Image == null)
                {
                    return Json(new { success = true }/*, JsonRequestBehavior.AllowGet*/);
                }
                user.Image = null;
                if (!await UpdateUserInfo(user))
                {
                    return Json(new { success = false, responseText = "خطا در حذف عکس، لطفا بعدا تلاش کنید" }/*, JsonRequestBehavior.AllowGet*/);
                }
                return Json(new { success = true, responseText = "عکس با موفقیت حذف شد" }/*, JsonRequestBehavior.AllowGet*/);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "خطا در حذف عکس، لطفا بعدا تلاش کنید" }/*, JsonRequestBehavior.AllowGet*/);
            }
        }
        [AllowAnonymous]
        public IActionResult DownloadPDF(string file)
        {
            string path = _env.WebRootPath + "/Content/Files/EffectFiles/" + file;

            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(path);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = file
            };
            return response;
        }
        [AllowAnonymous]
        public IActionResult DownloadFile(string file)
        {
            string path = _env.WebRootPath + file;

            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(path);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = file
            };
            return response;
        }

        #endregion


        #region Action for Email Service

        [AllowAnonymous]
        public IActionResult ConfirmEmailAgain()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmEmailAgain(ConfirmEmailAgain model)
        {
            //if (Session["Captcha"] == null || Session["Captcha"].ToString() != model.Captcha)
            //{
            //    TempData["Message"] = "The result of the image is wrong.";
            //    TempData["Type"] = "danger";
            //    return View(model);
            //}

            if (!ModelState.IsValid)
            {
                GetErrorListFromModelState(ModelState);
                TempData["Type"] = "danger";
                return View(model);
            }
            if (!_settingService.UseEmailService())
            {
                TempData["Message"] = "The email service is disabled.";
                TempData["Type"] = "danger";
                return View(model);
            }
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["Message"] = "The email is incorrect.";
                TempData["Type"] = "danger";
                return View(model);
            }

            string Res = await SendEmailConfirmAgain(user.Id, user.Email);

            if (Res != "success")
            {
                TempData["Message"] = "Error to send email, please try again.";
                TempData["Type"] = "danger";
                return View(model);
            }

            TempData["Message"] = "The email was sent successfuly, please check your email.";
            TempData["Type"] = "success";
            return View(model);
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> SendEmailAgain(string id)
        {
            try
            {
                if (id == "myself")
                    id = UserManager.GetUserId(User);
                var user = await UserManager.FindByIdAsync(id);
                if (user == null)
                {
                    return Json(new { success = false, responseText = "Error... Please select a record" }/*, JsonRequestBehavior.AllowGet*/);
                }
                if (user.EmailConfirmed)
                {
                    return Json(new { success = true, responseText = "Email Confimed" }/*, JsonRequestBehavior.AllowGet*/);

                }
                if (!_settingService.UseEmailService())
                {
                    return Json(new { success = false, responseText = "Please enable email service" }/*, JsonRequestBehavior.AllowGet*/);
                }
                //--My Email Sender
                string Res = await SendEmailConfirmAgain(user.Id, user.Email);
                if (Res != "success")
                {
                    return Json(new { success = false, responseText = "Note:" + "<br /> " + "Error... Please enable email service " + "<br /> " + Res }/*, JsonRequestBehavior.AllowGet*/);
                }
                return Json(new { success = true, responseText = "Email sent successfully. please check you'r email" }/*, JsonRequestBehavior.AllowGet*/);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = "خطا در ارسال ایمیل لطفا بعدا تلاش کنید" + "<br />" + ex.ToString() }/*, JsonRequestBehavior.AllowGet*/);
            }
        }
        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View(false);
            }
            var user = await UserManager.FindByIdAsync(userId);
            var result = await UserManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? true : false);
        }
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmChangeEmail(string userId, string code)
        {
            try
            {
                //yourCode
                var Res = true;
                if (userId == null || code == null)
                {
                    return View(false);
                }


                var user = await UserManager.FindByIdAsync(userId);
                var result = await UserManager.ConfirmEmailAsync(user, code);
                if (Res) Res = result.Succeeded;//Check Code Confirm

                var AppUser = await UserManager.FindByIdAsync(userId);
                if (Res)
                {
                    AppUser.UserName = AppUser.NewEmail;//تغییر ایمیل قبلی به ایمیل جدید
                    AppUser.Email = AppUser.NewEmail;
                }




                using (var scope = new TransactionScope())
                {

                    if (Res) Res = await UpdateUserInfo(AppUser);//Chnage Old Email

                    scope.Complete();
                    ViewBag.Email = AppUser.Email;
                    return View(Res);
                }

            }
            catch (TransactionAbortedException ex)
            {

                return View(false);
            }
            catch (ApplicationException ex)
            {
                return View(false);
            }


        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {



            return View();
        }



        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {

            // Session["NumberofFailedLogins"] = Session["NumberofFailedLogins"] ?? "0";
            //if (Int32.Parse(Session["NumberofFailedLogins"].ToString() ?? "0") > 2 & (Session["Captcha"] == null || Session["Captcha"].ToString() != model.Captcha))
            //{
            //    TempData["Message"] = "The result of the image is wrong.";
            //    TempData["Type"] = "danger";
            //    return View(model);
            //}

            //  Session["NumberofFailedLogins"] = Int32.Parse(Session["NumberofFailedLogins"].ToString() ?? "0") + 1;

            if (!ModelState.IsValid)
            {
                GetErrorListFromModelState(ModelState);
                TempData["Type"] = "danger";
                return View(model);
            }

            if (!model.Email.IsEmail())
            {
                TempData["Message"] = "Please enter your email";
                TempData["Type"] = "danger";
                return View(model);
            }
            if (!_settingService.UseEmailService())
            {
                TempData["Message"] = "The email service is disabled.";
                TempData["Type"] = "danger";
                return View(model);
            }
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["Message"] = "The email is incorrect.";
                TempData["Type"] = "danger";
                return View(model);
            }
            //if (!user.EmailConfirmed)
            //{
            //    TempData["Message"] = "you account is not confirmed." + "<br />" + "to confirm your account please  <a href='/Account/ConfirmEmailAgain'>send your email confirmation .</a> "; TempData["Type"] = "danger";
            //    return View(model);
            //}

            string Res = await SendPasswordReset(user.Id, user.Email);

            if (Res != "success")
            {
                TempData["Message"] = "Error.. please try again.";
                TempData["Type"] = "danger";
                return View(model);
            }

            TempData["Message"] = "The email was sent successfuly, please check your email.";
            TempData["Type"] = "success";
            return View(model);
        }


        [AllowAnonymous]
        public IActionResult RecoveryPassword()
        {
            return View();
        }

        public async Task<string> SendPasswordReset(string userID, string email)
        {
            if (!_settingService.UseEmailService())
                return "Email Service is Disable.";

            var user = await UserManager.FindByIdAsync(userID);
            var callbackUrl = Url.Action("ResetPassword", "Account",
                new { Area = "", userId = userID, code = await UserManager.GeneratePasswordResetTokenAsync(user) }, protocol: Request.Scheme);

            //  var code = UserManager.GenerateEmailConfirmationToken(userID);
            //  var callbackUrl = HomePage + "/Account/ResetPassword?userId=" + userID + "&code=" + code;
            HomePage = Request.Scheme + System.Uri.SchemeDelimiter + Request.Host;
            var defaultSetting = _settingService.DefaultEmailSetting();

            var EmailValue = new EmailValue();
            EmailValue.WebsiteName = defaultSetting.CompanyName;
            EmailValue.HomePage = HomePage;
            EmailValue.Login = HomePage + "/Account/Login";
            EmailValue.ButtonClick = callbackUrl;
            EmailValue.ButtonText = "Reset Password";
            EmailValue.EmailTitle = "Reset Password";
            EmailValue.Content = "Please, reset your password by this link";
            EmailValue.Phone = defaultSetting.CompanyPhone;
            EmailValue.LogoURL = defaultSetting.logo.Replace("svg", "png");
            var Content = await _razorViewToStringRenderer.RenderViewToStringAsync("_MailSender", EmailValue);

            return await _mailSender.SendMail(EmailValue.EmailTitle, Content, email);

        }


        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {

            return View();
        }


        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public IActionResult ResetPassword(string code)
        {

            return View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                GetErrorListFromModelState(ModelState);
                TempData["Type"] = "danger";
                return View(model);
            }
            if (!_settingService.UseEmailService())
            {
                TempData["Message"] = "The email service is disabled.";
                TempData["Type"] = "danger";
                return View(model);
            }
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["Message"] = "The email is incorrect.";
                TempData["Type"] = "danger";
                return View(model);
            }
            var result = await UserManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (!result.Succeeded)
            {
                TempData["Message"] = "Error... Please try again later.";
                TempData["Type"] = "danger";
                return View(model);
            }

            TempData["Message"] = "You'r password changed successfully." + "<br />" + "you can  <a href='/Account/Login?returnUrl=logoff'>Login </a> to panel.";
            TempData["Type"] = "success";
            return View(model);
        }

        //
        // GET: /Account/ResetPasswordation
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View(false);
        }
        #endregion


        #region Cookie Function


        [AllowAnonymous]
        private void AddCookie(string name, long value, int day)
        {
            var cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.SystemTime().AddDays(day);
            cookie.Path = "/";
            Response.Cookies.Append(name, value.ToString(), cookie);
        }
        [AllowAnonymous]
        private void DeleteCookie(string name)
        {
            Response.Cookies.Delete(name);
        }

        [AllowAnonymous]
        private bool isCookieExist(string name)
        {
            try
            {
                var reqCookies = Request.Cookies["startToken"];
                if (string.IsNullOrEmpty(reqCookies))
                    return false;
                else
                    return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        #endregion

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Authentication;
        //    }
        //}

        private void AddErrors(Microsoft.AspNet.Identity.IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        //internal class ChallengeResult : HttpUnauthorizedResult
        //{
        //    public ChallengeResult(string provider, string redirectUri)
        //        : this(provider, redirectUri, null)
        //    {
        //    }

        //    public ChallengeResult(string provider, string redirectUri, string userId)
        //    {
        //        LoginProvider = provider;
        //        RedirectUri = redirectUri;
        //        UserId = userId;
        //    }

        //    public string LoginProvider { get; set; }
        //    public string RedirectUri { get; set; }
        //    public string UserId { get; set; }

        //    public override void ExecuteResult(ControllerContext context)
        //    {
        //        var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
        //        if (UserId != null)
        //        {
        //            properties.Dictionary[XsrfKey] = UserId;
        //        }
        //        context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
        //    }
        //}
        #endregion


        #region ContactUS
        [AllowAnonymous]
        public IActionResult Contactus()
        {
            return View();
        }
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Contactus(ContactUsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                GetErrorListFromModelState(ModelState);
                TempData["Type"] = "danger";
                return View(model);
            }

            if (!model.Email.IsEmail())
            {
                TempData["Message"] = "Please enter your email";
                TempData["Type"] = "danger";
                return View(model);
            }
            if (!_settingService.UseEmailService())
            {
                TempData["Message"] = "The email service is disabled.";
                TempData["Type"] = "danger";
                return View(model);
            }

            string emailContent = "You have new contactus message" + "\r\n"
                             + "From : " + model.FullName + "\r\n"
                             + "Phone : " + model.Phone + "\r\n"
                             + "Email : " + model.Email + "\r\n"
                             + "Message : " + model.Message + "\r\n";

            string Res = await _mailSender.SendMail("New Contactus Message", emailContent, _settingService.DefaultEmailSetting().ReciverEmail);

            if (Res != "success")
            {
                TempData["Message"] = "Error.. please try again.";
                TempData["Type"] = "danger";
                return View(model);
            }

            TempData["Message"] = "You'r message was sent successfuly.";
            TempData["Type"] = "success";
            return View(new ContactUsViewModel());
        }
        #endregion

        public async Task<int> GetNumberOfNotification()
        {
            try
            {
                var userID = UserManager.GetUserId(User);
                var msgNotification = _MsgService.ListAllMsg();

                var myNotificationList = await msgNotification.Where(p => p.UserID == userID | p.forAll).ToListAsync();
                if (User.IsInRole("sysAdmin"))
                {
                    myNotificationList.AddRange(msgNotification.Where(p => p.forAdmin).ToList());
                }
                myNotificationList = myNotificationList.Select(p => { p.ReadIDs = p.ReadIDs ?? ""; return p; }).ToList();

                return myNotificationList.Count(p => !p.ReadIDs.Contains(userID));
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<bool> UpdateUserHeartBeat(ApplicationUser user, string IP, string LastPassword = "")
        {
            try
            {

                if (user == null)
                {
                    return false;
                }



                user.modifiedInfo = GetmodifiedInfo();
                user.modifiedInfo += (User.IsInRole("Administrator")) ? "" : " By :" + User.FullName();




                user.HeartBeatDate = DateTime.Now.SystemTime();
                user.LastLogin = DateTime.Now.SystemTime();
                user.LoginNumber = user.LoginNumber + 1;
                user.LastIP = IP;
                user.modifiedInfo = user.modifiedInfo;


                await UserManager.UpdateAsync(user);
                //     if (LastPassword != "") user.LastToken = LastPassword;
                //-------------------------------------------- //--#AccessLevel Setting


                return true;


            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> UpdateUserInfo(ApplicationUser user)
        {
            try
            {
                if (user == null)
                {
                    return false;
                }

                var item = await UserManager.FindByIdAsync(user.Id);

                user.modifiedInfo = GetmodifiedInfo();
                user.modifiedInfo += (User.IsInRole("Administrator")) ? "" : " By :" + User.FullName();

                if (item == null)
                    return false;



                item.DocumentGroupID = user.DocumentGroupID;
                item.Email = user.Email;
                item.SecondEmail = user.SecondEmail;
                item.FatherName = user.FatherName;
                item.FirstName = user.FirstName ?? "";
                item.FirstName = item.FirstName.Trim(' ').Trim(' ').Trim(' ');
                item.IdNumber = user.IdNumber;
                item.isActive = user.isActive;
                item.LastName = user.LastName ?? "";
                item.LastName = item.LastName.Trim(' ').Trim(' ').Trim(' ');
                item.modifiedInfo = user.modifiedInfo;
                item.NationalCode = user.NationalCode;
                item.OtherInformation = user.OtherInformation;
                item.PersonallyCode = user.PersonallyCode;
                item.Address = user.Address;
                item.ZipCode = user.ZipCode;
                item.CompanyName = user.CompanyName;
                item.UserType = user.UserType;
                item.PasswordHash = user.PasswordHash;
                item.ExpireDate = user.ExpireDate;
                item.modifiedInfo = user.modifiedInfo;
                item.CityID = user.CityID;
                item.StateID = user.StateID;
                item.RegisterDate = user.RegisterDate;
                item.LastLogin = user.LastLogin;
                item.HeartBeatDate = user.HeartBeatDate;
                item.LastIP = user.LastIP;
                item.Image = user.Image;
                item.EmailConfirmed = user.EmailConfirmed;
                item.Role = user.Role;
                item.UserName = user.UserName;
                item.UserColor = user.UserColor;
                item.BorrowNumber = user.BorrowNumber;
                item.latitude = user.latitude;
                item.longitude = user.longitude;
                item.VoiceGmail = user.VoiceGmail;
                //------------------------------------------
                if (item.PhoneNumber != user.PhoneNumber)
                    item.PhoneNumberConfirmed = false;

                item.PhoneNumber = user.PhoneNumber;
                item.PaymentTerms = user.PaymentTerms;
                //-----------------------------------------
                //-------------------------------------------- //--#AccessLevel Setting
                var res = await UserManager.UpdateAsync(item);
                if (res.Succeeded)
                {
                    await AddLastActivity("Users", "Edit", user.Id);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public string GetErrorListFromModelState(ModelStateDictionary modelState, string exMessage = "")
        {
            var query = from state in modelState.Values
                        from error in state.Errors
                        select error.ErrorMessage;

            foreach (var item in query)
            {
                TempData["Message"] += item + "<br /> ";
            }

            return TempData["Message"] == null ? exMessage :
                TempData["Message"] + "<p >" + exMessage + "</p>";

        }
        public void AutoLoginUser(string cookieName = "start")
        {
            //#region Auto Login

            ////--------------- Fetching Cookie -------------------------//  
            //try
            //{
            //    if (!User.Identity.IsAuthenticated)
            //    {
            //        HttpCookie reqCookies = Request.Cookies[cookieName];
            //        if (reqCookies != null)
            //        {
            //            if (!string.IsNullOrEmpty(reqCookies.Values["filed"]))
            //            {
            //                var appUser = await UserManager.FindByIdAsync(reqCookies.Values["filed"].ToString());
            //                if (appUser != null)
            //                    SignInManager.SignIn(appUser, true, true);
            //                else
            //                {
            //                    RemoveCookie(cookieName);
            //                }


            //            }
            //        }
            //    }
            //}
            //catch { }

            //#endregion

            //#region Auto Login

            ////--------------- Fetching Cookie -------------------------//  
            //try
            //{
            //    if (!User.Identity.IsAuthenticated)
            //    {
            //        HttpCookie reqCookies = Request.Cookies[cookieName];
            //        if (reqCookies != null)
            //        {
            //            if (!string.IsNullOrEmpty(reqCookies.Values["filed"]))
            //            {
            //                var appUser = await UserManager.FindByIdAsync(reqCookies.Values["filed"].ToString());
            //                if (appUser != null)
            //                    SignInManager.SignIn(appUser, true, true);
            //                else
            //                {
            //                    RemoveCookie(cookieName);
            //                }


            //            }
            //        }
            //    }
            //}
            //catch { }



            //#endregion
        }


        public string GetmodifiedInfo()
        {
            return DateTime.Now.SystemTime().ToString("yyyy/MM/dd hh:mm:ss:tt");
        }
        public void RemoveCookie(string cookieName = "startToken")
        {
            Response.Cookies.Delete(cookieName);
        }

        public async Task<bool> ChangeStatusFunction(FactorEnt job, FactorStatus newStatus = 0)
        {
            try
            {
                if (newStatus != 0) job.Status = newStatus;

                var oldJob = await _factorService.FactorDetailsAsync(job.ID);
                var OrderTo = await _factorService.CustomerOrderToDeatilsAsync(job.ID);
                if (job.Status != oldJob.Status)//The status was change... send email to customer
                {
                    var notification = await _settingService.GetNotificationAsync(job.Status);

                    if (notification == null) await _factorService.EditFactorAsync(job, oldJob);

                    await SendEmailProjectStatusToAdmin(job.ID, job.Status);

                    if (notification != null & await _factorService.EditFactorAsync(job, oldJob))
                    {
                        if (newStatus == FactorStatus.installation_delivery_Scheduled)
                            await SendInstallationReportToUserID("Customer's Work Order (" + OrderTo.WorkOrder + " #PO:" + job.PONumber + ")", notification.NotificationText, job.CustomerID, job.PrivateID);

                        else if (newStatus == FactorStatus.Measuring_Scheduled)
                            await SendEstimationReportToUserID("Customer's Work Order (" + OrderTo.WorkOrder + " #PO:" + job.PONumber + ")", notification.NotificationText, job.CustomerID, job.PrivateID);
                        else
                            await SendEmailByUserID("Customer's Work Order (" + OrderTo.WorkOrder + " #PO:" + job.PONumber + ")", notification.NotificationText, job.CustomerID);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        private async Task<string> SendEmailProjectStatusToAdmin(int id, FactorStatus newStatus = FactorStatus.PreEstimation)
        {
            try
            {

                var useEmailSErvice = await _settingService.UseEmailServiceAsync();
                if (!useEmailSErvice)
                    return "Email Service is Disable.";

                var Factor = await _factorService.FactorDetailsAsync(id);
                if (Factor == null) return "Project Not Found";
                var CustomerInfo = await UserManager.FindByIdAsync(Factor.RegisterUserID);
                if (!CustomerInfo.isActive)
                    return "Admin is not active";
                Factor.Status = newStatus != FactorStatus.PreEstimation ? newStatus : Factor.Status;
                HomePage = Request.Scheme + System.Uri.SchemeDelimiter + Request.Host;
                var defaultSetting = await _settingService.DefaultEmailSettingAsync();
                var EmailValue = new EmailValue();
                EmailValue.WebsiteName = defaultSetting.CompanyName;
                EmailValue.HomePage = HomePage;
                EmailValue.Login = HomePage + "/Account/Login";
                EmailValue.ButtonText = "Open Project";
                EmailValue.ButtonClick = HomePage + "/Factor/Update/" + Factor.ID;
                EmailValue.SecoundLink = SecondSite + "/Factor/Update/" + Factor.ID;
                EmailValue.EmailTitle = $"Project Update({Factor.PONumber})";
                EmailValue.Content = "The project's status changed to => " + Factor.Status.ToFactorStatus();
                EmailValue.Phone = defaultSetting.CompanyPhone;
                EmailValue.LogoURL = defaultSetting.logo.Replace("svg", "png");

                var Content = await _razorViewToStringRenderer.RenderViewToStringAsync("_MailSender", EmailValue);
                var sendEmailResult = await _mailSender.SendMailAsync(EmailValue.EmailTitle, Content, CustomerInfo.Email); ;

                return sendEmailResult;
            }
            catch (Exception ex)
            {

                return "Error to send email to admin";
            }
        }


        public async Task<string> SendEmailConfirmAgain(string userID, string email)
        {
            if (!_settingService.UseEmailService())
                return "Email Service is Disable.";

            //  var code = UserManager.GenerateEmailConfirmationToken(userID);
            //    var callbackUrl = HomePage + "/Account/ConfirmEmail?userId=" + userID + "&code=" + code;

            var appUser = await UserManager.FindByIdAsync(userID);
            var callbackUrl = Url.Action("ConfirmEmail", "Account",
                      new { Area = "", userId = userID, code = await UserManager.GenerateEmailConfirmationTokenAsync(appUser) }, protocol: Request.Scheme);

            HomePage = Request.Scheme + System.Uri.SchemeDelimiter + Request.Host;
            var defaultSetting = _settingService.DefaultEmailSetting();
            var EmailValue = new EmailValue();
            EmailValue.WebsiteName = defaultSetting.CompanyName;
            EmailValue.HomePage = HomePage;
            EmailValue.Login = HomePage + "/Account/Login";
            EmailValue.ButtonClick = callbackUrl;
            EmailValue.ButtonText = "Confirm Link";
            EmailValue.EmailTitle = "Confirmation Account";
            EmailValue.Content = "Please, Confirm you account  by this link.";
            EmailValue.Phone = defaultSetting.CompanyPhone;
            EmailValue.LogoURL = defaultSetting.logo.Replace("svg", "png");
            var Content = await _razorViewToStringRenderer.RenderViewToStringAsync("_MailSender", EmailValue);

            return
               await _mailSender.SendMail(EmailValue.EmailTitle, Content, email);

        }

        public async Task<bool> AddLastActivity(string tableName, string Type, string Id)
        {
            try
            {

                var json = new[]
                   {
                        new {
                                TableID =  Id,
                                TableName = tableName,
                                FullName = User.FullName(),
                                UserID = UserManager.GetUserId(User),
                                Type = Type,
                                DateTime = DateTime.Now.SystemTime().ToString("yyyy/MM/dd hh:mm:tt"),
                        },};

                var lastActivity = new LastActivityEnt();
                lastActivity.modifiedInfo = JsonConvert.SerializeObject(json);
                return await _factorService.AddLastActivityAsync(lastActivity);

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<string> SendInstallationReportToUserID(string title, string content, string UserID, string privateID)
        {
            if (!_settingService.UseEmailService())
                return "Email Service is Disable.";

            var appUser = await UserManager.FindByIdAsync(UserID);
            string email = appUser != null ? appUser.Email : _settingService.DefaultReciverEmail();

            HomePage = Request.Scheme + System.Uri.SchemeDelimiter + Request.Host;
            var defaultSetting = await _settingService.DefaultEmailSettingAsync();
            var EmailValue = new EmailValue();
            EmailValue.WebsiteName = defaultSetting.CompanyName;
            EmailValue.HomePage = HomePage;
            EmailValue.Login = HomePage + "/Account/Login";
            EmailValue.ButtonClick = HomePage + "/User/ViewInstallAppointment/" + privateID + "?email=" + email;
            EmailValue.ButtonText = "View Installation Appointment";
            EmailValue.EmailTitle = title;
            EmailValue.Content = content;
            EmailValue.Phone = defaultSetting.CompanyPhone;
            EmailValue.LogoURL = defaultSetting.logo.Replace("svg", "png");

            var Content = await _razorViewToStringRenderer.RenderViewToStringAsync("_MailSender", EmailValue);
            return await _mailSender.SendMail(EmailValue.EmailTitle, Content, email);

        }


        public async Task<string> SendEmailByUserID(string title, string content, string UserID)
        {
            if (!_settingService.UseEmailService())
                return "Email Service is Disable.";
            var userApp = (await UserManager.FindByIdAsync(UserID)) ?? new ApplicationUser();

            string email = userApp?.Email ?? "";
            if (UserID == "Admin")
                email = _settingService.DefaultReciverEmail();

            HomePage = Request.Scheme + System.Uri.SchemeDelimiter + Request.Host;
            var defaultSetting = _settingService.DefaultEmailSetting();
            var EmailValue = new EmailValue();
            EmailValue.WebsiteName = defaultSetting.CompanyName;
            EmailValue.HomePage = HomePage;
            EmailValue.Login = HomePage + "/Account/Login";
            EmailValue.EmailTitle = title;
            EmailValue.Content = content;
            EmailValue.Phone = defaultSetting.CompanyPhone;
            EmailValue.LogoURL = defaultSetting.logo.Replace("svg", "png");
            var Content = await _razorViewToStringRenderer.RenderViewToStringAsync("_MailSender", EmailValue);
            return
              await _mailSender.SendMail(EmailValue.EmailTitle, Content, email);
        }
        public async Task<string> SendEstimationReportToUserID(string title, string content, string UserID, string privateID)
        {
            if (!_settingService.UseEmailService())
                return "Email Service is Disable.";

            var appUser = await UserManager.FindByIdAsync(UserID);
            string email = appUser != null ? appUser.Email : _settingService.DefaultReciverEmail();

            HomePage = Request.Scheme + System.Uri.SchemeDelimiter + Request.Host;
            var defaultSetting = _settingService.DefaultEmailSetting();
            var EmailValue = new EmailValue();
            EmailValue.WebsiteName = defaultSetting.CompanyName;
            EmailValue.HomePage = HomePage;
            EmailValue.Login = HomePage + "/Account/Login";
            EmailValue.ButtonClick = HomePage + "/User/ViewEstimateAppointment/" + privateID + "?email=" + email;
            EmailValue.ButtonText = "View Estimate Appointment";
            EmailValue.EmailTitle = title;
            EmailValue.Content = content;
            EmailValue.Phone = defaultSetting.CompanyPhone;
            EmailValue.LogoURL = defaultSetting.logo.Replace("svg", "png");

            var Content = await _razorViewToStringRenderer.RenderViewToStringAsync("_MailSender", EmailValue);
            return await _mailSender.SendMail(EmailValue.EmailTitle, Content, email);

        }

    }
}