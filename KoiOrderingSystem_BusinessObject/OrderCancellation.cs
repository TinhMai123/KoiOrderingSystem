using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class OrderCancellation
    {
        public int CancellationId { get; set; }
        public int? OrderId { get; set; }
        public DateTime? CancellationDate { get; set; }
        public string? Reason { get; set; }
        public decimal? RefundAmount { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Order? Order { get; set; }
    }
}
