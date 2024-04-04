using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using Infrastructure.Repository;
using Infrastructure.Service.Interface;
using Infrastructure.Entity;
using Interface.Repository;
using Infrastructure.Service.Implement;
using Microsoft.AspNetCore.Identity;
using Interface.Data;

namespace Interface.Models.Access
{

    public interface IAccess
    {
      bool  isAccessInLayout(string AccessName);
    }
    public class Access : IAccess
    {
        //public List<AceessInfo> _accessInfoList { get; set; }
        //private readonly IRepositoryBase<AccessLevelEnt, long> _accessLevelRep;
        //private readonly IAccessLevelService _accessLevelService;

        //private readonly IRepositoryBase<RolePermisionEnt, int> _rolePermisionRepo;
        //private readonly IRolePermisionService _rolePermisionService;
        //private IdentityManager IdentityManager { get; set; }
        //private readonly IList<string> UserRoles;
        //private readonly List<RolePermisionEnt> AllRolePermision;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IRolePermisionService roleService;
        private readonly IHttpContextAccessor context;

        public Access( RoleManager<ApplicationRole> _roleManaer, UserManager<ApplicationUser> _userManager, IRolePermisionService roleService, IHttpContextAccessor _context)
        {
         
            roleManager = _roleManaer;
            userManager = _userManager;
            this.roleService = roleService;
            context = _context;
        }

        //public Access(bool isDateBase = true, string UserID = null)
        //{

        //    //if (!isDateBase) isDateBase = !CheckForInternetConnection();//اگر درخواست از دیتابیس نبود واینترنت قطع بود، از دیتابیس بگیر

        //    //_accessLevelRep = new RepositoryBase<AccessLevelEnt, long>();
        //    //_accessLevelService = new AccessLevelService(_accessLevelRep);
        //    //_rolePermisionRepo = new RepositoryBase<RolePermisionEnt, int>();
        //    //_rolePermisionService = new RolePermisionService(_rolePermisionRepo);
        //    //IdentityManager = new IdentityManager(new ApplicationDbContext());
        //    //if (UserID != null)
        //    //    UserRoles = IdentityManager._userManager.GetRoles(UserID);
        //    //else
        //    //    UserRoles = new List<string>();
        //    //AllRolePermision = _rolePermisionService.ListAllRolePermisionForAction(ActionType.Read);
        //    //if (isDateBase)
        //    //{
        //    //    _accessInfoList = GetFromDataBase();
        //    //}
        //    //else
        //    //{
        //    //    _accessInfoList = Download();
        //    //  }

        //}
        //private List<AceessInfo> Download()
        //{
        //    List<AceessInfo> List = new List<AceessInfo>();
        //    try
        //    {
        //        string T = "";
        //        WebClient client = new WebClient();
        //        Stream stream = client.OpenRead("http://takprogram.ir/websites/webapplication/TakProgram.txt");
        //        StreamReader Read = new StreamReader(stream);
        //        for (int i = 0; (T = Read.ReadLine()) != null; i++)
        //        {

        //            if (!T.StartsWith("//"))
        //            {
        //                var item = new AceessInfo();
        //                try
        //                {
        //                    string[] tokens = T.Split('-');//جدا کردن تاریخ و نام
        //                    if (tokens.Count() == 1)
        //                    {
        //                        item.accessName = tokens[0];
        //                        item.ExpireDate = DateTime.Now;
        //                    }
        //                    else
        //                    {
        //                        item.accessName = tokens[0];
        //                        item.ExpireDate = tokens[1].ConverPersina2Miladi();
        //                    }
        //                    List.Add(item);
        //                }
        //                catch (Exception ex)
        //                {
        //                }


        //            }
        //        }
        //        Read.Close();

        //        return List;
        //    }
        //    catch (Exception ex)
        //    {
        //        return List;
        //    }
        //}
        //private List<AceessInfo> GetFromDataBase()
        //{
        //    List<AceessInfo> List = new List<AceessInfo>();
        //    try
        //    {
        //        string T = "";
        //        var ListAccesList = _accessLevelService.ListAllAccessList();

        //        foreach (var access in ListAccesList)///گرفتن اطلاعات ا ز دیتابیسLocal
        //        {
        //            var item = new AceessInfo();
        //            try
        //            {
        //                item.accessName = access.AccessName;
        //                item.ExpireDate = access.ActiveUntil;
        //                List.Add(item);
        //            }
        //            catch (Exception ex)
        //            {
        //            }
        //        }

        //        return List;
        //    }
        //    catch (Exception ex)
        //    {
        //        return List;
        //    }
        //}
        //public bool isAccess(string AccessName)
        //{
        //    try
        //    {

        //        var accessInfo = _accessInfoList.Where(p => p.accessName.Trim('|').ToLower() == AccessName.ToLower()).FirstOrDefault();
        //        if (accessInfo == null)
        //            return false;
        //        if (accessInfo.accessName.EndsWith("|"))
        //            return true;
        //        else if (accessInfo.ExpireDate > DateTime.Now)
        //            return true;
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        public bool isAccessInLayout(string AccessName)
        {
            try
            {


              
                var User = context.HttpContext?.User;
                if (User == null)
                    return false;
                if (User.IsInRole("Administrator") | User.IsInRole("sysAdmin") | User.IsInRole("Management"))//به صفحه نقش ها و مجوز ها دسترسی بده
                    return true;

                var listAllRoles = roleManager.Roles.ToList();
                var CurrentUser = userManager.FindByIdAsync(userManager.GetUserId(User)).Result;
                var UserRoles = userManager.GetRolesAsync(CurrentUser).Result;

                var RolePermision = roleService.ListRolePermisionForAction(AccessName, ActionType.Read);
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
                catch (Exception ex)
            {
                return false;
            }
        }
        //public List<AceessInfo> GetLastAccessInfoListFromTak()
        //{
        //    return _accessInfoList;
        //}
        //public static bool CheckForInternetConnection()
        //{
        //    try
        //    {
        //        using (var client = new WebClient())
        //        {
        //            using (var stream = client.OpenRead("http://www.google.com"))
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    
    }
    //public class AceessInfo
    //{
    //    public string accessName { get; set; }
    //    public DateTime ExpireDate { get; set; }
    //}


}