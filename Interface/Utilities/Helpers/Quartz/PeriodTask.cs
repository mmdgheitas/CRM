using Acklann.Plaid;
using AutoMapper;
using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Implement;
using Infrastructure.Service.Interface;
using Interface.Models;
using Interface.Models.Google;
using Interface.Models.Setting;
using Interface.Repository;
using Microsoft.AspNet.Identity;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Interface.Models.Email;
using System.Web.Mvc;
using Interface.Controllers;
using Interface.Models.Factor;

namespace Interface.Utilities.Quartz
{
    public class PeriodTask : IJob
    {

        public readonly ISettingService _settingService;

        private readonly IRepositoryBase<EmailSettingEnt, byte> _emailSettingRepo;
        private readonly IRepositoryBase<StatusNotificationEnt, int> _statusRepo;

        private readonly IRepositoryBase<PlaidPublicTokenEnt, int> _plaidTokenRepo;
        private readonly IRepositoryBase<PlaidAccountEnt, int> _plaidaccountRepo;
        private readonly IRepositoryBase<PlaidTransactionEnt, long> _plaidTransactionRepo;
        private readonly IRepositoryBase<LogEnt, long> _logRepo;
        private readonly IRepositoryBase<ExpenseEnt, long> _expenseRepo;
        private readonly IRepositoryBase<FactorEnt, int> _factorRepo;
        private readonly IRepositoryBase<FactorTaskEnt, long> _TaskRepo;
        private readonly IRepositoryBase<FactorNoteEnt, long> _FactorNoteRepo;


        public readonly IPlaidService _plaidService;

        public PeriodTask()
        {
            _emailSettingRepo = new RepositoryBase<EmailSettingEnt, byte>();
            _statusRepo = new RepositoryBase<StatusNotificationEnt, int>();

            _settingService = new SettingService(_emailSettingRepo, _statusRepo);


            _plaidTokenRepo = new RepositoryBase<PlaidPublicTokenEnt, int>();
            _plaidaccountRepo = new RepositoryBase<PlaidAccountEnt, int>();
            _plaidTransactionRepo = new RepositoryBase<PlaidTransactionEnt, long>();
            _plaidService = new PlaidService(_plaidTokenRepo, _plaidaccountRepo, _plaidTransactionRepo);

            _logRepo = new RepositoryBase<LogEnt, long>();
            _expenseRepo = new RepositoryBase<ExpenseEnt, long>();

            _factorRepo = new RepositoryBase<FactorEnt, int>();
            _TaskRepo = new RepositoryBase<FactorTaskEnt, long>();
            _FactorNoteRepo = new RepositoryBase<FactorNoteEnt, long>();
        }


