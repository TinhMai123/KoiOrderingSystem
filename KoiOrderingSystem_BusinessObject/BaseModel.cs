using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_BusinessObject
{
    public class BaseModel
    {
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime DeleteAt {  get; set; }
        public DateTime UpdateAt {  get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
