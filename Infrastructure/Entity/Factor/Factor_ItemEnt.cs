

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Entity
{
    public class Factor_ItemEnt : EntityBase<long>
    {
        public int Quantity { get; set; }
        public int FacrorID { get; set; }
    //    public virtual FactorEnt Factor { get; set; }
        [Display(Name = "Item")]
        public long ItemID { get; set; }
       // [ForeignKey(nameof(ItemID))]
        public virtual ItemEnt Item { get; set; }
        public string? ItemText { get; set; }

        public string?  ItemTextVandorEmail { get; set; }
        [Display(Name = "Vandor")]
        public int VandorID { get; set; }
        public double ItemNumber { get; set; }
        public virtual VandorEnt Vandor { get; set; }
        [Display(Name = "Shipping")]


        public int ShippingID { get; set; }
        public virtual ShippingEnt Shipping { get; set; }
        [Display(Name = "Status")]
        public ItemStatus ItemStatus { get; set; }
        [Display(Name = "$/Each")]
        public int EachPrice { get; set; }
        public int Total { get; set; }
        public bool IsItemAdded { get; set; }
        public string?  TechnicalNote { get; set; }
        [Display(Name = "Time for install")]
        public int InstallTime { get; set; }
        [Display(Name = "Laber")]
        public int LaberNumber { get; set; }
        public bool Taxable { get; set; }
        public string?  Photo { get; set; }
        
        public string?  Photo2 { get; set; }
        [NotMapped]
        public List<FactorItem_ImageEnt> Images { get; set; }
        [NotMapped]
        public string? ShippingAddress { get; set; }
        [NotMapped]
        public string?  OrderEDD { get; set; }
        [NotMapped]     
        public FactorItemTimeEnt FactorItemTime { get; set; }
        public Factor_ItemEnt()
        {
            Taxable = true;
        }
    }



    public class Factor_ItemModel : EntityBase<long>
    {
        public int Quantity { get; set; }
        public int FacrorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
        [Display(Name = "Item")]
        public long ItemID { get; set; }
        public long ItemImageID { get; set; }
        public virtual ItemEnt Item { get; set; }
        public string ItemText { get; set; }
        [Display(Name = "Vandor")]
        public int VandorID { get; set; }
        public double ItemNumber { get; set; }
        public virtual VandorEnt Vandor { get; set; }
        [Display(Name = "Shipping")]

        public int ShippingID { get; set; }
        public virtual ShippingEnt Shipping { get; set; }
        [Display(Name = "Status")]
        public ItemStatus ItemStatus { get; set; }
        [Display(Name = "$/Each")]
        public int EachPrice { get; set; }
        public int Total { get; set; }
        public bool IsItemAdded { get; set; }
        public string TechnicalNote { get; set; }
        [Display(Name = "Time for install")]
        public int InstallTime { get; set; }
        [Display(Name = "Laber")]
        public int LaberNumber { get; set; }
        [Display(Name = "Taxable")]
        public bool Taxable { get; set; }
        public string? Photo { get; set; }
        
        public string Photo2 { get; set; }
        public FactorItemPhotoNumber PhotoNumber { get; set; }

        [Display(Name = "drag and drop of select file upload")]
        public List<IFormFile> FileUpload { get; set; }
        //File enable for these users
        public bool Customers { get; set; }
        public bool Installers { get; set; }
        public bool Estimators { get; set; }
        public bool Vandors { get; set; }
        [Display(Name = "Comment (Optional)")]
        public string? ImageComment { get; set; }

        public List<Factor_ItemEnt> ListItems { get; set; }
        public List<FactorItem_ImageEnt> ListJobImage { get; set; }
        public Factor_ItemModel()
        {
            Taxable = true;
            PhotoNumber = FactorItemPhotoNumber.Photo1;
        }


    }
    public enum FactorItemPhotoNumber
    {
        Photo1 = 1,
        Photo2 = 2
    }
    public class FactorItemReport
    {
        public int Quantity { get; set; }

        public string ItemText { get; set; }

        public double ItemNumber { get; set; }
        public string TechnicalNote { get; set; }
        public string ShippingAddress { get; set; }
    }


    public class Factor_ItemReportViewmodel : EntityBase<long>
    {
        public int Quantity { get; set; }
        public int FacrorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
        [Display(Name = "Item")]
        public long ItemID { get; set; }
        public virtual ItemEnt Item { get; set; }
        public string ItemText { get; set; }
        public string ItemTextVandorEmail { get; set; }
        [Display(Name = "Vandor")]
        public int VandorID { get; set; }
        public double ItemNumber { get; set; }
        public virtual VandorEnt Vandor { get; set; }
        [Display(Name = "Shipping")]


        public int ShippingID { get; set; }
        public virtual ShippingEnt Shipping { get; set; }
        [Display(Name = "Status")]
        public ItemStatus ItemStatus { get; set; }
        [Display(Name = "$/Each")]
        public int EachPrice { get; set; }
        public double Total { get; set; }
        public bool IsItemAdded { get; set; }
        public string TechnicalNote { get; set; }
        [Display(Name = "Time for install")]
        public int InstallTime { get; set; }
        [Display(Name = "Laber")]
        public int LaberNumber { get; set; }
        public bool Taxable { get; set; }
        public string Photo { get; set; }
        [NotMapped]
        public List<FactorItem_ImageEnt> Images { get; set; }
        [NotMapped]
        public string ShippingAddress { get; set; }
        [NotMapped]
        public string OrderEDD { get; set; }

    }
}