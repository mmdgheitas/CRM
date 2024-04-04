using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Implement
{
    public class PlaidService : IPlaidService
    {
        IRepositoryBase<PlaidPublicTokenEnt, int> _PlaidPublicTokenRepo;
        IRepositoryBase<PlaidAccountEnt, int> _PlaidAccountRepo;
        IRepositoryBase<PlaidTransactionEnt, long> _PlaidTransactionRepo;

        public PlaidService(IRepositoryBase<PlaidPublicTokenEnt, int> PlaidPublicTokenRepo,
            IRepositoryBase<PlaidAccountEnt, int> PlaidAccountRepo,
            IRepositoryBase<PlaidTransactionEnt, long> PlaidTransactionRepo)
        {
            this._PlaidPublicTokenRepo = PlaidPublicTokenRepo;
            this._PlaidAccountRepo = PlaidAccountRepo;
            this._PlaidTransactionRepo = PlaidTransactionRepo;
        }

        public async Task<bool> AddPlaidPublicToken(PlaidPublicTokenEnt item)
        {
            try
            {
                return await _PlaidPublicTokenRepo.InsertAsync(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> DeletePlaidPublicToken(int id)
        {
            try
            {
                return await _PlaidPublicTokenRepo.DeleteAsync(id);

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> EditPlaidPublicToken(PlaidPublicTokenEnt item)
        {
            try
            {
                return await _PlaidPublicTokenRepo.UpdateAsync(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }



        public async Task<PlaidPublicTokenEnt> PlaidPublicTokenDetails(int id)
        {
            try
            {
                var list = await _PlaidPublicTokenRepo.GetAllAsync().ToListAsync();
                return list.AsQueryable().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {

                return new PlaidPublicTokenEnt();
            }
        }

        public async Task<List<PlaidPublicTokenEnt>> ListPlaidPublicTokens()
        {
            try
            {
                var list = await _PlaidPublicTokenRepo.GetAllAsync().ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<bool> IFExistPlaidPublicTokenName(string publicToken, int iD)
        {
            try
            {
                var list = await _PlaidPublicTokenRepo.GetAllAsync().ToListAsync();
                if (iD != 0)
                    return list.Any(p => p.PublicToken == publicToken);
                else
                    return list.Any(p => p.PublicToken == publicToken & p.ID != iD);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddPlaidAccount(PlaidAccountEnt plaidAccount)
        {
            try
            {
                return await _PlaidAccountRepo.InsertAsync(plaidAccount); ;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> AddPlaidTransaction(PlaidTransactionEnt plaidTransaction)
        {
            try
            {
                return await _PlaidTransactionRepo.InsertAsync(plaidTransaction);

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<List<PlaidAccountEnt>> ListAllAccount()
        {
            try
            {
                var list = await _PlaidAccountRepo.GetAllAsync().ToListAsync();
                var listTransaction = await _PlaidTransactionRepo.GetAllAsync().ToListAsync();
                foreach (var item in list)
                {
                    try
                    {


                        item.TransactionCount = listTransaction.Count(p => p.PlaidAccountID.Value == item.ID);
                    }
                    catch { }

                    }
                return list;
            }
            catch (Exception ex)
            {

                return new List<PlaidAccountEnt>();
            }
        }

        public async Task<List<PlaidAccountEnt>> ListAccount(int publicTokenID)
        {
            try
            {
             

                if (publicTokenID == 0)
                    return await _PlaidAccountRepo.GetAllAsync().Include(p => p.PlaidPublicToken).ToListAsync();
                else
                    return await _PlaidAccountRepo.GetAllAsync().Include(p => p.PlaidPublicToken).Where(p => p.PlaidPublicTokenID == publicTokenID).ToListAsync();
            }
            catch (Exception ex)
            {

                return new List<PlaidAccountEnt>();
            }
        }

        public async Task<PlaidTransactionEnt> GetTransactionByTransactionId(string transactionId)
        {
            try
            {
        
                return await _PlaidTransactionRepo.GetAllAsync().FirstOrDefaultAsync(p => p.TransactionId == transactionId);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<bool> IFExistTransactionId(string transactionId)
        {
            try
            {
               
                return await _PlaidTransactionRepo.GetAllAsync().AnyAsync(p => p.TransactionId == transactionId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> IFExistTransactionId(string transactionId,decimal amount)
        {
            try
            {
              
                return await _PlaidTransactionRepo.GetAllAsync().AnyAsync(p => p.TransactionId == transactionId & p.Amount == amount);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<PlaidTransactionEnt>> GetTransactionByPublicTokenIDFilterDate(int id, DateTime startDate, DateTime EndDate, decimal amount = 0,string type = "All", int filter = 0 )
        {
            try
            {

               var modelList = await _PlaidTransactionRepo.GetAllAsync().Include(p => p.PlaidAccount).ThenInclude(p => p.PlaidPublicToken).Where(p => p.Date.Date >= startDate.Date & p.Date.Date <= EndDate.Date).OrderBy(p => p.AddToExpense).ThenByDescending(p => p.Date).ToListAsync();
                if (id != 0)
                {
                    modelList = modelList.Where(p => p.PlaidAccount != null).ToList();
                    modelList = modelList.Where(p => p.PlaidAccount.PlaidPublicToken != null).ToList();
                    modelList = modelList.Where(p =>  p.PlaidAccount.PlaidPublicToken.ID == id ).ToList();
                }
                if (amount != 0)
                    modelList = modelList.Where(p =>
                    ((p.Amount >= (amount - 1) & p.Amount <= (amount  + 1))) ||
                   ((p.Amount * -1) >= (amount - 1) & (p.Amount * -1) <= (amount + 1))).ToList();

                try
                {
                    if (type == "Transfer")
                        modelList = modelList.Where(p => p.jsonData.Contains("Transfer")).ToList();

                    if (type == "Expense")
                        modelList = modelList.Where(p => !p.jsonData.Contains("Transfer") & p.Amount > 0).ToList();

                    if (type == "Income")
                        modelList = modelList.Where(p => !p.jsonData.Contains("Transfer") & p.Amount < 0).ToList();

                }
                catch { }
                if (filter != 0)
                {
                    if (filter == 1)
                        modelList = modelList.Where(p => p.AddToExpense).ToList();

                    if (filter == 2)
                        modelList = modelList.Where(p => !p.AddToExpense).ToList();
                }
                return modelList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PlaidAccountEnt> PlaidAccountDetails(int id)
        {
            try
            {
               
                return await _PlaidAccountRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> EditPlaidAccount(PlaidAccountEnt plaid)
        {
            try
            {
                return await _PlaidAccountRepo.UpdateAsync(plaid);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> PlaidTransactionAddToExpense(string transactionId,bool add = true)
        {
            try
            {
                if (string.IsNullOrEmpty(transactionId)) return false;
              
                var tr = await _PlaidTransactionRepo.GetAllAsync().FirstOrDefaultAsync(p => p.TransactionId == transactionId);
                if (tr.AddToExpense == add)   return true;
                tr.AddToExpense = add;
                return await _PlaidTransactionRepo.UpdateAsync(tr);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<PlaidTransactionEnt> ListTransactions()
        {
            try
            {
                return _PlaidTransactionRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<PlaidTransactionEnt>> ListTransactionsAsync()
        {
            try
            {
                return await _PlaidTransactionRepo.GetAllAsync().Include(p => p.PlaidAccount).ToListAsync();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<bool> DeleteTransaction(long Id)
        {
            try
            {
                return await _PlaidTransactionRepo.DeleteAsync(Id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> DeletePlaidAccount(int Id)
        {
            try
            {
                return await _PlaidAccountRepo.DeleteAsync(Id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<List<PlaidTransactionEnt>> ListTransactionsByPublicTokenID(int id)
        {
            try
            {
              
                return await _PlaidTransactionRepo.GetAllAsync().Where(p => p.PlaidAccount.PlaidPublicTokenID == id).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<double> TotalTransactionSaevd(int selectYear)
        {
            try
            {
            
                return await _PlaidTransactionRepo.GetAllAsync().CountAsync(p => p.AddToExpense & p.Date.Year == selectYear);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public async Task<double> TotalTransactionNotSaevd(int selectYear)
        {
            try
            {
  
                return await _PlaidTransactionRepo.GetAllAsync().CountAsync(p => !p.AddToExpense & p.Date.Year == selectYear & !p.jsonData.Contains("Transfer") & p.Amount > 0);//Only Expense
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<double> TotalTransactionExpenses(int selectYear)
        {
            try
            {
    
                return (await _PlaidTransactionRepo.GetAllAsync().Where(p => p.Date.Year == selectYear & !p.jsonData.Contains("Transfer") & p.Amount > 0).SumAsync(p => p.Amount.ToPositive())).RoundDecimal();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<double> TotalTransactions(DateTime startTime, DateTime endTime)
        {
            try
            {
          
                return await _PlaidTransactionRepo.GetAllAsync().Where(p => p.Date.Date >= startTime.Date & p.Date.Date <= endTime.Date).SumAsync(p => p.Amount.ToPositive());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<double> TotalTransactionSaevd(DateTime startTime, DateTime endTime)
        {
            try
            {
             
                return await _PlaidTransactionRepo.GetAllAsync().CountAsync(p => p.AddToExpense & p.Date.Date >= startTime.Date & p.Date.Date <= endTime.Date);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<double> TotalTransactionNotSaevd(DateTime startTime, DateTime endTime)
        {
            try
            {
        
                return await _PlaidTransactionRepo.GetAllAsync().CountAsync(p => !p.AddToExpense & p.Date.Date >= startTime.Date & p.Date.Date <= endTime.Date & !p.jsonData.Contains("Transfer") & p.Amount > 0);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
