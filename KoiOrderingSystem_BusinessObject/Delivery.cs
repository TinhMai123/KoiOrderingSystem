using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class Delivery
    {
        public int DeliveryId { get; set; }
        public int? OrderId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? DeliveryStatus { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? DeliveryNote { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Order? Order { get; set; }
    }
}
