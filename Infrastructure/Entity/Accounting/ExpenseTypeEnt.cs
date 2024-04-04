

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    //this table instance sub category
    public class ExpenseTypeEnt : EntityBase<int>
    {
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
        public string?  Description { get; set; }
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public virtual CategoryEnt Category { get; set; }

        public ExpenseTypeEnt()
        { 
        }
    }



}