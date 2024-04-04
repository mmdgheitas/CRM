

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class TaskEnt : EntityBase<long>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? UserID { get; set; }
        public UserType UserType { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public bool Close { get; set; }
        public bool Disable { get; set; }
     
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

        public TaskEnt()
        {
            Close = false;
            Disable = false;
        }
    }
    public class TaskViewModel : EntityBase<long>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserID { get; set; }
        public string[] UserSelectID { get; set; }
        public string[] ListUserSelectID { get; set; }
        public UserType UserType { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }
        public string Description { get; set; }


        public string UserFullName { get; set; }
        public string Image { get; set; }
        public string UserColor { get; set; }

        public string StartDateStrTask { get; set; }

        public string EndDateStr { get; set; }
        [Display(Name = "Start Time")]
        public DateTime Time { get; set; }
        [Display(Name = "Finish Time")]
        public int FinishTime { get; set; }
        public int TimeLength { get; set; }
        public List<TimeModel> TimeList { get; set; }
        public List<FinishTimeLength> FinishTimeList { get; set; }
        [Display(Name = "Google Map")]
        public string GoogleMap { get; set; }
        public bool Close { get; set; }
        public bool Disable { get; set; }
        public DateTime? StartTask { get; set; }
        public DateTime? EndTask { get; set; }

        public DateTime? GetStartDate { get; set; }
        public string GetStartLocation { get; set; }
        public DateTime? StartProjectDate { get; set; }
        public string StartProjectLocation { get; set; }
        public DateTime? CompleteProjectDate { get; set; }
        public string CompleteProjectLocation { get; set; }
        public DateTime? InCompleteProjectDate { get; set; }
        public string InCompleteProjectLocation { get; set; }
        public int WorkTimeMin { get; set; }
        public int OnWayTimeMin { get; set; }
        public AppoitmentStatus AppoitmentStatus { get; set; }
        public TaskViewModel()
        {
        }
    }
}