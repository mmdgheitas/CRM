

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class PlaidAccountEnt : EntityBase<int>
    {


        public string? AccountId { get; set; }
        public int PlaidPublicTokenID { get; set; }
        public virtual PlaidPublicTokenEnt PlaidPublicToken { get; set; }
        public string? ItemId { get; set; }
  
        public string? InstitutionId { get; set; }
        [NotMapped]
        [Display(Name = "Bank Name")]
        public string? BankName { get; set; }
        [NotMapped]
        public int TransactionCount { get; set; }
        [Display(Name = "Account Name")]
        public string? Name { get; set; }
        [Display(Name = "Card Number")]
        public string? CardNumber { get; set; }

        public string? Mask { get; set; }
     
        public string? Type { get; set; }
            
        public string? SubType { get; set; }


        #region Balance
        public decimal Current {  get; set; }
      
        public decimal? Available {  get; set; }
        
        public decimal? Limit {  get; set; }
      
        public string? ISOCurrencyCode {  get; set; }

        public string? UnofficialCurrencyCode {  get; set; }
        #endregion


        #region Owner
        public string? Names { get; set; }
        
        public string? PhoneNumbers { get; set; }
       
        public string? Emails { get; set; }
    
        public string? Addresses { get; set; }
        #endregion

        public string? JsonData { get; set; }

    }
}