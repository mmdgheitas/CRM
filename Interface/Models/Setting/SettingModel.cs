using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.Setting
{
    public class EmailSettingModel : EntityBase<byte>
    {
        [Display(Name = "Use Email Service")]
        public bool UseEmailService { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Smtp Host(example : mail.yourdomain.com)")]
        public string SmtpHost { get; set; }
        //[Required]
        [Display(Name = "Password")]
        public string? Password { get; set; }
        public bool ChangePassword { get; set; }
        [Required]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }
        [Required]
        [Display(Name = "Port Number")]
        public int PortNumber { get; set; }
        [Display(Name = "SSL Enable")]
        public bool SSLEnable { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Reciver Email")]
        public string ReciverEmail { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Company Phone")]
        public string CompanyPhone { get; set; }

        [Display(Name = "Company Fax")]
        public string CompanyFax { get; set; }
        [Display(Name = "Company Address")]
        public string CompanyAddress { get; set; }
        [Display(Name = "Company Email")]
        public string CompanyEmail { get; set; }
        [Display(Name = "Company WebSite")]
        public string CompanyWebSite { get; set; }
        [Display(Name = "Terms")]
        public string Terms { get; set; }
        [Display(Name = "Logo")]
        public string logo { get; set; }

    
        public int PONumber { get; set; }
        public Factor_ItemEnt? Item { get; set; }
        public List<Factor_ItemEnt?> Items { get; set; }
        public List<string?> ListInboxReciver { get; set; }
        public EmailSettingModel()
        {
            UseEmailService = false;
            SSLEnable = false;
        }
    }
    public class SMSSettingModel : EntityBase<byte>
    {
        [Display(Name = "استفاده از سرویس پیامک")]
        public bool UseSMSService { get; set; }
        [Display(Name = "امانت سند")]
        public bool BorrowDoc { get; set; }
        [Display(Name = "رزرو سند")]
        public bool ReserveDoc { get; set; }
        [Display(Name = "برگشت سند")]
        public bool DeliveryDoc { get; set; }
        [Display(Name = " تمدید امانت")]
        public bool RenewBorrow { get; set; }
        [Display(Name = "ابطال سند")]
        public bool UndoDoc { get; set; }
        [Display(Name = "پرداخت جریمه امانت سند")]
        public bool PayFine { get; set; }
        [Display(Name = "ورود کاربر به سیستم")]
        public bool LoginUser { get; set; }
        [Display(Name = "تغییر رمز عبور")]
        public bool ChangePasswordUser { get; set; }
        [Display(Name = "تغییر پروفایل کاربری")]
        public bool EditProfile { get; set; }
        public int LibraryID { get; set; }
        public SMSSettingModel()
        {
            UseSMSService = false;
            BorrowDoc = true;
            ReserveDoc = true;
            DeliveryDoc = true;
            RenewBorrow = true;
            PayFine = true;
            UndoDoc = false;
            LoginUser = false;
            ChangePasswordUser = false;
            EditProfile = false;
        }
    }

    public class EmailServiceModel : EntityBase<byte>
    {
        [Display(Name = "استفاده از سرویس ایمیل")]
        public bool UseEmailService { get; set; }
        [Display(Name = "امانت سند")]
        public bool BorrowDoc { get; set; }
        [Display(Name = "رزرو سند")]
        public bool ReserveDoc { get; set; }
        [Display(Name = "برگشت سند")]
        public bool DeliveryDoc { get; set; }
        [Display(Name = " تمدید امانت")]
        public bool RenewBorrow { get; set; }
        [Display(Name = "ابطال سند")]
        public bool UndoDoc { get; set; }
        [Display(Name = "پرداخت جریمه امانت سند")]
        public bool PayFine { get; set; }
        [Display(Name = "ورود کاربر به سیستم")]
        public bool LoginUser { get; set; }
        [Display(Name = "تغییر رمز عبور")]
        public bool ChangePasswordUser { get; set; }
        [Display(Name = "تغییر پروفایل کاربری")]
        public bool EditProfile { get; set; }
        public int LibraryID { get; set; }
        public EmailServiceModel()
        {
            UseEmailService = false;
            BorrowDoc = true;
            ReserveDoc = true;
            DeliveryDoc = true;
            RenewBorrow = true;
            PayFine = true;
            UndoDoc = false;
            LoginUser = false;
            ChangePasswordUser = false;
            EditProfile = false;
        }
    }
}