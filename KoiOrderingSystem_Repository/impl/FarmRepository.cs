using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_DAO;
using System.Collections.Generic;

namespace KoiOrderingSystem_Repository
{
    public class FarmRepository : IFarmRepository
    {
        public void AddFarm(Farm newFarm)
        {
            FarmDAO.Instance.AddFarm(newFarm);
        }

        public List<Farm> GetAllFarms()
        {
            return FarmDAO.Instance.GetAllFarms();
        }

        public Farm GetFarmById(int id)
        {
            return FarmDAO.Instance.GetFarmById(id);
        }

        public void UpdateFarm(Farm farmToUpdate)=>FarmDAO.Instance.UpdateFarm(farmToUpdate);
        

        public void DeleteFarm(Farm farm)=>FarmDAO.Instance.DeleteFarm(farm);
    }
}
