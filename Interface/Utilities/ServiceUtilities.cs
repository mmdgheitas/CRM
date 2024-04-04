using Infrastructure.Entity;
using Interface.Data;
using Interface.Repository;
using Microsoft.AspNet.Identity;
using Stimulsoft.System.Web;
using System.Security.Principal;

namespace Interface.Utilities
{
    public class ServiceUtilities
    {
        public ServiceUtilities() { }

        public static byte GetPriorityOfFactorStatus(this FactorStatus sts)
        {
            try
            {
                var setting = new RepositoryBase<SettingEnt, byte>().GetAll().FirstOrDefault();
                switch (sts)
                {
                    case FactorStatus.PreEstimation:
                        return setting.ShowStatus0;
                    case FactorStatus.Estimation:
                        return setting.ShowStatus1;
                    case FactorStatus.Estimate_Sent:
                        return setting.ShowStatus2;
                    case FactorStatus.First_attempt_estimation:
                        return setting.ShowStatus3;
                    case FactorStatus.Secound_attempt_estimation:
                        return setting.ShowStatus4;
                    case FactorStatus.Schedule_Measuring:
                        return setting.ShowStatus5;

                    case FactorStatus.Measuring_Scheduled:
                        return setting.ShowStatus6;
                    case FactorStatus.Pricing:
                        return setting.ShowStatus7;
                    case FactorStatus.Pricing_updated:
                        return setting.ShowStatus8;
                    case FactorStatus.Quoted:
                        return setting.ShowStatus9;
                    case FactorStatus.First_attempt_question:
                        return setting.ShowStatus10;
                    case FactorStatus.Secound_attempt_question:
                        return setting.ShowStatus11;
                    case FactorStatus.Quote_Excepted:
                        return setting.ShowStatus12;
                    case FactorStatus.Waiting_for_deposit:
                        return setting.ShowStatus13;
                    case FactorStatus.Didnt_Received_Deposit:
                        return setting.ShowStatus14;
                    case FactorStatus.Recieved_deposit:
                        return setting.ShowStatus15;
                    case FactorStatus.Order_in_process:
                        return setting.ShowStatus16;
                    case FactorStatus.back_ordered:
                        return setting.ShowStatus17;
                    case FactorStatus.Delivered_in_house:
                        return setting.ShowStatus18;
                    case FactorStatus.installation_delivery_requested:
                        return setting.ShowStatus19;
                    case FactorStatus.installation_delivery_Scheduled:
                        return setting.ShowStatus20;
                    case FactorStatus.Out_for_delivery:
                        return setting.ShowStatus21;
                    case FactorStatus.Job_Delivered:
                        return setting.ShowStatus22;
                    case FactorStatus.Invoice_sent:
                        return setting.ShowStatus23;
                    case FactorStatus.waiting_for_payment:
                        return setting.ShowStatus24;
                    case FactorStatus.Paid_in_full:
                        return setting.ShowStatus25;
                    case FactorStatus.Request_Review:
                        return setting.ShowStatus26;

                    case FactorStatus.GetStart:
                        return setting.ShowStatus27;
                    case FactorStatus.StartProject:
                        return setting.ShowStatus28;
                    case FactorStatus.PauseProject:
                        return setting.ShowStatus29;
                    case FactorStatus.ContinueProject:
                        return setting.ShowStatus30;
                    case FactorStatus.Cancelled:
                        return setting.ShowStatus31;
                    case FactorStatus.Close:
                        return setting.ShowStatus32;
                    case FactorStatus.Suspended:
                        return setting.ShowStatus33;
                    case FactorStatus.OnlineOrder:
                        return setting.ShowStatus34;
                    case FactorStatus.Schedule_Measuring_Request:
                        return setting.ShowStatus35;
                    default:
                        return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public static string LastActvityTableName(this string tableName, string tableId)
        {
            try
            {
                switch (tableName)
                {
                    case "WorkScheduling":
                        return "Work Scheduling";
                    case "JobType":
                        return "Project Type";
                    case "StatusNotification":
                        return "Status Notification";
                    case "Shipping":
                        return "Shipping";
                    case "City":
                        return "Cities";
                    case "State":
                        return "States";
                    case "EmailSetting":
                        return "Email Service";
                    case "Setting":
                        return "System configure";
                    case "Factor":
                        return "Projects";
                    case "Factor_Item":
                        return "Project Item";
                    case "ItemModifireAnswer":
                        return "Project Item Answer";
                    case "FactorItem_Image":
                        return "Project Item Image";

                    case "CustomerRequest":
                        return "Customer Request";
                    case "ItemCategory":
                        return "Item Categories";
                    case "ItemModifire":
                        return "Item Modifires";
                    case "Item":
                        return "Item";
                    case "Item_ItemModifire":
                        return "Item";
                    case "PayAccount":
                        return "Pay Account";
                    case "PaymentType":
                        return "Payment Type";
                    case "ExpenseType":
                        return "Expense Type";
                    case "Category":
                        return "Category";
                    case "Expense":
                        return "Accounting";

                    case "Tools":
                        return "Tools";

                    case "Order":
                        return "Order";
                    case "OrderNote":
                        return "Order Notes";
                    case "Payment":
                        return "Payments";
                    case "TimeCard":
                        return "Time Card";

                    case "Users":
                        {
                            var appUser = new IdentityManager(new ApplicationDbContext())._userManager.FindById(tableId.Trim(' ').TrimEnd('-'));
                            if (appUser.UserType == UserType.Admin)
                                return "Admin Users";
                            else if (appUser.UserType == UserType.Estimator)
                                return "Estimator";
                            else if (appUser.UserType == UserType.Installer)
                                return "Installer";
                            else if (appUser.UserType == UserType.Installer_Estimator)
                                return "Employees";
                            else if (appUser.UserType == UserType.User)
                                return "Clients";
                            else
                                return "Clients";
                        }
                    default:
                        return tableName;
                }
            }
            catch
            {
                return tableName;
            }
        }
        public static string LastActvityURL(this string tableName, string tableId)
        {

            try
            {
                switch (tableName)
                {
                    case "WorkScheduling":
                        return "/Admin/WorkScheduling";

                    case "JobType":
                        return "/Base/JobTypes";
                    case "StatusNotification":
                        return "/Base/Status";
                    case "Shipping":
                        return "/Base/Shipping";
                    case "City":
                        return "/Base/Cities";
                    case "State":
                        return "/Base/State";
                    case "EmailSetting":
                        return "/Base/EmailSetting";
                    case "Setting":
                        return "/Base/Default";
                    case "Factor":
                        return "/Factor/Factors";


                    case "CustomerRequest":
                        return "/Item/CustomerRequest";
                    case "ItemCategory":
                        return "/Item/ItemCategories";
                    case "ItemModifire":
                        return "/Item/ItemModifires";
                    case "Item":
                        return "/Item/Items";
                    case "Item_ItemModifire":
                        return "/Item/Items";

                    case "PayAccount":
                        return "/Accounting/PayAccount";
                    case "ExpenseType":
                        return "/Accounting/ExpenseType";
                    case "PaymentType":
                        return "/Accounting/PaymentType";
                    case "Category":
                        return "/Accounting/Category";
                    case "Expense":
                        return "/Accounting/ExpenseType";

                    case "Tools":
                        return "/Factor/MyTools";

                    case "Order":
                        return "/Factor/Orders";
                    case "OrderNote":
                        return "/Factor/Orders";
                    case "Payment":
                        return "/Factor/Payments";
                    case "TimeCard":
                        return "/Time/MyTimeCards";
                    case "Factor_Item ":
                        {
                            var factorItem = new RepositoryBase<Factor_ItemEnt, long>().GetAll().FirstOrDefault(p => p.ID == tableId.ToInt());
                            return "/Factor/Update/" + factorItem.FacrorID;
                        }
                    case "Factor_Item":
                        {
                            var factorItem = new RepositoryBase<Factor_ItemEnt, long>().GetAll().FirstOrDefault(p => p.ID == tableId.ToInt());
                            return "/Factor/Update/" + factorItem.FacrorID;
                        }
                    case "ItemModifireAnswer":
                        {
                            var factorItemanswer = new RepositoryBase<ItemModifireAnswerEnt, long>().GetAll().FirstOrDefault(p => p.ID == tableId.ToInt());
                            var factorItem = new RepositoryBase<Factor_ItemEnt, long>().GetAll().FirstOrDefault(p => p.ID == factorItemanswer.Factor_ItemID);

                            return "/Factor/Update/" + factorItem.FacrorID;
                        }
                    case "FactorItem_Image":
                        {
                            var factorItemImage = new RepositoryBase<FactorItem_ImageEnt, long>().GetAll().FirstOrDefault(p => p.ID == tableId.ToInt());
                            return "/Factor/Update/" + factorItemImage.FactorID;
                        }
                    case "Users":
                        {
                            var appUser = new IdentityManager(new ApplicationDbContext())._userManager.FindById(tableId.Trim(' ').TrimEnd('-'));
                            if (appUser.UserType == UserType.Admin)
                                return "/Admin/Operator/";
                            else if (appUser.UserType == UserType.Estimator)
                                return "/Admin/Estimators";
                            else if (appUser.UserType == UserType.Installer)
                                return "/Admin/Installers";
                            else if (appUser.UserType == UserType.Installer_Estimator)
                                return "/Admin/OtherUsers";
                            else if (appUser.UserType == UserType.User)
                                return "/Admin/Users";
                            else
                                return "/Admin/Users";
                        }
                    default:
                        return "#";
                }
            }
            catch
            {
                return "#";
            }
        }


        public static int GetTaskCount(this IPrincipal user, bool UseSession = true)
        {
            try
            {


                if (user.Identity.IsAuthenticated)
                {
                    HttpCookie reqCookies = HttpContext.Current.Request.Cookies["TaskCount"];

                    if (reqCookies != null & UseSession)
                    {
                        if (!string.IsNullOrEmpty(reqCookies.Values["filed"]))
                        {
                            var count = reqCookies.Values["filed"].ToString();
                            return count.ToInt();
                        }
                        else
                        {
                            //Delete Cookies
                            var c = new HttpCookie("TaskCount");
                            c.Expires = DateTime.Now.AddDays(-1);
                            HttpContext.Current.Request.Cookies.Add(c);

                            return 0;
                        }


                    }
                    else
                    {
                        var factorTask = new RepositoryBase<FactorTaskEnt, long>().GetAll().Where(p => ((p.TaskType == FactorTaskType.Estimation || p.TaskType == FactorTaskType.Installation) ? p.StartDate.Date == DateTime.Now.SystemTime().Date : (p.StartDate.Date <= DateTime.Now.SystemTime().Date))).ToList();
                        var install = new RepositoryBase<InstallerAppointmentEnt, long>().GetAll().Where(p => p.AppointmentDate.Date == DateTime.Now.SystemTime().Date & !p.Disable).ToList();
                        var estimate = new RepositoryBase<EstimateAppointmentEnt, long>().GetAll().Where(p => p.AppointmentDate.Date == DateTime.Now.SystemTime().Date & !p.Disable).ToList();

                        //if (!user.IsInRole("TaskAdmin"))
                        //{
                        factorTask = factorTask.Where(p => p.EmployeeID == user.Identity.GetUserId()).ToList();
                        install = install.Where(p => p.InstallerID == user.Identity.GetUserId()).ToList();
                        estimate = estimate.Where(p => p.EstimatorID == user.Identity.GetUserId()).ToList();
                        // }

                        //Add Task count to cookie
                        var Taskcount = (factorTask.Count() + install.Count() + estimate.Count()).ToString();
                        if (HttpContext.Current.Request.Cookies["TaskCount"] == null)
                        {
                            HttpCookie TaskCookie = new HttpCookie("TaskCount");
                            TaskCookie.Values.Add("filed", Taskcount.ToString());
                            TaskCookie.Expires = DateTime.Now.AddHours(1);
                            HttpContext.Current.Response.Cookies.Add(TaskCookie);
                        }

                        return Taskcount.ToInt();
                    }


                }
                else
                {
                    //Delete Cookies
                    var c = new HttpCookie("TaskCount");
                    c.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Current.Request.Cookies.Add(c);
                    return 0;
                }

            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public static bool HasNewChatMessage(this string user)
        {
            try
            {


                user = user.Trim(' ').Trim(' ').Replace(' ', '_').ToLower();
                var listReadMessage = new RepositoryBase<PublicChatEnt, long>().GetAll().Where(p => (!string.IsNullOrEmpty(p.ReadMessage)));
                return listReadMessage.Any(p => p.ReadMessage.ToLower().Contains(user));
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public static string LibraryName(this IPrincipal user, int libId = 0)
        {
            try
            {
                var setting = new RepositoryBase<SettingEnt, byte>().GetAll().FirstOrDefault();
                return setting.DefaultWebSiteName;
            }
            catch (Exception ex)
            {
                return "سیستم پنل کاربری";
            }
        }





        public static bool IsConfirmPhoneNumber(this IPrincipal user)
        {
            try
            {
                var appUser = new IdentityManager(new ApplicationDbContext())._userManager.FindById(user.Identity.GetUserId());
                return appUser.PhoneNumberConfirmed;
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public static bool ShouldChangePassword(this IPrincipal user)
        {
            try
            {
                var appUser = new IdentityManager(new ApplicationDbContext())._userManager.FindById(user.Identity.GetUserId());
                var UserManager = new IdentityManager(new ApplicationDbContext())._userManager;
                if ((UserManager.PasswordHasher.VerifyHashedPassword(appUser.PasswordHash, "123456").ToString() == "Success"))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
