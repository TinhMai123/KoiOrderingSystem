using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class Payment : BaseModel
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public decimal PaymentAmount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        //public string TransactionId { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public int OrderId { get; set; }
        public int CurrencyId { get;set; }
        public Order? Order { get; set; }
        public Currency? Currency { get; set; }
    }
}
