using Infrastructure.Entity;
using Infrastructure.Entity.newAdded;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models.Price
{
    public class PriceViewModel
    {
        [Range(0, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int Width { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int Height { get; set; }

        public double Lineal { get; set; }
        public double Square { get; set; }

        [Display(Name = "Glass Type")]
        public int GlassTypeID { get; set; }

        public int GlassExtraPrice { get; set; }
        public List<GlassTypeEnt> ListGlassType { get; set; }

        [Display(Name = "Glass Thicknes")]
        public int GlassThicknesID { get; set; }

        [Display(Name = "Glass Strength")]
        public int GlassStrengthID { get; set; }

        public int FabricationCategoryID { get; set; }

        [Display(Name = "Glass Option")]
        public int FabricationID { get; set; }

        [Display(Name = "Glass Option")]
        public int GlassOptionID { get; set; }

        public int Edgework { get; set; }
        public int EdgeworkNumber { get; set; }
        public List<FabricationEnt> FabricationList { get; set; }
        public List<FabricationEnt> ListEdgeWork { get; set; }
        public double UnitPrice { get; set; }
        public double UnitFuleSurcharge { get; set; }
        public double TotalUnitCost { get; set; }
        public double BenefitsPercentage { get; set; }
        public double CreditCardFee { get; set; }
        public double FinalPrice { get; set; }
        public double GlassPricePerunit { get; set; }
        public double TotalGlassPrice { get; set; }

        //newAdded
        public List<newGlassType> ListnewGlassType { get; set; }

        public List<newFrameType> ListnewFrameType { get; set; }
    }
}