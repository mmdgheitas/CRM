using Infrastructure.Entity;
using Interface.Models.UserRole;
using Microsoft.EntityFrameworkCore.Sqlite.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Interface.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    //public class SendCodeViewModel
    //{
    //    public string SelectedProvider { get; set; }
    //    public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    //    public string ReturnUrl { get; set; }
    //    public bool RememberMe { get; set; }
    //}

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class Login
    {
        [Required]
        [Display(Name = "User Name")]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100)]
        public string Password { get; set; }
        [Display(Name = "Remember Me ?")]
        public bool RememberMe { get; set; }
       // [Required]
        [Display(Name = "Captcha")]
        public string? Captcha { get; set; }
        public string? LoginDescription { get; set; }
        public bool EnableLoginDes { get; set; }

    }

    public class Register
    {
        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [Display(Name = "نام :")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده برای نام بیش از حد مجاز است.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد کنید")]
        [Display(Name = " نام خانوادگی :")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده برای نام خانوادگی بیش از حد مجاز است.")]
        public string LastName { get; set; }


        [Display(Name = "شماره موبایل")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده برای شماره تلفن بیش از حد مجاز است.")]
        [RegularExpression(@"(0|\+98|0098)?([ ]|,|-|[()]){0,2}9[0|1|2|3|4]([ ]|,|-|[()]){0,2}(?:[0-9]([ ]|,|-|[()]){0,2}){8}", ErrorMessage = "لطفا شماره تلفن صحیح را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "کد ملی :")]
        [StringLength(10, ErrorMessage = "کد ملی باید 10 رقم باشد")]
        public string NationalCode { get; set; }
        [Required(ErrorMessage = "لطفا گروه را انتخاب کنید")]
        [Display(Name = "گروه :")]
        public int DocumentGroupID { get; set; }


        [Display(Name = " شماره دانشجویی :")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده برای شماره دانشجویی بیش از حد مجاز است.")]
        [MinLength(5, ErrorMessage = "شماره دانشجویی باید حداقل 5 کارکتری باشد")]
        public string PersonallyCode { get; set; }
        //---------------------------------------------------------
        [EmailAddress(ErrorMessage = "لطفا ایمیل صحیح را وارد کنید")]
        [Display(Name = "ایمیل :")]
        public string Email { get; set; }
        //---------------------------------------------------------
        [Required(ErrorMessage = "لطفا رمز عبور را وارد کنید")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است.")]
        [MinLength(6, ErrorMessage = "پسور شما باید حداقل 6 کارکتر باشد")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور :")]
        public string Password { get; set; }
        //---------------------------------------------------------
        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور :")]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن یکی نیستند")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "نوع کاربر")]
        public UserType UserType { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "حاصل جمع")]
        public string Captcha { get; set; }

        public bool AgreeService { get; set; }
        public string Terms { get; set; }
        public int LibraryID { get; set; }
        public string librarySearch { get; set; }
        public bool hideSearch { get; set; }
        public Register()
        {
            UserType = UserType.User;
            LibraryID = 0;
            hideSearch = false;

        }
    }

    public class UserImage
    {
        public string ImageProfile { get; set; }
        public int Height { get; set; }
    }

    public class PhoneNumberVerify
    {
        public string PhoneNumber { get; set; }
        public string VerifyCode { get; set; }
        public string SMSAccountNumber { get; set; }
        public bool isVerified { get; set; }
        public UserType UserType { get; set; }
    }
    public class ResetPassword
    {
        public string UserID { get; set; }
        [Display(Name = "Old Password")]
        [Required]
        [StringLength(120)]
        public string OldPassword { get; set; }
        //---------------------------------------------------------
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20,ErrorMessage = "Password length  maximum of 20.")]
        [MinLength(8, ErrorMessage = "Password length at least 8 characters.")]

        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        [RegularExpression(@"((?=.*\d)(?=.*[A-Z]).+$)", ErrorMessage = "Password must contains one digit from 0-9 and must contains one uppercase characters.")]
        public string Password { get; set; }
        //---------------------------------------------------------
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public UserType UserType { get; set; }
    }
    public class InactiveUser
    {
        public string UserID { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }
        [Display(Name = " شماره دانشجویی ")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده برای شماره دانشجویی بیش از حد مجاز است.")]
        [MinLength(5, ErrorMessage = "شماره دانشجویی باید حداقل 5 کارکتری باشد")]
        public string PersonallyCode { get; set; }
        [Display(Name = "گروه ")]
        public string DocumentGroup { get; set; }
        [Display(Name = "وضعیت")]
        public string isActive { get; set; }
        [Display(Name = "آخرین تغییرات")]
        public string modifiedInfo { get; set; }

    }
    public class ExtendUser
    {
        public string UserID { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }
        [Display(Name = " شماره دانشجویی ")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده برای شماره دانشجویی بیش از حد مجاز است.")]
        [MinLength(5, ErrorMessage = "شماره دانشجویی باید حداقل 5 کارکتری باشد")]
        public string PersonallyCode { get; set; }
        [Display(Name = "گروه ")]
        public string DocumentGroup { get; set; }
        [Display(Name = "اعتبار/روز")]
        public int ExpireDays { get; set; }
        [Display(Name = "تاریخ اعتبار")]
        public string ExpireDatePersia { get; set; }
        [Display(Name = "می خواهم تاریخ وارد کنم")]
        public bool SelectDate { get; set; }
        [Display(Name = "آخرین تغییرات")]
        public string modifiedInfo { get; set; }
    }
    public class User
    {
        public string UserID { get; set; }
        public string ParrentID { get; set; }
        public string Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        [StringLength(120)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(120)]
     //   [Required]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Father Name")]
        [StringLength(120)]
        public string FatherName { get; set; }
        [Display(Name = "National Code")]
        public string NationalCode { get; set; }

        [Display(Name = "Personally Code")]
        public string PersonallyCode { get; set; }

        [Display(Name = "Other Information")]
        [StringLength(500)]
        public string? OtherInformation { get; set; }
        public bool UserCheckProfile { get; set; }
        //---------------------------------------------------------

        [EmailAddress(ErrorMessage = "Please enter valid email")]
        [Display(Name = "Email ")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }
        [EmailAddress(ErrorMessage = "Please enter valid email")]
        [Display(Name = "Second Email")]
        public string? SecondEmail { get; set; }
        [Display(Name = "Company")]
        public string? CompanyName { get; set; }
    
        [Display(Name = "Street address ")]
        public string? Address { get; set; }
        public string? FullAddress { get; set; }
        [Display(Name = "Zip Code")]
        public string?   ZipCode { get; set; }
        public string? TimeZone { get; set; }
        [Required(ErrorMessage = "Please select city")]
        [Display(Name = "City ")]
        public int CityID { get; set; }
        public CityEnt City { get; set; }
        [Display(Name = "State ")]
        public int StateID { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? EmailConfirmed_P { get; set; }

        [Display(Name = "Phone")]
        //  [RegularExpression(@"(0|\+98|0098)?([ ]|,|-|[()]){0,2}9[0|1|2|3|4]([ ]|,|-|[()]){0,2}(?:[0-9]([ ]|,|-|[()]){0,2}){8}", ErrorMessage = "لطفا شماره تلفن صحیح را وارد کنید")]
          [RegularExpression(@"\d{10}", ErrorMessage = "Phone number must be 10 digits")]
          [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
        
      //  [Required]
        [StringLength(120)]
        [MinLength(6)]

        [Display(Name = "Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password :")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        //---------------------------------------------------------
        public DateTime ExpireDate { get; set; }
        public string ExpireDatePersia { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterDatePersia { get; set; }
        public string LastLoginPersia { get; set; }
        public DateTime LastLogin { get; set; }
        [Display(Name = "User Type")]
        public UserType UserType { get; set; }
        [Display(Name = "Status")]
        public bool isActive { get; set; }
        [Display(Name = "Status")]
        public string isActive_P { get; set; }

        [Display(Name = "Modified Info")]
        public string modifiedInfo { get; set; }
        [Display(Name = "Change Password")]
        public bool ChangePassword { get; set; }
        [Display(Name = "User Photo")]
        public IFormFile UploadImage { get; set; }
        public string Image { get; set; }
        public string FineNotPayed { get; set; }
        public int LibraryID { get; set; }
        public CustomerOrderToEnt OrderTo { get; set; }
        public List<JobTypeModel> JobTypes { get; set; }
        public bool AjaxRequest { get; set; }
        public string calendarColor { get; set; }
        [Display(Name = "Google Map")]
        public string ClientGoogleAddress { get; set; }
        public string CardList { get; set; }
        public List<EstimateAppointmentEnt> EstimateAppointments { get; set; }
        public List<InstallerAppointmentEnt> InstallerAppointments { get; set; }
        public List<TaskViewModel> ListTask { get; set; }
        public List<CityEnt> ListCity { get; set; }   
        public List<WorkSchedulingModel> ListWorkScheduling { get; set; }
        public List<LastActivityModel> ListLastActivity { get; set; }
        [Display(Name = "User Color")]
        public string UserColor { get; set; }
        public string? latitude { get; set; }
        public string? longitude { get; set; }
        [Display(Name = "Google Voice")]
        public string? VoiceGmail { get; set; }
        [Display(Name = "Work Page (Dashboard)")]
        public string? UrlRedirect { get; set; }
        [Display(Name = "Payment Terms")]
        public PaymentTerms PaymentTerms { get; set; }
        public User()
        {
            UserType = UserType.User;
            isActive = true;
            ChangePassword = false;
            OrderTo = new CustomerOrderToEnt();
        }
        public List<jsTreeRole> AllRoles { get; set; }
        public IEnumerable<jsTreeRole> Roles { get; set; }
    }

    public class UserApp
    {
       
        public string Id { get; set; }
    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }

     
        public int CityID { get; set; }
     
        public string PhoneNumber { get; set; }

        public UserType UserType { get; set; }

        public bool isActive { get; set; }
     
        public string Image { get; set; }

        public string Token { get; set; }

        public UserApp()
        {
           
        }
    }
    public class ClientUserApp
    {
        public string UserID { get; set; }
    
       
        public string FirstName { get; set; }
     
        public string FullName { get; set; }
       
        public string Email { get; set; }
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }

        public string Address { get; set; }
        public string FullAddress { get; set; }
        public string ZipCode { get; set; }
        public string GoogleVoice { get; set; }
        public string PhoneNumber { get; set; }
        public string GoogleMapAddress { get; set; }
        public string Balance { get; set; }
        public string BalanceColor { get; set; }
        public int ProjectID { get; set; }


        public ClientUserApp()
        {
        }
  
    }
    public class UserSearch
    {
        [Display(Name = "نام ")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده برای نام بیش از حد مجاز است.")]
        public string FirstName { get; set; }
        [Display(Name = " نام خانوادگی ")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده برای نام خانوادگی بیش از حد مجاز است.")]
        public string LastName { get; set; }
        [Display(Name = "کد ملی ")]
        [StringLength(10, ErrorMessage = "کد ملی باید 10 رقم باشد")]
        public string NationalCode { get; set; }
        [Display(Name = " شماره دانشجویی ")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده برای شماره دانشجویی/کدپرسنلی بیش از حد مجاز است.")]
        public string PersonallyCode { get; set; }
        [Display(Name = "از شماره دانشجویی")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده برای شماره دانشجویی/کدپرسنلی بیش از حد مجاز است.")]
        public string StartPC { get; set; }
        [Display(Name = "تا شماره دانشجویی")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده برای شماره دانشجویی/کدپرسنلی بیش از حد مجاز است.")]
        public string EndPC { get; set; }

        [Display(Name = "از اعتبار/روز")]
        public string StartExpireDays { get; set; }
        [Display(Name = "تا اعتبار/روز")]
        public string EndExpireDays { get; set; }
        [Display(Name = "اعتبار تا تاریخ")]
        public string EndExpireDate { get; set; }
        [Display(Name = "از محدودیت امانت")]
        public int StartBorrowLimit { get; set; }
        [Display(Name = "تا محدودیت امانت")]
        public int EndBorrowLimit { get; set; }
        [Display(Name = "از تعداد امانت")]
        public int StartBorrowNumber { get; set; }
        [Display(Name = "تا تعداد امانت")]
        public int EndBorrowNumber { get; set; }
        //---------------------------------------------------------

        [EmailAddress(ErrorMessage = "لطفا ایمیل صحیح را وارد کنید")]
        [Display(Name = "ایمیل ")]
        public string Email { get; set; }
        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "لطفا محدودیت امانت را وارد کنید")]
        [Display(Name = "محدودیت امانت")]
        public int BorrowLimit { get; set; }
        [Display(Name = "تعداد امانت")]
        public int BorrowNumber { get; set; }

        [Display(Name = "وضعیت فعالی")]
        public int isActive { get; set; }
        [Display(Name = "وضعیت تسویه")]
        public int isCheckOut { get; set; }

        public UserSearch()
        {
            BorrowNumber = 0;
            isActive = 0;
            isCheckOut = 0;
        }
    }

    public class Role
    {
        public bool Selected { get; set; }
        public string RoleName { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string MainName { get; set; }

        public Role()
        {
            Selected = false;
        }
    }


    public class PersonalInfo
    {
        //-----------------------------------------------------------------------
        [Required(ErrorMessage = "لطفا نام را وارد کنید")]
        [Display(Name = "نام")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است.")]
        public string Name { get; set; }
        //-----------------------------------------------------------------------
        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد کنید")]
        [Display(Name = " نام خانوادگی")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است.")]
        public string Family { get; set; }
        //-----------------------------------------------------------------------
        [Required(ErrorMessage = "لطفا جنسیت را مشخص کنید کنید")]
        [Display(Name = "جنسیت")]
        public bool Sex { get; set; }//جنیست=>0=زن-1=مرد
        //-----------------------------------------------------------------------
        [Required(ErrorMessage = "لطفا نام پدر را وارد کنید")]
        [Display(Name = "نام پدر")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است.")]
        public string FatherName { get; set; }
        //-----------------------------------------------------------------------
        [Required(ErrorMessage = "لطفا وضعیت تاهل را مشخصی کنید")]
        [Display(Name = "وضعیت تاهل")]
        public bool Tahol { get; set; }//وضعیت تاهل
        //-----------------------------------------------------------------------
        [Required(ErrorMessage = "لطفا تاریخ تولد را وارد کنید")]
        [Display(Name = "تاریخ تولد")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است.")]
        public string BirthDate { get; set; }
        //-----------------------------------------------------------------------
        [Required(ErrorMessage = "لطفا کد ملی را وارد کنید")]
        [Display(Name = "کد ملی")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است.")]
        public string NationalCode { get; set; }//کد ملی
        //-----------------------------------------------------------------------
        [Required(ErrorMessage = "لطفا شماره شناسنامه را وارد کنید")]
        [Display(Name = "شماره شناسنامه")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است.")]
        public string IdNumber { get; set; }//شماره شناسنامه
        //-----------------------------------------------------------------------
        [Display(Name = "محل تولد")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است.")]
        public string LocationOfBirth { get; set; }
        //-----------------------------------------------------------------------
        [Required(ErrorMessage = "لطفا شماره تلفن همراه را وارد کنید")]
        [Display(Name = "شماره تلفن همراه")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است.")]
        public string PhoneNumber { get; set; }//شماره تلفن همراه
        //-----------------------------------------------------------------------
        [Required(ErrorMessage = "لطفا شماره تلفن ثابت را وارد کنید")]
        [Display(Name = "شماره تلفن ثابت")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است.")]
        public string PhoneNumber2 { get; set; }//شماره تلفن ثابت
        //-----------------------------------------------------------------------
        [Required(ErrorMessage = "لطفا آدرس محل سکونت را وارد کنید")]
        [Display(Name = "آدرس محل سکونت")]
        [StringLength(500, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است.")]
        public string HomeAddress { get; set; }
        //-----------------------------------------------------------------------
        [Required(ErrorMessage = "لطفا کدپستی محل سکونت را وارد کنید")]
        [Display(Name = "کدپستی محل سکونت")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است.")]
        public string HomePCode { get; set; }
        //-----------------------------------------------------------------------
        [Required(ErrorMessage = "لطفا آدرس محل کار را وارد کنید")]
        [Display(Name = "آدرس محل کار")]
        [StringLength(500, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است.")]
        public string WorkAddress { get; set; }
        //-----------------------------------------------------------------------
        [Required(ErrorMessage = "لطفا شماره تلفن محل کار را وارد کنید")]
        [Display(Name = "شماره تلفن محل کار")]
        [StringLength(120, ErrorMessage = "مقدار وارد شده بیش از حد مجاز است.")]
        public string WorkPhoneNumber { get; set; }
        [Display(Name = "شخص")]
        public bool PersonType { get; set; }
        [Display(Name = "درخواست رزرو غرفه")]
        public bool StallReserve { get; set; }
        [Display(Name = "نام شرکت")]
        public string CompanyName { get; set; }
        [Display(Name = "شماره ثبت شرکت ")]
        public string CompanyRegNumber { get; set; }

    }

    public class ResetPasswordViewModel
    {
        [Required()]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        //---------------------------------------------------------
        [Required]
        [StringLength(120)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password :")]
        public string Password { get; set; }
        //---------------------------------------------------------
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password :")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Code { get; set; }

    }

    public class ForgotPasswordViewModel
    {
        [Required]

        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Captcha")]
        public string Captcha { get; set; }
    }
    public class ConfirmEmailAgain
    {
        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید.")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل صحیح وارد کنید.")]
        [Display(Name = "آدرس ایمیل :")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "حاصل جمع")]
        public string Captcha { get; set; }
    }
    public class ChangeEmail
    {
        [Required(ErrorMessage = "please enter you'r new email")]
        [EmailAddress(ErrorMessage = "please enter correct email.")]
        [Display(Name = "New email")]
        public string NewEmail { get; set; }
        [Display(Name = "You'r corrent email :")]
        public string Email { get; set; }
        public UserType UserType { get; set; }
    }
}
