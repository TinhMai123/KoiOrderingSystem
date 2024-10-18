using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class KoiType : BaseModel
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsEndangered { get; set; }
        public bool? IsBatch { get; set; }
        public string? Picture {  get; set; }
        public virtual ICollection<Koi>? Kois { get; set; }
        public virtual ICollection<FarmKoiType>? FarmKoiTypes { get; set; }
    }
}
