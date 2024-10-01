using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class Trip
    {
        public Trip()
        {
            CheckIns = new HashSet<CheckIn>();
            Orders = new HashSet<Order>();
        }

        public int TripId { get; set; }
        public int? FarmId { get; set; }
        public DateTime? TripDate { get; set; }
        public decimal? Price { get; set; }
        public string? Duration { get; set; }
        public int? MaxParticipants { get; set; }
        public int? MinParticipants { get; set; }
        public string? Transportation { get; set; }
        public string? MeetingLocation { get; set; }
        public string? IncludedServices { get; set; }
        public string? NotIncludedServices { get; set; }
        public string? SpecialInstructions { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Farm? Farm { get; set; }
        public virtual ICollection<CheckIn> CheckIns { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
