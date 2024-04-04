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
    public class CustomAuthorize3 : AuthorizeAttribute
    {

        //public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)

        //{

        //    if (AuthorizeRequest(actionContext))

        //    {

        //        return;

        //    }

        //    HandleUnauthorizedRequest(actionContext);

        //}
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                JsonResult UnauthorizedResult = new JsonResult();
                UnauthorizedResult.Data = new { success = false, api = false, responseText = "You don't have permission to access on this page" };
                UnauthorizedResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                filterContext.Result = UnauthorizedResult;
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }





        }
        private bool AuthorizeRequest(System.Web.Http.Controllers.HttpActionContext actionContext)

        {

            //Write your code here to perform authorization

            return true;

        }
    }


}