using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class Animal
    {
        public int AnimalId { get; set; }
        public int? AnimalVarietyId { get; set; }
        public int? FarmId { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public double? Weight { get; set; }
        public double? Length { get; set; }
        public string? Color { get; set; }
        public string? HealthStatus { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DateAdded { get; set; }
        public bool? IsAvailable { get; set; }
        public string? Notes { get; set; }

        public virtual AnimalVariety? AnimalVariety { get; set; }
        public virtual Farm? Farm { get; set; }
    }
}
