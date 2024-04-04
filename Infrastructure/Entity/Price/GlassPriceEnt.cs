

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class GlassPriceEnt : EntityBase<int>
    {
        public int GlassTypeID { get; set; }
        public int GlassOptionID { get; set; }
        public virtual GlassOptionEnt GlassOption { get; set; }
        public int GlassThicknesID { get; set; }
      //  public virtual GlassThicknesEnt GlassThicknes { get; set; }
        public int GlassStrengthID { get; set; }
        //public virtual GlassStrengthEnt GlassStrength { get; set; }

        public double Price { get; set; }

        public GlassPriceEnt()
        {
         
        }
    }
    


  
}