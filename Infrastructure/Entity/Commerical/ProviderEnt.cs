

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class ProviderEnt : EntityBase<int>
    {
        public string? Comapny { get; set; }
        public string? Address { get; set; } 
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Estimator { get; set; }
        public string? Cell { get; set; }
        public string? Licence { get; set; }
        public string? Bound { get; set; }
        [Display(Name = "Insurance Policy")]
        public string? InsurancePolicy { get; set; }
        [Display(Name  = "Default")]
        public bool isDefault { get; set; }

        public ProviderEnt()
        {
           
        }
    }


  
}