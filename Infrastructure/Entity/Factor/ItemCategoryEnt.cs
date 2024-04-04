

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class ItemCategoryEnt : EntityBase<int>
    {

        [Required]
        public string Name { get; set; }
        public ItemCategoryEnt()
        {
        }
    }


  
}