using Acklann.Plaid;
using AutoMapper;
using Infrastructure.Entity;
using Infrastructure.Service.Interface;
using Interface.Models;
using Interface.Models.Application;
using Interface.Models.Plaid;
using Interface.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Interface.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PlaidapiController : ApiController
    {


        private readonly IFactorService _factorService;
        private readonly IPlaidService _plaidService;
        private readonly IAccountingService _accountingService;
        private readonly ISettingService _settingService;
        private readonly IOrderService _orderService;
     
        public PlaidapiController(IFactorService _factorService, IAccountingService accounting, IPlaidService plaid, ISettingService settingService, IOrderService OrderService)
        {
            this._factorService = _factorService;
            this._plaidService = plaid;
            this._settingService = settingService;
            this._accountingService = accounting;
            this._orderService = OrderService;
        }


        public async Task<HttpResponseMessage> GetUserInfo(string user = "", string password = "")
        {
            try
            {
                if (user == "" || password == "")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.NotAcceptable,
                        user_message = "User and Password Required",
                    }.ToHttpResponseMessage(this.Request);
                }
                //var UserList = new ApplicationDbContext().Users.ToList();
                var userManager = new IdentityManager(new ApplicationDbContext())._userManager;
                var userinfo = userManager.Users.FirstOrDefault(p => p.PhoneNumber == user || p.Email == user);
                if (userinfo == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.NotAcceptable,
                        user_message = "User Not Exist",
                    }.ToHttpResponseMessage(this.Request);
                }
                
                if (userManager.PasswordHasher.VerifyHashedPassword(userinfo.PasswordHash, password).ToString() != "Success") //Check Password verify
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.NotAcceptable,
                        user_message = "Password incorrect",
                        results = null
                    }.ToHttpResponseMessage(this.Request);
                }

                var userResult = Mapper.DynamicMap<UserApp>(userinfo);
                userResult.Image = "https://start.glassma.us/Content/Files/ProfileImages/" + (userinfo?.Image ?? "default-image.jpg");
                userResult.FullName = (userResult?.FirstName ?? "") + " " + (userResult?.LastName ?? "");
                userResult.Token = userinfo.BotToken;
                if (string.IsNullOrEmpty(userinfo.BotToken) || userinfo.ExpireDate < DateTime.Now.SystemTime())
                {
                    //Create New Token
                    userinfo.BotToken = System.Guid.NewGuid().ToString();
                    userinfo.ExpireDate = DateTime.Now.SystemTime().AddMonths(1);
                    userResult.Token = userinfo.BotToken;
                    var updateuser = await userManager.UpdateAsync(userinfo);
                    if (updateuser.Succeeded)
                        return new ApiJsonResult()
                        {
                            code = HttpStatusCode.OK,
                            user_message = "Login Successfully",
                            results = userResult
                        }.ToHttpResponseMessage(this.Request);
                    else
                    {
                        return new ApiJsonResult()
                        {
                            code = HttpStatusCode.GatewayTimeout,
                            user_message = "Cannot Create token to login. please contact administrator",
                            results = userResult
                        }.ToHttpResponseMessage(this.Request);
                    }
                }
              

                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Login Successfully",
                    results = userResult
                }.ToHttpResponseMessage(this.Request);

            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }

        public async Task<HttpResponseMessage> GetPlaidAppVersion()
        {

            try
            {
                var setting = (await new RepositoryBase<SettingEnt, byte>().GetAllAsync()).FirstOrDefault();

                if (setting == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.NotFound,
                        user_message = "Error please try again later.",

                    }.ToHttpResponseMessage(this.Request);
                }

                var Update = new UpdateApplicationViewModel()
                {
                    Buile = setting.Buile,
                    DownloadForce = setting.DownloadForce,
                    DownloadLink = setting.DownloadLink,
                    UpdateDescription = setting.UpdateDescription,
                    Version = setting.Version

                };

                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Successfully",
                    results = Update
                }.ToHttpResponseMessage(this.Request);

            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }
        public async Task<HttpResponseMessage> GetPlaidAccount()
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }
                var plaids = await _plaidService.ListPlaidPublicTokens();
                if (plaids == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.InternalServerError,
                        user_message = "Error please try again later",
                        developer_message = "Cannot connect to database",
                    }.ToHttpResponseMessage(this.Request);
                }

                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = plaids
                }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }

        public async Task<HttpResponseMessage> GetTransactionsByPlaidID(int id)
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }
                var Transactions = await _plaidService.ListTransactionsByPublicTokenID(id);
                var Transactionsmodel = Transactions.Select(x => new
                {
                    x.ID,
                    x.PlaidAccountID,
                    x.TransactionId,
                    x.Name,
                    x.Amount,
                    x.Date,
                    x.AddToExpense,
                    x.jsonData
                }).ToList();
                if (Transactionsmodel == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.InternalServerError,
                        user_message = "Error please try again later",
                        developer_message = "Cannot connect to database",
                    }.ToHttpResponseMessage(this.Request);
                }

                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = Transactionsmodel
                }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }

        public async Task<HttpResponseMessage> GetReport(int year = 0)
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }

                var model = new ReportExpenseViewModel();
                model.SelectYear = year == 0 ? DateTime.Now.SystemTime().Year : year;
                model.PaymentList = await _orderService.ListReportMonthlyPaymentsAsync(model.SelectYear, false);
                model.ExpenseVsPayments = await _accountingService.ListReportExpenseVsPaymentMonthlyAsync(model.SelectYear, model.PaymentList);
                model.ExpenseByCategory = await _accountingService.ListReportExportCategoryAsync(model.SelectYear, TimeType.Year);
                model.PlaidAccounts = await _plaidService.ListAllAccount();
                model.TotalExpense = await _accountingService.TotalExpensesAsync(model.SelectYear);
                model.TotalExpenseIncome = await _accountingService.TotalExpensesIncomeAsync(model.SelectYear);
                model.TotalIncom = await _accountingService.TotalIncomeAsync(model.SelectYear);
                model.TotalPayed = await _orderService.TotalPaymentAsync(model.SelectYear);
                model.TotalNotPayed = await _factorService.TotalNotPayedAsync(model.SelectYear);
                model.TotalNotPayedThisMonth = await _factorService.TotalNotPayedThisMonthAsync(model.SelectYear);
                model.TotalPayedThisMonth = await _orderService.TotalPaymentThisMonthAsync(model.SelectYear);
                model.TotalTransactions = await _plaidService.TotalTransactionExpenses(model.SelectYear);
                model.TotalOverDuePayment = await _factorService.TotalOverDuePaymentAsync(model.SelectYear);
                model.TotalNotDuePayment = await _factorService.TotalNotDuePaymentAsync(model.SelectYear);

                model.TotalOverDuePayment_Percent = model.TotalOverDuePayment.CalculatePercentByAnotherValue(model.TotalNotDuePayment);
                model.TotalNotDuePayment_Percent = 100 - model.TotalOverDuePayment_Percent;
                model.TotalTransactionSaved = await _plaidService.TotalTransactionSaevd(model.SelectYear);
                model.TotalTransactionNotSaved = await _plaidService.TotalTransactionNotSaevd(model.SelectYear);

                model.TotalTransactionSaved_Percent = model.TotalTransactionSaved.CalculatePercentByAnotherValue(model.TotalTransactionNotSaved);
                model.TotalTransactionNotSaved_Percent = 100 - model.TotalTransactionSaved_Percent;

                model.TotalPayed_Percent = model.TotalPayed.CalculatePercentByAnotherValue(model.TotalNotPayed);
                model.TotalNotPayed_Percent = 100 - model.TotalPayed_Percent;

                model.TotalPayedThisMonth_Percent = model.TotalPayedThisMonth.CalculatePercentByAnotherValue(model.TotalNotPayedThisMonth);
                model.TotalNotPayedThisMonth_Percent = 100 - model.TotalPayedThisMonth_Percent;


                model.TotalExpense_Percent = model.TotalExpense.CalculatePercentByAnotherValue(model.TotalIncom);
                model.TotalIncom_Percent = 100 - model.TotalExpense_Percent;

                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = model
                }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }

        public async Task<HttpResponseMessage> GetTransactions(string startDate, string endDate, decimal amount)
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }
                #region Convert Date

                DateTime StartDate = DateTime.Now.SystemTime().AddDays(-7);
                DateTime EndtDate = DateTime.Now.SystemTime().AddDays(7);
                try
                {
                    StartDate = DateTime.Parse(startDate).AddDays(-7);
                    EndtDate = DateTime.Parse(endDate).AddDays(7);
                }
                catch (Exception ex)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.BadRequest,
                        user_message = "invalid start or end date.",
                        developer_message = ex.ToString(),
                    }.ToHttpResponseMessage(this.Request);
                }
                #endregion

                var ListAccounts = await _plaidService.ListPlaidPublicTokens();
                foreach (var item in ListAccounts)
                {
                    var SiteSetting = (await new RepositoryBase<SettingEnt, byte>().GetAllAsync()).FirstOrDefault();
                    var _clientId = SiteSetting?.PlaidClientID ?? ""; ;
                    var _secrets = SiteSetting?.PlaidSecret ?? "";
                    var _env = Acklann.Plaid.Environment.Development;
                    var client = new PlaidClient(_clientId, _secrets, null, _env);
                    var model = await _plaidService.PlaidPublicTokenDetails(item.ID);
                    var ListAccount = await _plaidService.ListAccount(model.ID);

                    #region Add Transaction To DB
                    var result2 = await client.FetchTransactionsAsync(
                              new Acklann.Plaid.Transactions.GetTransactionsRequest()

                              {
                                  ClientId = _clientId,
                                  Secret = _secrets,
                                  AccessToken = model.AccessToken,
                                  StartDate = StartDate.AddDays(3),
                                  EndDate = EndtDate.AddDays(-3),
                              });

                    if (result2.Transactions == null)
                    {

                    }
                    else
                    {
                        var listExpense = _accountingService.ListAllExpenses();
                        foreach (var tr in result2.Transactions)
                        {
                            if (await _plaidService.IFExistTransactionId(tr.TransactionId))
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

                            var res = await _plaidService.AddPlaidTransaction(PlaidTransaction);

                        }
                    }
                    #endregion

                }

                var Transactions = await _plaidService.GetTransactionByPublicTokenIDFilterDate(0, StartDate, EndtDate, amount);
                var Transactionsmodel = Transactions.Select(x => new
                {
                    x.ID,
                    x.PlaidAccountID,
                    x.TransactionId,
                    x.Name,
                    x.Amount,
                    x.Date,
                    x.AddToExpense,
                    x.jsonData
                }).ToList();
                if (Transactionsmodel == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.InternalServerError,
                        user_message = "Error please try again later",
                        developer_message = "Cannot connect to database",
                    }.ToHttpResponseMessage(this.Request);
                }

                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = Transactionsmodel
                }.ToHttpResponseMessage(this.Request);


            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }



        public async Task<HttpResponseMessage> GetTransactionsPlaid(string startDate = "", string endDate = "", decimal amount = 0, int pageitemcount = 10, int pagenumber = 1)
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }
                #region Convert Date

                DateTime StartDate = DateTime.Now.SystemTime().AddYears(-1);
                DateTime EndtDate = DateTime.Now.SystemTime();
                try
                {
                    StartDate = string.IsNullOrEmpty(startDate) ? StartDate : DateTime.Parse(startDate);
                    EndtDate = string.IsNullOrEmpty(endDate) ? EndtDate : DateTime.Parse(endDate);
                }
                catch (Exception ex)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.BadRequest,
                        user_message = "invalid start or end date.",
                        developer_message = ex.ToString(),
                    }.ToHttpResponseMessage(this.Request);
                }
                #endregion
                var ListAccounts = await _plaidService.ListPlaidPublicTokens();
                foreach (var item in ListAccounts)
                {
                    var SiteSetting = (await new RepositoryBase<SettingEnt, byte>().GetAllAsync()).FirstOrDefault();
                    var _clientId = SiteSetting?.PlaidClientID ?? ""; ;
                    var _secrets = SiteSetting?.PlaidSecret ?? "";
                    var _env = Acklann.Plaid.Environment.Development;
                    var client = new PlaidClient(_clientId, _secrets, null, _env);
                    var modelPlaid = await _plaidService.PlaidPublicTokenDetails(item.ID);
                    var ListAccount = await _plaidService.ListAccount(modelPlaid.ID);

                    #region Add Transaction To DB
                    var result2 = await client.FetchTransactionsAsync(
                              new Acklann.Plaid.Transactions.GetTransactionsRequest()

                              {
                                  ClientId = _clientId,
                                  Secret = _secrets,
                                  AccessToken = modelPlaid.AccessToken,
                                  StartDate = StartDate.AddDays(3),
                                  EndDate = EndtDate.AddDays(-3),
                              });

                    if (result2.Transactions == null)
                    {

                    }
                    else
                    {
                        var listExpense = _accountingService.ListAllExpenses();
                        foreach (var tr in result2.Transactions)
                        {
                            if (await _plaidService.IFExistTransactionId(tr.TransactionId))
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

                            var res = await _plaidService.AddPlaidTransaction(PlaidTransaction);

                        }
                    }
                    #endregion

                }

                var Transactions = await _plaidService.GetTransactionByPublicTokenIDFilterDate(0, StartDate, EndtDate, amount);
                var model = new PlaidTransactionAppPagation()
                {
                    modelCount = Transactions.Count(),
                    pagecount = (Transactions.Count() + pageitemcount - 1) / pageitemcount,

                };
                if (pagenumber != 0)
                    Transactions = Transactions.Skip((pagenumber - 1) * pageitemcount).Take(pageitemcount).ToList();

                model.model = Transactions.Select(x => new
                {
                    x.ID,
                    x.PlaidAccountID,
                    x.TransactionId,
                    x.Name,
                    x.Amount,
                    x.Date,
                    x.AddToExpense,
                    x.jsonData
                }).ToList();

                if (model.model == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.InternalServerError,
                        user_message = "Error please try again later",
                        developer_message = "Cannot connect to database",
                    }.ToHttpResponseMessage(this.Request);
                }


                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = model,
                }.ToHttpResponseMessage(this.Request);


            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }
        public async Task<HttpResponseMessage> GetPaymentTypes()
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }
                var modelList = _accountingService.ListPaymentTypes();
                if (modelList == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.InternalServerError,
                        user_message = "Error please try again later",
                        developer_message = "Cannot connect to database",
                    }.ToHttpResponseMessage(this.Request);
                }

                var resultModel = modelList.Select(x => new
                {
                    x.ID,
                    x.Title,
                }).ToList();
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = resultModel
                }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }

        public async Task<HttpResponseMessage> GetExpenseTypes()
        {
            try
            {

                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }
                var modelList = _accountingService.ListExpenseType();
                if (modelList == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.InternalServerError,
                        user_message = "Error please try again later",
                        developer_message = "Cannot connect to database",
                    }.ToHttpResponseMessage(this.Request);
                }

                var resultModel = modelList.Select(x => new
                {
                    x.ID,
                    x.Title,
                    x.Description
                }).ToList();
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = resultModel
                }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }

        public async Task<HttpResponseMessage> GetPayAccounts()
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }

                var modelList = _accountingService.ListPayAccounts();
                if (modelList == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.InternalServerError,
                        user_message = "Error please try again later",
                        developer_message = "Cannot connect to database",
                    }.ToHttpResponseMessage(this.Request);
                }

                var resultModel = modelList.Select(x => new
                {
                    x.ID,
                    x.Title,
                    x.Description
                }).ToList();
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = resultModel
                }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }

        public async Task<HttpResponseMessage> GetExpenses(string userid = "", string startDate = "", string endDate = "", double amount = 0, int pageitemcount = 10, int pagenumber = 1)
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }

                var modelList = _accountingService.ListExpenses();
                if (modelList == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.InternalServerError,
                        user_message = "Error please try again later",
                        developer_message = "Cannot connect to database",
                    }.ToHttpResponseMessage(this.Request);
                }


                #region Convert Date

                DateTime StartDate = DateTime.Now.SystemTime();
                DateTime EndtDate = DateTime.Now.SystemTime();
                try
                {
                    StartDate = DateTime.Parse(startDate);
                    EndtDate = DateTime.Parse(endDate);
                }
                catch (Exception ex)
                {
                }
                #endregion

                var modelappList = new List<ExpenseAppViewModel>();

                if (userid != "")
                    modelList = modelList.Where(p => p.UserId == userid).ToList();
                if (startDate != "")
                    modelList = modelList.Where(p => p.Date.Date >= StartDate.Date).ToList();
                if (endDate != "")
                    modelList = modelList.Where(p => p.Date.Date <= EndtDate.Date).ToList();
                if (amount != 0)
                    modelList = modelList.Where(p => p.Amount == amount).ToList();

                var model = new ExpenseAppPagation()
                {
                    modelCount = modelList.Count(),
                    pagecount = (modelList.Count() + pageitemcount - 1) / pageitemcount,
                };

                if (pagenumber != 0)
                    modelList = modelList.Skip((pagenumber - 1) * pageitemcount).Take(pageitemcount).ToList();


                var userManager = new IdentityManager(new ApplicationDbContext())._userManager;
                foreach (var item in modelList)
                {
                    var modelapp = await MapExpenseToExoenseApp(item);
                    var userSaved = await userManager.FindByIdAsync(item.UserId); ;
                    if (userSaved != null) modelapp.UserFullName = userSaved.FirstName;
                    modelappList.Add(modelapp);
                }


                model.model = modelappList;
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = model
                }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }

        private async Task<ExpenseAppViewModel> MapExpenseToExoenseApp(ExpenseEnt item)
        {


            var app = new ExpenseAppViewModel()
            {
                ID = item.ID,
                Amount = item.Amount.ToPrice(2).Replace(",", ""),
                Attachment = "https://start.glassma.us/" + item.Attachment,
                Category = item.Category,
                Date = item.Date.ToString("d"),
                CheckInfo = item.CheckInfo,
                Description = item.Description,
                TransactionId = item.TransactionId,
                PaymentType = item.PaymentType,
                Vandor = item.Vandor,
                PONumber = item.FactorID != null ? item.Factor.PONumber.ToString() : "",
                ExpenseProduct = item.ExpenseProduct,
                TransactionType = item.TransactionType,
                PayAccount = item.PayAccount,
                SubCategory = item.ExpenseType,
                CardNumber = item.CardNumber,
                PaymentReference = item.PaymentReference,

            };
            var transaction = await _plaidService.GetTransactionByTransactionId(item.TransactionId);
            var userManager = new IdentityManager(new ApplicationDbContext())._userManager;
            var AppUser = await userManager.FindByIdAsync(item.UserId);
            app.UserFullName = AppUser != null ? AppUser.FirstName : "";
            app.UserFullName = app.UserFullName.Trim(' ');
            app.UserFullName = app.UserFullName.Trim(' ');
            app.Title = transaction != null ? transaction.Name : "";
            app.Transaction = transaction;
            return app;

        }

        public async Task<HttpResponseMessage> GetExpenseDetails(int id)
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }

                var model = _accountingService.ExpenseDetails(id);
                if (model == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.InternalServerError,
                        user_message = "Error please try again later",
                        developer_message = "Cannot connect to database",
                    }.ToHttpResponseMessage(this.Request);
                }
                var userManager = new IdentityManager(new ApplicationDbContext())._userManager;
                var modelapp = await MapExpenseToExoenseApp(model);
                var userSaved = await userManager.FindByIdAsync(model.UserId); ;
                if (userSaved != null)
                    modelapp.UserFullName = userSaved.FirstName;
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = modelapp
                }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }

        public async Task<HttpResponseMessage> GetExpenseProduct()
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }

                var modelList = _accountingService.ListExpenseProducts();
                if (modelList == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.InternalServerError,
                        user_message = "Error please try again later",
                        developer_message = "Cannot connect to database",
                    }.ToHttpResponseMessage(this.Request);
                }
                var resultModel = modelList.Select(x => new
                {
                    x.ID,
                    x.Title,
                    x.Description
                }).ToList();
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = resultModel
                }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }
        public async Task<HttpResponseMessage> GetCategories()
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }

                var modelList = await _accountingService.ListCategoriesAsync();
                if (modelList == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.InternalServerError,
                        user_message = "Error please try again later",
                        developer_message = "Cannot connect to database",
                    }.ToHttpResponseMessage(this.Request);
                }

                var resultModel = modelList.Select(x => new
                {
                    x.ID,
                    x.Title,
                    x.Description
                }).ToList();
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = resultModel
                }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }

        public async Task<HttpResponseMessage> GetSubCategories(int? id = 0)
        {
            try
            {

                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }
                var modelList = _accountingService.ListExpenseType();
                if (id != 0)
                    modelList = modelList.Where(p => p.CategoryId == id).ToList();
                if (modelList == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.InternalServerError,
                        user_message = "Error please try again later",
                        developer_message = "Cannot connect to database",
                    }.ToHttpResponseMessage(this.Request);
                }

                var resultModel = modelList.Select(x => new
                {
                    x.ID,
                    x.Title,
                    x.CategoryId,
                    x.Description
                }).ToList();
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = resultModel
                }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }

        public async Task<HttpResponseMessage> GetVendors()
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }
                var modelList = _settingService.ListExdpenseVandor();
                if (modelList == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.InternalServerError,
                        user_message = "Error please try again later",
                        developer_message = "Cannot connect to database",
                    }.ToHttpResponseMessage(this.Request);
                }

                var resultModel = modelList.Select(x => new
                {
                    x.ID,
                    x.Name,
                    x.Email,
                    x.Phone,
                }).ToList();
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = resultModel
                }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }

        public async Task<HttpResponseMessage> GetProjects()
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }

                var modelList = await _factorService.ListFactorsAsync("", 0, false);
                if (modelList == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.InternalServerError,
                        user_message = "Error please try again later",
                        developer_message = "Cannot connect to database",
                    }.ToHttpResponseMessage(this.Request);
                }

                var resultModel = modelList.Select(x => new
                {
                    x.ID,
                    x.PONumber,
                }).ToList();
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.OK,
                    user_message = "Success",
                    results = resultModel
                }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }


        [HttpPost]
        public async Task<HttpResponseMessage> PostAddProduct([FromBody] TitleModel item)
        {
            try
            {

                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }

                var resDuplicate = await _accountingService.IFExistExpenseProductTitleAsync(item?.title);
                if (resDuplicate != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.Ambiguous,
                        user_message = resDuplicate,
                    }.ToHttpResponseMessage(this.Request);
                }

                var product = new ExpenseProductEnt()
                {
                    Title = item.title,
                };

                var res = await _accountingService.AddExpenseProductAsync(product);
                if (res)
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.OK,
                        user_message = "Added Successfully",
                        results = product
                    }.ToHttpResponseMessage(this.Request);
                else
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.NotAcceptable,
                        user_message = "Error to save. please try again.",
                    }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }

        }


        [HttpPost]
        public async Task<HttpResponseMessage> PostAddCategory([FromBody] TitleModel item)
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }
                var resDuplicate = await _accountingService.IFExistCategoryTitleAsync(item?.title);
                if (resDuplicate != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.Ambiguous,
                        user_message = resDuplicate,
                    }.ToHttpResponseMessage(this.Request);
                }

                var model = new CategoryEnt()
                {
                    Title = item.title,
                };
                var res = await _accountingService.AddCategoryAsync(model);
                if (res)
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.OK,
                        user_message = "Added Successfully",
                        results = model
                    }.ToHttpResponseMessage(this.Request);
                else
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.NotAcceptable,
                        user_message = "Error to save. please try again.",
                    }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }
        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostAddSubCategory([FromBody] TitleModel item)
        {
            try
            {


                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }
                var resDuplicate = await _accountingService.IFExistExpenseTypeTitleAsync(item?.title);
                if (resDuplicate != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.Ambiguous,
                        user_message = resDuplicate,
                    }.ToHttpResponseMessage(this.Request);
                }
                var model = new ExpenseTypeEnt()
                {
                    Title = item.title,
                    CategoryId = item.categotyId
                };
                var res = await _accountingService.AddExpenseTypeAsync(model);
                if (res)
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.OK,
                        user_message = "Added Successfully",
                        results = model
                    }.ToHttpResponseMessage(this.Request);
                else
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.NotAcceptable,
                        user_message = "Error to save. please try again.",
                    }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }

        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostAddPayAccount([FromBody] TitleModel item)
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }
                var resDuplicate = await _accountingService.IFExistPayAccountTitleAsync(item?.title);
                if (resDuplicate != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.Ambiguous,
                        user_message = resDuplicate,
                    }.ToHttpResponseMessage(this.Request);
                }
                var model = new PayAccountEnt()
                {
                    Title = item.title,

                };
                var res = await _accountingService.AddPayAccountAsync(model);
                if (res)
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.OK,
                        user_message = "Added Successfully",
                        results = model
                    }.ToHttpResponseMessage(this.Request);
                else
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.NotAcceptable,
                        user_message = "Error to save. please try again.",
                    }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }

        }
        [HttpPost]
        public async Task<HttpResponseMessage> PostAddVendor([FromBody] TitleModel item)
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }
                var resDuplicate = await _settingService.IFExistVandorNameAsync(item.title, VandorType.ExpenseVandor);
                if (resDuplicate != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.Ambiguous,
                        user_message = resDuplicate,
                    }.ToHttpResponseMessage(this.Request);
                }

                var model = new VandorEnt()
                {
                    Name = item.title,
                    Type = VandorType.ExpenseVandor
                };
                if (!string.IsNullOrEmpty(item.email))
                    model.Email = item.email;
                if (!string.IsNullOrEmpty(item.phone))
                    model.Phone = item.phone;
                var res = await _settingService.AddVandorAsync(model);
                if (res == "success")
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.OK,
                        user_message = "Added Successfully",
                        results = model
                    }.ToHttpResponseMessage(this.Request);
                else
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.NotAcceptable,
                        user_message = "Error to save. please try again.",
                        developer_message = res,
                    }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }

        }

        [HttpPost]
        public async Task<HttpResponseMessage> PostAddExpenseFile(int id = 0)
        {
            int step = 0;
            try
            {
                //  !Request.Content.IsMimeMultipartContent()
                step++;
                var model = _accountingService.ExpenseDetails(id);
                if (model == null)
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.NotFound,
                        user_message = "Expense not found",

                    }.ToHttpResponseMessage(this.Request);
                }


                var file = HttpContext.Current.Request.Files.Count > 0 ?

                        HttpContext.Current.Request.Files[0] : null;
                step++;
                if (file != null && file.ContentLength > 0)
                {
                    step++;
                    var fileName = Path.GetFileName(file.FileName);
                    step++;
                    var path = HttpContext.Current.Server.MapPath("~") + $"Content\\Files\\ExpenseFile\\" + fileName;
                    file.SaveAs(path);
                    step++;
                    model.Attachment = file != null ? "/Content/Files/ExpenseFile/" + file.FileName : null;

                }



                var res = await _accountingService.EditExpenseAsync(model);
                if (res == "success")
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.OK,
                        user_message = "Saved Successfully",
                        results = model
                    }.ToHttpResponseMessage(this.Request);
                else
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.NotAcceptable,
                        user_message = "Error to save file. please try again.",
                    }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString() + "step:" + step.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }

        }
        [HttpPost]
        public async Task<HttpResponseMessage> PostAddExpense([FromBody] ExpenseEnt item)
        {
            try
            {
                var resToken = TokenCheck(Request.Headers);
                if (resToken != "success")
                {
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.GatewayTimeout,
                        user_message = resToken,
                    }.ToHttpResponseMessage(this.Request);
                }


                if (item.CategoryID == 0)
                {
                    return new ApiJsonResult() { code = HttpStatusCode.Ambiguous, user_message = "Please select payment type", }.ToHttpResponseMessage(this.Request);
                }

                if (item.PaymentTypeID == 0)
                {
                    return new ApiJsonResult() { code = HttpStatusCode.Ambiguous, user_message = "Please select payment type", }.ToHttpResponseMessage(this.Request);
                }


                var model = Mapper.DynamicMap<ExpenseEnt>(item);

                if (!string.IsNullOrEmpty(item.DateStr)) model.Date = DateTime.Parse(item.DateStr);
                model.FactorID = model.FactorID == 0 ? null : model.FactorID;
                model.VandorId = model.VandorId == 0 ? null : model.VandorId;
                model.PayAccountID = model.PayAccountID == 0 ? null : model.PayAccountID;
                model.ExpenseProductID = model.ExpenseProductID == 0 ? null : model.ExpenseProductID;
                model.ExpenseTypeID = model.ExpenseTypeID == 0 ? null : model.ExpenseTypeID;
                if (model.ID != 0)
                {
                    var OldExpense = await _accountingService.ExpenseDetailsAsync(model.ID);
                    model.Attachment = OldExpense.Attachment;
                }

                var res = model.ID == 0 ? await _accountingService.AddExpenseAsync(model) :
                                        await _accountingService.EditExpenseAsync(model);
                if (res == "success")
                {
                 await   _plaidService.PlaidTransactionAddToExpense(model.TransactionId);
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.OK,
                        user_message = "Saved Successfully",
                        results = model
                    }.ToHttpResponseMessage(this.Request);
                }
                else
                    return new ApiJsonResult()
                    {
                        code = HttpStatusCode.NotAcceptable,
                        user_message = "Error to save. please try again.",
                        developer_message = res,
                    }.ToHttpResponseMessage(this.Request);
            }
            catch (Exception ex)
            {
                return new ApiJsonResult()
                {
                    code = HttpStatusCode.ExpectationFailed,
                    user_message = "Error please try again later.",
                    developer_message = ex.ToString(),
                }.ToHttpResponseMessage(this.Request);
            }

        }

        private List<string> UploadFileAsync(HttpRequestBase httpRequest, string ponumber, string folder = "AttachmentFile")
        {

            List<string> Result = new List<string>();
            //  var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {


                foreach (string file in httpRequest.Files)
                {

                    var postedFile = httpRequest.Files[file];

                    var fileName = ponumber + "-" + new Random().Next(1, 100).ToString() + ".jpg";
                    //    var filePath = HttpContext.Current.Server.MapPath("~/Content/Files/AttachmentFile/" + fileName);
                    var filePath = HttpContext.Current.Server.MapPath("~") + $"Content\\Files\\{folder}\\" + fileName;

                    string contentType = postedFile?.ContentType ?? ""; contentType = contentType.ToLower();

                    postedFile.SaveAs(filePath);

                    WebImage webimg = new WebImage(filePath);
                    if (webimg.Width > 1000)
                        webimg.Resize(1000, 1000);

                    webimg.Save(filePath);

                    Result.Add($"/Content/Files/{folder}/" + fileName);

                }
            }

            return Result;
        }

        private string TokenCheck(HttpRequestHeaders headers)
        {
            try
            {
                var Token = headers.Contains("token") ? headers.GetValues("token").First() : "";
                if (string.IsNullOrEmpty(Token))
                { return "Invalid token"; }
                var UserList = new ApplicationDbContext().Users.ToList();
                var tokenExit = UserList.Any(p => p.BotToken == Token & p.ExpireDate > DateTime.Now.SystemTime());

                if (tokenExit)
                    return "success";
                else
                    return "Invalid token";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }
    }
}
