

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Entity
{


    public class ItemEnt : EntityBase<long>
    {
        
        public string? Name { get; set; }
        public int ItemCategoryID { get; set; }
        public  ItemCategoryEnt ItemCategory  { get; set; }
     //   public bool Taxable { get; set; }
        public string? Details { get; set; }
        public string? Image { get; set; }
        public bool Enable { get; set; }
   
       // public virtual ICollection<Factor_ItemEnt> Factor_Items { get; set; }


        public ItemEnt()
        {
            Enable = true;
           // Factor_Items = new HashSet<Factor_ItemEnt>();
        }
    }

    public class ItemModel : EntityBase<long>
    {
       // [Required]
        public string Name { get; set; }
      //  [Required]
        public int ItemCategoryID { get; set; }
        public virtual ItemCategoryEnt ItemCategory { get; set; }
        [Display(Name = "Description")]
        public string Details { get; set; }
    //    public bool Taxable { get; set; }
        public List<ItemModifireModel> ListModifire { get; set; }
        public string Image { get; set; }
        [Display(Name = "Image")]
        public IFormFile FileUpload { get; set; }
        public List<ItemModifireAnswerEnt> ListAnswer { get; set; }
        public bool Enable { get; set; }

        public ItemModel()
        {
            Enable = true;
        }
    }



}