using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models.BreadCrumbLink
{
    public class breadCrumbLink
    {
        public string title { get; set; }
        public string url { get; set; }
        public bool current { get; set; }
    }
}