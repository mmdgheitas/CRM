using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models.EmployeeApplication
{
    public class ProjectModel_EmployeeApp
    {
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Admin { get; set; }
        public string ViewLink { get; set; }

        public int PONumber { get; set; }
        public FactorStatus Status { get; set; }
        public FactorProgressStatus ProgressStatus { get; set; }

        public double TotalPrice { get; set; }
        public double Remaining { get; set; }
        public double PaidPrice { get; set; }
        public double TaxAmount { get; set; }

    }
}