using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_BusinessObject
{
    public class BaseModel
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime DeletedAt {  get; set; }
        public DateTime UpdatedAt {  get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
