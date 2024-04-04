

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class OrderNoteEnt : EntityBase<long>
    {
        public long OrdreID { get; set; }
     //   public virtual OrderNoteEnt Order { get; set; }
        public string? Note { get; set; }


    }



}