using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.Report
{
    public class PaymentViewModel
    {
        [Display(Name = "Pay Date")]
        public bool PayDate { get; set; }
        [Display(Name = "Customer Name")]
        public bool CustomerName { get; set; }
        [Display(Name = "Project Name")]
        public bool ProjectName { get; set; }
        [Display(Name = "Company Name")]
        public bool CompanyName { get; set; }
        public bool City { get; set; } = false;
        public bool PONumber { get; set; }
        public bool Amount { get; set; }
        public bool PayType { get; set; }
        public bool Confirmed { get; set; }
        public bool VendorSent { get; set; } = false;
        public bool ConfirmUserName { get; set; } = false;
        [Display(Name = "Sales Tax Amount")]
        public bool SalesTaxAmount { get; set; } = true;
        [Display(Name = "Sales Tax Rate")]
        public bool SalesTaxRate { get; set; } = true;
        [Display(Name = "Project Location")]
        public bool ProjectLocation { get; set; } = true;
        [Display(Name = "Reseller Permit")]
        public bool ResellerPermit { get; set; } = false;
        [Display(Name = "Customer Reseller Permit")]
        public bool CustomerResellerPermit { get; set; }
        public bool modifiedInfo { get; set; } = false;
        public bool test { get; set; }
        public PaymentViewModel()
        {
            PayDate = true;
            CustomerName = true;
            ProjectName = true;
            PONumber = true;
           // City = true;
            Amount = true;
            PayType = true;
            Confirmed = true;
     
            test = false;
        }

    }


}