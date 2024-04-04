

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class ReportEmailEnt : EntityBase<long>
    {
       
        public DateTime SentDate { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public string? ReciverEmail { get; set; }
        public string? ReciverFullName { get; set; }
        public bool Delete { get; set; }
        public string? Sender { get; set; }
        public string? MemberID { get; set; }

        public ReportEmailEnt()
        {
            Delete = false;
        }

    }

    public class ReportEmailViewModel: EntityBase<long>
    {

        public DateTime SentDate { get; set; }
        public string Subject { get; set; }

        public string ReciverEmail { get; set; }
        public string ReciverFullName { get; set; }
        public bool Delete { get; set; }
        public string Sender { get; set; }
        public string MemberID { get; set; }

      

    }





}