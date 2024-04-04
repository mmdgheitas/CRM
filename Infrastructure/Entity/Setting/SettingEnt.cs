

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    // You can add profile data for the user by adding more properties to your UserEnt class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class SettingEnt : EntityBase<byte>
    {
        [Display(Name = "Software Name")]
        public string? DefaultWebSiteName { get; set; }
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        public string? Logo { get; set; }
  
        [Display(Name = "Login Timeout(Day)")]
        public int LoginTimeout { get; set; }
        public string? Terms { get; set; }
        [Display(Name = "Estimation Appointment Interval")]
        public int EstimateInterval { get; set; }
        [Display(Name = "Difrent Calendar Time")]
        public int DifrentCalendarTime { get; set; }
        [Display(Name = "Installation Appointment Interval")]
        public int InstallerInterval { get; set; }

        [Display(Name = "Job Task Interval(min)")]
        public int JobTaskInterval { get; set; }
        [Display(Name = "Job Task Start Time(8)")]
        public int JobTaskStartTime { get; set; }
        [Display(Name = "Job Task End Time(18)")]
        public int JobTaskEndTime { get; set; }
        [Display(Name = "Contract Text")]
        public string? ContractText { get; set; }
        [Display(Name = "Payment Text 1")]
        public string? PaymentText1 { get; set; }
        [Display(Name = "Payment Text 2")]
        public string? PaymentText2 { get; set; }
        [Display(Name = "Payment Text 3")]
        public string? PaymentText3 { get; set; }
        [Display(Name = "Payment Text 4")]
        public string? PaymentText4 { get; set; }
        [Display(Name = "Payment Text 5")]
        public string? PaymentText5 { get; set; }
        [Display(Name = "Company Address")]
        public string? CompanyAddress { get; set; }
        [Display(Name = "Stripe Public Key")]
        public string? StripePublicKey { get; set; }
        [Display(Name = "Stripe Private Key")]
        public string? StripePrivateKey { get; set; }
        [NotMapped]
        public bool ChangeKey { get; set; }

        [Display(Name = "Plaid Client ID")]
        public string? PlaidClientID { get; set; }
        [Display(Name = "Plaid Secret")]
        public string? PlaidSecret { get; set; }
        [NotMapped]
        public bool ChangePlaid { get; set; }
        public int BreakTime { get; set; }
        [Display(Name = "job Status Counting Days")]
        public int jobStatusCountingDays { get; set; }
        public bool ShowTableOverview { get; set; }
        public bool ShowTableTimeCard { get; set; }
        public bool ShowTableSearch { get; set; }
        public bool ShowTableSortedProject  { get; set; }
        public bool ShowTableRecentActivity { get; set; }
        public bool ShowTableGalleries { get; set; }
        public bool ShowTableFutureTasks  { get; set; }
        public bool ShowTableLastPayments { get; set; }
        public bool ShowTablePaymentLeft { get; set; }
        public bool ShowTablePaymentAgo { get; set; }
        public bool ShowTableJobStatuses { get; set; }
        [Display(Name = "Auto Confirm Appointment")]
        public bool AutoConfirmAppt { get; set; }
        [Display(Name = "Email Notification Reciver")]
        public string? ReciverEmail { get; set; }
        [Display(Name = "Labor Cost Per H($)")]
        public double LaborCostPerHour { get; set; }

        /// <summary>
        ///  Sorted Project : 
        /// </summary>
        /// 
        public byte ShowStatus0 { get; set; }
        public byte ShowStatus1 { get; set; }

        public byte ShowStatus2 { get; set; }
        public byte ShowStatus3 { get; set; }
        public byte ShowStatus4 { get; set; }
        public byte ShowStatus5 { get; set; }
        public byte ShowStatus6 { get; set; }
        public byte ShowStatus7 { get; set; }
        public byte ShowStatus8 { get; set; }
        public byte ShowStatus9 { get; set; }

        public byte ShowStatus10 { get; set; }
        public byte ShowStatus11 { get; set; }
        public byte ShowStatus12 { get; set; }
        public byte ShowStatus13 { get; set; }
        public byte ShowStatus14 { get; set; }
        public byte ShowStatus15 { get; set; }
        public byte ShowStatus16 { get; set; }
        public byte ShowStatus17 { get; set; }
        public byte ShowStatus18 { get; set; }
        public byte ShowStatus19 { get; set; }


        public byte ShowStatus20 { get; set; }
        public byte ShowStatus21 { get; set; }
        public byte ShowStatus22 { get; set; }
        public byte ShowStatus23 { get; set; }
        public byte ShowStatus24 { get; set; }
        public byte ShowStatus25 { get; set; }
        public byte ShowStatus26 { get; set; }
        public byte ShowStatus27 { get; set; }
        public byte ShowStatus28 { get; set; }
        public byte ShowStatus29 { get; set; }


        public byte ShowStatus30 { get; set; }
        public byte ShowStatus31 { get; set; }
        public byte ShowStatus32 { get; set; }
        public byte ShowStatus33 { get; set; }
        public byte ShowStatus34 { get; set; }
        public byte ShowStatus35 { get; set; }
        public byte ShowStatus36 { get; set; }
        public byte ShowStatusIncompletePayment { get; set; }
        [Display(Name = "Shop latitude")]
        public string? Shoplatitude { get; set; }
        [Display(Name = "Shop longitude")]
        public string? Shoplongitude { get; set; }
        [Display(Name = "Shop Address")]
        public string?    ShopAddress { get; set; }
        /// <summary>
        /// /Glass Price Field
        /// </summary>
        ///  
        [Display(Name = "Unit Fule Surcharge")]
        public int UnitFuleSurcharge { get; set; }
        [Display(Name = "Credit Card Fee")]
        public int CreditCardFee { get; set; }
        [Display(Name = "Benefits Percentage")]
        public int BenefitsPercentage { get; set; }
        public bool FirstCalendar { get; set; }


        /// <summary>
        /// ////---Application Updaten Setting
        /// </summary>
        public double Version { get; set; }
        public double Buile { get; set; }
        [Display(Name = "Update Description")]
        public string? UpdateDescription { get; set; }
        [Display(Name = "Download Link")]
        public string? DownloadLink { get; set; }
        [Display(Name = "Download Force")]
        public bool DownloadForce { get; set; }

        /// <summary>
        /// ////---Application Updaten Setting
        /// </summary>
        public double Version2 { get; set; }
        public double Buile2 { get; set; }
        [Display(Name = "Update Description")]
        public string? UpdateDescription2 { get; set; }
        [Display(Name = "Download Link")]
        public string? DownloadLink2 { get; set; }
        [Display(Name = "Download Force")]
        public bool DownloadForce2 { get; set; }


     
        public SettingEnt()
        {
            jobStatusCountingDays = 30;
        
        }


    }


}