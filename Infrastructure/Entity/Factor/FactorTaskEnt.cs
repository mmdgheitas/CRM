

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class FactorTaskEnt : EntityBase<long>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [StringLength(64)]
        // [NotMapped]
        public string? EmployeeID { get; set; }
        [StringLength(64)]
        public string? UserFullName { get; set; }

        public int FactorID { get; set; }

        [StringLength(1024)]
        public string? Description { get; set; }
        public bool Done { get; set; }
        public FactorTaskType TaskType { get; set; }
        [StringLength(64)]
        public string? Title { get; set; }
        [StringLength(512)]
        public string? Address { get; set; }
        public FactorTaskMode TaskMode { get; set; }
        public FactorTaskEnt()
        {

            Done = false;
            TaskMode = FactorTaskMode.None;
        }
    }
    public enum FactorTaskType
    {
        Task = 0,
        Installation = 1,
        Estimation = 2,
        Other = 5
    }
    public enum FactorTaskMode
    {
        None = 0,
        DuePastPay = 1,
        UnReadEmail = 2,
        
    }
    public class FactorTaskViewModel : EntityBase<long>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EmployeeID { get; set; }
        public string[] EmployeeListID { get; set; }
        public string Image { get; set; }

        [Required(AllowEmptyStrings = true)]
        public int FactorID { get; set; }
        public string? FactorIDD { get; set; }
        public int PONumber { get; set; }
        public string ProjecName { get; set; }
        public string Client { get; set; }
        public string Phone { get; set; }
        public string[] UserSelectID { get; set; }
        public string[] ListUserSelectID { get; set; }

        public string?   Description { get; set; }
        public string? Address { get; set; }
        public string? ProjectAddress { get; set; }
        public string OldDescription { get; set; }


        public string UserFullName { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        public string StartDateTask { get; set; }

        [Display(Name = "End Date")]
        [Required]
        public string EndDateTask { get; set; }

        [Display(Name = "Start Time")]
        public DateTime Time { get; set; }
        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "Please select start time")]
        public string StartTime { get; set; }
        [Display(Name = "End Time")]
        [Required(ErrorMessage = "Please select end time")]
        public string EndTime { get; set; }

        public DateTime OldStartTime { get; set; }
        public DateTime OldEndTime { get; set; }
        [Display(Name = "Finish Time")]
        public int FinishTime { get; set; }
        public int TimeLength { get; set; }
        public List<TimeModel> TimeList { get; set; }
        public List<FinishTimeLength> FinishTimeList { get; set; }

        public bool Done { get; set; }
        public FactorTaskType TaskType { get; set; }
        public bool IsAppoitment { get; set; }
        [StringLength(64)]
        public string? Title { get; set; }
        public List<FactorNoteEnt> ListNotes { get; set; }
        public bool OnlyNote { get; set; }
        public bool OnlyEditTime { get; set; }
        public FactorTaskMode TaskMode { get; set; }

        /// <summary>
        /// ////Task Details View
        /// </summary>
        public string ProjectName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhone { get; set; }
        public string ClientName { get; set; }
        public FactorTaskViewModel()
        {
            ListNotes = new List<FactorNoteEnt>();
            TaskType = FactorTaskType.Task;
        }
    }
}