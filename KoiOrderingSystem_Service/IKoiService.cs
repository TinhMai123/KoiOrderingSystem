using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service
{
    public interface IKoiService
    {
        public void addKoi(Koi koi);
        public void removeKoi(Koi koi);
        public Koi getKoiById(int koiId);
        public void updateKoi(Koi koi);
        public List<Koi> getall();
    }
}
