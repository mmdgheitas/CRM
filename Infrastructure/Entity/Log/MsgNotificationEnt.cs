

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    // You can add profile data for the user by adding more properties to your UserEnt class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class MsgNotificationEnt : EntityBase<long>
    {

        public DateTime Date { get; set; }
        public string? UserID { get; set; }
        public bool forAll { get; set; }
        public bool forAdmin { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ReadIDs { get; set; }
        [NotMapped]
        public bool Read { get; set; }
        public string? AlertIDs { get; set; }
        public MsgNotificationEnt()
        {
            forAll = false;
            forAdmin = false;
        }
    }
    public class MsgNotificationModel : EntityBase<long>
    {

        public DateTime Date { get; set; }
        public string UserID { get; set; }
        public bool forAll { get; set; }
        public bool forAdmin { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Read { get; set; }
        public bool Alert { get; set; }
        public MsgNotificationModel()
        {
            forAll = false;
            Read = false;
            Alert = false;
            forAdmin = false;
        }
    }

}