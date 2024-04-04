using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models.Plaid
{
    public class TitleModel
    {
        public string title { get; set; }
        public int? categotyId { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public TitleModel()
        {
            categotyId = null;
            email = "";
            phone = "";
            title = "";
        }
    }

    public class TitleModelTest
    {
        public int id { get; set; }
    
      
    }
}