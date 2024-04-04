

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Entity
{
    public class ExpenseEnt : EntityBase<long>
    {
        public DateTime Date { get; set; }
        [NotMapped]
        public string DateStr { get; set; }
        public int? FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
        public int? CategoryID { get; set; }
        public virtual CategoryEnt Category { get; set; }
        public int? ExpenseTypeID { get; set; }//sub category
        public virtual ExpenseTypeEnt ExpenseType { get; set; }
        public int? PayAccountID { get; set; }
        public virtual PayAccountEnt PayAccount { get; set; }
        public int? PaymentTypeID { get; set; }
        public virtual PaymentTypeEnt PaymentType { get; set; }
        public double Amount { get; set; }
        public string? PaymentReference { get; set; }

        public string? Description { get; set; }
        public string? Attachment { get; set; }
        [NotMapped]
        public string? AttachmentFile { get; set; }
        public string? TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        //  public string Product { get; set; }
        public int? ExpenseProductID { get; set; }
        public virtual ExpenseProductEnt ExpenseProduct { get; set; }
        public int? VandorId { get; set; }
        public virtual VandorEnt Vandor { get; set; }
        public string? UserId { get; set; }
        public string? CardNumber { get; set; }
        public string? CheckInfo { get; set; }

        public ExpenseEnt()
        {
        }
    }


    public class ExpenseModel : EntityBase<long>
    {
        public DateTime Date { get; set; }
        [Display(Name = "Date")]
        public string DateStr { get; set; }
        [Display(Name = "Project")]
        public int? FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
        public List<FactorEnt> ListFactor { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please select category")]
        public int? CategoryID { get; set; }
        public virtual CategoryEnt Category { get; set; }
        public List<CategoryEnt> ListCategory { get; set; }
        [Display(Name = "Sub Category")]
        public int? ExpenseTypeID { get; set; }
        public virtual ExpenseTypeEnt ExpenseType { get; set; }
        public List<ExpenseTypeEnt> ListExpenseTypes { get; set; }
        [Display(Name = "Pay account")]
        public int? PayAccountID { get; set; }
        public virtual PayAccountEnt PayAccount { get; set; }
        public List<PayAccountEnt> ListPayAccounts { get; set; }
        [Display(Name = "Payment type")]
        [Required(ErrorMessage = "Please select payment type")]
        public int? PaymentTypeID { get; set; }
        public virtual PaymentTypeEnt PaymentType { get; set; }
        public List<PaymentTypeEnt> ListPaymentTypes { get; set; }
        public List<ExpenseProductEnt> ListProducts { get; set; }
        public List<VandorEnt> ListVandors { get; set; }
        [Required(ErrorMessage = "Please enter amount")]
        [Display(Name = "Amount ($)")]
        public double Amount { get; set; }
        // [Required]
        [Display(Name = "Payment Reference")]
        public string PaymentReference { get; set; }

        public string Description { get; set; }
        public string Attachment { get; set; }
        public string AttachmentFile { get; set; }
        [Display(Name = "drag and drop of select file upload")]
        public IFormFile FileUpload { get; set; }
        public string[] listpayto { get; set; }
        public string TransactionId { get; set; }
        public string TransactionName { get; set; }
        [Display(Name = "Type")]
        public TransactionType TransactionType { get; set; }
        public string TransactionTypeStr { get; set; }

        [Display(Name = "Product")]
        public int? ExpenseProductID { get; set; }
        public virtual ExpenseProductEnt ExpenseProduct { get; set; }
        [Display(Name = "Vendor")]
        public int? VandorId { get; set; }
        public virtual VandorEnt Vandor { get; set; }
     
        public string UserId { get; set; }
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string UserFullName { get; set; }
        public string CardNumber { get; set; }
        public string CheckInfo { get; set; }
        public ExpenseModel()
        {
        }
    }



    public class ExpenseAppViewModel
    {
        public long ID { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string Title { get; set; }
        public PlaidTransactionEnt Transaction { get; set; }
        public string TransactionId { get; set; }
        public string PONumber { get; set; }

        public PaymentTypeEnt PaymentType { get; set; }
        public string Description { get; set; }
        public CategoryEnt Category { get; set; }
        public ExpenseProductEnt ExpenseProduct { get; set; }
        public string Attachment { get; set; }
        public ExpenseTypeEnt SubCategory { get; set; }
        public VandorEnt Vandor { get; set; }
        public TransactionType TransactionType { get; set; }
        public string UserFullName { get; set; }


        public PayAccountEnt PayAccount { get; set; }
        public string PaymentReference { get; set; }
        public string CardNumber { get; set; }
        public string CheckInfo { get; set; }

        public ExpenseAppViewModel()
        {
        }
    }
    public class ExpenseAppPagation
    {
        public int modelCount { get; set; }
        public int pagecount { get; set; }
        public List<ExpenseAppViewModel> model { get; set; }
    }
    public class ExpenseListViewModel : EntityBase<long>
    {
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }
        [Display(Name = "End Date")]
        public string EndDate { get; set; }
        public DateTime EndDatee { get; set; }
        public string time { get; set; }
        [Display(Name = "Project")]
        public int? jobID { get; set; }
        public List<FactorEnt> ListFactor { get; set; }
        [Display(Name = "Category")]
        public int? CategoryID { get; set; }
        public List<CategoryEnt> ListCategory { get; set; }
        public List<VandorEnt> ListVandors { get; set; }
        [Display(Name = "Sub Category")]
        public int ExpenseTypeID { get; set; }
        public List<ExpenseTypeEnt> ListExpenseTypes { get; set; }
        [Display(Name = "Pay account")]
        public int? PayAccountID { get; set; }
        [Display(Name = "Product")]
        public int? ProductID { get; set; }
        public List<PayAccountEnt> ListPayAccounts { get; set; }
        [Display(Name = "Payment type")]
        public int? PaymentTypeID { get; set; }
        [Display(Name = "Amount")]
        public double   Amount { get; set; }
        [Display(Name = "Transaction")]
        public bool TransactionNotSaved { get; set; }
        public List<PaymentTypeEnt> ListPaymentTypes { get; set; }
        public List<ExpenseProductEnt> ListProducts { get; set; }
        public List<ExpenseModel> ListExpenses { get; set; }
        public int modelCount { get; set; }
        public int pagecount { get; set; }
        public int pageitemcount { get; set; }
        public int pagenumber { get; set; }
        public int Page { get; set; }


        public ExpenseListViewModel()
        {
            jobID = -1;
            pageitemcount = 10;
        }
    }

   
    public enum TransactionType
    {
        [Display(Name = "Expense")]
        Expense = 0,
        [Display(Name = "Income")]
        Income = 1,
        [Display(Name = "Transfer")]
        Transfer = 2
    }



    public class ReportExpenseViewModel
    {
        public List<ReportExpenseDate> ExpenseVsPayments { get; set; }
        public List<ReportExpenseDate> ProjectVsPayments { get; set; }
        public int SelectYear { get; set; }

        #region Due Payment


        public double TotalOverDuePayment { get; set; }//Remaining balance that project status invoiced
        public double TotalNotDuePayment { get; set; }//Remaining balance that project status not invoiced
        public double TotalOverDuePayment_Percent { get; set; }
        public double TotalNotDuePayment_Percent { get; set; }
        public double TotalNotDuePaymentNumber { get; set; }
        #endregion

        #region Transaction Saved


        public double TotalTransactionSaved { get; set; }
        public double TotalTransactionNotSaved { get; set; }

        public double TotalTransactionSaved_Percent { get; set; }
        public double TotalTransactionNotSaved_Percent { get; set; }
        #endregion

        #region Expense and Payment
        public double TotalTransactions { get; set; }
        public double TotalExpenseIncome { get; set; }
        public double TotalIncom { get; set; }
        public double TotalExpense { get; set; }
        public double TotalExpense_Percent { get; set; } = 0;
        public double TotalIncom_Percent { get; set; } = 0;
        public double TotalPayed { get; set; }
        public double TotalNotPayed { get; set; }

        public double TotalPayed_Percent { get; set; } = 0;
        public double TotalNotPayed_Percent { get; set; } = 0;
        public double TotalPayedThisMonth { get; set; }
        public double TotalNotPayedThisMonth_Percent { get; set; } = 0;
        public double TotalPayedThisMonth_Percent { get; set; } = 0;
        public double TotalNotPayedThisMonth { get; set; }
        #endregion

        public int AllProjectCount { get; set; }
        public List<ReportExpenseDate> ExpenseByCategory { get; set; }
        public List<ReportExpenseDate> ProjectByStatus { get; set; }
        public List<ReportExpenseDate> PaymentList { get; set; }
        public List<PlaidAccountEnt> PlaidAccounts { get; set; }
    }
    public class ReportExpenseDate
    {
        public string Month { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }

    public enum TimeType
    {
        Year = 1,
        Month = 2,
        Weekly = 3,
        Daily = 4

    }
}