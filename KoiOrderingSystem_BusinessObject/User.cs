using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Password { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public ICollection<Farm> Farms { get; set; } = new List<Farm>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<OrderTrip> OrderTrips { get; set; } = new List<OrderTrip>();
    }
}
