

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Infrastructure.Entity
{
    public class CustomerRequestEnt : EntityBase<int>
    {
        public string? RequestText { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? ZipCode { get; set; }
        public string? Phone { get; set; }
        public DateTime DateTime { get; set; }
        public bool CrateUser { get; set; }
        public int FactorID { get; set; }

        [NotMapped]
        public string? UpdateBtn { get; set; }
        [NotMapped]
        public List<ItemModifireAnswerEnt> ListAnswers { get; set; }
        [NotMapped]
        public List<CustomerRequest_ItemEnt> ListItems { get; set; }
        [NotMapped]
        public long ItemID { get; set; }//Last Item ID
    }
    public class ItemRequest
    {
        public List<ItemModifireModel> ListModifire { get; set; }
        public int Step { get; set; }
        public int ModifireId { get; set; }
        public int ItemId { get; set; }
        public int CustomerRequestID { get; set; }
        public List<ItemModifireAnswerEnt> ListAnswers { get; set; }
        public List<ItemEnt> ListItemSelected { get; set; }
        public CustomerRequestModel CustomerRequest { get; set; }
        /// <summary>
        /// Customer Request Page
        /// </summary>
        public List<ItemModel> ListItem { get; set; }

    }
    public class CustomerRequestModel : EntityBase<int>
    {
        public string RequestText { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Phone must be 10 digit number")]
        public string Phone { get; set; }
        public long ItemID { get; set; }
        public virtual ItemEnt Item { get; set; }
        [NotMapped]
        public string UpdateBtn { get; set; }
        [NotMapped]
        public List<ItemModifireAnswerEnt> ListAnswers { get; set; }
        public DateTime DateTime { get; set; }
        [NotMapped]

        public string DateTimeStr { get; set; }
    }


}