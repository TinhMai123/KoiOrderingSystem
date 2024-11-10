
using KoiOrderingSystem_BusinessObject;
using KoiOrderingSystem_BusinessObject.Data;
using KoiOrderingSystem_DAO;
using KoiOrderingSystem_Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystem_Repository.Repo
{
    public class FarmKoiTypeRepo : IFarmKoiTypeRepo
    {
        public async Task<bool> Add(FarmKoiType model)
        {
            return await FarmKoiTypeDAO.Instance.Add(model);
        }

        public async Task<List<FarmKoiType>> GetAll()
        {
            return await FarmKoiTypeDAO.Instance.GetAll();
        }

        public async Task<FarmKoiType?> GetById(int id)
        {
            return await FarmKoiTypeDAO.Instance.GetById(id);
        }

        public async Task<List<FarmKoiType>> ReadAll()
        {
            return await FarmKoiTypeDAO.Instance.ReadAll();
        }

        public async Task<FarmKoiType?> ReadById(int id)
        {
            return await FarmKoiTypeDAO.Instance.ReadById(id);
        }

        public async Task<bool> Remove(int id)
        {
            return await FarmKoiTypeDAO.Instance.Remove(id);
        }

        public async Task<bool> Update(FarmKoiType model)
        {
            return await FarmKoiTypeDAO.Instance.Update(model);
        }
    }
}
