using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface IAccessLevelService
    {
        List<AccessLevelEnt> ListAllAccessList();
        AccessLevelEnt AccessLevelDetails(long id);
        bool AddAccessLevel(AccessLevelEnt model);
        bool UpdateAccessLevel(AccessLevelEnt item);
        bool DeleteAccessLevel(long id);
        bool ifExistAccessLevel(string name, long id = 0);
        bool ifExistAccessLevel(string name, DateTime ActiveUntile);

    }
}
