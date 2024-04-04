using Infrastructure.Entity;
using Infrastructure.Entity.newAdded;
using Infrastructure.Repository;
using Infrastructure.Service.Implement;
using Infrastructure.Service.Interface;
using Interface.Data;
using Interface.Models.Access;
using Interface.Models.Middleware;
using Interface.Repository;
using Interface.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Filters;
using Wangkanai.Extensions;
using static Stimulsoft.Report.StiOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));

builder.Services.AddSession();

builder.Services.AddDbContext<ProjectDBContext>(options =>
{
    options.UseSqlServer(connectionString);
});

//newAdded
builder.Services.AddDbContext<newAddedDBContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;

    options.Password.RequireDigit = true;
    options.Password.RequiredUniqueChars = 2;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
})

    .AddEntityFrameworkStores<ApplicationDbContext>()
     .AddDefaultUI()
.AddDefaultTokenProviders();

builder.Services.AddDetection();

builder.Services.AddScoped<IRazorViewToStringRenderer, RazorViewToStringRenderer>();
// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//builder.Services.AddScoped<IAuthorizationFilter>();
//builder.Services.AddScoped<CustomAuthorizeFilter>();
builder.Services.AddScoped<IMailSender, MailSender>();
builder.Services.AddScoped<IAccess, Access>();
//builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddHttpContextAccessor();

#region Rep & Services

builder.Services.AddScoped<IRepositoryBase<LogEnt, long>, RepositoryBase<LogEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<MsgNotificationEnt, long>, RepositoryBase<MsgNotificationEnt, long>>();
builder.Services.AddScoped<ILogService, LogService>();
//////-------------------------------------------------------------------------------------------------------------

builder.Services.AddScoped<IRepositoryBase<SettingEnt, byte>, RepositoryBase<SettingEnt, byte>>();
builder.Services.AddScoped<IRepositoryBase<EmailSettingEnt, byte>, RepositoryBase<EmailSettingEnt, byte>>();
builder.Services.AddScoped<IRepositoryBase<VandorEnt, int>, RepositoryBase<VandorEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<ShippingEnt, int>, RepositoryBase<ShippingEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<PageViewStatisticsEnt, long>, RepositoryBase<PageViewStatisticsEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<StatusNotificationEnt, int>, RepositoryBase<StatusNotificationEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<EmailNotificationEnt, long>, RepositoryBase<EmailNotificationEnt, long>>();
builder.Services.AddScoped<ISettingService, SettingService>();
////-------------------------------------------------------------------------------------------------------------
builder.Services.AddScoped<IRepositoryBase<GlassTypeEnt, int>, RepositoryBase<GlassTypeEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<GlassStrengthEnt, int>, RepositoryBase<GlassStrengthEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<GlassThicknesEnt, int>, RepositoryBase<GlassThicknesEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<Glass_FabricationEnt, int>, RepositoryBase<Glass_FabricationEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<FabricationEnt, int>, RepositoryBase<FabricationEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<GlassOptionEnt, int>, RepositoryBase<GlassOptionEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<GlassPriceEnt, int>, RepositoryBase<GlassPriceEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<FabricationPriceEnt, int>, RepositoryBase<FabricationPriceEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<GlassExtraPriceEnt, int>, RepositoryBase<GlassExtraPriceEnt, int>>();

builder.Services.AddScoped<IRepositoryBase<GlassType_OptionEnt, int>, RepositoryBase<GlassType_OptionEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<GlassType_StrengthEnt, int>, RepositoryBase<GlassType_StrengthEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<GlassType_ThicknesEnt, int>, RepositoryBase<GlassType_ThicknesEnt, int>>();

builder.Services.AddScoped<IRepositoryBase<FabricationCategoryEnt, int>, RepositoryBase<FabricationCategoryEnt, int>>();

builder.Services.AddScoped<IPriceService, PriceService>();
//////-------------------------------------------------------------------------------------------------------------

