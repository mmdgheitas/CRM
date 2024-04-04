using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Interface.Utilities.Quartz
{
    public class PeriodTaskSchedule : ISchedule
    {
        public int Hour;
        public int Minute;
        public PeriodTaskSchedule(int hour = 10, int minute = 0)
        {
            Hour = hour;
            Minute = minute;
        }
        //Help
        //https://www.quartz-scheduler.net/documentation/quartz-2.x/tutorial/simpletriggers.html
        //https://www.quartz-scheduler.net/documentation/quartz-2.x/tutorial/crontriggers.html
        public async Task Run()
        {
            //DateTimeOffset startTime = DateBuilder.NextGivenSecondDate(null, 2);
            DateTimeOffset startTime = DateBuilder.FutureDate(1, IntervalUnit.Second);

            IJobDetail job = JobBuilder.Create<PeriodTask>()
                                       .WithIdentity("PeriodTask")
                                       .Build();

            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("PeriodTrigger")
                                             .StartAt(startTime)
                                                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(Hour, Minute))

                                            //  .WithCronSchedule("0 0/59 * * * ?")//every 4 Houre

                                  
                                         
                                             .Build();

            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler sc =await sf.GetScheduler();
            sc.ScheduleJob(job, trigger);

            sc.Start();
        }
    }
}