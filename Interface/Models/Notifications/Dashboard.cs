using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure.Entity;
using Interface.Models.Factor;
using Interface.Models.Payment;

namespace Interface.Models
{
    public class Dashboard
    {
        public List<FactorModel> Factors { get; set; }
        public List<PaymentModel> Payments { get; set; }
        public List<DueDateViewModel> PaymentAgo { get; set; }
        public List<DueDateViewModel> PaymentLeft { get; set; }
        public List<EstimateAppointmentEnt> EstimateAppointments { get; set; }
        public List<InstallerAppointmentEnt> InstallerAppointments { get; set; }
        public List<TaskViewModel> InstallerTask { get; set; }
        public List<FactorTaskViewModel> Tasks { get; set; }
        public List<PageViewStatisticsViewModel> TabViewList { get; set; }
        public List<UnsortedGallery> ListUnsortedGallery { get; set; }
        public List<int> JosStatuses { get; set; }
        public SortedFactorStatusViewModel SortedFactorStatus { get; set; }
        public SettingEnt TableSetting { get; set; }
        public TimeCardBtn TimeCard { get; set; }
        public string FactorID { get; set; }
        public MonthlyChart monthlyChart { get; set; }
        public MonthlyProjectChart monthlyProjectChart { get; set; }
        public bool HasChatMessage { get; set; }
        public bool ConfirmEmail { get; set; }
    }
    public class MonthlyChart
    {
        public int ThisYear { get; set; }
        public List<ChartData> MonthlyTotalPrice { get; set; }
        public List<ChartData> MonthlyPaidPrice { get; set; }
        public List<ChartData> MonthlyRemainingPrice { get; set; }
    }
    public class MonthlyProjectChart
    {
        public int ThisYear { get; set; }
        public List<ChartData> MonthlyTotalProject { get; set; }
        public List<ChartData> MonthlyPaidInFull { get; set; }

    }

    public class ChartData
    {
        public int Month { get; set; }
        public int Value { get; set; }
    }

    
}