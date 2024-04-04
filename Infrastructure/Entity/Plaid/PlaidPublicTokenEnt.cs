

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class PlaidPublicTokenEnt : EntityBase<int>
    {

        public string? PublicToken { get; set; }
        public string? AccessToken { get; set; }
        public string? BankName { get; set; }
        public DateTime RegisterDate { get; set; }
        public string? OtherInformation { get; set; }
        public bool isDefault { get; set; }
        public bool AddAccount { get; set; }
        public bool AddTransaction { get; set; }
    }

    public class PlaidPublicTokenViewModel : EntityBase<int>
    {

    
        public string BankName { get; set; }
        public DateTime RegisterDate { get; set; }
        public string OtherInformation { get; set; }
        public bool isDefault { get; set; }
        public bool AddAccount { get; set; }
        public bool AddTransaction { get; set; }
   
    }
}