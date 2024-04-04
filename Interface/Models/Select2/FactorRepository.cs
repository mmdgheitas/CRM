using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Implement;
using Infrastructure.Service.Interface;
using Interface.Models.Factor;
using Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Interface.Models.Select2
{
    public class FactorRepository
    {
    

   
   
        public IQueryable<FactorModel> Factors { get; set; }

        public  FactorRepository()
        {

           
        }

        //Return only the results we want
        public async Task<List<FactorModel>> GetFactors(IQueryable<FactorModel> factors,string searchTerm, int pageSize, int pageNum)
        {
            Factors = factors;
            return (await GetFactorsQuery(searchTerm))
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize)
                .ToList();
        }

        //And the total count of records
        public async Task<int> GetFactorsCount(string searchTerm, int pageSize, int pageNum)
        {
            var list = await GetFactorsQuery(searchTerm);
            return list.Count();
        }
        //Our search term
        private async Task<IQueryable<FactorModel>> GetFactorsQuery(string searchTerm)
        {
            searchTerm = searchTerm.ToLower().TrimEnd(' ').TrimStart(' ');
            var result = Factors
                .Where(
                    a =>
                    (a.PONumber.ToString() + a.UserInfo.PhoneNumber.ToString() + a.UserInfo.Email.ToLower() + a.UserInfo.SecondEmail.ToLower() + a.UserInfo.FirstName.ToLower() + a.UserInfo.Address.ToLower() + a.OrderToAddress.ToLower() + a.ProjectName.ToLower()).Contains(searchTerm.ToLower())
                    //search by project address
                );

            if (result.Count() == 0)
            {
                var list = result.ToList();
                list.Add(new FactorModel() { ID = 0, PONumber = 0, PhoneNumber = "0", UserInfo = new User() { Email = "", FirstName = searchTerm, Id = "" } });
                result = list.AsQueryable();

            }

            return result;
        }

        //Generate test data
    
    }
}