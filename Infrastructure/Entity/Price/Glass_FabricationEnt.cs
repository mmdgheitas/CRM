

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class Glass_FabricationEnt : EntityBase<int>
    {
        public int GlassTypeID { get; set; }
        public virtual GlassTypeEnt GlassType { get; set; }
        public int FabricationID { get; set; }
        public virtual FabricationEnt Fabrication { get; set; }

   
        public Glass_FabricationEnt()
        {
         
        }
    }


  
}