using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Implement
{
    public class AccessLevelService : IAccessLevelService
    {
        IRepositoryBase<AccessLevelEnt, long> _accessLevelRepo;
        public AccessLevelService(IRepositoryBase<AccessLevelEnt, long> _accessLevelRepo)
        {
            this._accessLevelRepo = _accessLevelRepo;
        }

        public AccessLevelEnt AccessLevelDetails(long id)
        {
            try
            {
                return _accessLevelRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool AddAccessLevel(AccessLevelEnt model)
        {

            return _accessLevelRepo.Insert(model);

        }

        public bool DeleteAccessLevel(long id)
        {
            try
            {
                return _accessLevelRepo.Delete(id);
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool ifExistAccessLevel(string name, DateTime ActiveUntile)
        {

            return _accessLevelRepo.GetAll().Where(p => p.AccessName == name && p.ActiveUntil == ActiveUntile).Any();

        }

        public bool ifExistAccessLevel(string name, long id = 0)
        {
            try
            {
                if (id == 0)
                    return _accessLevelRepo.GetAll().Where(p => p.AccessName == name).Any();
                else
                    return _accessLevelRepo.GetAll().Where(p => p.AccessName == name & p.ID != id).Any();

            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<AccessLevelEnt> ListAllAccessList()
        {
            try
            {
                return _accessLevelRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool UpdateAccessLevel(AccessLevelEnt item)
        {
            try
            {
                return _accessLevelRepo.Update(item);
            }
            catch (Exception ex)
            {

                return false;
            }
        }



    }
}
