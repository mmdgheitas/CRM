

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class CustomerOrderToEnt : EntityBase<int>
    {
        [Display(Name = "Contact")]
        public string?  Contact { get; set; }
        [Display(Name = "Project Name")]

        public string?  CompanyName { get; set; }
        [Display(Name = "Work Order")]
        public string? WorkOrder { get; set; }
        [Display(Name = "City")]
        public int CityID { get; set; }
        [Display(Name = "Address")]
        public virtual CityEnt City { get; set; }
        [Display(Name = "State")]
        public int StateID { get; set; }
        public string?  ZipCode { get; set; }
        [Display(Name = "Phone")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Phone Number must be 10 digit number")]
        public string?  PhoneNumber { get; set; }
        [Display(Name = "Street address")]
        public string?  Address { get; set; }
        [NotMapped]
        public string?  FullAddress { get; set; }
        [NotMapped]
        [Display(Name = "Map")]
        public string?  GoogleMap { get; set; }
        [EmailAddress]
        public string?  Email { get; set; }
        public string?  UserID { get; set; }
        public int FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
        public bool IsProject { get; set; }

        [NotMapped]
        public List<CityEnt> ListCities { get; set; } 


    }
}

  

