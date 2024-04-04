

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class LastActivityEnt : EntityBase<long>
    {

    }

    public class LastActivityModel : EntityBase<long>
    {
        public string TableID { get; set; }
        public string TableName  { get; set; }
        public string FullName { get; set; }
        public string UserID { get; set; }
        public string Type { get; set; }
        public string DateTime { get; set; }
        public string URL { get; set; }
        public string modifiedInfo { get; set; }
    }



}