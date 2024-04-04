using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models.Report
{
    public class UserViewModel
    {
        public bool FirstName { get; set; }
        public bool LastName { get; set; }
        public bool Email { get; set; }
        public bool PhoneNumber { get; set; }
        public bool Enable { get; set; }
        public bool City { get; set; }
        public bool Address { get; set; }
        public bool LastLogin { get; set; }
        public bool modifiedInfo { get; set; }
        public bool test { get; set; }

        public UserViewModel()
        {
            FirstName = true;
            LastName = true;
            Email = true;
            PhoneNumber = true;
            Enable = true;
            City = true;
            modifiedInfo = true;
            Address = true;
            LastLogin = true;
            test = false;
       
        }
    }
}