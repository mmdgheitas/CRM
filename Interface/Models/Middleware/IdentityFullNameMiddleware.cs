using Interface.Data;
using Microsoft.AspNetCore.Identity;
using SQLitePCL;
using System.Security.Claims;

namespace Interface.Models.Middleware
{
    public class IdentityFullNameMiddleware
    {
        private readonly RequestDelegate _next;
       // private readonly UserManager<ApplicationUser> userManager;

        public IdentityFullNameMiddleware(RequestDelegate next/*, UserManager<ApplicationUser> _userManager*/)
        {
            _next = next;
          //  userManager = _userManager;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
            {
               // var UserApp = await userManager.GetUserAsync(httpContext.User);
               // var fullName = (UserApp?.FirstName ?? "") + " " + (UserApp?.LastName ?? "");
            //    fullName = fullName.Trim(' ');
                httpContext.User.Identities.FirstOrDefault().AddClaim(new Claim("FullName", "Omid_Omid"));
            }
            await _next(httpContext);
        }
    }
}
