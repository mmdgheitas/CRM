

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
    public class FactorItem_ImageEnt : EntityBase<long>
    {
        public long? Factor_ItemID { get; set; }
        public virtual Factor_ItemEnt Factor_Item { get; set; }
        public int FactorID { get; set; }
        public string? Image { get; set; }
        public string? FileName { get; set; }
        public string? Type { get; set; }
        public string? Title { get; set; }
        //File enable for these users
        public bool Customers { get; set; }
        public bool Installers { get; set; }
        public bool Estimators { get; set; }
        public bool Vandors { get; set; }
        public string? Comment { get; set; }
        public InstallerUploadItemType UploadItemType { get; set; }
  


        [NotMapped]
        public bool Select { get; set; }
        [NotMapped]
        public bool Added { get; set; }
        public FactorItem_ImageEnt()
        {
            FileName = "";
        }
    }
    public enum InstallerUploadItemType
    {
        None = 0,
        Start = 1,
        Complete = 2,
        Incomplete = 3,

    }
    public class FactorItem_ImageModel : EntityBase<long>
    {
        public long? Factor_ItemID { get; set; }
        public virtual Factor_ItemEnt Factor_Item { get; set; }
        [Display(Name = "Project")]
        public int? FactorID { get; set; }
        public string Image { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        [Display(Name = "Type")]
        public string Title { get; set; }
        //File enable for these users
        public bool Customers { get; set; }
        public bool Installers { get; set; }
        public bool Estimators { get; set; }
        public bool Vandors { get; set; }
        [Display(Name = "Comment (optional)")]
        public string?   Comment { get; set; }
        [Display(Name = "Upload Files *")]
        public List<IFormFile> FileUpload { get; set; }

        public List<FactorEnt> ListFactor { get; set; }
        public FactorItem_ImageModel()
        {
            FileName = "";
        }
    }

    public class UnsortedGallery : EntityBase<long>
    {
    
        [Display(Name = "Project")]
        public int FactorID { get; set; }
        public string File { get; set; }
        public string Image { get; set; }
        public string FileName { get; set; }
        public string Type { get; set; }
        [Display(Name = "Type")]
        public string Title { get; set; }
        //File enable for these users
        public bool Customers { get; set; }
        public bool Installers { get; set; }
        public bool Estimators { get; set; }
        public bool Vandors { get; set; }
        public string Comment { get; set; }
    
        public List<FactorEnt> ListFactor { get; set; }
      
    }



}