

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class RequestInstallerAppointmentEnt : EntityBase<long>
    {
        public string? CustomerID { get; set; }
        public int FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }

        public string? Description { get; set; }
        
        public DateTime Date { get; set; }

        [Display(Name = "Time")]
        public string? Time { get; set; }
        public int InstallTime { get; set; }
        public DateTime BookDate { get; set; }

        public string? InstallerID { get; set; }

        public ConfirmStatus Confirmed { get; set; }
        [NotMapped]
        public string? CustomerAddress { get; set; }
        [NotMapped]
        public string? Address { get; set; }
        public RequestInstallerAppointmentEnt()
        {
            Confirmed = 0;
        }
    }

    public class RequestInstallerAppointmentModel : EntityBase<long>
    {
        public string CustomerID { get; set; }
        public int FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [EmailAddress]
        [Display(Name = "Your e-mail address")]
        public string Email { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public virtual CityEnt City { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        public string ZipCode { get; set; }

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Date (click in box for change.)")]
        public string DateStr { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        [Display(Name = "Time")]
        public string Time { get; set; }
   
        [Display(Name = "Install Time(Hour)")]
        public int InstallTime { get; set; }
        public DateTime BookDate { get; set; }
        public string BookDateStr { get; set; }
        public string InstallerID { get; set; }
        public string InstallerFullName { get; set; }
        public ConfirmStatus Confirmed { get; set; }
        public string ConfirmedStr { get; set; }
    
        public List<TimeModel> ListTime { get; set; }
        public EmailSettingEnt EmailSetting { get; set; }
        public FactorStatus FactorStatus { get; set; }
        public bool Reschedul { get; set; }
        public List<DateTimeModel> ListDateTime { get; set; }
        public RequestInstallerAppointmentModel()
        {
            Confirmed = 0;
            Reschedul = false;
        }
    }

    public enum ConfirmStatus
    {
        Pending = 0,
        accept = 1,
        reject = 2

    }
}