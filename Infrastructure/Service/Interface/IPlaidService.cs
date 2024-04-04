using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface IPlaidService
    {
       Task<List<PlaidPublicTokenEnt>> ListPlaidPublicTokens();
        Task<bool> DeletePlaidPublicToken(int id);
        Task<PlaidPublicTokenEnt> PlaidPublicTokenDetails(int id);
        Task<bool> AddPlaidPublicToken(PlaidPublicTokenEnt item);
         Task<bool> EditPlaidPublicToken(PlaidPublicTokenEnt item);
         Task<bool> IFExistPlaidPublicTokenName(string publicToken, int iD);
         Task<bool> AddPlaidAccount(PlaidAccountEnt plaidAccount);
         Task<bool> AddPlaidTransaction(PlaidTransactionEnt plaidTransaction);
       Task<List<PlaidAccountEnt>> ListAllAccount();
        Task<List<PlaidAccountEnt>> ListAccount(int iD);
        Task<PlaidTransactionEnt> GetTransactionByTransactionId(string id);
       List<PlaidTransactionEnt> ListTransactions();
       Task< List<PlaidTransactionEnt>> ListTransactionsAsync();
        Task<bool> IFExistTransactionId(string transactionId);
        Task<bool> IFExistTransactionId(string transactionId,decimal amount);
        Task<List<PlaidTransactionEnt>> GetTransactionByPublicTokenIDFilterDate(int id, DateTime startDate, DateTime EndDate,decimal amount = 0,string type = "All",int filter = 0);
         Task<PlaidAccountEnt> PlaidAccountDetails(int id);
        Task<bool> EditPlaidAccount(PlaidAccountEnt plaid);
        Task<bool> PlaidTransactionAddToExpense(string transactionId,bool add = true);
        Task<bool> DeleteTransaction(long Id);
        Task<bool> DeletePlaidAccount(int Id);
        Task<List<PlaidTransactionEnt>> ListTransactionsByPublicTokenID(int id);
        Task<double> TotalTransactionSaevd(int selectYear);
        Task<double> TotalTransactionNotSaevd(int selectYear);
        Task<double> TotalTransactionExpenses(int year);
        Task<double> TotalTransactions(DateTime startTime, DateTime endTime);
        Task<double> TotalTransactionSaevd(DateTime startTime, DateTime endTime);
        Task<double> TotalTransactionNotSaevd(DateTime startTime, DateTime endTime);
    }
}
