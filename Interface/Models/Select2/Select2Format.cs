using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models.Select2
{
    public class DocumentPagedResult
    {
        public int Total { get; set; }
        public List<DocumentResult> Results { get; set; }
    }

    public class DocumentResult
    {
        public string id { get; set; }
        public string text { get; set; }
        public string title { get; set; }
        public string regnum { get; set; }
        public string author { get; set; }
        public string helpnumber { get; set; }
    }


    public class UserPagedResult
    {
        public int Total { get; set; }
        public List<FactorResult> Results { get; set; }
    }

    public class FactorResult
    {

        public string id { get; set; }
        public string po { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string projectName { get; set; }
        public string cid { get; set; }

    }
}