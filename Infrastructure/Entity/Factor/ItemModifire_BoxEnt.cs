

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class ItemModifire_BoxEnt : EntityBase<long>
    {
        [Display(Name = "Text")]
        public string? Text { get; set; }
        public long ItemModifireID { get; set; }
        public virtual ItemModifireEnt ItemModifire { get; set; }

        public ItemModifire_BoxEnt()
        {
        }

     

    }



}
