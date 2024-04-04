

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class GlassType_OptionEnt : EntityBase<int>
    {
        public int GlassOptionID { get; set; }
        public virtual GlassOptionEnt GlassOption { get; set; }

        public int GlassTypeID { get; set; }
        public virtual GlassTypeEnt GlassType { get; set; }

       
    }
    public class GlassType_ThicknesEnt : EntityBase<int>
    {
        public int GlassThicknesID { get; set; }
        public virtual GlassThicknesEnt GlassThicknes { get; set; }

        public int GlassTypeID { get; set; }
        public virtual GlassTypeEnt GlassType { get; set; }


    }

    public class GlassType_StrengthEnt : EntityBase<int>
    {
        public int GlassStrengthID { get; set; }
        public virtual GlassStrengthEnt GlassStrength { get; set; }

        public int GlassTypeID { get; set; }
        public virtual GlassTypeEnt GlassType { get; set; }


    }



}