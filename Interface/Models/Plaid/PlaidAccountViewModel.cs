using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Acklann.Plaid.Entity;
using Infrastructure.Entity;


namespace Interface.Models.Plaid
{
    public class PlaidAccountViewModel : EntityBase<int>
    {


        public string AccountId { get; set; }
        public int PlaidPublicTokenID { get; set; }
        public virtual PlaidPublicTokenEnt PlaidPublicToken { get; set; }
        public string ItemId { get; set; }

        public string InstitutionId { get; set; }

        public string Name { get; set; }

        public string Mask { get; set; }

        public string Type { get; set; }

        public string SubType { get; set; }
        public string CardNumber { get; set; }

        #region Balance
        public decimal Current { get; set; }

        public decimal? Available { get; set; }

        public decimal? Limit { get; set; }

        public string ISOCurrencyCode { get; set; }

        public string UnofficialCurrencyCode { get; set; }
        #endregion


        #region Owner
        public string Names { get; set; }

        public string PhoneNumbers { get; set; }

        public string Emails { get; set; }

        public string Addresses { get; set; }
        #endregion

        public string JsonData { get; set; }
        public Account Account { get; set; }

    }
}