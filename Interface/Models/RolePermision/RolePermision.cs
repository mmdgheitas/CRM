using Infrastructure.Entity;
using Interface.Data;
using Interface.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interface.Models
{
    public class RolePermisionModel
    {
        public bool Selected { get; set; }
        public int ID { get; set; }
        [Display(Name = "نام اکشن")]
        public string ActionName { get; set; }

        [Display(Name = "نام اکشن")]
        public string ActionCategory { get; set; }
        public string ActionTitle { get; set; }
        public int DisplayOrder { get; set; }
        public string fontAwesome { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Delete { get; set; }

    }

    public class MyRole
    {
        public string Id { get; set; }
        [Display(Name = "نام نقش")]
        public string Name { get; set; }
        public string description { get; set; }
     //   public byte type { get; set; }
        public virtual RoleType type { get; set; }
        public string fontawesome { get; set; }
        public List<RolePermisionModel> RolePermision { get; set; }
        public string title { get; set; }
        public string price { get; set; }

        public  string mainPrice { get; set; }
        public int libraryPrice { get; set; }
        public  string discountPercent { get; set; }
        public  bool popular { get; set; }
        public string popularStr { get; set; }
        public string dayNumber { get; set; }
        public int OrderID { get; set; }
        public bool Visible { get; set; }
        public string VisibleStr { get; set; }
        public bool Gift { get; set; }
        public string GiftStr { get; set; }
        public bool isDefault { get; set; }
        public string isDefaultStr { get; set; }
        //--


    }


    public class ListMyRole
    {
        public List<MyRole> ListRole { get; set; }
        public int PercentOfLibrary { get; set; }
    }

    public class ControllerActions
    {
        public string cTitle { get; set; }
        public string cName { get; set; }
        public bool cAvailable { get; set; }
        public IEnumerable<Action> ActionLists { get; set; }
    }
    public class Action
    {
        public string aTitle { get; set; }
        public string Name { get; set; }
        public bool aAvailable { get; set; }
        public bool HttpPost { get; set; }
        public string ActionCategory { get; set; }
        public ActionType ActionType { get; set; }
        public string ControllerTitle { get; set; }
    }

}