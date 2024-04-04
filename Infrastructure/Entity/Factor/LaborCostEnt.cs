

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Entity
{
    public class LaborCostEnt : EntityBase<int>
    {
        public int FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
        public DateTime Date { get; set; }
        public string? Labors { get; set; }
        public double Hours { get; set; }
        public double TotalCost { get; set; }
        public string? File { get; set; }
        public string? Description { get; set; }

    }

    public class LaborCostModel : EntityBase<int>
    {
        public int FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Labor Names")]
        public string Labors { get; set; }
        public double Hours { get; set; }
        [Display(Name = " Labor Cost Per H($)")]
        public double LaberPerH { get; set; }
        public double TotalCost { get; set; }
        public string File { get; set; }
        [Display(Name = "File")]
        public IFormFile FileUpload { get; set; }
        public string? Description { get; set; }
    }

    public class Appt_Time
    {
        public long ID { get; set; }
        public string OnWayTime { get; set; }
        public string ApptTime { get; set; }
        public string InstallerFullName { get; set; }
        public string EstimatorFullName { get; set; }
        public int OnWayTimeMin { get; set; }
        public int WorkTimeMin { get; set; }
        public string Image { get; set; }
        public AppoitmentLocation GetStart_Location { get; set; }

        public AppoitmentLocation StartProject_Location { get; set; }
        public AppoitmentLocation CompleteProject_Location { get; set; }
        public AppoitmentLocation InCompleteProject_Location { get; set; }



        public string GetStartLocation { get; set; }

        public string StartProjectLocation { get; set; }
        public string CompleteProjectLocation { get; set; }
        public string InCompleteProjectLocation { get; set; }

        public DateTime? GetStartDate { get; set; }


        public DateTime? StartProjectDate { get; set; }
        public DateTime? CompleteProjectDate { get; set; }
        public DateTime? InCompleteProjectDate { get; set; }
        public List<FactorItemTimeViewModel> ListFactorItemTimes { get; set; }

        public Appt_Time()
        {
            StartProject_Location = new AppoitmentLocation();
            CompleteProject_Location = new AppoitmentLocation();
            InCompleteProject_Location = new AppoitmentLocation();
            GetStart_Location = new AppoitmentLocation();
        }


}
public class FactorItemTimeViewModel
    {
        public long FactorItemId { get; set; }
        public double ItemNumber { get; set; }
        public int WorkTimeMin { get; set; }
        public string WorkTime { get; set; }


        public AppoitmentLocation StartItem_Location { get; set; }
        public AppoitmentLocation CompleteItem_Location { get; set; }
        public AppoitmentLocation InCompleteItem_Location { get; set; }


        public DateTime? StartItetmDate { get; set; }
        public string StartItemLocation { get; set; }
        public DateTime? CompleteItemDate { get; set; }
        public string CompleteItemLocation { get; set; }
        public DateTime? InCompleteItemDate { get; set; }
        public string InCompleteItemLocation { get; set; }

        public FactorItemTimeViewModel()
        {
            StartItem_Location = new AppoitmentLocation();
            CompleteItem_Location = new AppoitmentLocation();
            InCompleteItem_Location = new AppoitmentLocation();
        }
    }
}