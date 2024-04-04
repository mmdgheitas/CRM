

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class ShippingEnt : EntityBase<int>
    {
        [Required(ErrorMessage = "Title is required")]
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}