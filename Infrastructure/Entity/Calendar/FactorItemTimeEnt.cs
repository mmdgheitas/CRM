

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class FactorItemTimeEnt : EntityBase<long>
    {

        public long Factor_ItemID { get; set; }
        public virtual Factor_ItemEnt Factor_Item { get; set; }
        public long AppointmentID { get; set; }
        public AppoitmentType AppoitmentType { get; set; }
        public AppoitmentStatus Status { get; set; }
        public DateTime? StartItetmDate { get; set; }
        public string? StartItemLocation { get; set; }
        public DateTime? CompleteItemDate { get; set; }
        public string? CompleteItemLocation { get; set; }
        public DateTime? InCompleteItemDate { get; set; }
        public string? InCompleteItemLocation { get; set; }
        public int WorkTimeMin { get; set; }
    }
    public enum AppoitmentType
    {
        Estimation = 0,
        Installation = 1,
        Task = 2,
    }
}