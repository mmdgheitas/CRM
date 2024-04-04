using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.Report
{
    public class InstallRequestViewModel
    {
        public bool PONumber { get; set; }
        public bool Customer { get; set; }
        public bool PhoneNumber { get; set; }
        public bool EmailAddress { get; set; }
        public bool AppointmentDate { get; set; }
        public bool Time { get; set; }
        public bool InstallTime { get; set; }
        public bool Confirmed { get; set; }
        public bool test { get; set; }
        public bool modifiedInfo { get; set; }
        public InstallRequestViewModel()
        {
            PONumber = true;
            Customer = true;
            PhoneNumber = true;
            EmailAddress = true;
            AppointmentDate = true;
            Time = true;
            InstallTime = true;
            Confirmed = true;
            modifiedInfo = true;
            test = false;
        }

    }




}