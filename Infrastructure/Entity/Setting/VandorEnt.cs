

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class VandorEnt : EntityBase<int>
    {
    
        [Required(ErrorMessage = "Title is required")]
        public string? Name { get; set; }
        public string? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Goods { get; set; }
        public VandorType Type { get; set; }
    }
    public enum VandorType
    {
        ProjectVandor = 0,
        ExpenseVandor = 1,
    }
}

  
