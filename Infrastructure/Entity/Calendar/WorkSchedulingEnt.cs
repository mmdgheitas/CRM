

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class WorkSchedulingEnt : EntityBase<long>
    {
        public string? Title { get; set; }
        public string? UserID { get; set; }
        [NotMapped]
        public string UserFullName { get; set; }
        public UserType UserType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartHour { get; set; }
        public int StartMin { get; set; }
        public int EndHour { get; set; }
        public int EndMin { get; set; }
        [NotMapped]
        public DateTime? CheckHourInDate { get; set; } = null;

    }

    public class WorkSchedulingModel : EntityBase<long>
    {
        public string Title { get; set; }
        public string UserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Display(Name = "Start Date")]
        [Required]
        public string StartDateStr { get; set; }
        [Display(Name = "End Date")]
        [Required]
        public string EndDateStr { get; set; }
        [Display(Name = "Start Hour")]
        public int StartHour { get; set; }
        [Display(Name = "Start Min")]
        public int StartMin { get; set; }
        [Display(Name = "End Hour")]
        public int EndHour { get; set; }
        [Display(Name = "End Min")]
        public int EndMin { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Status { get; set; }
        [Display(Name = "Appointment Type")]
        public UserType UserType { get; set; }
        public string UserTypeStr { get; set; }
        public bool SelectDate { get; set; } = true;

      
        public bool Sat { get; set; }
    
        public bool Sun { get; set; }

        public bool Mon { get; set; }
        public bool Tue { get; set; }
        public bool Wed { get; set; }

        public bool Thu { get; set; }
        public bool Fri { get; set; }

        public WorkSchedulingModel()
        {
            StartHour = 1;
            EndHour = 1;
        }

    }

    public class WorkSchedulingMultiple : EntityBase<long>
    {
        public string Title { get; set; }
        public string UserID { get; set; }

        public bool Sat { get; set; }
        [Display(Name = "Saturday")]
        public string SatDate { get; set; }
        public string SatStartHour { get; set; }
        public string SatEndHour { get; set; }
        public string SatStartMin { get; set; }
        public string SatEndMin { get; set; }


        public bool Sun { get; set; }
        [Display(Name = "Sunday")]
        public string SunDate { get; set; }
        public string SunStartHour { get; set; }
        public string SunEndHour { get; set; }
        public string SunStartMin { get; set; }
        public string SunEndMin { get; set; }

        public bool Mon { get; set; }
        [Display(Name = "Monday")]
        public string MonDate { get; set; }
        public string MonStartHour { get; set; }
        public string MonEndHour { get; set; }
        public string MonStartMin { get; set; }
        public string MonEndMin { get; set; }

        public bool Tue { get; set; }
        [Display(Name = "Tuesday")]
        public string TueDate { get; set; }
        public string TueStartHour { get; set; }
        public string TueEndHour { get; set; }
        public string TueStartMin { get; set; }
        public string TueEndMin { get; set; }

        public bool Wed { get; set; }
        [Display(Name = "Wednesday")]
        public string WedDate { get; set; }
        public string WedStartHour { get; set; }
        public string WedEndHour { get; set; }
        public string WedStartMin { get; set; }
        public string WedEndMin { get; set; }


        public bool Thu { get; set; }
        [Display(Name = "Thursday")]
        public string ThuDate { get; set; }
        public string ThuStartHour { get; set; }
        public string ThuEndHour { get; set; }
        public string ThuStartMin { get; set; }
        public string ThuEndMin { get; set; }

        public bool Fri { get; set; }
        [Display(Name = "Friday")]
        public string FriDate { get; set; }
        public string FriStartHour { get; set; }
        public string FriEndHour { get; set; }
        public string FriStartMin { get; set; }
        public string FriEndMin { get; set; }

        [Display(Name = "Appointment Type")]
        public UserType UserType { get; set; }

    }
    public class WorkSchedlingHors
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}