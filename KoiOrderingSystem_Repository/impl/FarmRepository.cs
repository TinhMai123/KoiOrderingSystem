using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_DAO;
using System.Collections.Generic;

namespace KoiOrderingSystem_Repository
{
    public class FarmRepository : IFarmRepository
    {
        public void AddFarm(Farm newFarm)
        {
            FarmDAO.Instance.Add(newFarm);
        }

        public List<Farm> GetAllFarms()
        {
            return FarmDAO.Instance.GetAll();
        }

        public Farm GetFarmById(int id)
        {
            return FarmDAO.Instance.GetById(id);
        }

        public void UpdateFarm(Farm farmToUpdate) => FarmDAO.Instance.Update(farmToUpdate);


        public void DeleteFarm(Farm farm) => FarmDAO.Instance.Remove(farm);
    }
}
