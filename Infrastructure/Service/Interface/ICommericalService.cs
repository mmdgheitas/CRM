using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface ICommericalService
    {
    

        List<ProviderEnt> ListAllProviders();
        bool DeleteProvider(int id);
        ProviderEnt ProviderDetails(int id);
        bool AddProvider(ProviderEnt item);
        bool EditProvider(ProviderEnt item);

        bool IFExistProviderCompany(string comapny, int iD);
        bool IsDefaultProvider(int id);
    }
}
