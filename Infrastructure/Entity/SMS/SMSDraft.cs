

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
   
    public class SMSDraftEnt : EntityBase<int>
    {
        [Display(Name = "عنوان")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "لطفا متن پیام را وارد کنید")]
        [Display(Name = "متن پیام")]
        public string? Message { get; set; }

    }


}