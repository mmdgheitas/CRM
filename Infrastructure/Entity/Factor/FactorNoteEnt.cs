

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class FactorNoteEnt : EntityBase<long>
    {
        public int? FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
        public string? Note { get; set; }
        public string?  FilePath { get; set; }
        public long FactorTaskID { get; set; }
    }
}