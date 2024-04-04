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
    public class CustomAuthorizeAdminUser : AuthorizeAttribute
    {


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authorized = base.AuthorizeCore(httpContext);
            if (!authorized)
            {
                return false;
            }

            var user = httpContext.User;
            if (user.IsInRole("Administrator") | user.IsInRole("Admin") | user.IsInRole("LibraryAdmin") | user.IsInRole("Operator"))
                return true;
            else
                return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                JsonResult UnauthorizedResult = new JsonResult();
                UnauthorizedResult.Data = new { success = false, responseText = "محدودیت دسترسی!" };
                UnauthorizedResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                filterContext.Result = UnauthorizedResult;
            }
           
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                         new RouteValueDictionary(
                             new
                             {
                                 Area="Private",
                                 controller = "Account",
                                 action = "Login",
                                 returnUrl = filterContext.HttpContext.Request.Url.GetComponents(UriComponents.PathAndQuery, UriFormat.SafeUnescaped)
                             }));

            }





        }
    }


}