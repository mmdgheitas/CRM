using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models.Access
{
    public class UserButton
    {
        public bool UseTelegram { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PasswordChange { get; set; }

        public UserButton()
        {
            UseTelegram = false;
            PhoneNumberConfirmed = false;
            EmailConfirmed = false;
            PasswordChange = false;
        }
      
    }

}