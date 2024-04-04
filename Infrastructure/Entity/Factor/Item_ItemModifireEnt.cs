

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class Item_ItemModifireEnt : EntityBase<long>
    {
        public long Item_ID { get; set; }
   //     public virtual ItemEnt Item { get; set; }
        public long ItemModifireID { get; set; }
        public virtual ItemModifireEnt ItemModifire { get; set; }
        public int Priority { get; set; }
        public Item_ItemModifireEnt()
        {
        }
    }


  
}