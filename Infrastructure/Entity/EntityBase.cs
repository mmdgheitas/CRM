using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Infrastructure.Entity
{
 
    public abstract class EntityBase<T> 
    {
     [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
     [Key]
        public  T ID { get; set; }
        [Display(Name = "last modified : ")]
        public  string? modifiedInfo { get; set; }

    
    }

    public enum UserType
    {
        User = 1,//Customer
        Admin = 2,
        Estimator = 3,
        Installer = 4,
        Commerical = 5,
        Installer_Estimator = 6,
        Billing = 7,

        Shipping = 8,
        Store = 9,
        ProjectManager  = 10



    }
}
