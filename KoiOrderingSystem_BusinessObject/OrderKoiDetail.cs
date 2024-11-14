using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class OrderKoiDetail : BaseModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? KoiId { get; set; }
        public Koi? Koi { get; set; }
        public int? KoiByBatchId { get; set; }
        public KoiByBatch? KoiByBatch { get; set; }
        public int OrderKoiId { get; set; }
        public OrderKoi? OrderKoi { get; set; }
    }
}
