using Infrastructure.Entity;
using Interface.Models.Factor;
using Interface.Models.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models
{
    public class WorkSchadulingViewModel
    {
        public string title { get; set; }
        public string ponumber { get; set; }
        public string start { get; set; }
        public int starty { get; set; }
        public int startmo { get; set; }
        public int startd { get; set; }
        public int endy { get; set; }
        public int endmo { get; set; }
        public int endd { get; set; }
        public int startyh { get; set; }
        public int endh { get; set; }
        public int endmi { get; set; }
        public int startymi { get; set; }
        public int startys { get; set; }
        public string end { get; set; }
        public string today { get; set; }
        public bool allDay { get; set; }
        public string className { get; set; }//["bg-primary"]     ["bg-primary"] = for view work schaduling
        public string borderColor { get; set; }
        public string description { get; set; }
        public string background { get; set; }//#C1E0FF
        public string icon { get; set; }
        public string installer { get; set; }
        public string customer { get; set; }
        public long rid { get; set; }
        public long tid { get; set; }
        public int type { get; set; }
        public string address { get; set; }
        public string map { get; set; }
    }
    public class CalendarViewModel
    {

        public List<WorkSchadulingViewModel> WorkSchadulings { get; set; }
        public List<WorkSchadulingViewModel> EstimateAppointment { get; set; }
        public List<RequestEstimateAppointmentModel> MyAppointment { get; set; }
        public List<FactorItemTimeEnt> ListAllFactorItemTimes { get; set; }
        public List<User> ListUsers { get; set; }
        public string    FactorID { get; set; }
        public Locations Location { get; set; }
        public string SelectDate { get; set; }
        public bool FirstCalendar { get; set; }
        public DateTime? TimeLineDate { get; set; }
    }

    public class TaskTimeLineViewModel
    {

       public List<FactorTaskViewModel> MyTask { get; set; }
        public List<FactorItemTimeEnt> ListAllFactorItemTimes { get; set; }
        public List<EventCount> listEventCount { get; set; }
        public List<User> ListUsers { get; set; }
        public string FactorID { get; set; }
        public Locations Location { get; set; }
        public string SelectDate { get; set; }
        public string SelectUser { get; set; }
        public bool FirstCalendar { get; set; }
        public DateTime? TimeLineDate { get; set; }
    }

    public class EventCount
    {
        public DateTime Date { get; set; }
        public int Count_Red { get; set; }
        public int Count_Green { get; set; }
    }



    public class WorkSchadulingPanelViewModel
    {
        public List<EmployeeUser> ListUsers { get; set; }
        public DateTime StartTime  { get; set; }
        public DateTime EndTime { get; set; }
    }

    public class EmployeeUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserColor { get; set; }
        public List<UserWorkScheduling> ListWorkScheduling { get; set; } = new List<UserWorkScheduling>();
    }
    public class UserWorkScheduling
    {
        public long ID { get; set; }
        public string UserID { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public string TimeToTime { get; set; }

        public string Type { get; set; }
        public string Color { get; set; }

    } 


}