        public async Task Execute(IJobExecutionContext context)
        {
            var userManager = new IdentityManager(new ApplicationDbContext())._userManager;

            #region Get Voice Email
            var UserList = userManager.Users.ToList();
            try
            {
                var model = Mapper.DynamicMap<EmailSettingEnt, EmailSettingModel>(_settingService.DefaultEmailSetting());


                var listEmail = new GmailMessagesService().GetEmailSender(model.EmailAddress, model.Password);


                var ListEmailAdded = new List<string>();
                foreach (var item in listEmail)
                {

                    try
                    {

                        int startindex = item.IndexOf(".1") + 2;
                        int Endindex = item.IndexOf('.', item.IndexOf('.') + 1) - startindex;
                        string outputstring = item.Substring(startindex, Endindex);

                        var find = UserList.FirstOrDefault(p => p.PhoneNumber == outputstring);
                        if (find != null)
                        {
                            find.VoiceGmail = item;
                            userManager.Update(find);
                        }
                        else
                        {

                        }

                    }
                    catch { }
                }

                _logRepo.Insert2(new LogEnt() { Date = DateTime.Now, Description = "Email Added", Type = 10 });
            }
            catch (Exception ex)
            {
                _logRepo.Insert2(new LogEnt() { Date = DateTime.Now, Description = "Email Added Error", Type = 10 });

            }
            #endregion

            #region Get Transaction In Plaid
            try
            {
                var ListAccounts = _plaidTokenRepo.GetAll();
                foreach (var item in ListAccounts)
                {
                    var SiteSetting = (new RepositoryBase<SettingEnt, byte>().GetAll()).FirstOrDefault();
                    var _clientId = SiteSetting?.PlaidClientID ?? ""; ;
                    var _secrets = SiteSetting?.PlaidSecret ?? "";
                    var _env = Acklann.Plaid.Environment.Development;
                    var client = new PlaidClient(_clientId, _secrets, null, _env);
                    var model = _plaidTokenRepo.GetAll().FirstOrDefault(p => p.ID == item.ID);
                    var ListAccount = _plaidaccountRepo.GetAll().Where(p => p.PlaidPublicTokenID == model.ID);

                    #region Add Transaction To DB
                    var result2 = client.FetchTransactionsAsync(
                              new Acklann.Plaid.Transactions.GetTransactionsRequest()

                              {
                                  ClientId = _clientId,
                                  Secret = _secrets,
                                  AccessToken = model.AccessToken,
                                  StartDate = DateTime.Now.AddDays(-2),
                                  EndDate = DateTime.Now.SystemTime(),
                              }).Result;

                    if (result2.Transactions == null)
                    {

                    }
                    else
                    {
                        var listExpense = new RepositoryBase<ExpenseEnt, long>().GetAll();
                        foreach (var tr in result2.Transactions)
                        {
                            if (_plaidTransactionRepo.GetAll().Any(p => p.TransactionId == tr.TransactionId))
                                continue;
                            var PlaidTransaction = new PlaidTransactionEnt()
                            {
                                TransactionId = tr.TransactionId,
                                Amount = tr.Amount,
                                Name = tr.Name,
                                Date = tr.Date,
                                PlaidAccountID = ListAccount.FirstOrDefault(p => p.AccountId == tr.AccountId)?.ID ?? null,
                                jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(tr),
                                AddToExpense = listExpense.Any(p => p.TransactionId == tr.TransactionId),
                            };

                            var res = _plaidTransactionRepo.Insert2(PlaidTransaction);

                        }
                    }

                    #endregion

                }

                _logRepo.Insert2(new LogEnt() { Date = DateTime.Now, Description = "Add Transaction -" + _plaidTransactionRepo.GetAll().Count() });
            }
            catch (Exception ex)
            {
                _logRepo.Insert2(new LogEnt() { Date = DateTime.Now, Description = "Add Transaction error -" + ex.ToString() });
            }
            #endregion


            #region Set Transaction to Expense
            //var step = 0;
            //try
            //{
            //    var expenseList = _expenseRepo.GetAll().Where(p => p.Date.Date >= DateTime.Now.SystemTimee().AddDays(-2).Date & string.IsNullOrEmpty(p.TransactionId) ).ToList();
            //    step++;
            //    foreach (var expense in expenseList)
            //    {
            //        var transaction = _plaidTransactionRepo.GetAll().FirstOrDefault(p => p.Date == expense.Date & (double)p.Amount == (double)expense.Amount);
            //        step++;
            //        if (transaction != null)
            //        {
            //            expense.TransactionId = transaction.TransactionId;
            //            step++;
            //            //Send Notification to app
            //            _expenseRepo.Update2(expense);
            //        }
            //    }
            //    _logRepo.Insert2(new LogEnt() { Date = DateTime.Now, Description = "Set Transaction to expense -step: "+ step });

            //}
            //catch (Exception ex)
            //{
            //    _logRepo.Insert2(new LogEnt() { Date = DateTime.Now, Description = "Set Transaction to expense  error -step: "+ step + "-" + ex.ToString() });

            //}

            #endregion


            #region Get Factor Due Date Today
            int email = 0;
            string errorMessaeg = "";
            var AllFactorList = _factorRepo.GetAll();
            var FactorList = AllFactorList.Where(p =>
            (DateTime.Now.SystemTime() - p.DueDate).TotalDays < 10 &
            (DateTime.Now.SystemTime() - p.DueDate).TotalDays > 0 & 
             p.DueDate.Date != p.Date.Date 
             & (p.TaxAmount + p.FactorPrice - p.PaidPrice) > 1  //Remaining not zero

              ).ToList();
            var notification = _settingService.GetNotification(FactorStatus.DueDate);
            if (notification != null)
            {
                foreach (var factor in FactorList)
                {
                    try
                    {

                        var customer = userManager.FindById(factor.CustomerID);

                        if (customer == null) continue;

                        var defaultSetting = _settingService.DefaultEmailSetting();
                        var EmailValue = new EmailValue();
                        EmailValue.WebsiteName = defaultSetting.CompanyName;
                        EmailValue.HomePage = "https://start.glassma.us";
                        EmailValue.Login = EmailValue.HomePage + "/Account/Login";
                        EmailValue.ButtonClick = EmailValue.HomePage + "/User/Project/" + factor.PrivateID;
                        EmailValue.SecoundLink = EmailValue.HomePage + "/User/Project/" + factor.PrivateID;
                        EmailValue.ButtonText = "View Invoice";
                        EmailValue.EmailTitle = $"Work Order({factor.PONumber})";
                        EmailValue.Content = notification.NotificationText;
                        EmailValue.Phone = defaultSetting.CompanyPhone;
                        EmailValue.LogoURL = defaultSetting.logo.Replace("svg", "png");

                        var Content = notification.NotificationText.Replace("\r\n", "<br />");
                        Content += "<br />" + "<br />" + EmailValue.ButtonClick;
                        var sendEmailResult = new MailSender(_settingService.DefaultEmailSetting()).SendMail(EmailValue.EmailTitle, Content, customer.Email, customer.SecondEmail);

                        if (sendEmailResult == "success") email++;
                        else errorMessaeg += sendEmailResult;


                    }
                    catch (Exception ex)
                    {
                        errorMessaeg += ex.ToString();
                    }

                }


            }
            var SettingBase = new RepositoryBase<SettingEnt, byte>().GetAll().FirstOrDefault() ?? new SettingEnt() { JobTaskEndTime = 18, JobTaskStartTime = 8, JobTaskInterval = 30 };
            #endregion

            #region Auto Task for Due Date Pay


            foreach (var factor in FactorList)
            {
                try
                {

                    var AdmiUser = userManager.FindById(factor.RegisterUserID) ?? new ApplicationUser(); ;
                    //Create Auto task for project admin to follow up  due past
                    var Now = DateTime.Now.SystemTime();
                    var LastTaskToday = new FactorTaskEnt() { EndDate = new DateTime(Now.Year, Now.Month, Now.Day, SettingBase.JobTaskStartTime, 0, 0) };
                    if (Now.DayOfWeek == DayOfWeek.Saturday || Now.DayOfWeek == DayOfWeek.Sunday)
                    {//Dont Save Task in Weekend
                        var firstOfWeek = DateTime.Now.SystemTime().StartOfWeekk(DayOfWeek.Monday).AddDays(7);
                        LastTaskToday = new FactorTaskEnt() { EndDate = new DateTime(firstOfWeek.Year, firstOfWeek.Month, firstOfWeek.Day, SettingBase.JobTaskStartTime, 0, 0) };

                    }
                    try
                    {
                        LastTaskToday = _TaskRepo.GetAll().Where(p => p.EmployeeID == factor.RegisterUserID & p.EndDate.Date == LastTaskToday.EndDate.Date).OrderBy(p => p.EndDate).LastOrDefault() ?? LastTaskToday;
                    }
                    catch { }
                    if (_TaskRepo.GetAll().Any(p => p.FactorID == factor.ID & p.TaskMode == FactorTaskMode.DuePastPay))
                        continue;

                    var newTask = new FactorTaskEnt()
                    {
                        EmployeeID = factor.RegisterUserID,
                        UserFullName = (AdmiUser?.FirstName ?? "") + " " + (AdmiUser?.LastName ?? ""),
                        Title = "Due date pay follow-up",
                        FactorID = factor.ID,
                        TaskMode = FactorTaskMode.DuePastPay,
                        TaskType = FactorTaskType.Task,
                        StartDate = LastTaskToday.EndDate,
                        EndDate = LastTaskToday.EndDate.AddMinutes(SettingBase.JobTaskInterval),
                        Done = false,
                        Description = "Follow up due date payment ",
                        modifiedInfo = DateTime.Now.SystemTime().ToString("yyyy/MM/dd hh:mm:ss:tt") + " By System",
                    };

                    _TaskRepo.Insert2(newTask);
                    _FactorNoteRepo.Insert2(new FactorNoteEnt()
                    {
                        FactorID = factor.ID,
                        FactorTaskID = newTask.ID,
                        Note = newTask.Description,
                        modifiedInfo = newTask.modifiedInfo

                    });

                }
                catch (Exception ex)
                {
                    var a = 0;
                }
            }
            #endregion

            #region Auto Task for Unread Email

            try
            {


                var listVisitPage = (await new RepositoryBase<PageViewStatisticsEnt, long>().GetAllAsync()).Where(p => string.IsNullOrEmpty(p.FullName) & p.PageName == "Project" & p.Date > DateTime.Now.SystemTime().AddDays(-20)).ToList();
                var listPrivateID = listVisitPage.Select(p => p.PageID).ToList();
                var modelList = AllFactorList.Where(p => p.Status != FactorStatus.Estimation & p.Status != FactorStatus.PreEstimation & p.Status != FactorStatus.Cancelled & p.Status != FactorStatus.Close & p.IsProjectHasPaymentOrPlaceOrder() == false & p.Date > DateTime.Now.SystemTime().AddDays(-10) & (DateTime.Now.SystemTime() - p.Date).TotalDays > 1 & p.PaidPrice < 1 & !listPrivateID.Contains(p.PrivateID)).ToList();


                var listAllEmail = (await new RepositoryBase<ReportEmailEnt, long>().GetAllAsync()).Where(p => p.Subject != null & p.SentDate > DateTime.Now.SystemTime().AddDays(-20)).ToList();
                foreach (var factor in modelList)
                {
                    bool EmailSent = true;
                    try
                    {

                        var Customer = UserList.FirstOrDefault(u => u.Id == factor.CustomerID);
                        if (Customer == null)
                            continue;
                        var Email = Customer.Email;

                        var listEmails = listAllEmail.Where(e => (e.ReciverEmail == Email));
                          EmailSent = listAllEmail.Any(e => e.Subject.Contains(factor.PONumber.ToString()) & (e.ReciverEmail == Email));


                    }
                    catch { }

                    //Add Auto Task
                    try
                    {
                        var AdmiUser = userManager.FindById(factor.RegisterUserID) ?? new ApplicationUser(); ;
                        //Create Auto task for project admin to follow up  due past
                        var Now = DateTime.Now.SystemTime();
                        var LastTaskToday = new FactorTaskEnt() { EndDate = new DateTime(Now.Year, Now.Month, Now.Day, SettingBase.JobTaskStartTime, 0, 0) };
                        if (Now.DayOfWeek == DayOfWeek.Saturday || Now.DayOfWeek == DayOfWeek.Sunday)
                        {
                            //Do not add     Task in Weekend
                            var firstOfWeek = DateTime.Now.SystemTime().StartOfWeekk(DayOfWeek.Monday).AddDays(7);
                            LastTaskToday = new FactorTaskEnt() { EndDate = new DateTime(firstOfWeek.Year, firstOfWeek.Month, firstOfWeek.Day, SettingBase.JobTaskStartTime, 0, 0) };

                        }
                        try
                        {
                            LastTaskToday = _TaskRepo.GetAll().Where(t => t.EmployeeID == factor.RegisterUserID & t.EndDate.Date == LastTaskToday.EndDate.Date).OrderBy(t => t.EndDate).LastOrDefault() ?? LastTaskToday;
                        }
                        catch { }


                        if (_TaskRepo.GetAll().Any(t => t.FactorID == factor.ID & t.TaskMode == FactorTaskMode.UnReadEmail & (LastTaskToday.EndDate - t.EndDate).TotalDays <= 3))
                            continue;

                        if (_TaskRepo.GetAll().Any(t => t.FactorID == factor.ID & t.TaskMode == FactorTaskMode.UnReadEmail & t.Done == true))
                            continue;

                        var newTask = new FactorTaskEnt()
                        {
                            EmployeeID = factor.RegisterUserID,
                            UserFullName = (AdmiUser?.FirstName ?? "") + " " + (AdmiUser?.LastName ?? ""),
                            Title = "Follow-up on invoice opening",
                            FactorID = factor.ID,
                            TaskMode = FactorTaskMode.UnReadEmail,
                            TaskType = FactorTaskType.Task,
                            StartDate = LastTaskToday.EndDate,
                            EndDate = LastTaskToday.EndDate.AddMinutes(SettingBase.JobTaskInterval),
                            Done = false,
                            Description = "Follow-up the opening of invoice",
                            modifiedInfo = DateTime.Now.SystemTime().ToString("yyyy/MM/dd hh:mm:ss:tt") + " By System",
                        };

                        _TaskRepo.Insert2(newTask);
                        if (!EmailSent)
                        {
                            _FactorNoteRepo.Insert2(new FactorNoteEnt()
                            {
                                FactorID = factor.ID,
                                FactorTaskID = newTask.ID,
                                Note = "Invoice email has not been sent. Please check the authenticity of the email and resend the email",
                                modifiedInfo = newTask.modifiedInfo
                            });
                        }
                        _FactorNoteRepo.Insert2(new FactorNoteEnt()
                        {
                            FactorID = factor.ID,
                            FactorTaskID = newTask.ID,
                            Note = newTask.Description,
                            modifiedInfo = newTask.modifiedInfo

                        });

                    }
                    catch { }
                }




            }
            catch { }
            #endregion

            _logRepo.Insert2(new LogEnt()
            {
                Date = DateTime.Now.SystemTime(),
                Description =
                    $"send invoice to customer :" +
                   $"[email :{email}]" +
                   $"[error :{errorMessaeg}]",
                Type = 15,
            });


        }
    }
}