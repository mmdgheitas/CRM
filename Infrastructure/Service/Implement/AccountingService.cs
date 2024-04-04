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
    public class AccountingService : IAccountingService
    {
        IRepositoryBase<ExpenseEnt, long> _expenseRepo;
        IRepositoryBase<CategoryEnt, int> _categoryRepo;
        IRepositoryBase<ExpenseProductEnt, int> _expenseProductRepo;
        IRepositoryBase<ExpenseTypeEnt, int> _expenseTypeRepo;
        IRepositoryBase<PayAccountEnt, int> _payAccountRepo;
        IRepositoryBase<PaymentTypeEnt, int> _paymentTypeRepo;



        public AccountingService(IRepositoryBase<ExpenseEnt, long> _expenseRepo, IRepositoryBase<CategoryEnt, int> _categoryRepo,
            IRepositoryBase<ExpenseTypeEnt, int> _expenceTypeRepo, IRepositoryBase<PayAccountEnt, int> _payAccountRepo,
             IRepositoryBase<ExpenseProductEnt, int> _expenseProductRepo,
            IRepositoryBase<PaymentTypeEnt, int> _paymentTypeRepo)
        {
            this._expenseRepo = _expenseRepo;
            this._categoryRepo = _categoryRepo;
            this._payAccountRepo = _payAccountRepo;
            this._paymentTypeRepo = _paymentTypeRepo;
            this._expenseTypeRepo = _expenceTypeRepo;
            this._expenseProductRepo = _expenseProductRepo;

        }

        public bool AddCategory(CategoryEnt model)
        {
            try
            {
                return _categoryRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> AddCategoryAsync(CategoryEnt model)
        {
            try
            {
                return await _categoryRepo.InsertAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddExpense(ExpenseEnt item)
        {
            try
            {
                return _expenseRepo.Insert(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public async Task<string> AddExpenseAsync(ExpenseEnt item)
        {
            try
            {
                return (await _expenseRepo.InsertAsync(item)) ? "success" : "Error to save";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }
        public bool AddExpenseProduct(ExpenseProductEnt model)
        {
            try
            {
                return _expenseProductRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> AddExpenseProductAsync(ExpenseProductEnt model)
        {
            try
            {
                return await _expenseProductRepo.InsertAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddExpenseType(ExpenseTypeEnt model)
        {
            try
            {
                return _expenseTypeRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddExpenseTypeAsync(ExpenseTypeEnt model)
        {
            try
            {
                return await _expenseTypeRepo.InsertAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddPayAccount(PayAccountEnt model)
        {
            try
            {
                return _payAccountRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddPayAccountAsync(PayAccountEnt model)
        {
            try
            {
                return await _payAccountRepo.InsertAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddPaymentType(PaymentTypeEnt model)
        {
            try
            {
                return _paymentTypeRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public CategoryEnt CategoryDetails(int id)
        {
            try
            {
                return _categoryRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int CategoryIdByName(string categoryName)
        {
            try
            {
                return _categoryRepo.GetAll().FirstOrDefault(p => p.Title == categoryName)?.ID ?? 0;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                return _categoryRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteExpense(long id)
        {
            try
            {
                return _expenseRepo.Delete(id);

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<bool> DeleteExpenseAsync(long id)
        {
            try
            {
                return await _expenseRepo.DeleteAsync(id);

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeleteExpenseProduct(int id)
        {
            try
            {
                return _expenseProductRepo.Delete(id);
            }
            catch (Exception ez)
            {
                return false;
            }
        }

        public bool DeleteExpenseType(int id)
        {
            try
            {
                return _expenseTypeRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletePayAccount(int id)
        {
            try
            {
                return _payAccountRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletePaymentType(int id)
        {
            try
            {
                return _paymentTypeRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditCategory(CategoryEnt model)
        {
            try
            {
                return _categoryRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditExpense(ExpenseEnt item)
        {
            try
            {
                return _expenseRepo.Update(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<string> EditExpenseAsync(ExpenseEnt item)
        {
            try
            {
                return (await _expenseRepo.UpdateAsync(item)) ? "success" : "Error to save";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public bool EditExpenseProduct(ExpenseProductEnt model)
        {
            try
            {
                return _expenseProductRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditExpenseType(ExpenseTypeEnt model)
        {
            try
            {
                return _expenseTypeRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditPayAccount(PayAccountEnt model)
        {
            try
            {
                return _payAccountRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditPaymentType(PaymentTypeEnt model)
        {
            try
            {
                return _paymentTypeRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ExpenseEnt ExpenseDetails(long id)
        {
            try
            {
                return _expenseRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<ExpenseEnt?> ExpenseDetailsAsync(long id)
        {
            try
            {

                var model = await _expenseRepo.GetAllAsync()
                    .Where(p => p.ID == id)
                    .FirstOrDefaultAsync();

                return model;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public ExpenseProductEnt ExpenseProductDetails(int id)
        {
            try
            {
                return _expenseProductRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ExpenseTypeEnt ExpenseTypeDetails(int id)
        {
            try
            {
                return _expenseTypeRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int ExpenseTypeIDByName(string expenseType)
        {
            try
            {
                return _expenseTypeRepo.GetAll().FirstOrDefault(p => p.Title == expenseType)?.ID ?? 0;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public bool IFExistCategoryTitle(string title, int iD)
        {
            try
            {
                if (iD == 0)
                    return _categoryRepo.GetAll().Any(p => p.Title == title);
                else
                    return _categoryRepo.GetAll().Any(p => p.Title == title & p.ID != iD);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<string> IFExistCategoryTitleAsync(string title, int id = 0)
        {
            try
            {
                if (string.IsNullOrEmpty(title)) return "The title is required";

                bool res = true;
                if (id == 0)
                    res = await _categoryRepo.GetAllAsync().AnyAsync(p => p.Title == title);
                else
                    res = await _categoryRepo.GetAllAsync().AnyAsync(p => p.Title == title & p.ID != id);
                if (!res)
                    return "success";
                else
                    return "This record exists";
            }
            catch (Exception ex)
            {
                return "Server error. Please try again.";
            }
        }

        public bool IFExistExpenseProductTitle(string title, int id)
        {
            try
            {
                if (id == 0)
                    return _expenseProductRepo.GetAll().Any(p => p.Title == title);
                else
                    return _expenseProductRepo.GetAll().Any(p => p.Title == title & p.ID != id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<string> IFExistExpenseProductTitleAsync(string title, int id = 0)
        {
            try
            {
                if (string.IsNullOrEmpty(title)) return "The title is required";

                bool res = true;
                if (id == 0)
                    res = await _expenseProductRepo.GetAllAsync().AnyAsync(p => p.Title == title);
                else
                    res = await _expenseProductRepo.GetAllAsync().AnyAsync(p => p.Title == title & p.ID != id);
                if (!res)
                    return "success";
                else
                    return "This record exists";
            }
            catch (Exception ex)
            {
                return "Server error. Please try again.";
            }
        }

        public bool IFExistExpenseTypeTitle(string title, int iD)
        {
            try
            {
                if (iD == 0)
                    return _expenseTypeRepo.GetAll().Any(p => p.Title == title);
                else
                    return _expenseTypeRepo.GetAll().Any(p => p.Title == title & p.ID != iD);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<string> IFExistExpenseTypeTitleAsync(string title, int id = 0)
        {
            try
            {
                if (string.IsNullOrEmpty(title)) return "The title is required";

                bool res = true;
                if (id == 0)
                    res = await _expenseTypeRepo.GetAllAsync().AnyAsync(p => p.Title == title);
                else
                    res = await _expenseTypeRepo.GetAllAsync().AnyAsync(p => p.Title == title & p.ID != id);
                if (!res)
                    return "success";
                else
                    return "This record exists";
            }
            catch (Exception ex)
            {
                return "Server error. Please try again.";
            }
        }

        public bool IFExistPayAccountTitle(string title, int iD)
        {
            try
            {
                if (iD == 0)
                    return _payAccountRepo.GetAll().Any(p => p.Title == title);
                else
                    return _payAccountRepo.GetAll().Any(p => p.Title == title & p.ID != iD);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<string> IFExistPayAccountTitleAsync(string title, int id = 0)
        {
            try
            {
                if (string.IsNullOrEmpty(title)) return "The title is required";

                bool res = true;
                if (id == 0)
                    res = await _payAccountRepo.GetAllAsync().AnyAsync(p => p.Title == title);
                else
                    res = await _payAccountRepo.GetAllAsync().AnyAsync(p => p.Title == title & p.ID != id);
                if (!res)
                    return "success";
                else
                    return "This record exists";
            }
            catch (Exception ex)
            {
                return "Server error. Please try again.";
            }
        }

        public bool IFExistPaymentTypeTitle(string title, int iD)
        {
            try
            {
                if (iD == 0)
                    return _paymentTypeRepo.GetAll().Any(p => p.Title == title);
                else
                    return _paymentTypeRepo.GetAll().Any(p => p.Title == title & p.ID != iD);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<string> IFExistPaymentTypeTitleAsync(string title, int id = 0)
        {
            try
            {
                if (string.IsNullOrEmpty(title)) return "The title is required";

                bool res = true;
                if (id == 0)
                    res = await _paymentTypeRepo.GetAllAsync().AnyAsync(p => p.Title == title);
                else
                    res = await _paymentTypeRepo.GetAllAsync().AnyAsync(p => p.Title == title & p.ID != id);
                if (!res)
                    return "success";
                else
                    return "This record exists";
            }
            catch (Exception ex)
            {
                return "Server error. Please try again.";
            }
        }

        public bool IfUsedVandorsInExpense(int id)
        {
            try
            {
                return _expenseRepo.GetAll().Any(p => p.VandorId == id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<ExpenseEnt> ListAllExpense()
        {
            try
            {
                return _expenseRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<ExpenseEnt>> ListAllExpenses()
        {
            try
            {
                return await _expenseRepo.GetAll().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ExpenseEnt>> ListAllExpensesAsync()
        {
            try
            {
                return await _expenseRepo.GetAllAsync()
                    .Include(p => p.Factor)
                    .Include(p => p.Category)
                    .Include(p => p.Vandor)
                    .Include(p => p.PayAccount)
                    .Include(p => p.ExpenseProduct)
                    .Include(p => p.PaymentType)
                    .OrderByDescending(p => p.Date).ThenByDescending(p => p.ID).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<CategoryEnt> ListCategories()
        {
            try
            {
                var listCategoty = _categoryRepo.GetAll();
                var listExpense = _expenseRepo.GetAll();
                foreach (var category in listCategoty)
                {
                    category.NumberOfUsed = listExpense.Count(p => p.CategoryID == category.ID);
                }
                var listCat = listCategoty.ToList();
                return listCat.OrderByDescending(p => p.NumberOfUsed).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<CategoryEnt>> ListCategoriesAsync()
        {
            try
            {
                var listCategoty = await _categoryRepo.GetAllAsync().ToListAsync();
                var listExpense = await _expenseRepo.GetAllAsync().ToListAsync();
                foreach (var category in listCategoty)
                {
                    category.NumberOfUsed = listExpense.Count(p => p.CategoryID == category.ID);
                }
                return listCategoty.OrderByDescending(p => p.NumberOfUsed).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ExpenseProductEnt> ListExpenseProducts()
        {
            try
            {
                return _expenseProductRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<ExpenseProductEnt>> ListExpenseProductsAsync()
        {
            try
            {
                return await _expenseProductRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ExpenseEnt> ListExpenses()
        {
            try
            {
                return _expenseRepo.GetAll().OrderByDescending(p => p.Date).ThenByDescending(p => p.ID).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ExpenseTypeEnt> ListExpenseType()
        {
            try
            {
                return _expenseTypeRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<ExpenseTypeEnt>> ListExpenseTypeAsync()
        {
            try
            {
                return await _expenseTypeRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ExpenseTypeEnt> ListexpenseType()
        {
            try
            {
                return _expenseTypeRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<PayAccountEnt> ListPayAccounts()
        {
            try
            {
                return _payAccountRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<PayAccountEnt>> ListPayAccountsAsync()
        {
            try
            {
                return await _payAccountRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<PaymentTypeEnt> ListPaymentTypes()
        {
            try
            {
                return _paymentTypeRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<PaymentTypeEnt>> ListPaymentTypesAsync()
        {
            try
            {
                return await _paymentTypeRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ReportExpenseDate>> ListReportExpenseVsPaymentDailyAsync(int selectYear, List<ReportExpenseDate> paymentList, DateTime startTime, DateTime endTime, int intervalDay)
        {
            try
            {
                var listExpense = await ListAllExpensesAsync();
                var listExpenseIncome = new List<ReportExpenseDate>();
                for (DateTime time = startTime; time <= endTime; time = time.AddDays(intervalDay))
                {

                    var dayLable = intervalDay == 1 ? time.ToString("M") : time.ToString("M") + "->" + time.AddDays(intervalDay).ToString("M");
                    listExpenseIncome.Add(new ReportExpenseDate()
                    {
                        Month = dayLable,

                        Value1 = paymentList.FirstOrDefault(p => p.Month == dayLable)?.Value1 ?? "0",
                        Value2 = (listExpense.Where(p => p.TransactionType == TransactionType.Expense & p.Date.Date == time.Date).Sum(p => p.Amount.ToPositive())).ToString(),
                        //if day interval more than 1 =>p.Date.Date >= time.Date & p.Date.Date < time.AddDays(intervalDay).Date
                    });

                }

                return listExpenseIncome;
            }
            catch (Exception ex)
            {

                return new List<ReportExpenseDate>();
            }
        }

        public async Task<List<ReportExpenseDate>> ListReportExpenseVsPaymentMonthlyAsync(int thisYear, List<ReportExpenseDate> paymentList, bool allMonth = true)
        {
            try
            {
                var dateNow = DateTime.Now.SystemTimee();
                var listExpense = await ListAllExpensesAsync();
                var listExpenseIncome = new List<ReportExpenseDate>();
                for (int i = 1; i <= 12; i++)
                {

                    if (allMonth == false) if (dateNow.Year == thisYear & dateNow.SystemTimee().Month < i) break;

                    var monthDate = new DateTime(thisYear, i, 1, 0, 0, 0);
                    listExpenseIncome.Add(new ReportExpenseDate()
                    {
                        Month = monthDate.ToString("MMM"),
                        Value1 = paymentList.FirstOrDefault(p => p.Month == monthDate.ToString("MMM"))?.Value1 ?? "0",
                        Value2 = (listExpense.Where(p => p.TransactionType == TransactionType.Expense & p.Date.Year == thisYear & p.Date.Month == monthDate.Month).Sum(p => p.Amount.ToPositive()).RoundDecimal()).ToString(),
                    });
                }

                return listExpenseIncome;
            }
            catch (Exception ex)
            {

                return new List<ReportExpenseDate>();
            }
        }



        public async Task<List<ReportExpenseDate>> ListReportExportCategoryAsync(int year, TimeType type = TimeType.Year)
        {
            try
            {
                var listExpense = await _expenseRepo.GetAllAsync().Where(p => p.Date.Year == year & p.TransactionType == TransactionType.Expense).ToListAsync();
                if (type == TimeType.Month)
                    listExpense = await _expenseRepo.GetAllAsync().Where(p => p.Date.Month == DateTime.Now.Month).ToListAsync();
                if (type == TimeType.Weekly)
                {
                    var DateNow = DateTime.Now.SystemTimee();
                    var firstWeekDate = DateNow.StartOfWeekk(DayOfWeek.Monday);
                    var lastWeekDate = DateNow.StartOfWeekk(DayOfWeek.Friday);
                    listExpense = await _expenseRepo.GetAllAsync().Where(p => p.Date.Date >= firstWeekDate.Date & p.Date.Date <= lastWeekDate.Date).ToListAsync();
                }

                var listCategory = await _categoryRepo.GetAllAsync().ToListAsync();
                listCategory.Add(new CategoryEnt() { ID = 0, Title = "No Category" });
                foreach (var item in listCategory)
                {
                    if (item.ID == 0)
                        item.SumAmount = listExpense.Where(p => p.CategoryID == null).Sum(p => p.Amount.ToPositive()).RoundDecimal();
                    else
                        item.SumAmount = listExpense.Where(p => p.CategoryID == item.ID).Sum(p => p.Amount.ToPositive()).RoundDecimal();

                }
                listCategory = listCategory.OrderByDescending(p => p.SumAmount).ToList();
                var list4TopCategory = listCategory.Take(4);
                var listOtherCategory = listCategory.Skip(4);

                var ReportDatalist = new List<ReportExpenseDate>();
                foreach (var category in list4TopCategory)
                {
                    if (category.SumAmount > 0)
                        ReportDatalist.Add(new ReportExpenseDate()
                        {
                            Month = category.Title,
                            Value1 = category.SumAmount.ToString(),
                        });
                }
                var sumOther = listOtherCategory.Sum(p => p.SumAmount);
                if (sumOther > 0)
                    ReportDatalist.Add(new ReportExpenseDate()
                    {
                        Month = "Other Catgory",
                        Value1 = sumOther.ToString(),
                    });


                return ReportDatalist;
            }
            catch (Exception ex)
            {

                return null;
            }
        }



        public async Task<List<ReportExpenseDate>> ListReportExportCategoryAsync(int year, DateTime startTime, DateTime endTime)
        {
            try
            {
                var listExpense = await _expenseRepo.GetAllAsync().Where(p => p.Date.Date >= startTime.Date & p.Date <= endTime.Date & p.TransactionType == TransactionType.Expense).ToListAsync();


                var listCategory = _categoryRepo.GetAll().ToList();

                foreach (var item in listCategory)
                {
                    item.SumAmount = listExpense.Where(p => p.CategoryID == item.ID).Sum(p => p.Amount.ToPositive());
                }
                listCategory = listCategory.OrderByDescending(p => p.SumAmount).ToList();
                var list4TopCategory = listCategory.Take(4);
                var listOtherCategory = listCategory.Skip(4);

                var ReportDatalist = new List<ReportExpenseDate>();
                foreach (var category in list4TopCategory)
                {
                    if (category.SumAmount > 0)
                        ReportDatalist.Add(new ReportExpenseDate()
                        {
                            Month = category.Title,
                            Value1 = category.SumAmount.ToString(),
                        });
                }
                var sumOther = listOtherCategory.Sum(p => p.SumAmount);
                if (sumOther > 0)
                    ReportDatalist.Add(new ReportExpenseDate()
                    {
                        Month = "Other Catgory",
                        Value1 = sumOther.ToString(),
                    });


                return ReportDatalist;
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        public PayAccountEnt PayAccountDetails(int id)
        {
            try
            {
                return _payAccountRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int PayAccountIDByName(string payAccount)
        {
            try
            {
                return _payAccountRepo.GetAll().FirstOrDefault(p => p.Title == payAccount)?.ID ?? 0;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public PaymentTypeEnt PaymentTypeDetails(int id)
        {
            try
            {
                return _paymentTypeRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int PaymentTypeIDByName(string paymentType)
        {
            try
            {
                return _paymentTypeRepo.GetAll().FirstOrDefault(p => p.Title == paymentType)?.ID ?? 0;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public async Task<double> TotalExpensesAsync(int year)
        {
            try
            {
                var allExpense = await _expenseRepo.GetAllAsync().ToListAsync();
                allExpense = allExpense.Where(p => p.TransactionType == TransactionType.Expense & p.Date.Year == year).ToList();
                return allExpense.Sum(p => p.Amount.ToPositive()).RoundDecimal();

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<double> TotalExpensesAsync(DateTime startTime, DateTime endTime)
        {
            try
            {
                var allExpense = await _expenseRepo.GetAllAsync().ToListAsync();
                allExpense = allExpense.Where(p => p.TransactionType == TransactionType.Expense & p.Date.Date >= startTime.Date & p.Date.Date <= endTime.Date).ToList();
                return allExpense.Sum(p => p.Amount.ToPositive());

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<double> TotalExpensesIncomeAsync(int year)
        {
            try
            {
                var allExpense = await _expenseRepo.GetAllAsync().ToListAsync();
                allExpense = allExpense.Where(p => (p.TransactionType == TransactionType.Expense || p.TransactionType == TransactionType.Income) & p.Date.Year == year).ToList();
                return allExpense.Sum(p => p.Amount.ToPositive()).RoundDecimal();

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<double> TotalExpensesIncomeAsync(DateTime startTime, DateTime endTime)
        {
            try
            {
                var allExpense = await _expenseRepo.GetAllAsync().ToListAsync();
                allExpense = allExpense.Where(p => (p.TransactionType == TransactionType.Expense || p.TransactionType == TransactionType.Income) & p.Date.Date >= startTime.Date & p.Date.Date < endTime.Date).ToList();
                return allExpense.Sum(p => p.Amount.ToPositive());

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<double> TotalIncomeAsync(int selectYear)
        {
            try
            {
                var allExpense = await _expenseRepo.GetAllAsync().ToListAsync();
                return allExpense.Where(p => p.TransactionType == TransactionType.Income & p.Date.Year == selectYear).Sum(p => p.Amount.ToPositive()).RoundDecimal();

            }
            catch (Exception ex)
            {
                return 0;
            }
        }


    }
}
