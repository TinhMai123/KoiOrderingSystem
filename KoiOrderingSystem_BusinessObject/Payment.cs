using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class Payment : BaseModel
    {
        public int PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? TransactionId { get; set; }
        public string? PaymentStatus { get; set; }
        public string? OrderId { get; set; }
        public string? CurrencyId { get;set; }
        public Order? Order { get; set; }
        public Currency? Currency { get; set; }
    }
}
