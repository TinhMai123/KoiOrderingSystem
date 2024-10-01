using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class Farm
    {
        public Farm()
        {
            Animals = new HashSet<Animal>();
            FarmAnimals = new HashSet<FarmAnimal>();
            Trips = new HashSet<Trip>();
        }

        public int FarmId { get; set; }
        public string? FarmName { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? OwnerName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public int? EstablishedYear { get; set; }
        public double? AreaSize { get; set; }
        public int? NumberOfKoi { get; set; }
        public bool? IsCertified { get; set; }
        public double? Rating { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<FarmAnimal> FarmAnimals { get; set; }
        public virtual ICollection<Trip> Trips { get; set; }
    }
}
