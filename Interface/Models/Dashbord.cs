using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Models
{
    public class Dashbord
    {
        public List<Notification> Notifications { get; set; }
        public List<EmailNotificationEnt> EmailNotifications { get; set; }

    }

    public class ServicesStatus
    {
        public string ServiceTitle { get; set; }
        public int DocumentAll { get; set; }
        public int DocumentUsed { get; set; }
        public int DocumentPercent { get; set; }

        public int UserAll { get; set; }
        public int UserUsed { get; set; }
        public int UserPercent { get; set; }

        public int LibrarianAll { get; set; }
        public int LibrarianUsed { get; set; }
        public int LibrarianPercent { get; set; }

        public int DayAll { get; set; }
        public int DayUsed { get; set; }
        public int DayPerncet { get; set; }
    }
    public class Daily
    {
        public List<string> DayName { get; set; }
        public List<int> DayBorrow { get; set; }
    }
}