//////-------------------------------------------------------------------------------------------------------------
//newAdded
builder.Services.AddScoped<IRepositoryBase<newGlassType, int>, RepositoryBase<newGlassType, int>>();
builder.Services.AddScoped<IRepositoryBase<newFrameType, int>, RepositoryBase<newFrameType, int>>();
builder.Services.AddScoped<InewAddedService, newAddedService>();
//////-------------------------------------------------------------------------------------------------------------

builder.Services.AddScoped<IRepositoryBase<ProviderEnt, int>, RepositoryBase<ProviderEnt, int>>();
builder.Services.AddScoped<ICommericalService, CommericalService>();
//////-------------------------------------------------------------------------------------------------------------
builder.Services.AddScoped<IRepositoryBase<JobTypeEnt, int>, RepositoryBase<JobTypeEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<CustomerEnt, int>, RepositoryBase<CustomerEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<UserJobTypeEnt, int>, RepositoryBase<UserJobTypeEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<FactorJobTypeEnt, int>, RepositoryBase<FactorJobTypeEnt, int>>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
//////-------------------------------------------------------------------------------------------------------------
builder.Services.AddScoped<IRepositoryBase<ProductCategoryEnt, int>, RepositoryBase<ProductCategoryEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<ProductEnt, int>, RepositoryBase<ProductEnt, int>>();
builder.Services.AddScoped<IProductService, ProductService>();
////-------------------------------------------------------------------------------------------------------------

builder.Services.AddScoped<IRepositoryBase<CustomerOrderToEnt, int>, RepositoryBase<CustomerOrderToEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<Factor_ItemEnt, long>, RepositoryBase<Factor_ItemEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<FactorItem_ImageEnt, long>, RepositoryBase<FactorItem_ImageEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<FactorNoteEnt, long>, RepositoryBase<FactorNoteEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<FactorEnt, int>, RepositoryBase<FactorEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<FactorInstallerEnt, int>, RepositoryBase<FactorInstallerEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<ItemEnt, long>, RepositoryBase<ItemEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<ItemModifireEnt, long>, RepositoryBase<ItemModifireEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<Item_ItemModifireEnt, long>, RepositoryBase<Item_ItemModifireEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<ItemCategoryEnt, int>, RepositoryBase<ItemCategoryEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<ItemModifireAnswerEnt, long>, RepositoryBase<ItemModifireAnswerEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<CustomerRequestEnt, int>, RepositoryBase<CustomerRequestEnt, int>>();

builder.Services.AddScoped<IRepositoryBase<CustomerRequest_ItemEnt, int>, RepositoryBase<CustomerRequest_ItemEnt, int>>();

builder.Services.AddScoped<IRepositoryBase<LastActivityEnt, long>, RepositoryBase<LastActivityEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<LaborCostEnt, int>, RepositoryBase<LaborCostEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<FactorTaskEnt, long>, RepositoryBase<FactorTaskEnt, long>>();

////-------------------------------------------------------------------------------------------------------------

builder.Services.AddScoped<IRepositoryBase<WorkSchedulingEnt, long>, RepositoryBase<WorkSchedulingEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<RequestEstimateAppointmentEnt, long>, RepositoryBase<RequestEstimateAppointmentEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<EstimateAppointmentEnt, long>, RepositoryBase<EstimateAppointmentEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<InstallerAppointmentEnt, long>, RepositoryBase<InstallerAppointmentEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<RequestInstallerAppointmentEnt, long>, RepositoryBase<RequestInstallerAppointmentEnt, long>>();

builder.Services.AddScoped<IRepositoryBase<TaskEnt, long>, RepositoryBase<TaskEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<EmployeeRating, long>, RepositoryBase<EmployeeRating, long>>();
builder.Services.AddScoped<IRepositoryBase<FactorItemTimeEnt, long>, RepositoryBase<FactorItemTimeEnt, long>>();

builder.Services.AddScoped<ICalendarService, CalendarService>();

builder.Services.AddScoped<IRepositoryBase<ToolsEnt, long>, RepositoryBase<ToolsEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<OrderEnt, long>, RepositoryBase<OrderEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<OrderNoteEnt, long>, RepositoryBase<OrderNoteEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<PaymentEnt, long>, RepositoryBase<PaymentEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<SubmitSignEnt, long>, RepositoryBase<SubmitSignEnt, long>>();
builder.Services.AddScoped<IOrderService, OrderService>();

