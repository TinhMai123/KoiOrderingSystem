using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_BusinessObject
{
    public class OrderKoi : BaseModel
    {
        public int Id { get; set; }
        public string ShippingType { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        public ICollection<OrderKoiDetail> OrderDetailKois { get; set; } = new List<OrderKoiDetail>();

    }
}
