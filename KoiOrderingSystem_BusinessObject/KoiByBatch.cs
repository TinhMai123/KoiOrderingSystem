using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_BusinessObject
{
    public class KoiByBatch : BaseModel
    {
        public int Id { get; set; }
        public int Quantity {  get; set; }
        public int Size {  get; set; }
        public decimal Price {  get; set; }
        public int KoiTypeId { get; set; }
        public int? OrderDetailKoiId { get; set; }
        public KoiType? KoiType { get; set; }
        public OrderDetailKoi? OrderDetailKoi { get; set; }
    }
}
