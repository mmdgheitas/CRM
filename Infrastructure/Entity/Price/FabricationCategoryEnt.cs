

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class FabricationCategoryEnt : EntityBase<int>
    {
        public string? Title { get; set; }
   


        public FabricationCategoryEnt()
        {
         
        }
    }


  
}