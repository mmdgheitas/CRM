using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Implement;
using Infrastructure.Service.Interface;


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

public static class Utility
{


    public static IEnumerable<TSource> DistinctBy<TSource, TKey>
        (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        HashSet<TKey> seenKeys = new HashSet<TKey>();
        foreach (TSource element in source)
        {
            if (seenKeys.Add(keySelector(element)))
            {
                yield return element;
            }
        }
    }


    public static T ToEnum<T>(this int value)
    {
        Type type = typeof(T);

        if (!type.IsEnum)
        {
            throw new ArgumentException($"{type} is not an enum.");

        }

        if (!type.IsEnumDefined(value))
        {
            throw new ArgumentException($"{value} is not a valid ordinal of type {type}.");
        }

        return (T)Enum.ToObject(type, value);
    }
    public static string ToFactorStatus(this FactorStatus sts)
    {
        try
        {
            switch (sts)
            {
                case FactorStatus.PreEstimation:
                    return "Pre Estimation";
                case FactorStatus.Estimation:
                    return "Estimation";
                case FactorStatus.Estimate_Sent:
                    return "Estimate Sent";
                case FactorStatus.First_attempt_estimation:
                    return "First Attempt Estimation";
                case FactorStatus.Secound_attempt_estimation:
                    return "Secound Attempt Estimation";
                case FactorStatus.Schedule_Measuring:
                    return "Schedule Measuring";
                case FactorStatus.Schedule_Measuring_Request:
                    return "Schedule Measuring Requested";
                case FactorStatus.Measuring_Scheduled:
                    return "Measuring Scheduled";
                case FactorStatus.Pricing:
                    return "Pricing";
                case FactorStatus.Pricing_updated:
                    return "Pricing Updated";
                case FactorStatus.Quoted:
                    return "Quoted";
                case FactorStatus.First_attempt_question:
                    return "First Attempt Question";
                case FactorStatus.Secound_attempt_question:
                    return "Secound Attempt Question";
                case FactorStatus.Quote_Excepted:
                    return "Quote Excepted";
                case FactorStatus.Waiting_for_deposit:
                    return "Waiting For Deposit";
                case FactorStatus.Didnt_Received_Deposit:
                    return "Didn't Received Deposit";
                case FactorStatus.Recieved_deposit:
                    return "Recieved Deposit";
                case FactorStatus.Order_in_process:
                    return "Order In Process";
                case FactorStatus.Order_Confirmation:
                    return "Order Confirmation";
                case FactorStatus.Order_Pending:
                    return "Order Pending";
                case FactorStatus.back_ordered:
                    return "Back Ordered";
                case FactorStatus.Delivered_in_house:
                    return "Delivered In House";
                case FactorStatus.installation_delivery_requested:
                    return "Install Delivery Requested";
                case FactorStatus.installation_delivery_Scheduled:
                    return "Install Delivery Scheduled";
                case FactorStatus.Out_for_delivery:
                    return "Out For Delivery";
                case FactorStatus.Job_Delivered:
                    return "Job Delivered";
                case FactorStatus.Invoice_sent:
                    return "Invoice Sent";
                case FactorStatus.waiting_for_payment:
                    return "waiting For Payment";
                case FactorStatus.Paid_in_full:
                    return "Paid In Full";
                case FactorStatus.Request_Review:
                    return "Request Review";
                case FactorStatus.Cancelled:
                    return "Cancelled";
                case FactorStatus.GetStart:
                    return "Start";
                case FactorStatus.StartProject:
                    return "Start";
                case FactorStatus.PauseProject:
                    return "Pause";
                case FactorStatus.ContinueProject:
                    return "Continue Later";
                case FactorStatus.Close:
                    return "Close";
                case FactorStatus.Suspended:
                    return "Suspended";
                case FactorStatus.OnlineOrder:
                    return "Online Order";
                case FactorStatus.DueDate:
                    return "Due Date";
                default:
                    return "--";
            }
        }
        catch
        {
            return "--";
        }
    }
    public static double UptoTwoDecimalPoints(this double num)
    {
        var totalCost = Convert.ToDouble(String.Format("{0:0.00}", num));
        return totalCost;
    }
    public static DateTime StartOfWeekk(this DateTime dt, DayOfWeek startOfWeek)
    {
        int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
        return dt.AddDays(-1 * diff).Date;
    }
    public static DateTime SystemTimee(this DateTime time)
    {
        try
        {
            //America/Los_Angeles
            TimeZoneInfo timeInfo = TimeZoneInfo.FindSystemTimeZoneById("America/Los_Angeles");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeInfo);
        }
        catch (Exception ex)
        {
            return DateTime.Now;
        }
    }
    public static double ToPositive(this double amount)
    {
        return (amount > 0 ? amount : -1 * amount);
    }
    public static double RoundDecimal(this double amount,int decimalPoint = 2)
    {
        if (amount == 0)
            return 0.0;

     return Math.Round(amount, decimalPoint);
    }
    public static double ToPositive(this decimal amount)
    {
        return (double)(amount > 0 ? amount : -1 * amount);
    }
    public static string ToPageTitle(this string pageName)
    {
        try
        {
           var casestr = pageName.ToLower();
            switch (casestr)
            {
                case "index":
                    return "Home Page";
                case "views":
                    return "Page Views Statistic";
                case "pageviews":
                    return "Page Views Statistic";
                case "update":
                    return "Project Details";
                case "factors":
                    return "Projects";
                case "jobpayment":
                    return "Payment Page";
                case "project":
                    return "New Payment Page";
                case "mypayments":
                    return "My Payments";
                case "workscheduling":
                    return "Work Scheduling";
                case "expense":
                    return "Expense";
                case "mycalendar":
                    return "My Calendar";
                case "otherusers":
                    return "Employees";
                case "shipping":
                    return "Shipping";
                case "vendors":
                    return "Vendors";
                case "default":
                    return "System Configuration";
                case "jobtypes":
                    return "Job Types";
                case "editprofile":
                    return "Edit Profile";
                case "add":
                    return "New Project";
                case "emailsetting":
                    return "Email Service";
                case "status":
                    return "Status Notification";
                case "operatorresetpassword":
                    return "Reset Password";
                case "mytools":
                    return "My Tools";
                case "mytimecards":
                    return "My TimeCards";
                case "timeLine":
                    return "Time Line";
                case "users":
                    return "Clients";
                case "listtimeCards":
                    return "Time Cards";
                case "itemcategories":
                    return "Item Categories";
                case "itemmodifires":
                    return "Item Modifires";
                case "payaccount":
                    return "Accounting Pay Account";
                case "paymenttype":
                    return "Accounting Payment Type";
                case "expenseproduct":
                    return "Accounting Product";
                case "expensetype":
                    return "Accounting Expense Type";
                case "category":
                    return "Accounting Category";
                case "showtransactoin":
                    return "Plaid Show Transactoin";
                case "bankaccounts":
                    return "Plaid SBankAccounts";
                case "sortedproject":
                    return "Sorted Project Setting";
                case "operator":
                    return "Admin Users";
                default:
                    return pageName;
            }
        }
        catch
        {
            return pageName;
        }
    }

    public static string EstimationColor(this FactorStatus sts)
    {
        try
        {
            if (sts == FactorStatus.OnlineOrder) return "step-success";
            if (sts == FactorStatus.Schedule_Measuring_Request) return "step-success";

            var number = (int)sts;

            return number == 1 ? "step-active" : "step-success";

        }
        catch
        {
            return "step-inactive";
        }
    }

    public static string FabricationColor(this FactorStatus sts)
    {
        try
        {
            if (sts == FactorStatus.OnlineOrder) return "step-active";
            if (sts == FactorStatus.Schedule_Measuring_Request) return "step-active";
            var number = (int)sts;

            return number > 1 & number < 16 ? "step-active" : (number >= 16 ? "step-success" : "step-inactive");
        }
        catch
        {
            return "step-inactive";
        }
    }
    public static string InstallationColor(this FactorStatus sts)
    {
        try
        {
            if (sts == FactorStatus.OnlineOrder) return "step-inactive";
            if (sts == FactorStatus.Schedule_Measuring_Request) return "step-inactive";

            var number = (int)sts;
            return number >= 16 & number < 18 ? "step-active" : (number >= 18 ? "step-success" : "step-inactive");
        }
        catch
        {
            return "step-inactive";
        }
    }
    public static string CompletationColor(this FactorStatus sts)
    {
        try
        {
            if (sts == FactorStatus.OnlineOrder) return "step-inactive";
            if (sts == FactorStatus.Schedule_Measuring_Request) return "step-inactive";
            var number = (int)sts;

            return number >= 18 & number < 22 ? "step-active" : (number >= 22 ? "step-success" : "step-inactive");
        }
        catch
        {
            return "step-inactive";
        }
    }




}
