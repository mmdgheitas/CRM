using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface ISettingService
    {

        string DefaultWebsiteName();

        SettingEnt DefaultSetting();
        Task<SettingEnt> DefaultSettingAsync();
        SettingEnt DefaultSettingBase();
        Task<SettingEnt> DefaultSettingBaseAsync();
        bool UpdateSetting(SettingEnt item);
        bool AddSetting(SettingEnt item);



        bool UseEmailService();

        int LoginTimeOut();
        Task<bool> UseEmailServiceAsync();
        EmailSettingEnt DefaultEmailSetting();
        Task<EmailSettingEnt> DefaultEmailSettingAsync();
        bool AddEmailSetting(EmailSettingEnt item);
        bool UpdateEmailSetting(EmailSettingEnt item);
        bool DeleteAllEmailSettingExceptDefault();

        string DefaultReciverEmail();
        Task<string> DefaultReciverEmailAsync();

        string WebsitePhoneNumber();
        string GetWebsiteLogo();
        string GetTermOfUse();
        int GetBreakTime();
        Task<int> GetBreakTimeASync();
        List<VandorEnt> ListExdpenseVandor();
        List<VandorEnt> ListVandor();
        Task<List<VandorEnt>> ListVandorAsync(VandorType type);
        Task<List<VandorEnt>> ListVandorAsync();
        Task<List<VandorEnt>> ListAllVandorAsync();
        bool DeleteVandor(int id);
        VandorEnt VandorDetails(int id);
        bool IFExistVandorName(string name, VandorType type, int iD);
        Task<string> IFExistVandorNameAsync(string name, VandorType type, int iD = 0);
        bool AddVandor(VandorEnt model);
        Task<string> AddVandorAsync(VandorEnt model);

        bool EditVandor(VandorEnt model);
        List<ShippingEnt> ListShipping();
        Task<List<ShippingEnt>> ListShippingAsync();
        bool DeleteShipping(int id);
        ShippingEnt ShippingDetails(int id);
        bool IFExistShippingName(string name, int id = 0);
        bool AddShipping(ShippingEnt model);
        bool EditShipping(ShippingEnt model);

        string StripePublishKey();
        Task<string> StripePublishKeyAsync();
        string StripePrivateKey();
       Task< string> StripePrivateKeyAsync();
        List<StatusNotificationEnt> ListStatus();
        bool DeleteStatus(int id);
        StatusNotificationEnt StatusDetails(int id);
        bool AddStatus(StatusNotificationEnt model);
        bool EditStatus(StatusNotificationEnt model);
        bool IfExistStatus(FactorStatus status, int id = 0);
        Task<bool> AddPageViewStatistic(PageViewStatisticsEnt pageView);
        Task<List<PageViewStatisticsViewModel>> ListPageViewOfFactorAsync(int factorId, string privateID);
     Task<List<PageViewStatisticsViewModel>> ListPageSeenAsync();

        List<PageViewStatisticsViewModel> ListPageViewOfFactor(int factorId, string privateID);
        Task<List<PageViewStatisticsViewModel>> ListTabViewsNumberAsync();
        Task<List<PageViewStatisticsViewModel>> ListPageViewsNumberAsync();
        Task<List<PageViewStatisticsViewModel>> ListPageViewsByPageName(string name);
        Task<StatusNotificationEnt> GetNotificationAsync(FactorStatus estimation);
        StatusNotificationEnt GetNotification(FactorStatus estimation);
        Task<bool> AddEmailNotification(EmailNotificationEnt emailNotificationEnt);
    }
}
