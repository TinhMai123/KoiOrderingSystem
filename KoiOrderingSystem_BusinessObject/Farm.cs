using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class Farm : BaseModel
    {

        public int Id { get; set; }
        public string FarmName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? ManagerId { get; set; }
        public User? Manager { get; set; }
        public int EstablishedYear { get; set; }
        public ICollection<Koi> Kois { get; set; } = new List<Koi>();
        public ICollection<FarmKoiType> FarmKoiTypes { get; set; } = new List<FarmKoiType>();
        public ICollection<OrderTrip> OrderTrips { get; set; } = new List<OrderTrip>();
    }
}
