using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class Order : BaseModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int? OrderKoiId { get; set; }
        public User? Customer { get; set; }
        public ICollection<OrderKoi> OrderKois { get; set; } = new List<OrderKoi>();
        public ICollection<OrderTrip> Trips { get; set; } = new List<OrderTrip>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Quote> Quotes { get; set; } = new List<Quote>();
    }
}
