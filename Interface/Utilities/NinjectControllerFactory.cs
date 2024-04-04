using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Implement;
using Infrastructure.Service.Interface;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Interface
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBinding();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBinding()
        {
            ninjectKernel.Bind<IRepositoryBase<SettingEnt, byte>>().To<Repository.RepositoryBase<SettingEnt, byte>>();
            ninjectKernel.Bind<IRepositoryBase<EmailSettingEnt, byte>>().To<Repository.RepositoryBase<EmailSettingEnt, byte>>();
            ninjectKernel.Bind<IRepositoryBase<VandorEnt, int>>().To<Repository.RepositoryBase<VandorEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<ShippingEnt, int>>().To<Repository.RepositoryBase<ShippingEnt, int>>();

            ninjectKernel.Bind<IRepositoryBase<CustomerOrderToEnt, int>>().To<Repository.RepositoryBase<CustomerOrderToEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<JobTypeEnt, int>>().To<Repository.RepositoryBase<JobTypeEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<StatusNotificationEnt, int>>().To<Repository.RepositoryBase<StatusNotificationEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<EmailNotificationEnt, long>>().To<Repository.RepositoryBase<EmailNotificationEnt, long>>();
            ninjectKernel.Bind<ISettingService>().To<SettingService>();
            //-------------------------------------------------------------------------------------------------------------

            ninjectKernel.Bind<IRepositoryBase<LogEnt, long>>().To<Repository.RepositoryBase<LogEnt, long>>();
            ninjectKernel.Bind<ILogService>().To<LogService>();
            //-------------------------------------------------------------------------------------------------------------
            ninjectKernel.Bind<IRepositoryBase<CustomerEnt, int>>().To<Repository.RepositoryBase<CustomerEnt, int>>();
            ninjectKernel.Bind<ICustomerService>().To<CustomerService>();
            //-------------------------------------------------------------------------------------------------------------
            ninjectKernel.Bind<IRepositoryBase<ProductCategoryEnt, int>>().To<Repository.RepositoryBase<ProductCategoryEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<ProductEnt, int>>().To<Repository.RepositoryBase<ProductEnt, int>>();
            ninjectKernel.Bind<IProductService>().To<ProductService>();
            //-------------------------------------------------------------------------------------------------------------
            ninjectKernel.Bind<IRepositoryBase<Factor_ItemEnt, long>>().To<Repository.RepositoryBase<Factor_ItemEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<FactorItem_ImageEnt, long>>().To<Repository.RepositoryBase<FactorItem_ImageEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<FactorEnt, int>>().To<Repository.RepositoryBase<FactorEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<FactorTaskEnt, long>>().To<Repository.RepositoryBase<FactorTaskEnt, long>>();

            ninjectKernel.Bind<IRepositoryBase<ItemEnt, long>>().To<Repository.RepositoryBase<ItemEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<ItemModifireEnt, long>>().To<Repository.RepositoryBase<ItemModifireEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<Item_ItemModifireEnt, long>>().To<Repository.RepositoryBase<Item_ItemModifireEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<ItemCategoryEnt, int>>().To<Repository.RepositoryBase<ItemCategoryEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<ItemModifireAnswerEnt, long>>().To<Repository.RepositoryBase<ItemModifireAnswerEnt, long>>();
            ninjectKernel.Bind<IFactorService>().To<FactorService>();

            //-------------------------------------------------------------------------------------------------------------



            ninjectKernel.Bind<IRepositoryBase<WorkSchedulingEnt, long>>().To<Repository.RepositoryBase<WorkSchedulingEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<RequestEstimateAppointmentEnt, long>>().To<Repository.RepositoryBase<RequestEstimateAppointmentEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<EstimateAppointmentEnt, long>>().To<Repository.RepositoryBase<EstimateAppointmentEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<InstallerAppointmentEnt, long>>().To<Repository.RepositoryBase<InstallerAppointmentEnt, long>>();

            ninjectKernel.Bind<IRepositoryBase<RequestInstallerAppointmentEnt, long>>().To<Repository.RepositoryBase<RequestInstallerAppointmentEnt, long>>();
            ninjectKernel.Bind<ICalendarService>().To<CalendarService>();

            ninjectKernel.Bind<IRepositoryBase<SubmitSignEnt, long>>().To<Repository.RepositoryBase<SubmitSignEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<ToolsEnt, long>>().To<Repository.RepositoryBase<ToolsEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<OrderEnt, long>>().To<Repository.RepositoryBase<OrderEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<OrderNoteEnt, long>>().To<Repository.RepositoryBase<OrderNoteEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<PaymentEnt, long>>().To<Repository.RepositoryBase<PaymentEnt, long>>();
    
            ninjectKernel.Bind<IOrderService>().To<OrderService>();

            //-------------------------------------------------------------------------------------------------------------

            #region Cites
            ninjectKernel.Bind<IRepositoryBase<CityEnt, int>>().To<Repository.RepositoryBase<CityEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<StateEnt, int>>().To<Repository.RepositoryBase<StateEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<ResellerPermitEnt, long>>().To<Repository.RepositoryBase<ResellerPermitEnt, long>>();

            ninjectKernel.Bind<ICityService>().To<CityService>();
            #endregion

            ninjectKernel.Bind<IRepositoryBase<ReportEmailEnt, long>>().To<Repository.RepositoryBase<ReportEmailEnt, long>>();

            ninjectKernel.Bind<IReportService>().To<ReportService>();

            //-------------------------------------------------------------------------------------------------------------
            ninjectKernel.Bind<IRepositoryBase<AccessLevelEnt, long>>().To<Repository.RepositoryBase<AccessLevelEnt, long>>();

            ninjectKernel.Bind<IAccessLevelService>().To<AccessLevelService>();
            //-------------------------------------------------------------------------------------------------------------
            ninjectKernel.Bind<IRepositoryBase<HelpEnt, int>>().To<Repository.RepositoryBase<HelpEnt, int>>();

            ninjectKernel.Bind<IHelpService>().To<HelpService>();

            //-------------------------------------------------------------------------------------------------------------
            ninjectKernel.Bind<IRepositoryBase<PlaidPublicTokenEnt, int>>().To<Repository.RepositoryBase<PlaidPublicTokenEnt, int>>();
           ninjectKernel.Bind<IRepositoryBase<PlaidAccountEnt, int>>().To<Repository.RepositoryBase<PlaidAccountEnt, int>>();

            ninjectKernel.Bind<IRepositoryBase<PlaidTransactionEnt, long>>().To<Repository.RepositoryBase<PlaidTransactionEnt, long>>();
            ninjectKernel.Bind<IPlaidService>().To<PlaidService>();

            //-------------------------------------------------------------------------------------------------------------
            ninjectKernel.Bind<IRepositoryBase<PublicChatEnt, long>>().To<Repository.RepositoryBase<PublicChatEnt, long>>();

            ninjectKernel.Bind<IPublicChatService>().To<PublicChatService>();


            //-------------------------------------------------------------------------------------------------------------
            ninjectKernel.Bind<IRepositoryBase<ExpenseEnt, long>>().To<Repository.RepositoryBase<ExpenseEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<ExpenseTypeEnt, int>>().To<Repository.RepositoryBase<ExpenseTypeEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<CategoryEnt, int>>().To<Repository.RepositoryBase<CategoryEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<PayAccountEnt, int>>().To<Repository.RepositoryBase<PayAccountEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<PaymentTypeEnt, int>>().To<Repository.RepositoryBase<PaymentTypeEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<ExpenseProductEnt, int>>().To<Repository.RepositoryBase<ExpenseProductEnt, int>>();

            ninjectKernel.Bind<IAccountingService>().To<AccountingService>();

            //-------------------------------------------------------------------------------------------------------------

            ninjectKernel.Bind<IRepositoryBase<TimeCardEnt, long>>().To<Repository.RepositoryBase<TimeCardEnt, long>>();

            ninjectKernel.Bind<ITimeCardService>().To<TimeCardService>();
          
            #region SMS
            ninjectKernel.Bind<IRepositoryBase<SMSAccountEnt, short>>().To<Repository.RepositoryBase<SMSAccountEnt, short>>();
            ninjectKernel.Bind<IRepositoryBase<SMSGroupEnt, int>>().To<Repository.RepositoryBase<SMSGroupEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<SMSContactEnt, long>>().To<Repository.RepositoryBase<SMSContactEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<Group_ContactEnt, long>>().To<Repository.RepositoryBase<Group_ContactEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<SMSGroupNoNameEnt, int>>().To<Repository.RepositoryBase<SMSGroupNoNameEnt, int>>();
            ninjectKernel.Bind<IRepositoryBase<SendSMSEnt, long>>().To<Repository.RepositoryBase<SendSMSEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<SendSMSGroupEnt, long>>().To<Repository.RepositoryBase<SendSMSGroupEnt, long>>();
            ninjectKernel.Bind<IRepositoryBase<SMSDraftEnt, int>>().To<Repository.RepositoryBase<SMSDraftEnt, int>>();
            ninjectKernel.Bind<ISMSService>().To<SMSService>();
            #endregion



            #region RolePermision
            ninjectKernel.Bind<IRepositoryBase<RolePermisionEnt, int>>().To<Repository.RepositoryBase<RolePermisionEnt, int>>();
            ninjectKernel.Bind<IRolePermisionService>().To<RolePermisionService>();
            #endregion



        }

    }
}