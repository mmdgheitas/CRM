using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interface.Utilities
{
    public class OptionalAuthorizeAttribute : AuthorizeAttribute
    {
        private class Http403Result : ActionResult
        {
            public override void ExecuteResult(ControllerContext context)
            {
                // Set the response code to 403.
                context.HttpContext.Response.StatusCode = 403;
                context.HttpContext.Response.Write("logoff");
            }
        }

        private readonly bool _authorize;

        public OptionalAuthorizeAttribute()
        {
            _authorize = true;
        }

        //OptionalAuthorize is turned on on base controller class, so it has to be turned off on some controller. 
        //That is why parameter is introduced.
        public OptionalAuthorizeAttribute(bool authorize)
        {
            _authorize = authorize;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //When authorize parameter is set to false, not authorization should be performed.
            if (!_authorize)
                return true;

            var result = base.AuthorizeCore(httpContext);

            return result;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                //Ajax request doesn't return to login page, it just returns 403 error.
                filterContext.Result = new Http403Result();
            }
            else
                base.HandleUnauthorizedRequest(filterContext);
        }
    }
}