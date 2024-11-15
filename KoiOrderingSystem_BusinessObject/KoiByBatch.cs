using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_BusinessObject
{
    public class KoiByBatch : BaseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Size is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Size must be greater than zero.")]
        public int Size { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Koi Type ID is required.")]
        public int KoiTypeId { get; set; }

        public KoiType? KoiType { get; set; }

        public KoiOrderDetail? OrderDetailKoi { get; set; }
    }
}
