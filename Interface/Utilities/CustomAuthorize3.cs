using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Utils;
using System.Security.Claims;
using Infrastructure.Entity;
using Microsoft.EntityFrameworkCore.Sqlite.Query.Internal;

namespace Interface.Utilities
{
    public class CustomAuthorize3 : TypeFilterAttribute
    {
        
    }

    public class CustomAuthorizeFilter3 : IAuthorizationFilter
    {
    

        public CustomAuthorizeFilter3(string _aliasName, ActionType _type)
        {
          
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
           
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                if (context.HttpContext.Request.IsAjaxRequest())
                {
                    //JsonResult UnauthorizedResult = new JsonResult();
                    //UnauthorizedResult.Data = new { success = false, api = false, responseText = "You don't have permission to access on this page" };
                    //UnauthorizedResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    //filterContext.Result = UnauthorizedResult;

                    context.Result = new ForbidResult();

                }
                else
                {
                    context.Result = new ForbidResult();
                }
            }

      
            return;
        }
    }

}
