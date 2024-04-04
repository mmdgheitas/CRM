

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    // You can add profile data for the user by adding more properties to your UserEnt class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class StatusNotificationEnt : EntityBase<int>
    {

        public FactorStatus status { get; set; }
        [NotMapped]
        public string? StatusStr { get; set; }
        public string? NotificationText { get; set; }
        public StatusNotificationEnt()
        {

        }


    }


}