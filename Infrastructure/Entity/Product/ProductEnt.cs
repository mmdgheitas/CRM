

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class ProductEnt : EntityBase<int>
    {
        [Display(Name = "عنوان")]
        public string? Title { get; set; }
       [Display(Name = "قیمت")]
        public int Price { get; set; }
        [Display(Name = "تعداد")]
        public int Number { get; set; }
        [Display(Name = "توضیحات")]
        public int Description { get; set; }
        [Display(Name = "دسته بندی محصول")]
        public int ProductCategoryID { get; set; }
        public virtual ProductCategoryEnt ProductCategory { get; set; }
        [Display(Name = "اولویت نمایش")]
        public int Priority { get; set; }
    }

    public class ProductModel : EntityBase<int>
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا عنوان را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "قیمت")]
        public int Price { get; set; }
        [Display(Name = "تعداد")]
        [Required(ErrorMessage = "لطفا تعداد را وارد کنید")]
        public int Number { get; set; }
        [Display(Name = "توضیحات")]
        public int Description { get; set; }
        [Display(Name = "دسته بندی محصول")]
        public int ProductCategoryID { get; set; }
        public virtual ProductCategoryEnt ProductCategory { get; set; }
        public List<ProductCategoryEnt> ListProductCategory { get; set; }
        [Display(Name = "اولویت نمایش")]
        public int Priority { get; set; }
    }


}