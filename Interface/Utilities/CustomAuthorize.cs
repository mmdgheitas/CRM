using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Utils;
using System.Security.Claims;
using Infrastructure.Entity;
using Microsoft.EntityFrameworkCore.Sqlite.Query.Internal;
using Infrastructure.Repository;
using Infrastructure.Service.Implement;
using Infrastructure.Service.Interface;
using Interface.Data;
using Interface.Repository;
using Microsoft.AspNetCore.Identity;

using System.Web.Http.Controllers;


namespace Interface.Utilities
{
    public class CustomAuthorize : TypeFilterAttribute
    {
        public CustomAuthorize(string AliasName, ActionType Type) : base(typeof(CustomAuthorizeFilter))
        {
            Arguments = new object[] { AliasName, Type };
        }
    }

    public class CustomAuthorizeFilter : IAuthorizationFilter
    {
        private readonly string AliasName;
        private readonly ActionType Type;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IRolePermisionService roleService;




        public CustomAuthorizeFilter(string _aliasName, ActionType _type, RoleManager<ApplicationRole> _roleManaer , UserManager<ApplicationUser> _userManager, IRolePermisionService roleService)
        {
            AliasName = _aliasName;
            Type = _type;
            roleManager = _roleManaer;
            userManager = _userManager;
            this.roleService = roleService;
        }

        public  void OnAuthorization(AuthorizationFilterContext context)
        {

            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new ForbidResult();
            }


            var user = context.HttpContext.User;
            //   var appUser = IdentityManager._userManager.FindById(httpContext.User.Identity.GetUserId()) ;
            if (user.IsInRole("Administrator") || Type == ActionType.System)//اگر مدیران وبسایت بودند اازه دسترسی بده
            {
                return;
            }



            var listAllRoles = roleManager.Roles.ToList();
            var CurrentUser = userManager.FindByIdAsync(userManager.GetUserId(user)).Result;
            var UserRoles = userManager.GetRolesAsync(CurrentUser).Result;
     
            var RolePermision = roleService.ListRolePermisionForAction(AliasName, Type);
            foreach (var permision in RolePermision)
            {
                foreach (var role in UserRoles)
                {
                    //if (IdentityManager._roleManager.FindById(permision.RoleID).Name == role)//چک کردن اینکه اکشن جاری در پرمیشن رول هایش هست یا نه
                    //    return true;

                    if ((listAllRoles.FirstOrDefault(p => p.Id == permision.RoleID)?.Name ?? "") == role)//چک کردن اینکه اکشن جاری در پرمیشن رول هایش هست یا نه
                        return ;
                }
            }
            context.Result = new ForbidResult();
        }
    }

}
