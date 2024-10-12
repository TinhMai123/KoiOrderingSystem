using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public class Feedback : BaseModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string? Title { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; } = string.Empty;
        public Order? Order { get; set; }

    }
}
