

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class JobTypeEnt : EntityBase<int>
    {
        [Required]
        public string Title { get; set; }
        public bool HideForCustomer { get; set; }
    }
    public class JobTypeModel : EntityBase<int>
    {
        [Required]
        public string Title { get; set; }
        public bool Select { get; set; }
        public string UserID { get; set; }
        public int FactorID { get; set; }
    }
}