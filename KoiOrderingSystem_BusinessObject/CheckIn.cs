using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class CheckIn
    {
        public int CheckInId { get; set; }
        public int? TripId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public string? CheckInStatus { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UserId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Trip? Trip { get; set; }
        public virtual User? User { get; set; }
    }
}
