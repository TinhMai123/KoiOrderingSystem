using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class FarmKoiType : BaseModel
    {
        public int Id { get; set; }
        public int FarmId { get; set; }
        public int KoiTypeId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public KoiType? KoiType { get; set; }
        public Farm? Farm { get; set; }
    }
}
