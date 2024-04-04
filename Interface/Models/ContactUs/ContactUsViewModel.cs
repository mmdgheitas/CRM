using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.ContactUs
{
    public class ContactUsViewModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Phone { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}