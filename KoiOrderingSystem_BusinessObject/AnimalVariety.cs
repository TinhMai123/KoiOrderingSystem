using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class AnimalVariety
    {
        public AnimalVariety()
        {
            Animals = new HashSet<Animal>();
            FarmAnimals = new HashSet<FarmAnimal>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int AnimalVarietyId { get; set; }
        public string? TypeName { get; set; }
        public string? ScientificName { get; set; }
        public string? Description { get; set; }
        public int? LifespanYears { get; set; }
        public double? AverageSize { get; set; }
        public string? Habitat { get; set; }
        public string? Diet { get; set; }
        public string? ColorPattern { get; set; }
        public bool? IsEndangered { get; set; }
        public string? CareDifficulty { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
        public virtual ICollection<FarmAnimal> FarmAnimals { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
