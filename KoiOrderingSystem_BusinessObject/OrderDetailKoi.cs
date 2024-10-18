using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class OrderDetailKoi : BaseModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public bool isValid { get; set; }
        public int? KoiByBatchId { get; set; }
        public int? KoiId { get; set; }
        public int OrderKoiId { get; set; }
        public Koi? Koi { get; set; }
        public KoiByBatch? KoiByBatch { get; set; }
        public OrderKoi? OrderKoi { get; set; }
    }
}
