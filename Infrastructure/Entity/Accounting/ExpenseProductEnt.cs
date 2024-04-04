

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class ExpenseProductEnt : EntityBase<int>
    {
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        public string? Description { get; set; }

        public ExpenseProductEnt()
        {
        }
    }



}