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
    public class CityService : ICityService
    {
        IRepositoryBase<CityEnt, int> _cityRepo;
        IRepositoryBase<StateEnt, int> _stateRepo;
        IRepositoryBase<ResellerPermitEnt, long> _resellerPermitRepo;

        public CityService(IRepositoryBase<CityEnt, int> _cityRepo,
           IRepositoryBase<StateEnt, int> _stateRepo, IRepositoryBase<ResellerPermitEnt, long> _sresellerPremitRepo
           )
        {
            this._cityRepo = _cityRepo;
            this._stateRepo = _stateRepo;
            this._resellerPermitRepo = _sresellerPremitRepo;

        }





        public List<StateEnt> ListState()
        {
            try
            {
                return _stateRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public List<CityEnt> ListCityByStateID(int id = 0)
        {
            try
            {
                var list = new List<CityEnt>();
                if (id == 0)
                    list = _cityRepo.GetAll().Include(p => p.State).ToList();
                else
                    list = _cityRepo.GetAll().Include(p => p.State).Where(p => p.StateId == id).ToList();


                return list.OrderBy(p => p.State.StateName).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CityEnt CityDetails(int cityID)
        {
            try
            {
                return _cityRepo.GetAll().FirstOrDefault(p => p.ID == cityID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CityEnt> CityDetailsAsync(int cityID)
        {
            try
            {
                return await _cityRepo.GetAllAsync().Where(p => p.ID == cityID).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteState(int id)
        {
            try
            {
                return _stateRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public StateEnt StateDetails(int id)
        {
            try
            {
                return _stateRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IFExistStateName(string stateName, int id = 0)
        {
            try
            {
                if (id == 0)
                    return _stateRepo.GetAll().Any(p => p.StateName == stateName);
                else
                    return _stateRepo.GetAll().Any(p => p.StateName == stateName & p.ID != id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddState(StateEnt model)
        {
            try
            {
                return _stateRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditState(StateEnt model)
        {
            try
            {
                model.modifiedInfo += " ";
                return _stateRepo.Update2(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCity(int id)
        {
            try
            {
                return _cityRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IFExistCityName(string cityName, int id = 0)
        {
            try
            {
                if (id == 0)
                    return _cityRepo.GetAll().Any(p => p.CityName == cityName);
                else
                    return _cityRepo.GetAll().Any(p => p.CityName == cityName & p.ID != id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddCity(CityEnt model)
        {
            try
            {
                return _cityRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditCity(CityEnt model)
        {
            try
            {
                return _cityRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<CityEnt> ListCities()
        {
            try
            {
                return _cityRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<CityEnt>> ListCitiesAsync()
        {
            try
            {
                return await _cityRepo.GetAllAsync().Include(p => p.State).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public decimal GetTaxOfCityID(int cityID)
        {
            try
            {
                var city = _cityRepo.GetAll().FirstOrDefault(p => p.ID == cityID);
                if (city == null)
                    return 0;
                else
                    return city.Tax;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<decimal> GetTaxOfCityIDAsync(int cityID)
        {
            try
            {
                var city = await _cityRepo.GetAllAsync().Where(p => p.ID == cityID).FirstOrDefaultAsync();
                if (city == null)
                    return 0;
                else
                    return city.Tax;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

  
    }
}
