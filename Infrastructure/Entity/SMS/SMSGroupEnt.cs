

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
   
    public class SMSGroupEnt : EntityBase<int>
    {
        [Display(Name = "نام گروه")]
        public string? Name { get; set; }
    }


}