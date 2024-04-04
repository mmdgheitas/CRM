

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class ToolsEnt : EntityBase<long>
    {
        public string? Tools { get; set; }
        public string? CarearID { get; set; }
        [NotMapped]
        public string? CarearName { get; set; }
        public DateTime CarearDate { get; set; }
        [Display(Name = "Carear")]
        public string? TargetCarearID { get; set; }//if target = ""(not transfer) if target has data= it was transfered.
        public ToolsEnt()
        {
            TargetCarearID = "";
        }
    }

    public class ToolsModel : EntityBase<long>
    {
        public string Tools { get; set; }
        [Display(Name = "Carear User")]
        public string CarearID { get; set; }
        [Display(Name = "Carear Name")]
        public string CarearName { get; set; }
        [Display(Name = "Carear Date")]
        public DateTime CarearDate { get; set; }
        [Display(Name = "Carear Date")]
        public string CarearDateStr { get; set; }
        [Display(Name = "Carear")]
        public string TargetCarearID { get; set; }

        [Display(Name = "Carear")]
        public string TargetCarearName { get; set; }
        public ToolsModel()
        {
        }
    }



}