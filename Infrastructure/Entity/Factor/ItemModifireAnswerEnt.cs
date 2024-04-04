

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class ItemModifireAnswerEnt : EntityBase<long>
    {
        public string? Answer { get; set; }
        public string? AnswerJson { get; set; }
        public string? AnswerText { get; set; }
        [Display(Name = "FullName")]
        public string? FullName { get; set; }

        public string? UserID { get; set; }
        public DateTime AnsweredDate { get; set; }
        public long ItemModifireID { get; set; }
        public virtual ItemModifireEnt ItemModifire { get; set; }

        public long Factor_ItemID { get; set; }
        public long CustomerRequestID { get; set; }
        public int Step { get; set; }
        

    }








}