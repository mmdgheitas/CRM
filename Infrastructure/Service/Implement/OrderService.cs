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
    public class OrderService : IOrderService
    {
        IRepositoryBase<OrderEnt, long> _OrderRepo;
        IRepositoryBase<ToolsEnt, long> _toolsRepo;
        IRepositoryBase<PaymentEnt, long> _paymentRepo;
        IRepositoryBase<SubmitSignEnt, long> _submitSignRepo;
        IRepositoryBase<OrderNoteEnt, long> _orderNoteRepo;


        public OrderService(IRepositoryBase<OrderEnt, long> _OrderRepo, IRepositoryBase<ToolsEnt, long> _toolsRepo, IRepositoryBase<PaymentEnt, long> _paymentRepo, IRepositoryBase<SubmitSignEnt, long> _submitSignRepo, IRepositoryBase<OrderNoteEnt, long> _orderNoteRepo)
        {
            this._OrderRepo = _OrderRepo;
            this._toolsRepo = _toolsRepo;
            this._paymentRepo = _paymentRepo;
            this._submitSignRepo = _submitSignRepo;
            this._orderNoteRepo = _orderNoteRepo;
        }

        public bool AddOrder(OrderEnt item)
        {
            try
            {
                return _OrderRepo.Insert(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> AddOrderAsync(OrderEnt item)
        {
            try
            {
                return await _OrderRepo.InsertAsync(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeleteOrder(long id)
        {
            try
            {
                return _OrderRepo.Delete(id);

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EditOrder(OrderEnt item)
        {
            try
            {
                return _OrderRepo.Update(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<bool> EditOrderAsync(OrderEnt item)
        {
            try
            {
                return await _OrderRepo.UpdateAsync(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public OrderEnt OrderDetails(long id)
        {
            try
            {
                return _OrderRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<OrderEnt> OrderDetailsAsync(long id)
        {
            try
            {
                return await _OrderRepo.GetAllAsync().Where(p => p.ID == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<OrderEnt> ListAllOrders()
        {
            try
            {
                return _OrderRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<OrderEnt>> ListAllOrdersAsync()
        {
            try
            {
                return await _OrderRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool AddPayment(PaymentEnt item)
        {
            try
            {
                return _paymentRepo.Insert(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddPaymentAsync(PaymentEnt item)
        {
            try
            {
                return await _paymentRepo.InsertAsync(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<PaymentEnt> PaymentDetailsAsync(long id)
        {
            try
            {
                return await _paymentRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id);
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public PaymentEnt PaymentDetails(long id)
        {
            try
            {
                return _paymentRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<PaymentEnt> ListPayments()
        {
            try
            {
                return _paymentRepo.FromSql($"SELECT * FROM Payments ;");

            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public async Task<List<PaymentEnt>> ListPaymentsAsync()
        {
            try
            {
                return await _paymentRepo.GetAllAsync().Include(p => p.Factor).OrderByDescending(p => p.PayDate).ToListAsync();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<PaymentEnt>> ListPaymentsAsync(int factorID)
        {
            try
            {
                return await _paymentRepo.GetAllAsync().Where(p => p.FactorID == factorID).OrderByDescending(p => p.PayDate).ToListAsync();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool EditPayment(PaymentEnt payment)
        {
            try
            {
                return _paymentRepo.Update(payment);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> EditPaymentAsync(PaymentEnt payment)
        {
            try
            {
                return await _paymentRepo.UpdateAsync(payment);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public byte[] GetElectronicSignatureOfFactorId(int id)
        {
            try
            {
                var submitSign = _submitSignRepo.GetAll().FirstOrDefault(p => p.FactorID == id & p.ElectronicSignature != null);
                if (submitSign == null)
                    return null;
                else
                    return submitSign?.ElectronicSignatureByte;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ToolsEnt> ListTools(string userid = "")
        {
            try
            {
                return _toolsRepo.GetAll().Where(p => (userid != "" ? p.CarearID == userid : true)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ToolsEnt>> ListToolsAsync(string userid = "")
        {
            try
            {
                return await _toolsRepo.GetAllAsync().Where(p => (userid != "" ? p.CarearID == userid : true)).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteTools(int id)
        {
            try
            {
                return _toolsRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteToolsAsync(int id)
        {
            try
            {
                return await _toolsRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ToolsEnt ToolsDetails(long id)
        {
            try
            {
                return _toolsRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ToolsEnt> ToolsDetailsAsync(long id)
        {
            try
            {
                return await _toolsRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddTools(ToolsEnt model)
        {
            try
            {
                return _toolsRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddToolsAsync(ToolsEnt model)
        {
            try
            {
                return await _toolsRepo.InsertAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditTools(ToolsEnt model)
        {
            try
            {
                return _toolsRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> EditToolsAsync(ToolsEnt model)
        {
            try
            {
                return await _toolsRepo.UpdateAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeletePayment(long id)
        {
            try
            {
                return _paymentRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeletePaymentAsync(long id)
        {
            try
            {
                return await _paymentRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddSubmitSign(SubmitSignEnt item)
        {
            try
            {
                return _submitSignRepo.Insert(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool IfExistSubmit(int fID)
        {
            try
            {
                return _submitSignRepo.GetAll().Any(p => p.FactorID == fID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public SubmitSignEnt SubmitSignDetailsByFactorID(int fID)
        {
            try
            {
                return _submitSignRepo.GetAll().FirstOrDefault(p => p.FactorID == fID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SubmitSignEnt> ListSubmitSigns()
        {
            try
            {
                return _submitSignRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<SubmitSignEnt>> ListSubmitSignsAsync()
        {
            try
            {
                return await _submitSignRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<OrderNoteEnt> ListOrderNotes(int id)
        {
            try
            {
                return _orderNoteRepo.GetAll().Where(p => p.OrdreID == id).OrderByDescending(p => p.ID).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<OrderNoteEnt>> ListOrderNotesAsync(int id)
        {
            try
            {
                return await _orderNoteRepo.GetAllAsync().Where(p => p.OrdreID == id).OrderByDescending(p => p.ID).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddOrderNote(string text, int id)
        {
            try
            {
                var note = new OrderNoteEnt() { OrdreID = id, Note = text };
                return _orderNoteRepo.Insert(note);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> AddOrderNoteAsync(string text, int id)
        {
            try
            {
                var note = new OrderNoteEnt() { OrdreID = id, Note = text };
                return await _orderNoteRepo.InsertAsync(note);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteOrderNote(long id)
        {
            try
            {
                return _orderNoteRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrderNoteAsync(long id)
        {
            try
            {
                return await _orderNoteRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ReportExpenseDate>> ListReportMonthlyPaymentsAsync(int thisYear, bool allMonth = true)
        {
            try
            {
                var dateNow = DateTime.Now.SystemTimee();
                var listPayment = await ListPaymentsAsync();
                var listMonthlyPayment = new List<ReportExpenseDate>();
                for (int i = 1; i <= 12; i++)
                {
                    var monthDate = new DateTime(thisYear, i, 1, 0, 0, 0);
                    if (allMonth == false) if (dateNow.Year == thisYear & dateNow.Month < i) break;

                    listMonthlyPayment.Add(new ReportExpenseDate()
                    {
                        Month = monthDate.ToString("MMM"),
                        Value1 = (listPayment.Where(p => p.Confirmed & p.PayDate.Year == thisYear & p.PayDate.Month == monthDate.Month).Sum(p => p.Price).RoundDecimal()).ToString(),
                    });
                }

                return listMonthlyPayment;
            }
            catch (Exception ex)
            {

                return new List<ReportExpenseDate>();
            }
        }

        public async Task<List<ReportExpenseDate>> ListReportDailyPaymentsAsync(int thisYear, DateTime startTime, DateTime endTime, int intervalDay)
        {
            try
            {
                var listPayment = await ListPaymentsAsync();
                var listMonthlyPayment = new List<ReportExpenseDate>();
                for (DateTime time = startTime; time <= endTime; time = time.AddDays(intervalDay))
                {
                    //if (DateTime.Now.Year == thisYear & DateTime.Now.SystemTimee().Month < i) break;
                    var dayLable = intervalDay == 1 ? time.ToString("M") : time.ToString("M") + "->" + time.AddDays(intervalDay).ToString("M");
                    listMonthlyPayment.Add(new ReportExpenseDate()
                    {
                        Month = dayLable,
                        Value1 = listPayment.Where(p => p.Confirmed & p.PayDate.Year == thisYear & p.PayDate.Date >= time.Date & p.PayDate.Date == time.Date).Sum(p => p.Price).ToString(),
                        //id interval more than 1 => p.PayDate.Date >= time.Date & p.PayDate.Date < time.AddDays(intervalDay).Date
                    });


                }

                return listMonthlyPayment;
            }
            catch (Exception ex)
            {

                return new List<ReportExpenseDate>();
            }
        }
        public async Task<double> TotalPaymentAsync(int year)
        {
            try
            {
                var listPayment = await _paymentRepo.GetAllAsync().Where(p => p.Confirmed & p.PayDate.Year == year).ToListAsync();

                return listPayment.Sum(p => p.Price).RoundDecimal();
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public async Task<double> TotalPaymentAsync(DateTime startTime, DateTime endTime)
        {
            try
            {
                var listPayment = await _paymentRepo.GetAllAsync().ToListAsync();

                return listPayment.Where(p => p.Confirmed & p.PayDate.Date >= startTime.Date & p.PayDate.Date <= endTime.Date).Sum(p => p.Price);
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public async Task<double> TotalPaymentThisMonthAsync(int selectYear)
        {
            try
            {
                var listPayment = await _paymentRepo.GetAllAsync().ToListAsync();
                var datenow = DateTime.Now.SystemTimee();
                return listPayment.Where(p => p.Confirmed & p.PayDate.Year == selectYear & p.PayDate.Month == datenow.Month).Sum(p => p.Price).RoundDecimal();
            }
            catch (Exception ex) { return 0; }
        }


    }

}
