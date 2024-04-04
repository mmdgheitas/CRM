using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models.Application
{
    public class UpdateApplicationViewModel
    {
        public double Version { get; set; }
        public double Buile { get; set; }
        public string UpdateDescription { get; set; }
        public string DownloadLink { get; set; }
        public bool DownloadForce { get; set; }

     
    }
}