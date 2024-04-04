

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class EmailSettingEnt : EntityBase<byte>
    {
        public bool UseEmailService { get; set; }
   
        public string?  EmailAddress { get; set; }
   
        public string?  SmtpHost { get; set; }

        public string?  Password { get; set; }
     

        public string?  DisplayName { get; set; }
        
   
        public int PortNumber { get; set; }
 
        public bool SSLEnable { get; set; }
        public string?  ReciverEmail { get; set; }
        //---------------------------------------------
        public string?  CompanyName { get; set; }
        public string?  CompanyPhone { get; set; }
        public string?  CompanyFax { get; set; }
        public string?  CompanyAddress { get; set; }
        public string?  CompanyEmail { get; set; }
        public string?  CompanyWebSite { get; set; }
        public string?  Terms { get; set; }
        public string?  logo { get; set; }
  

        public EmailSettingEnt()
        {
            UseEmailService = false;
            SSLEnable = false;
        }
    }


 
}