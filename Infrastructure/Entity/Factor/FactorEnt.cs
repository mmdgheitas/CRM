

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class FactorEnt : EntityBase<int>
    {
     
        [Display(Name = "ProjectName")]
        public string? ProjectName { get; set; }
    
        public bool Signed { get; set; }
        [Display(Name = "PrintName")]
     
        public string?  PrintName { get; set; } 
        //   public int MyProperty { get; set; } 
        [StringLength(64)]
        public string? PrivateID { get; set; }
        public int PONumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime PlaceOrderDate { get; set; }
        public bool IsFinish { get; set; }
        public double FactorPrice { get; set; }
        public double PaidPrice { get; set; }
        public double Remaining { get; set; }
        public string? CustomerID { get; set; }
       //public virtual CustomerEnt Customer { get; set; }


        public string? RegisterUserID { get; set; }
        public FactorStatus Status { get; set; }
        public PaymentTerms PaymentTerms { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public string? Type { get; set; }
        public string? FactorTechnicalNote { get; set; }
        public int FactorInstallTime { get; set; }
        public int FactorLaberNumber { get; set; }
        public int SUM_QHL { get; set; }
        public int MAX_L { get; set; }
        public int SUM_HL { get; set; }
        public long RequestEstimateID { get; set; }

        [Display(Name = "Minimum Payment (%)")]
        public double MinimumPaymentPercent { get; set; }
        [Display(Name = "Second Payment (%)")]
        public double SecondPaymentPercent { get; set; }
        [Display(Name = "Third Payment (%)")]
        public double ThirdPaymentPercent { get; set; }
        [Display(Name = "Fourth Payment (%)")]
        public double FourthPaymentPercent { get; set; }


        public bool PayCreditCard { get; set; }
        public bool PayCash { get; set; }
        public bool PayCheck { get; set; }

        public string? WorkFlow { get; set; }
        //  [NotMapped]
        public int TaxableFactorPrice { get; set; }
        //    [NotMapped]
        public double TaxAmount { get; set; }
        //  [NotMapped]
        public decimal Tax { get; set; }
        public bool IsCommerical { get; set; }

        /// <summary>
        /// Changes View
        /// </summary>
        [StringLength(512)]
        public string? FactorChangesView { get; set; }
        [StringLength(512)]
        public string? GalleryChangesView { get; set; }
        [StringLength(512)]
        public string? AppoitmentChangesView { get; set; }
        [StringLength(512)]
        public string? PaymentChangesView { get; set; }
        [StringLength(512)]

        public string? OrderChangesView { get; set; }
        [StringLength(512)]
        public string? NoteChangesView { get; set; }
        [StringLength(512)]
        public string? ContractChangesView { get; set; }
        public bool UseDiffrentContract { get; set; }
        public string? ContractText { get; set; }
        public bool Pin { get; set; }
        public int PinOrder { get; set; }
        public PayType PayType { get; set; }
        [StringLength(50)]
        public string? CreditCardView { get; set; }
        [StringLength(50)]
        public string? CreditCardCustomerID { get; set; }
       [NotMapped]
        public CustomerInfo CustomerInfo { get; set; }
        public FactorEnt()
        {
            MinimumPaymentPercent = 40;
            SecondPaymentPercent = 60;
            ThirdPaymentPercent = 0;
            FourthPaymentPercent = 0;
            PinOrder = 0;
            PayCreditCard = true;
            PayCheck = true;
            PayCash = true;
            IsCommerical = false;
            PayType = PayType.None;
            Signed = false;
        }
    }

    public class NoteApplicationModel : EntityBase<long>
    {

        public string Note { get; set; }
        public string Date { get; set; }
        public string User { get; set; }
        public string FilePath { get; set; }

    }

    public class StatusModel
    {
        public int ID { get; set; }
        public byte Priority { get; set; }
        public string StatusTitle { get; set; }
        public FactorStatus Status { get; set; }
        public bool Enable { get; set; }
        public string EnableStr { get; set; }
    }

    public class FactorItemDynamicData
    {
        public int FactorPrice { get; set; }
        public int FactorLaberNumber { get; set; }
        public int FactorInstallTime { get; set; }
        public int SUM_QHL { get; set; }
        public int MAX_L { get; set; }
        public int SUM_HL { get; set; }

        public FactorItemDynamicData()
        {
            FactorPrice = 0;
            FactorLaberNumber = 0;
            FactorInstallTime = 0;
        }
    }

    public enum FactorStatus
    {
        PreEstimation = 0,
        Estimation = 1,
        Estimate_Sent = 2,
        First_attempt_estimation = 3,
        Secound_attempt_estimation = 4,
        Schedule_Measuring = 5,
        Measuring_Scheduled = 6,
        Pricing = 7,
        Pricing_updated = 8,
        Quoted = 9,
        First_attempt_question = 10,
        Secound_attempt_question = 11,
        Quote_Excepted = 12,
        Waiting_for_deposit = 13,
        Didnt_Received_Deposit = 14,
        Recieved_deposit = 15,
        Order_in_process = 16,//
        back_ordered = 17,
        Delivered_in_house = 18,
        installation_delivery_requested = 19,//
        installation_delivery_Scheduled = 20,
        Out_for_delivery = 21,
        Job_Delivered = 22,
        Invoice_sent = 23,
        waiting_for_payment = 24,//
        Paid_in_full = 25,//
        Request_Review = 26,
        GetStart = 27,
        StartProject = 28,
        PauseProject = 29,
        ContinueProject = 30,
        Cancelled = 31,
        Close = 32,
        Suspended = 33,
        OnlineOrder = 34,
        Schedule_Measuring_Request = 35,
        Order_Pending = 36,
        Order_Confirmation = 37,
       DueDate = 38
    }
    public enum PaymentTerms
    {
        PP = 0,//Partial Payment
        DOC = 3,
        COD = 4,//Cash on delivery
        EOM = 5,
        PIA = 6,//Payment in advance
        Net7 = 7,
        BiMonthly = 8,
        Net10 = 10,
        Net15 = 15,
        Net30 = 30,
        Net45 = 45,
        Net60 = 60

    }
    public enum FactorProgressStatus
    {
        Lead = 0,
        Job = 1,
        Invoice = 2,
        Unkhonw = 3
    }
    public enum ItemStatus
    {
        Pending = 1,
        Good_to_go = 2,
        Orderd = 3,//
        Back_ordered = 4,
        Delivered_in_house = 5,
        Load = 6,
        Item_Delivered = 7,//
        Deleted = 8
    }


    public class CustomerInfo
    {
        public string FullName { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string  Company { get; set; } 
        public string Email { get; set; }
        public string FirstName { get; set; }

        public CustomerInfo()
        {
            FullName = "";
            Address = "";
            PhoneNumber = "";
            Email = "";
        }
    }
}