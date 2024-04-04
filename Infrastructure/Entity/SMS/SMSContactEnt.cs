

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
   
    public class SMSContactEnt : EntityBase<long>
    {
        [StringLength(100)] 
        public string? FullName { get; set; }
        [StringLength(100)]
        public string? PhoneNumber { get; set; }
        public string? HomePhone { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? JoinDate { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(100)]
        public string? Prefix { get; set; }

    }


}