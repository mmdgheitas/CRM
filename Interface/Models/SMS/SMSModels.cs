using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.SMS
{
    public class ContactModel
    {
        public long ID { get; set; }
        [StringLength(100, ErrorMessage = "مقدار وارد شده برای نام و نام خانوادگی بیش از حد مجاز است")]
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا نام و نام خانوادگی را وارد کنید")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "لطفا شماره تلفن را وارد کنید")]
        [StringLength(100, ErrorMessage = "مقدار وارد شده برای شماره تلفن بیش از حد مجاز است")]
        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; }
        [StringLength(100, ErrorMessage = "مقدار وارد شده برای تلفن منزل بیش از حد مجاز است")]
        [Display(Name = "تلفن منزل")]
        public string HomePhone { get; set; }
        [Display(Name = "تاریخ تولد")]
        public string BirthDatePersia { get; set; }
        [Display(Name = "تاریخ عضویت")]
        public string JoinDatePersia { get; set; }
        [StringLength(100, ErrorMessage = "مقدار وارد شده برای ایمیل بیش از حد مجاز است")]
        public string Email { get; set; }
        [StringLength(100, ErrorMessage = "مقدار وارد شده برای پیشوند بیش از حد مجاز است")]
        [Display(Name = "پیشوند")]
        public string Prefix { get; set; }
        [Display(Name = "گروه ها")]
        public List<SMSGroupModel> ListGroup { get; set; }
        public string GroupName { get; set; }
        public string modifiedInfo { get; set; }

        public bool Select { get; set; }
    }

    public class SMSGroupModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "لطفا نام گروه را وارد کنید.")]
        [Display(Name = "نام گروه")]
        public string Name { get; set; }
        [Display(Name = "تعداد مخاطبین")]
        public long NumberOfContact { get; set; }
        [Display(Name = "آخرین ویرایش")]
        public string modifiedInfo { get; set; }
        public List<ContactModel> ListContact { get; set; }
        public bool Select { get; set; }
        public bool GroupType { get; set; }//Only for Select Group in Send SMs Group

        public SMSGroupModel()
        {
            GroupType = true;//True = SMSGroup / False = SMSGroupNoName
        }

    }

    public class SMSGroupNoNameModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "لطفا نام گروه را وارد کنید.")]
        [Display(Name = "نام گروه")]
        public string Name { get; set; }
        [Display(Name = "تعداد مخاطبین")]
        public long NumberOfContact { get; set; }
        [Display(Name = "آخرین ویرایش")]
        public string modifiedInfo { get; set; }
        [Display(Name = "لیست شماره ها")]
        [Required(ErrorMessage = "لطفا شماره ها را وارد  کنید")]
        public string ContactList { get; set; }
        public HttpPostedFileBase UploadFile { get; set; }
        public bool Select { get; set; }

    }

    public class SendSMS
    {
        [Display(Name = "فرستنده")]
        public List<SMSAccountEnt> ListAccount { get; set; }
        [Required(ErrorMessage = "لطفا شماره فرستنده را مشخص کنید")]
        [Display(Name = "فرستنده")]
        public string SenderNumber { get; set; }
        [Required(ErrorMessage = "لطفا شماره گیرنده را مشخص کنید")]
        [Display(Name = "گیرندگان")]
        public string Language { get; set; }
        public int SMSLength { get; set; }
        [Display(Name = "گیرندگان")]
        public string Recivers { get; set; }
        [Required(ErrorMessage = "لطفا متن پیام را وارد کنید")]
        [Display(Name = "متن پیام")]
        [MaxLength(640, ErrorMessage = "متن پیام بیش از حد مجاز است")]

        public string Content { get; set; }
        [Display(Name = "تاریخ و ساعت ارسال")]
        public DateTime SendDate { get; set; }
        [Display(Name = "تاریخ ارسال")]
        public string SendDatePersia { get; set; }
        [Display(Name = "ساعت ارسال")]
        public string SendTime { get; set; }
        public bool SendNow { get; set; }
        public double SMSPrice { get; set; }
        public string UserID { get; set; }
        public int LibraryID { get; set; }
        public SendSMS()
        {
            SendNow = true;
        }

    }

    public class SendModel
    {
        public long ID { get; set; }
        public string message { get; set; }
        // public string mobile { get; set; }
        public string groupmid { get; set; }
        public DateTime SendDate { get; set; }
        public string SendDatePersia { get; set; }
        public bool isSent { get; set; }
        public string Language { get; set; }
        public string Sender { get; set; }
        public string Status { get; set; }
        public string StatusCode { get; set; }
        public string Recivers { get; set; }
        public string ReciverNumbers { get; set; }
        public int SMSLength { get; set; }
        public string modifiedInfo { get; set; }
    }

    public class SentDetails
    {
        public long ID { get; set; }
        public string Number { get; set; }
        public string FullName { get; set; }
        public string SentDatePersia { get; set; }
        public string Status { get; set; }
        public string StatusCode { get; set; }

    }

    public class SentDetailsList
    {
        public string Status { get; set; }
        public string StatusCode { get; set; }
        public List<SentDetails> SentList { get; set; }
    }

    public class ReciveMessage
    {
        public string message { get; set; }
        public string SenderNumber { get; set; }
        public string SenderName { get; set; }
        public string SendDate { get; set; }
        public string ReciveNumber { get; set; }//Account

    }

    public class ReciveMessageList
    {
        public string Status { get; set; }
        public List<ReciveMessage> ListRecive { get; set; }
        public ReciveMessageList()
        {
            Status = "";
        }
        
    }


    public class ReciverSearch
    {
        [Display(Name = "تاریخ شروع")]
        public string StartDate { get; set; }
        [Display(Name = "تاریخ پایان")]
        public string EndDate { get; set; }
        [Required(ErrorMessage = "لطفا شماره گیرنده را مشخص کنید")]
        [Display(Name = " گیرنده")]
        public string Number { get; set; }//Account
        [Display(Name = "فرستنده")]
        public string Sender { get; set; }
        [Display(Name = "متن پیام")]
        public string message { get; set; }
     
    }


    public class TestSMS
    {
        public int id { get; set; }
        public string date { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public string amount { get; set; }
        public string tax { get; set; }
        public string total { get; set; }
    }
}

