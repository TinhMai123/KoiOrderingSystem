using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KoiOrderingSystem_BusinessObject
{
    public class Koi : BaseModel
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public string Description { get; set; } = string.Empty;
        //public double Price { get; set; }
        public string HealthStatus { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime DateAdded {  get; set; } = DateTime.Now;
        public bool Status { get; set; }
        public string Picture { get; set; } = string.Empty;
        public int KoiTypeId { get; set; }
        public int? OrderDetailKoiId { get; set; }

        [Required]
        public KoiType? KoiType { get; set; }
        public OrderKoiDetail? OrderDetailKoi { get; set; }
    }
}
