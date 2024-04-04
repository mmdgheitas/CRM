using Infrastructure.Entity;
using Interface.Models.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Interface.Models.Factor
{
    public class FactorModel : EntityBase<int>
    {
       [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Display(Name = "Project Name")]
        public string PrintName { get; set; }

        [StringLength(32)]
        public string PrivateID { get; set; }
        public User user { get; set; }
        [Display(Name = "PO")]
        public int PONumber { get; set; }
        [Display(Name = "PONumber")]
        public string PONumberStr { get; set; }
        public DateTime Date { get; set; }
        public DateTime FinishDate { get; set; }
        [Display(Name = "Date")]
        public string DateFa { get; set; }
        public string FinishDateFa { get; set; }
        public bool IsFinish { get; set; }
        [Display(Name = "Technical Note")]
        public string FactorTechnicalNote { get; set; }
        public int FactorInstallTime { get; set; }
        public int FactorLaberNumber { get; set; }
        public int SUM_QHL { get; set; }
        public int MAX_L { get; set; }
        public int SUM_HL { get; set; }
        [Display(Name = "Total Price :")]
        public double FactorPrice { get; set; }
        public decimal TaxableFactorPrice { get; set; }
        public string FactorPriceFa { get; set; }
        public double PaidPrice { get; set; }
        public double PaidPricePercent { get; set; }
        public double TotalPrice { get; set; }
        public string PaidPriceFa { get; set; }
        public double Remaining { get; set; }
        public string RemainingFa { get; set; }
        public string DueDateRemaining { get; set; }
        public string PaidRemainingFa { get; set; }
        public string Progress { get; set; }
        [Display(Name = "Users")]
        public string? CustomerID { get; set; }
        [Display(Name = "Customer")]
        public string CustomerFullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string SecondEmail { get; set; }
        public bool EmailSent { get; set; }
        public List<CustomerModel> Customers { get; set; }
        public virtual CustomerEnt Customer { get; set; }
        public string RegisterUserID { get; set; }
        public string RegisterUserFullName { get; set; }
        public string RegisterUserEmail{ get; set; }
        public long RequestEstimateID { get; set; }
        public FactorStatus Status { get; set; }
        [Display(Name = "Terms")]
        public PaymentTerms PaymentTerms { get; set; }
        public string StatusColor { get; set; }
        public string StatusFa { get; set; }
        public string Type { get; set; }
        public List<Factor_ItemEnt> ListItems { get; set; }
        public List<ReportEmailViewModel> Emails { get; set; }
        public List<FactorItem_ImageEnt> ListJobImage { get; set; }
        public string UpdateBtn { get; set; }
        public string UpdateBtn2 { get; set; }
        public string DeliverBtn { get; set; }
        public User UserInfo { get; set; }
        public string OrderToAddress { get; set; }

        public decimal Tax { get; set; }
        public double TaxAmount { get; set; }
        public double Payabel { get; set; }

        /// <summary>
        /// Changes View
        /// </summary>
        [StringLength(512)]
        public string FactorChangesView { get; set; }
        [StringLength(512)]
        public string GalleryChangesView { get; set; }
        [StringLength(512)]
        public string AppoitmentChangesView { get; set; }
        [StringLength(512)]
        public string PaymentChangesView { get; set; }
        [StringLength(512)]
        public string OrderChangesView { get; set; }
        [StringLength(512)]
        public string NoteChangesView { get; set; }
        [StringLength(512)]
        public string ContractChangesView { get; set; }
        public string CurentUserID { get; set; }

        //------------------------------------------------
        //اضافه کردن اطلاعات Items

        public int Quantity { get; set; }
        [Display(Name = "Item Number")]
        public double ItemNumer { get; set; }
        [Display(Name = "Item ")]
        public int ItemID { get; set; }
        public List<ItemEnt> ListItem { get; set; }
        public List<FactorInstallerModel> ListFactorInstaller { get; set; }
        public bool IsItemAdded { get; set; }
        public bool Select { get; set; }
        [Display(Name = "Vandor")]
        public int VandorID { get; set; }
        public List<VandorEnt> ListVandors { get; set; }
        public int ShippingID { get; set; }
        public List<ShippingEnt> ListShipping { get; set; }
        [Display(Name = "$/Each")]
        public int EachPrice { get; set; }
        [Display(Name = "Technical Note")]
        public string TechnicalNote { get; set; }
        [Display(Name = "Time for install")]
        public int InstallTime { get; set; }
        [Display(Name = "Laber")]
        public int LaberNumber { get; set; }
        public int Total { get; set; }

        [Display(Name = "First(%)")]
        public double MinimumPaymentPercent { get; set; }
        [Display(Name = "Second(%)")]
        public double SecondPaymentPercent { get; set; }
        [Display(Name = "Third(%)")]
        public double ThirdPaymentPercent { get; set; }
        [Display(Name = "Fourth(%)")]
        public double FourthPaymentPercent { get; set; }

        public bool MinimumPayed { get; set; }
        public bool SecondPayed { get; set; }
        public bool ThirdPayed { get; set; }
        public bool FourthPayed { get; set; }

        [Display(Name = "Credit Card")]
        public bool PayCreditCard { get; set; }
        [Display(Name = "Pay Cash")]
        public bool PayCash { get; set; }
        [Display(Name = "Pay Check ")]
        public bool PayCheck { get; set; }
        public string WorkFlow { get; set; }
        public bool IsCommerical { get; set; }
        [Display(Name = "Use Diffrent Contract")]
        public bool UseDiffrentContract { get; set; }
        public string ContractText { get; set; }
        public List<PaymentModel> Payments { get; set; }
        public List<PageViewStatisticsViewModel> ListPageView { get; set; }
        public List<OrderModel> Orders { get; set; }
        public List<FactorNoteEnt> Notes { get; set; }
 
        public List<FactorTaskEnt> ListFactorTask { get; set; }
        public List<EstimateAppointmentEnt> EstimateAppointments { get; set; }
        public List<InstallerAppointmentEnt> InstallerAppointments { get; set; }
        public List<JobTypeModel> JobTypes { get; set; }
        public List<ExpenseEnt> Accounting_Expenses { get; set; }
        public List<LaborCostModel> Accounting_LaborCost { get; set; }
        public List<Appt_Time> Account_ApptTime { get; set; }
        public List<ItemModel> LisItemAnswer { get; set; }

        public bool Pin { get; set; }
        public int PinOrder { get; set; }
        public PayType PayType { get; set; }
        [StringLength(50)]
        public string CreditCardView { get; set; }
        [StringLength(50)]
        public string CreditCardCustomerID { get; set; }
        public double TotalAppoitmentWorkTime { get; set; }
        public double TotalAppoitmentWorkPrice { get; set; }
        public double TotalProjectExpensePrice { get; set; }
        public double TotalLaberCostPrice { get; set; }
        public double ProjectProfit { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime PlaceOrderDate { get; set; }
        public bool Signed { get; set; } 
        public DateTime DueDate { get; set; }
        public ResellerPremitStatus ResellerPremitStatus { get; set; }
        public List<CityEnt> ListCities { get; set; }
        public List<StateEnt> ListStates { get; set; }

        public FactorModel()
        {
            MinimumPaymentPercent = 40;
            SecondPaymentPercent = 60;
            ThirdPaymentPercent = 0;
            FourthPaymentPercent = 0;
            PayCreditCard = true;
            PayCheck = true;
            PayCash = false;
            IsCommerical = false;
            user = new User();

            FactorChangesView = "";


            GalleryChangesView = "";

            AppoitmentChangesView = "";

            PaymentChangesView = "";

            OrderChangesView = "";

            NoteChangesView = "";
        }

    }
    public class FactorInvoiceDate
    {
        public int ID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceStr { get; set; }
    }
    public class FactorModelResult
    {
        public List<FactorModel> ListFactor { get; set; }
        public int modelCount { get; set; }
        public int pagecount { get; set; }
        public int pageitemcount { get; set; }
        public int pagenumber { get; set; }
    }
    public class FactorStatusViewModel : EntityBase<int>
    {
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
      

        public int PONumber { get; set; }
        public string PONumberStr { get; set; }

        public string CustomerID { get; set; }
        [Display(Name = "Customer")]
        public string CustomerFullName { get; set; }
  


        public string StatusColor { get; set; }
        public string StatusFa { get; set; }
   
       

    }


    public class FactorModelApp : EntityBase<int>
    {
        [StringLength(32)]
        public string PrivateID { get; set; }
        
        public int PONumber { get; set; }
        public int FactorInstallTime { get; set; }
        public int FactorLaberNumber { get; set; }
        [Display(Name = "Total Price :")]
        public double FactorPrice { get; set; }
        public decimal TaxableFactorPrice { get; set; }
        public string FactorPriceFa { get; set; }
        public double PaidPrice { get; set; }
        public double PaidPricePercent { get; set; }
        public double TotalPrice { get; set; }
        public string PaidPriceFa { get; set; }
        public double Remaining { get; set; }
        public string RemainingFa { get; set; }
        public string PaidRemainingFa { get; set; }
        public string Progress { get; set; }
        [Display(Name = "Client")]
        public string CustomerID { get; set; }
        [Display(Name = "Customer")]
        public string CustomerFullName { get; set; }
        public string ProjectName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string GoogleAddress { get; set; }
        public string Email { get; set; }
    
        public string RegisterUserID { get; set; }
        public string RegisterUserFullName { get; set; }
        public long RequestEstimateID { get; set; }
        public FactorStatus Status { get; set; }
        public string viewLink { get; set; }
        public string StatusColor { get; set; }
        public string StatusFa { get; set; }
        public string Type { get; set; }
      //  public List<Factor_ItemEnt> ListItems { get; set; }
      //  public List<FactorItem_ImageEnt> ListJobImage { get; set; }
        public string UpdateBtn { get; set; }
        public string UpdateBtn2 { get; set; }
        public string DeliverBtn { get; set; }
     

        public decimal Tax { get; set; }
        public double TaxAmount { get; set; }
        public double Payabel { get; set; }

   


        public FactorModelApp()
        {
           
        }

    }


    public class SortedFactorStatusViewModel
    {
        public List<FactorStatusModel> ListFactorStatus { get; set; }
        public List<FactorModel> FactorStatus0 { get; set; }
        public List<FactorModel> FactorStatus1 { get; set; }
        public List<FactorModel> FactorStatus2 { get; set; }
        public List<FactorModel> FactorStatus3 { get; set; }
        public List<FactorModel> FactorStatus4 { get; set; }
        public List<FactorModel> FactorStatus5 { get; set; }
        public List<FactorModel> FactorStatus6 { get; set; }
        public List<FactorModel> FactorStatus7 { get; set; }

  public List<FactorModel> FactorStatus7_1 { get; set; }
        public List<FactorModel> FactorStatus8 { get; set; }
        public List<FactorModel> FactorStatus9 { get; set; }
        
        public List<FactorModel> FactorStatus10 { get; set; }
        public int MaxCount { get; set; }
        public int EnableFactorCount { get; set; }
        public string PartialRender { get; set; }
    }
    public class FactorStatusModel
    {
        public List<FactorStatusViewModel> FactorStatus { get; set; }
        public byte SortingPriority { get; set; }
        public string StatusTitle { get; set; }
    }
    public class FactorSearch
    {
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }
        [Display(Name = "End Date")]
        public string EndDate { get; set; }
        public DateTime EndDatee { get; set; }
        [Display(Name = "Users")]
        public string UserID { get; set; }
     
        public string PageId { get; set; }
        public List<appUser> ListUser { get; set; }
        [Display(Name = "Type Name,PO,Phone,Email")]
        public string Search { get; set; }
        public FactorSearch()
        {
            PageId = "";
        }
     
    }

    public class RequestEstimateAppointmentModel : EntityBase<long>
    {
        public string CustomerID { get; set; }
        [Display(Name = "Full Name")]
        [Required]
        public string FullName { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [EmailAddress]
        [Display(Name = "Your e-mail address")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "State")]
        public int StateID { get; set; }
        [Display(Name = "City")]
        public int CityID { get; set; }
        public virtual CityEnt City { get; set; }
        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }
        [Display(Name = "Google Map")]
        public string GoogleAddress { get; set; }
        public string viewLink { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Display(Name = "Phone")]
        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Phone Number must be 10 digit number")]
        public string PhoneNumber { get; set; }
        public string PhoneVerify { get; set; }
        [Display(Name = "Job typee")]
        public string JobTypes { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime EndDatee { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime? StartTask { get; set; }
        public DateTime? EndTask { get; set; }
        public int StartH { get; set; }
        public int StartM { get; set; }
        public int EndH { get; set; }
        public int EndM { get; set; }
        [NotMapped]
        [Display(Name = "Date (click in box for change.)")]
        public string DateStr { get; set; }
        [Display(Name = "Time")]
        [Required]
        public string Time { get; set; }
        public string Time12H { get; set; }
        public virtual User UserInfo { get; set; }
        public DateTime BookDate { get; set; }
        [NotMapped]
        public string BookDateStr { get; set; }
        [Display(Name = "Shipp Same as Bill")]
        public bool ShippSameBill { get; set; }
        [NotMapped]
        public List<TimeModel> ListTime { get; set; }
        [NotMapped]
        public List<JobTypeModel> ListJobType { get; set; }
        public bool Canceled { get; set; }
        public string CanceledStr { get; set; }
        public bool createjob { get; set; }
        public int PONumber { get; set; }
        public string PrivateID { get; set; }
        public int FactorID { get; set; }//Only for install appointment// and estimate appoitment

        public virtual FactorEnt Factor { get; set; }//Only for install appointment
        public FactorStatus FactorStatus { get; set; }
        public AppoitmentStatus AppoitmentStatus { get; set; }
        public string AppoitmentType { get; set; }

        //public bool AgreeService { get; set; }
        public string Captcha { get; set; }
        public bool isEstemate { get; set; }
        public bool isTask { get; set; }
        [Display(Name = "Install Time(Hour)")]
        public int InstallTime { get; set; }
        public int LaberCount { get; set; }
        public EmailSettingEnt EmailSetting { get; set; }
        public string UpdateBtn { get; set; }

        public string InstallerID { get; set; }
        //For User Appoitment View
        public List<EstimateAppointmentEnt> EstimateAppointments { get; set; }
        public List<InstallerAppointmentEnt> InstallerAppointments { get; set; }
        public bool Reschedul { get; set; }
        public List<DateTimeModel> ListDateTime { get; set; }


        /// <summary>
        /// /////More Details For Time Line
        /// </summary>
        public List<Factor_ItemEnt> ListItems { get; set; }
        public List<FactorItem_ImageEnt> ListJobImage { get; set; }
        public List<FactorNoteEnt> Notes { get; set; }
        public string Image { get; set; }
        public string UserColor { get; set; }
        public int Type { get; set; }
        public string Installer { get; set; }
        public long AppoitmentID { get; set; }
        public int WorkTimeMin { get; set; }
        public RequestEstimateAppointmentModel()
        {
            Canceled = false;
            isTask = false;
            isEstemate = false;
            InstallTime = 1;
            LaberCount = 1;
        }
    }


    public class Appoitment
    {
        public string DateTime { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }

        public string EmployeName { get; set; }
        public string EmployeImage { get; set; }
        public int ID { get; set; }
        public int FactorID { get; set; }
        public int PONumber { get; set; }
    }
}