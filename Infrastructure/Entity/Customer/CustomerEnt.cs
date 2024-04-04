

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class CustomerEnt : EntityBase<int>
    {
        [Display(Name = "نام")]
        public string? FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        public string? LastName { get; set; }
        [Display(Name = "شماره موبایل")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "تلفن منزل")]
        public string? Phone { get; set; }
        [Display(Name = "آدرس")]
        public string? Address { get; set; }
        [Display(Name = "سایر اطلاعات")]
        public string? OtherInformation { get; set; }
        public DateTime RegisterDate { get; set; }

    }

    public class CustomerModel : EntityBase<int>
    {
        public string UserID { get; set; }
        public string Id { get; set; }
        [Required]
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
        public string OtherInformation { get; set; }
        //---------------------------------------------------------

        [EmailAddress]
        [Display(Name = "Email ")]
        public string Email { get; set; }
        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Street address ")]
        public string Address { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Required]
        [Display(Name = "City ")]
        public int CityID { get; set; }
        public CityEnt City { get; set; }
        [Display(Name = "State ")]
        public int StateID { get; set; }
        public bool EmailConfirmed { get; set; }
        public string EmailConfirmed_P { get; set; }

        [Display(Name = "Phone")]
        //  [RegularExpression(@"(0|\+98|0098)?([ ]|,|-|[()]){0,2}9[0|1|2|3|4]([ ]|,|-|[()]){0,2}(?:[0-9]([ ]|,|-|[()]){0,2}){8}", ErrorMessage = "لطفا شماره تلفن صحیح را وارد کنید")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Phone Number must be 10 digit number")]

        public string PhoneNumber { get; set; }

        //  [Required]
        [StringLength(120)]
        [MinLength(6)]

        [Display(Name = "Password")]
        public string Password { get; set; }

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



        public string Image { get; set; }


        public bool AjaxRequest { get; set; }
 

    }



}