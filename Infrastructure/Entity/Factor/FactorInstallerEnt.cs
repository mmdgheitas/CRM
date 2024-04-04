

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class FactorInstallerEnt : EntityBase<int>
    {
        public string? InstallerId { get; set; }
        public int FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
    }
    public class FactorInstallerModel : EntityBase<int>
    {
        public string InstallerId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int FactorID { get; set; }
        public virtual FactorEnt Factor { get; set; }
        public bool Selected { get; set; }

    }
}