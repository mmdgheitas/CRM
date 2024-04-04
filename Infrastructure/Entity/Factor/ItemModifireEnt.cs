

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class ItemModifireEnt : EntityBase<long>
    {
        [Required]
        [Display(Name = "Form Title")]
        public string FormTitle { get; set; }
        [Required]
        [Display(Name = "Submit Title")]
        public string SubmitTitle { get; set; }
        [Display(Name = "Answer Form (if suucced)")]
        public string? AnswerForm { get; set; }
        public string? EditableForm { get; set; }
        [Required]
        [Display(Name = "Modifire Name")]
        public string Name { get; set; }
        [Display(Name = "Category")]
        public int ItemCategoryID { get; set; }
        public virtual ItemCategoryEnt ItemCategory { get; set; }
        public string? CreatedForm { get; set; }
        [Display(Name = "Enable")]
        public bool Enable { get; set; }
        public bool DontSendToVandor { get; set; }
        [NotMapped]
        public string? SendVandor { get; set; }
        public ItemModifireEnt()
        {
            FormTitle = "New Form";
            SubmitTitle = "Submit";
            AnswerForm = "Data saved successfully";
            Enable = true;
            DontSendToVandor = false;

        }

    }


    public class ItemModifireModel : EntityBase<long>
    {
        [Required]
        [Display(Name = "Form Title")]
        public string FormTitle { get; set; }
        [Required]
        [Display(Name = "Submit Title")]
        public string SubmitTitle { get; set; }
        [Display(Name = "Answer Form (if suucced)")]
        public string AnswerForm { get; set; }
        public string EditableForm { get; set; }
        [Required]
        [Display(Name = "Modifire Name")]
        public string Name { get; set; }
        [Display(Name = "Category")]
        public int ItemCategoryID { get; set; }
        public virtual ItemCategoryEnt ItemCategory { get; set; }
        public string CreatedForm { get; set; }
        [Display(Name = "Enable")]
        public bool Enable { get; set; }
        public bool Select { get; set; }
        public int Priority { get; set; }
        public long FactorItemId { get; set; }
        public bool isAnswered { get; set; }
        public ItemModifireModel()
        {
            FormTitle = "New Form";
            SubmitTitle = "Submit";
            AnswerForm = "Data saved successfully";
            Enable = true;
            Priority = 0;
            isAnswered = false;
        }

    }


}
