using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_BusinessObject
{
    public class Insurance : BaseModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string? Status {  get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
