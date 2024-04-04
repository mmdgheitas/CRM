using Acklann.Plaid;
using AutoMapper;
using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Implement;
using Infrastructure.Service.Interface;
using Interface.Models;
using Interface.Models.Google;
using Interface.Models.Setting;
using Interface.Repository;
using Microsoft.AspNet.Identity;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Interface.Utilities.Quartz
{
    public class AppoitmentTask : IJob
    {

        public readonly ISettingService _settingService;

        private readonly IRepositoryBase<EmailSettingEnt, byte> _emailSettingRepo;
        private readonly IRepositoryBase<LogEnt, long> _logRepo;

        private readonly IRepositoryBase<InstallerAppointmentEnt, long> _installRepo;
        private readonly IRepositoryBase<EstimateAppointmentEnt, long> _estimateRepo;

        private readonly IRepositoryBase<RequestInstallerAppointmentEnt, long> _requestInstallRepo;
        private readonly IRepositoryBase<RequestEstimateAppointmentEnt, long> _requestEstimateRepo;
        private readonly IRepositoryBase<TaskEnt, long> _taskeRepo;



        public readonly ICalendarService _calendarService;


        public AppoitmentTask()
        {
            _emailSettingRepo = new RepositoryBase<EmailSettingEnt, byte>();
            _settingService = new SettingService(_emailSettingRepo);



            _estimateRepo = new RepositoryBase<EstimateAppointmentEnt, long>();
            _installRepo = new RepositoryBase<InstallerAppointmentEnt, long>();

            _requestEstimateRepo = new RepositoryBase<RequestEstimateAppointmentEnt, long>();
            _requestInstallRepo = new RepositoryBase<RequestInstallerAppointmentEnt, long>();
            _taskeRepo = new RepositoryBase<TaskEnt, long>();
            _calendarService = new CalendarService(_estimateRepo, _installRepo, _taskeRepo, _requestEstimateRepo, _requestInstallRepo);
            _logRepo = new RepositoryBase<LogEnt, long>();
        }


        public async Task Execute(IJobExecutionContext context)
        {
            var emailSetting = _settingService.DefaultEmailSetting();
            if (!emailSetting.UseEmailService)
                return;

            var errorMessaeg = "";
            #region Send Voice SMS To Employee
            var _30MinLater = DateTime.Now.SystemTime().AddMinutes(30);
            var _rightNow = DateTime.Now.SystemTime();
            var listEstimateAppointment = (_calendarService.ListUserEstimateAppointment()).Where(p => p.Disable == false).ToList(); ;
            var listInstallAppointment = (_calendarService.ListUserInstallAppointment()).Where(p => p.Disable == false).ToList();
            var TaskList = (_calendarService.ListUserTasks()).Where(p => p.Disable == false).ToList();
            var FactorTaskList = (new RepositoryBase<FactorTaskEnt, long>().GetAll()).Where(p => p.Done == false).ToList();
            var userManager = new IdentityManager(new ApplicationDbContext())._userManager;
            var UserList = userManager.Users.ToList();
            listEstimateAppointment = listEstimateAppointment.Where(p => p.AppointmentDate <= _30MinLater & p.AppointmentDate >= _rightNow).ToList();
            listInstallAppointment = listInstallAppointment.Where(p => p.AppointmentDate <= _30MinLater & p.AppointmentDate >= _rightNow).ToList();
            TaskList = TaskList.Where(p => p.StartDate <= _30MinLater & p.StartDate >= _rightNow).ToList();
            FactorTaskList = FactorTaskList.Where(p => p.StartDate <= _30MinLater & p.StartDate >= _rightNow).ToList();
            var sent = 0;
            var email = 0;
            foreach (var estimate in listEstimateAppointment)
            {
                var employee = UserList.FirstOrDefault(p => p.Id == estimate.EstimatorID);

                if (employee != null)
                {
                    if (employee.VoiceGmail != null)
                    {
                        var PONumber = GetPONumberOfAppoitment(estimate.RequestEstimateAppointmentID, AppoitmentType.Estimation);
                        var ContentSMS = $"This is a 30 minute reminder for your next appointment - Link => https://start.glassma.us/Task/TimeLine";
                        var res = new MailSender(emailSetting).SendMailWithMemberID(PONumber, ContentSMS, employee.Id, employee.VoiceGmail);
                        if (res == "success") sent++;
                        else errorMessaeg += res;
                    }
                   else 
                    {
                        var PONumber = GetPONumberOfAppoitment(estimate.RequestEstimateAppointmentID, AppoitmentType.Estimation);
                        var ContentSMS = $"This is a 30 minute reminder for your next appointment - Link => https://start.glassma.us/Task/TimeLine";
                        var res = new MailSender(emailSetting).SendMailWithMemberID(PONumber, ContentSMS, employee.Id, employee.Email);
                        if (res == "success") email++;
                        else errorMessaeg += res;
                    }
                }
            }

            foreach (var install in listInstallAppointment)
            {
                var employee = UserList.FirstOrDefault(p => p.Id == install.InstallerID);
                if (employee != null)
                {
                    if (employee.VoiceGmail != null)
                    {

                        var PONumber = GetPONumberOfAppoitment(install.RequestInstallerAppointmentID, AppoitmentType.Installation);
                        var ContentSMS = $"This is a 30 minute reminder for your next appointment - Link => https://start.glassma.us/Task/TimeLine";
                        var res = new MailSender(emailSetting).SendMailWithMemberID(PONumber, ContentSMS, employee.Id, employee.VoiceGmail);
                        if (res == "success") sent++;
                        else errorMessaeg += res;
                    }
                   else
                    {
                        var PONumber = GetPONumberOfAppoitment(install.RequestInstallerAppointmentID, AppoitmentType.Installation);
                        var ContentSMS = $"This is a 30 minute reminder for your next appointment - Link => https://start.glassma.us/Task/TimeLine";
                        var res = new MailSender(emailSetting).SendMailWithMemberID(PONumber, ContentSMS, employee.Id, employee.Email);
                        if (res == "success") email++;
                        else errorMessaeg += res;
                    }

                }

            }

            foreach (var task in TaskList)
            {
                var employee = UserList.FirstOrDefault(p => p.Id == task.UserID);
                if (employee != null)
                {
                    if (employee.VoiceGmail != null)
                    {
                        var ContentSMS = $"This is a 30 minute reminder for your next appointment  -  Link => https://start.glassma.us/Task/TimeLine";
                        var res = new MailSender(emailSetting).SendMailWithMemberID("Task Notofocation", ContentSMS, employee.Id, employee.VoiceGmail);
                        if (res == "success") sent++;
                        else errorMessaeg += res;
                    }
                   else
                    {
                        var ContentSMS = $"This is a 30 minute reminder for your next appointment  -  Link => https://start.glassma.us/Task/TimeLine";
                        var res = new MailSender(emailSetting).SendMailWithMemberID("Task Notofocation", ContentSMS, employee.Id, employee.Email);
                        if (res == "success") email++;
                        else errorMessaeg += res;
                    }
                }

            }

            foreach (var task in FactorTaskList)
            {
                var employee = UserList.FirstOrDefault(p => p.Id == task.EmployeeID);
                if (employee != null)
                {
                    if (employee.VoiceGmail != null)
                    {
                        var ContentSMS = $"This is a 30 minute reminder for your next Task  -  Link => https://start.glassma.us/Task/TimeLine";
                        var res = new MailSender(emailSetting).SendMailWithMemberID("Task Notofocation", ContentSMS, employee.Id, employee.VoiceGmail);
                        if (res == "success") sent++;
                        else errorMessaeg += res;
                    }
                    else
                    {
                        var ContentSMS = $"This is a 30 minute reminder for your next Task  -  Link => https://start.glassma.us/Task/TimeLine";
                        var res = new MailSender(emailSetting).SendMailWithMemberID("Task Notofocation", ContentSMS, employee.Id, employee.Email);
                        if (res == "success") email++;
                        else errorMessaeg += res;
                    }
                }

            }

            if (listEstimateAppointment.Count > 0 || listInstallAppointment.Count > 0 || TaskList.Count > 0 || sent > 0)
            {
                _logRepo.Insert2(new LogEnt()
                {
                    Date = DateTime.Now.SystemTime(),
                    Description =
                     $"send sms to employee :" +
                    $"[Estimate :{listEstimateAppointment.Count}]" +
                    $"[Installation :{listInstallAppointment.Count}]" +
                    $"[Task :{TaskList.Count}]" +
                    $"[Sent SMS :{sent}]"  +
                        $"[Sent Email :{email}]" + $"Error:{errorMessaeg}",
                    Type = 10,
                });
            }
            #endregion
        }

        private string GetPONumberOfAppoitment(long requestID, AppoitmentType type)
        {
            try
            {
                if (type == AppoitmentType.Installation)
                {
                    var request = _calendarService.RequestInstallAppointmentDetails(requestID);
                    var factor = (new RepositoryBase<FactorEnt, int>().GetAll()).FirstOrDefault(p => p.ID == request.FactorID);

                    return factor.PONumber.ToString();
                }
                else
                {
                    var request = _calendarService.RequestEstimateAppointmentDetails(requestID);
                    var factor = (new RepositoryBase<FactorEnt, int>().GetAll()).FirstOrDefault(p => p.ID == request.FactorID);

                    return factor.PONumber.ToString();
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}