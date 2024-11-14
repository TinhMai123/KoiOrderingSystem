using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class KoiType : BaseModel
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsEndangered { get; set; }
        public bool IsBatch { get; set; }
        public string Picture { get; set; } = string.Empty;
        public ICollection<Koi> Kois { get; set; } = new List<Koi>();
        public ICollection<FarmKoiType> FarmKoiTypes { get; set; } = new List<FarmKoiType>();
    }
}
