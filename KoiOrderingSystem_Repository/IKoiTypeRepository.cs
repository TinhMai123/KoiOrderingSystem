using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository
{
    public interface IKoiTypeRepository
    {
        void AddKoiType(KoiType koiType);
        List<KoiType> GetAllKoiTypes();
        KoiType GetKoiTypeById(int id);
        void UpdateKoiType(KoiType koiType);
        void DeleteKoiType(KoiType koiType);
    }
}
