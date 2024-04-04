using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.Payment
{
    public class PaymentModel : EntityBase<long>
    {
        public string UserID { get; set; }
        public string FullName { get; set; }
        public int FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }

        public string PONumber { get; set; }
        public DateTime PayDate { get; set; }
        public string PayDateStr { get; set; }
        public string UpdateBtn { get; set; }

        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public double MinPrice { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public double SecondPrice { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public double ThirdPrice { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public double FouthPrice { get; set; }
        public bool MinimumPayed { get; set; }
        public bool SecondPayed { get; set; }
        public bool ThirdPayed { get; set; }
        public bool FourthPayed { get; set; }

        public string MinimumPayedStr { get; set; }
        public string SecondPayedStr { get; set; }
        public string ThirdPayedStr { get; set; }
        public string FourthPayedStr { get; set; }
        public bool emailPayment { get; set; }
        public string routid { get; set; }
        [Display(Name = "Amount")]
      //  [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public double Price { get; set; }
        [Display(Name = "Pay Type")]
        public PayType PayType { get; set; }
        public string PayTypeStr { get; set; }
        public string CustomerCardNumber { get; set; }
        public bool PayAdmin { get; set; }
        [Display(Name = "Electronic Signature")]
        public string ElectronicSignature { get; set; }
        public byte[] ElectronicSignatureByte { get; set; }
        public bool Signed { get; set; }
        public List<Factor_ItemEnt> ListItems { get; set; }
        [Display(Name = "Contract Text")]
        public string ContractText { get; set; }

        [Display(Name = "Payment Text 1")]
        public string PaymentText1 { get; set; }
        public bool Text1 { get; set; }
        [Display(Name = "Payment Text 2")]
        public string PaymentText2 { get; set; }
        public bool Text2 { get; set; }
        [Display(Name = "Payment Text 3")]
        public string PaymentText3 { get; set; }
        public bool Text3 { get; set; }
        [Display(Name = "Payment Text 4")]
        public string PaymentText4 { get; set; }
        public bool Text4 { get; set; }
        [Display(Name = "Payment Text 5")]
        public string PaymentText5 { get; set; }
        public bool Text5 { get; set; }
        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }
        public string FileCheck { get; set; }
        public string FileCheckBack { get; set; }
        [Display(Name = "Check File")]
        public IFormFile FileCheckUpload { get; set; }
        [Display(Name = "Check File")]
        public IFormFile FileCheckUpload2 { get; set; }
        [Display(Name = "Tech ID")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Type your name here")]
      //  [Required(ErrorMessage = "Please type your name")]
        public string PrintName { get; set; }

        public string PlaceOrderDate { get; set; }

        public string stripeEmail { get; set; }
        public string stripeToken { get; set; }
        public int Status { get; set; }

        //---------------------------------------------
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public double TaxAmount { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public double Payabel { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public decimal Tax { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public double FactorPrice { get; set; }
        public decimal TaxableFactorPrice { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public double PaidPrice { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public double UnapprovedPayments { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public double TotalPrice { get; set; }
        public double Remaining { get; set; }
        public string PaymentID { get; set; }
        public bool Confirmed { get; set; }
        public string ConfirmedStr { get; set; }
        public bool VendorSent { get; set; }
        public string VendorSentStr { get; set; }
        public string ConfirmUserName { get; set; }
        public EmailSettingEnt EmailSetting { get; set; }
        public bool receipt { get; set; }
        public User UserInfo { get; set; }
        public List<PayTypeModel> PayTypeList { get; set; }
        public string Terms { get; set; }
        public string TermDateConfirm { get; set; } 
        [Display(Name = "Captcha")]
        public string? Captcha { get; set; }
        public string PrivateID { get; set; }
        public List<PaymentModel> PaymentList { get; set; }
        public List<EstimateAppointmentEnt> EstimateAppointments { get; set; }
        public List<InstallerAppointmentEnt> InstallerAppointments { get; set; }

        public List<CardListViewModel> CardList { get; set; }
        public string? CardID { get; set; }
        public bool SaveCard { get; set; }
        public string? Description { get; set; }
   

        public PaymentModel()
        {
            receipt = false;
            Signed = false;
            EstimateAppointments = new List<EstimateAppointmentEnt>();
            InstallerAppointments = new List<InstallerAppointmentEnt>();
            PaymentList = new List<PaymentModel>();
        }
    }

    public class PaymentRefundModel : EntityBase<long>
    {
        public string Reason { get; set; }
        [Display(Name = "Price ($)")]
        public double Price { get; set; }
    }
        public class PaymentViewModelApp : EntityBase<long>
    {
        public string UserID { get; set; }
        public string FullName { get; set; }
        public int FactorID { get; set; }
     
        public DateTime PayDate { get; set; }
        public double Price { get; set; }
        [Display(Name = "Pay Type")]
        public PayType PayType { get; set; }


        public string FileCheck { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public PaymentViewModelApp()
        {
        
        }
    }

    public class PaymentModelApp : EntityBase<long>
    {
        public string UserID { get; set; }
        public string FullName { get; set; }
        public int FactorID { get; set; }
     

        public string PONumber { get; set; }
        public DateTime PayDate { get; set; }
        public string PayDateStr { get; set; }
        public double Price { get; set; }
     
        public PayType PayType { get; set; }
        public string PayTypeStr { get; set; }
        public bool PayAdmin { get; set; }
      
        public string FileCheck { get; set; }
     
        public string PrintName { get; set; }

      
        public int Status { get; set; }


        //---------------------------------------------
        public double TaxAmount { get; set; }
        public double Payabel { get; set; }
        public decimal Tax { get; set; }
        public double FactorPrice { get; set; }
        public decimal TaxableFactorPrice { get; set; }
        

        public double TotalPrice { get; set; }
        public double Remaining { get; set; }
        public string PaymentID { get; set; }
        public bool Confirmed { get; set; }
        public string ConfirmedStr { get; set; }
        public string CustomerCardNumber { get; set; }
        public string ConfirmUserName { get; set; }
        public User UserInfo { get; set; }
       
        public string PrivateID { get; set; }
    
        public string CardID { get; set; }


        public PaymentModelApp()
        {
        
        }
    }


    public class CardListViewModel
    {
        public string CustomerID { get; set; }
        public string CardNumers { get; set; }
    }

    public class DueDateViewModel
    {
        public int PoNumber { get; set; }
        public string CustomerFullName { get; set; }
        public double Amount { get; set; }
        public string Time { get; set; }
    }
}
 