using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models
{
    public class Notification
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "لطفا عنوان اطلاعیه را وارد کنید",AllowEmptyStrings = true)]
        [Display(Name = "عنوان اطلاعیه")]
        public string Title { get; set; }
        [Required(ErrorMessage = "لطفا متن اطلاعیه را وارد کنید")]
        [Display(Name = "متن اطلاعیه")]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }
        [Display(Name = "تاریخ شروع نمایش")]
        public DateTime StartDate { get; set; }
        [Display(Name = "تاریخ پایان نمایش")]
        public DateTime EndDate { get; set; }
        [Display(Name = "تاریخ شروع نمایش")]
        public string StartDate_Persia { get; set; }
        [Display(Name = "تاریخ پایان نمایش")]
        public string EndDate_Persia { get; set; }
        [Display(Name = "وضعیت")]
        public bool isActive { get; set; }
        public string isActive_Persia { get; set; }
        public string Author { get; set; }
        [Display(Name = "نمایش نام شما")]
        public bool ShowAuthor { get; set; }
        [Display(Name = "دیافت کننده")]
        public UserType UserType { get; set; }
        public string UserType_Persia { get; set; }
        public string modifiedInfo { get; set; }

        public Notification()
        {
            isActive = true;
            ShowAuthor = true;
            StartDate_Persia = Persia.Calendar.ConvertToPersian(DateTime.Now).ToString();
            EndDate_Persia = Persia.Calendar.ConvertToPersian(DateTime.Now.AddDays(10)).ToString();
        }
    }
}