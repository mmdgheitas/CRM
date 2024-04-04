

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class CityEnt : EntityBase<int>
    {
        [Display(Name = "State")]
        public int StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public virtual StateEnt State { get; set; }
        [StringLength(50)]
        [Display(Name = "City Name")]
     
        public string? CityName { get; set; }
        [Display(Name = "Tax (%)")]
        public decimal Tax { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [StringLength(50)]
        public string? County { get; set; }

        public CityEnt()
        {
            Tax = 0;
        }
    }

    public class StateEnt : EntityBase<int>
    {
        //public StateEnt() {
        //    Cities = new HashSet<CityEnt>();
        //}
        [StringLength(100)]
        [Display(Name = "State Name")]
        public string StateName { get; set; }
      //  public virtual ICollection<CityEnt> Cities { get; set; }

    }





}