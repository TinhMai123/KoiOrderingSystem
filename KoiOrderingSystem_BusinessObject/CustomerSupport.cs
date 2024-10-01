using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class CustomerSupport
    {
        public int SupportId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? RequestDescription { get; set; }
        public string? ResponseDescription { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
