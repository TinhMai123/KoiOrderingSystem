using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service
{
    public interface IFarmKoiTypeService
    {
        void AddFarmKoiType(FarmKoiType newFarm);
        List<FarmKoiType> GetAllFarms();
        FarmKoiType GetFarmById(int id);
        void UpdateFarm(FarmKoiType farmKoiType);
        void DeleteFarm(FarmKoiType farmKoiType);
    }
}