//////-------------------------------------------------------------------------------------------------------------

#region Cites

builder.Services.AddScoped<IRepositoryBase<CityEnt, int>, RepositoryBase<CityEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<StateEnt, int>, RepositoryBase<StateEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<ResellerPermitEnt, long>, RepositoryBase<ResellerPermitEnt, long>>();

builder.Services.AddScoped<ICityService, CityService>();

#endregion Cites

builder.Services.AddScoped<IRepositoryBase<ReportEmailEnt, long>, RepositoryBase<ReportEmailEnt, long>>();

builder.Services.AddScoped<IReportService, ReportService>();

//////-------------------------------------------------------------------------------------------------------------
builder.Services.AddScoped<IRepositoryBase<AccessLevelEnt, long>, RepositoryBase<AccessLevelEnt, long>>();

builder.Services.AddScoped<IAccessLevelService, AccessLevelService>();
////-------------------------------------------------------------------------------------------------------------
builder.Services.AddScoped<IRepositoryBase<HelpEnt, int>, RepositoryBase<HelpEnt, int>>();

builder.Services.AddScoped<IHelpService, HelpService>();

builder.Services.AddScoped<IRepositoryBase<PlaidPublicTokenEnt, int>, RepositoryBase<PlaidPublicTokenEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<PlaidAccountEnt, int>, RepositoryBase<PlaidAccountEnt, int>>();

builder.Services.AddScoped<IRepositoryBase<PlaidTransactionEnt, long>, RepositoryBase<PlaidTransactionEnt, long>>();
builder.Services.AddScoped<IPlaidService, PlaidService>();
//////-------------------------------------------------------------------------------------------------------------
builder.Services.AddScoped<IRepositoryBase<ExpenseEnt, long>, RepositoryBase<ExpenseEnt, long>>();
builder.Services.AddScoped<IRepositoryBase<ExpenseTypeEnt, int>, RepositoryBase<ExpenseTypeEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<CategoryEnt, int>, RepositoryBase<CategoryEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<PayAccountEnt, int>, RepositoryBase<PayAccountEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<PaymentTypeEnt, int>, RepositoryBase<PaymentTypeEnt, int>>();
builder.Services.AddScoped<IRepositoryBase<ExpenseProductEnt, int>, RepositoryBase<ExpenseProductEnt, int>>();

builder.Services.AddScoped<IAccountingService, AccountingService>();

//////-------------------------------------------------------------------------------------------------------------
builder.Services.AddScoped<IRepositoryBase<PublicChatEnt, long>, RepositoryBase<PublicChatEnt, long>>();

builder.Services.AddScoped<IPublicChatService, PublicChatService>();

//////-------------------------------------------------------------------------------------------------------------

builder.Services.AddScoped<IRepositoryBase<TimeCardEnt, long>, RepositoryBase<TimeCardEnt, long>>();

builder.Services.AddScoped<ITimeCardService, TimeCardService>();

builder.Services.AddScoped<IRepositoryBase<RolePermisionEnt, int>, RepositoryBase<RolePermisionEnt, int>>();
builder.Services.AddScoped<IRolePermisionService, RolePermisionService>();

builder.Services.AddScoped<IFactorService, FactorService>();

#endregion Rep & Services

https://www.coreprogramm.com/2021/09/lowercase-json-property-names-in-aspnet-core.html
builder.Services.AddControllersWithViews()
         .AddNewtonsoftJson(options =>
         {
             options.SerializerSettings.ContractResolver = new DefaultContractResolver();
         });

builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});
builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/login");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseSession();
app.UseDetection();
app.UseRouting();

app.UseAuthorization();

//app.UseMiddleware<IdentityFullNameMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=newAdded}/{action=Index}/{id?}");

app.MapControllerRoute(
        name: "ActionApi",
        pattern: "api/{controller}/{action}/{id}",
        defaults: new { id = RouteParameter.Optional });

app.MapRazorPages();

app.Run();