using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.Email
{
    public class EmailValue
    {
        public string WebsiteName { get; set; }
        public string ButtonClick { get; set; }
        public string SecoundLink { get; set; }
        public string HomePage { get; set; }
        
        public string Login { get; set; }
        public string ButtonText { get; set; }
        public string Content { get; set; }
        public string EmailTitle { get; set; }
        public string LogoURL { get; set; }
        public string Phone { get; set; }
        public bool EnableDontAnswer { get; set; }
        public EmailValue()
        {
            EnableDontAnswer = false;
        }
    }

    public class SendEmail
    {
        [Display(Name = "فرستنده")]
        public string Sender { get; set; }
        [Display(Name = "گیرنده")]
        public string FullName { get; set; }
        [Display(Name = "گیرنده")]
        public string Email { get; set; }
        [Display(Name = "عنوان ایمیل")]
        [Required(ErrorMessage = "لطفا عنوان ایمیل را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "متن ایمیل")]
        [Required(ErrorMessage = "لطفا متن ایمیل را وارد کنید")]
        public string Content { get; set; }
    }
}