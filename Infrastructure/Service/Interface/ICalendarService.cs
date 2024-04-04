using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface ICalendarService
    {

        bool DeleteWorkScheduling(long id);
        WorkSchedulingEnt WorkSchedulingDetails(long id);
        bool AddWorkScheduling(WorkSchedulingEnt item);
        bool EditWorkScheduling(WorkSchedulingEnt item);

        List<WorkSchedulingEnt> ListAllWorkSchedulings();
        List<WorkSchedulingEnt> ListUserWorkSchedulings(string UserId);
        Task<List<WorkSchedulingEnt>> ListUserWorkSchedulingsAsync(string UserId);
        List<WorkSchedulingEnt> ListWorkScheduling();
        List<RequestEstimateAppointmentEnt> ListUserRequestEstimateAppointment(string id);

        bool DeleteRequestEstimateAppointment(long id);
        Task<List<TimeModel>> GetEstimateFreeWorkScheduling(string date, DateTime now, string time, string userId = "", int estimateTime = 1);
        Task<List<TimeModel>> GetFreeWorkSchedulingMultiUser(string date, DateTime now, string time, List<String> UserIdList);
       Task<List<TimeModel>> GetInstallerFreeWorkScheduling(string date, DateTime now, string time, int installtime = 0, int factorId = 0, string userId = "", int laberCount = 1, bool forInstallation = true, bool forMultiUser = false);
        bool AddRequestEstimateAppointment(RequestEstimateAppointmentEnt model);
        bool AddEstimateAppointment(EstimateAppointmentEnt estimate);
        RequestEstimateAppointmentEnt RequestEstimateAppointmentDetails(long id);
        Task<RequestEstimateAppointmentEnt> RequestEstimateAppointmentDetailsAsync(long id);
        bool RequestEstimateAppointmentUpdate(RequestEstimateAppointmentEnt request);
        EstimateAppointmentEnt EstimateAppointmentDetailsByRequestID(long requestId);
        Task<EstimateAppointmentEnt> EstimateAppointmentDetailsByRequestIDAsync(long requestId);
        bool DeleteEstimateAppointment(long id);
        List<EstimateAppointmentEnt> ListUserEstimateAppointment(string id = "");
        Task<List<EstimateAppointmentEnt>> ListUserEstimateAppointmentAsync(string id = "");
        List<InstallerAppointmentEnt> ListUserInstallAppointment(string id = "");
        Task<List<InstallerAppointmentEnt>> ListUserInstallAppointmentAsync(string id = "");
        RequestInstallerAppointmentEnt RequestInstallAppointmentDetails(long id);
        Task<RequestInstallerAppointmentEnt> RequestInstallAppointmentDetailsAsync(long id);
        bool DeleteRequestInstallAppointment(long id);
        bool AddRequestInstallAppointment(RequestInstallerAppointmentEnt model);
        bool UserHasAppointmentInTime(string userID, DateTime date, DateTime? endDate = null, long EditEstimateID = 0, long EditInstallerID = 0, long editTakID = 0);
        Task<bool> UserHasAppointmentInTimeAsync(string userID, DateTime date, DateTime? endDate = null, long EditEstimateID = 0, long EditInstallerID = 0, long editTakID = 0);

        List<RequestInstallerAppointmentEnt> ListUserRequestInstallAppointment(string id = "");
        List<RequestInstallerAppointmentEnt> ListRequestInstallAppointmentForMe(string id, DateTime now);
        bool UpdateRequestInstallAppointment(RequestInstallerAppointmentEnt request);

        Task<bool> UpdateRequestInstallAppointmentAsync(RequestInstallerAppointmentEnt request);
        bool AddInstallAppointment(InstallerAppointmentEnt installAppointment, bool forAllInstaller = false);
        bool DeleteWorkSchedulingForUser(string UserId);
        InstallerAppointmentEnt InstallAppointmentDetailsByRequestID(long requestId);
        Task<InstallerAppointmentEnt> InstallAppointmentDetailsByRequestIDAsync(long requestId);
        bool DeleteInstallAppointment(long id);
        Task<List<RequestEstimateAppointmentEnt>> ListAllRequestEstimateAppointmentAsync();
        List<RequestEstimateAppointmentEnt> ListAllRequestEstimateAppointment();
        Task<RequestInstallerAppointmentEnt> RequestInstallAppointmentDetailsBtFactorID(int factorId);
        List<RequestInstallerAppointmentEnt> ListRequestInstallAppointment();
        Task<List<RequestInstallerAppointmentEnt>> ListRequestInstallAppointmentAsync();
        List<EstimateAppointmentEnt> ListEstimateAppointment();
        Task<List<EstimateAppointmentEnt>> ListEstimateAppointmentAsync();
        bool UpdateInstallAppointment(InstallerAppointmentEnt appoitment);
        Task<bool> UpdateInstallAppointmentAsync(InstallerAppointmentEnt appoitment);

        bool AddTask(TaskEnt model);
        bool EditTask(TaskEnt model);
        Task<bool> EditTaskAsync(TaskEnt model);
        List<TaskEnt> ListUserTasks(string id = "");
        Task<List<TaskEnt>> ListUserTasksAsync(string id = "");
        TaskEnt TaskDetails(int id);
        Task<TaskEnt> TaskDetailsAsync(int id);
        bool EditInstallAppointment(InstallerAppointmentEnt model);
        bool AddInstallAppointmentFource(InstallerAppointmentEnt model);
        InstallerAppointmentEnt InstallAppointmentDetails(long id);
        Task<InstallerAppointmentEnt> InstallAppointmentDetailsAsync(long id);
        bool DeleteTask(long id);
        bool AddEstimateAppointmentForce(EstimateAppointmentEnt model);
        bool UpdateRequestEstimateAppointment(RequestEstimateAppointmentEnt request);
        bool EditEstimateAppoitment(EstimateAppointmentEnt model);
        Task<bool> EditEstimateAppoitmentAsync(EstimateAppointmentEnt model);
        EstimateAppointmentEnt EstimateAppointmentDetails(long id);
        Task<EstimateAppointmentEnt> EstimateAppointmentDetailsAsync(long id);
        List<TaskEnt> ListAllTasks();
        Task<List<TaskEnt>> ListAllTasksAsync();
        bool IfExistEmployeeRatingByRequestInstallID(long id);
        bool ExistRequestInstallID(long id);
        bool UpdateUserTypeOfWorkScheduling(string id, UserType userType, DateTime now);
        bool UpdateUserTypeOfTask(string id, UserType userType, DateTime now);
        List<RequestInstallerAppointmentEnt> ListAdminRequestInstallAppointment(string currentUserID);
        List<InstallerAppointmentEnt> ListAdmiInstallAppointment(string currentUserID);
        Task<List<InstallerAppointmentEnt>> ListAdmiInstallAppointmentAsync(string currentUserID);
        bool isFinishLastAppointment(int iD);
        Task<List<FactorItemTimeEnt>> ListFactorItemTimes();
        Task<FactorItemTimeEnt> FactorItemTimeDetails(long FactorItemId, long apid);
        Task<FactorItemTimeEnt> FactorItemTimeDetails(long FactorItemId, long apid, AppoitmentType type);
        Task<FactorItemTimeEnt> AddFactorItemTime(int id, long apid, string type, AppoitmentStatus status);
        Task<bool> UpdateFactorItemTime(FactorItemTimeEnt factorItemTime);
        bool IfExiistWorkScheduling(WorkSchedulingEnt model);
        bool IfNotExiistWorkSchedulingInDate(WorkSchedulingEnt model);
        bool DeleteFactorItemTimes(long id, AppoitmentType estimation);
    }
}
