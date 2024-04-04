

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class TimeCardEnt : EntityBase<long>
    {
        public string? UserID { get; set; }
        public string? ClockInLocation { get; set; }
        public string? ClockOutLocation { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime? ClockOutTime { get; set; }
        public DateTime? LunchStart { get; set; }
        public DateTime? LunchFinish { get; set; }
        public DateTime? BreakStart { get; set; }
        public DateTime? BreakFinish { get; set; }

        public TimeCardEnt()
        {

        }
    }

    public class TimeCardModel : EntityBase<long>
    {
        public string UserID { get; set; }
        public string FullName { get; set; }
        public DateTime ClockInTime { get; set; }
        [Display(Name = "Clock in")]
        public string ClockInTimeFa { get; set; }
        public string ClockInTimeStr { get; set; }
        public DateTime? ClockOutTime { get; set; }
        [Display(Name = "Clock out")]
        public string ClockOutTimeFa { get; set; }
        public string ClockOutTimeStr { get; set; }
        public DateTime? BreakStart { get; set; }
        [Display(Name = "Break start")]
        public string BreakStartFa { get; set; }
        public string BreakStartTime { get; set; }
        public DateTime? BreakFinish { get; set; }
        [Display(Name = "Break finish")]
        public string BreakFinishFa { get; set; }
        public string BreakFinishTime { get; set; }
        public string UseBreakFa { get; set; }
        public DateTime? LunchStart { get; set; }
        [Display(Name = "Lunch start")]
        public string LunchStartFa { get; set; }
        public string LunchStartTime { get; set; }
        public DateTime? LunchFinish { get; set; }
        [Display(Name = "Lunch finish")]
        public string LunchFinishFa { get; set; }
        public string LunchFinishTime { get; set; }
        public string LunchTime { get; set; }
        public string ClockTime { get; set; }
        public string BreakTime { get; set; }

        public double LunchTime_min { get; set; }
        public double ClockTime_min { get; set; }
        public double BreakTime_min { get; set; }
        public string Status { get; set; }
        public string ClockInLocation { get; set; }
        public string ClockOutLocation { get; set; }
    }

    public class TimeCardBtn
    {
        public bool ClockInBtn { get; set; }
        public bool ClockOutBtn { get; set; }
        public bool ForceCheckOutBtn { get; set; }
        public bool LunchStartBtn { get; set; }
        public bool LunchFinishBtn { get; set; }
        public bool BreakStartBtn { get; set; }
        public bool BreakFinishBtn { get; set; }
        public int BreakTime { get; set; }
        public DateTime StartTime { get; set; }
        public bool inLunch { get; set; }
        public bool inBreak { get; set; }
        public DateTime Now { get; set; }
        public DateTime? LastLogin { get; set; }
        public string ClockInLocation { get; set; }
        public string ClockOutLocation { get; set; }
        public TimeCardBtn()
        {
            ClockOutBtn = false;
            ClockInBtn = false;
            LunchStartBtn = false;
            LunchFinishBtn = false;
            BreakStartBtn = false;
            BreakTime = 15;
        }
    }
    public class TimeCardViewModel_EmployeeApp
    {
        public bool  ClockIn { get; set; }
        public DateTime Now { get; set; }
        public DateTime StartTime { get; set; }
        public string ClockInLocation { get; set; }
        public string ClockOutLocation { get; set; }
        public DateTime? LastLogin { get; set; }

    }
   
    public class TimeCardSearch
    {
        [Display(Name = "Start Date")]
        public string StartDate { get; set; }
        [Display(Name = "End Date")]
        public string EndDate { get; set; }
        public DateTime EndDatee { get; set; }
        [Display(Name = "Users")]
        public string UserID { get; set; }
        public List<appUser> ListUser { get; set; }
    }
    public class appUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }
}