using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.Report
{
    public class OrderViewModel
    {
        public bool ItemNumber { get; set; }
        public bool OrderDate { get; set; }
        public bool ReciveDate { get; set; }
        public bool vandor { get; set; }
        public bool Shipping { get; set; }
        public bool Status { get; set; }
        public bool Delivered { get; set; }
        public bool DeliveredUserName { get; set; }
        public bool modifiedInfo { get; set; }
        public bool test { get; set; }

        public OrderViewModel()
        {
            ItemNumber = true;
            OrderDate = true;
            ReciveDate = true;
            vandor = true;
            Shipping = true;
            Status = true;
            Delivered = true;
            DeliveredUserName = true;
            modifiedInfo = true;
            test = false;

        }

    }




}