

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class ProductCategoryEnt : EntityBase<int>
    {
        [Display(Name = "عنوان")]
        public string? Title { get; set; }
        [Display(Name = "اولویت")]
        public int Priority { get; set; }

    }




}