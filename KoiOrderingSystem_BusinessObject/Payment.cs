using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? OrderId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? TransactionId { get; set; }
        public string? PaymentStatus { get; set; }
        public string? Currency { get; set; }
        public double? ExchangeRate { get; set; }
        public string? PaymentNote { get; set; }
        public string? ProcessedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public decimal? RefundAmount { get; set; }

        public virtual Order? Order { get; set; }
    }
}
