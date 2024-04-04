

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class PlaidTransactionEnt : EntityBase<long>
    {
        public string? jsonData { get; set; }
        public decimal Amount { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string? TransactionId { get; set; }
        public int? PlaidAccountID { get; set; }
        public bool AddToExpense { get; set; }
        public virtual PlaidAccountEnt PlaidAccount { get; set; }

        public PlaidTransactionEnt()
        {
            AddToExpense = false;
        }

    }


    public class PlaidTransactionAppPagation
    {
        public int modelCount { get; set; }
        public int pagecount { get; set; }
        public object model { get; set; }
    }


    public class FindTransactionViewModel

    {
        public long ExpenseID { get; set; }
        public DateTime ExpenseDate { get; set; }

        public List<PlaidTransactionEnt> ListTransaction { get; set; }
    }
}