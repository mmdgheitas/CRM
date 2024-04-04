using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface IAccountingService
    {
        Task<List<ExpenseEnt>> ListAllExpenses();
        Task<List<ExpenseEnt>> ListAllExpensesAsync();
        bool DeleteExpense(long id);
        Task<bool> DeleteExpenseAsync(long id);
        ExpenseEnt ExpenseDetails(long id);
       Task<ExpenseEnt?> ExpenseDetailsAsync(long id);
        bool AddExpense(ExpenseEnt item);
       Task< string> AddExpenseAsync(ExpenseEnt item);
        bool EditExpense(ExpenseEnt item);
       Task< string> EditExpenseAsync(ExpenseEnt item);
        List<CategoryEnt> ListCategories();
        Task<List<CategoryEnt>> ListCategoriesAsync();
        bool DeleteCategory(int id);
        CategoryEnt CategoryDetails(int id);
        bool IFExistCategoryTitle(string title, int iD);
        Task<string> IFExistCategoryTitleAsync(string title, int id = 0);
        bool AddCategory(CategoryEnt model);
        Task<bool> AddCategoryAsync(CategoryEnt model);
        bool EditCategory(CategoryEnt model);

        List<ExpenseProductEnt> ListExpenseProducts();
        Task<List<ExpenseProductEnt>> ListExpenseProductsAsync();
        bool DeleteExpenseProduct(int id);
        ExpenseProductEnt ExpenseProductDetails(int id);
        bool IFExistExpenseProductTitle(string title, int iD);
       Task< string> IFExistExpenseProductTitleAsync(string title, int id = 0);
        bool AddExpenseProduct(ExpenseProductEnt model);
        Task<bool> AddExpenseProductAsync(ExpenseProductEnt model);
        bool EditExpenseProduct(ExpenseProductEnt model);
        List<PaymentTypeEnt> ListPaymentTypes();
        Task<List<PaymentTypeEnt>> ListPaymentTypesAsync();
        bool DeletePaymentType(int id);
        PaymentTypeEnt PaymentTypeDetails(int id);
        bool IFExistPaymentTypeTitle(string title, int iD);
        bool AddPaymentType(PaymentTypeEnt model);
        bool EditPaymentType(PaymentTypeEnt model);
        bool DeletePayAccount(int id);
        PayAccountEnt PayAccountDetails(int id);
        bool IFExistPayAccountTitle(string title, int iD);
       Task< string> IFExistPayAccountTitleAsync(string title, int id = 0);
        bool AddPayAccount(PayAccountEnt model);
       Task< bool> AddPayAccountAsync(PayAccountEnt model);
        bool EditPayAccount(PayAccountEnt model);
        List<PayAccountEnt> ListPayAccounts();

        Task<List<PayAccountEnt>> ListPayAccountsAsync();
        List<ExpenseTypeEnt> ListExpenseType();
        Task<List<ExpenseTypeEnt>> ListExpenseTypeAsync();
        List<ExpenseEnt> ListExpenses();
        List<ExpenseTypeEnt> ListexpenseType();
        bool DeleteExpenseType(int id);
        ExpenseTypeEnt ExpenseTypeDetails(int id);
        bool IFExistExpenseTypeTitle(string title, int iD);
       Task< string> IFExistExpenseTypeTitleAsync(string title, int id = 0);
        bool AddExpenseType(ExpenseTypeEnt model);
            Task<bool> AddExpenseTypeAsync(ExpenseTypeEnt model);
        bool EditExpenseType(ExpenseTypeEnt model);
       // string[] ListPayTo();
        int CategoryIdByName(string categoryName);
        int PaymentTypeIDByName(string paymentType);
        int PayAccountIDByName(string payAccount);
        int ExpenseTypeIDByName(string expenseType);
        bool IfUsedVandorsInExpense(int id);
        Task<List<ReportExpenseDate>> ListReportExpenseVsPaymentMonthlyAsync(int thisYear, List<ReportExpenseDate> paymentList,bool allMonth = true);
        Task<List<ReportExpenseDate>> ListReportExpenseVsPaymentDailyAsync(int selectYear, List<ReportExpenseDate> paymentList, DateTime startTime, DateTime endTime, int intervalDay);

        Task<List<ReportExpenseDate>> ListReportExportCategoryAsync(int thisYear, TimeType type = TimeType.Year);
        Task<List<ReportExpenseDate>> ListReportExportCategoryAsync(int thisYear,DateTime startTime ,DateTime endTime);
        Task<double> TotalExpensesAsync(int year);
        Task<double> TotalExpensesAsync(DateTime startTime , DateTime endTime);

        Task<double> TotalExpensesIncomeAsync(int year);
        Task<double> TotalExpensesIncomeAsync(DateTime startTime, DateTime endTime);
        Task<double> TotalIncomeAsync(int selectYear);
   
    }
}
