

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Entity
{
    public class OrderEnt : EntityBase<long>
    {
        public double ItemNumber { get; set; }
        public long FactorItemID { get; set; }
        [NotMapped]
        public virtual Factor_ItemEnt Factor_Item { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? EDDDate { get; set; }
        public DateTime ReciveDate { get; set; }
        public int vandorID { get; set; }
        [NotMapped]
        public VandorEnt vandor { get; set; }
        public int ShippingID { get; set; }
        [NotMapped]
        public ShippingEnt Shipping { get; set; }
        public bool Delivered { get; set; }
        public string? DeliveredUserName { get; set; }
        public string? PDF { get; set; }

        public OrderEnt()
        {
          
        }
    }


    public class OrderModel : EntityBase<long>
    {
        public double ItemNumber { get; set; }
        public long FactorItemID { get; set; }
        public virtual Factor_ItemEnt Factor_Item { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReciveDate { get; set; }
        public string OrderDateStr { get; set; }
        public string ReciveDateStr { get; set; }
        public DateTime? EDDDate { get; set; }
        public string EDDStr { get; set; }
        public int vandorID { get; set; }
        public virtual VandorEnt vandor { get; set; }
        public int ShippingID { get; set; }
        public virtual ShippingEnt Shipping { get; set; }
        public string PDF { get; set; }
        public int OrderBoxinItemList { get; set; }
        public bool Delivered { get; set; }
        public string DeliveredStr { get; set; }
        public string DeliveredUserName { get; set; }
        public string Status { get; set; }
        public List<OrderNoteEnt> Notes { get; set; }

        public OrderModel()
        {

        }
    }


}