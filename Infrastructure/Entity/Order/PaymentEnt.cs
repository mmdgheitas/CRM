

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

using System.Web;

namespace Infrastructure.Entity
{
    public class PaymentEnt : EntityBase<long>
    {
        public string? UserID { get; set; }
        public string? FullName { get; set; }
        public int FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
        public DateTime PayDate { get; set; }

        public double Price { get; set; }
        [Display(Name = "Pay Type")]
        public PayType PayType { get; set; }
        public bool Confirmed { get; set; }
        public string? PaymentID { get; set; }
        public string? FileCheck { get; set; }
        public string? FileCheckBack { get; set; }
        public bool VendorSent { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ConfirmUserName { get; set; }
        public string? Description { get; set; }
        public PaymentEnt()
        {
        }
    }
    public enum PayType
    {
        None = 0,
        ByCreadit = 1,
        ACH = 2,
        ByCHeck = 3,
        Cach = 4,
        ByAdmin = 5,
        Refund = 6,
    }
    public class PayTypeModel
    {
        public string PayTypeTitle { get; set; }
        public int PayTypeValue { get; set; }
    }

    public class PaymentConfimationViewModel
    {

        public string Date { get; set; }
        public string Time { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerEmail { get; set; }
        public PayType PayType { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }

    }

    public class PaymentExcel
    {
        public int PONumber { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public PayType PayType { get; set; }
        public bool Confirm { get; set; }
        public string Description { get; set; }
        public int rowID { get; set; }
        public bool Duplicate { get; set; } = false;
        public bool PO_OK { get; set; } = true;
        public double ProjectRemaining { get; set; }
    }

    public class ListPaymentExcelImport
    {
        public List<PaymentExcel> ListPayment { get; set; }
   
        public int pageitemcount { get; set; }
        public int pagecount { get; set; }
        public int pagenumber { get; set; }
        public int modelCount { get; set; }
        public bool UseDocumentVersion { get; set; }
    }
}
  
