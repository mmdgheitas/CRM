

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
   
    public class SendSMSGroupEnt : EntityBase<long>
    {
        public string? message { get; set; }
        // public string mobile { get; set; }
        public string? groupmid { get; set; }
        public DateTime SendDate { get; set; }
        public bool isSent { get; set; }
        public string? Language { get; set; }
        public int SMSLength { get; set; }
        public string? Sender { get; set; }

        public SendSMSGroupEnt()
        {
            isSent = false;
        }
    }


}