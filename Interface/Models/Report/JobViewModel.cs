using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.Report
{
    public class JobViewModel
    {
        public bool PONumber { get; set; }
        public bool Date { get; set; }

        //   public bool IsFinish { get; set; }
        [Display(Name = "Total Price")]
        public bool TotalPrice { get; set; }
        [Display(Name = "Paid Price")]
        public bool PaidPrice { get; set; }
        public bool Remaining { get; set; }
        [Display(Name = "Tax Percent")]
        public bool Tax { get; set; }
        [Display(Name = "Tax Amount")]
        public bool TaxAmount { get; set; }
        [Display(Name = "Project Reseller Permit")]
        public bool ResellerPermit { get; set; }
        [Display(Name = "Customer Reseller Permit")]
        public bool CustomerResellerPermit { get; set; }
        public bool Customer { get; set; }

        public bool Status { get; set; }
        public bool LinkAdmin { get; set; }
        public bool LinkCustomer { get; set; }
        public bool ProjectName { get; set; }
        public bool Address { get; set; }
        public bool Phone { get; set; }
        public bool Email { get; set; }
        public bool Company { get; set; }


        public bool Item { get; set; }
        public bool Payments { get; set; }
        public bool CheckFile { get; set; }
        public bool modifiedInfo { get; set; }

        public bool test { get; set; }

        public JobViewModel()
        {
            PONumber = true;
            Date = true;
            TotalPrice = true;
            PaidPrice = true;
            Remaining = true;
            Customer = true;
            Status = true;

            modifiedInfo = false;
            test = false;
            Item = true;
            Tax = true;
            TaxAmount = true;
            ResellerPermit = false;
            CustomerResellerPermit = false;

        }

    }


}