using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class FarmAnimal
    {
        public int FarmId { get; set; }
        public int AnimalVarietyId { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityAvailable { get; set; }
        public int? MinOrderQuantity { get; set; }
        public int? MaxOrderQuantity { get; set; }
        public string? CareInstructions { get; set; }
        public bool? IsInStock { get; set; }
        public double? DiscountPercentage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual AnimalVariety AnimalVariety { get; set; } = null!;
        public virtual Farm Farm { get; set; } = null!;
    }
}
