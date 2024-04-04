

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{

    public class SMSAccountEnt : EntityBase<short>
    {
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "لطفا رمز عبوری را وارد کنید")]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا شماره خط اختصاصی را وارد کنید")]
        [Display(Name = "شماره خط اختصاصی")]
        public string PhoneNumber { get; set; }
        [Display(Name = "وضعیت پیش فرض")]
        public bool isDefault { get; set; }
        [Display(Name = "فعال")]
        public bool isActive { get; set; }
        public bool ChangePassword { get; set; }
        public string? Balance { get; set; }
        public SMSAccountEnt() {
            isActive = true;
            isDefault = false;
            ChangePassword = false;
        }
    }


}