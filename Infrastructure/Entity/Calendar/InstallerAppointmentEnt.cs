

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class InstallerAppointmentEnt : EntityBase<long>
    {
        public long RequestInstallerAppointmentID { get; set; }
        [NotMapped]
        public virtual RequestInstallerAppointmentEnt RequestInstallerAppointment { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime? EndAppointmentDate { get; set; }
        [NotMapped]
        public string? AppointmentDateStr { get; set; }
        public string? InstallerID { get; set; }
        [NotMapped]
        public string? InstallerFullName { get; set; }
        [NotMapped]
        public string? InstallerColor { get; set; }
        [NotMapped]
        public string? CustomerFullName { get; set; }

        public DateTime? GetStartDate { get; set; }

       
        public DateTime? StartProjectDate { get; set; }
        public DateTime? CompleteProjectDate { get; set; }
        public DateTime? InCompleteProjectDate { get; set; }

        public string? GetStartLocation { get; set; }
        public string? StartProjectLocation { get; set; }
        public string? CompleteProjectLocation { get; set; }
        public string? InCompleteProjectLocation { get; set; }
        public int WorkTimeMin { get; set; }
        public int OnWayTimeMin { get; set; }
        public AppoitmentStatus AppoitmentStatus { get; set; }
        [NotMapped]
        public string? TimeDetails { get; set; }
        [NotMapped]
        public string? OnWayTime { get; set; }
        [NotMapped]
        public string? ApptTime { get; set; }
        public bool Disable { get; set; }
        public bool Close { get; set; }
        [NotMapped]
        public string? Image { get; set; }
  
        public InstallerAppointmentEnt()
        {
            WorkTimeMin = 0;
            OnWayTimeMin = 0;
            AppoitmentStatus = AppoitmentStatus.NotStart;
            Disable = false;
            Close = false;
        }
    }

    public class InstallerAppointmentViewModel : EntityBase<long>
    {
        public long RequestInstallerAppointmentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string? UserID { get; set; }
        public string[] UserListID { get; set; }
        public int FactorID { get; set; }
        public int ProjectID { get; set; }
        public UserType UserType { get; set; }
        [Required]
        public int WorkTimeMin { get; set; }
        public int OnWayTimeMin { get; set; }

        public DateTime? GetStartDate { get; set; }
        public DateTime? StartProjectDate { get; set; }
        public DateTime? CompleteProjectDate { get; set; }
        public DateTime? InCompleteProjectDate { get; set; }
        public string?   GetStartLocation { get; set; }
        public string? StartProjectLocation { get; set; }
        public string? CompleteProjectLocation { get; set; }
        public string? InCompleteProjectLocation { get; set; }

        public string UserFullName { get; set; }

        public string StartDateStr { get; set; }

        public string EndDateStr { get; set; }
        [Display(Name = "Time")]
        public DateTime Time { get; set; }
        [Display(Name = "Finish Time")]
        public int FinishTime { get; set; }
        public int TimeLength { get; set; }
        public List<TimeModel> TimeList { get; set; }
        public List<FinishTimeLength> FinishTimeList { get; set; }
        public CustomerOrderToEnt RequestInfo { get; set; }
        public int Type { get; set; }
        public bool Disable { get; set; }
        public bool Close { get; set; }
        public string[] listfactorId { get; set; }
        public string[] listemployee { get; set; }
        public AppoitmentStatus AppoitmentStatus { get; set; }
        public InstallerAppointmentViewModel()
        {
            RequestInfo = new CustomerOrderToEnt();
            Type = 0;
        }
    }

    public enum AppoitmentStatus
    {
        NotStart = 0,
        StartDriving = 1,
        StartProject = 2,
        InCompleteProject = 3,
        CompleteProject = 4
    }

    public class AppoitmentLocation
    {
        public string IP { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string Address { get; set; }
    }
}