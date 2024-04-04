

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class GlassOptionEnt : EntityBase<int>
    {
        public string? Title { get; set; }
     
      
        public int Value { get; set; }

        public GlassOptionEnt()
        {
         
        }
    }
    


  
}