using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime? FeedbackDate { get; set; }
        public int? ServiceRating { get; set; }
        public int? ProductRating { get; set; }
        public bool? WouldRecommend { get; set; }
        public string? PhotoUrl { get; set; }
        public bool? IsVerified { get; set; }
        public string? Reply { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Order? Order { get; set; }
    }
}
