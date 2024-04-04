using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Acklann.Plaid.Entity;
using Infrastructure.Entity;

namespace Interface.Models.Plaid
{
    public class PlaidTransactionViewModel : EntityBase<long>
    {
        public string jsonData { get; set; }

        public Transaction Transaction { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string TransactionId { get; set; }
        public int? PlaidAccountID { get; set; }
        public bool AddToExpense { get; set; }
        public virtual PlaidAccountEnt PlaidAccount { get; set; }

        #region Property for save expense in show transaction
        public int? PaymentTypeID { get; set; }
        public int? CategoryID { get; set; }
        public int? ExpenseTypeID { get; set; }
        public int? ExpenseProductID { get; set; }
        public int? VandorId { get; set; }
        public int? FactorID { get; set; }
        public int? PayAccountID { get; set; }
        #endregion
        public PlaidTransactionViewModel() {
            Transaction = new Transaction();
        }

    }
}