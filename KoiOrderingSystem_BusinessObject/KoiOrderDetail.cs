using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class KoiOrderDetail : BaseModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? KoiId { get; set; }
        public Koi? Koi { get; set; }
        public int? KoiByBatchId { get; set; }
        public KoiByBatch? KoiByBatch { get; set; }
        public int KoiOrderId { get; set; }
        public KoiOrder? KoiOrder { get; set; }
    }
}
