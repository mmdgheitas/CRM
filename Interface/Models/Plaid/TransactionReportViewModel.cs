using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Acklann.Plaid.Entity;
using Infrastructure.Entity;

namespace Interface.Models.Plaid
{
    public class TransactionReportViewModel
    {
        public List<PlaidTransactionViewModel> Transactions { get; set; }
        public int modelCount { get; set; }
        public int pagecount { get; set; }
        public int pageitemcount { get; set; }
        public int pagenumber { get; set; }
        public List<PlaidAccountViewModel> Accounts { get; set; }

        public List<CategoryEnt> ListCategory { get; set; }
        public List<ExpenseTypeEnt> ListExpenseTypes { get; set; }
        public List<PayAccountEnt> ListPayAccounts { get; set; }
        public List<PaymentTypeEnt> ListPaymentTypes { get; set; }
        public List<ExpenseProductEnt> ListProducts { get; set; }
        public List<VandorEnt> ListVandors { get; set; }
        public List<FactorEnt> ListFactor { get; set; }
        public string time { get; set; }
        public bool notAddExpense { get; set; }

        public TransactionReportViewModel()
        {
            Transactions = new List<PlaidTransactionViewModel>();
        }

    }
}