using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Implement
{
    public class CustomerService : ICustomerService
    {
        IRepositoryBase<CustomerEnt, int> _customerRepo;
        IRepositoryBase<JobTypeEnt, int> _jobTypeRepo;
         IRepositoryBase<UserJobTypeEnt, int> _UserjobTypeRepo;
        IRepositoryBase<FactorJobTypeEnt, int> _FactorjobTypeRepo;
        public CustomerService(IRepositoryBase<CustomerEnt, int> _customerRepo, IRepositoryBase<UserJobTypeEnt, int> UserjobTypeRepo, IRepositoryBase<JobTypeEnt, int> jobtypeRepo, IRepositoryBase<FactorJobTypeEnt, int> factorJobType)
        {
            this._customerRepo = _customerRepo;
            this._UserjobTypeRepo = UserjobTypeRepo;
            this._jobTypeRepo = jobtypeRepo;
            this._FactorjobTypeRepo = factorJobType;
        }
        public bool AddCustomer(CustomerEnt item)
        {
            try
            {
                return _customerRepo.Insert(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool DeleteCustomer(int id)
        {
            try
            {
                return _customerRepo.Delete(id);

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool EditCustomer(CustomerEnt item)
        {
            try
            {
                return _customerRepo.Update(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public CustomerEnt CustomerDetails(int id)
        {
            try
            {
                return _customerRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<CustomerEnt> ListAllCustomers()
        {
            try
            {
                return _customerRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<CustomerEnt> ListCustomer()
        {
            try
            {
                return _customerRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IFExistCustomerPhoneNumber(string phoneNumber, int iD)
        {
            try
            {
                if (iD == 0)
                    return _customerRepo.GetAll().Any(p => p.PhoneNumber == phoneNumber);
                else
                    return _customerRepo.GetAll().Any(p => p.PhoneNumber == phoneNumber & p.ID != iD);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool isJobTypeForInstaller(int jobType, string installerId)
        {
            try
            {
                return _UserjobTypeRepo.GetAll().Any(p => p.JobTypeID == jobType & p.UserID == installerId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddUserTypes(int JobTypeID, string installerID)
        {
            try
            {
                var uj = new UserJobTypeEnt() { UserID = installerID, JobTypeID = JobTypeID };
                return _UserjobTypeRepo.Insert(uj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool DeleteUserTypes(int jobTypeId, string installerID)
        {
            try
            {
                var ujj = _UserjobTypeRepo.GetAll().FirstOrDefault(p => p.UserID == installerID & p.JobTypeID == jobTypeId);
                return _UserjobTypeRepo.Delete(ujj.ID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<JobTypeEnt> ListJobType()
        {
            try
            {
                return _jobTypeRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<JobTypeEnt>> ListJobTypeAsync()
        {
            try
            {
                return await _jobTypeRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<UserJobTypeEnt>> ListUserJobTypeAsync()
        {
            try
            {
                return await _UserjobTypeRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<FactorJobTypeEnt>> ListFactorJobTypeAsync()
        {
            try
            {
                return await _FactorjobTypeRepo.GetAllAsync().ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteJobType(int id)
        {
            try
            {
                return _jobTypeRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public JobTypeEnt JobTypeDetails(int id)
        {
            try
            {
                return _jobTypeRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IFExistJobTypeTitle(string title, int id = 0)
        {
            try
            {
                if (id == 0)
                    return _jobTypeRepo.GetAll().Any(p => p.Title == title);
                else
                    return _jobTypeRepo.GetAll().Any(p => p.Title == title & p.ID != id);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddJobType(JobTypeEnt model)
        {
            try
            {
                return _jobTypeRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditJobType(JobTypeEnt model)
        {
            try
            {
                return _jobTypeRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool isJobTypeInFactor(int jobTypeId, int FactorId)
        {
            try
            {
                return _FactorjobTypeRepo.GetAll().Any(p => p.JobTypeID == jobTypeId & p.FactorID == FactorId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddFactorJobTypes(int jobTypeId, int factorID)
        {
            try
            {
                var fjt = new FactorJobTypeEnt() { FactorID = factorID, JobTypeID = jobTypeId };
                if (!_FactorjobTypeRepo.GetAll().Any(p => p.FactorID == factorID & p.JobTypeID == jobTypeId))
                    return _FactorjobTypeRepo.Insert(fjt);
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteFactorJobType(int jobTypeId, int factorID)
        {
            try
            {
                var fjt = _FactorjobTypeRepo.GetAll().FirstOrDefault(p => p.FactorID == factorID & p.JobTypeID == jobTypeId) ?? new FactorJobTypeEnt();

                return _FactorjobTypeRepo.Delete(fjt.ID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
