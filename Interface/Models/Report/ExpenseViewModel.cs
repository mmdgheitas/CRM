using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models.Report
{
    public class ExpenseViewModel
    {
        public bool Date { get; set; } = true;

        public bool Amount { get; set; } = true;
        public bool  Product { get; set; } = true;
        public bool Category { get; set; } = true;
        public bool SubCategory { get; set; } = true;
        public bool Vendor { get; set; } = true;
        public bool Project { get; set; } = true;
        public bool PaymentType { get; set; } = true;
        public bool PayAccount { get; set; } = true;
        public bool User { get; set; } = true;
        public bool test { get; set; } 
    }
}