using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class Order
    {
        public Order()
        {
            Deliveries = new HashSet<Delivery>();
            Feedbacks = new HashSet<Feedback>();
            OrderCancellations = new HashSet<OrderCancellation>();
            OrderDetails = new HashSet<OrderDetail>();
            OrderProcesses = new HashSet<OrderProcess>();
            Payments = new HashSet<Payment>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? TripId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? Status { get; set; }
        public int? PaymentStatus { get; set; }
        public string? ShippingAddress { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public bool? IsGift { get; set; }
        public string? GiftMessage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? CancellationStatus { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Trip? Trip { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<OrderCancellation> OrderCancellations { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<OrderProcess> OrderProcesses { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
