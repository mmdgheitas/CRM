using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Entity;

namespace Infrastructure.Service.Interface
{
    public interface ICityService
    {
        List<StateEnt> ListState();
        List<CityEnt> ListCityByStateID(int id = 0);
        CityEnt CityDetails(int cityID);
        Task<CityEnt> CityDetailsAsync(int cityID);
        bool DeleteState(int id);
        StateEnt StateDetails(int id);
        bool IFExistStateName(string stateName, int iD);
        bool AddState(StateEnt model);
        bool EditState(StateEnt model);
        bool DeleteCity(int id);
        bool IFExistCityName(string cityName, int id = 0);
        bool AddCity(CityEnt model);
        bool EditCity(CityEnt model);
        List<CityEnt> ListCities();
       Task< List<CityEnt>> ListCitiesAsync();
        decimal GetTaxOfCityID(int cityID);
        Task<decimal> GetTaxOfCityIDAsync(int cityID);


 

    }
}
