using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models.Report
{
    public class ReportEmailModel : EntityBase<long>
    {
        public DateTime SentDate { get; set; }
        public string SentDatePersia { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string ReciverEmail { get; set; }
        public string ReciverFullName { get; set; }
        public string Sender { get; set; }
        public bool Delete { get; set; }
        public int LibraryID { get; set; }
        public ReportEmailModel()
        {
            Delete = false;
        }



    }
}