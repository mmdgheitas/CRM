using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface ICustomerService
    {
        List<CustomerEnt> ListAllCustomers();
        bool DeleteCustomer(int id);
        CustomerEnt CustomerDetails(int id);
        bool AddCustomer(CustomerEnt item);
        bool EditCustomer(CustomerEnt item);
        List<CustomerEnt> ListCustomer();

        bool IFExistCustomerPhoneNumber(string phoneNumber, int iD);
        bool isJobTypeForInstaller(int jobType, string installerId);
        bool AddUserTypes(int JobTypeID, string installerID);
        bool DeleteUserTypes(int jobTypeId, string installerID);
        List<JobTypeEnt> ListJobType();
        Task<List<JobTypeEnt>> ListJobTypeAsync();
        Task<List<UserJobTypeEnt>> ListUserJobTypeAsync();
        Task<List<FactorJobTypeEnt>> ListFactorJobTypeAsync();
        bool DeleteJobType(int id);
        JobTypeEnt JobTypeDetails(int id);
        bool IFExistJobTypeTitle(string title, int id = 0);
        bool AddJobType(JobTypeEnt model);
        bool EditJobType(JobTypeEnt model);
        bool isJobTypeInFactor(int jobTypeId, int factorId);
        bool AddFactorJobTypes(int iD, int factorID);
        bool DeleteFactorJobType(int iD, int factorID);
    }
}
