

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

using System.Web;

namespace Infrastructure.Entity
{
    public class SubmitSignEnt : EntityBase<long>
    {
        public string? UserID { get; set; }
        public int FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
        public DateTime SubmitDate { get; set; }

        [Display(Name = "Electronic Signature")]
        public string? ElectronicSignature { get; set; }
        public byte[] ElectronicSignatureByte { get; set; }
   
        public string? PrintName { get; set; }
        public SubmitSignEnt()
        {
        }
    }
  

}
  
