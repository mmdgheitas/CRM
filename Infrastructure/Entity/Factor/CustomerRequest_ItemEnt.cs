

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class CustomerRequest_ItemEnt : EntityBase<int>
    {
        public long ItemID { get; set; }
        public virtual ItemEnt Item { get; set; }
        public long CustomerRequestID { get; set; }
        public virtual CustomerRequestEnt CustomerRequest { get; set; }
        public CustomerRequest_ItemEnt()
        {
        }
    }


  
}