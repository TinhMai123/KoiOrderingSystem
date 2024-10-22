using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.impl
{
    public class FarmKoiTypeRepository : IFarmKoiTypeRepository
    {
        public void AddFarmKoiType(FarmKoiType newFarm)
        {
            FarmKoiTypeDAO.Instance.AddFarmKoiType(newFarm);
        }

        public void DeleteFarm(FarmKoiType farmKoiType)
        {
            FarmKoiTypeDAO.Instance.DeleteFarmKoiType(farmKoiType);
        }

        public List<FarmKoiType> GetAllFarms()=>FarmKoiTypeDAO.Instance.GetAllFarmKoiTypes();
        

        public FarmKoiType GetFarmById(int id)=>FarmKoiTypeDAO.Instance.GetFarmKoiTypeById(id);
        public void UpdateFarm(FarmKoiType farmKoiType) => FarmKoiTypeDAO.Instance.UpdateFarmKoiType(farmKoiType);
    }
}
