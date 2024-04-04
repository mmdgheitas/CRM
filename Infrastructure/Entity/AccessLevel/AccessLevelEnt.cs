

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class AccessLevelEnt : EntityBase<long>
    {
        public string? AccessName { get; set; }
        public DateTime ActiveUntil { get; set; }
    }

}