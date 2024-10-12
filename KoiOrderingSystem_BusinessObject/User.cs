using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class User : BaseModel
    {

        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Role { get; set; }
        public string? Picture {  get; set; }
        public int FarmId { get; set; }
        public Farm? Farm { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<OrderTrip>? OrderTrips { get; set; }
    }
}
