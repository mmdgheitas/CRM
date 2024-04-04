using DNTScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interface.Utilities
{
    public class SendEmailsTask : ScheduledTaskTemplate
    {
        /// <summary>
        /// اگر چند جاب در یک زمان مشخص داشتید، این خاصیت ترتیب اجرای آن‌ها را مشخص خواهد کرد
        /// </summary>
        public override int Order
        {
            get { return 1; }
        }

        public override bool RunAt(DateTime utcNow)
        {

            if (this.IsShuttingDown || this.Pause)
                return false;

            var now = utcNow.AddHours(3.5);//in iran
            return now.Hour == 23 && now.Minute == 33 && now.Second == 1;
        }

        public override void Run()
        {
            if (this.IsShuttingDown || this.Pause)
                return;

            System.Diagnostics.Trace.WriteLine("Running Send Emails");
        }

        public override string Name
        {
            get { return "ارسال ایمیل"; }
        }
    }
}