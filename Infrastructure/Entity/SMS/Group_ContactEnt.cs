

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
   
    public class Group_ContactEnt : EntityBase<long>
    {
        public int SMSGroupID { get; set; }
        public virtual SMSGroupEnt SMSGroup  { get; set; }

        public long SMSContactID { get; set; }
        public virtual SMSContactEnt SMSContact { get; set; }
    }


}