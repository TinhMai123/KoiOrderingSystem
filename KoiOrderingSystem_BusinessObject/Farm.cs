using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class Farm : BaseModel
    {

        public int Id { get; set; }
        public string? FarmName { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public int? ManagerId { get; set; }
        public User? Manager { get; set; }
        public int? EstablishedYear { get; set; }

        public virtual ICollection<Koi>? Kois { get; set; }
        public virtual ICollection<FarmKoiType>? FarmKoiTypes { get; set; }
        public virtual ICollection<OrderTrip>? OrderTrips { get; set; }
    }
}
