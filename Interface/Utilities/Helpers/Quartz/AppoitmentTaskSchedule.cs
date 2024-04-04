using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Interface.Utilities.Quartz
{
    public class AppoitmentTaskSchedule : ISchedule
    {
        public int Hour;
        public int Minute;
        public AppoitmentTaskSchedule()
        {
          
        }
        //Help
        //https://www.quartz-scheduler.net/documentation/quartz-2.x/tutorial/simpletriggers.html
        //https://www.quartz-scheduler.net/documentation/quartz-2.x/tutorial/crontriggers.html
        public async Task Run()
        {
            //DateTimeOffset startTime = DateBuilder.NextGivenSecondDate(null, 2);
            DateTimeOffset startTime = DateBuilder.FutureDate(2, IntervalUnit.Second);

            IJobDetail job = JobBuilder.Create<AppoitmentTask>()
                                       .WithIdentity("AppoitmentTask")
                                       .Build();

            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("AppoitmentTrigger")
                                             .StartAt(startTime)
                                             .WithCronSchedule("0 0/30 * * * ?")

                                         //      .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(Hour, Minute))
                                         
                                             .Build();

            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler sc =await sf.GetScheduler();
            sc.ScheduleJob(job, trigger);

            sc.Start();
        }
    }
}