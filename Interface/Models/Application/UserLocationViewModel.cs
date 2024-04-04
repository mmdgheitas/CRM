using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models
{
    public class UserLocationViewModel
    {
        public string UserID { get; set; }
        public string FullName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
    }
}