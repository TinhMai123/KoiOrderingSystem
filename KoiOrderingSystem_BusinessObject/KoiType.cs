using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KoiOrderingSystem_BusinessObject
{
    public class KoiType : BaseModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;

        public bool IsEndangered { get; set; }

        public bool IsBatch { get; set; }

        [StringLength(250, ErrorMessage = "Picture URL can't be longer than 250 characters.")]
        public string Picture { get; set; } = string.Empty;

        public ICollection<Koi> Kois { get; set; } = new List<Koi>();
        public ICollection<KoiByBatch> KoiByBatches { get; set; } = new List<KoiByBatch>();
        public ICollection<FarmKoiType> FarmKoiTypes { get; set; } = new List<FarmKoiType>();
    }
}
