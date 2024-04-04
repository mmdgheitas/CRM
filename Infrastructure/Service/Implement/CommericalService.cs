using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Implement
{
    public class CommericalService : ICommericalService
    {
   
        IRepositoryBase<ProviderEnt, int> _providerRepo;

        public CommericalService(IRepositoryBase<ProviderEnt, int> _providerRepo)
        {
            this._providerRepo = _providerRepo;
        }



        public bool AddProvider(ProviderEnt item)
        {
            try
            {
                return _providerRepo.Insert(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool DeleteProvider(int id)
        {
            try
            {
                return _providerRepo.Delete(id);

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool EditProvider(ProviderEnt item)
        {
            try
            {
                return _providerRepo.Update(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public ProviderEnt ProviderDetails(int id)
        {
            try
            {
                return _providerRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public List<ProviderEnt> ListAllProviders()
        {
            try
            {
                return _providerRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

    

        public bool IFExistProviderCompany(string comapny, int iD)
        {
            try
            {
                if (iD == 0)
                    return _providerRepo.GetAll().Any(p => p.Comapny == comapny);
                else
                    return _providerRepo.GetAll().Any(p => p.Comapny == comapny & p.ID != iD);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsDefaultProvider(int id)
        {
            try
            {
                return _providerRepo.GetAll().Any(p => p.ID == id & p.isDefault);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
