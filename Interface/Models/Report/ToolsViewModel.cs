using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.Report
{
    public class ToolsViewModel
    {
        public bool Tools { get; set; }
        public bool Carear { get; set; }
        public bool CarearDate { get; set; }
        public bool TransferTo { get; set; }
        public bool modifiedInfo { get; set; }
        public bool test { get; set; }
        public ToolsViewModel()
        {
            Tools =  true;
            Carear = true;
            CarearDate = true;
            TransferTo = true;
            modifiedInfo = true;
            test = false;
        }

    }

 
}