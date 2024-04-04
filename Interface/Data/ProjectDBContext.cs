
using Infrastructure.Entity;
using Infrastructure.Repository;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace Interface.Data
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext(DbContextOptions<ProjectDBContext> options)
               : base(options)
        {

        }
        //------------------


        #region Cities
        public DbSet<CityEnt> Cities { get; set; }
        public DbSet<StateEnt> States { get; set; }
        public DbSet<ResellerPermitEnt> ResellerPermits { get; set; }
        #endregion

        #region Order
        public DbSet<OrderEnt> Orders { get; set; }
        public DbSet<ToolsEnt> Tools { get; set; }
        public DbSet<PaymentEnt> Payments { get; set; }
        public DbSet<SubmitSignEnt> SubmitSigns { get; set; }
        public DbSet<OrderNoteEnt> OrderNotes { get; set; }
        #endregion

        #region Setting Entities
        public DbSet<SettingEnt> Setting { get; set; }
        public DbSet<EmailSettingEnt> EmailSetting { get; set; }
        public DbSet<VandorEnt> Vandor { get; set; }
        public DbSet<ShippingEnt> Shipping { get; set; }
        public DbSet<CustomerOrderToEnt> OrderTo { get; set; }
        public DbSet<StatusNotificationEnt> StatusNotifications { get; set; }
        public DbSet<EmailNotificationEnt> EmailNotification { get; set; }
        public DbSet<PageViewStatisticsEnt> PageViewStatistics { get; set; }
        #endregion

        #region Help
        public DbSet<HelpEnt> Helps { get; set; }
        #endregion

        #region Plaid
        public DbSet<PlaidAccountEnt> PlaidAccounts { get; set; }

        public DbSet<PlaidTransactionEnt> PlaidTransactions { get; set; }
        public DbSet<PlaidPublicTokenEnt> PlaidPublicTokens { get; set; }
        #endregion




        #region Public Chat
        public DbSet<PublicChatEnt> PublicChats { get; set; }
        #endregion

        #region Expenses
        public DbSet<ExpenseEnt> Expenses { get; set; }
        public DbSet<ExpenseTypeEnt> ExpenseTypes { get; set; }
        public DbSet<CategoryEnt> Categories { get; set; }
        public DbSet<ExpenseProductEnt> ExpenseProducts { get; set; }
        public DbSet<PayAccountEnt> PayAccounts { get; set; }
        public DbSet<PaymentTypeEnt> PaymentTypes { get; set; }

        #endregion

        #region TimeCard
        public DbSet<TimeCardEnt> TimeCards { get; set; }
        #endregion

        #region Calendar
        public DbSet<WorkSchedulingEnt> WorkSchedulings { get; set; }
        public DbSet<RequestEstimateAppointmentEnt> RequestEstimateAppointments { get; set; }
        public DbSet<RequestInstallerAppointmentEnt> RequestInstallerAppointments { get; set; }

        public DbSet<EstimateAppointmentEnt> EstimateAppointments { get; set; }
        public DbSet<InstallerAppointmentEnt> InstallAppointments { get; set; }
        public DbSet<TaskEnt> Tasks { get; set; }
        public DbSet<EmployeeRating> EmployeeRating { get; set; }
        public DbSet<FactorItemTimeEnt> factorItemTimes { get; set; }
        #endregion

        #region Customer
        public DbSet<CustomerEnt> Customers { get; set; }
        public DbSet<JobTypeEnt> JobTypes { get; set; }
        public DbSet<UserJobTypeEnt> UserJobTypes { get; set; }
        public DbSet<FactorJobTypeEnt> FactorJobTypes { get; set; }
        #endregion


        #region Product
        public DbSet<ProductEnt> Products { get; set; }
        public DbSet<ProductCategoryEnt> ProductCategories { get; set; }
        #endregion

        #region Factor
        public DbSet<FactorEnt> Factors { get; set; }
        public DbSet<Factor_ItemEnt> Factor_Items { get; set; }
        public DbSet<CustomerRequestEnt> CustomerRequests { get; set; }
        public DbSet<CustomerRequest_ItemEnt> CustomerRequestItem { get; set; }
        public DbSet<FactorItem_ImageEnt> FactorItem_Images { get; set; }
        public DbSet<ItemEnt> items { get; set; }
        public DbSet<Item_ItemModifireEnt> Item_ItemModifires { get; set; }
        public DbSet<ItemModifireAnswerEnt> itemModifireAnswerRepo { get; set; }
        public DbSet<ItemModifireEnt> itemModifiress { get; set; }
        public DbSet<ItemCategoryEnt> ItemCategories { get; set; }
        public DbSet<FactorNoteEnt> FactorNsote { get; set; }
        public DbSet<FactorInstallerEnt> FactorInstaller { get; set; }
        public DbSet<LastActivityEnt> LastActivities { get; set; }
        public DbSet<LaborCostEnt> LaborCosts { get; set; }
        public DbSet<FactorTaskEnt> FactorTasks { get; set; }
        #endregion


        #region RolePermision
        public DbSet<RolePermisionEnt> RolePermision { get; set; }

        #endregion

        #region Report
        public DbSet<ReportEmailEnt> ReportEmail { get; set; }
        #endregion

        #region AccessLevel
        public DbSet<AccessLevelEnt> UserSetting { get; set; }

        #endregion

        #region Commerical
        public DbSet<ProviderEnt> Provider { get; set; }

        #endregion


        #region Logs
        public DbSet<MsgNotificationEnt> MsgNotifications { get; set; }
        public DbSet<LogEnt> Logs { get; set; }
        #endregion



        #region Price
        public DbSet<GlassTypeEnt> GlassTypes { get; set; }
        public DbSet<FabricationCategoryEnt> FabricationCategories { get; set; }
        public DbSet<Glass_FabricationEnt> Glass_Fabrications { get; set; }
        public DbSet<FabricationEnt> Fabrications { get; set; }
        public DbSet<GlassThicknesEnt> GlassThicknes { get; set; }
        public DbSet<GlassStrengthEnt> GlassStrengths { get; set; }
        public DbSet<GlassOptionEnt> GlassOptions { get; set; }
        public DbSet<GlassPriceEnt> GlassPrices { get; set; }
        public DbSet<FabricationPriceEnt> FabricationPrices { get; set; }
        public DbSet<GlassExtraPriceEnt> GlassExtraPrice { get; set; }

        public DbSet<GlassType_OptionEnt> GlassType_Options { get; set; }
        public DbSet<GlassType_StrengthEnt> GlassType_Strengths { get; set; }
        public DbSet<GlassType_ThicknesEnt> GlassType_Thickness { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
            //-----Change Table's Name

            //     modelBuilder.Entity<ApplicationUser>().ToTable("Users", "dbo");

            #region Setting
            modelBuilder.Entity<SettingEnt>().ToTable("Setting", "dbo");
            modelBuilder.Entity<EmailSettingEnt>().ToTable("EmailSetting", "dbo");
            modelBuilder.Entity<VandorEnt>().ToTable("Vandors", "dbo");
            modelBuilder.Entity<ShippingEnt>().ToTable("Shipping", "dbo");
            modelBuilder.Entity<CustomerOrderToEnt>().ToTable("CustomerOrderTo", "dbo");
            modelBuilder.Entity<StatusNotificationEnt>().ToTable("StatusNotifications", "dbo");
            modelBuilder.Entity<EmailNotificationEnt>().ToTable("EmailNotification", "dbo");
            modelBuilder.Entity<PageViewStatisticsEnt>().ToTable("PageViewStatistics", "dbo");
            #endregion

            #region Help
            modelBuilder.Entity<HelpEnt>().ToTable("Helps");
            #endregion


            #region Plaid
            modelBuilder.Entity<PlaidPublicTokenEnt>().ToTable("PlaidPublicTokens");
            modelBuilder.Entity<PlaidTransactionEnt>().ToTable("PlaidTransactions");
            modelBuilder.Entity<PlaidAccountEnt>().ToTable("PlaidAccounts");
            #endregion




            #region Expenses
            modelBuilder.Entity<ExpenseEnt>().ToTable("Expenses");
            modelBuilder.Entity<ExpenseTypeEnt>().ToTable("ExpenseTypes");
            modelBuilder.Entity<PayAccountEnt>().ToTable("PayAccounts");
            modelBuilder.Entity<CategoryEnt>().ToTable("Categories");
            modelBuilder.Entity<ExpenseProductEnt>().ToTable("ExpenseProducts");
            modelBuilder.Entity<PaymentTypeEnt>().ToTable("PaymentTypes");
            #endregion


            #region Help
            modelBuilder.Entity<TimeCardEnt>().ToTable("TimeCards");
            #endregion



            #region Public Chat
            modelBuilder.Entity<PublicChatEnt>().ToTable("PublicChats");
            #endregion

            #region Calendar
            modelBuilder.Entity<WorkSchedulingEnt>().ToTable("WorkSchedulings");
            modelBuilder.Entity<RequestEstimateAppointmentEnt>().ToTable("RequestEstimateAppointments");
            modelBuilder.Entity<RequestInstallerAppointmentEnt>().ToTable("RequestInstallerAppointments");
            modelBuilder.Entity<EstimateAppointmentEnt>().ToTable("EstimateAppointments");
            modelBuilder.Entity<InstallerAppointmentEnt>().ToTable("InstallerAppointments");
            modelBuilder.Entity<TaskEnt>().ToTable("Tasks");
            modelBuilder.Entity<EmployeeRating>().ToTable("EmployeeRating");
            modelBuilder.Entity<FactorItemTimeEnt>().ToTable("FactorItemTimes");
            #endregion

            #region Customer
            modelBuilder.Entity<CustomerEnt>().ToTable("Customers");
            modelBuilder.Entity<JobTypeEnt>().ToTable("JobTypes", "dbo");
            modelBuilder.Entity<UserJobTypeEnt>().ToTable("UserJobTypes");
            modelBuilder.Entity<FactorJobTypeEnt>().ToTable("FactorJobTypes");
            #endregion

            #region Product
            modelBuilder.Entity<ProductEnt>().ToTable("Products");
            modelBuilder.Entity<ProductCategoryEnt>().ToTable("ProductCategories");
            #endregion

            #region Order
            modelBuilder.Entity<OrderEnt>().ToTable("Orders");
            modelBuilder.Entity<ToolsEnt>().ToTable("Tools");
            modelBuilder.Entity<PaymentEnt>().ToTable("Payments");
            modelBuilder.Entity<SubmitSignEnt>().ToTable("SubmitSigns");
            modelBuilder.Entity<OrderNoteEnt>().ToTable("OrderNotes");
            #endregion

            #region Factor
            modelBuilder.Entity<FactorEnt>().ToTable("Factors");
            modelBuilder.Entity<Factor_ItemEnt>().ToTable("Factor_Items");
            modelBuilder.Entity<CustomerRequestEnt>().ToTable("CustomerRequests");
            modelBuilder.Entity<CustomerRequest_ItemEnt>().ToTable("CustomerRequest_Items");
            modelBuilder.Entity<FactorItem_ImageEnt>().ToTable("FactorItem_Images");
            modelBuilder.Entity<ItemEnt>().ToTable("Items");
            modelBuilder.Entity<ItemModifireEnt>().ToTable("ItemModofires");
            modelBuilder.Entity<Item_ItemModifireEnt>().ToTable("Item_ItemModifire");
            modelBuilder.Entity<ItemCategoryEnt>().ToTable("ItemCategories");
            modelBuilder.Entity<ItemModifireAnswerEnt>().ToTable("ItemModifireAnswers");
            modelBuilder.Entity<FactorNoteEnt>().ToTable("FactorNotes");
            modelBuilder.Entity<FactorInstallerEnt>().ToTable("FactorInstaller");
            modelBuilder.Entity<LastActivityEnt>().ToTable("LastActivities");
            modelBuilder.Entity<LaborCostEnt>().ToTable("LaborCosts");
            modelBuilder.Entity<FactorTaskEnt>().ToTable("FactorTasks");
            #endregion

            #region Report
            modelBuilder.Entity<ReportEmailEnt>().ToTable("ReportEmail", "dbo");
            #endregion

            #region    AccessLevel
            modelBuilder.Entity<AccessLevelEnt>().ToTable("UserSetting", "dbo");

            #endregion

            #region RolePermision
            modelBuilder.Entity<RolePermisionEnt>().ToTable("RolePermisions", "dbo");
            #endregion

            #region City
            modelBuilder.Entity<CityEnt>().ToTable("Cities", "dbo");
            modelBuilder.Entity<StateEnt>().ToTable("States", "dbo");
            modelBuilder.Entity<ResellerPermitEnt>().ToTable("ResellerPermits", "dbo");
            #endregion

            #region Commerical
            modelBuilder.Entity<ProviderEnt>().ToTable("Providers", "dbo");
            #endregion

            #region Logs
            modelBuilder.Entity<MsgNotificationEnt>().ToTable("MsgNotifications", "dbo");
            modelBuilder.Entity<LogEnt>().ToTable("Logs");

            #endregion

            #region Glass Price
            modelBuilder.Entity<GlassTypeEnt>().ToTable("GlassTypes", "dbo");
            modelBuilder.Entity<FabricationEnt>().ToTable("Fabrications", "dbo");
            modelBuilder.Entity<Glass_FabricationEnt>().ToTable("Glass_Fabrications", "dbo");
            modelBuilder.Entity<FabricationCategoryEnt>().ToTable("FabricationCategories", "dbo");
            modelBuilder.Entity<GlassThicknesEnt>().ToTable("GlassThicknes", "dbo");
            modelBuilder.Entity<GlassStrengthEnt>().ToTable("GlassStrengths", "dbo");
            modelBuilder.Entity<GlassOptionEnt>().ToTable("GlassOptions", "dbo");
            modelBuilder.Entity<GlassPriceEnt>().ToTable("GlassPrices", "dbo");
            modelBuilder.Entity<FabricationPriceEnt>().ToTable("FabricationPrices", "dbo");
            modelBuilder.Entity<GlassExtraPriceEnt>().ToTable("GlassExtraPrices", "dbo");


            modelBuilder.Entity<GlassType_OptionEnt>().ToTable("GlassType_Option", "dbo");
            modelBuilder.Entity<GlassType_ThicknesEnt>().ToTable("GlassType_Thicknes", "dbo");
            modelBuilder.Entity<GlassType_StrengthEnt>().ToTable("GlassType_Strength", "dbo");
            #endregion

            //#region SMS
            //modelBuilder.Entity<SMSAccountEnt>().ToTable("SMSAccount", "dbo");
            //modelBuilder.Entity<SMSContactEnt>().ToTable("SMSContacts", "dbo");
            //modelBuilder.Entity<SMSGroupEnt>().ToTable("SMSGroups", "dbo");
            //modelBuilder.Entity<Group_ContactEnt>().ToTable("Group_Contact", "dbo");
            //modelBuilder.Entity<SMSGroupNoNameEnt>().ToTable("SMSGroupNoNames", "dbo");
            //modelBuilder.Entity<SendSMSEnt>().ToTable("SendSMS", "dbo");
            //modelBuilder.Entity<SendSMSGroupEnt>().ToTable("SendSMSGroup", "dbo");
            //#endregion




        }
    }
}