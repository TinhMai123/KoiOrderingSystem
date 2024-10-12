using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_BusinessObject
{
    public class Currency : BaseModel
    {
        public int Id { get; set; }
        public string? Name {  get; set; }
        public double ExchangeRate { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
