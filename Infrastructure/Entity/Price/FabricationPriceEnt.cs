

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class FabricationPriceEnt : EntityBase<int>
    {
       
        public int GlassThicknesID { get; set; }
        public virtual GlassThicknesEnt GlassThicknes { get; set; }
        public int FabricationID { get; set; }
        public virtual FabricationEnt Fabrication { get; set; }
        public int GlassStrengthID { get; set; }
        public byte Sqf25 { get; set; }//sqf25 = 1 (up to 25) ,sqf25 = 0  (cut to size and laminated glass) ,sqf25 = 2(over 25 foot) 

       // public byte MyProperty { get; set; }
        public double Price { get; set; }
        [NotMapped]
        public int GlassTypeID { get; set; }
        public FabricationPriceEnt()
        {
         
        }
    }
    public class FabricationPriceModel : EntityBase<int>
    {

        public int GlassThicknesID { get; set; }
        public virtual GlassThicknesEnt GlassThicknes { get; set; }
        public int FabricationID { get; set; }
        public virtual FabricationEnt Fabrication { get; set; }
        public int GlassStrengthID { get; set; }
        public int GlassTypeID { get; set; }
        public double Price { get; set; }

        public string htmlID { get; set; }
        [Display(Name = "Square Foot")]
        public byte Sqf25 { get; set; }
    }




}