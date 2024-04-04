

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class EmployeeRating : EntityBase<long>
    {
        public string? UserID { get; set; }
        public byte Score { get; set; }//1-5
        public string? Comment { get; set; }
        public string? CustomerID { get; set; }
        public long RequestEstimateAppointmentID { get; set; }
        public long RequestInstallerAppointmentID { get; set; }
       

        public EmployeeRating()
        {
          
        }
    }

    public class SubmitPoll
    {
        public long RequestInstallerAppointmentID { get; set; }
        public byte Score { get; set; }
        public string Comment { get; set; }
        public bool Polled { get; set; }
        public EmailSettingEnt EmailSetting { get; set; }
    }
  
}