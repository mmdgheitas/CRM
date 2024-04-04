

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class LogEnt : EntityBase<long>
    {
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string? UserFullName { get; set; }
        public string? UserID { get; set; }
        public byte Type { get; set; }
    }





}