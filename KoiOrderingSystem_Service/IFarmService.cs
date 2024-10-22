using KoiOrderingSystem_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Service
{
    public interface IFarmService
    {
        void AddFarm(Farm newFarm);
        List<Farm> GetAllFarms();
        Farm GetFarmById(int id);
        void UpdateFarm(Farm farmToUpdate);
        void DeleteFarm(Farm farm);
    }
}
