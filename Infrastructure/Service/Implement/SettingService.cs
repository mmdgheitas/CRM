using AutoMapper;
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
    public class SettingService : ISettingService
    {

        IRepositoryBase<SettingEnt, byte> _settingRepo;
        IRepositoryBase<EmailSettingEnt, byte> _EmailsettingRepo;
        IRepositoryBase<VandorEnt, int> _vandorRepo;
        IRepositoryBase<ShippingEnt, int> _shippingRepo;
        IRepositoryBase<CustomerOrderToEnt, int> _orderToRepo;
        IRepositoryBase<PageViewStatisticsEnt, long> _pageViewStatisticRepo;

        IRepositoryBase<StatusNotificationEnt, int> _statusRepo;
        IRepositoryBase<EmailNotificationEnt, long> _EmailNotificationRepo;
        private readonly IMapper _mapper;
        public SettingService(IRepositoryBase<VandorEnt, int> vandorRepo,
                IRepositoryBase<ShippingEnt, int> shippingRepo,
                IRepositoryBase<StatusNotificationEnt, int> statusNotification,
                IRepositoryBase<EmailNotificationEnt, long> _emailNotification,
                IRepositoryBase<PageViewStatisticsEnt, long> pageViewStatisticRepo,
                IRepositoryBase<SettingEnt, byte> _settingRepo,
                IRepositoryBase<EmailSettingEnt, byte> _EmailsettingRepo,
                IRepositoryBase<CustomerOrderToEnt, int> _orderToRepo,
               IMapper mapper
                )
        {
            _mapper = mapper;
            this._shippingRepo = shippingRepo;
            this._vandorRepo = vandorRepo;

            this._statusRepo = statusNotification;
            this._pageViewStatisticRepo = pageViewStatisticRepo;
            this._EmailNotificationRepo = _emailNotification;
            this._settingRepo = _settingRepo;
            this._EmailsettingRepo = _EmailsettingRepo;
            this._orderToRepo = _orderToRepo;
          
        }
        //public SettingService(IRepositoryBase<VandorEnt, int> vandorRepo,
        //    IRepositoryBase<ShippingEnt, int> shippingRepo,
        //    IRepositoryBase<StatusNotificationEnt, int> statusNotification,
        //    IRepositoryBase<EmailNotificationEnt, long> _emailNotification,
        //    IRepositoryBase<PageViewStatisticsEnt, long> pageViewStatisticRepo
        //    )
        //{
        //    this._shippingRepo = shippingRepo;
        //    this._vandorRepo = vandorRepo;

        //    this._statusRepo = statusNotification;
        //    this._pageViewStatisticRepo = pageViewStatisticRepo;
        //    this._EmailNotificationRepo = _emailNotification;
        //}

        //public SettingService(IRepositoryBase<CustomerOrderToEnt, int> orderToRepo)
        //{
        //    this._orderToRepo = orderToRepo;
        //}
        //public SettingService(IRepositoryBase<SettingEnt, byte> _settingRepo)
        //{
        //    this._settingRepo = _settingRepo;
        //}

        //public SettingService(IRepositoryBase<SettingEnt, byte> _settingRepo, IRepositoryBase<EmailSettingEnt, byte> _EmailsettingRepo)
        //{
        //    this._settingRepo = _settingRepo;
        //    this._EmailsettingRepo = _EmailsettingRepo;
        //}
        //public SettingService(IRepositoryBase<SettingEnt, byte> _settingRepo, IRepositoryBase<EmailSettingEnt, byte> _EmailsettingRepo, IRepositoryBase<PageViewStatisticsEnt, long> pageViewStatisticRepo)
        //{
        //    this._settingRepo = _settingRepo;
        //    this._EmailsettingRepo = _EmailsettingRepo;
        //    this._pageViewStatisticRepo = pageViewStatisticRepo;
        //}

        //public SettingService(IRepositoryBase<SettingEnt, byte> _settingRepo, IRepositoryBase<EmailSettingEnt, byte> _EmailsettingRepo, IRepositoryBase<VandorEnt, int> _vandorRepo)
        //{
        //    this._settingRepo = _settingRepo;
        //    this._EmailsettingRepo = _EmailsettingRepo;
        //    this._vandorRepo = _vandorRepo;
        //}
        //public SettingService(IRepositoryBase<SettingEnt, byte> _settingRepo, IRepositoryBase<EmailSettingEnt, byte> _EmailsettingRepo, IRepositoryBase<VandorEnt, int> _vandorRepo, IRepositoryBase<PageViewStatisticsEnt, long> _pageViewStatistic)
        //{
        //    this._settingRepo = _settingRepo;
        //    this._EmailsettingRepo = _EmailsettingRepo;
        //    this._vandorRepo = _vandorRepo;
        //    this._pageViewStatisticRepo = _pageViewStatistic;
        //}
        //public SettingService(IRepositoryBase<EmailSettingEnt, byte> _EmailsettingRepo)
        //{
        //    this._EmailsettingRepo = _EmailsettingRepo;
        //}
        //public SettingService(IRepositoryBase<EmailSettingEnt, byte> _EmailsettingRepo, IRepositoryBase<StatusNotificationEnt, int> _statusRepo)
        //{
        //    this._EmailsettingRepo = _EmailsettingRepo;
        //    this._statusRepo = _statusRepo;
        //}

        public string DefaultWebsiteName()
        {
            try
            {
                var libName = _settingRepo.GetAll().FirstOrDefault().DefaultWebSiteName;
                if (libName == "")
                    return "User Panel System";
                else
                    return libName;

            }
            catch (Exception ex)
            {

                return "‌User Panel System";
            }
        }

        public bool AddSetting(SettingEnt item)
        {
            try
            {
                return _settingRepo.Insert(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public bool UpdateSetting(SettingEnt item)
        {
            try
            {
                return _settingRepo.Update(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string DefaultReciverEmail()
        {
            try
            {
                return _EmailsettingRepo.GetAll().FirstOrDefault().ReciverEmail;
            }
            catch (Exception ex)
            {
                return "--";

            }
        }
        public async Task<string> DefaultReciverEmailAsync()
        {
            try
            {
                return (await _EmailsettingRepo.GetAllAsync().FirstOrDefaultAsync()).ReciverEmail;
            }
            catch (Exception ex)
            {
                return "--";

            }
        }
        public bool UseEmailService()
        {
            try
            {
                return _EmailsettingRepo.GetAll().FirstOrDefault().UseEmailService;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public async Task<bool> UseEmailServiceAsync()
        {
            try
            {
                return (await _EmailsettingRepo.GetAllAsync().FirstOrDefaultAsync()).UseEmailService;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public EmailSettingEnt DefaultEmailSetting()
        {
            try
            {
                return _EmailsettingRepo.GetAll().FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<EmailSettingEnt> DefaultEmailSettingAsync()
        {
            try
            {
                return await _EmailsettingRepo.GetAllAsync().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool AddEmailSetting(EmailSettingEnt item)
        {
            try
            {
                return _EmailsettingRepo.Insert(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateEmailSetting(EmailSettingEnt item)
        {
            try
            {
                return _EmailsettingRepo.Update(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool DeleteAllEmailSettingExceptDefault()//حذف همه رکورد ها بغیر  از اولی
        {
            try
            {
                var ListModel = _EmailsettingRepo.GetAll().ToList();
                if (ListModel.Count > 1)//اگر بزگرتر از یک بود خذفشون کن
                {
                    var Default = ListModel.FirstOrDefault();
                    foreach (var item in ListModel)
                    {
                        if (item.ID != Default.ID)//اولی را حذف نکن
                            _EmailsettingRepo.Delete(item.ID);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public SettingEnt DefaultSetting()
        {
            try
            {
                var def = _settingRepo.GetAll().FirstOrDefault();

                if (def == null) DefaultSettingBase();

                return def;

            }
            catch (Exception ex)
            {
                return DefaultSettingBase();
            }
        }
        public SettingEnt DefaultSettingBase()
        {
            var setting = new SettingEnt();
            setting.DefaultWebSiteName = "Admin Panel";

            return setting;
        }



        public async Task<SettingEnt> DefaultSettingAsync()
        {
            try
            {
                var def = await _settingRepo.GetAllAsync().FirstOrDefaultAsync();

                if (def == null) def = await DefaultSettingBaseAsync();

                return def;

            }
            catch (Exception ex)
            {
                return await DefaultSettingBaseAsync();
            }
        }
        public async Task<SettingEnt> DefaultSettingBaseAsync()
        {
            var setting = new SettingEnt();
            setting.DefaultWebSiteName = "Admin Panel";

            return setting;
        }




        public bool UseEmailService(int libraryID)
        {
            try
            {
                var email = _EmailsettingRepo.GetAll().FirstOrDefault();
                if (email.EmailAddress != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }



        public string WebsitePhoneNumber()
        {
            try
            {
                return _settingRepo.GetAll().FirstOrDefault().PhoneNumber;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetWebsiteLogo()
        {
            try
            {
                return _settingRepo.GetAll().FirstOrDefault().Logo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetTermOfUse()
        {
            try
            {
                return _settingRepo.GetAll().FirstOrDefault().Terms;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<VandorEnt> ListVandor()
        {
            try
            {
                return _vandorRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<VandorEnt>> ListVandorAsync()
        {
            try
            {
                return await _vandorRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<VandorEnt>> ListVandorAsync(VandorType type)
        {
            try
            {
                var list  = await _vandorRepo.GetAllAsync().ToListAsync();
                return list.Where(p => p.Type == type).OrderBy(p => p.Name).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<VandorEnt>> ListAllVandorAsync()
        {
            try
            {
                return await _vandorRepo.GetAllAsync().OrderBy(p => p.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<VandorEnt> ListExdpenseVandor()
        {
            try
            {
                return _vandorRepo.GetAll().Where(p => p.Type == VandorType.ExpenseVandor).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteVandor(int id)
        {
            try
            {
                return _vandorRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public VandorEnt VandorDetails(int id)
        {
            try
            {
                return _vandorRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IFExistVandorName(string name, VandorType type, int id = 0)
        {
            try
            {
                if (id == 0)
                    return _vandorRepo.GetAll().Any(p => p.Name == name & p.Type == type);
                else
                    return _vandorRepo.GetAll().Any(p => p.Name == name & p.ID != id & p.Type == type);

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<string> IFExistVandorNameAsync(string name, VandorType type, int id = 0)
        {
            try
            {
                if (string.IsNullOrEmpty(name)) return "The title is required";

                bool res = true;
                if (id == 0)
                    res = await _vandorRepo.GetAllAsync().AnyAsync(p => p.Name == name & p.Type == type);
                else
                    res = await _vandorRepo.GetAllAsync().AnyAsync(p => p.Name == name & p.ID != id & p.Type == type);
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

        public bool AddVandor(VandorEnt model)
        {
            try
            {
                return _vandorRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<string> AddVandorAsync(VandorEnt model)
        {
            try
            {
                return (await _vandorRepo.InsertAsync(model)) ? "success" : "Error to save";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public bool EditVandor(VandorEnt model)
        {
            try
            {
                return _vandorRepo.Update(model);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<ShippingEnt> ListShipping()
        {
            try
            {
                return _shippingRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<ShippingEnt>> ListShippingAsync()
        {
            try
            {
                return await _shippingRepo.GetAllAsync().OrderBy(p => p.Name).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteShipping(int id)
        {
            try
            {
                return _shippingRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ShippingEnt ShippingDetails(int id)
        {
            try
            {
                return _shippingRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IFExistShippingName(string name, int id = 0)
        {
            try
            {
                if (id == 0)
                    return _shippingRepo.GetAll().Any(p => p.Name == name);
                else
                    return _shippingRepo.GetAll().Any(p => p.Name == name & p.ID != id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddShipping(ShippingEnt model)
        {
            try
            {
                return _shippingRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditShipping(ShippingEnt model)
        {
            try
            {
                return _shippingRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public string StripePublishKey()
        {
            try
            {
                return _settingRepo.GetAll().FirstOrDefault().StripePublicKey;
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        public async Task<string> StripePublishKeyAsync()
        {
            try
            {
                return (await _settingRepo.GetAllAsync().FirstOrDefaultAsync()).StripePublicKey;
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        public string StripePrivateKey()
        {
            try
            {
                return _settingRepo.GetAll().FirstOrDefault().StripePrivateKey;
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        public async Task<string> StripePrivateKeyAsync()
        {
            try
            {
                return (await _settingRepo.GetAllAsync().FirstOrDefaultAsync()).StripePrivateKey;
            }
            catch (Exception ex)
            {
                return "";
            }
        }



        public List<StatusNotificationEnt> ListStatus()
        {
            try
            {
                return _statusRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteStatus(int id)
        {
            try
            {
                return _statusRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public StatusNotificationEnt StatusDetails(int id)
        {
            try
            {
                return _statusRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddStatus(StatusNotificationEnt model)
        {
            try
            {
                return _statusRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditStatus(StatusNotificationEnt model)
        {
            try
            {
                return _statusRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IfExistStatus(FactorStatus status, int id = 0)
        {
            try
            {
                if (id == 0)
                    return _statusRepo.GetAll().Any(p => p.status == status);
                else
                    return _statusRepo.GetAll().Any(p => p.status == status & p.ID != id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int GetBreakTime()
        {
            try
            {
                return _settingRepo.GetAll().FirstOrDefault().BreakTime;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public async Task<int> GetBreakTimeASync()
        {
            try
            {
                return (await _settingRepo.GetAllAsync().FirstOrDefaultAsync()).BreakTime;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<bool> AddPageViewStatistic(PageViewStatisticsEnt pageView)
        {
            try
            {
                return await _pageViewStatisticRepo.InsertAsync(pageView);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<List<PageViewStatisticsViewModel>> ListPageViewOfFactorAsync(int factorId, string privateID)
        {
            try
            {
                var listPageView =( await _pageViewStatisticRepo.GetAllAsync().ToListAsync()).Where(p => p.FullName != null ? p.FullName.Trim(' ') != "Omid Dehghani" : true).ToList();
                var listProjectView = listPageView.Where(p => p.PageID == privateID & p.PageName == "Project").ToList();
                var listJobPaymentView = listPageView.Where(p => p.PageID == privateID & p.PageName == "JobPayment").ToList();
                var listfactorView = listPageView.Where(p => p.PageID == factorId.ToString() & p.PageName == "Update").ToList();
                var listView = new List<PageViewStatisticsViewModel>();
                foreach (var item in listProjectView)
                {
                    listView.Add(new PageViewStatisticsViewModel()
                    {
                        Date = item.Date,
                        FullName = item.FullName,
                        IP = item.IP,
                        PageName = item.PageName,
                        PageTitle = "New Payment Page",
                        DateStr = item.Date.ToString("g"),
                    });
                }

                foreach (var item in listJobPaymentView)
                {
                    listView.Add(new PageViewStatisticsViewModel()
                    {
                        Date = item.Date,
                        FullName = item.FullName,
                        IP = item.IP,
                        PageName = item.PageName,
                        PageTitle = "Payment Page",
                        DateStr = item.Date.ToString("g"),
                    });
                }

                foreach (var item in listfactorView)
                {
                    listView.Add(new PageViewStatisticsViewModel()
                    {
                        Date = item.Date,
                        FullName = item.FullName,
                        IP = item.IP,
                        PageName = item.PageName,
                        PageTitle = "Project Page",
                        DateStr = item.Date.ToString("g"),
                    });
                }

                return listView.OrderByDescending(p => p.Date).ToList();

            }
            catch (Exception ex)
            {

                return new List<PageViewStatisticsViewModel>();
            }
        }
        public async Task<List<PageViewStatisticsViewModel>> ListPageSeenAsync()
        {
            try
            {
                var listPageView = (await _pageViewStatisticRepo.GetAllAsync().Where(p => string.IsNullOrEmpty(p.FullName) & p.PageName == "Project").ToListAsync());

                var listView = new List<PageViewStatisticsViewModel>();
                foreach (var item in listPageView)
                {
                    listView.Add(new PageViewStatisticsViewModel()
                    {
                        Date = item.Date,
                        FullName = item.FullName,
                        IP = item.IP,
                        PageName = item.PageName,
                        PageTitle = "New Payment Page",
                        DateStr = item.Date.ToString("g"),
                        PageID = item.PageID,
                    });
                }

                return listView.OrderByDescending(p => p.Date).ToList();

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<PageViewStatisticsViewModel> ListPageViewOfFactor(int factorId, string privateID)
        {
            try
            {
                var listPageView = _pageViewStatisticRepo.GetAll().Where(p => p.FullName != null ? p.FullName.Trim(' ') != "Omid Dehghani" : true).ToList(); ;
                var listProjectView = listPageView.Where(p => p.PageID == privateID & p.PageName == "Project").ToList();
                var listJobPaymentView = listPageView.Where(p => p.PageID == privateID & p.PageName == "JobPayment").ToList();
                var listfactorView = listPageView.Where(p => p.PageID == factorId.ToString() & p.PageName == "Update").ToList();
                var listView = new List<PageViewStatisticsViewModel>();
                foreach (var item in listProjectView)
                {
                    listView.Add(new PageViewStatisticsViewModel()
                    {
                        Date = item.Date,
                        FullName = item.FullName,
                        IP = item.IP,
                        PageName = item.PageName,
                        PageTitle = "New Payment Page",
                        DateStr = item.Date.ToString("g"),
                    });
                }

                foreach (var item in listJobPaymentView)
                {
                    listView.Add(new PageViewStatisticsViewModel()
                    {
                        Date = item.Date,
                        FullName = item.FullName,
                        IP = item.IP,
                        PageName = item.PageName,
                        PageTitle = "Payment Page",
                        DateStr = item.Date.ToString("g"),
                    });
                }

                foreach (var item in listfactorView)
                {
                    listView.Add(new PageViewStatisticsViewModel()
                    {
                        Date = item.Date,
                        FullName = item.FullName,
                        IP = item.IP,
                        PageName = item.PageName,
                        PageTitle = "Project Page",
                        DateStr = item.Date.ToString("g"),
                    });
                }

                return listView.OrderByDescending(p => p.Date).ToList();

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<PageViewStatisticsViewModel>> ListTabViewsNumberAsync()
        {
            try
            {
                var listPageView = await _pageViewStatisticRepo.GetAllAsync().Where(p => p.FullName != null ? p.FullName.Trim(' ') != "Omid Dehghani" : true).ToListAsync(); ;
                var listTabs = listPageView.Where(p => p.Type == PageViewType.HomeTabs).ToList();
                var tabs = _mapper.Map<List<PageViewStatisticsViewModel>>(listTabs.GroupBy(x => x.PageName).Select(x => x.First()).ToList());

                foreach (var item in tabs)
                {
                    item.Count = listTabs.Count(p => p.PageName == item.PageName);
                }

                return tabs.OrderByDescending(p => p.Count).ToList();
            }
            catch (Exception ex)
            {

                return new List<PageViewStatisticsViewModel>();
            }
        }

        public async Task<List<PageViewStatisticsViewModel>> ListPageViewsNumberAsync()
        {
            try
            {
                var listPageView = (await _pageViewStatisticRepo.GetAllAsync().Where(p => p.FullName != null ? p.FullName.Trim(' ') != "Omid Dehghani" : true).ToListAsync()); ;
                var listTabs = listPageView.ToList();
                var tabs = _mapper.Map<List<PageViewStatisticsViewModel>>(listTabs.GroupBy(x => x.PageName).Select(x => x.First()).ToList());

                foreach (var item in tabs)
                {
                    item.PageTitle = item.PageName.ToPageTitle();
                    item.Count = listTabs.Count(p => p.PageName == item.PageName);
                }

                return tabs.OrderByDescending(p => p.Type == PageViewType.HomeTabs).OrderByDescending(p => p.Count).ToList();
            }
            catch (Exception ex)
            {

                return new List<PageViewStatisticsViewModel>();
            }
        }

        public async Task<List<PageViewStatisticsViewModel>> ListPageViewsByPageName(string name)
        {
            try
            {
                var listPage = await _pageViewStatisticRepo.GetAllAsync().Where(p => p.FullName != null ? p.FullName.Trim(' ') != "Omid Dehghani" : true).Where(p => p.PageName == name || p.IP == name).ToListAsync();

                var listView = new List<PageViewStatisticsViewModel>();
                foreach (var item in listPage)
                {
                    listView.Add(new PageViewStatisticsViewModel()
                    {
                        Date = item.Date,
                        FullName = item.FullName,
                        IP = item.IP,
                        PageID = item.PageID,
                        PageName = item.PageName,
                        PageTitle = item.PageName.ToPageTitle(),
                        DateStr = item.Date.ToString("g"),
                    });
                }

                return listView.OrderByDescending(p => p.Date).ToList();

            }
            catch (Exception ex)
            {

                return new List<PageViewStatisticsViewModel>();
            }
        }

        public async Task<StatusNotificationEnt> GetNotificationAsync(FactorStatus status)
        {
            try
            {
                var all = await _statusRepo.GetAllAsync().ToListAsync();
                return all.FirstOrDefault(p => p.status == status);
            }
            catch (Exception ex)
            {
                return new StatusNotificationEnt();
            }
        }
        public StatusNotificationEnt GetNotification(FactorStatus status)
        {
            try
            {
                var all = _statusRepo.GetAll();
                return all.FirstOrDefault(p => p.status == status);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> AddEmailNotification(EmailNotificationEnt emailNotificationEnt)
        {
            try
            {
                return await _EmailNotificationRepo.InsertAsync(emailNotificationEnt);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public int LoginTimeOut()
        {
            try
            {
                return _settingRepo.GetAll().FirstOrDefault()?.LoginTimeout ?? 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
