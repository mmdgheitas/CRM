
using AutoMapper.Configuration.Annotations;
using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Infrastructure.Service.Implement
{
    public class CalendarService : ICalendarService
    {
        IRepositoryBase<WorkSchedulingEnt, long> _WorkSchedulingRepo;
        IRepositoryBase<RequestEstimateAppointmentEnt, long> _requestEstimateAppointmentRepo;
        IRepositoryBase<RequestInstallerAppointmentEnt, long> _requestInstallerAppointmentRepo;
        IRepositoryBase<EstimateAppointmentEnt, long> _estimateAppointmentEntRepo;
        IRepositoryBase<InstallerAppointmentEnt, long> _installerAppointmentEntRepo;
        IRepositoryBase<SettingEnt, byte> _settingRepo;
        IRepositoryBase<FactorInstallerEnt, int> _factorInstallerRepo;
        IRepositoryBase<EmployeeRating, long> _employeeRatingRepo;
        IRepositoryBase<TaskEnt, long> _taskRepo;
        IRepositoryBase<FactorItemTimeEnt, long> _factorItemTimeRepo;
        public CalendarService(IRepositoryBase<WorkSchedulingEnt, long> workSchedulingRepo,
            IRepositoryBase<EstimateAppointmentEnt, long> estimateAppointmentRepo,
            IRepositoryBase<InstallerAppointmentEnt, long> installerAppointmentRepo,
            IRepositoryBase<RequestEstimateAppointmentEnt, long> requestEstimateAppointmentRepo,
            IRepositoryBase<RequestInstallerAppointmentEnt, long> requestInstallerAppointmentRepo,
            IRepositoryBase<SettingEnt, byte> settingRepo,
            IRepositoryBase<FactorInstallerEnt, int> factorInstallerRepo,
            IRepositoryBase<TaskEnt, long> taskRepo,
            IRepositoryBase<EmployeeRating, long> employeeRatingRepo,
              IRepositoryBase<FactorItemTimeEnt, long> factorItemTimeRepo
            )
        {
            this._settingRepo = settingRepo;
            this._WorkSchedulingRepo = workSchedulingRepo;
            this._estimateAppointmentEntRepo = estimateAppointmentRepo;
            this._requestEstimateAppointmentRepo = requestEstimateAppointmentRepo;
            this._requestInstallerAppointmentRepo = requestInstallerAppointmentRepo;
            this._installerAppointmentEntRepo = installerAppointmentRepo;
            this._factorInstallerRepo = factorInstallerRepo;
            this._taskRepo = taskRepo;
            this._employeeRatingRepo = employeeRatingRepo;
            this._factorItemTimeRepo = factorItemTimeRepo;
        }


        public CalendarService(IRepositoryBase<EstimateAppointmentEnt, long> estimateAppointmentRepo,
           IRepositoryBase<InstallerAppointmentEnt, long> installerAppointmentRepo,
           IRepositoryBase<TaskEnt, long> taskRepo,
           IRepositoryBase<RequestEstimateAppointmentEnt, long> requestEstimateAppointmentRepo,
           IRepositoryBase<RequestInstallerAppointmentEnt, long> requestInstallerAppointmentRepo

           )
        {

            this._estimateAppointmentEntRepo = estimateAppointmentRepo;

            this._installerAppointmentEntRepo = installerAppointmentRepo;
            this._requestEstimateAppointmentRepo = requestEstimateAppointmentRepo;

            this._requestInstallerAppointmentRepo = requestInstallerAppointmentRepo;

            this._taskRepo = taskRepo;

        }

        public bool AddWorkScheduling(WorkSchedulingEnt item)
        {
            try
            {
                return _WorkSchedulingRepo.Insert(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeleteWorkScheduling(long id)
        {
            try
            {
                return _WorkSchedulingRepo.Delete(id);

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool EditWorkScheduling(WorkSchedulingEnt item)
        {
            try
            {
                return _WorkSchedulingRepo.Update(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public WorkSchedulingEnt WorkSchedulingDetails(long id)
        {
            try
            {
                return _WorkSchedulingRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<WorkSchedulingEnt> ListAllWorkSchedulings()
        {
            try
            {
                return _WorkSchedulingRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<WorkSchedulingEnt> ListUserWorkSchedulings(string UserId)
        {
            try
            {
                return _WorkSchedulingRepo.GetAll().Where(p => p.UserID == UserId).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<WorkSchedulingEnt>> ListUserWorkSchedulingsAsync(string UserId)
        {
            try
            {
                return await _WorkSchedulingRepo.GetAllAsync().Where(p => p.UserID == UserId).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<WorkSchedulingEnt> ListWorkScheduling()
        {
            try
            {
                return _WorkSchedulingRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<RequestEstimateAppointmentEnt> ListUserRequestEstimateAppointment(string id)
        {
            try
            {
                return _requestEstimateAppointmentRepo.GetAll().Where(p => p.CustomerID == id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<RequestInstallerAppointmentEnt> ListUserRequestInstallAppointment(string id = "")
        {
            try
            {
                if (id == "")
                    return _requestInstallerAppointmentRepo.GetAll().ToList();
                else
                    return _requestInstallerAppointmentRepo.GetAll().Where(p => p.CustomerID == id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<RequestInstallerAppointmentEnt> ListAdminRequestInstallAppointment(string id = "")
        {
            try
            {
                if (id == "")
                    return _requestInstallerAppointmentRepo.GetAll().ToList();
                else
                    return _requestInstallerAppointmentRepo.GetAll().Where(p => p.InstallerID == id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<InstallerAppointmentEnt> ListAdminInstallAppointment(string id = "")
        {
            try
            {
                if (id == "")
                    return _installerAppointmentEntRepo.GetAll().ToList();
                else
                    return _installerAppointmentEntRepo.GetAll().Where(p => p.InstallerID == id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteRequestEstimateAppointment(long id)
        {
            try
            {
                return _requestEstimateAppointmentRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<TimeModel>> GetEstimateFreeWorkScheduling(string date, DateTime now, string editTime, string userId = "", int estimateTime = 1)
        {
            return await GetInstallerFreeWorkScheduling(date, now, editTime, estimateTime, 0, userId, 1, false);
        }

        public async Task<List<TimeModel>> GetFreeWorkSchedulingMultiUser(string date, DateTime now, string editTime, List<string> userIdList)
        {
            var result = new List<TimeModel>();
            var AllTimeModel = new List<TimeModel>();
            var userCount = userIdList.Count();
            if (userCount == 0)
            {
                AllTimeModel.Add(new TimeModel() { TimeStr = "Nothing available" });
                return AllTimeModel;
            }


            //   return ListFreeTime.Where(p => p.Laber >= laberCount).DistinctBy(p => p.TimeStr).OrderBy(p => p.TimeStr).ToList();
            foreach (var userId in userIdList)
            {
                var listTime =await GetInstallerFreeWorkScheduling(date, now, editTime, -1, 0, userId, 1, false, true);
                AllTimeModel.AddRange(listTime);
            }

            foreach (var Time in AllTimeModel)
            {
                if (AllTimeModel.Count(p => p.Time == Time.Time) == userCount)
                    result.Add(Time);
            }

            if (result.Count() == 0)
            {
                result.Add(new TimeModel() { TimeStr = "Nothing available" });
            }
            return result.DistinctBy(p => p.TimeStr).OrderBy(p => p.TimeStr).ToList();
        }

        public async Task<List<TimeModel>> GetInstallerFreeWorkScheduling(string date, DateTime now, string editTime = "", int installtime = 1, int factorId = 0, string userId = "", int laberCount = 1, bool forInstallation = true, bool foMultiUser = false)
        {
            try
            {
                if (installtime == 0)//In User Schedual
                    installtime = 1;
                if (installtime == -1)//In Admin Schedual (show all time)
                    installtime = 0;
                laberCount = laberCount == 0 ? 1 : laberCount;
                var Date = date != "" ? DateTime.Parse(date) : now;

                //installtime = 1;
                //laberCount = 1;

                var installerId = new List<string>();
                if (userId == "")
                    installerId = _factorInstallerRepo.GetAll().Where(p => p.FactorID == factorId).Select(p => p.InstallerId).ToList();
                else
                    installerId = new List<string>() { userId };

                var AllWorkScheduling = _WorkSchedulingRepo.GetAll().Where(p => (userId == "" ? (p.UserType == UserType.Installer || p.UserType == UserType.Installer_Estimator) : true) & p.StartDate.Date <= Date.Date & Date.Date <= p.EndDate.Date & (installerId.Count > 0 ? installerId.Contains(p.UserID) : true)).ToList();

                int InstallerInterval = _settingRepo.GetAll().FirstOrDefault()?.InstallerInterval ?? 60;
                if (forInstallation == false)
                {
                    AllWorkScheduling = _WorkSchedulingRepo.GetAll().Where(p => (userId == "" ? (p.UserType == UserType.Estimator || p.UserType == UserType.Installer_Estimator) : true) & p.StartDate.Date <= Date.Date & Date.Date <= p.EndDate.Date & (userId != "" ? p.UserID == userId : true)).ToList();
                    InstallerInterval = _settingRepo.GetAll().FirstOrDefault()?.EstimateInterval ?? 60;
                }
                if (foMultiUser == true)
                {
                    AllWorkScheduling = _WorkSchedulingRepo.GetAll().Where(p => p.StartDate.Date <= Date.Date & Date.Date <= p.EndDate.Date & (userId != "" ? p.UserID == userId : true)).ToList();
                    InstallerInterval = _settingRepo.GetAll().FirstOrDefault()?.InstallerInterval ?? 60;
                }

                var allRequestInstaller =await _requestInstallerAppointmentRepo.GetAll().ToListAsync();
                var BookedScheduling = _installerAppointmentEntRepo.GetAll().Where(p => p.AppointmentDate.Date == Date.Date & (installerId.Count > 0 ? installerId.Contains(p.InstallerID) : true)).ToList().Select(p =>
                {
                    p.RequestInstallerAppointment = allRequestInstaller.FirstOrDefault(r => r.ID == p.RequestInstallerAppointmentID);


                    p.EndAppointmentDate = p.EndAppointmentDate == null ? p.AppointmentDate.AddHours(p.RequestInstallerAppointment.InstallTime) : p.EndAppointmentDate;
                    return p;
                }).ToList();

                var BookedScheduling2 = _estimateAppointmentEntRepo.GetAll().Where(p => p.AppointmentDate.Date == Date.Date & (userId != "" ? p.EstimatorID == userId : true)).ToList();
                BookedScheduling2 = BookedScheduling2.Select(p => { p.EndAppointmentDate = p.EndAppointmentDate ?? p.AppointmentDate.AddHours(1); return p; }).ToList();
                foreach (var item in BookedScheduling2)
                {
                    BookedScheduling.Add(new InstallerAppointmentEnt()
                    {
                        AppointmentDate = item.AppointmentDate,
                        EndAppointmentDate = item.EndAppointmentDate,
                        InstallerID = item.EstimatorID,

                    });
                }

                var BookedTask = _taskRepo.GetAll().Where(p => p.StartDate.Date == Date.Date & (userId == "" ? (p.UserType == UserType.Installer | p.UserType == UserType.Installer_Estimator) : true) & (installerId.Count > 0 ? installerId.Contains(p.UserID) : true)).ToList();
                foreach (var item in BookedTask)
                {
                    BookedScheduling.Add(new InstallerAppointmentEnt()
                    {
                        AppointmentDate = item.StartDate,
                        EndAppointmentDate = item.EndDate,
                        InstallerID = item.UserID,

                    });
                }
                if (editTime != "")
                {
                    var edittime = BookedScheduling.FirstOrDefault(p => p.AppointmentDate == DateTime.Parse(editTime));
                    BookedScheduling.Remove(edittime);
                }

                var HourBookedScheduling = new List<InstallerAppointmentEnt>();
                // var RemoveBookedScheduling = new List<InstallerAppointmentEnt>();
                BookedScheduling = BookedScheduling.Where(p => p.EndAppointmentDate >= p.AppointmentDate).ToList();
                //open booked scheduling
                // if (userId == "")
                foreach (var item in BookedScheduling)
                {

                    var startPoint = item.AppointmentDate.AddHours(-1 * (installtime - 1));
                    var endPoint = item.EndAppointmentDate;
                    if (installtime <= 0) startPoint = item.AppointmentDate;

                    for (DateTime hour = startPoint; hour < endPoint; hour = hour.AddMinutes(InstallerInterval))
                    {

                        HourBookedScheduling.Add(new InstallerAppointmentEnt()
                        {
                            AppointmentDate = hour,
                            EndAppointmentDate = hour,
                            InstallerID = item.InstallerID,
                        });
                    }


                }


                //    BookedScheduling.AddRange(HourBookedScheduling);
                var minHour = AllWorkScheduling.Min(p => p.StartHour);
                var maxHour = AllWorkScheduling.Max(p => p.EndHour);
                var ListFreeTime = new List<TimeModel>();

                var Now = now;
                // now = now.AddMinutes(EstimateInterval);

                foreach (var item in AllWorkScheduling)
                {
                    for (DateTime hour = new DateTime(Date.Year, Date.Month, Date.Day, item.StartHour, item.StartMin, 0); hour <= new DateTime(Date.Year, Date.Month, Date.Day, item.EndHour - installtime, item.EndMin, 0); hour = hour.AddMinutes(InstallerInterval))//آیا در این ساعت نصاب آزاد هست یا خیر. ساعت اینستال تایم هم حساب میشود
                    {
                        var booked = HourBookedScheduling.FirstOrDefault(p => p.AppointmentDate == hour & item.UserID == p.InstallerID);

                        if (booked == null & hour >= Now)
                        {
                            var time = new TimeModel()
                            {
                                Time = hour,
                                TimeStr = hour.ToString("HH:mm"),
                                Time12H = hour.ToString("h:mm tt"),
                                UserID = item.UserID,
                                Laber = 1
                            };
                            if (ListFreeTime.Any(p => p.TimeStr == time.TimeStr))
                            {
                                var deletedtime = ListFreeTime.FirstOrDefault(p => p.TimeStr == time.TimeStr);
                                time.Laber = deletedtime.Laber + 1;
                                ListFreeTime.Remove(deletedtime);

                            }
                            ListFreeTime.Add(time);
                        }

                        if (booked != null)
                        {
                            HourBookedScheduling.Remove(booked);
                        }
                    }
                }
                if (ListFreeTime.Count == 0)
                    ListFreeTime.Add(new TimeModel() { TimeStr = "Nothing available" });


                return ListFreeTime.Where(p => p.Laber >= laberCount).DistinctBy(p => p.TimeStr).OrderBy(p => p.TimeStr).ToList();
            }
            catch (Exception ex)
            {
                var ListFreeTime = new List<TimeModel>();
                ListFreeTime.Add(new TimeModel() { TimeStr = "Nothing available" });
                return ListFreeTime;
            }
        }



        public bool AddRequestEstimateAppointment(RequestEstimateAppointmentEnt model)
        {
            try
            {
                return _requestEstimateAppointmentRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddEstimateAppointment(EstimateAppointmentEnt estimate)
        {
            try
            {
                if (!string.IsNullOrEmpty(estimate.EstimatorID)) return _estimateAppointmentEntRepo.Insert(estimate);

                ///Finding Free User
                var AllWorkScheduling = _WorkSchedulingRepo.GetAll().Where(p => (p.UserType == UserType.Estimator | p.UserType == UserType.Installer_Estimator) & p.StartDate.Date <= estimate.AppointmentDate.Date & estimate.AppointmentDate.Date <= p.EndDate.Date);
                var BookedScheduling = _estimateAppointmentEntRepo.GetAll().Where(p => p.AppointmentDate.Date == estimate.AppointmentDate.Date).ToList();

                var BookedTask = _taskRepo.GetAll().Where(p => p.StartDate.Date == estimate.AppointmentDate.Date & (p.UserType == UserType.Estimator | p.UserType == UserType.Installer_Estimator)).ToList();
                foreach (var item in BookedTask)
                {
                    BookedScheduling.Add(new EstimateAppointmentEnt()
                    {
                        AppointmentDate = item.StartDate,
                        EndAppointmentDate = item.EndDate,
                        EstimatorID = item.UserID,

                    });
                }

                foreach (var item in AllWorkScheduling)
                {
                    if (!BookedScheduling.Any(p => p.EstimatorID == item.UserID & p.AppointmentDate == estimate.AppointmentDate))
                    {
                        if (ListRequestInstallAppointment().Any(p => p.InstallerID == item.UserID & p.Date == estimate.AppointmentDate) | ListEstimateAppointment().Any(p => p.EstimatorID == item.UserID & p.AppointmentDate == estimate.AppointmentDate))
                        {
                            _requestEstimateAppointmentRepo.Delete(estimate.RequestEstimateAppointmentID);
                            return false;
                        }
                        estimate.EstimatorID = item.UserID;


                        return _estimateAppointmentEntRepo.Insert(estimate);
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public RequestEstimateAppointmentEnt RequestEstimateAppointmentDetails(long id)
        {
            try
            {
                return _requestEstimateAppointmentRepo.GetAll().FirstOrDefault(p => p.ID == id) ?? new RequestEstimateAppointmentEnt();
            }
            catch (Exception ex)
            {
                return new RequestEstimateAppointmentEnt();
            }
        }
        public async Task<RequestEstimateAppointmentEnt> RequestEstimateAppointmentDetailsAsync(long id)
        {
            try
            {
                return await _requestEstimateAppointmentRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id) ?? new RequestEstimateAppointmentEnt();
            }
            catch (Exception ex)
            {
                return new RequestEstimateAppointmentEnt();
            }
        }

        public bool RequestEstimateAppointmentUpdate(RequestEstimateAppointmentEnt request)
        {
            try
            {
                return _requestEstimateAppointmentRepo.Update(request);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public EstimateAppointmentEnt EstimateAppointmentDetailsByRequestID(long requestId)
        {
            try
            {
                return _estimateAppointmentEntRepo.GetAll().FirstOrDefault(p => p.RequestEstimateAppointmentID == requestId) ?? new EstimateAppointmentEnt();
            }
            catch (Exception ex)
            {
                return new EstimateAppointmentEnt();
            }
        }
        public async Task<EstimateAppointmentEnt> EstimateAppointmentDetailsByRequestIDAsync(long requestId)
        {
            try
            {
                return (await _estimateAppointmentEntRepo.GetAllAsync().FirstOrDefaultAsync(p => p.RequestEstimateAppointmentID == requestId)) ?? new EstimateAppointmentEnt();
            }
            catch (Exception ex)
            {
                return new EstimateAppointmentEnt();
            }
        }

        public bool DeleteEstimateAppointment(long id)
        {
            try
            {
                if (_estimateAppointmentEntRepo.GetAll().Any(p => p.ID == id))
                    return _estimateAppointmentEntRepo.Delete(id);
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<EstimateAppointmentEnt> ListUserEstimateAppointment(string id = "")
        {
            try
            {
                if (id == "")
                    return _estimateAppointmentEntRepo.GetAll().ToList();
                else
                    return _estimateAppointmentEntRepo.GetAll().Where(p => p.EstimatorID == id).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<EstimateAppointmentEnt>> ListUserEstimateAppointmentAsync(string id = "")
        {
            try
            {
                if (id == "")
                    return await _estimateAppointmentEntRepo.GetAllAsync().Include(p => p.RequestEstimateAppointment).ToListAsync();
                else
                    return (await _estimateAppointmentEntRepo.GetAllAsync().Include(p => p.RequestEstimateAppointment).Where(p => p.EstimatorID == id).ToListAsync());

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<InstallerAppointmentEnt> ListUserInstallAppointment(string id = "")
        {
            try
            {
                if (id == "")
                    return _installerAppointmentEntRepo.GetAll().ToList();
                else
                    return _installerAppointmentEntRepo.GetAll().Where(p => p.InstallerID == id).ToList();


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<InstallerAppointmentEnt>> ListUserInstallAppointmentAsync(string id = "")
        {
            try
            {
                if (id == "")
                    return await _installerAppointmentEntRepo.GetAllAsync().ToListAsync();
                else
                    return await _installerAppointmentEntRepo.GetAllAsync().Where(p => p.InstallerID == id).ToListAsync();


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public RequestInstallerAppointmentEnt RequestInstallAppointmentDetails(long id)
        {
            try
            {
                return _requestInstallerAppointmentRepo.GetAll().FirstOrDefault(p => p.ID == id) ?? new RequestInstallerAppointmentEnt();
            }
            catch (Exception ex)
            {
                return new RequestInstallerAppointmentEnt();
            }
        }

        public async Task<RequestInstallerAppointmentEnt> RequestInstallAppointmentDetailsAsync(long id)
        {
            try
            {
                return await _requestInstallerAppointmentRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id) ?? new RequestInstallerAppointmentEnt();
            }
            catch (Exception ex)
            {
                return new RequestInstallerAppointmentEnt();
            }
        }

        public bool DeleteRequestInstallAppointment(long id)
        {
            try
            {
                return _requestInstallerAppointmentRepo.Delete(id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool AddRequestInstallAppointment(RequestInstallerAppointmentEnt model)
        {
            try
            {
                return _requestInstallerAppointmentRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<RequestInstallerAppointmentEnt> ListRequestInstallAppointmentForMe(string id, DateTime now)
        {
            try
            {
                var MyWorkScheduling = _WorkSchedulingRepo.GetAll().Where(p => (p.UserType == UserType.Installer | p.UserType == UserType.Installer_Estimator) & p.EndDate.Date >= now & p.UserID == id);
                var allPendingRequest = _requestInstallerAppointmentRepo.GetAll().Where(p => p.Confirmed == ConfirmStatus.Pending & p.InstallerID == "").ToList();
                var pendingRequestForMe = new List<RequestInstallerAppointmentEnt>();
                var myAcceptedInstall = _requestInstallerAppointmentRepo.GetAll().Where(p => p.Confirmed == ConfirmStatus.accept & p.InstallerID == id).ToList();
                int InstallerInterval = _settingRepo.GetAll().FirstOrDefault()?.InstallerInterval ?? 60;
                var Now = now;
                // now = now.AddMinutes(EstimateInterval);

                foreach (var item in MyWorkScheduling)
                {
                    for (DateTime hour = new DateTime(item.StartDate.Year, item.StartDate.Month, item.StartDate.Day, item.StartHour, item.StartMin, 0); hour < new DateTime(item.EndDate.Year, item.EndDate.Month, item.EndDate.Day, item.EndHour, item.EndMin, 0); hour = hour.AddMinutes(InstallerInterval))
                    {
                        if (allPendingRequest.Any(p => p.Date == hour) & hour >= Now)
                            if (!myAcceptedInstall.Any(p => p.Date == hour))
                                pendingRequestForMe.Add(allPendingRequest.FirstOrDefault(p => p.Date == hour));
                    }
                }

                return pendingRequestForMe;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateRequestInstallAppointment(RequestInstallerAppointmentEnt request)
        {
            try
            {
                return _requestInstallerAppointmentRepo.Update(request);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateRequestInstallAppointmentAsync(RequestInstallerAppointmentEnt request)
        {
            try
            {
                return await _requestInstallerAppointmentRepo.UpdateAsync(request);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddInstallAppointment(InstallerAppointmentEnt install, bool forAllInstaller = false)
        {

            try
            {
                if (!string.IsNullOrEmpty(install.InstallerID))
                {
                    return _installerAppointmentEntRepo.Insert(install);
                }
                //----find free installer
                var installerId = _factorInstallerRepo.GetAll().Where(p => p.FactorID == install.RequestInstallerAppointment.FactorID).Select(p => p.InstallerId).ToList();

                if (forAllInstaller) installerId = new List<string>();
                var AllWorkScheduling = _WorkSchedulingRepo.GetAll().Where(p => (p.UserType == UserType.Installer || p.UserType == UserType.Installer_Estimator) & p.StartDate.Date <= install.AppointmentDate.Date & install.AppointmentDate.Date <= p.EndDate.Date & (installerId.Count > 0 ? installerId.Contains(p.UserID) : true));
                var BookedScheduling = _installerAppointmentEntRepo.GetAll().Where(p => p.AppointmentDate.Date == install.AppointmentDate.Date & (installerId.Count > 0 ? installerId.Contains(p.InstallerID) : true)).ToList();


                var BookedScheduling2 = _estimateAppointmentEntRepo.GetAll().Where(p => p.AppointmentDate.Date == install.AppointmentDate.Date & (installerId.Count > 0 ? installerId.Contains(p.EstimatorID) : true)).ToList();
                BookedScheduling2 = BookedScheduling2.Select(p => { p.EndAppointmentDate = p.EndAppointmentDate == null ? p.AppointmentDate : p.EndAppointmentDate; return p; }).ToList();
                foreach (var item in BookedScheduling2)
                {
                    BookedScheduling.Add(new InstallerAppointmentEnt()
                    {
                        AppointmentDate = item.AppointmentDate,
                        EndAppointmentDate = item.EndAppointmentDate,
                        InstallerID = item.EstimatorID,

                    });
                }

                var BookedTask = _taskRepo.GetAll().Where(p => p.StartDate.Date == install.AppointmentDate.Date & p.UserType == UserType.Installer).ToList();
                foreach (var item in BookedTask)
                {

                    BookedScheduling.Add(new InstallerAppointmentEnt()
                    {
                        AppointmentDate = item.StartDate,
                        EndAppointmentDate = item.EndDate,
                        InstallerID = item.UserID,

                    });
                }

                var listRequestInstall = _requestInstallerAppointmentRepo.GetAll();
                BookedScheduling = BookedScheduling.Select(p =>
                {
                    p.RequestInstallerAppointment = listRequestInstall.FirstOrDefault(r => r.ID == p.RequestInstallerAppointmentID) ?? new RequestInstallerAppointmentEnt() { InstallTime = 0 };
                    p.EndAppointmentDate = p.EndAppointmentDate == null ?
                    (p.RequestInstallerAppointment != null ? p.AppointmentDate.AddHours(p.RequestInstallerAppointment.InstallTime) : p.EndAppointmentDate) : p.EndAppointmentDate;
                    return p;
                }).ToList();





                foreach (var item in AllWorkScheduling)
                {
                    if (!BookedScheduling.Any(p => p.InstallerID == item.UserID & p.AppointmentDate <= install.AppointmentDate & p.EndAppointmentDate > install.AppointmentDate))
                    {

                        if (!UserHasAppointmentInTime(item.UserID, install.AppointmentDate, install.EndAppointmentDate))
                        {
                            install.InstallerID = item.UserID;
                            return _installerAppointmentEntRepo.Insert(install);
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UserHasAppointmentInTime(string userID, DateTime date, DateTime? endDate = null, long EditEstimateID = 0, long EditInstallerID = 0, long editTaskID = 0)
        {
            try
            {

                if (string.IsNullOrEmpty(userID)) return false;

                var BookedScheduling = _installerAppointmentEntRepo.GetAll().Where(p => p.AppointmentDate.Date == date.Date & p.InstallerID == userID & (EditInstallerID != 0 ? p.ID != EditInstallerID : true)).ToList();

                var listRequestInstall = _requestInstallerAppointmentRepo.GetAll();
                BookedScheduling = BookedScheduling.Select(p =>
                {
                    p.RequestInstallerAppointment = listRequestInstall.FirstOrDefault(r => r.ID == p.RequestInstallerAppointmentID) ?? new RequestInstallerAppointmentEnt() { InstallTime = 0 };
                    p.EndAppointmentDate = p.EndAppointmentDate == null ?
                    (p.RequestInstallerAppointment != null ? p.AppointmentDate.AddHours(p.RequestInstallerAppointment.InstallTime) : p.EndAppointmentDate) : p.EndAppointmentDate;
                    return p;
                }).ToList();

                var BookedScheduling2 = _estimateAppointmentEntRepo.GetAll().Where(p => p.AppointmentDate.Date == date.Date & p.EstimatorID == userID & (EditEstimateID != 0 ? p.ID != EditEstimateID : true)).ToList();
                BookedScheduling2 = BookedScheduling2.Select(p => { p.EndAppointmentDate = p.EndAppointmentDate ?? p.AppointmentDate.AddHours(1); return p; }).ToList();
                foreach (var item in BookedScheduling2)
                {
                    BookedScheduling.Add(new InstallerAppointmentEnt()
                    {
                        AppointmentDate = DateTime.Parse(item.AppointmentDate.ToString()),
                        EndAppointmentDate = DateTime.Parse(item.EndAppointmentDate.ToString()),
                        InstallerID = item.EstimatorID,

                    });
                }

                var BookedTask = _taskRepo.GetAll().Where(p => p.StartDate.Date == date.Date & p.UserID == userID & (editTaskID != 0 ? p.ID != editTaskID : true)).ToList();
                foreach (var item in BookedTask)
                {

                    BookedScheduling.Add(new InstallerAppointmentEnt()
                    {
                        AppointmentDate = item.StartDate,
                        EndAppointmentDate = item.EndDate,
                        InstallerID = item.UserID,

                    });
                }


                var EndDateTime = endDate ?? date.AddHours(1);

                if (BookedScheduling.Any(p => (p.AppointmentDate.Ticks <= date.Ticks & date.Ticks < ((DateTime)p.EndAppointmentDate).Ticks) |
                                             (p.AppointmentDate.Ticks < EndDateTime.Ticks & EndDateTime.Ticks <= ((DateTime)p.EndAppointmentDate).Ticks) |
                                             (p.AppointmentDate.Ticks >= date.Ticks & EndDateTime.Ticks >= ((DateTime)p.EndAppointmentDate).Ticks)))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> UserHasAppointmentInTimeAsync(string userID, DateTime date, DateTime? endDate = null, long EditEstimateID = 0, long EditInstallerID = 0, long editTaskID = 0)
        {
            try
            {

                if (string.IsNullOrEmpty(userID)) return false;

                var BookedScheduling = await _installerAppointmentEntRepo.GetAllAsync().Where(p => p.AppointmentDate.Date == date.Date & p.InstallerID == userID & (EditInstallerID != 0 ? p.ID != EditInstallerID : true)).ToListAsync();

                var listRequestInstall = await _requestInstallerAppointmentRepo.GetAllAsync().ToListAsync();
                BookedScheduling = BookedScheduling.Select(p =>
                {
                    p.RequestInstallerAppointment = listRequestInstall.FirstOrDefault(r => r.ID == p.RequestInstallerAppointmentID) ?? new RequestInstallerAppointmentEnt() { InstallTime = 0 };
                    p.EndAppointmentDate = p.EndAppointmentDate == null ?
                    (p.RequestInstallerAppointment != null ? p.AppointmentDate.AddHours(p.RequestInstallerAppointment.InstallTime) : p.EndAppointmentDate) : p.EndAppointmentDate;
                    return p;
                }).ToList();

                var BookedScheduling2 = await _estimateAppointmentEntRepo.GetAllAsync().Where(p => p.AppointmentDate.Date == date.Date & p.EstimatorID == userID & (EditEstimateID != 0 ? p.ID != EditEstimateID : true)).ToListAsync();
                BookedScheduling2 = BookedScheduling2.Select(p => { p.EndAppointmentDate = p.EndAppointmentDate ?? p.AppointmentDate.AddHours(1); return p; }).ToList();
                foreach (var item in BookedScheduling2)
                {
                    BookedScheduling.Add(new InstallerAppointmentEnt()
                    {
                        AppointmentDate = DateTime.Parse(item.AppointmentDate.ToString()),
                        EndAppointmentDate = DateTime.Parse(item.EndAppointmentDate.ToString()),
                        InstallerID = item.EstimatorID,

                    });
                }

                var BookedTask = await _taskRepo.GetAllAsync().Where(p => p.StartDate.Date == date.Date & p.UserType == UserType.Installer & (editTaskID != 0 ? p.ID != editTaskID : true)).ToListAsync();
                foreach (var item in BookedTask)
                {

                    BookedScheduling.Add(new InstallerAppointmentEnt()
                    {
                        AppointmentDate = item.StartDate,
                        EndAppointmentDate = item.EndDate,
                        InstallerID = item.UserID,

                    });
                }


                var EndDateTime = endDate ?? date.AddHours(1);

                if (BookedScheduling.Any(p => (p.AppointmentDate.Ticks <= date.Ticks & date.Ticks < ((DateTime)p.EndAppointmentDate).Ticks) |
                                             (p.AppointmentDate.Ticks < EndDateTime.Ticks & EndDateTime.Ticks <= ((DateTime)p.EndAppointmentDate).Ticks) |
                                             (p.AppointmentDate.Ticks >= date.Ticks & EndDateTime.Ticks >= ((DateTime)p.EndAppointmentDate).Ticks)))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteWorkSchedulingForUser(string id)
        {
            try
            {
                var listWorkScaduling = _WorkSchedulingRepo.GetAll().Where(p => p.UserID == id);
                var res = true;
                foreach (var item in listWorkScaduling)
                {

                    if (res) res = _WorkSchedulingRepo.Delete(item.ID);
                }
                return res;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public InstallerAppointmentEnt InstallAppointmentDetailsByRequestID(long requestId)
        {
            try
            {
                return _installerAppointmentEntRepo.GetAll().FirstOrDefault(p => p.RequestInstallerAppointmentID == requestId) ?? new InstallerAppointmentEnt();
            }
            catch (Exception ex)
            {
                return new InstallerAppointmentEnt();
            }
        }
        public async Task<InstallerAppointmentEnt> InstallAppointmentDetailsByRequestIDAsync(long requestId)
        {
            try
            {
                return await _installerAppointmentEntRepo.GetAllAsync().FirstOrDefaultAsync(p => p.RequestInstallerAppointmentID == requestId) ?? new InstallerAppointmentEnt();
            }
            catch (Exception ex)
            {
                return new InstallerAppointmentEnt();
            }
        }

        public bool DeleteInstallAppointment(long id)
        {
            try
            {
                return _installerAppointmentEntRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<RequestEstimateAppointmentEnt> ListAllRequestEstimateAppointment()
        {
            try
            {
                return _requestEstimateAppointmentRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<RequestEstimateAppointmentEnt>> ListAllRequestEstimateAppointmentAsync()
        {
            try
            {
                return await _requestEstimateAppointmentRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<RequestInstallerAppointmentEnt> RequestInstallAppointmentDetailsBtFactorID(int factorId)
        {
            try
            {
                return await _requestInstallerAppointmentRepo.GetAllAsync().LastOrDefaultAsync(p => p.FactorID == factorId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<RequestInstallerAppointmentEnt> ListRequestInstallAppointment()
        {
            try
            {
                return _requestInstallerAppointmentRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<RequestInstallerAppointmentEnt>> ListRequestInstallAppointmentAsync()
        {
            try
            {
                return await _requestInstallerAppointmentRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<EstimateAppointmentEnt> ListEstimateAppointment()
        {
            try
            {
                return _estimateAppointmentEntRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<EstimateAppointmentEnt>> ListEstimateAppointmentAsync()
        {
            try
            {
                var list = await _estimateAppointmentEntRepo.GetAllAsync().Include(p => p.RequestEstimateAppointment).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool UpdateInstallAppointment(InstallerAppointmentEnt appoitment)
        {
            try
            {
                return _installerAppointmentEntRepo.Update(appoitment);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateInstallAppointmentAsync(InstallerAppointmentEnt appoitment)
        {
            try
            {
                return await _installerAppointmentEntRepo.UpdateAsync(appoitment);
            }
            catch (Exception ex)
            {
                return false;
            }

        }



        public bool AddTask(TaskEnt model)
        {
            try
            {
                if (_taskRepo.GetAll().Any(p => p.UserID == model.UserID & p.StartDate == model.StartDate & p.EndDate == model.EndDate))
                    return true;
                return _taskRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditTask(TaskEnt model)
        {
            try
            {
                return _taskRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> EditTaskAsync(TaskEnt model)
        {
            try
            {
                return await _taskRepo.UpdateAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TaskEnt> ListUserTasks(string id = "")
        {
            try
            {
                if (id == "")
                    return _taskRepo.GetAll().ToList();
                else
                    return _taskRepo.GetAll().Where(p => p.UserID == id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TaskEnt>> ListUserTasksAsync(string id = "")
        {
            try
            {
                if (id == "")
                    return await _taskRepo.GetAllAsync().ToListAsync();
                else
                    return await _taskRepo.GetAllAsync().Where(p => p.UserID == id).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public TaskEnt TaskDetails(int id)
        {
            try
            {
                return _taskRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<TaskEnt> TaskDetailsAsync(int id)
        {
            try
            {
                return await _taskRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool EditInstallAppointment(InstallerAppointmentEnt model)
        {
            try
            {
                return _installerAppointmentEntRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddInstallAppointmentFource(InstallerAppointmentEnt model)
        {
            try
            {
                if (_installerAppointmentEntRepo.GetAll().Any(p => p.RequestInstallerAppointmentID == model.RequestInstallerAppointmentID & p.InstallerID == model.InstallerID & p.AppointmentDate == model.AppointmentDate))
                    return true;
                else
                    return _installerAppointmentEntRepo.Insert(model);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public InstallerAppointmentEnt InstallAppointmentDetails(long id)
        {
            try
            {
                return _installerAppointmentEntRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<InstallerAppointmentEnt> InstallAppointmentDetailsAsync(long id)
        {
            try
            {
                return await _installerAppointmentEntRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteTask(long id)
        {
            try
            {
                return _taskRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddEstimateAppointmentForce(EstimateAppointmentEnt model)
        {
            try
            {
                return _estimateAppointmentEntRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateRequestEstimateAppointment(RequestEstimateAppointmentEnt request)
        {
            try
            {
                return _requestEstimateAppointmentRepo.Update(request);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditEstimateAppoitment(EstimateAppointmentEnt model)
        {
            try
            {
                return _estimateAppointmentEntRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> EditEstimateAppoitmentAsync(EstimateAppointmentEnt model)
        {
            try
            {
                return await _estimateAppointmentEntRepo.UpdateAsync(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public EstimateAppointmentEnt EstimateAppointmentDetails(long id)
        {
            try
            {
                return _estimateAppointmentEntRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<EstimateAppointmentEnt> EstimateAppointmentDetailsAsync(long id)
        {
            try
            {
                return await _estimateAppointmentEntRepo.GetAllAsync().FirstOrDefaultAsync(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<TaskEnt> ListAllTasks()
        {
            try
            {
                return _taskRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TaskEnt>> ListAllTasksAsync()
        {
            try
            {
                return await _taskRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool IfExistEmployeeRatingByRequestInstallID(long id)
        {
            try
            {
                return _employeeRatingRepo.GetAll().Any(p => p.RequestInstallerAppointmentID == id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ExistRequestInstallID(long id)
        {
            try
            {
                return _requestInstallerAppointmentRepo.GetAll().Any(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateUserTypeOfWorkScheduling(string id, UserType userType, DateTime now)
        {
            try
            {
                var list = _WorkSchedulingRepo.GetAll().Where(p => p.UserID == id & p.StartDate >= now);
                foreach (var item in list)
                {
                    item.UserType = userType;
                    _WorkSchedulingRepo.Update(item);
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool UpdateUserTypeOfTask(string id, UserType userType, DateTime now)
        {
            try
            {
                var list = _taskRepo.GetAll().Where(p => p.UserID == id & p.StartDate >= now);
                foreach (var item in list)
                {
                    item.UserType = userType;
                    _taskRepo.Update(item);
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<InstallerAppointmentEnt> ListAdmiInstallAppointment(string currentUserID)
        {
            try
            {
                return _installerAppointmentEntRepo.GetAll().Where(p => p.InstallerID == currentUserID).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<InstallerAppointmentEnt>> ListAdmiInstallAppointmentAsync(string currentUserID)
        {
            try
            {
                return await _installerAppointmentEntRepo.GetAllAsync().Where(p => p.InstallerID == currentUserID).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool isFinishLastAppointment(int factorId)
        {
            try
            {
                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<List<FactorItemTimeEnt>> ListFactorItemTimes()
        {
            try
            {
                return await _factorItemTimeRepo.GetAllAsync().Include(p => p.Factor_Item).ToListAsync();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<FactorItemTimeEnt> FactorItemTimeDetails(long FactorItemID, long apid)
        {
            try
            {
                return await _factorItemTimeRepo.GetAllAsync().FirstOrDefaultAsync(p => p.Factor_ItemID == FactorItemID & p.AppointmentID == apid);
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<FactorItemTimeEnt> FactorItemTimeDetails(long FactorItemID, long apid, AppoitmentType type)
        {
            try
            {
                return await _factorItemTimeRepo.GetAllAsync().FirstOrDefaultAsync(p => p.Factor_ItemID == FactorItemID & p.AppointmentID == apid & p.AppoitmentType == type);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<FactorItemTimeEnt> AddFactorItemTime(int id, long apid, string type, AppoitmentStatus status)
        {
            try
            {
                FactorItemTimeEnt model = new FactorItemTimeEnt()
                {
                    Factor_ItemID = id,
                    AppointmentID = apid,
                    AppoitmentType = (type == "estimate") ? AppoitmentType.Estimation : AppoitmentType.Installation,
                    Status = status,
                    WorkTimeMin = 0,

                };
                var res = await _factorItemTimeRepo.InsertAsync(model);
                if (res) return model;
                else return null;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<bool> UpdateFactorItemTime(FactorItemTimeEnt factorItemTime)
        {
            try
            {
                return await _factorItemTimeRepo.UpdateAsync(factorItemTime);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IfExiistWorkScheduling(WorkSchedulingEnt model)
        {
            try
            {
                //              p.State date                           p.end date
                //   model.startdate               model.enddate

                var thisUserWork = _WorkSchedulingRepo.GetAll().Where(p => p.UserID == model.UserID).ToList();
                if (model.ID != 0) thisUserWork = _WorkSchedulingRepo.GetAll().Where(p => p.UserID == model.UserID & p.ID != model.ID).ToList();



                var resStart = thisUserWork.Any(p => p.StartDate <= model.StartDate && model.StartDate <= p.EndDate);
                var resEnd = thisUserWork.Any(p => p.StartDate <= model.EndDate && model.EndDate <= p.EndDate);

                return resStart | resEnd;

                return false;

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool IfNotExiistWorkSchedulingInDate(WorkSchedulingEnt model)
        {
            try
            {


                var thisUserWork = _WorkSchedulingRepo.GetAll().Where(p => p.UserID == model.UserID).ToList();
                if (model.ID != 0) thisUserWork = _WorkSchedulingRepo.GetAll().Where(p => p.UserID == model.UserID & p.ID != model.ID).ToList();

                thisUserWork = thisUserWork.Where(p => p.StartDate <= model.CheckHourInDate.Value & p.EndDate >= model.CheckHourInDate.Value).ToList();
                var checkDate = new DateTime(model.CheckHourInDate.Value.Year, model.CheckHourInDate.Value.Month, model.CheckHourInDate.Value.Day, 0, 0, 0);
                
                var resStartHour = !thisUserWork.Any(p => checkDate.AddHours(p.StartHour).AddMinutes(p.StartMin) <= checkDate.AddHours(model.StartHour).AddMinutes(model.StartMin) 
                && checkDate.AddHours(model.StartHour).AddMinutes(model.StartMin)  <= checkDate.AddHours(p.EndHour).AddMinutes(p.EndMin));

                var resEndHour = !thisUserWork.Any(p => checkDate.AddHours(p.StartHour).AddMinutes(p.StartMin) <= checkDate.AddHours(model.EndHour).AddMinutes(model.EndMin) &&
                        checkDate.AddHours(model.EndHour).AddMinutes(model.EndMin) <= checkDate.AddHours(p.EndHour).AddMinutes(p.EndMin));

                return (resStartHour || resEndHour);


            }
            catch (Exception ex)
            {

                return true;
            }
        }
        public bool DeleteFactorItemTimes(long id, AppoitmentType appoitmentType)
        {
            try
            {
                var listItemTime = _factorItemTimeRepo.GetAll().Where(p => p.AppointmentID == id & p.AppoitmentType == appoitmentType);
                var Res = true;
                foreach (var item in listItemTime)
                {
                    if (Res) Res = _factorItemTimeRepo.Delete(item.ID);
                }

                return Res;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
