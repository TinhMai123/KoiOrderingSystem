using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KoiOrderingSystem_BusinessObject
{
    public class Koi : BaseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Weight is required.")]
        [Range(0.1, float.MaxValue, ErrorMessage = "Weight must be greater than zero.")]
        public float Weight { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Health Status is required.")]
        [StringLength(100, ErrorMessage = "Health Status can't be longer than 100 characters.")]
        public string HealthStatus { get; set; } = string.Empty;

        [Required(ErrorMessage = "Birth Date is required.")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        public bool Status { get; set; }

        [StringLength(250, ErrorMessage = "Picture URL can't be longer than 250 characters.")]
        public string Picture { get; set; } = string.Empty;

        [Required(ErrorMessage = "Koi Type ID is required.")]
        public int KoiTypeId { get; set; }

        public KoiType? KoiType { get; set; }

        [Required(ErrorMessage = "Farm ID is required.")]
        public int FarmId { get; set; }

        public Farm? Farm { get; set; }

        public ICollection<KoiOrderDetail> OrderDetailKois { get; set; } = new List<KoiOrderDetail>();
    }
}
