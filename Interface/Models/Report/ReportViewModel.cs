using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.Report
{
    public class ReportViewModel
    {
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }
        [Display(Name = "End Date")]
        public string EndDate { get; set; }
        [Display(Name = "Filter Date")]
        public bool UseDate { get; set; }
        public string Search { get; set; }
        [Display(Name = "List Table")]
        public List<Table> ListTable { get; set; }
        public UserViewModel User { get; set; }
        public JobViewModel Job { get; set; }
        public ItemViewModel Item { get; set; }
        public ExpenseViewModel Expense { get; set; }
        public ItemModifireViewModel ItemModifire { get; set; }
        public WorkSchedulingViewModel workscheduling { get; set; }
        public InstallRequestViewModel installRequest { get; set; }
        public OrderViewModel order { get; set; }
        public ToolsViewModel Tools { get; set; }
        public PaymentViewModel Payment { get; set; }

    }

    public class Table
    {
        public string Title { get; set; }
        public string Name { get; set; }
    }
}