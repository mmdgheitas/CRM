using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entity
{
    public class ResellerPermitEnt : EntityBase<long>
    {
        public string? ResellerPermit { get; set; }
        public string? File { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? UserID { get; set; }


        public ResellerPermitEnt()
        {
         
        }
    }


    public class ResellerPremitStatus : EntityBase<long>
    {
        public string ResellerPermit { get; set; }
        public string File { get; set; }
        public bool isActive { get; set; }
        public bool Exist { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string EffectiveDatee { get; set; }
        public string ExpirationDatee { get; set; }
    }

    public class ResellerPremitViewModel
    {
        [Display(Name = "Reseller Permit")]
        [Required]
        public string ResellerPermit { get; set; }

        public string File { get; set; }
        public IFormFile FileUpload { get; set; }
        [Display(Name = "Effective Date")]
        [Required]
        public string EffectiveDatee { get; set; }
        [Required]
        [Display(Name = "Expiration Date")]
        public string ExpirationDatee { get; set; }
        public string UserID { get; set; }
        public List<ResellerPermitEnt> ListResellerPremits { get; set; }
    }


  
}