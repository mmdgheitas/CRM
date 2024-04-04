

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class UserJobTypeEnt : EntityBase<int>
    {
        public int JobTypeID { get; set; }
        public virtual JobTypeEnt JobType { get; set; }
        public string? UserID { get; set; }
    }
    public class UserJobTypeModel : EntityBase<int>
    {
        public int JobTypeID { get; set; }
        public virtual JobTypeEnt JobType { get; set; }
        public string UserID { get; set; }
        public bool Selected { get; set; }
    }
}