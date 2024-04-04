using Infrastructure.Entity;
using Interface.Models.Factor;
using Interface.Models.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models
{
    public class EstimationProjectViewModel
    {
        public string PrivateID { get; set; }
        public int FactorID { get; set; }
        public FactorEnt Factor { get; set; }
        public PayType PayType { get; set; }
        public int PONumber { get; set; }
        public Client Client { get; set; }
        public bool ShippingIsBilling { get; set; }
        public CustomerOrderToEnt Shipping { get; set; }
        public List<Factor_ItemEnt> ListItems { get; set; }
        public EstimatePaymentModel PaymentViewModel { get; set; }
        public List<PaymentModel> PaymentList { get; set; }
        public RequestInstallerAppointmentModel InstallationDateModel { get; set; }
        public RequestEstimateAppointmentModel EstimationDateModel { get; set; }

        public List<InstallerAppointmentEnt> ListInstallations { get; set; }
        public List<EstimateAppointmentEnt> ListEstimations { get; set; }
        public EmailSettingEnt EmailSetting { get; set; }
        public List<StateEnt> ListStates { get; set; }
        public List<CityEnt> ListOrderCity { get; set; }
     
        public List<CityEnt> ListCities { get; set; }
        public EstimationProjectViewModel()
        {
            ShippingIsBilling = true;
            PaymentList = new List<PaymentModel>();
            EstimationDateModel = new RequestEstimateAppointmentModel();
        }
    }


    public class EstimatePaymentModel : EntityBase<long>
    {
  

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
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public double Price { get; set; }
        [Display(Name = "Pay Type")]
        public PayType PayType { get; set; }
        public string PayTypeStr { get; set; }
        public bool PayAdmin { get; set; }
        [Display(Name = "Electronic Signature")]
        public string ElectronicSignature { get; set; }
        public byte[] ElectronicSignatureByte { get; set; }
        public bool Signed { get; set; }
       
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
        [Display(Name = "Check File")]
        public IFormFile FileCheckUpload { get; set; }
        [Display(Name = "Tech ID")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Type your name here")]
        [Required(ErrorMessage = "Please type your name")]
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
        public bool receipt { get; set; }
     
        public List<PayTypeModel> PayTypeList { get; set; }
        public string Terms { get; set; }
        [Display(Name = "Captcha")]
        public string Captcha { get; set; }
        public string PrivateID { get; set; }
       

        public List<CardListViewModel> CardList { get; set; }
        public string CardID { get; set; }
        public bool SaveCard { get; set; }
        public string Description { get; set; }

        public EstimatePaymentModel()
        {
            receipt = false;
            Signed = false;

        }
    }
    public class Client
    {
        public string UserID { get; set; }
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [Display(Name = "Name")]
        [StringLength(120)]
        public string FirstName { get; set; }
    

        [EmailAddress(ErrorMessage = "please enter valid email address")]
        [Required(ErrorMessage = "Please enter billing email addredd")]
        [Display(Name = "Email ")]
        public string Email { get; set; }

        [EmailAddress(ErrorMessage = "please enter valid accounting email address")]
        [Display(Name = "Second Email ")]
        public string? SecondEmail { get; set; }
        [Display(Name = "Company")]
        public string? CompanyName { get; set; }

        [Display(Name = "Street address ")]
        [Required(ErrorMessage = "please enter street address")]
        public string Address { get; set; }
        [Display(Name = "Zip/Postal Code")]
        public string ZipCode { get; set; }
       
        [Display(Name = "City ")]
        public int CityID { get; set; }
        public CityEnt City { get; set; }
        [Display(Name = "State ")]
        public int StateID { get; set; }

        [Display(Name = "Phone")]
        //  [RegularExpression(@"(0|\+98|0098)?([ ]|,|-|[()]){0,2}9[0|1|2|3|4]([ ]|,|-|[()]){0,2}(?:[0-9]([ ]|,|-|[()]){0,2}){8}", ErrorMessage = "لطفا شماره تلفن صحیح را وارد کنید")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Phone Number must be 10 digit number")]
        [Required(ErrorMessage = "Please enter phone number")]
        public string PhoneNumber { get; set; }

        public bool UserCheckProfile { get; set; }



    }
}