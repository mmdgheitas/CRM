

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
   
    public class SMSGroupNoNameEnt : EntityBase<int>
    {
        [Display(Name = "نام گروه")]
        public string? Name { get; set; }
        public string? ContactList { get; set; }
    }


}