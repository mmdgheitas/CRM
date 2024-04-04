

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class FactorJobTypeEnt : EntityBase<int>
    {
        public int JobTypeID { get; set; }
        public virtual JobTypeEnt JobType { get; set; }
        public int FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
    }
    public class FactorJobTypeModel : EntityBase<int>
    {
        public int JobTypeID { get; set; }
        public virtual JobTypeEnt JobType { get; set; }
        public int FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
        public bool Selected { get; set; }
    }
}