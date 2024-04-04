using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.Report
{
    public class WorkSchedulingViewModel
    {
        public bool Title { get; set; }
        public bool User { get; set; }
        public bool StartDate { get; set; }
        public bool EndDate { get; set; }
        public bool StartHour { get; set; }
        public bool StartMin { get; set; }
        public bool EndHour { get; set; }
        public bool EndMin { get; set; }
        public bool modifiedInfo { get; set; }
        public bool test { get; set; }

        public WorkSchedulingViewModel()
        {
            Title = true;
            User = true;
            StartDate = true;
            EndDate = true;
            StartHour = true;
            StartMin = true;
            EndHour = true;
            EndMin = true;
            modifiedInfo = true;
            test = false;
    }
}
    
}
    

 
    
