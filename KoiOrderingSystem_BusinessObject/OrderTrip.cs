using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class OrderTrip : BaseModel
    {

        public int Id { get; set; }
        public DateTime? TripStartDate { get; set; }
        public DateTime? TripEndDate { get; set; }
        public int? MaxParticipants { get; set; }
        public bool IsActive { get; set; } = true;
        public int OrderId { get; set; }
        public int FarmId { get; set; }
        public int? ConsultantId { get; set; }
        public Order? Order { get; set; }
        public Farm? Farm { get; set; }
        public User? Consultant { get; set; }
    }
}
