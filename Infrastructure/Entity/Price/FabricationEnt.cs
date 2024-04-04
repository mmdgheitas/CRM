

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class FabricationEnt : EntityBase<int>
    {
        public string? Title { get; set; }
        public double PerUnit { get; set; }
        public int FabricationCategoryID { get; set; }
        public virtual FabricationCategoryEnt FabricationCategory { get; set; }

        public double Value { get; set; }
        public FabricationEnt()
        {
         
        }
    }


  
}