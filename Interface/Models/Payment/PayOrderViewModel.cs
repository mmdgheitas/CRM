using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models.Payment
{
    public class PayOrderViewModel
    {
        public string Invoice { get; set; }
        public string ContractText { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string DigitalSign { get; set; }
        public int Price { get; set; }
        public int PriceType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

    }

    public enum PaymentMethod
    {
        Catch = 1,
        Check = 2,
        Trade = 3,
    }
}