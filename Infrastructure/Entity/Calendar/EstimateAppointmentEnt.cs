

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class EstimateAppointmentEnt : EntityBase<long>
    {
        public long RequestEstimateAppointmentID { get; set; }
        public virtual RequestEstimateAppointmentEnt RequestEstimateAppointment { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime? EndAppointmentDate { get; set; }
        [NotMapped]
        public string? AppointmentDateStr { get; set; }
        public string? EstimatorID { get; set; }
        [NotMapped]
        public string? EstimatorFullName { get; set; }
        [NotMapped]
        public string? EstimatorColor { get; set; }
        [NotMapped]
        public string? CustomerFullName { get; set; }
        public bool Disable { get; set; }
        public bool Close { get; set; }
        [NotMapped]

        public string? Image { get; set; }

        public DateTime? GetStartDate { get; set; }
        public string? GetStartLocation { get; set; }

        public DateTime? StartProjectDate { get; set; }
        public string? StartProjectLocation { get; set; }
        public DateTime? CompleteProjectDate { get; set; }
        public string? CompleteProjectLocation { get; set; }
        public DateTime? InCompleteProjectDate { get; set; }
        public string? InCompleteProjectLocation { get; set; }
        public int WorkTimeMin { get; set; }
        public int OnWayTimeMin { get; set; }
        public AppoitmentStatus AppoitmentStatus { get; set; }

        [NotMapped]
        public string? TimeDetails { get; set; }
        [NotMapped]
        public string? ApptTime { get; set; }
        [NotMapped]
        public string? OnWayTime { get; set; }
        public EstimateAppointmentEnt()
        {
            Disable = false;
            Close = false;
        }

    }
}