

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class CategoryEnt : EntityBase<int>
    {
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [NotMapped]
        public int NumberOfUsed { get; set; }
        [NotMapped]
        public double SumAmount { get; set; }

        public CategoryEnt()
        {
        }
    }



}