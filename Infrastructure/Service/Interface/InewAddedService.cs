using Infrastructure.Entity;
using Infrastructure.Entity.newAdded;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface InewAddedService
    {
        List<newGlassType> ListAllnewGlassTypes();

        List<newFrameType> ListAllnewFrameTypes();
    }
}