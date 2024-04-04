using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models.Factor
{
    public class JqGridData
    {
        public string page { get; set; }
        public string total { get; set; }
        public string records { get; set; }
        public object rows { get; set; }
    }
}