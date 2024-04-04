using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface IOrderService
    {
        List<OrderEnt> ListAllOrders();
        Task<List<OrderEnt>> ListAllOrdersAsync();
        bool DeleteOrder(long id);
        OrderEnt OrderDetails(long id);
       Task<OrderEnt> OrderDetailsAsync(long id);
        bool AddOrder(OrderEnt item);
        Task<bool> AddOrderAsync(OrderEnt item);
        bool EditOrder(OrderEnt item);
       Task< bool> EditOrderAsync(OrderEnt item);
        bool AddPayment(PaymentEnt item);
        Task<bool> AddPaymentAsync(PaymentEnt item);
        PaymentEnt PaymentDetails(long id);
        Task<PaymentEnt> PaymentDetailsAsync(long id);
        List<PaymentEnt> ListPayments();
        Task<List<PaymentEnt>> ListPaymentsAsync();
        Task<List<PaymentEnt>> ListPaymentsAsync(int factorID );

        bool EditPayment(PaymentEnt payment);
        Task<bool> EditPaymentAsync(PaymentEnt payment);
        byte[] GetElectronicSignatureOfFactorId(int id);


        List<ToolsEnt> ListTools(string userid = ""); 
        Task<List<ToolsEnt>> ListToolsAsync(string userid = "");
        bool DeleteTools(int id);
        Task<bool> DeleteToolsAsync(int id);
        ToolsEnt ToolsDetails(long id);
        Task<ToolsEnt> ToolsDetailsAsync(long id);
        bool AddTools(ToolsEnt model);
       Task< bool> AddToolsAsync(ToolsEnt model);
        bool EditTools(ToolsEnt model);
        Task<bool> EditToolsAsync(ToolsEnt model);

        bool DeletePayment(long id);
        Task<bool> DeletePaymentAsync(long id);

        bool AddSubmitSign(SubmitSignEnt item);
        bool IfExistSubmit(int fID);
        SubmitSignEnt SubmitSignDetailsByFactorID(int fID);
        List<SubmitSignEnt> ListSubmitSigns();
        Task<List<SubmitSignEnt>> ListSubmitSignsAsync();
        List<OrderNoteEnt> ListOrderNotes(int id);
        Task<List<OrderNoteEnt>> ListOrderNotesAsync(int id);
        bool AddOrderNote(string text, int id);
       Task< bool> AddOrderNoteAsync(string text, int id);
        bool DeleteOrderNote(long id);
        Task<bool> DeleteOrderNoteAsync(long id);
        Task<List<ReportExpenseDate>> ListReportMonthlyPaymentsAsync(int thisYear, bool allMonth = true);
        Task<List<ReportExpenseDate>> ListReportDailyPaymentsAsync(int thisYear, DateTime startTime, DateTime endTime, int intervalDay);
        Task<double> TotalPaymentAsync(int year);
        Task<double> TotalPaymentAsync(DateTime startTime, DateTime endTime);

        Task<double> TotalPaymentThisMonthAsync(int selectYear);
    }
}
