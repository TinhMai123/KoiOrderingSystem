using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class Order : BaseModel
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? Status { get; set; }
        public string? ShippingAddress { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int OrderKoiId { get; set; }
        public User? Customer { get; set; }
        public ICollection<OrderKoi>? OrderKois { get; set; }
        public  ICollection<OrderTrip>? Trips { get; set; }
        public  ICollection<Payment>? Payments { get; set; }
    }
}
