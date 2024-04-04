using Microsoft.AspNet.Identity;
using Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Infrastructure.Repository;
using Infrastructure.Entity;
using Infrastructure.Service.Implement;
using Interface.Repository;
using System.Reflection;
using Interface.Utilities;
using System.Web.Security;
using Infrastructure.Service.Interface;

namespace Interface.Authorize
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        public string Controller { get; set; }
        public string Actions { get; set; }

        public string AliasName { get; set; }
        public ActionType Type { get; set; }

        public IdentityManager IdentityManager { get; set; }

        public CustomAuthorize(string AliasName, ActionType Type = ActionType.System)
        {
            this.AliasName = AliasName;
            this.Type = Type;
            IdentityManager = new IdentityManager(new ApplicationDbContext());

        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                return false;
            }
            return true;

            var user = httpContext.User;
            //   var appUser = IdentityManager._userManager.FindById(httpContext.User.Identity.GetUserId()) ;
            if (user.IsInRole("Administrator") )//اگر مدیران وبسایت بودند اازه دسترسی بده
            {
                // Administrator => let him in
                return true;
            }
            if (Type == ActionType.System)//نوع اکشن سیستم آزاد است
                return true;
            ///   var rd = httpContext.Request.RequestContext.RouteData;
            ///   var queryString = actionContext.Request
            //string Lang = "";
            //string WS = "";

            //if (HttpContext.Current.Request.QueryString["language"] == null || HttpContext.Current.Request.QueryString["language"] == "undefined")
            //    Lang = httpContext.User.GetClaimValue("language");
            //else
            //{
            //    Lang = HttpContext.Current.Request.QueryString["language"].ToString();
            //    httpContext.User.AddUpdateClaim("language", HttpContext.Current.Request.QueryString["language"].ToString());
            //}

            //if (HttpContext.Current.Request.QueryString["WS"] == null || HttpContext.Current.Request.QueryString["WS"] == "undefined")
            //    Lang = httpContext.User.GetClaimValue("WS");
            //else
            //{
            //    WS = HttpContext.Current.Request.QueryString["WS"].ToString();
            //    httpContext.User.AddUpdateClaim("WS", WS);
            //}
            //if (!string.IsNullOrEmpty(Lang) & !string.IsNullOrEmpty(WS))
            //{
            //    var Language = Lang;
            //    var Website = WS;
            //    //var r1 = user.IsInRole(Language);
            //    //var r2 = user.IsInRole(Website);
            //    if (!user.IsInRole(Language) & !user.IsInRole(Website))//اگر به زبان مورد نظر دسترسی داشت دسترسی بده
            //        return false;
            //}

            var listAllRoles = IdentityManager._roleManager.Roles.ToList();
            var UserRoles = IdentityManager._userManager.GetRoles(HttpContext.Current.Request.RequestContext.HttpContext.User.Identity.GetUserId());
            IRepositoryBase<RolePermisionEnt, int> _rolePermisionRepo = new RepositoryBase<RolePermisionEnt, int>();
            IRolePermisionService _rolePermisionService = new RolePermisionService(_rolePermisionRepo);

            var RolePermision = _rolePermisionService.ListRolePermisionForAction(AliasName, Type);
            foreach (var permision in RolePermision)
            {
                foreach (var role in UserRoles)
                {
                    //if (IdentityManager._roleManager.FindById(permision.RoleID).Name == role)//چک کردن اینکه اکشن جاری در پرمیشن رول هایش هست یا نه
                    //    return true;

                    if ((listAllRoles.FirstOrDefault(p => p.Id == permision.RoleID)?.Name ?? "") == role)//چک کردن اینکه اکشن جاری در پرمیشن رول هایش هست یا نه
                        return true;
                }
            }
            return false;

        }


        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                JsonResult UnauthorizedResult = new JsonResult();
                UnauthorizedResult.Data = new { success = false, responseText = "Access Denied!" };
                UnauthorizedResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                filterContext.Result = UnauthorizedResult;
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                      new RouteValueDictionary(
                          new
                          {
                              Area = "Private",
                              controller = "Account",
                              action = "Login",
                              returnUrl = filterContext.HttpContext.Request.Url.GetComponents(UriComponents.PathAndQuery, UriFormat.SafeUnescaped)
                          }));
            }





        }
    }


}