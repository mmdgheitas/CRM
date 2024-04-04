

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class RequestEstimateAppointmentEnt : EntityBase<long>
    {
        public string? CustomerID { get; set; }
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }
        public string? CompanyName { get; set; }
        public int FactorID { get; set; }
        [NotMapped]
        public virtual FactorEnt Factor { get; set; }
        [EmailAddress]
        [Display(Name = "Your e-mail address")]
        public string? Email { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public virtual CityEnt City { get; set; }
        [Display(Name = "Address")]
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        [Display(Name = "Phone")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Job typee")]
        public string? JobTypes { get; set; }
        public string? Description { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "Time")]
        public string? Time { get; set; }
        public DateTime BookDate { get; set; }

        public bool ShippSameBill { get; set; }
        public bool Canceled { get; set; }

        public RequestEstimateAppointmentEnt()
        {
            Canceled = false;
        }
    }


    public class DateTimeModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string DateStr { get; set; }
        public List<TimeModel> ListTimes { get; set; }
    }
    public class TimeModel
    {
        public string TimeStr { get; set; }
        public string Time12H { get; set; }
        public DateTime Time { get; set; }
        public int Laber { get; set; }
        public string UserID { get; set; }

        public TimeModel()
        {
            Laber = 1;
        }


    }

    public class FinishTimeLength
    {
        public int Minute { get; set; }
        public string Hour { get; set; }
    }

}