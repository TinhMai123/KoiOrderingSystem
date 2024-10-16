using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_BusinessObject
{
    public class Quote : BaseModel
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? SalesStaffId { get; set; }
        public decimal QuoteAmount { get; set; }
        public bool ApprovalStatus { get; set; }
        public Order? Order { get; set; }
        public User? SalesStaff { get; set; }
    }
}
