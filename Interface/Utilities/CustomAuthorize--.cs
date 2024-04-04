using Microsoft.AspNet.Identity;
using Interface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Infrastructure.Repository;
using Infrastructure.Entity;
using Infrastructure.Service.Implement;
using Interface.Repository;
using System.Reflection;
using Interface.Utilities;

using Infrastructure.Service.Interface;
using System.Web.Http;
using Interface.Data;

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



    }


}