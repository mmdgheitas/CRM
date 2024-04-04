using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Interface.Models.Plaid
{
    public class ApiJsonResult
    {
        public HttpStatusCode code { get; set; }
        public string user_message { get; set; }
        public string developer_message { get; set; }
        public object results { get; set; } = null;
    }
    public class ApiJsonResultNotNull
    {
        public HttpStatusCode code { get; set; }
        public string user_message { get; set; }
        public string developer_message { get; set; }
    
    }


}
