

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class HelpEnt : EntityBase<int>
    {
        [Display(Name = "آدرس بخش")]
        [Required(ErrorMessage = "لطفا آدرس بخش را وارد کنید")]
        public string? HelpURL { get; set; }
        [Display(Name = "مربوط به بخش")]
        [Required(ErrorMessage = "لطفا بخش مورد نظر را وارد کنید")]
        public string? HelpName { get; set; }
        [Display(Name = "عنوان راهنما")]
        public string? HelpTitle { get; set; }
        [Display(Name = "توضیحات راهنما")]
        [Required(ErrorMessage = "لطفا توضیحات راهنما را وارد کنید")]
        public string? HelpContent { get; set; }
        [Display(Name = "وضعیت")]
        public bool isActive { get; set; }


        public HelpEnt()
        {
            isActive = true;
        }
    }


  
}