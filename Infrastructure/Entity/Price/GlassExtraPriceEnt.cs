

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class GlassExtraPriceEnt : EntityBase<int>
    {
        public string? Title { get; set; }
        public double Price { get; set; }


        public GlassExtraPriceEnt()
        {
         
        }
    }
    


  
}