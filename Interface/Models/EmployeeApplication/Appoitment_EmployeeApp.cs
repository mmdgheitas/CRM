using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure.Entity;

namespace Interface.Models.EmployeeApplication
{
    public class Appointment_EmployeeApp
    {
        public long AppitmenID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime? EndAppointmentDate { get; set; }
        public string InstallerID { get; set; }
        public int FactorID { get; set; }
        public string InstallerFullName { get; set; }
        public DateTime? GetStartDate { get; set; }
        public DateTime? StartProjectDate { get; set; }
        public DateTime? CompleteProjectDate { get; set; }
        public DateTime? InCompleteProjectDate { get; set; }

        public string GetStartLocation { get; set; }
        public string StartProjectLocation { get; set; }
        public string CompleteProjectLocation { get; set; }
        public string InCompleteProjectLocation { get; set; }
        public int WorkTimeMin { get; set; }
        public int OnWayTimeMin { get; set; }
        public AppoitmentStatus AppoitmentStatus { get; set; }
        public AppoitmentType Type { get; set; }

        public string TaskType { get; set; }
        public string TaskTitle { get; set; }


        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string GoogleAddress { get; set; }
        public string Admin { get; set; }
        public string ViewLink { get; set; }
        public int PONumber { get; set; }
        public FactorProgressStatus ProjectStatus { get; set; }

        public List<AppointmentItemModel> ListItems { get; set; }
        public List<AppointmentItem_FileModel> Images { get; set; }
        public List<AppoitmentColleague> Colleagues { get; set; }
        public List<NoteApplicationModel> ListNotes { get; set; }
    }


    public class AppointmentItemModel 
    {
        public long ID { get; set; }
        public int Quantity { get; set; }
        public int EachPrice { get; set; }
        public int Total { get; set; }
        public string ItemName { get; set; }
        public string ItemText { get; set; }
        public bool Taxable { get; set; }
        public string Shipping { get; set; }
        public string Vendor { get; set; }
        public int InstallTime { get; set; }
        public double ItemNumber { get; set; }
        public bool UploadStart { get; set; }
        public bool UploadInComplete { get; set; }
        public bool UploadComplete { get; set; }

        public ItemStatus ItemStatus { get; set; }
        public string Photo { get; set; }
     
        public List<AppointmentItem_FileModel> Files { get; set; }
  
        public AppointmentItemTimeModel FactorItemTime { get; set; }
     
    }
    public class AppointmentItem_FileModel
    {
        public long FactorItemImageID { get; set; }

        public string File { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        public bool isImage { get; set; }
        public string Comment { get; set; }
        public InstallerUploadItemType UploadItemType { get; set; }


    }

    public class AppitmentPagation_EmployeeApp
    {
        public int modelCount { get; set; }
        public int pagecount { get; set; }
        public List<Appointment_EmployeeApp> model { get; set; }
    }
    public class AppoitmentColleague
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class AppointmentItemTimeModel 
    {
    
        public AppoitmentStatus Status { get; set; }
        public DateTime? StartItetmDate { get; set; }
        public string StartItemLocation { get; set; }
        public DateTime? CompleteItemDate { get; set; }
        public string CompleteItemLocation { get; set; }
        public DateTime? InCompleteItemDate { get; set; }
        public string InCompleteItemLocation { get; set; }
        public int WorkTimeMin { get; set; }
    }
}