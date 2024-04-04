

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class TeamEnt : EntityBase<int>
    {
        public string? TeamName { get; set; }
        public string? TeamAdminID { get; set; }
        
    }


  
}