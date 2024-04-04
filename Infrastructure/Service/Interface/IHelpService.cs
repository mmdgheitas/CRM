using Infrastructure.Entity;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface IHelpService 
    {
        List<HelpEnt> ListAllHelps();
      
    
    }
}
